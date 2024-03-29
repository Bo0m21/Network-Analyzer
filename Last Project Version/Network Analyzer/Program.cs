﻿using System;
using System.Windows.Forms;
using Network_Analyzer.Code;
using Network_Analyzer.Models;

namespace Network_Analyzer
{
    internal static class Program
    {
        /// <summary>
        ///     Main entry point for the application
        /// </summary>
        [STAThread]
        private static void Main()
        {
            // Loading settings
            Code.Settings.LoadSettings();

            // Loading localizer from resources
            //Localizer.LoadLocalizer(Configuration.Language, "Network_Analyzer.Localization.Resource");

            // TODO Сейчас стоит только русский язык
            Localizer.LoadLocalizer(Languages.Russian.ToString(), "Network_Analyzer.Localization.Resource");

            // Loading form
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());

            // Saving settings
            Code.Settings.SaveSettings();
        }
    }
}