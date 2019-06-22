namespace Network_Analyzer.Models.Configuration
{
    /// <summary>
    ///     This base class configuration field
    /// </summary>
    public class ConfigurationFieldModel
    {
        /// <summary>
        ///     Field name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Field description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Field type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        ///     Position at data
        /// </summary>
        public long Position { get; set; }

        /// <summary>
        ///     Field reverse (type sequence)
        /// </summary>
        public bool Reverse { get; set; }

        /// <summary>
        ///     Length field(for example - string)
        /// </summary>
        public string Length { get; set; }
    }
}