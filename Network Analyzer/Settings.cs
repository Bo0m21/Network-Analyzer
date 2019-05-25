using System;
using System.Diagnostics;
using System.Windows.Forms;
using Network_Analyzer.Extensions;
using Network_Analyzer.Models.Enums;
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

			cbProgramLanguage.Text = Configuration.Language;
			tbAddressListener.Text = Configuration.Address;
			tbPortListener.Text = Configuration.Port;
			tbFolderSaved.Text = Configuration.Folder;

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

				Configuration.Language = cbProgramLanguage.Text;
				Configuration.Address = tbAddressListener.Text;
				Configuration.Port = tbPortListener.Text;
				Configuration.Folder = tbFolderSaved.Text;

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