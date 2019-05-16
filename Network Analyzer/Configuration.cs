using System;
using System.Configuration;

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
            ---var language = (LanguagesEnums)Enum.Parse(typeof(LanguagesEnums), ConfigurationManager.AppSettings["Language"], true);
            var address = ConfigurationManager.AppSettings["Address"];
            var port = ConfigurationManager.AppSettings["Port"];


            var languages = Enum.GetValues(typeof(LanguagesEnums));

            if (string.IsNullOrEmpty(Language))
            {
                Language = "English";
            }

            if (string.IsNullOrEmpty(Address))
            {
                Address = "127.0.0.1";
            }

            if (string.IsNullOrEmpty(Port))
            {
                Port = "30000";
            }
        }

        /// <summary>
        /// Сохранение конфигураций
        /// </summary>
        public static void SaveConfiguration()
        {
        }
    }
}
