using System.Collections.Generic;

namespace Network_Analyzer_Backend.Models.Entities
{
    /// <summary>
    ///     This class has information about user
    /// </summary>
    public class User
    {
        /// <summary>
        ///     Identity user
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        ///     Identity token
        /// </summary>
        public long TokenId { get; set; }

        /// <summary>
        ///     Nickname user
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     Password user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///     Role user
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        ///     Password hash
        /// </summary>
        public byte[] PasswordHash { get; set; }

        /// <summary>
        ///     Password salt
        /// </summary>
        public byte[] PasswordSalt { get; set; }

        /// <summary>
        ///     Mark that user is deleted
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        ///     Token for user
        /// </summary>
        public Token Token { get; set; }

        /// <summary>
        ///     User connections
        /// </summary>
        public List<Connection> Connections { get; set; }
    }
}