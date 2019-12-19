using System.Collections.Generic;

namespace Network_Analyzer.Models.Configuration
{
    /// <summary>
    ///     This class has packets for configuration
    /// </summary>
    public class ConfigurationModel
    {
        public ConfigurationModel()
        {
			ConfigurationStructures = new List<ConfigurationClassModel>();
			ConfigurationPackets = new List<ConfigurationClassModel>();
        }

		/// <summary>
		///     Configuration structures
		/// </summary>
		public List<ConfigurationClassModel> ConfigurationStructures { get; set; }

		/// <summary>
		///     Configuration packets
		/// </summary>
		public List<ConfigurationClassModel> ConfigurationPackets { get; set; }
    }
}