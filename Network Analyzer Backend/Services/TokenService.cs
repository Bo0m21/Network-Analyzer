using System;
using System.Linq;
using Network_Analyzer_Backend.Interfaces;
using Network_Analyzer_Backend.Models;
using Network_Analyzer_Backend.Models.Entities;

namespace Network_Analyzer_Backend.Services
{
    public class TokenService : ITokenService
    {
        private readonly DatabaseContext _databaseContext;

        public TokenService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        /// <summary>
        ///     Get token by UserId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GetToken(long userId)
        {
            Token token = _databaseContext.Tokens.FirstOrDefault(c => c.UserId == userId);
            return token == null ? "" : token.UniqueToken;
        }

        /// <summary>
        ///     Generate token by UserId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GenerateToken(long userId)
        {
            Token token = _databaseContext.Tokens.FirstOrDefault(c => c.UserId == userId);

            if (token == null)
            {
                token = new Token
                {
                    UserId = userId,
                    UniqueToken = CreateToken()
                };

                _databaseContext.Tokens.Add(token);
                _databaseContext.SaveChanges();
            }
            else
            {
                token.UniqueToken = CreateToken();
                _databaseContext.SaveChanges();
            }

            return token.UniqueToken;
        }

        /// <summary>
        ///     Create token
        /// </summary>
        /// <returns></returns>
        private string CreateToken()
        {
            return new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789", 72)
                .Select(s => s[new Random().Next(s.Length)]).ToArray()) + "=";
        }
    }
}