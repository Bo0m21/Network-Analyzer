using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace Network_Analyzer.Localization
{
    /// <summary>
    /// Класс для перевода проекта
    /// </summary>
    public static class Localizer
    {
        private static ResourceManager _mainResourse = null;

        /// <summary>
        /// Инициализация локализатора
        /// </summary>
        /// <param name="languagePrefix"></param>
        /// <param name="resourseBase"></param>
        /// <param name="delimeter"></param>
        public static void InitLocalizer(string languagePrefix, string resourseBase, string delimeter = "_")
        {
            var fullResourseName = resourseBase;
            var assembly = Assembly.GetExecutingAssembly();

            var resList = assembly.GetManifestResourceNames().ToList();

            if (resList.Count(x => x.Equals(fullResourseName + delimeter + languagePrefix + ".resources")) == 1)
                fullResourseName += delimeter + languagePrefix;

            _mainResourse = new ResourceManager(fullResourseName, assembly);
        }

        /// <summary>
        /// Метод для локализации строки
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string LocalizeString(string str)
        {
            return GetString(str);
        }

        /// <summary>
        /// Метод для получения конкретной строки из ресурсов
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
        /// Метод для локализации формы
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public static void LocalizeForm(Form form)
        {
            var controls = GetAllControls(form.Controls);

            form.Text = LocalizeString(form.Text);

            foreach (var control in controls)
            {
                control.Text = LocalizeString(control.Text);

                if (control is DataGridView)
                {
                    foreach (DataGridViewColumn dataGridViewColumn in ((DataGridView)control).Columns)
                    {
                        dataGridViewColumn.HeaderText = LocalizeString(dataGridViewColumn.HeaderText);
                    }
                }

                if (control is MenuStrip)
                {
                    foreach (ToolStripItem toolStripItem in ((MenuStrip)control).Items)
                    {
                        toolStripItem.Text = LocalizeString(toolStripItem.Text);

                        foreach (ToolStripMenuItem toolStripMenuItem in ((ToolStripMenuItem)toolStripItem).DropDownItems)
                        {
                            toolStripMenuItem.Text = LocalizeString(toolStripMenuItem.Text);
                        }
                    }
                }
            }
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
