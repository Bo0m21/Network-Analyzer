using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Network_Analyzer.Extensions;
using Network_Analyzer.Models.Configuration;
using Network_Analyzer.Models.Connection;
using Network_Analyzer.Services;

namespace Network_Analyzer
{
    public partial class ConfigurationPacketField : Form
    {
        private readonly ConnectionPacketModel m_ConnectionPacketModel;
        private readonly ConfigurationPacketModel m_ConfigurationPacketModel;

	    // TODO Сделать редактирование и так же переделать конфтруктор под массив филдов и сделать его же для работы со структурами
        public ConfigurationPacketField(ConnectionPacketModel connectionPacket, ConfigurationPacketModel configurationPacket)
        {
            InitializeComponent();
            Localizer.LocalizeForm(this);

            m_ConnectionPacketModel = connectionPacket;
			m_ConfigurationPacketModel = configurationPacket;
		}

        private void ConfigurationField_Load(object sender, EventArgs e)
        {
            cbSequenceType.SelectedIndex = 0;
            cbType.SelectedIndex = 0;

            foreach (var configurationPacket in m_ConfigurationPacketModel.ConfigurationPacketFields)
            {
	            if (configurationPacket.Type == Localizer.LocalizeString("Types.Byte") ||
	                configurationPacket.Type == Localizer.LocalizeString("Types.Sbyte") ||
	                configurationPacket.Type == Localizer.LocalizeString("Types.Short") ||
	                configurationPacket.Type == Localizer.LocalizeString("Types.Ushort") ||
	                configurationPacket.Type == Localizer.LocalizeString("Types.Int") ||
	                configurationPacket.Type == Localizer.LocalizeString("Types.Uint") ||
	                configurationPacket.Type == Localizer.LocalizeString("Types.Long") ||
	                configurationPacket.Type == Localizer.LocalizeString("Types.Ulong") ||
	                configurationPacket.Type == Localizer.LocalizeString("Types.Float") ||
	                configurationPacket.Type == Localizer.LocalizeString("Types.Double"))
	            {
		            cbLength.Items.Add(configurationPacket.Name);
	            }
            }

			lblInformation.Text = Localizer.LocalizeString("ConfigurationField.LoadedSuccessfully");
        }

		public void SetPosition(long position)
		{
			if (position == m_ConnectionPacketModel.Data.Length || position == -1)
			{
				tbPosition.Text = "0";
			}
			else
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

		private void CbType_SelectedIndexChanged(object sender, EventArgs e)
        {
	        cbLength.Enabled = (string) cbType.SelectedItem == Localizer.LocalizeString("Types.String");
	        
	        UpdateValue();
        }

        private void CbSequenceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateValue();
        }

        private void TbPosition_TextChanged(object sender, EventArgs e)
        {
            UpdateValue();
        }

        private void CbLength_TextChanged(object sender, EventArgs e)
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

            tbValue.Text = m_ConnectionPacketModel.Data.GetValue((string)cbType.SelectedItem, position, reverse);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
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

            if (m_ConfigurationPacketModel.ConfigurationPacketFields.FirstOrDefault(c => c.Name == tbName.Text) != null)
            {
	            lblInformation.Text = Localizer.LocalizeString("ConfigurationField.ErrorNameAlreadyExists");
				return;
            }

            if (string.IsNullOrEmpty(tbDescription.Text))
            {
                lblInformation.Text = Localizer.LocalizeString("ConfigurationField.ErrorFieldDescriptionCannotBeEmpty");
                return;
            }

            if (!long.TryParse(tbPosition.Text, out long position))
            {
                lblInformation.Text = Localizer.LocalizeString("ConfigurationField.ErrorsPosition");
                return;
            }

            if (cbType.Text == Localizer.LocalizeString("Types.String"))
            {
	            if (string.IsNullOrEmpty(cbLength.Text))
	            {
					lblInformation.Text = Localizer.LocalizeString("ConfigurationField.ErrorsLengthEmpty");
					return;
	            }

	            var configurationPacket =  m_ConfigurationPacketModel.ConfigurationPacketFields.FirstOrDefault(c => c.Name == cbLength.Text);

				if (!long.TryParse(cbLength.Text, out long length) && configurationPacket == null)
	            {
		            lblInformation.Text = Localizer.LocalizeString("ConfigurationField.ErrorsLengthCanNotParted");
					return;
	            }
            }

			// TODO сделать пересчет всех байтов в пакете чтобы друг на друга никто не создавал и не наезжал
			
            bool reverse = cbSequenceType.Text != Localizer.LocalizeString("SequenceTypes.LittleEndian");

            ConfigurationPacketFieldModel configurationPacketFieldModel = new ConfigurationPacketFieldModel
            {
                Name = tbName.Text,
                Description = tbDescription.Text,
                Type = cbType.Text,
                Reverse = reverse,
                Position = position,
                Length = cbLength.Text
            };

            m_ConfigurationPacketModel.ConfigurationPacketFields.Add(configurationPacketFieldModel);

			Close();
        }
    }
}