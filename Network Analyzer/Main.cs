using Network_Analyzer.Localization;
using System.Reflection;
using System.Windows.Forms;

namespace Network_Analyzer
{
    public partial class Main : Form
    {
        //private SocksListener m_SocksListener;
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
            lblVersion.Text = Localizer.LocalizeString("Main.Version") + " " + Assembly.GetEntryAssembly().GetName().Version;
        }
    }
}
