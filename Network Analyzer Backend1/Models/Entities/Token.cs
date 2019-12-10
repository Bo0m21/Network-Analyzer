namespace Network_Analyzer_Backend.Models.Entities
{
    /// <summary>
    ///     This class has information token for user
    /// </summary>
    public class Token
    {
        /// <summary>
        ///     Identity token
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        ///     Identity user
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        ///     Unique token
        /// </summary>
        public string UniqueToken { get; set; }

        /// <summary>
        ///     User for token
        /// </summary>
        public User User { get; set; }
    }
}
