using System;
using System.Diagnostics;
using System.Windows.Forms;
using Network_Analyzer.Extensions;
using Network_Analyzer.Models;
using Network_Analyzer.Services;

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

			cbProgramLanguage.Text = Services.Settings.Language;
			tbAddressListener.Text = Services.Settings.Address;
			tbPortListener.Text = Services.Settings.Port;
			tbFolderSaved.Text = Services.Settings.Folder;

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

                Services.Settings.Language = cbProgramLanguage.Text;
                Services.Settings.Address = tbAddressListener.Text;
                Services.Settings.Port = tbPortListener.Text;
                Services.Settings.Folder = tbFolderSaved.Text;

                Services.Settings.SaveSettings();

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