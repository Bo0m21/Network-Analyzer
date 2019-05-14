using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace Network_Analyzer.Localization
{
    /// <summary>
    /// Класс для перевода строковых значений
    /// </summary>
    public static class Localizer
    {
        private static ResourceManager _mainResourse = null;

        /// <summary>
        /// Метод для загрузки ресурсов
        /// </summary>
        /// <param name="languagePrefix"></param>
        /// <param name="resourseBase"></param>
        /// <param name="delimeter"></param>
        public static void InitLocalizedResource(string languagePrefix, string resourseBase, string delimeter = "_")
        {
            var fullResourseName = resourseBase;
            var assembly = Assembly.GetExecutingAssembly();

            var resList = assembly.GetManifestResourceNames().ToList();

            if (resList.Count(x => x.Equals(fullResourseName + delimeter + languagePrefix + ".resources")) == 1)
                fullResourseName += delimeter + languagePrefix;

            _mainResourse = new ResourceManager(fullResourseName, assembly);
        }

        public static void Local(Form form)
        {
            

        }

        /// <summary>
        /// Метод для локализации ресурсов
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Localize(this string str)
        {
            return GetString(str);
        }

        /// <summary>
        /// метод для получения конкретной строки из ресурсов
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static string GetString(string name)
        {
            try
            {
                if (_mainResourse == null)
                    return name;

                var result = _mainResourse.GetString(name);
                return result ?? name;
            }
            catch
            {
                return name;
            }
        }

        /// <summary>
        /// Метод для локализации ресурсов
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public static string LocalizeForm(this Form form)
        {
            var controls = GetAllControls(form.Controls);

            return GetAllControls(str);
        }

        /// <summary>
        /// Получение всех контролов на форме
        /// </summary>
        /// <param name="controlCollection"></param>
        /// <returns></returns>
        private static List<Control> GetAllControls(Control.ControlCollection controlCollection)
        {
            var list = new List<Control>();

            foreach (Control control in controlCollection)
            {
                list.Add(control);
                list.AddRange(GetAllControls(control.Controls));
            }

            return list;
        }
    }
}
