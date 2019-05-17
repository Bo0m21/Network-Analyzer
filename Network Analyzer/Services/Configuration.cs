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
        // Private variables
        private static string _language;
        private static string _address;
        private static string _port;

        // Properties
        public static string Language
        {
            get => _language;
            set => _language = value.ValidateLanguage() ? value : Languages.English.ToString();
        }

        public static string Address
        {
            get => _address;
            set => _address = value.ValidateAddress() ? value : "127.0.0.1";
        }

        public static string Port
        {
            get => _port;
            set => _port = value.ValidatePort() ? value : "35000";
        }

        /// <summary>
        ///     Loading configuration
        /// </summary>
        public static void LoadConfiguration()
        {
            Language = ConfigurationManager.AppSettings["Language"];
            Address = ConfigurationManager.AppSettings["Address"];
            Port = ConfigurationManager.AppSettings["Port"];
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

            configuration.Save(ConfigurationSaveMode.Modified);
        }
    }
}