using Network_Analyzer.Localization;
using System.Windows.Forms;

namespace Network_Analyzer
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            Localizer.LocalizeForm(this);
        }
    }
}
