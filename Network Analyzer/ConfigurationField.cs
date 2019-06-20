using System;
using System.Windows.Forms;
using Network_Analyzer.Extensions;
using Network_Analyzer.Models.Connection;
using Network_Analyzer.Services;

namespace Network_Analyzer
{
    public partial class ConfigurationField : Form
    {
        private ConnectionPacketModel m_PacketModel;
        private long m_StartIndex;

        public ConfigurationField(ConnectionPacketModel packet)
        {
            InitializeComponent();
            Localizer.LocalizeForm(this);

            m_PacketModel = packet;
        }

        private void ConfigurationField_Load(object sender, EventArgs e)
        {
            cbSequenceType.SelectedIndex = 0;
            cbType.SelectedIndex = 0;

            lblInformation.Text = Localizer.LocalizeString("ConfigurationField.LoadedSuccessfully");
        }

        // TODO переделать и так же переделать выбор из информации
        public void SetSettings(long startIndex = -1)
        {
            if (startIndex != -1)
            {
                // TODO переделать
                m_StartIndex = startIndex;
                tbStartIndex.Text = startIndex.ToString();
            }
        }

        private void CbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string) cbType.SelectedItem == Localizer.LocalizeString("Types.String"))
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

        private void TbStartIndex_TextChanged(object sender, EventArgs e)
        {
            UpdateValue();
        }

        private void CbLength_TextChanged(object sender, EventArgs e)
        {
            UpdateValue();
        }

        private void UpdateValue()
        {
            var reverse = cbSequenceType.SelectedIndex == 0 ? false : true;

            if (!long.TryParse(tbStartIndex.Text, out var startindex))
            {
                lblInformation.Text = Localizer.LocalizeString("Editor.ErrorsStartIndex");
                return;
            }

            if ((string) cbType.SelectedItem == Localizer.LocalizeString("Types.Byte"))
            {
                lblValue.Text = Localizer.LocalizeString("ConfigurationField.Value") + " " +
                                m_PacketModel.Data.ReadByte((int) startindex);
            }

            if ((string) cbType.SelectedItem == Localizer.LocalizeString("Types.Sbyte"))
            {
                lblValue.Text = Localizer.LocalizeString("ConfigurationField.Value") + " " +
                                m_PacketModel.Data.ReadSbyte((int) startindex);
            }

            if (m_StartIndex + 1 < m_PacketModel.Data.Length)
            {
                if ((string) cbType.SelectedItem == Localizer.LocalizeString("Types.Short"))
                {
                    lblValue.Text = Localizer.LocalizeString("ConfigurationField.Value") + " " +
                                    m_PacketModel.Data.ReadShort((int) startindex, reverse);
                }

                if ((string) cbType.SelectedItem == Localizer.LocalizeString("Types.Ushort"))
                {
                    lblValue.Text = Localizer.LocalizeString("ConfigurationField.Value") + " " +
                                    m_PacketModel.Data.ReadUshort((int) startindex, reverse);
                }
            }

            if (m_StartIndex + 3 < m_PacketModel.Data.Length)
            {
                if ((string) cbType.SelectedItem == Localizer.LocalizeString("Types.Int"))
                {
                    lblValue.Text = Localizer.LocalizeString("ConfigurationField.Value") + " " +
                                    m_PacketModel.Data.ReadInt((int) startindex, reverse);
                }

                if ((string) cbType.SelectedItem == Localizer.LocalizeString("Types.Uint"))
                {
                    lblValue.Text = Localizer.LocalizeString("ConfigurationField.Value") + " " +
                                    m_PacketModel.Data.ReadUint((int) startindex, reverse);
                }

                if ((string) cbType.SelectedItem == Localizer.LocalizeString("Types.Float"))
                {
                    lblValue.Text = Localizer.LocalizeString("ConfigurationField.Value") + " " +
                                    m_PacketModel.Data.ReadFloat((int) startindex, reverse);
                }
            }

            if (m_StartIndex + 7 < m_PacketModel.Data.Length)
            {
                if ((string) cbType.SelectedItem == Localizer.LocalizeString("Types.Long"))
                {
                    lblValue.Text = Localizer.LocalizeString("ConfigurationField.Value") + " " +
                                    m_PacketModel.Data.ReadLong((int) startindex, reverse);
                }

                if ((string) cbType.SelectedItem == Localizer.LocalizeString("Types.Ulong"))
                {
                    lblValue.Text = Localizer.LocalizeString("ConfigurationField.Value") + " " +
                                    m_PacketModel.Data.ReadUlong((int) startindex, reverse);
                }

                if ((string) cbType.SelectedItem == Localizer.LocalizeString("Types.Double"))
                {
                    lblValue.Text = Localizer.LocalizeString("ConfigurationField.Value") + " " +
                                    m_PacketModel.Data.ReadDouble((int) startindex, reverse);
                }
            }
        }
    }
}