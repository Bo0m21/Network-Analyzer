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
            ConfigurationPackets = new List<ConfigurationPacketModel>();
        }

        // TODO Добавить структуры и глабальные поля и возможно названеие конфига

        /// <summary>
        ///     Configuration packets
        /// </summary>
        public List<ConfigurationPacketModel> ConfigurationPackets { get; set; }
    }
}