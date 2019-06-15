using Network_Analyzer.Services;
using System.Windows.Forms;

namespace Network_Analyzer.Configuration
{
    public partial class ConfigurationField : Form
    {
        public ConfigurationField(long selectionIndex)
        {
            InitializeComponent();
            Localizer.LocalizeForm(this);

            selectionIndex
        }
    }
}
