using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Network_Analyzer.Code;
using Network_Analyzer.Extensions;
using Network_Analyzer.Models.Configuration;
using Network_Analyzer.Models.Connection;
using Network_Analyzer.Models.SelectedEncoding;
using Network_Analyzer.Models.SelectedPacket;

namespace Network_Analyzer
{
	public partial class ConfigurationField : Form
	{
		private readonly ConnectionPacketModel m_ConnectionPacketModel;
		private readonly ConfigurationModel m_ConfigurationModel;

		private readonly ConfigurationClassModel m_ConfigurationClassModel;
		private readonly ConfigurationFieldModel m_ConfigurationFieldModel;

		private readonly SelectedEncodingType m_SelectedEncodingType;

		public ConfigurationField(ConnectionPacketModel connectionPacket, ConfigurationModel configurationModel, ConfigurationClassModel configurationClass, SelectedEncodingType selectedEncodingType)
		{
			InitializeComponent();
			Localizer.LocalizeForm(this);

			m_ConnectionPacketModel = connectionPacket;
			m_ConfigurationModel = configurationModel;
			m_ConfigurationClassModel = configurationClass;
			m_SelectedEncodingType = selectedEncodingType;
		}

		public ConfigurationField(ConnectionPacketModel connectionPacket, ConfigurationModel configurationModel, ConfigurationClassModel configurationClass, ConfigurationFieldModel configurationFieldModel, SelectedEncodingType selectedEncodingType) : this(connectionPacket, configurationModel, configurationClass, selectedEncodingType)
		{
			m_ConfigurationFieldModel = configurationFieldModel;
		}

		private void ConfigurationField_Load(object sender, EventArgs e)
		{
			if (m_ConfigurationFieldModel != null)
			{
				SetSequenceType(m_ConfigurationFieldModel.SequenceType);
				SetType(m_ConfigurationFieldModel.Type);

				tbName.Text = m_ConfigurationFieldModel.Name;
				tbDescription.Text = m_ConfigurationFieldModel.Description;
				cbArray.Checked = m_ConfigurationFieldModel.IsArray;
				tbArrayLength.Text = m_ConfigurationFieldModel.ArrayLength.ToString();
				tbPosition.Text = m_ConfigurationFieldModel.Position.ToString();
				cbCommon.Text = m_ConfigurationFieldModel.Common;
			}

			lblInformation.Text = Localizer.LocalizeString("ConfigurationField.LoadedSuccessfully");
		}

		#region Set fields

		public void SetPosition(long position)
		{
			if (position != m_ConnectionPacketModel.Data.Length && position != -1)
			{
				tbPosition.Text = position.ToString();
			}
		}

		public void SetSequenceType(string sequenceType)
		{
			if (!string.IsNullOrEmpty(sequenceType))
			{
				int indexSequenceType = cbSequenceType.FindString(sequenceType);

				if (indexSequenceType != -1)
				{
					cbSequenceType.SelectedIndex = indexSequenceType;
				}
			}
		}

		public void SetType(string type)
		{
			if (!string.IsNullOrEmpty(type))
			{
				int indexType = cbType.FindString(type);

				if (indexType != -1)
				{
					cbType.SelectedIndex = indexType;
				}
			}
		}

		#endregion

		#region Update value

		private void CbArray_CheckedChanged(object sender, EventArgs e)
		{
			tbArrayLength.Enabled = cbArray.Checked;

			UpdateValue();
		}

		private void CbSequenceType_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateValue();
		}

		private void CbType_SelectedIndexChanged(object sender, EventArgs e)
		{
			cbCommon.ResetText();
			cbCommon.Items.Clear();

			if (cbType.Text == Localizer.LocalizeString("Types.String"))
			{
				foreach (var configurationField in m_ConfigurationClassModel.ConfigurationFields)
				{
					if (configurationField.Type != Localizer.LocalizeString("Types.String") && configurationField.Type != Localizer.LocalizeString("Types.Structure"))
					{
						cbCommon.Items.Add(configurationField.Name);
					}
				}

				lblCommon.Text = Localizer.LocalizeString("ConfigurationField.CommonString");
				cbCommon.Enabled = true;
			}
			else if (cbType.Text == Localizer.LocalizeString("Types.Structure"))
			{
				foreach (var configurationStructure in m_ConfigurationModel.ConfigurationStructures)
				{
					cbCommon.Items.Add(configurationStructure.Name);
				}

				lblCommon.Text = Localizer.LocalizeString("ConfigurationField.CommonStructure");
				cbCommon.Enabled = true;
			}
			else
			{
				lblCommon.Text = Localizer.LocalizeString("ConfigurationField.CommonString");
				cbCommon.Enabled = false;
			}

			UpdateValue();
		}

		private void TbPosition_TextChanged(object sender, EventArgs e)
		{
			UpdateValue();
		}

		private void CbCommon_TextChanged(object sender, EventArgs e)
		{
			UpdateValue();
		}

		private void UpdateValue()
		{
			bool reverse = cbSequenceType.Text != Localizer.LocalizeString("SequenceTypes.LittleEndian");

			if (!long.TryParse(tbPosition.Text, out long position))
			{
				lblInformation.Text = Localizer.LocalizeString("ConfigurationField.ErrorsPosition");
				return;
			}

			tbValue.Text = m_ConnectionPacketModel.Data.GetValue(cbType.Text, position, reverse, m_SelectedEncodingType);
		}

