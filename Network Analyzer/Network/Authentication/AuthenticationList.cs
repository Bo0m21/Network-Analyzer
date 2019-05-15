using System;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Text;

namespace Network_Analyzer.Network.Authentication
{
    /// <summary>Stores a dictionary with username/password combinations.</summary>
    /// <remarks>This class can be used by a SOCKS5 listener.</remarks>
    /// <remarks>This class uses an MD5 has to store the passwords in a secure manner.</remarks>
    /// <remarks>The username is treated in a case-insensitive manner, the password is treated case-sensitive.</remarks>
    public class AuthenticationList
    {
        /// <summary>Gets the StringDictionary that's used to store the user/pass combinations.</summary>
        /// <value>A StringDictionary object that's used to store the user/pass combinations.</value>
        protected StringDictionary Listing { get; } = new StringDictionary();

        /// <summary>Gets an array with all the keys in the authentication list.</summary>
        /// <value>An array of strings containing all the keys in the authentication list.</value>
        public string[] Keys
        {
            get
            {
                var keys = Listing.Keys;
                var ret = new string[keys.Count];
                keys.CopyTo(ret, 0);

                return ret;
            }
        }

        /// <summary>Gets an array with all the hashes in the authentication list.</summary>
        /// <value>An array of strings containing all the hashes in the authentication list.</value>
        public string[] Hashes
        {
            get
            {
                var values = Listing.Values;
                var ret = new string[values.Count];
                values.CopyTo(ret, 0);

                return ret;
            }
        }

        /// <summary>Adds an item to the list.</summary>
        /// <param name="username">The username to add.</param>
        /// <param name="password">The corresponding password to add.</param>
        /// <exception cref="ArgumentNullException">Either Username or Password is null.</exception>
        public void AddItem(string username, string password)
        {
            if (password == null)
                throw new ArgumentNullException();

            AddHash(username,
                Convert.ToBase64String(new MD5CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(password))));
        }

        /// <summary>Adds an item to the list.</summary>
        /// <param name="username">The username to add.</param>
        /// <param name="passHash">The hashed password to add.</param>
        /// <exception cref="ArgumentNullException">Either Username or Password is null.</exception>
        public void AddHash(string username, string passHash)
        {
            if (username == null || passHash == null)
                throw new ArgumentNullException();

            if (Listing.ContainsKey(username))
                Listing[username] = passHash;
            else
                Listing.Add(username, passHash);
        }

        /// <summary>Removes an item from the list.</summary>
        /// <param name="username">The username to remove.</param>
        /// <exception cref="ArgumentNullException">Username is null.</exception>
        public void RemoveItem(string username)
        {
            if (username == null)
                throw new ArgumentNullException();

            Listing.Remove(username);
        }

        /// <summary>Checks whether a user/pass combination is present in the collection or not.</summary>
        /// <param name="username">The username to search for.</param>
        /// <param name="password">The corresponding password to search for.</param>
        /// <returns>True when the user/pass combination is present in the collection, false otherwise.</returns>
        public bool IsItemPresent(string username, string password)
        {
            return IsHashPresent(username,
                Convert.ToBase64String(new MD5CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(password))));
        }

        /// <summary>Checks whether a username is present in the collection or not.</summary>
        /// <param name="username">The username to search for.</param>
        /// <returns>True when the username is present in the collection, false otherwise.</returns>
        public bool IsUserPresent(string username)
        {
            return Listing.ContainsKey(username);
        }

        /// <summary>Checks whether a user/passhash combination is present in the collection or not.</summary>
        /// <param name="username">The username to search for.</param>
        /// <param name="passHash">The corresponding password hash to search for.</param>
        /// <returns>True when the user/passhash combination is present in the collection, false otherwise.</returns>
        public bool IsHashPresent(string username, string passHash)
        {
            return Listing.ContainsKey(username) && Listing[username].Equals(passHash);
        }

        /// <summary>Clears the authentication list.</summary>
        public void Clear()
        {
            Listing.Clear();
        }
    }
}