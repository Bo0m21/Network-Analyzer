using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using HexBoxForm;
using Network_Analyzer.Code;
using Network_Analyzer.Decryptors;
using Network_Analyzer.Extensions;
using Network_Analyzer.Globals;
using Network_Analyzer.Interfaces;
using Network_Analyzer.Models;
using Network_Analyzer.Models.Configuration;
using Network_Analyzer.Models.Connection;
using Network_Analyzer.Models.Decryptor;
using Network_Analyzer.Models.Search;
using Network_Analyzer.Models.SelectedEncoding;
using Network_Analyzer.Models.SelectedPacket;
using Network_Analyzer.Models.SelectedTabControl;
using Newtonsoft.Json;

namespace Network_Analyzer
{
	public partial class Editor : Form
	{
		private readonly object m_TimerPacketsGridViewUpdateLock = new object();
		private readonly object m_TimerDecryptPacketsUpdateLock = new object();

		private System.Windows.Forms.Timer m_TimerPacketsGridViewUpdate;
		private System.Windows.Forms.Timer m_TimerDecryptPacketsUpdate;

		private ConnectionModel m_ConnectionModel;
		private ConfigurationModel m_ConfigurationModel;

		private ConnectionPacketModel m_CurrentConnectionPacketModel;
		private ConfigurationClassModel m_CurrentConfigurationClassModel;

		private IDecryptor m_Decryptor;
		private SearchModel m_SearchModel;

		private SelectedTabControlGeneralType m_SelectedTabControlGeneralType;
		private SelectedTabControlConfigurationType m_SelectedTabControlConfigurationType;

		private SelectedPacketEncryptionType m_SelectedPacketEncryptionType;
		private SelectedPacketType m_SelectedPacketType;

		private SelectedEncodingType m_SelectedEncodingType;

		public Editor(long connectionId)
		{
			InitializeComponent();
			Localizer.LocalizeForm(this);

			m_ConnectionModel = Connections.GetConnection(connectionId);
		}

		private void Editor_Load(object sender, EventArgs e)
		{
            m_SelectedTabControlGeneralType = SelectedTabControlGeneralType.Packets;
			m_SelectedTabControlConfigurationType = SelectedTabControlConfigurationType.PacketInformation;

			m_SelectedPacketEncryptionType = SelectedPacketEncryptionType.Encrypted;
			m_SelectedPacketType = SelectedPacketType.AllPackets;

			m_SelectedEncodingType = SelectedEncodingType.EncodingAscii;
			encodingAsciiToolStripMenuItem.Checked = true;

			cbTypePackets.SelectedIndex = 0;
			cbTypeEncryptionPackets.SelectedIndex = 0;
			cbSearchType.SelectedIndex = 0;
			cbSequenceType.SelectedIndex = 0;

			m_TimerPacketsGridViewUpdate = new System.Windows.Forms.Timer();
			m_TimerPacketsGridViewUpdate.Tick += TimerPacketsGridViewUpdate_Tick;

			m_TimerDecryptPacketsUpdate = new System.Windows.Forms.Timer();
			m_TimerDecryptPacketsUpdate.Tick += TimerDecryptPacketsUpdate_Tick;

			lblInformation.Text = Localizer.LocalizeString("Editor.LoadedSuccessfully");
		}

		private void Editor_FormClosing(object sender, FormClosingEventArgs e)
		{
			m_TimerPacketsGridViewUpdate.Stop();
			m_TimerDecryptPacketsUpdate.Stop();
		}

		#region Menu

		private void EncodingInstall_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem item = (ToolStripMenuItem)sender;

			encodingAsciiToolStripMenuItem.Checked = false;
			encodingUnicodeToolStripMenuItem.Checked = false;
			encodingUTF8ToolStripMenuItem.Checked = false;
			encodingWindows1251ToolStripMenuItem.Checked = false;

			if (item.Text == Localizer.LocalizeString("Editor.EncodingUnicode"))
			{
				encodingUnicodeToolStripMenuItem.Checked = true;
				m_SelectedEncodingType = SelectedEncodingType.EncodingUnicode;
				hbHexEditor.ByteCharConverter = new UnicodeByteCharProvider();
			}
			else if (item.Text == Localizer.LocalizeString("Editor.EncodingUTF8"))
			{
				encodingUTF8ToolStripMenuItem.Checked = true;
				m_SelectedEncodingType = SelectedEncodingType.EncodingUTF8;
				hbHexEditor.ByteCharConverter = new UTF8ByteCharProvider();
			}
			else if (item.Text == Localizer.LocalizeString("Editor.EncodingWindows1251"))
			{
				encodingWindows1251ToolStripMenuItem.Checked = true;
				m_SelectedEncodingType = SelectedEncodingType.EncodingWindows1251;
				hbHexEditor.ByteCharConverter = new Windows1251ByteCharProvider();
			}
			else
			{
				encodingAsciiToolStripMenuItem.Checked = true;
				m_SelectedEncodingType = SelectedEncodingType.EncodingAscii;
				hbHexEditor.ByteCharConverter = new DefaultByteCharConverter();
			}

			HexBoxViewUpdate();
			InformationViewUpdate();
			ConfigurationViewUpdate();
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

			m_ConnectionModel.DecryptedPackets.Clear();
			foreach (ConnectionPacketModel packet in m_ConnectionModel.ConnectionPackets)
			{
				packet.IsDecrypted = false;
			}

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

