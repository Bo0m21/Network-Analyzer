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

        private ConnectionPacketModel m_CurrentConnectionPacketModel;

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
            m_TimerDecryptPacketsUpdate.Tick += TimerDecryptPacketsUpdate_Tick;

            m_TimerDataGridViewUpdate = new System.Windows.Forms.Timer();
            m_TimerDataGridViewUpdate.Tick += TimerDataGridViewUpdate_Tick;

            ((Control)tpConfiguration).Enabled = false;

            lblInformation.Text = Localizer.LocalizeString("Editor.LoadedSuccessfully");
        }

        private void Editor_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_TimerDecryptPacketsUpdate.Stop();
            m_TimerDataGridViewUpdate.Stop();
        }

        #region Menu //refactor min decryptor and configs unload

        private void EncodingInstall_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

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
            foreach (ConnectionPacketModel packet in m_ConnectionModel.ConnectionPackets)
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
            if (m_Decryptor == null)
            {
                lblInformation.Text = Localizer.LocalizeString("Editor.ErrorLoadingDecryptor");
                return;
            }

            m_ConfigurationModel = new ConfigurationModel();
            ((Control)tpConfiguration).Enabled = true;

            // TODO

            lblInformation.Text = Localizer.LocalizeString("Editor.ConfigurationLoadedSuccessfully");
        }

        private void SaveConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void CreateConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_Decryptor == null)
            {
                lblInformation.Text = Localizer.LocalizeString("Editor.ErrorLoadingDecryptor");
                return;
            }

            m_ConfigurationModel = new ConfigurationModel();
            ((Control)tpConfiguration).Enabled = true;

            lblInformation.Text = Localizer.LocalizeString("Editor.ConfigurationCreateSuccessfully");
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

                    lblInformation.Text = Localizer.LocalizeString("Editor.ErrorLoadingDecryptor");
                    return;
                }

                m_SelectedPacketEncryptionType = SelectedPacketEncryptionType.Decrypted;
            }

            DataGridViewUpdate();
            SetCurrentConnectionPacketModel();

            HexBoxViewUpdate();
            InformationViewUpdate();
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
            SetCurrentConnectionPacketModel();

            HexBoxViewUpdate();
            InformationViewUpdate();
        }

        private void DgvPackets_SelectionChanged(object sender, EventArgs e)
        {
            if (cbAutoScroll.Checked)
            {
                cbAutoScroll.Checked = false;
            }

            SetCurrentConnectionPacketModel();

            HexBoxViewUpdate();
            InformationViewUpdate();
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
            SetCurrentConnectionPacketModel();

            HexBoxViewUpdate();
            InformationViewUpdate();
        }

        private void BtnClearPackets_Click(object sender, EventArgs e)
        {
            m_ConnectionModel.ConnectionPackets.Clear();
            m_ConnectionModel.DecryptedPackets.Clear();

            dgvPackets.Rows.Clear();
            hbHexEditor.ByteProvider = null;

            DataGridViewUpdate();
            SetCurrentConnectionPacketModel();

            HexBoxViewUpdate();
            InformationViewUpdate();
        }

        #endregion

        #region Hex editor

        private void BtnSearchStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSearch.Text))
            {
                lblInformation.Text = Localizer.LocalizeString("Editor.ErrorNotFillSerchField");
                return;
            }

            SearchModel searchModel = new SearchModel();

            if (cbSearchType.SelectedIndex == 0)
            {
                searchModel.Type = SelectedSearchType.Opcode;
                searchModel.Opcode = tbSearch.Text;
            }
            else if (cbSearchType.SelectedIndex == 1)
            {
                searchModel.Type = SelectedSearchType.Bytes;
                string searchTextReplace = tbSearch.Text.Replace(" ", "").Replace("0x", "");

                if (searchTextReplace.Length % 2 != 0)
                {
                    lblInformation.Text = Localizer.LocalizeString("Editor.ErrorsValidation");
                    return;
                }

                IEnumerable<string> bytesString = from Match match in Regex.Matches(searchTextReplace, "..")
                                                  select match.Value;

                List<byte> bytes = new List<byte>();
                foreach (string byteString in bytesString)
                {
                    if (byte.TryParse(byteString, NumberStyles.HexNumber, CultureInfo.InvariantCulture.NumberFormat, out byte byteArray))
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
            else
            {
                lblInformation.Text = Localizer.LocalizeString("Editor.ErrorSelectSearchType");
                return;
            }

            m_SearchModel = searchModel;
            lblInformation.Text = Localizer.LocalizeString("Editor.SearchSuccessfullyApplied");

            DataGridViewUpdate();
            SetCurrentConnectionPacketModel();

            HexBoxViewUpdate();
            InformationViewUpdate();
        }

        private void BtnSearchClear_Click(object sender, EventArgs e)
        {
            m_SearchModel = null;
            lblInformation.Text = Localizer.LocalizeString("Editor.SearchSuccessfullyCleared");

            DataGridViewUpdate();
            SetCurrentConnectionPacketModel();

            HexBoxViewUpdate();
            InformationViewUpdate();
        }

        // TODO Доделать
        private void HbHexEditor_Paint(object sender, PaintEventArgs e)
        {
            hbHexEditor.FillPaint(e.Graphics, 0, 2, new SolidBrush(Color.FromArgb(89, 202, 250)));
            hbHexEditor.FillPaint(e.Graphics, 2, 2, new SolidBrush(Color.FromArgb(146, 250, 91)));
        }

        #endregion

        #region Information and converter

        private void HbHexEditor_SelectionStartChanged(object sender, EventArgs e)
        {
            InformationViewUpdate();
        }

        private void HbHexEditor_SelectionLengthChanged(object sender, EventArgs e)
        {
            InformationViewUpdate();
        }

        private void CbSequenceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            InformationViewUpdate();
        }

        #endregion

        #region Configuration // toto доделать

        // TODO !!! В конфиги отправлять модель пакета конфигураци для того чтобы производить валидацию имени и позиций
        // TODO refacrot
        private void BtnAddConfigurationField_Click(object sender, EventArgs e)
        {
            if (m_SelectedPacketEncryptionType != SelectedPacketEncryptionType.Decrypted)
            {
                lblInformation.Text = Localizer.LocalizeString("Editor.ErrorsSelectDecryptedPackages");
                return;
            }

            if (hbHexEditor.SelectionStart == m_CurrentConnectionPacketModel.Data.Length || hbHexEditor.SelectionStart == -1)
            {
                return;
            }

            using (ConfigurationField configurationField = new ConfigurationField(m_CurrentConnectionPacketModel, hbHexEditor.SelectionStart))
            {
                DialogResult result = configurationField.ShowDialog();

                if (result == DialogResult.OK)
                {
                    ConfigurationFieldModel resultModel = configurationField.GetConfigurationFieldModel();
                    //m_ConfigurationModel.ConfigurationFields.Add(resultModel);

                    ConfigurationViewUpdate();
                    lblInformation.Text = Localizer.LocalizeString("Editor.ConfigurationFieldAddedSuccessfully");
                }
            }
        }

        // TODO refacrot
        private void BtnDeleteConfigurationField_Click(object sender, EventArgs e)
        {
            long position = (long)dgvConfigurationFields.Rows[dgvConfigurationFields.CurrentCell.RowIndex].Cells["ConfigurationPosition"].Value;

            //ConfigurationFieldModel configurationField = m_ConfigurationModel.ConfigurationFields.FirstOrDefault(c => c.Position == position);
            //m_ConfigurationModel.ConfigurationFields.Remove(configurationField);

            ConfigurationViewUpdate();
            lblInformation.Text = Localizer.LocalizeString("Editor.ConfigurationFieldDeletedSuccessfully");
        }

        #endregion

        #region Timers

        private void TimerDecryptPacketsUpdate_Tick(object sender, EventArgs e)
        {
            Invoke(new Action(DecryptPacketsUpdate));
        }

        private void TimerDataGridViewUpdate_Tick(object sender, EventArgs e)
        {
            Invoke(new Action(DataGridViewUpdate));
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get all packets by search settings
        /// </summary>
        /// <returns></returns>
        private List<ConnectionPacketModel> GetPacketsBySearchSettings()
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
                packets = packets.Where(p => p.Type == ConnectionPacketType.ClientToServer || p.Type == ConnectionPacketType.ServerToClient).ToList();
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

            return packets;
        }

        /// <summary>
        /// Set current connection packet model
        /// </summary>
        private void SetCurrentConnectionPacketModel()
        {
            if (dgvPackets.Rows.Count == 0)
            {
                m_CurrentConnectionPacketModel = null;
                return;
            }

            if (dgvPackets.Rows[dgvPackets.CurrentCell.RowIndex].Cells["Id"].Value == null)
            {
                m_CurrentConnectionPacketModel = null;
                return;
            }

            long packetId = (long)dgvPackets.Rows[dgvPackets.CurrentCell.RowIndex].Cells["Id"].Value;
            m_CurrentConnectionPacketModel = GetPacketsBySearchSettings().FirstOrDefault(p => p.Id == packetId);
        }

        /// <summary>
        /// Method for update data grid
        /// </summary>
        private void DataGridViewUpdate()
        {
            if (!Monitor.TryEnter(m_TimerDataGridViewUpdateLock))
            {
                return;
            }

            try
            {
                List<ConnectionPacketModel> packets = GetPacketsBySearchSettings();

                if (packets.Count == 0)
                {
                    dgvPackets.Rows.Clear();
                    return;
                }

                for (int i = 0; i < packets.Count; i++)
                {
                    // TODO Maybe refactor
                    while (dgvPackets.Rows.Count < i + 1)
                    {
                        dgvPackets.Rows.Add();
                    }

                    // TODO Maybe refactor
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

        /// <summary>
        /// Method for update hexbox
        /// </summary>
        private void HexBoxViewUpdate()
        {
            try
            {
                if (m_CurrentConnectionPacketModel == null || m_CurrentConnectionPacketModel.Data == null)
                {
                    hbHexEditor.ByteProvider = null;
                    return;
                }

                DynamicByteProvider dynamicByteProvider = new DynamicByteProvider(m_CurrentConnectionPacketModel.Data);
                hbHexEditor.ByteProvider = dynamicByteProvider;
                hbHexEditor.StringViewVisible = true;
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
                lblInformation.Text = Localizer.LocalizeString("Editor.ErrorLoadingPacket");
            }
        }

        /// <summary>
        /// Method for update information
        /// </summary>
        private void InformationViewUpdate()
        {
            lblAllPackets.Text = Localizer.LocalizeString("Editor.AllPackets") + " " + "0";
            lblLengthPacket.Text = Localizer.LocalizeString("Editor.LengthPacket") + " " + "0";
            lblSelectedIndex.Text = Localizer.LocalizeString("Editor.SelectedIndex") + " " + "0";
            lblSelectedLength.Text = Localizer.LocalizeString("Editor.SelectedLength") + " " + "0";

            tbByte.Text = "0";
            tbSbyte.Text = "0";

            tbShort.Text = "0";
            tbUshort.Text = "0";

            tbInt.Text = "0";
            tbUint.Text = "0";
            tbFloat.Text = "0";

            tbLong.Text = "0";
            tbUlong.Text = "0";
            tbDouble.Text = "0";

            if (m_CurrentConnectionPacketModel == null || m_CurrentConnectionPacketModel.Data == null)
            {
                return;
            }

            lblAllPackets.Text = Localizer.LocalizeString("Editor.AllPackets") + " " + dgvPackets.Rows.Count;
            lblLengthPacket.Text = Localizer.LocalizeString("Editor.LengthPacket") + " " + m_CurrentConnectionPacketModel.Data.Length;
            lblSelectedIndex.Text = Localizer.LocalizeString("Editor.SelectedIndex") + " " + hbHexEditor.SelectionStart;
            lblSelectedLength.Text = Localizer.LocalizeString("Editor.SelectedLength") + " " + hbHexEditor.SelectionLength;

            bool reverse = cbSequenceType.Text == Localizer.LocalizeString("SequenceTypes.LittleEndian") ? false : true;

            tbByte.Text = m_CurrentConnectionPacketModel.Data.GetValue(Localizer.LocalizeString("Types.Byte"), hbHexEditor.SelectionStart, reverse);
            tbSbyte.Text = m_CurrentConnectionPacketModel.Data.GetValue(Localizer.LocalizeString("Types.Sbyte"), hbHexEditor.SelectionStart, reverse);

            tbShort.Text = m_CurrentConnectionPacketModel.Data.GetValue(Localizer.LocalizeString("Types.Short"), hbHexEditor.SelectionStart, reverse);
            tbUshort.Text = m_CurrentConnectionPacketModel.Data.GetValue(Localizer.LocalizeString("Types.Ushort"), hbHexEditor.SelectionStart, reverse);

            tbInt.Text = m_CurrentConnectionPacketModel.Data.GetValue(Localizer.LocalizeString("Types.Int"), hbHexEditor.SelectionStart, reverse);
            tbUint.Text = m_CurrentConnectionPacketModel.Data.GetValue(Localizer.LocalizeString("Types.Uint"), hbHexEditor.SelectionStart, reverse);
            tbFloat.Text = m_CurrentConnectionPacketModel.Data.GetValue(Localizer.LocalizeString("Types.Float"), hbHexEditor.SelectionStart, reverse);

            tbLong.Text = m_CurrentConnectionPacketModel.Data.GetValue(Localizer.LocalizeString("Types.Long"), hbHexEditor.SelectionStart, reverse);
            tbUlong.Text = m_CurrentConnectionPacketModel.Data.GetValue(Localizer.LocalizeString("Types.Ulong"), hbHexEditor.SelectionStart, reverse);
            tbDouble.Text = m_CurrentConnectionPacketModel.Data.GetValue(Localizer.LocalizeString("Types.Double"), hbHexEditor.SelectionStart, reverse);
        }

        /// <summary>
        /// Method for updare configuration
        /// </summary>
        private void ConfigurationViewUpdate()
        {
            // TODO
            //if (m_SelectedPacketEncryptionType == SelectedPacketEncryptionType.Decrypted)
            //{
            //    packet = m_ConnectionModel.DecryptedPackets.FirstOrDefault(p => p.Id == idPacket);
            //}
            //else
            //{
            //    lblInformation.Text = Localizer.LocalizeString("Editor.ErrorsSelectDecryptedPackages");
            //    return;
            //}

            //dgvConfigurationFields.Rows.Clear();

            //m_ConfigurationModel.ConfigurationFields = m_ConfigurationModel.ConfigurationFields.OrderBy(c => c.Position).ToList();

            //for (int i = 0; i < m_ConfigurationModel.ConfigurationFields.Count; i++)
            //{
            //    ConfigurationFieldModel configurationField = m_ConfigurationModel.ConfigurationFields[i];

            //    string fieldValue = packet.Data.GetValue(configurationField.Type, configurationField.Position, configurationField.Reverse);
            //    dgvConfigurationFields.Rows.Add(configurationField.Position, configurationField.Type, configurationField.Name, fieldValue);
            //}
        }

        #endregion

        #region Decryptor

        // Bad idea refactor
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
                    foreach (ConnectionPacketModel packet in m_ConnectionModel.ConnectionPackets)
                    {
                        if (packet.IsDecrypted)
                        {
                            continue;
                        }

                        List<long> idPackets = new List<long>();
                        List<DecryptorModel> decryptedPackets = null;

                        while (decryptedPackets == null)
                        {
                            if (idPackets.Count == 0)
                            {
                                idPackets.Add(packet.Id);
                            }
                            else
                            {
                                int indexPacket =
                                    m_ConnectionModel.ConnectionPackets.FindIndex(p => p.Id == idPackets.Last());
                                ConnectionPacketModel packetNext = m_ConnectionModel.ConnectionPackets.Skip(indexPacket + 1)
                                    .FirstOrDefault(p => p.Type == packet.Type);

                                if (packetNext == null)
                                {
                                    return;
                                }

                                idPackets.Add(packetNext.Id);
                            }

                            byte[] packetsData = m_ConnectionModel.ConnectionPackets.Where(p => idPackets.Contains(p.Id))
                                .SelectMany(p => p.Data).ToArray();
                            decryptedPackets = m_Decryptor.Parse(packetsData);
                        }

                        foreach (DecryptorModel decryptedPacket in decryptedPackets)
                        {
                            ConnectionPacketModel decryptedPacketModel = new ConnectionPacketModel
                            {
                                Data = decryptedPacket.Data,
                                Type = packet.Type,
                                Opcode = decryptedPacket.Opcode
                            };

                            m_ConnectionModel.DecryptedPackets.Add(decryptedPacketModel);
                        }

                        IEnumerable<ConnectionPacketModel> packetsForUpdate = m_ConnectionModel.ConnectionPackets.Where(p => idPackets.Contains(p.Id));

                        foreach (ConnectionPacketModel packetForUpdate in packetsForUpdate)
                        {
                            packetForUpdate.IsDecrypted = true;
                        }

                        for (int i = 0; i < m_ConnectionModel.DecryptedPackets.Count; i++)
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

        #endregion
    }
}