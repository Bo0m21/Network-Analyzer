using System.Collections.Generic;

namespace Network_Analyzer_Database.Models
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
        ///     Register key
        /// </summary>
        public string RegisterKey { get; set; }

        /// <summary>
        ///     Hardware key
        /// </summary>
        public string HardwareKey { get; set; }

        /// <summary>
        ///     Mark that user is deleted
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        ///     User connections
        /// </summary>
        public List<Connection> Connections { get; set; }
    }
}