using System;
using System.Windows.Forms;
using Network_Analyzer_WinForms.Models;
using Network_Analyzer_WinForms.Utilities;

namespace Network_Analyzer_WinForms
{
    internal static class Program
    {
        /// <summary>
        ///     Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        private static void Main()
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