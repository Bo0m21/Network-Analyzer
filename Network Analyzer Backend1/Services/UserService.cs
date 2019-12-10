using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Network_Analyzer_Backend.Helpers;
using Network_Analyzer_Backend.Interfaces;
using Network_Analyzer_Backend.Models;
using Network_Analyzer_Backend.Models.Entities;

namespace Network_Analyzer_Backend.Services
{
    public class UserService : IUserService
    {
        private readonly DatabaseContext _databaseContext;

        public UserService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        /// <summary>
        ///     Authenticate user by username and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            User user = _databaseContext.Users.SingleOrDefault(x => x.Username == username);

            // Check if username exists
            if (user == null)
            {
                throw new Exception("Username or password is incorrect");
            }

            // Check if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                throw new Exception("Username or password is incorrect");
            }

            // Authentication successful
            return user;
        }

        /// <summary>
        ///     Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetUser(long id)
        {
            User user = _databaseContext.Users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            return user;
        }

        /// <summary>
        ///     Create user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User Create(User user, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Password is required");
            }

            if (_databaseContext.Users.Any(x => x.Username == user.Username))
            {
                throw new Exception("Username \"" + user.Username + "\" is already taken");
            }

            if (_databaseContext.Users.Any(x => x.Email == user.Email))
            {
                throw new Exception("Email \"" + user.Email + "\" is already taken");
            }

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            user.Role = Roles.User;

            _databaseContext.Users.Add(user);
            _databaseContext.SaveChanges();

            return user;
        }

        /// <summary>
        ///     Update user
        /// </summary>
        /// <param name="userParam"></param>
        /// <param name="password"></param>
        public void Update(User userParam, string password)
        {
            User user = _databaseContext.Users.Find(userParam.Id);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            if (userParam.Username != user.Username)
            {
                // Username has changed so check if the new username is already taken
                if (_databaseContext.Users.Any(x => x.Username == userParam.Username))
                {
                    throw new Exception("Username " + userParam.Username + " is already taken");
                }
            }

            if (userParam.Email != user.Email)
            {
                // Email has changed so check if the new email is already taken
                if (_databaseContext.Users.Any(x => x.Email == userParam.Email))
                {
                    throw new Exception("Email " + userParam.Email + " is already taken");
                }
            }

            // Update user properties
            user.Username = userParam.Username;
            user.Email = userParam.Email;

            // Update password if it was entered
            if (!string.IsNullOrWhiteSpace(password))
            {
                CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            _databaseContext.Users.Update(user);
            _databaseContext.SaveChanges();
        }

        /// <summary>
        ///     Delete user
        /// </summary>
        /// <param name="id"></param>
        public void Delete(long id)
        {
            User user = _databaseContext.Users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            user.IsDeleted = true;
            _databaseContext.SaveChanges();
        }

        /// <summary>
        ///     Create password hash and salt
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passwordHash"></param>
        /// <param name="passwordSalt"></param>
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            }

            using (HMACSHA512 hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        /// <summary>
        ///     Verify password hash
        /// </summary>
        /// <param name="password"></param>
        /// <param name="storedHash"></param>
        /// <param name="storedSalt"></param>
        /// <returns></returns>
        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            }

            if (storedHash.Length != 64)
            {
                throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            }

            if (storedSalt.Length != 128)
            {
                throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");
            }

            using (HMACSHA512 hmac = new HMACSHA512(storedSalt))
            {
                byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                if (computedHash.Where((t, i) => t != storedHash[i]).Any())
                {
                    return false;
                }
            }

            return true;
        }
    }
}