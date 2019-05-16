using System;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;

namespace Network_Analyzer
{
    /// <summary>
    /// Калсс для работы с сонфигурационными занчениями
    /// </summary>
    public static class Configuration
    {
        public static string Language { get; set; }
        public static string Address { get; set; }
        public static string Port { get; set; }

        /// <summary>
        /// Загрузка конфигураций
        /// </summary>
        public static void LoadConfiguration()
        {
            var language = ConfigurationManager.AppSettings["Language"];
            var address = ConfigurationManager.AppSettings["Address"];
            var port = ConfigurationManager.AppSettings["Port"];

            if (string.IsNullOrEmpty(language))
            {
                Language = Languages.English;
            }
            else
            {
                Enum.TryParse(language, out Languages parseLanguage);
                Language = parseLanguage;
            }

            if (string.IsNullOrEmpty(address))
            {
                Address = "127.0.0.1";
            }
            else
            {
                Address = address;
            }

            if (string.IsNullOrEmpty(port))
            {
                Port = 30000;
            }
            else
            {
                int.TryParse(port, out int parsePort);

                if (parsePort > 0 && parsePort < 65535)
                {
                    Port = parsePort;
                }
                else
                {
                    Port = 30000;
                }
            }
        }

        /// <summary>
        /// Сохранение конфигураций
        /// </summary>
        public static void SaveConfiguration()
        {
            var configuration = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

            if (configuration.AppSettings.Settings.AllKeys.Any(k => k == "Language"))
            {
                configuration.AppSettings.Settings["Language"].Value = Language.ToString();
            }
            else
            {
                configuration.AppSettings.Settings.Add("Language", Language.ToString());
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
                configuration.AppSettings.Settings["Port"].Value = Port.ToString();
            }
            else
            {
                configuration.AppSettings.Settings.Add("Port", Port.ToString());
            }

            configuration.Save(ConfigurationSaveMode.Modified);
        }
    }
}
