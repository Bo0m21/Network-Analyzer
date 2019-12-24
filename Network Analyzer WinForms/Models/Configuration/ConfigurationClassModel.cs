using System.Collections.Generic;

namespace Network_Analyzer_WinForms.Models.Configuration
{
	/// <summary>
	///     This class has information and fields for configuration class
	/// </summary>
	public class ConfigurationClassModel
	{
		public ConfigurationClassModel()
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