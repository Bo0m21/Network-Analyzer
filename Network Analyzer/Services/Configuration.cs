using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using Network_Analyzer.Extensions;
using Network_Analyzer.Models.Enums;

namespace Network_Analyzer.Services
{
	/// <summary>
	///     Class for work with configuration values
	/// </summary>
	public static class Configuration
	{
		/// <summary>
		///     Langeuage private variable
		/// </summary>
		private static string _language;

		/// <summary>
		///     Address private variable
		/// </summary>
		private static string _address;

		/// <summary>
		///     Port private variable
		/// </summary>
		private static string _port;

		/// <summary>
		///     Port private variable
		/// </summary>
		private static string _folder;

		/// <summary>
		///     Language property and validation
		/// </summary>
		public static string Language
		{
			get => _language;
			set => _language = value.ValidateLanguage() ? value : Languages.English.ToString();
		}

		/// <summary>
		///     Adreess property and validation
		/// </summary>
		public static string Address
		{
			get => _address;
			set => _address = value.ValidateAddress() ? value : "127.0.0.1";
		}

		/// <summary>
		///     Port property and validation
		/// </summary>
		public static string Port
		{
			get => _port;
			set => _port = value.ValidatePort() ? value : "35000";
		}

		/// <summary>
		///     Folder property and validation
		/// </summary>
		public static string Folder
		{
			get => _folder;
			set => _folder = value.ValidateFolder() ? value : "Connections";
		}

		/// <summary>
		///     Loading configuration
		/// </summary>
		public static void LoadConfiguration()
		{
			Language = ConfigurationManager.AppSettings["Language"];
			Address = ConfigurationManager.AppSettings["Address"];
			Port = ConfigurationManager.AppSettings["Port"];
			Folder = ConfigurationManager.AppSettings["Folder"];
		}

		/// <summary>
		///     Save configuration
		/// </summary>
		public static void SaveConfiguration()
		{
			var configuration = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

			if (configuration.AppSettings.Settings.AllKeys.Any(k => k == "Language"))
			{
				configuration.AppSettings.Settings["Language"].Value = Language;
			}
			else
			{
				configuration.AppSettings.Settings.Add("Language", Language);
			}

			if (configuration.AppSettings.Settings.AllKeys.Any(k => k == "Address"))
			{
				configuration.AppSettings.Settings["Address"].Value = Address;
			}
			else
			{
				configuration.AppSettings.Settings.Add("Address", Address);
			}

			if (configuration.AppSettings.Settings.AllKeys.Any(k => k == "Port"))
			{
				configuration.AppSettings.Settings["Port"].Value = Port;
			}
			else
			{
				configuration.AppSettings.Settings.Add("Port", Port);
			}

			if (configuration.AppSettings.Settings.AllKeys.Any(k => k == "Folder"))
			{
				configuration.AppSettings.Settings["Folder"].Value = Folder;
			}
			else
			{
				configuration.AppSettings.Settings.Add("Folder", Folder);
			}

			configuration.Save(ConfigurationSaveMode.Modified);
		}
	}
}