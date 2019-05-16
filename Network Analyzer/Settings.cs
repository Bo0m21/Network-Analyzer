using Network_Analyzer.Localization;
using System.Windows.Forms;

namespace Network_Analyzer
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            Localizer.LocalizeForm(this);
        }

        private void Settings_Load(object sender, System.EventArgs e)
        {
            //cbProgramLanguage.
            tbAddressListener.Text = Configuration.Address;
            tbPortListener.Text = Configuration.Port;
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, System.EventArgs e)
        {

        }

        private void BtnSave_Click(object sender, System.EventArgs e)
        {

        }
    }
}
