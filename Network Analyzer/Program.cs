using System;
using System.Windows.Forms;
using Network_Analyzer.Localization;

namespace Network_Analyzer
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Установка соответствующей локали
            // TODO Сделать загрузку из конфигов!
            Localizer.InitLocalizedResource("ru", "Network_Analyzer.Localization.Languages.Resource");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
