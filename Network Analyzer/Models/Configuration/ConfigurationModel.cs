using System.Collections.Generic;

namespace Network_Analyzer.Models.Configuration
{
    /// <summary>
    ///     This class has information and fields for configuration
    /// </summary>
    public class ConfigurationModel
    {
        /// <summary>
        ///     Configuration name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Configuration description
        /// </summary>
        public string Descreption { get; set; }

        /// <summary>
        ///     Configuration fields
        /// </summary>
        public List<ConfigurationFieldModel> ConfigurationFields { get; set; }
    }
}