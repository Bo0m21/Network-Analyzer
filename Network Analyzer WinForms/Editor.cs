using System.Windows.Forms;
using Network_Analyzer_WinForms.Services;
using Network_Analyzer_WinForms.Utilities;

namespace Network_Analyzer_WinForms
{
    public partial class Editor : Form
    {
        private readonly ConnectionViewModel _connection;
        private readonly BackendServce _backendServce;

        public Editor(ConnectionViewModel connection)
        {
            InitializeComponent();
            Localizer.LocalizeForm(this);

            _connection = connection;
            _backendServce = BackendServce.GetService();
        }
    }
}