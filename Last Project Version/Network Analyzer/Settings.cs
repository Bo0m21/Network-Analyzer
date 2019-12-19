using System;
using System.Diagnostics;
using System.Windows.Forms;
using Network_Analyzer.Code;
using Network_Analyzer.Extensions;
using Network_Analyzer.Models;

namespace Network_Analyzer
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            Localizer.LocalizeForm(this);
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            foreach (Languages language in Enum.GetValues(typeof(Languages)))
            {
                cbProgramLanguage.Items.Add(language.ToString());
            }

            cbProgramLanguage.Text = Code.Settings.Language;
            tbAddressListener.Text = Code.Settings.Address;
            tbPortListener.Text = Code.Settings.Port;
            tbFolderSaved.Text = Code.Settings.Folder;

            lblInformation.Text = Localizer.LocalizeString("Settings.SettingsLoadedSuccessfully");
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!cbProgramLanguage.Text.ValidateLanguage())
                {
                    lblInformation.Text = Localizer.LocalizeString("Settings.ErrorsValidationLanguage");
                    return;
                }

                if (!tbAddressListener.Text.ValidateAddress())
                {
                    lblInformation.Text = Localizer.LocalizeString("Settings.ErrorsValidationAddress");
                    return;
                }

                if (!tbPortListener.Text.ValidatePort())
                {
                    lblInformation.Text = Localizer.LocalizeString("Settings.ErrorsValidationPort");
                    return;
                }

                if (!tbFolderSaved.Text.ValidateFolder())
                {
                    lblInformation.Text = Localizer.LocalizeString("Settings.ErrorsValidationFolder");
                    return;
                }

                Code.Settings.Language = cbProgramLanguage.Text;
                Code.Settings.Address = tbAddressListener.Text;
                Code.Settings.Port = tbPortListener.Text;
                Code.Settings.Folder = tbFolderSaved.Text;

                Code.Settings.SaveSettings();

                lblInformation.Text = Localizer.LocalizeString("Settings.SettingsSavedSuccessfully");
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);

                lblInformation.Text = Localizer.LocalizeString("Settings.ErrorsSavingSettings");
            }
        }
    }
}