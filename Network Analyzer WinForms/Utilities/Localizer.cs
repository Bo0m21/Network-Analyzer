using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using Network_Analyzer_WinForms.Models;

namespace Network_Analyzer_WinForms.Utilities
{
    /// <summary>
    ///     Class for translate project
    /// </summary>
    public static class Localizer
    {
        private static ResourceManager _mainResourse;

        /// <summary>
        ///     Loading resources for translate
        /// </summary>
        /// <param name="languagePrefix"></param>
        /// <param name="resourseBase"></param>
        /// <param name="delimeter"></param>
        public static void LoadLocalizer(Languages languagePrefix, string resourseBase, string delimeter = "_")
        {
            string fullResourseName = resourseBase;
            Assembly assembly = Assembly.GetExecutingAssembly();

            List<string> resList = assembly.GetManifestResourceNames().ToList();

            if (resList.Count(x => x.Equals(fullResourseName + delimeter + languagePrefix + ".resources")) == 1)
            {
                fullResourseName += delimeter + languagePrefix;
            }

            _mainResourse = new ResourceManager(fullResourseName, assembly);
        }

        /// <summary>
        ///     Method for translate string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string LocalizeString(string str)
        {
            return GetString(str);
        }

        /// <summary>
        ///     Method for get string in resources
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static string GetString(string name)
        {
            try
            {
                if (_mainResourse == null)
                {
                    return name;
                }

                return _mainResourse.GetString(name) ?? name;
            }
            catch
            {
                return name;
            }
        }

        /// <summary>
        ///     Method for translation form
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public static void LocalizeForm(Form form)
        {
            List<Control> controls = GetAllControls(form.Controls);

            form.Text = LocalizeString(form.Text);

            foreach (Control control in controls)
            {
                control.Text = LocalizeString(control.Text);

                if (control is DataGridView)
                {
                    foreach (DataGridViewColumn dataGridViewColumn in ((DataGridView) control).Columns)
                    {
                        dataGridViewColumn.HeaderText = LocalizeString(dataGridViewColumn.HeaderText);
                    }
                }

                if (control is MenuStrip)
                {
                    List<ToolStripMenuItem> toolStripItems = GetAllMenuItems(((MenuStrip) control).Items);

                    foreach (ToolStripItem toolStripItem in toolStripItems)
                    {
                        toolStripItem.Text = LocalizeString(toolStripItem.Text);
                    }
                }

                if (control is ComboBox)
                {
                    for (int i = 0; i < ((ComboBox) control).Items.Count; i++)
                    {
                        if (((ComboBox) control).Items[i] is string)
                        {
                            ((ComboBox) control).Items[i] = LocalizeString((string) ((ComboBox) control).Items[i]);
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Get all controls in form
        /// </summary>
        /// <param name="controlCollection"></param>
        /// <returns></returns>
        private static List<Control> GetAllControls(Control.ControlCollection controlCollection)
        {
            List<Control> list = new List<Control>();

            foreach (Control control in controlCollection)
            {
                list.Add(control);
                list.AddRange(GetAllControls(control.Controls));
            }

            return list;
        }

        /// <summary>
        ///     Get all menu items in menu
        /// </summary>
        /// <param name="toolStripItemCollection"></param>
        /// <returns></returns>
        private static List<ToolStripMenuItem> GetAllMenuItems(ToolStripItemCollection toolStripItemCollection)
        {
            List<ToolStripMenuItem> list = new List<ToolStripMenuItem>();

            foreach (ToolStripMenuItem toolStripMenuItem in toolStripItemCollection)
            {
                list.Add(toolStripMenuItem);
                list.AddRange(GetAllMenuItems(toolStripMenuItem.DropDownItems));
            }

            return list;
        }
    }
}