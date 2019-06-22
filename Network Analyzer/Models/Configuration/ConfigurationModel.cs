﻿using System.Collections.Generic;

namespace Network_Analyzer.Models.Configuration
{
    /// <summary>
    ///     This class has information and fields for configuration
    /// </summary>
    public class ConfigurationModel
    {
        public ConfigurationModel()
        {
            ConfigurationFields = new List<ConfigurationFieldModel>();
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
        ///     Configuration fields
        /// </summary>
        public List<ConfigurationFieldModel> ConfigurationFields { get; set; }
    }
}