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
        ///     Field type sequence
        /// </summary>
        public bool SequenceType { get; set; }

        /// <summary>
        ///     Field type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        ///     Start index at data
        /// </summary>
        public string StartIndex { get; set; }

        /// <summary>
        ///     Length field(for example - string)
        /// </summary>
        public string Length { get; set; }
    }
}