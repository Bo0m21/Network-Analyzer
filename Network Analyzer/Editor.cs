using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using HexBoxForm;
using Network_Analyzer.Decryptor;
using Network_Analyzer.Decryptor.Decryptors;
using Network_Analyzer.Extensions;
using Network_Analyzer.Models.Configuration;
using Network_Analyzer.Models.Connection;
using Network_Analyzer.Models.Search;
using Network_Analyzer.Models.SelectedPacket;
using Network_Analyzer.Network.Data;
using Network_Analyzer.Services;

namespace Network_Analyzer
{
    public partial class Editor : Form
    {
        private readonly object m_TimerDataGridViewUpdateLock = new object();
        private readonly object m_TimerDecryptPacketsUpdateLock = new object();

        private System.Windows.Forms.Timer m_TimerDataGridViewUpdate;
        private System.Windows.Forms.Timer m_TimerDecryptPacketsUpdate;

        private ConnectionModel m_ConnectionModel;
        private ConfigurationModel m_ConfigurationModel;

        private IDecryptor m_Decryptor;
        private SearchModel m_SearchModel;

        private SelectedPacketEncryptionType m_SelectedPacketEncryptionType;
        private SelectedPacketType m_SelectedPacketType;

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
            cbSearchType.SelectedIndex = 0;
            cbSequenceType.SelectedIndex = 0;

            m_TimerDecryptPacketsUpdate = new System.Windows.Forms.Timer();
            m_TimerDecryptPacketsUpdate.Tick += timerDecryptPacketsUpdate_Tick;

            m_TimerDataGridViewUpdate = new System.Windows.Forms.Timer();
            m_TimerDataGridViewUpdate.Tick += timerDataGridViewUpdate_Tick;

            //((Control)tpConfiguration).Enabled = false;

            DataGridViewUpdate();

            lblInformation.Text = Localizer.LocalizeString("Editor.LoadedSuccessfully");
        }

