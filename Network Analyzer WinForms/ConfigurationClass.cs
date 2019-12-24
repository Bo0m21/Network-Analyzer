using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Network_Analyzer_WinForms.Models.Configuration;
using Network_Analyzer_WinForms.Models.Connection;
using Network_Analyzer_WinForms.Models.SelectedTabControl;
using Network_Analyzer_WinForms.Utilities;

namespace Network_Analyzer
{
	public partial class ConfigurationClass : Form
	{
		private ConfigurationModel m_ConfigurationModel;
		private ConnectionPacketModel m_ConnectionPacketModel;
		private List<ConfigurationClassModel> m_ConfigurationClasses;
		private SelectedTabControlGeneralType m_SelectedTabControlGeneralType;

		public ConfigurationClass(ConfigurationModel configurationModel, ConnectionPacketModel connectionPacketModel, List<ConfigurationClassModel> configurationClasses, SelectedTabControlGeneralType selectedTabControlGeneralType)
		{
			InitializeComponent();
			Localizer.LocalizeForm(this);

			m_ConfigurationModel = configurationModel;
			m_ConnectionPacketModel = connectionPacketModel;
			m_ConfigurationClasses = configurationClasses;
			m_SelectedTabControlGeneralType = selectedTabControlGeneralType;
		}

		private void ConfigurationClass_Load(object sender, System.EventArgs e)
		{
			if (m_SelectedTabControlGeneralType == SelectedTabControlGeneralType.Packets)
			{
				tbOpcode.Text = m_ConnectionPacketModel.Opcode;
				tbOpcode.Enabled = false;
			}
			else if (m_SelectedTabControlGeneralType == SelectedTabControlGeneralType.ConfigurationPackets)
			{
				tbOpcode.Enabled = true;
			}
			else if (m_SelectedTabControlGeneralType == SelectedTabControlGeneralType.Structures)
			{
				tbOpcode.Enabled = false;
			}

			lblInformation.Text = Localizer.LocalizeString("ConfigurationClass.LoadedSuccessfully");
		}

		private void BtnCancel_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void BtnSave_Click(object sender, System.EventArgs e)
		{
			if (string.IsNullOrEmpty(tbName.Text))
			{
				lblInformation.Text = Localizer.LocalizeString("ConfigurationClass.ErrorConfigurationNameCannotBeEmpty");
				return;
			}

			if (!Regex.Match(tbName.Text, @"[a-zA-Z0-9]").Success)
			{
				lblInformation.Text = Localizer.LocalizeString("ConfigurationClass.ErrorOnlyEnglishLettersNumbers");
				return;
			}

			if (!char.IsLetter(tbName.Text[0]) || !char.IsUpper(tbName.Text[0]))
			{
				lblInformation.Text = Localizer.LocalizeString("ConfigurationClass.ErrorNameBeginCapitalLetter");
				return;
			}

			bool checkConfigurationName = m_ConfigurationModel.ConfigurationPackets.Any(c => c.Name == tbName.Text) ||
										  m_ConfigurationModel.ConfigurationStructures.Any(c => c.Name == tbName.Text);

			if (checkConfigurationName)
			{
				lblInformation.Text = Localizer.LocalizeString("ConfigurationClass.ErrorNameAlreadyExists");
				return;
			}

			string opcode = "";
			if (m_SelectedTabControlGeneralType == SelectedTabControlGeneralType.Packets)
			{
				opcode = m_ConnectionPacketModel.Opcode;
			}
			else if (m_SelectedTabControlGeneralType == SelectedTabControlGeneralType.ConfigurationPackets)
			{
				opcode = tbOpcode.Text;

				if (string.IsNullOrEmpty(opcode))
				{
					lblInformation.Text = Localizer.LocalizeString("ConfigurationClass.ErrorOpcodeCannotBeEmpty");
					return;
				}

				if (m_ConfigurationClasses.Any(c => c.Opcode == opcode))
				{
					lblInformation.Text = Localizer.LocalizeString("ConfigurationClass.ErrorOpcodeAlreadyExists");
					return;
				}
			}

			m_ConfigurationClasses.Add(new ConfigurationClassModel
			{
				Name = tbName.Text,
				Opcode = opcode
			});

			Close();
		}
	}
}
