using System;
using System.Diagnostics;
using Network_Analyzer.Localization;
using Network_Analyzer.Network.Listeners;
using System.Reflection;
using System.Windows.Forms;

namespace Network_Analyzer
{
    public partial class Main : Form
    {
        private SocksListener m_SocksListener;
        private Timer m_TimerDataGridViewUpdate;
        private object m_TimerDataGridViewUpdateLock = new object();

        public Main()
        {
            InitializeComponent();
            Localizer.LocalizeForm(this);
        }

        private void Main_Load(object sender, System.EventArgs e)
        {
            m_TimerDataGridViewUpdate = new Timer();
            //m_TimerDataGridViewUpdate.Tick += timerDataGridViewUpdate_Tick;

            lblInformation.Text = Localizer.LocalizeString("Main.LoadedSuccessfully");
            lblVersion.Text = Localizer.LocalizeString("Main.Version") + " " + Assembly.GetEntryAssembly()?.GetName().Version;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_SocksListener?.Dispose();
            m_TimerDataGridViewUpdate.Stop();
        }

        private void bStartListener_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_SocksListener != null && !m_SocksListener.IsDisposed && m_SocksListener.Listening)
                {
                    lblInformation.Text = "Сервис уже запущен";
                    return;
                }

                m_SocksListener?.Dispose();

                m_SocksListener = new SocksListener(System.Net.IPAddress.Parse("127.0.0.1"), 30000);
                m_SocksListener.Start();

                btnStartListener.Enabled = false;
                btnStopListener.Enabled = true;

                startListenerToolStripMenuItem.Enabled = false;
                stopListenerToolStripMenuItem.Enabled = true;

                btnSaveConnections.Enabled = false;
                btnLoadConnections.Enabled = false;

                //saveDumpToolStripMenuItem.Enabled = false;
                //loadDumpToolStripMenuItem.Enabled = false;

                btnClearDataGridView.Enabled = false;
                btnClearConnentions.Enabled = false;

                lblInformation.Text = "Сервис успешно запущен";
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

                //saveDumpToolStripMenuItem.Enabled = true;
                //loadDumpToolStripMenuItem.Enabled = true;

                if (!cbAutoUpdateDataGridView.Checked)
                {
                    btnClearDataGridView.Enabled = true;
                    btnClearConnentions.Enabled = true;
                }

                lblInformation.Text = "Ошибки при запуске сервиса";
            }
        }
    }
}
