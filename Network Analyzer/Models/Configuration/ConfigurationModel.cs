using System.Collections.Generic;

namespace Network_Analyzer.Models.Configuration
{
    /// <summary>
    ///     This class has information for configuration
    /// </summary>
    public class ConfigurationModel
    {
        public ConfigurationModel()
        {
            ConfigurationPackets = new List<ConfigurationPacketModel>();
        }

        // TODO Добавить структуры и глабальные поля

        /// <summary>
        ///     Configuration packets
        /// </summary>
        public List<ConfigurationPacketModel> ConfigurationPackets { get; set; }
    }
}