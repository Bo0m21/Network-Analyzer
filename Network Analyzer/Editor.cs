using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Network_Analyzer.Models;
using Network_Analyzer.Network.Data;
using Network_Analyzer.Services;
using Network_Analyzer.Models.Enums;
using System.Threading;
using Network_Analyzer.Models.Search;
using System.Diagnostics;
using HexBoxForm;
using Network_Analyzer.Extensions;

namespace Network_Analyzer
{
    public partial class Editor : Form
    {
        private ConnectionModel m_ConnectionModel;
        //////private IDecryptor m_Decryptor;

        private SelectedPacketEncryptionType m_SelectedPacketEncryptionType;
        private SelectedPacketType m_SelectedPacketType;

        private SearchModel m_SearchModel;

        //////private List<ConfigurationModel> m_ConfigurationModels;

        //////private System.Windows.Forms.Timer m_TimerDecryptPacketsUpdate;
        //////private object m_TimerDecryptPacketsUpdateLock = new object();

        private System.Windows.Forms.Timer m_TimerDataGridViewUpdate;
        private object m_TimerDataGridViewUpdateLock = new object();

        public Editor(long connectionId)
        {
            InitializeComponent();
            Localizer.LocalizeForm(this);

            m_ConnectionModel = Connections.GetConnection(connectionId);
        }

        private void Editor_Load(object sender, EventArgs e)
        {
            m_SelectedPacketEncryptionType = SelectedPacketEncryptionType.Encrypted;
            m_SelectedPacketType = SelectedPacketType.AllPackets;

            cbTypePackets.SelectedIndex = 0;
            cbTypeEncryptionPackets.SelectedIndex = 0;
            //////cbSearchType.SelectedIndex = 0;
            //////cbSequenceType.SelectedIndex = 0;

            //////((Control)tpConfiguration).Enabled = false;

            //////m_TimerDecryptPacketsUpdate = new System.Windows.Forms.Timer();
            //////m_TimerDecryptPacketsUpdate.Tick += timerDecryptPacketsUpdate_Tick;

            m_TimerDataGridViewUpdate = new System.Windows.Forms.Timer();
            m_TimerDataGridViewUpdate.Tick += timerDataGridViewUpdate_Tick;

            DataGridViewUpdate();
        }

        #region Packets

        private void CbTypeEncryptionPackets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTypeEncryptionPackets.SelectedIndex == 0)
            {
                m_SelectedPacketEncryptionType = SelectedPacketEncryptionType.Encrypted;
            }
            else if (cbTypeEncryptionPackets.SelectedIndex == 1)
            {
                m_SelectedPacketEncryptionType = SelectedPacketEncryptionType.Decrypted;
            }

