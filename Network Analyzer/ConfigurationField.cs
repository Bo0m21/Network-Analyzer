using System;
using System.Windows.Forms;
using Network_Analyzer.Extensions;
using Network_Analyzer.Models.Configuration;
using Network_Analyzer.Models.Connection;
using Network_Analyzer.Services;

namespace Network_Analyzer
{
    public partial class ConfigurationField : Form
    {
        private ConnectionPacketModel m_PacketModel;
        private long m_Position;

        private ConfigurationFieldModel m_ConfigurationFieldModel;

        public ConfigurationField(ConnectionPacketModel packet)
        {
            InitializeComponent();
            Localizer.LocalizeForm(this);

            m_PacketModel = packet;
        }

        public ConfigurationField(ConnectionPacketModel packet, long position) : this(packet)
        {
            m_Position = position;
        }

        private void ConfigurationField_Load(object sender, EventArgs e)
        {
            cbSequenceType.SelectedIndex = 0;
            cbType.SelectedIndex = 0;
            tbPosition.Text = m_Position.ToString();

            lblInformation.Text = Localizer.LocalizeString("ConfigurationField.LoadedSuccessfully");
        }

        private void CbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)cbType.SelectedItem == Localizer.LocalizeString("Types.String"))
            {
                cbLength.Enabled = true;
            }
            else
            {
                cbLength.Enabled = false;
            }

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
            bool reverse = cbSequenceType.Text == Localizer.LocalizeString("SequenceTypes.LittleEndian") ? false : true;

            if (!long.TryParse(tbPosition.Text, out long position))
            {
                lblInformation.Text = Localizer.LocalizeString("ConfigurationField.ErrorsPosition");
                return;
            }

            lblValue.Text = Localizer.LocalizeString("ConfigurationField.Value") + " " + m_PacketModel.Data.GetValue((string)cbType.SelectedItem, position, reverse);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text))
            {
                lblInformation.Text = Localizer.LocalizeString("ConfigurationField.ErrorFieldCannotBeEmpty");
                return;
            }

            if (string.IsNullOrEmpty(tbDescription.Text))
            {
                lblInformation.Text = Localizer.LocalizeString("ConfigurationField.ErrorFieldCannotBeEmpty");
                return;
            }

            if (!long.TryParse(tbPosition.Text, out long position))
            {
                lblInformation.Text = Localizer.LocalizeString("ConfigurationField.ErrorsPosition");
                return;
            }

            if (cbType.Text == Localizer.LocalizeString("Types.String") && string.IsNullOrEmpty(cbLength.Text))
            {
                lblInformation.Text = Localizer.LocalizeString("ConfigurationField.ErrorsPosition");
                return;
            }

            bool reverse = cbSequenceType.Text == Localizer.LocalizeString("SequenceTypes.LittleEndian") ? false : true;

            m_ConfigurationFieldModel = new ConfigurationFieldModel()
            {
                Name = tbName.Text,
                Description = tbDescription.Text,
                Type = cbType.Text,
                Position = position,
                Reverse = reverse,
                Length = cbLength.Text
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        public ConfigurationFieldModel GetConfigurationFieldModel()
        {
            return m_ConfigurationFieldModel;
        }
    }
}