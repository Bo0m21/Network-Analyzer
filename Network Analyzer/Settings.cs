using Network_Analyzer.Localization;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Network_Analyzer
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            Localizer.LocalizeForm(this);
        }

        private void Settings_Load(object sender, System.EventArgs e)
        {
            foreach (Languages language in Enum.GetValues(typeof(Languages)))
            {
                cbProgramLanguage.Items.Add(language.ToString());
            }

            cbProgramLanguage.Text = Configuration.Language;
            tbAddressListener.Text = Configuration.Address;
            tbPortListener.Text = Configuration.Port;

            lblInformation.Text = Localizer.LocalizeString("Settings.SettingsLoadedSuccessfully");
        }

        private void BtnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            try
            {
                // TODO переписать это чтобы не было дублирования кода
                Configuration.Language = (Languages)Enum.Parse(typeof(Languages), cbProgramLanguage.Text);
                Configuration.Address = tbAddressListener.Text;
                Configuration.Port = int.Parse(tbPortListener.Text);

                Configuration.SaveConfiguration();

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