        private void Editor_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_TimerDecryptPacketsUpdate.Stop();
            m_TimerDataGridViewUpdate.Stop();
        }

        #region Menu

        private void EncodingInstall_Click(object sender, EventArgs e)
        {
            var item = (ToolStripMenuItem) sender;

            if (item.Text == Localizer.LocalizeString("Editor.EncodingAscii"))
            {
                hbHexEditor.ByteCharConverter = new DefaultByteCharConverter();
            }
            else if (item.Text == Localizer.LocalizeString("Editor.EncodingUnicode"))
            {
                hbHexEditor.ByteCharConverter = new UnicodeByteCharProvider();
            }
            else if (item.Text == Localizer.LocalizeString("Editor.EncodingUTF8"))
            {
                hbHexEditor.ByteCharConverter = new UTF8ByteCharProvider();
            }
            else if (item.Text == Localizer.LocalizeString("Editor.EncodingWindows1251"))
            {
                hbHexEditor.ByteCharConverter = new Windows1251ByteCharProvider();
            }
            else
            {
                lblInformation.Text = Localizer.LocalizeString("Editor.ErrorsSelectEncoding");
            }
        }

        private void LoadDecryptorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_Decryptor = new R2Decryptor();

            m_ConnectionModel.DecryptedPackets.Clear();
            foreach (var packet in m_ConnectionModel.ConnectionPackets)
            {
                packet.IsDecrypted = false;
            }

            m_TimerDecryptPacketsUpdate.Start();

            lblInformation.Text = Localizer.LocalizeString("Editor.DecryptorLoadedSuccessfully");
        }

        private void UnloadDecryptorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_TimerDecryptPacketsUpdate.Stop();

            m_Decryptor = null;
            cbTypeEncryptionPackets.SelectedIndex = 0;

            lblInformation.Text = Localizer.LocalizeString("Editor.DecryptorUnloadedSuccessfully");
        }

        private void LoadConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO
            MessageBox.Show("TODO");
        }

        private void SaveConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO
            MessageBox.Show("TODO");
        }

        private void CreateConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO
            MessageBox.Show("TODO");
        }

        #endregion

        #region Packets

        private void CbTypeEncryptionPackets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTypeEncryptionPackets.SelectedIndex == 0)
            {
                m_SelectedPacketEncryptionType = SelectedPacketEncryptionType.Encrypted;
            }
            else if (cbTypeEncryptionPackets.SelectedIndex == 1)
            {
                if (m_Decryptor == null)
                {
                    cbTypeEncryptionPackets.SelectedIndex = 0;
                    return;
                }

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
            {
                cbAutoScroll.Checked = false;
            }

            if (dgvPackets.Rows[dgvPackets.CurrentCell.RowIndex].Cells["Id"].Value == null)
            {
                return;
            }

            var idPacket = (long) dgvPackets.Rows[dgvPackets.CurrentCell.RowIndex].Cells["Id"].Value;

            if (m_SelectedPacketEncryptionType == SelectedPacketEncryptionType.Encrypted)
            {
                var packet = m_ConnectionModel.ConnectionPackets.FirstOrDefault(p => p.Id == idPacket);

                if (packet != null && packet.Data != null)
                {
                    LoadPacketForView(packet?.Data);
                }
            }
            else if (m_SelectedPacketEncryptionType == SelectedPacketEncryptionType.Decrypted)
            {
                var packet = m_ConnectionModel.DecryptedPackets.FirstOrDefault(p => p.Id == idPacket);

                if (packet != null && packet.Data != null)
                {
                    LoadPacketForView(packet?.Data);
                }
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

            DataGridViewUpdate();
        }

        #endregion

        #region Hex editor

        private void BtnSearchStart_Click(object sender, EventArgs e)
        {
            var searchModel = new SearchModel();

            if (cbSearchType.SelectedIndex == 0)
            {
                searchModel.Type = SelectedSearchType.Opcode;
            }
            else if (cbSearchType.SelectedIndex == 1)
            {
                searchModel.Type = SelectedSearchType.Bytes;
            }
            else
            {
                lblInformation.Text = Localizer.LocalizeString("Editor.ErrorSelectSearchType");
                return;
            }

            if (string.IsNullOrEmpty(tbSearch.Text))
            {
                lblInformation.Text = Localizer.LocalizeString("Editor.ErrorNotFillSerchField");
                return;
            }

            if (cbSearchType.SelectedIndex == 0)
            {
                searchModel.Opcode = tbSearch.Text;
            }
            else if (cbSearchType.SelectedIndex == 1)
            {
                var searchTextReplace = tbSearch.Text.Replace(" ", "").Replace("0x", "");

                if (searchTextReplace.Length % 2 != 0)
                {
                    lblInformation.Text = Localizer.LocalizeString("Editor.ErrorsValidation");
                    return;
                }

                var bytesString = from Match match in Regex.Matches(searchTextReplace, "..")
                    select match.Value;

                var bytes = new List<byte>();
                foreach (var byteString in bytesString)
                {
                    if (byte.TryParse(byteString, NumberStyles.HexNumber, CultureInfo.InvariantCulture.NumberFormat,
                        out var byteArray))
                    {
                        bytes.Add(byteArray);
                    }
                    else
                    {
                        lblInformation.Text = Localizer.LocalizeString("Editor.ErrorsValidation");
                        return;
                    }
                }

                searchModel.Bytes = bytes.ToArray();
            }

            m_SearchModel = searchModel;
            lblInformation.Text = Localizer.LocalizeString("Editor.SearchSuccessfullyApplied");

            DataGridViewUpdate();
        }

        private void BtnSearchClear_Click(object sender, EventArgs e)
        {
            m_SearchModel = null;
            lblInformation.Text = Localizer.LocalizeString("Editor.SearchSuccessfullyCleared");

            DataGridViewUpdate();
        }

        private void HbHexEditor_Paint(object sender, PaintEventArgs e)
        {
            hbHexEditor.FillPaint(e.Graphics, 0, 2, new SolidBrush(Color.FromArgb(89, 202, 250)));
            hbHexEditor.FillPaint(e.Graphics, 2, 2, new SolidBrush(Color.FromArgb(146, 250, 91)));
        }

        #endregion

        #region Information and converter

        private void HbHexEditor_SelectionStartChanged(object sender, EventArgs e)
        {
            lblSelectedIndex.Text = Localizer.LocalizeString("Editor.SelectedIndex") + " " + hbHexEditor.SelectionStart;

            ConverterUpdate();
        }

        private void HbHexEditor_SelectionLengthChanged(object sender, EventArgs e)
        {
            lblSelectedLength.Text =
                Localizer.LocalizeString("Editor.SelectedLength") + " " + hbHexEditor.SelectionLength;
        }

        private void CbSequenceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConverterUpdate();
        }

        #endregion

        #region Configuration

        private void BtnAddFieldConfiguration_Click(object sender, EventArgs e)
        {
            var idPacket = (long) dgvPackets.Rows[dgvPackets.CurrentCell.RowIndex].Cells["Id"].Value;
            ConnectionPacketModel packet = null;

            if (m_SelectedPacketEncryptionType == SelectedPacketEncryptionType.Decrypted)
            {
                packet = m_ConnectionModel.DecryptedPackets.FirstOrDefault(p => p.Id == idPacket);
            }
            else
            {
                lblInformation.Text = Localizer.LocalizeString("Editor.ErrorsSelectDecryptedPackages");
                return;
            }

            if (hbHexEditor.SelectionStart == packet.Data.Length || hbHexEditor.SelectionStart == -1)
            {
                return;
            }

            using (var configurationField = new ConfigurationField(packet, hbHexEditor.SelectionStart))
            {
                configurationField.ShowDialog();
            }
        }

        private void BtnDeleteFieldConfiguration_Click(object sender, EventArgs e)
        {
            // TODO
        }

        #endregion

        #region Timers

        private void timerDecryptPacketsUpdate_Tick(object sender, EventArgs e)
        {
            Invoke(new Action(DecryptPacketsUpdate));
        }

        private void timerDataGridViewUpdate_Tick(object sender, EventArgs e)
        {
            Invoke(new Action(DataGridViewUpdate));
        }

        #endregion

        #region Methods

        // Bad idea
        private void DecryptPacketsUpdate()
        {
            if (!Monitor.TryEnter(m_TimerDecryptPacketsUpdateLock))
            {
                return;
            }

            try
            {
                if (m_Decryptor != null)
                {
                    foreach (var packet in m_ConnectionModel.ConnectionPackets)
                    {
                        if (packet.IsDecrypted)
                        {
                            continue;
                        }

                        var idPackets = new List<long>();
                        List<DecryptorModel> decryptedPackets = null;

                        while (decryptedPackets == null)
                        {
                            if (idPackets.Count == 0)
                            {
                                idPackets.Add(packet.Id);
                            }
                            else
                            {
                                var indexPacket =
                                    m_ConnectionModel.ConnectionPackets.FindIndex(p => p.Id == idPackets.Last());
                                var packetNext = m_ConnectionModel.ConnectionPackets.Skip(indexPacket + 1)
                                    .FirstOrDefault(p => p.Type == packet.Type);

                                if (packetNext == null)
                                {
                                    return;
                                }

                                idPackets.Add(packetNext.Id);
                            }

                            var packetsData = m_ConnectionModel.ConnectionPackets.Where(p => idPackets.Contains(p.Id))
                                .SelectMany(p => p.Data).ToArray();
                            decryptedPackets = m_Decryptor.Parse(packetsData);
                        }

                        foreach (var decryptedPacket in decryptedPackets)
                        {
                            var decryptedPacketModel = new ConnectionPacketModel
                            {
                                Data = decryptedPacket.Data,
                                Type = packet.Type,
                                Opcode = decryptedPacket.Opcode
                            };

                            m_ConnectionModel.DecryptedPackets.Add(decryptedPacketModel);
                        }

                        var packetsForUpdate = m_ConnectionModel.ConnectionPackets.Where(p => idPackets.Contains(p.Id));

                        foreach (var packetForUpdate in packetsForUpdate)
                        {
                            packetForUpdate.IsDecrypted = true;
                        }

                        for (var i = 0; i < m_ConnectionModel.DecryptedPackets.Count; i++)
                        {
                            m_ConnectionModel.DecryptedPackets[i].Id = i + 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
            }
            finally
            {
                Monitor.Exit(m_TimerDecryptPacketsUpdateLock);
            }
        }

        private void DataGridViewUpdate()
        {
            if (!Monitor.TryEnter(m_TimerDataGridViewUpdateLock))
            {
                return;
            }

            try
            {
                List<ConnectionPacketModel> packets = null;

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
                    packets = packets.Where(p =>
                            p.Type == ConnectionPacketType.ClientToServer ||
                            p.Type == ConnectionPacketType.ServerToClient)
                        .ToList();
                }
                else if (m_SelectedPacketType == SelectedPacketType.ClientToServer)
                {
                    packets = packets.Where(p => p.Type == ConnectionPacketType.ClientToServer).ToList();
                }
                else if (m_SelectedPacketType == SelectedPacketType.ServerToClient)
                {
                    packets = packets.Where(p => p.Type == ConnectionPacketType.ServerToClient).ToList();
                }

                if (m_SearchModel != null)
                {
                    if (m_SearchModel.Type == SelectedSearchType.Opcode)
                    {
                        packets = packets.Where(p => p.Opcode == m_SearchModel.Opcode).ToList();
                    }
                    else if (m_SearchModel.Type == SelectedSearchType.Bytes)
                    {
                        packets = packets.Where(p => p.Data.Search(m_SearchModel.Bytes).Length != 0).ToList();
                    }
                }

                lblAllPackets.Text = Localizer.LocalizeString("Editor.AllPackets") + " " + packets.Count;

                if (packets.Count == 0)
                {
                    dgvPackets.Rows.Clear();
                    hbHexEditor.ByteProvider = null;

                    return;
                }

                for (var i = 0; i < packets.Count; i++)
                {
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

                    if (packets[i].Type == ConnectionPacketType.ClientToServer)
                    {
                        dgvPackets.Rows[i].Cells["Number"].Style.BackColor = Color.FromArgb(135, 255, 135);
                    }
                    else if (packets[i].Type == ConnectionPacketType.ServerToClient)
                    {
                        dgvPackets.Rows[i].Cells["Number"].Style.BackColor = Color.FromArgb(135, 255, 255);
                    }

                    if (m_SelectedPacketEncryptionType == SelectedPacketEncryptionType.Encrypted)
                    {
                        dgvPackets.Rows[i].Cells["PacketName"].Value = Localizer.LocalizeString("Editor.NotDecrypted");
                    }
                    else if (m_SelectedPacketEncryptionType == SelectedPacketEncryptionType.Decrypted)
                    {
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
                lblInformation.Text = Localizer.LocalizeString("Editor.ErrorsUpdatePackets");
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
                hbHexEditor.StringViewVisible = true;

                lblLengthPacket.Text = Localizer.LocalizeString("Editor.LengthPacket") + " " + bytes.Length;
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
                lblInformation.Text = Localizer.LocalizeString("Editor.ErrorLoadingPacket");
            }
        }

        private void ConverterUpdate()
        {
            if (dgvPackets.Rows[dgvPackets.CurrentCell.RowIndex].Cells["Id"].Value == null)
            {
                return;
            }

            var idPacket = (long) dgvPackets.Rows[dgvPackets.CurrentCell.RowIndex].Cells["Id"].Value;
            ConnectionPacketModel packet = null;

            if (m_SelectedPacketEncryptionType == SelectedPacketEncryptionType.Encrypted)
            {
                packet = m_ConnectionModel.ConnectionPackets.FirstOrDefault(p => p.Id == idPacket);
            }
            else if (m_SelectedPacketEncryptionType == SelectedPacketEncryptionType.Decrypted)
            {
                packet = m_ConnectionModel.DecryptedPackets.FirstOrDefault(p => p.Id == idPacket);
            }

            lblByteType.Text = Localizer.LocalizeString("Types.Byte") + " " + "0";
            lblSbyteType.Text = Localizer.LocalizeString("Types.Sbyte") + " " + "0";

            lblShortType.Text = Localizer.LocalizeString("Types.Short") + " " + "0";
            lblUshortType.Text = Localizer.LocalizeString("Types.Ushort") + " " + "0";

            lblIntType.Text = Localizer.LocalizeString("Types.Int") + " " + "0";
            lblUintType.Text = Localizer.LocalizeString("Types.Uint") + " " + "0";

            lblLongType.Text = Localizer.LocalizeString("Types.Long") + " " + "0";
            lblUlongType.Text = Localizer.LocalizeString("Types.Ulong") + " " + "0";

            lblFloatType.Text = Localizer.LocalizeString("Types.Float") + " " + "0";
            lblDoubleType.Text = Localizer.LocalizeString("Types.Double") + " " + "0";

            if (hbHexEditor.SelectionStart == packet.Data.Length || hbHexEditor.SelectionStart == -1)
            {
                return;
            }

            var reverse = cbSequenceType.SelectedIndex == 0 ? false : true;

            lblByteType.Text = Localizer.LocalizeString("Types.Byte") + " " +
                               packet.Data.ReadByte((int) hbHexEditor.SelectionStart);
            lblSbyteType.Text = Localizer.LocalizeString("Types.Sbyte") + " " +
                                packet.Data.ReadSbyte((int) hbHexEditor.SelectionStart);

            if (hbHexEditor.SelectionStart + 1 < packet.Data.Length)
            {
                lblShortType.Text = Localizer.LocalizeString("Types.Short") + " " +
                                    packet.Data.ReadShort((int) hbHexEditor.SelectionStart, reverse);
                lblUshortType.Text = Localizer.LocalizeString("Types.Ushort") + " " +
                                     packet.Data.ReadUshort((int) hbHexEditor.SelectionStart, reverse);
            }

            if (hbHexEditor.SelectionStart + 3 < packet.Data.Length)
            {
                lblIntType.Text = Localizer.LocalizeString("Types.Int") + " " +
                                  packet.Data.ReadInt((int) hbHexEditor.SelectionStart, reverse);
                lblUintType.Text = Localizer.LocalizeString("Types.Uint") + " " +
                                   packet.Data.ReadUint((int) hbHexEditor.SelectionStart, reverse);
                lblFloatType.Text = Localizer.LocalizeString("Types.Float") + " " +
                                    packet.Data.ReadFloat((int) hbHexEditor.SelectionStart, reverse);
            }

            if (hbHexEditor.SelectionStart + 7 < packet.Data.Length)
            {
                lblLongType.Text = Localizer.LocalizeString("Types.Long") + " " +
                                   packet.Data.ReadLong((int) hbHexEditor.SelectionStart, reverse);
                lblUlongType.Text = Localizer.LocalizeString("Types.Ulong") + " " +
                                    packet.Data.ReadUlong((int) hbHexEditor.SelectionStart, reverse);
                lblDoubleType.Text = Localizer.LocalizeString("Types.Double") + " " +
                                     packet.Data.ReadDouble((int) hbHexEditor.SelectionStart, reverse);
            }
        }

        #endregion
    }
}