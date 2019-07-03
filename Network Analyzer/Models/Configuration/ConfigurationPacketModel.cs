using System.Collections.Generic;

namespace Network_Analyzer.Models.Configuration
{
    /// <summary>
    ///     This class has information and fields for configuration packet
    /// </summary>
    public class ConfigurationPacketModel
    {
        public ConfigurationPacketModel()
        {
            ConfigurationPacketFields = new List<ConfigurationPacketFieldModel>();
        }

        /// <summary>
        ///     Configuration opcode
        /// </summary>
        public string Opcode { get; set; }

        /// <summary>
        ///     Configuration name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Configuration description
        /// </summary>
        public string Descreption { get; set; }

        /// <summary>
        ///     Configuration packet fields
        /// </summary>
        public List<ConfigurationPacketFieldModel> ConfigurationPacketFields { get; set; }
    }
}