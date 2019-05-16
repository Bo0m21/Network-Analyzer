using Network_Analyzer.Localization;
using Network_Analyzer.Network.Data;
using Network_Analyzer.Network.Listeners;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Network_Analyzer
{
    public partial class Main : Form
    {
        private SocksListener m_SocksListener;
        private Timer m_TimerDataGridViewUpdate;
        private readonly object m_TimerDataGridViewUpdateLock = new object();

        public Main()
        {
            InitializeComponent();
            Localizer.LocalizeForm(this);
        }

        private void Main_Load(object sender, System.EventArgs e)
        {
            m_TimerDataGridViewUpdate = new Timer();
            m_TimerDataGridViewUpdate.Tick += TimerDataGridViewUpdate_Tick;

            var connections = Connections.GetConnections();
            lblAllConnections.Text = Localizer.LocalizeString("Main.AllConnections") + " " + connections.Count.ToString();

            lblInformation.Text = Localizer.LocalizeString("Main.LoadedSuccessfully");
            lblVersion.Text = Localizer.LocalizeString("Main.Version") + " " + Assembly.GetEntryAssembly()?.GetName().Version;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_SocksListener?.Dispose();
            m_TimerDataGridViewUpdate.Stop();
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

                // TODO Перенести в настройки
                m_SocksListener = new SocksListener(System.Net.IPAddress.Parse(Configuration.Address), Configuration.Port);
                m_SocksListener.Start();

                btnStartListener.Enabled = false;
                btnStopListener.Enabled = true;

                startListenerToolStripMenuItem.Enabled = false;
                stopListenerToolStripMenuItem.Enabled = true;

                btnSaveConnections.Enabled = false;
                btnLoadConnections.Enabled = false;

                saveConnectionsToolStripMenuItem.Enabled = false;
                loadConnectionsToolStripMenuItem.Enabled = false;

                btnClearConnentions.Enabled = false;

                lblInformation.Text = Localizer.LocalizeString("Main.ListenerSuccessfullyLaunched");
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
                m_SocksListener?.Dispose();

                btnStartListener.Enabled = true;
                btnStopListener.Enabled = false;

                startListenerToolStripMenuItem.Enabled = true;
                stopListenerToolStripMenuItem.Enabled = false;

                btnSaveConnections.Enabled = true;
                btnLoadConnections.Enabled = true;

                saveConnectionsToolStripMenuItem.Enabled = true;
                loadConnectionsToolStripMenuItem.Enabled = true;

                if (!cbAutoUpdateDataGridView.Checked)
                {
                    btnClearConnentions.Enabled = true;
                }

                lblInformation.Text = Localizer.LocalizeString("Main.ErrorsStartingListener");
            }
        }

        private void BtnStopListener_Click(object sender, EventArgs e)
        {
            try
            {
                m_SocksListener?.Dispose();

                btnStartListener.Enabled = true;
                btnStopListener.Enabled = false;

                startListenerToolStripMenuItem.Enabled = true;
                stopListenerToolStripMenuItem.Enabled = false;

                btnSaveConnections.Enabled = true;
                btnLoadConnections.Enabled = true;

                saveConnectionsToolStripMenuItem.Enabled = true;
                loadConnectionsToolStripMenuItem.Enabled = true;

                if (!cbAutoUpdateDataGridView.Checked)
                {
                    btnClearConnentions.Enabled = true;
                }

                lblInformation.Text = Localizer.LocalizeString("Main.ListenerSuccessfullyStopped");
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);

                btnStartListener.Enabled = true;
                btnStopListener.Enabled = false;

                startListenerToolStripMenuItem.Enabled = true;
                stopListenerToolStripMenuItem.Enabled = false;

                btnSaveConnections.Enabled = true;
                btnLoadConnections.Enabled = true;

                saveConnectionsToolStripMenuItem.Enabled = true;
                loadConnectionsToolStripMenuItem.Enabled = true;

                if (!cbAutoUpdateDataGridView.Checked)
                {
                    btnClearConnentions.Enabled = true;
                }

                lblInformation.Text = Localizer.LocalizeString("Main.ErrorsStoppingListener");
            }
        }

        private void BtnLoadConnections_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TODO");
        }

        private void BtnSaveConnections_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TODO");
        }

        private void BtnClearConnentions_Click(object sender, EventArgs e)
        {
            Connections.Clear();
            dgvConnections.Rows.Clear();

            DataGridViewUpdate();

            lblInformation.Text = Localizer.LocalizeString("Main.ConnectionsSuccessfullyCleanedUpdated");
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

                btnClearConnentions.Enabled = false;
                btnUpdateDataGridView.Enabled = false;

                lblInformation.Text = Localizer.LocalizeString("Main.AutoUpdatePackagesEnabled");
            }
            else
            {
                m_TimerDataGridViewUpdate.Stop();

                if (m_SocksListener == null || m_SocksListener.IsDisposed || !m_SocksListener.Listening)
                {
                    btnClearConnentions.Enabled = true;
                }

                btnUpdateDataGridView.Enabled = true;

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
                return;

            try
            {
                var connections = Connections.GetConnections();
                lblAllConnections.Text = Localizer.LocalizeString("Main.AllConnections") + " " + connections.Count.ToString();

                for (var i = 0; i < connections.Count; i++)
                {
                    while (dgvConnections.Rows.Count < i + 1)
                    {
                        dgvConnections.Rows.Add();
                    }

                    dgvConnections.Rows[i].Cells["Number"].Value = i + 1;
                    dgvConnections.Rows[i].Cells["Id"].Value = connections[i].Id;
                    dgvConnections.Rows[i].Cells["ClientAddress"].Value = connections[i].SourceAddress;
                    dgvConnections.Rows[i].Cells["ServerAddress"].Value = connections[i].DestinationAddress;
                    dgvConnections.Rows[i].Cells["Received"].Value = connections[i].Received;
                    dgvConnections.Rows[i].Cells["Send"].Value = connections[i].Send;
                    dgvConnections.Rows[i].Cells["Disconnected"].Value = connections[i].IsDisconnected ? Localizer.LocalizeString("Main.Connections.Yes") : Localizer.LocalizeString("Main.Connections.No");
                }
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
            var index = dgvConnections?.CurrentRow?.Index;

            if (index.HasValue)
            {
                var connection = Connections.GetConnectionAtIndex(index.Value);

                if (connection != null)
                {
                    MessageBox.Show("TODO");
                    //using (var editor = new Editor(connection.Id))
                    //{
                    //    Hide();
                    //    editor.ShowDialog();
                    //    Show();
                    //}
                }
                else
                {
                    lblInformation.Text = Localizer.LocalizeString("Main.NoConnectionFoundForEditing");
                }
            }
            else
            {
                lblInformation.Text = Localizer.LocalizeString("Main.ErrorsChoosingConnection");
            }
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Settings settings = new Settings())
            {
                settings.ShowDialog();
            }
        }
    }
}