		#endregion

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void BtnSave_Click(object sender, EventArgs e)
		{
			long lengthArr = 0;	

			if (string.IsNullOrEmpty(tbName.Text))
			{
				lblInformation.Text = Localizer.LocalizeString("ConfigurationField.ErrorFieldNameCannotBeEmpty");
				return;
			}

			if (!Regex.Match(tbName.Text, @"[a-zA-Z0-9]").Success)
			{
				lblInformation.Text = Localizer.LocalizeString("ConfigurationField.ErrorOnlyEnglishLettersNumbers");
				return;
			}

			if (!char.IsLetter(tbName.Text[0]) || !char.IsUpper(tbName.Text[0]))
			{
				lblInformation.Text = Localizer.LocalizeString("ConfigurationField.ErrorNameBeginCapitalLetter");
				return;
			}

			if (m_ConfigurationClassModel.ConfigurationFields.Where(c => c != m_ConfigurationFieldModel).FirstOrDefault(c => c.Name == tbName.Text) != null)
			{
				lblInformation.Text = Localizer.LocalizeString("ConfigurationField.ErrorNameAlreadyExists");
				return;
			}

			if (cbArray.Checked)
			{
				if (!long.TryParse(tbArrayLength.Text, out long arrayLength))
				{
					lblInformation.Text = Localizer.LocalizeString("ConfigurationField.ErrorsPosition");
					return;
				}

				if (arrayLength == 0)
				{
					lblInformation.Text = Localizer.LocalizeString("ConfigurationField.ErrorsLengthCanNotBeZero");
					return;
				}

				lengthArr = arrayLength;
			}

            if (string.IsNullOrEmpty(cbSequenceType.Text))
            {
                lblInformation.Text = Localizer.LocalizeString("ConfigurationField.ErrorsSequenceType");
                return;
            }

            if (string.IsNullOrEmpty(cbType.Text))
            {
                lblInformation.Text = Localizer.LocalizeString("ConfigurationField.ErrorsType");
                return;
            }

            if (!long.TryParse(tbPosition.Text, out long position))
			{
				lblInformation.Text = Localizer.LocalizeString("ConfigurationField.ErrorsPosition");
				return;
			}

			if (m_ConfigurationClassModel.ConfigurationFields.Any(c => c.Position == position && c != m_ConfigurationFieldModel))
			{
				lblInformation.Text = Localizer.LocalizeString("ConfigurationField.ErrorsPositionAlreadyUse");
				return;
			}

            if (cbType.Text == Localizer.LocalizeString("Types.String"))
			{
				if (string.IsNullOrEmpty(cbCommon.Text))
				{
					lblInformation.Text = Localizer.LocalizeString("ConfigurationField.ErrorsLengthEmpty");
					return;
				}

				var configurationField = m_ConfigurationClassModel.ConfigurationFields.FirstOrDefault(c => c.Name == cbCommon.Text);

				if (!long.TryParse(cbCommon.Text, out long length) && configurationField == null)
				{
					lblInformation.Text = Localizer.LocalizeString("ConfigurationField.ErrorsEnteredLengthInvalid");
					return;
				}
			}

			if (cbType.Text == Localizer.LocalizeString("Types.Structure"))
			{
				if (string.IsNullOrEmpty(cbCommon.Text))
				{
					lblInformation.Text = Localizer.LocalizeString("ConfigurationField.ErrorsStructureEmpty");
					return;
				}

				var configurationStructure = m_ConfigurationModel.ConfigurationStructures.FirstOrDefault(c => c.Name == cbCommon.Text);

				if (configurationStructure == null)
				{
					lblInformation.Text = Localizer.LocalizeString("ConfigurationField.ErrorsEnteredStructureInvalid");
					return;
				}

				// TODO Сделать проверку имени при получении всех полей и так же сделать чтобы у структур не было зависимости
			}

            var fieldLength = m_ConfigurationModel.GetLengthByType(cbType.Text, cbCommon.Text);

            if (m_ConfigurationModel.GetEntryFieldByIndex(m_ConfigurationClassModel, position, fieldLength) != null)
            {
                lblInformation.Text = Localizer.LocalizeString("ConfigurationField.ErrorsPositionAlreadyUse");
                return;
            }

            if (m_ConfigurationFieldModel == null)
			{
				ConfigurationFieldModel configurationFieldModel = new ConfigurationFieldModel
				{
					Name = tbName.Text,
					Description = tbDescription.Text,
					Type = cbType.Text,
					SequenceType = cbSequenceType.Text,
					Position = position,
					IsArray = cbArray.Checked,
					ArrayLength = lengthArr,
					Common = cbCommon.Text
				};

				m_ConfigurationClassModel.ConfigurationFields.Add(configurationFieldModel);
			}
			else
			{
				string newName = tbName.Text;
				string oldName = m_ConfigurationFieldModel.Name;

				if (newName != oldName)
				{
					// Rename all related fields
					m_ConfigurationClassModel.RenameFieldNameAllRelatedFields(oldName, newName);
				}

				m_ConfigurationFieldModel.Name = newName;
				m_ConfigurationFieldModel.Description = tbDescription.Text;
				m_ConfigurationFieldModel.Type = cbType.Text;
				m_ConfigurationFieldModel.SequenceType = cbSequenceType.Text;
				m_ConfigurationFieldModel.Position = position;
				m_ConfigurationFieldModel.IsArray = cbArray.Checked;
				m_ConfigurationFieldModel.ArrayLength = lengthArr;
				m_ConfigurationFieldModel.Common = cbCommon.Text;
			}

			Close();
		}
	}
}