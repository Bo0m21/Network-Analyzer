using System;
using System.Reflection;
using System.Windows.Forms;
using Network_Analyzer_WinForms.Services;
using Network_Analyzer_WinForms.Utilities;

namespace Network_Analyzer_WinForms
{
    public partial class Main : Form
    {
        private BackendServce _backendServce;

        public Main()
        {
            InitializeComponent();
            Localizer.LocalizeForm(this);

            _backendServce = BackendServce.GetService();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //m_TimerDataGridViewUpdate = new System.Windows.Forms.Timer();
            //m_TimerDataGridViewUpdate.Tick += TimerDataGridViewUpdate_Tick;

            //m_TimerAutoSaveConnections = new System.Windows.Forms.Timer();
            //m_TimerAutoSaveConnections.Tick += TimerAutoSaveConnections_Tick;

            //List<ConnectionModel> connections = Connections.GetConnections();
            //lblAllConnections.Text = Localizer.LocalizeString("Main.AllConnections") + " " + connections.Count;

            lblInformation.Text = Localizer.LocalizeString("Main.LoadedSuccessfully");
            lblVersion.Text = Localizer.LocalizeString("Main.Version") + " " +
                              Assembly.GetEntryAssembly()?.GetName().Version;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(Localizer.LocalizeString("Main.WantToExitMessage"),
                Localizer.LocalizeString("Main.InformationBox"), MessageBoxButtons.OKCancel,
                MessageBoxIcon.Information);

            if (dialogResult == DialogResult.OK)
            {
                //m_SocksListener?.Dispose();
                //m_TimerDataGridViewUpdate.Stop();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}