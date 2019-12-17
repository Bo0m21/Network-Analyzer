using Network_Analyzer.Code;
using Network_Analyzer.Services;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Network_Analyzer
{
    public partial class Authentication : Form
    {
        public Authentication()
        {
            InitializeComponent();
            Localizer.LocalizeForm(this);
        }

        private void Authentication_Load(object sender, EventArgs e)
        {
            //Client111111.Client1 client1 = new Client111111.Client1();

            //var asdasd = client1.AuthenticateAsync(new UserAuthReqModel()
            //{
            //    Username = "string",
            //    Password = "string"
            //}).Result;
        }

        private void btnAuth_Click(object sender, EventArgs e)
        {
            try
            {
                BackendClient backendClient = BackendClient.GetInstance();

                var asdsadsad = backendClient.AuthenticateAsync(new UserAuthReqModel()
                {
                    Username = tbLogin.Text,
                    Password = tbPassword.Text
                }).Result;


            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);

                lblInformation.Text = Localizer.LocalizeString("Authentication.ErrorsAuthentication");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbLogin.Clear();
            tbPassword.Clear();

            lblInformation.Text = Localizer.LocalizeString("Authentication.AllFieldCleared");
        }
    }
}
