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
            // Загрузка конфигураций
            Configuration.LoadConfiguration();

            // Загрузка локализатора из ресурсов
            Localizer.LoadLocalizer("Russian", "Network_Analyzer.Localization.Resource");

            // TODO Исправить когдп будет английский язык
            //Localizer.LoadLocalizer(Configuration.Language.ToString(), "Network_Analyzer.Localization.Resource");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());

            // Сохранение конфигураций
            Configuration.SaveConfiguration();
        }
    }
}