			string fileName = "";
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";

				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					fileName = openFileDialog.FileName;
				}
				else
				{
					lblInformation.Text = Localizer.LocalizeString("Editor.NotSelectFile");
					return;
				}
			}

			string configurationJson = File.ReadAllText(fileName);

			if (string.IsNullOrEmpty(configurationJson))
			{
				lblInformation.Text = Localizer.LocalizeString("Editor.DeserializationResultEmpty");
				return;
			}

			try
			{
				ConfigurationModel configuration = JsonConvert.DeserializeObject<ConfigurationModel>(configurationJson);

				if (configuration == null)
				{
					lblInformation.Text = Localizer.LocalizeString("Editor.ConfigurationEmpty");
					return;
				}

				m_ConfigurationModel = configuration;

				PacketsGridViewUpdate();
				ConfigurationPacketsGridViewUpdate();
				StructuresGridViewUpdate();
				SetCurrentConnectionPacketModel();
				SetCurrentConfigurationClassModel();

				HexBoxViewUpdate();
				InformationViewUpdate();
				ConfigurationViewUpdate();

				lblInformation.Text = Localizer.LocalizeString("Editor.ConfigurationLoadedSuccessfully");
			}
			catch (Exception ex)
			{
				Trace.TraceError(ex.Message);
				lblInformation.Text = Localizer.LocalizeString("Main.ErrorsLoadingConnections");
			}
		}

		private void SaveConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (m_ConfigurationModel == null)
			{
				lblInformation.Text = Localizer.LocalizeString("Editor.ConfigurationEmpty");
				return;
			}

			try
			{
				string configurationJson = JsonConvert.SerializeObject(m_ConfigurationModel);

				if (string.IsNullOrEmpty(configurationJson))
				{
					lblInformation.Text = Localizer.LocalizeString("Editor.SerializationResultEmpty");
					return;
				}

				using (SaveFileDialog saveFileDialog = new SaveFileDialog())
				{
					saveFileDialog.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";

					if (saveFileDialog.ShowDialog() == DialogResult.OK)
					{
						File.WriteAllText(saveFileDialog.FileName, configurationJson);
						lblInformation.Text = Localizer.LocalizeString("Editor.ConfigurationSuccessfullySaved");
					}
				}
			}
			catch (Exception ex)
			{
				Trace.TraceError(ex.Message);
				lblInformation.Text = Localizer.LocalizeString("Editor.ErrorsSavingConfiguration");
			}
		}

		private void CreateConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (m_Decryptor == null)
			{
				lblInformation.Text = Localizer.LocalizeString("Editor.ErrorLoadingDecryptor");
				return;
			}

			m_ConfigurationModel = new ConfigurationModel();

			PacketsGridViewUpdate();
			ConfigurationPacketsGridViewUpdate();
			StructuresGridViewUpdate();
			SetCurrentConnectionPacketModel();
			SetCurrentConfigurationClassModel();

			HexBoxViewUpdate();
			InformationViewUpdate();
			ConfigurationViewUpdate();

			lblInformation.Text = Localizer.LocalizeString("Editor.ConfigurationCreateSuccessfully");
		}

		private void DumperToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (m_Decryptor == null)
			{
				cbTypeEncryptionPackets.SelectedIndex = 0;

				lblInformation.Text = Localizer.LocalizeString("Editor.ErrorLoadingDecryptor");
				return;
			}

			DialogResult dialogResult = MessageBox.Show(Localizer.LocalizeString("Editor.DumpQuestion") + ": " + m_CurrentConnectionPacketModel.Opcode + "?", Localizer.LocalizeString("Editor.DumpTitle"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (dialogResult == DialogResult.Yes)
			{
				if (m_ConnectionModel.DecryptedPackets.Count == 0)
				{
					lblInformation.Text = Localizer.LocalizeString("Editor.DumpConnectionsEmpty");
					return;
				}

				string dumpConnectionsJson = JsonConvert.SerializeObject(m_ConnectionModel.DecryptedPackets);

				if (string.IsNullOrEmpty(dumpConnectionsJson))
				{
					lblInformation.Text = Localizer.LocalizeString("Editor.DumpSerializationResultEmpty");
					return;
				}

				using (SaveFileDialog saveFileDialog = new SaveFileDialog())
				{
					saveFileDialog.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";

					if (saveFileDialog.ShowDialog() == DialogResult.OK)
					{
						File.WriteAllText(saveFileDialog.FileName, dumpConnectionsJson);
						lblInformation.Text = Localizer.LocalizeString("Editor.DumpConnectionsSuccessfullySaved");
					}
				}
			}
			else
			{
				lblInformation.Text = Localizer.LocalizeString("Editor.DumpConnectionsNotSaved");
			}
		}

		#endregion

		#region Tab Controls

		private void TcGeneral_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tcGeneral.SelectedIndex == 0)
			{
				m_SelectedTabControlGeneralType = SelectedTabControlGeneralType.Packets;
			}
			else if (tcGeneral.SelectedIndex == 1)
			{
				m_SelectedTabControlGeneralType = SelectedTabControlGeneralType.ConfigurationPackets;
			}
			else if (tcGeneral.SelectedIndex == 2)
			{
				m_SelectedTabControlGeneralType = SelectedTabControlGeneralType.Structures;
			}

			PacketsGridViewUpdate();
			ConfigurationPacketsGridViewUpdate();
			StructuresGridViewUpdate();
			SetCurrentConnectionPacketModel();
			SetCurrentConfigurationClassModel();

			HexBoxViewUpdate();
			InformationViewUpdate();
			ConfigurationViewUpdate();
		}

		private void TcConfiguration_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tcConfiguration.SelectedIndex == 0)
			{
				m_SelectedTabControlConfigurationType = SelectedTabControlConfigurationType.PacketInformation;
			}
			else if (tcConfiguration.SelectedIndex == 1)
			{
				m_SelectedTabControlConfigurationType = SelectedTabControlConfigurationType.Configuration;
			}
			else if (tcConfiguration.SelectedIndex == 2)
			{
				m_SelectedTabControlConfigurationType = SelectedTabControlConfigurationType.Bindings;
			}

			PacketsGridViewUpdate();
			ConfigurationPacketsGridViewUpdate();
			StructuresGridViewUpdate();
			SetCurrentConnectionPacketModel();
			SetCurrentConfigurationClassModel();

			HexBoxViewUpdate();
			InformationViewUpdate();
			ConfigurationViewUpdate();
		}

		#endregion

		#region General Tab

		/* --- Packets --- */
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

			PacketsGridViewUpdate();
			SetCurrentConnectionPacketModel();
			SetCurrentConfigurationClassModel();

			HexBoxViewUpdate();
			InformationViewUpdate();
			ConfigurationViewUpdate();
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

			PacketsGridViewUpdate();
			SetCurrentConnectionPacketModel();
			SetCurrentConfigurationClassModel();

			HexBoxViewUpdate();
			InformationViewUpdate();
			ConfigurationViewUpdate();
		}

		private void DgvPackets_SelectionChanged(object sender, EventArgs e)
		{
			if (cbAutoScroll.Checked)
			{
				cbAutoScroll.Checked = false;
			}

			SetCurrentConnectionPacketModel();
			SetCurrentConfigurationClassModel();

			HexBoxViewUpdate();
			InformationViewUpdate();
			ConfigurationViewUpdate();
		}

		private void CbAutoUpdateDataGridView_CheckedChanged(object sender, EventArgs e)
		{
			if (cbAutoUpdateDataGridView.Checked)
			{
				m_TimerPacketsGridViewUpdate.Start();

				btnUpdatePackets.Enabled = false;
				btnClearPackets.Enabled = false;
			}
			else
			{
				m_TimerPacketsGridViewUpdate.Stop();

				btnUpdatePackets.Enabled = true;
				btnClearPackets.Enabled = true;
			}
		}

		private void BtnUpdatePackets_Click(object sender, EventArgs e)
		{
			PacketsGridViewUpdate();
			SetCurrentConnectionPacketModel();
			SetCurrentConfigurationClassModel();

			HexBoxViewUpdate();
			InformationViewUpdate();
			ConfigurationViewUpdate();
		}

		private void BtnClearPackets_Click(object sender, EventArgs e)
		{
			m_ConnectionModel.ConnectionPackets.Clear();
			m_ConnectionModel.DecryptedPackets.Clear();

			dgvPackets.Rows.Clear();
			hbHexEditor.ByteProvider = null;

			PacketsGridViewUpdate();
			SetCurrentConnectionPacketModel();
			SetCurrentConfigurationClassModel();

			HexBoxViewUpdate();
			InformationViewUpdate();
			ConfigurationViewUpdate();
		}

		/* --- Configuration packets --- */
		private void DgvConfigurationPackets_SelectionChanged(object sender, EventArgs e)
		{
			SetCurrentConnectionPacketModel();
			SetCurrentConfigurationClassModel();

			HexBoxViewUpdate();
			InformationViewUpdate();
			ConfigurationViewUpdate();
		}

		/* --- Structures --- */
		private void DgvStructures_SelectionChanged(object sender, EventArgs e)
		{
			SetCurrentConnectionPacketModel();
			SetCurrentConfigurationClassModel();

			HexBoxViewUpdate();
			InformationViewUpdate();
			ConfigurationViewUpdate();
		}

        #endregion

        #region Hex-box Tab

        private void HbHexEditor_DoubleClick(object sender, EventArgs e)
        {
            var entryConfigurationField = m_ConfigurationModel.GetEntryFieldByIndex(m_CurrentConfigurationClassModel, hbHexEditor.SelectionStart);

            if (entryConfigurationField != null)
            {
                foreach (DataGridViewRow dataGridViewRow in dgvConfigurationFields.Rows)
                {
                    if (dataGridViewRow.Cells["ConfigurationFieldPosition"].Value == null)
                    {
                        continue;
                    }

                    var position = (long)dataGridViewRow.Cells["ConfigurationFieldPosition"].Value;

                    if (entryConfigurationField.Position == position)
                    {
                        foreach (DataGridViewRow dataGridViewRowSelected in dgvConfigurationFields.Rows)
                        {
                            dataGridViewRowSelected.Selected = false;
                        }

                        dataGridViewRow.Selected = true;
                        break;
                    }
                }
            }
        }

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
				searchModel.Type = SelectedSearchType.Name;
				searchModel.Name = tbSearch.Text;
			}
			else if (cbSearchType.SelectedIndex == 1)
			{
				searchModel.Type = SelectedSearchType.Opcode;
				searchModel.Opcode = tbSearch.Text;
			}
			else if (cbSearchType.SelectedIndex == 2)
			{
				searchModel.Type = SelectedSearchType.Bytes;
				string searchTextReplace = tbSearch.Text.Replace(" ", "").Replace("0x", "");

				if (searchTextReplace.Length % 2 != 0)
				{
					lblInformation.Text = Localizer.LocalizeString("Editor.ErrorsValidation");
					return;
				}

				// TODO May be refactor
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

			PacketsGridViewUpdate();
			ConfigurationPacketsGridViewUpdate();
			StructuresGridViewUpdate();
			SetCurrentConnectionPacketModel();
			SetCurrentConfigurationClassModel();

			HexBoxViewUpdate();
			InformationViewUpdate();
			ConfigurationViewUpdate();
		}

		private void BtnSearchClear_Click(object sender, EventArgs e)
		{
			m_SearchModel = null;
			lblInformation.Text = Localizer.LocalizeString("Editor.SearchSuccessfullyCleared");

			PacketsGridViewUpdate();
			ConfigurationPacketsGridViewUpdate();
			StructuresGridViewUpdate();
			SetCurrentConnectionPacketModel();
			SetCurrentConfigurationClassModel();

			HexBoxViewUpdate();
			InformationViewUpdate();
			ConfigurationViewUpdate();
		}

		private void HbHexEditor_Paint(object sender, PaintEventArgs e)
		{
			if (m_CurrentConfigurationClassModel != null)
			{
				var configurationFields = m_ConfigurationModel.GetAllFieldForConfiguration(m_CurrentConfigurationClassModel, display: true);

                foreach (var configurationField in configurationFields)
                {
                    SolidBrush color = new SolidBrush(Colors.Success.GetColor());

                    if (!m_ConfigurationModel.CheckFieldForUniquenessSpace(configurationFields, configurationField))
                    {
                        color = new SolidBrush(Colors.Error.GetColor());
                    }

                    if (configurationField.Type != Localizer.LocalizeString("Types.Structure") && !configurationField.IsArray)
                    {
                        hbHexEditor.FillPaint(e.Graphics, configurationField.Position, m_ConfigurationModel.GetLengthForConfiguration(configurationField), color);
                    }
                }
            }
        }

        private void HbHexEditor_SelectionStartChanged(object sender, EventArgs e)
        {
            InformationViewUpdate();
		}

		private void HbHexEditor_SelectionLengthChanged(object sender, EventArgs e)
		{
			InformationViewUpdate();
		}

		#endregion

		#region Configuration Tab

		/* --- Packet Information --- */
		private void CbSequenceType_SelectedIndexChanged(object sender, EventArgs e)
		{
			InformationViewUpdate();
		}

		private void BtnConfigurationFieldInformationCopy_Click(object sender, EventArgs e)
		{
			var type = ((Button)sender).Name.Replace("btnCopy", "");

			foreach (var control in gbDataTypes.Controls)
			{
				var controlText = control as TextBox;

				if (controlText != null && controlText.Name == "tb" + type)
				{ 
					Clipboard.SetText(controlText.Text);
					break;
				}
			}
		}

		private void BtnConfigurationFieldInformationAdd_Click(object sender, EventArgs e)
		{
			var type = ((Button)sender).Name.Replace("btnField", "");

			using (ConfigurationField configurationField = new ConfigurationField(m_CurrentConnectionPacketModel, m_ConfigurationModel, m_CurrentConfigurationClassModel, m_SelectedEncodingType))
			{
				configurationField.SetPosition(hbHexEditor.SelectionStart);
				configurationField.SetSequenceType(cbSequenceType.Text);
				configurationField.SetType(type);

				configurationField.ShowDialog();
			}

			PacketsGridViewUpdate();
			ConfigurationPacketsGridViewUpdate();
			StructuresGridViewUpdate();
			SetCurrentConnectionPacketModel();
			SetCurrentConfigurationClassModel();

			HexBoxViewUpdate();
			InformationViewUpdate();
			ConfigurationViewUpdate();
		}

		/* --- Configuration --- */
		private void TbConfigurationName_Leave(object sender, EventArgs e)
		{
			string newName = tbConfigurationName.Text;
			string oldName = m_CurrentConfigurationClassModel.Name;

			bool checkConfigurationName = !m_ConfigurationModel.ConfigurationPackets.Any(c => c.Name == newName) &&
										  !m_ConfigurationModel.ConfigurationStructures.Any(c => c.Name == newName);

			if (checkConfigurationName)
			{
				m_CurrentConfigurationClassModel.Name = newName;
			}
			else
			{
				tbConfigurationName.Text = oldName;

				lblInformation.Text = Localizer.LocalizeString("Editor.ErrorsConfigurationNameAlreadyUse");
				return;
			}

			// Rename all related fields
			m_ConfigurationModel.RenameConfigurationNameAllRelatedFields(oldName, newName);

			PacketsGridViewUpdate();
			ConfigurationPacketsGridViewUpdate();
			StructuresGridViewUpdate();
		}

		private void TbConfigurationDescription_Leave(object sender, EventArgs e)
		{
			m_CurrentConfigurationClassModel.Descreption = tbConfigurationDescription.Text;

			PacketsGridViewUpdate();
			ConfigurationPacketsGridViewUpdate();
			StructuresGridViewUpdate();
		}

        private void DgvConfigurationFields_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvConfigurationFields.Rows[dgvConfigurationFields.CurrentCell.RowIndex].Cells["ConfigurationFieldName"].Value != null)
            {
                string configurationFieldName = (string)dgvConfigurationFields.Rows[dgvConfigurationFields.CurrentCell.RowIndex].Cells["ConfigurationFieldName"].Value;

                if (configurationFieldName.Contains(".") || configurationFieldName.Contains("["))
                {
                    btnConfigurationFieldAdd.Enabled = false;
                    btnConfigurationFieldEdit.Enabled = false;
                    btnConfigurationFieldDelete.Enabled = false;
                }
                else
                {
                    btnConfigurationFieldAdd.Enabled = true;
                    btnConfigurationFieldEdit.Enabled = true;
                    btnConfigurationFieldDelete.Enabled = true;
                }
            }
        }

        private void DgvConfigurationFields_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvConfigurationFields.Rows[dgvConfigurationFields.CurrentCell.RowIndex].Cells["ConfigurationFieldPosition"].Value != null)
            {
                ConfigurationFieldModel configurationField = m_ConfigurationModel.GetAllFieldForConfiguration(m_CurrentConfigurationClassModel, display: true).ElementAt(dgvConfigurationFields.CurrentCell.RowIndex);
                long position = (long)dgvConfigurationFields.Rows[dgvConfigurationFields.CurrentCell.RowIndex].Cells["ConfigurationFieldPosition"].Value;

                hbHexEditor.SelectionLength = m_ConfigurationModel.GetLengthForConfiguration(configurationField);
                hbHexEditor.SelectionStart = position;
            }
        }

        private void CbHexEditorLongField_CheckedChanged(object sender, EventArgs e)
        {
            SetCurrentConnectionPacketModel();
            SetCurrentConfigurationClassModel();

            HexBoxViewUpdate();
        }

        private void CbConfigurationHighlights_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbConfigurationHighlights.Checked)
            {
                for (int i = 0; i < dgvPackets.RowCount; i++)
                {
                    dgvPackets.Rows[i].Cells["PacketName"].Style.BackColor = Color.White;
                }
            }


            PacketsGridViewUpdate();
            ConfigurationPacketsGridViewUpdate();
            StructuresGridViewUpdate();
        }

        private void BtnConfigurationAdd_Click(object sender, EventArgs e)
		{
			List<ConfigurationClassModel> configurationClassModels = new List<ConfigurationClassModel>();

			if (m_SelectedTabControlGeneralType == SelectedTabControlGeneralType.Packets ||
				m_SelectedTabControlGeneralType == SelectedTabControlGeneralType.ConfigurationPackets)
			{
				configurationClassModels = m_ConfigurationModel.ConfigurationPackets;
			}
			else if (m_SelectedTabControlGeneralType == SelectedTabControlGeneralType.Structures)
			{
				configurationClassModels = m_ConfigurationModel.ConfigurationStructures;
			}

			using (ConfigurationClass configurationClass = new ConfigurationClass(m_ConfigurationModel, m_CurrentConnectionPacketModel, configurationClassModels, m_SelectedTabControlGeneralType))
			{
				configurationClass.ShowDialog();
			}

			PacketsGridViewUpdate();
			ConfigurationPacketsGridViewUpdate();
			StructuresGridViewUpdate();
			SetCurrentConnectionPacketModel();
			SetCurrentConfigurationClassModel();

			HexBoxViewUpdate();
			InformationViewUpdate();
			ConfigurationViewUpdate();
		}

		private void BtnConfigurationDelete_Click(object sender, EventArgs e)
		{
			List<ConfigurationClassModel> configurationClassModels = new List<ConfigurationClassModel>();

			if (m_SelectedTabControlGeneralType == SelectedTabControlGeneralType.Packets ||
				m_SelectedTabControlGeneralType == SelectedTabControlGeneralType.ConfigurationPackets)
			{
				configurationClassModels = m_ConfigurationModel.ConfigurationPackets;
			}
			else if (m_SelectedTabControlGeneralType == SelectedTabControlGeneralType.Structures)
			{
				configurationClassModels = m_ConfigurationModel.ConfigurationStructures;
			}

			configurationClassModels.Remove(m_CurrentConfigurationClassModel);

			// Delete all related fields
			m_ConfigurationModel.DeleteConfigurationNameAllRelatedFields(m_CurrentConfigurationClassModel.Name);

			PacketsGridViewUpdate();
			ConfigurationPacketsGridViewUpdate();
			StructuresGridViewUpdate();
			SetCurrentConnectionPacketModel();
			SetCurrentConfigurationClassModel();

			HexBoxViewUpdate();
			InformationViewUpdate();
			ConfigurationViewUpdate();
		}

		private void BtnConfigurationFieldAdd_Click(object sender, EventArgs e)
		{
			using (ConfigurationField configurationField = new ConfigurationField(m_CurrentConnectionPacketModel, m_ConfigurationModel, m_CurrentConfigurationClassModel, m_SelectedEncodingType))
			{
				configurationField.SetPosition(hbHexEditor.SelectionStart);
				configurationField.SetSequenceType(cbSequenceType.Text);

				configurationField.ShowDialog();
			}

			PacketsGridViewUpdate();
			ConfigurationPacketsGridViewUpdate();
			StructuresGridViewUpdate();
			SetCurrentConnectionPacketModel();
			SetCurrentConfigurationClassModel();

			HexBoxViewUpdate();
			InformationViewUpdate();
			ConfigurationViewUpdate();
		}

		private void BtnConfigurationFieldEdit_Click(object sender, EventArgs e)
		{
			if (dgvConfigurationFields.Rows.Count == 0)
			{
				return;
			}

			if (dgvConfigurationFields.Rows[dgvConfigurationFields.CurrentCell.RowIndex].Cells["ConfigurationFieldPosition"].Value == null)
			{
				return;
			}

			long position = (long)dgvConfigurationFields.Rows[dgvConfigurationFields.CurrentCell.RowIndex].Cells["ConfigurationFieldPosition"].Value;
			ConfigurationFieldModel configurationFieldModel = m_CurrentConfigurationClassModel.ConfigurationFields.FirstOrDefault(c => c.Position == position);

			using (ConfigurationField configurationField = new ConfigurationField(m_CurrentConnectionPacketModel, m_ConfigurationModel, m_CurrentConfigurationClassModel, configurationFieldModel, m_SelectedEncodingType))
			{
				configurationField.ShowDialog();
			}

			PacketsGridViewUpdate();
			ConfigurationPacketsGridViewUpdate();
			StructuresGridViewUpdate();
			SetCurrentConnectionPacketModel();
			SetCurrentConfigurationClassModel();

			HexBoxViewUpdate();
			InformationViewUpdate();
			ConfigurationViewUpdate();
		}

		private void BtnConfigurationFieldDelete_Click(object sender, EventArgs e)
		{
			if (dgvConfigurationFields.Rows.Count == 0)
			{
				return;
			}

			if (dgvConfigurationFields.Rows[dgvConfigurationFields.CurrentCell.RowIndex].Cells["ConfigurationFieldPosition"].Value == null)
			{
				return;
			}

			long position = (long)dgvConfigurationFields.Rows[dgvConfigurationFields.CurrentCell.RowIndex].Cells["ConfigurationFieldPosition"].Value;
			ConfigurationFieldModel configurationField = m_CurrentConfigurationClassModel.ConfigurationFields.FirstOrDefault(c => c.Position == position);

			m_CurrentConfigurationClassModel.ConfigurationFields.Remove(configurationField);

			// Delete all related fields
			m_CurrentConfigurationClassModel.DeleteFieldNameAllRelatedFields(configurationField.Name);

			PacketsGridViewUpdate();
			ConfigurationPacketsGridViewUpdate();
			StructuresGridViewUpdate();
			SetCurrentConnectionPacketModel();
			SetCurrentConfigurationClassModel();

			HexBoxViewUpdate();
			InformationViewUpdate();
			ConfigurationViewUpdate();
		}

		/* --- Bindings --- */
		// TODO

		#endregion

		#region Timers

		private void TimerPacketsGridViewUpdate_Tick(object sender, EventArgs e)
		{
			Invoke(new Action(PacketsGridViewUpdate));
		}

		private void TimerDecryptPacketsUpdate_Tick(object sender, EventArgs e)
		{
			Invoke(new Action(DecryptPacketsUpdate));
		}

		#endregion

		#region Methods

		/// <summary>
		///     Get all packets by search settings
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
				if (m_SearchModel.Type == SelectedSearchType.Name)
				{
					if (m_ConfigurationModel == null)
					{
						return new List<ConnectionPacketModel>();
					}

					List<string> configurationPacketOpcodes = m_ConfigurationModel.ConfigurationPackets.Where(c => !string.IsNullOrEmpty(c.Name) && c.Name.Contains(m_SearchModel.Name)).Select(c => c.Opcode).ToList();
					packets = packets.Where(p => configurationPacketOpcodes.Contains(p.Opcode)).ToList();
				}
				else if (m_SearchModel.Type == SelectedSearchType.Opcode)
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
		///		Get all configuration packets by search settings
		/// </summary>
		/// <returns></returns>
		private List<ConfigurationClassModel> GetConfigurationPacketsBySearchSettings()
		{
			if (m_ConfigurationModel == null)
			{
				return new List<ConfigurationClassModel>();
			}

			List<ConfigurationClassModel> configurationPackets = m_ConfigurationModel.ConfigurationPackets;

			if (m_SearchModel != null)
			{
				if (m_SearchModel.Type == SelectedSearchType.Name)
				{
					configurationPackets = configurationPackets.Where(s => s.Name.Contains(m_SearchModel.Name)).ToList();
				}
				else if (m_SearchModel.Type == SelectedSearchType.Opcode)
				{
					configurationPackets = configurationPackets.Where(s => s.Opcode == m_SearchModel.Opcode).ToList();
				}
				else if (m_SearchModel.Type == SelectedSearchType.Bytes)
				{
					// TODO May be I can do it
					return new List<ConfigurationClassModel>();
				}
			}

			return configurationPackets;
		}

		/// <summary>
		///     Get all structures by search settings
		/// </summary>
		/// <returns></returns>
		private List<ConfigurationClassModel> GetStructuresBySearchSettings()
		{
			if (m_ConfigurationModel == null)
			{
				return new List<ConfigurationClassModel>();
			}

			List<ConfigurationClassModel> structures = m_ConfigurationModel.ConfigurationStructures;

			if (m_SearchModel != null)
			{
				if (m_SearchModel.Type == SelectedSearchType.Name)
				{
					structures = structures.Where(s => s.Name.Contains(m_SearchModel.Name)).ToList();
				}
				else if (m_SearchModel.Type == SelectedSearchType.Opcode)
				{
					// TODO May be I can do it
					return new List<ConfigurationClassModel>();
				}
				else if (m_SearchModel.Type == SelectedSearchType.Bytes)
				{
					// TODO May be I can do it
					return new List<ConfigurationClassModel>();
				}
			}

			return structures;
		}

		/// <summary>
		///     Set current connection packet model
		/// </summary>
		private void SetCurrentConnectionPacketModel()
		{
			if (dgvPackets.Rows.Count == 0)
			{
				m_CurrentConnectionPacketModel = null;
				return;
			}

			if (dgvPackets.Rows[dgvPackets.CurrentCell.RowIndex].Cells["PacketId"].Value == null)
			{
				m_CurrentConnectionPacketModel = null;
				return;
			}

			long packetId = (long)dgvPackets.Rows[dgvPackets.CurrentCell.RowIndex].Cells["PacketId"].Value;
			m_CurrentConnectionPacketModel = GetPacketsBySearchSettings().FirstOrDefault(p => p.Id == packetId);
		}

		/// <summary>
		///     Set current configuration class model
		/// </summary>
		private void SetCurrentConfigurationClassModel()
		{
			if (m_SelectedTabControlGeneralType == SelectedTabControlGeneralType.Packets)
			{
				if (m_ConfigurationModel == null)
				{
					m_CurrentConfigurationClassModel = null;
					return;
				}

				if (m_CurrentConnectionPacketModel == null)
				{
					m_CurrentConfigurationClassModel = null;
					return;
				}

				if (m_SelectedPacketEncryptionType != SelectedPacketEncryptionType.Decrypted)
				{
					m_CurrentConfigurationClassModel = null;
					return;
				}

				ConfigurationClassModel configurationClass = m_ConfigurationModel.ConfigurationPackets.FirstOrDefault(c => c.Opcode == m_CurrentConnectionPacketModel.Opcode);

				if (configurationClass != null)
				{
					m_CurrentConfigurationClassModel = configurationClass;
				}
				else
				{
					m_CurrentConfigurationClassModel = null;
				}
			}
			else if (m_SelectedTabControlGeneralType == SelectedTabControlGeneralType.ConfigurationPackets)
			{
				if (m_ConfigurationModel == null)
				{
					m_CurrentConnectionPacketModel = null;
					m_CurrentConfigurationClassModel = null;
					return;
				}

				if (dgvConfigurationPackets.Rows.Count == 0)
				{
					m_CurrentConnectionPacketModel = null;
					m_CurrentConfigurationClassModel = null;
					return;
				}

				if (dgvConfigurationPackets.Rows[dgvConfigurationPackets.CurrentCell.RowIndex].Cells["ConfigurationPacketOpcode"].Value == null)
				{
					m_CurrentConnectionPacketModel = null;
					m_CurrentConfigurationClassModel = null;
					return;
				}

				string configurationPacketOpcode = (string)dgvConfigurationPackets.Rows[dgvConfigurationPackets.CurrentCell.RowIndex].Cells["ConfigurationPacketOpcode"].Value;
				ConfigurationClassModel configurationClass = m_ConfigurationModel.ConfigurationPackets.FirstOrDefault(c => c.Opcode == configurationPacketOpcode);

				if (configurationClass != null)
                {
                    m_CurrentConnectionPacketModel = new ConnectionPacketModel();

                    if (cbHexEditorLongField.Checked)
                    {
                        m_CurrentConnectionPacketModel.Data = new byte[65536];
                    }
                    else
                    {
                        m_CurrentConnectionPacketModel.Data = new byte[m_ConfigurationModel.GetLengthForConfiguration(configurationClass)];
                    }

                    m_CurrentConfigurationClassModel = configurationClass;
				}
				else
				{
					m_CurrentConnectionPacketModel = null;
					m_CurrentConfigurationClassModel = null;
				}
			}
			else if (m_SelectedTabControlGeneralType == SelectedTabControlGeneralType.Structures)
			{
				if (m_ConfigurationModel == null)
				{
					m_CurrentConnectionPacketModel = null;
					m_CurrentConfigurationClassModel = null;
					return;
				}

				if (dgvStructures.Rows.Count == 0)
				{
					m_CurrentConnectionPacketModel = null;
					m_CurrentConfigurationClassModel = null;
					return;
				}

				if (dgvStructures.Rows[dgvStructures.CurrentCell.RowIndex].Cells["StructureName"].Value == null)
				{
					m_CurrentConnectionPacketModel = null;
					m_CurrentConfigurationClassModel = null;
					return;
				}

				string structureName = (string)dgvStructures.Rows[dgvStructures.CurrentCell.RowIndex].Cells["StructureName"].Value;
				ConfigurationClassModel configurationClass = GetStructuresBySearchSettings().FirstOrDefault(p => p.Name == structureName);

				if (configurationClass != null)
                {
                    m_CurrentConnectionPacketModel = new ConnectionPacketModel();

                    if (cbHexEditorLongField.Checked)
                    {
                        m_CurrentConnectionPacketModel.Data = new byte[65536];
                    }
                    else
                    {
                        m_CurrentConnectionPacketModel.Data = new byte[m_ConfigurationModel.GetLengthForConfiguration(configurationClass)];
                    }

                    m_CurrentConfigurationClassModel = configurationClass;
				}
				else
				{
					m_CurrentConnectionPacketModel = null;
					m_CurrentConfigurationClassModel = null;
				}
			}
		}

		/// <summary>
		///     Method for update packets grid view
		/// </summary>
		private void PacketsGridViewUpdate()
		{
			if (!Monitor.TryEnter(m_TimerPacketsGridViewUpdateLock))
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

					dgvPackets.Rows[i].Cells["PacketNumber"].Value = i + 1;
					dgvPackets.Rows[i].Cells["PacketId"].Value = packets[i].Id;

					if (packets[i].Type == ConnectionPacketType.ClientToServer)
                    {
                        dgvPackets.Rows[i].Cells["PacketNumber"].Style.BackColor = Colors.ClientToServer.GetColor();
                    }
					else if (packets[i].Type == ConnectionPacketType.ServerToClient)
                    {
                        dgvPackets.Rows[i].Cells["PacketNumber"].Style.BackColor = Colors.ServerToClient.GetColor();
                    }

					if (m_SelectedPacketEncryptionType == SelectedPacketEncryptionType.Encrypted)
					{
						dgvPackets.Rows[i].Cells["PacketOpcode"].Value = "-";
						dgvPackets.Rows[i].Cells["PacketName"].Value = Localizer.LocalizeString("Editor.NotDecrypted");
					}
					else if (m_SelectedPacketEncryptionType == SelectedPacketEncryptionType.Decrypted)
					{
						dgvPackets.Rows[i].Cells["PacketOpcode"].Value = packets[i].Opcode;

						if (m_ConfigurationModel != null)
						{
							var configurationPacketModel = m_ConfigurationModel.ConfigurationPackets.FirstOrDefault(p => p.Opcode == packets[i].Opcode);

							if (configurationPacketModel != null && !string.IsNullOrEmpty(configurationPacketModel.Name))
							{
								dgvPackets.Rows[i].Cells["PacketName"].Value = configurationPacketModel.Name;

                                if (cbConfigurationHighlights.Checked)
                                {
                                    long totalLength = m_ConfigurationModel.GetAllLengthForConfiguration(configurationPacketModel);

                                    if (totalLength < packets[i].Data.Length)
                                    {
                                        dgvPackets.Rows[i].Cells["PacketName"].Style.BackColor = Colors.Warning.GetColor();
                                    }
                                    else if (totalLength > packets[i].Data.Length)
                                    {
                                        dgvPackets.Rows[i].Cells["PacketName"].Style.BackColor = Colors.Error.GetColor();
                                    }
                                    else
                                    {
                                        dgvPackets.Rows[i].Cells["PacketName"].Style.BackColor = Colors.Success.GetColor();
                                    }
                                }
							}
							else
							{
								dgvPackets.Rows[i].Cells["PacketName"].Value = Localizer.LocalizeString("Editor.NotInstalled");
							}
						}
						else
						{
							dgvPackets.Rows[i].Cells["PacketName"].Value = Localizer.LocalizeString("Editor.NotInstalled");
						}
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
				Monitor.Exit(m_TimerPacketsGridViewUpdateLock);
			}
		}

		/// <summary>
		///     Method for update configuration packets grid view
		/// </summary>
		private void ConfigurationPacketsGridViewUpdate()
		{
			// TODO Maybe refactor
			if (m_ConfigurationModel == null)
			{
				((Control)tpConfigurationPackets).Enabled = false;
				return;
			}

			((Control)tpConfigurationPackets).Enabled = true;

			List<ConfigurationClassModel> configurationPackets = GetConfigurationPacketsBySearchSettings();

			if (configurationPackets.Count == 0)
			{
				dgvConfigurationPackets.Rows.Clear();
				return;
			}

			for (int i = 0; i < configurationPackets.Count; i++)
			{
				// TODO Maybe refactor
				while (dgvConfigurationPackets.Rows.Count < i + 1)
				{
					dgvConfigurationPackets.Rows.Add();
				}

				// TODO Maybe refactor
				while (dgvConfigurationPackets.Rows.Count > configurationPackets.Count)
				{
					dgvConfigurationPackets.Rows.RemoveAt(dgvConfigurationPackets.Rows.Count - 1);
				}

				dgvConfigurationPackets.Rows[i].Cells["ConfigurationPacketNumber"].Value = i + 1;
				dgvConfigurationPackets.Rows[i].Cells["ConfigurationPacketOpcode"].Value = configurationPackets[i].Opcode;
				dgvConfigurationPackets.Rows[i].Cells["ConfigurationPacketName"].Value = configurationPackets[i].Name;
			}
		}

		/// <summary>
		///     Method for update structures grid view
		/// </summary>
		private void StructuresGridViewUpdate()
		{
			// TODO Maybe refactor
			if (m_ConfigurationModel == null)
			{
				((Control)tpStructures).Enabled = false;
				return;
			}

			((Control)tpStructures).Enabled = true;

			List<ConfigurationClassModel> structures = GetStructuresBySearchSettings();

			if (structures.Count == 0)
			{
				dgvStructures.Rows.Clear();
				return;
			}

			for (int i = 0; i < structures.Count; i++)
			{
				// TODO Maybe refactor
				while (dgvStructures.Rows.Count < i + 1)
				{
					dgvStructures.Rows.Add();
				}

				// TODO Maybe refactor
				while (dgvStructures.Rows.Count > structures.Count)
				{
					dgvStructures.Rows.RemoveAt(dgvStructures.Rows.Count - 1);
				}

				dgvStructures.Rows[i].Cells["StructureNumber"].Value = i + 1;
				dgvStructures.Rows[i].Cells["StructureName"].Value = structures[i].Name;
			}
		}

		/// <summary>
		///     Method for update hexbox
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
		///     Method for update information
		/// </summary>
		private void InformationViewUpdate()
		{
			lblClassCount.Text = Localizer.LocalizeString("Editor.ClassCount") + " " + "0";
			lblDataLength.Text = Localizer.LocalizeString("Editor.DataLength") + " " + "0";
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

			tbString.Text = "";

			if (m_CurrentConnectionPacketModel == null || m_CurrentConnectionPacketModel.Data == null)
			{
				return;
			}

			if (m_SelectedTabControlGeneralType == SelectedTabControlGeneralType.Packets)
			{
				lblClassCount.Text = Localizer.LocalizeString("Editor.ClassCount") + " " + dgvPackets.Rows.Count;
			}
			else if (m_SelectedTabControlGeneralType == SelectedTabControlGeneralType.ConfigurationPackets)
			{
				lblClassCount.Text = Localizer.LocalizeString("Editor.ClassCount") + " " + dgvConfigurationPackets.Rows.Count;
			}
			else if (m_SelectedTabControlGeneralType == SelectedTabControlGeneralType.Structures)
			{
				lblClassCount.Text = Localizer.LocalizeString("Editor.ClassCount") + " " + dgvStructures.Rows.Count;
			}

			lblDataLength.Text = Localizer.LocalizeString("Editor.DataLength") + " " + m_CurrentConnectionPacketModel.Data.Length;
			lblSelectedIndex.Text = Localizer.LocalizeString("Editor.SelectedIndex") + " " + hbHexEditor.SelectionStart;
			lblSelectedLength.Text = Localizer.LocalizeString("Editor.SelectedLength") + " " + hbHexEditor.SelectionLength;

			if (hbHexEditor.SelectionStart == m_CurrentConnectionPacketModel.Data.Length || hbHexEditor.SelectionStart == -1)
			{
				return;
			}

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

			tbString.Text = m_CurrentConnectionPacketModel.Data.GetValue(Localizer.LocalizeString("Types.String"), hbHexEditor.SelectionStart, reverse, m_SelectedEncodingType);
		}

		/// <summary>
		///     Method for updare configuration
		/// </summary>
		private void ConfigurationViewUpdate()
		{
			if (m_CurrentConfigurationClassModel == null)
			{
				btnFieldByte.Enabled = false;
				btnFieldShort.Enabled = false;
				btnFieldInt.Enabled = false;
				btnFieldLong.Enabled = false;
				btnFieldFloat.Enabled = false;
				btnFieldSbyte.Enabled = false;
				btnFieldUshort.Enabled = false;
				btnFieldUint.Enabled = false;
				btnFieldUlong.Enabled = false;
				btnFieldDouble.Enabled = false;
				btnFieldString.Enabled = false;

				tbConfigurationName.Enabled = false;
				tbConfigurationDescription.Enabled = false;
				dgvConfigurationFields.Enabled = false;
                cbHexEditorLongField.Enabled = false;
                cbConfigurationHighlights.Enabled = false;
                btnConfigurationFieldAdd.Enabled = false;
				btnConfigurationFieldEdit.Enabled = false;
				btnConfigurationFieldDelete.Enabled = false;
				btnConfigurationAdd.Enabled = false;
				btnConfigurationDelete.Enabled = false;

				if (m_ConfigurationModel != null)
				{
					if (m_SelectedTabControlGeneralType == SelectedTabControlGeneralType.Packets)
					{
						if (m_SelectedPacketEncryptionType == SelectedPacketEncryptionType.Decrypted)
						{
							btnConfigurationAdd.Enabled = true;
						}
					}
					else if (m_SelectedTabControlGeneralType == SelectedTabControlGeneralType.ConfigurationPackets ||
							 m_SelectedTabControlGeneralType == SelectedTabControlGeneralType.Structures)
					{
						btnConfigurationAdd.Enabled = true;
					}
				}

				tbConfigurationName.Clear();
				tbConfigurationDescription.Clear();
				dgvConfigurationFields.Rows.Clear();

                return;
			}

			btnFieldByte.Enabled = true;
			btnFieldShort.Enabled = true;
			btnFieldInt.Enabled = true;
			btnFieldLong.Enabled = true;
			btnFieldFloat.Enabled = true;
			btnFieldSbyte.Enabled = true;
			btnFieldUshort.Enabled = true;
			btnFieldUint.Enabled = true;
			btnFieldUlong.Enabled = true;
			btnFieldDouble.Enabled = true;
			btnFieldString.Enabled = true;

			tbConfigurationName.Enabled = true;
			tbConfigurationDescription.Enabled = true;
			dgvConfigurationFields.Enabled = true;
            cbHexEditorLongField.Enabled = true;
            cbConfigurationHighlights.Enabled = true;
            btnConfigurationFieldAdd.Enabled = true;
			btnConfigurationFieldEdit.Enabled = true;
			btnConfigurationFieldDelete.Enabled = true;
			btnConfigurationAdd.Enabled = true;
			btnConfigurationDelete.Enabled = true;

			if (m_SelectedTabControlGeneralType == SelectedTabControlGeneralType.Packets)
			{
                cbHexEditorLongField.Enabled = false;
				btnConfigurationAdd.Enabled = false;
            }
			else if (m_SelectedTabControlGeneralType == SelectedTabControlGeneralType.ConfigurationPackets ||
					 m_SelectedTabControlGeneralType == SelectedTabControlGeneralType.Structures)
			{
				btnConfigurationAdd.Enabled = true;
                cbConfigurationHighlights.Enabled = false;
            }

			tbConfigurationName.Text = m_CurrentConfigurationClassModel.Name;
			tbConfigurationDescription.Text = m_CurrentConfigurationClassModel.Descreption;

			dgvConfigurationFields.Rows.Clear();

            m_CurrentConfigurationClassModel.ConfigurationFields = m_CurrentConfigurationClassModel.ConfigurationFields.OrderBy(c => c.Position).ToList();
            List<ConfigurationFieldModel> configurationFields = m_ConfigurationModel.GetAllFieldForConfiguration(m_CurrentConfigurationClassModel, display: true);

            foreach (var configurationField in configurationFields)
            {
                string configurationFieldItemValue = m_CurrentConnectionPacketModel.Data.GetValue(configurationField.Type, configurationField.Position, configurationField.SequenceType != Localizer.LocalizeString("SequenceTypes.LittleEndian"));
                dgvConfigurationFields.Rows.Add(configurationField.Position, configurationField.Type, configurationField.Name, configurationFieldItemValue);

                if (!m_ConfigurationModel.CheckFieldForUniquenessSpace(configurationFields, configurationField))
                {
                    dgvConfigurationFields.Rows[dgvConfigurationFields.Rows.Count - 1].DefaultCellStyle.BackColor = Colors.Error.GetColor();
                }
                else
                {
                    if (configurationField.Name.Contains(".") || configurationField.Name.Contains("["))
                    {
                        dgvConfigurationFields.Rows[dgvConfigurationFields.Rows.Count - 1].DefaultCellStyle.BackColor = Colors.BlockedElement.GetColor();
                    }
                }
            }
        }

		#endregion

		#region Decryptor

		// TDOD Bad idea refactor
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