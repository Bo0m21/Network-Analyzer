using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Network_Analyzer_WinForms.Network;
using Network_Analyzer_WinForms.Services;
using Network_Analyzer_WinForms.Services.Background;
using Network_Analyzer_WinForms.Utilities;

namespace Network_Analyzer_WinForms
{
    public partial class Main : Form
    {
        private readonly object m_TimerDataGridViewUpdateLock = new object();

        private System.Windows.Forms.Timer m_TimerDataGridViewUpdate;

        private SocksListener m_SocksListener;

        private BackendServce _backendServce;
        private ConnectionService _connectionService;

        public Main()
        {
            InitializeComponent();
            Localizer.LocalizeForm(this);

            _backendServce = BackendServce.GetService();
            _connectionService = new ConnectionService();

            // Start background connection service
            _connectionService.StartService();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // Create timer for update connections
            m_TimerDataGridViewUpdate = new System.Windows.Forms.Timer();
            m_TimerDataGridViewUpdate.Tick += TimerDataGridViewUpdate_Tick;
            m_TimerDataGridViewUpdate.Interval = 1000;

            // Update all connections
            DataGridViewUpdate();

            lblInformation.Text = Localizer.LocalizeString("Main.LoadedSuccessfully");
            lblVersion.Text = Localizer.LocalizeString("Main.Version") + " " + Assembly.GetEntryAssembly()?.GetName().Version;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(Localizer.LocalizeString("Main.WantToExitMessage"), Localizer.LocalizeString("Main.InformationBox"), MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (dialogResult == DialogResult.OK)
            {
                m_SocksListener?.Dispose();
                m_TimerDataGridViewUpdate.Stop();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void BtnStartListener_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_SocksListener != null && !m_SocksListener.IsDisposed && m_SocksListener.Listening)
                {
                    lblInformation.Text = Localizer.LocalizeString("Main.ListenerAlreadyStarted");
                    return;
                }

                m_SocksListener?.Dispose();

                _backendServce.CloseAllConnectionAsync();

                m_SocksListener = new SocksListener(IPAddress.Parse("127.0.0.1"), 35000);
                m_SocksListener.Start();

                btnStartListener.Enabled = false;
                btnStopListener.Enabled = true;

                startListenerToolStripMenuItem.Enabled = false;
                stopListenerToolStripMenuItem.Enabled = true;

                lblInformation.Text = Localizer.LocalizeString("Main.ListenerSuccessfullyLaunched");
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
                m_SocksListener?.Dispose();

                _backendServce.CloseAllConnectionAsync();

                btnStartListener.Enabled = true;
                btnStopListener.Enabled = false;

                startListenerToolStripMenuItem.Enabled = true;
                stopListenerToolStripMenuItem.Enabled = false;

                lblInformation.Text = Localizer.LocalizeString("Main.ErrorsStartingListener");
            }
        }

        private void BtnStopListener_Click(object sender, EventArgs e)
        {
            try
            {
                m_SocksListener?.Dispose();

                _backendServce.CloseAllConnectionAsync();

                btnStartListener.Enabled = true;
                btnStopListener.Enabled = false;

                startListenerToolStripMenuItem.Enabled = true;
                stopListenerToolStripMenuItem.Enabled = false;

                lblInformation.Text = Localizer.LocalizeString("Main.ListenerSuccessfullyStopped");
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);

                _backendServce.CloseAllConnectionAsync();

                btnStartListener.Enabled = true;
                btnStopListener.Enabled = false;

                startListenerToolStripMenuItem.Enabled = true;
                stopListenerToolStripMenuItem.Enabled = false;

                lblInformation.Text = Localizer.LocalizeString("Main.ErrorsStoppingListener");
            }
        }

        private void BtnUpdateDataGridView_Click(object sender, EventArgs e)
        {
            DataGridViewUpdate();

            lblInformation.Text = Localizer.LocalizeString("Main.ConnectionsSuccessfullyUpdated");
        }

        private void CbAutoUpdateDataGridView_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAutoUpdateDataGridView.Checked)
            {
                m_TimerDataGridViewUpdate.Start();

                btnUpdateDataGridView.Enabled = false;
                updateDataGridViewToolStripMenuItem.Enabled = false;

                lblInformation.Text = Localizer.LocalizeString("Main.AutoUpdatePackagesEnabled");
            }
            else
            {
                m_TimerDataGridViewUpdate.Stop();

                btnUpdateDataGridView.Enabled = true;
                updateDataGridViewToolStripMenuItem.Enabled = true;

                lblInformation.Text = Localizer.LocalizeString("Main.AutoUpdatePackagesDisabled");
            }
        }

        private void TimerDataGridViewUpdate_Tick(object sender, EventArgs e)
        {
            Invoke(new Action(DataGridViewUpdate));
        }

        private void DataGridViewUpdate()
        {
            if (!Monitor.TryEnter(m_TimerDataGridViewUpdateLock))
            {
                return;
            }

            try
            {
                List<ConnectionViewModel> connections = _backendServce.GetConnectionsAsync().Result.ToList();
                lblAllConnections.Text = Localizer.LocalizeString("Main.AllConnections") + " " + connections.Count;

                //var inded = dgvConnections?.CurrentCell?.RowIndex;

                for (int i = 0; i < connections.Count; i++)
                {
                    while (dgvConnections.Rows.Count < i + 1)
                    {
                        dgvConnections.Rows.Add();
                    }

                    while (dgvConnections.Rows.Count > i + 1)
                    {
                        dgvConnections.Rows.RemoveAt(0);
                    }

                    dgvConnections.Rows[i].Cells["Number"].Value = i + 1;
                    dgvConnections.Rows[i].Cells["Id"].Value = connections[i].Id;
                    dgvConnections.Rows[i].Cells["ClientAddress"].Value = connections[i].SourceAddress;
                    dgvConnections.Rows[i].Cells["ServerAddress"].Value = connections[i].DestinationAddress;
                    dgvConnections.Rows[i].Cells["Received"].Value = connections[i].Received;
                    dgvConnections.Rows[i].Cells["Send"].Value = connections[i].Send;
                    dgvConnections.Rows[i].Cells["Disconnected"].Value = connections[i].IsDisconnected ? Localizer.LocalizeString("Main.Connections.Yes") : Localizer.LocalizeString("Main.Connections.No");
                }

                //if (inded.HasValue)
                //{
                //    dgvConnections.Rows[inded.Value].Selected = true;
                //}
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
                lblInformation.Text = Localizer.LocalizeString("Main.ErrorsUpdatingConnections");
            }
            finally
            {
                Monitor.Exit(m_TimerDataGridViewUpdateLock);
            }
        }

        private void DgvConnections_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OpenEditorForConnection();
                e.Handled = true;
            }
        }

        private void DgvConnections_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OpenEditorForConnection();
        }

        private void OpenEditorForConnection()
        {
            int? index = dgvConnections?.CurrentRow?.Index;

            if (index.HasValue)
            {
                MessageBox.Show("For tested");
                //ConnectionModel connection = Connections.GetConnectionAtIndex(index.Value);

                //if (connection != null)
                //{
                //    using (Editor editor = new Editor(connection.Id))
                //    {
                //        Hide();
                //        editor.ShowDialog();
                //        Show();
                //    }
                //}
                //else
                //{
                //    lblInformation.Text = Localizer.LocalizeString("Main.NoConnectionFoundForEditing");
                //}
            }
            else
            {
                lblInformation.Text = Localizer.LocalizeString("Main.ErrorsChoosingConnection");
            }
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //using (Settings settings = new Settings())
            //{
            //    settings.ShowDialog();
            //}
        }
    }
}