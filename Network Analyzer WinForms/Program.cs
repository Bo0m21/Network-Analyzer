using Network_Analyzer_WinForms.Models;
using Network_Analyzer_WinForms.Utilities;
using System;
using System.Windows.Forms;

namespace Network_Analyzer_WinForms
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // TODO Сделать загрузку конфигов и языка

            // TODO Сейчас стоит только русский язык
            Localizer.LoadLocalizer(Languages.Russian, "Network_Analyzer_WinForms.Localization.Resource");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Authentication());
        }
    }
}
