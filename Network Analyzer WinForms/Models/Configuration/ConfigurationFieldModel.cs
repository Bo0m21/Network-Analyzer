namespace Network_Analyzer_WinForms.Models.Configuration
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
		///     Field sequence type
		/// </summary>
		public string SequenceType { get; set; }

        /// <summary>
        ///     Position at data
        /// </summary>
        public long Position { get; set; }

		/// <summary>
		///		If field array
		/// </summary>
		public bool IsArray { get; set; }

		/// <summary>
		///		Array length
		/// </summary>
		public long ArrayLength { get; set; }

		/// <summary>
		///     Common field(Name structure/field or length)
		/// </summary>
		public string Common { get; set; }
    }
}