            DataGridViewUpdate();
        }

        private void CbTypePackets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTypePackets.SelectedIndex == 0)
            {
                m_SelectedPacketType = SelectedPacketType.AllPackets;
            }
            else if (cbTypePackets.SelectedIndex == 1)
            {
                m_SelectedPacketType = SelectedPacketType.ClientToServer;
            }
            else if (cbTypePackets.SelectedIndex == 2)
            {
                m_SelectedPacketType = SelectedPacketType.ServerToClient;
            }

            DataGridViewUpdate();
        }

        private void DgvPackets_SelectionChanged(object sender, EventArgs e)
        {
            if (cbAutoScroll.Checked)
                cbAutoScroll.Checked = false;

            var idPacket = dgvPackets.Rows[dgvPackets.CurrentCell.RowIndex].Cells["Id"].Value;

            if (idPacket == null)
                return;

            var idPacket1 = long.Parse(idPacket.ToString());

            if (m_SelectedPacketEncryptionType == SelectedPacketEncryptionType.Encrypted)
            {
                var packet = m_ConnectionModel.ConnectionPackets.FirstOrDefault(p => p.Id == idPacket1);
                LoadPacketForView(packet?.Data);
            }
            else if (m_SelectedPacketEncryptionType == SelectedPacketEncryptionType.Decrypted)
            {
                var packet = m_ConnectionModel.DecryptedPackets.FirstOrDefault(p => p.Id == idPacket1);
                LoadPacketForView(packet?.Data);

                ConfigurationGridView();
            }
        }

        private void CbAutoUpdateDataGridView_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAutoUpdateDataGridView.Checked)
            {
                m_TimerDataGridViewUpdate.Start();

                btnUpdatePackets.Enabled = false;
                btnClearPackets.Enabled = false;
            }
            else
            {
                m_TimerDataGridViewUpdate.Stop();

                btnUpdatePackets.Enabled = true;
                btnClearPackets.Enabled = true;
            }
        }

        private void BtnUpdatePackets_Click(object sender, EventArgs e)
        {
            DataGridViewUpdate();
        }

        private void BtnClearPackets_Click(object sender, EventArgs e)
        {
            m_ConnectionModel.ConnectionPackets.Clear();
            m_ConnectionModel.DecryptedPackets.Clear();

            dgvPackets.Rows.Clear();
            hbHexEditor.ByteProvider = null;
        }

        #endregion

        #region Timers

        //////timerDecryptPacketsUpdate_Tick

        private void timerDataGridViewUpdate_Tick(object sender, EventArgs e)
        {
            Invoke(new Action(DataGridViewUpdate));
        }

        #endregion

        #region Methods

        //////DecryptPacketsUpdate

        private void DataGridViewUpdate()
        {
            if (!Monitor.TryEnter(m_TimerDataGridViewUpdateLock))
                return;

            try
            {
                List<PacketModel> packets = null;

                if (m_SelectedPacketEncryptionType == SelectedPacketEncryptionType.Encrypted)
                {
                    packets = m_ConnectionModel.ConnectionPackets;
                }
                else if (m_SelectedPacketEncryptionType == SelectedPacketEncryptionType.Decrypted)
                {
                    packets = m_ConnectionModel.DecryptedPackets;
                }

                if (m_SelectedPacketType == SelectedPacketType.AllPackets)
                {
                    packets = packets.Where(p => p.Type == Models.Enums.PacketType.ClientToServer || p.Type == Models.Enums.PacketType.ServerToClient).ToList();
                }
                else if (m_SelectedPacketType == SelectedPacketType.ClientToServer)
                {
                    packets = packets.Where(p => p.Type == Models.Enums.PacketType.ClientToServer).ToList();
                }
                else if (m_SelectedPacketType == SelectedPacketType.ServerToClient)
                {
                    packets = packets.Where(p => p.Type == Models.Enums.PacketType.ServerToClient).ToList();
                }

                if (m_SearchModel != null)
                {
                    if (m_SearchModel.Type == SelectedSearchType.Opcode)
                    {
                        //////packets = packets.Where(p => p.Opcode == m_SearchModel.Opcode).ToList();
                    }
                    else if (m_SearchModel.Type == SelectedSearchType.Bytes)
                    {
                        packets = packets.Where(p => p.Data.Search(m_SearchModel.Bytes).Length != 0).ToList();
                    }
                }

                if (packets.Count == 0)
                {
                    dgvPackets.Rows.Clear();
                    return;
                }

                for (var i = 0; i < packets.Count; i++)
                {
                    //////lblAllPackets.Text = packets.Count.ToString();

                    while (dgvPackets.Rows.Count < i + 1)
                    {
                        dgvPackets.Rows.Add();
                    }

                    while (dgvPackets.Rows.Count > packets.Count)
                    {
                        dgvPackets.Rows.RemoveAt(dgvPackets.Rows.Count - 1);
                    }

                    dgvPackets.Rows[i].Cells["Number"].Value = i + 1;
                    dgvPackets.Rows[i].Cells["Id"].Value = packets[i].Id;

                    if (packets[i].Type == Models.Enums.PacketType.ClientToServer)
                    {
                        dgvPackets.Rows[i].Cells["PacketType"].Value = "К => С";
                        dgvPackets.Rows[i].Cells["Number"].Style.BackColor = Color.FromArgb(0, 91, 255);
                    }
                    else if (packets[i].Type == Models.Enums.PacketType.ServerToClient)
                    {
                        dgvPackets.Rows[i].Cells["PacketType"].Value = "К <= С";
                        dgvPackets.Rows[i].Cells["Number"].Style.BackColor = Color.FromArgb(0, 255, 127);
                    }
                    else
                    {
                        //////dgvPackets.Rows[i].Cells["PacketType"].Value = "Ошибка";
                        dgvPackets.Rows[i].Cells["Number"].Style.BackColor = Color.FromArgb(255, 255, 0);
                    }

                    if (m_SelectedPacketEncryptionType == SelectedPacketEncryptionType.Encrypted)
                    {
                        dgvPackets.Rows[i].Cells["PacketOpcode"].Value = null;
                        //////dgvPackets.Rows[i].Cells["PacketName"].Value = "Не расшифровано";
                    }
                    else if (m_SelectedPacketEncryptionType == SelectedPacketEncryptionType.Decrypted)
                    {
                        dgvPackets.Rows[i].Cells["PacketOpcode"].Value = packets[i].Opcode;
                        dgvPackets.Rows[i].Cells["PacketName"].Value = packets[i].Opcode;
                    }
                }

                if (cbAutoScroll.Checked)
                {
                    dgvPackets.FirstDisplayedScrollingRowIndex = dgvPackets.Rows.Count - 1;
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
                //////lblInformation.Text = "Ошибки при обновлении пакетов";
            }
            finally
            {
                Monitor.Exit(m_TimerDataGridViewUpdateLock);
            }
        }

        private void LoadPacketForView(byte[] bytes)
        {
            try
            {
                var dynamicByteProvider = new DynamicByteProvider(bytes);
                hbHexEditor.ByteProvider = dynamicByteProvider;

                //////lblLengthPacket.Text = bytes.Length.ToString();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
                //////lblInformation.Text = "Ошибки при загрузке пакета";
            }
        }

        //////ConverterUpdate

        #endregion
    }
}
