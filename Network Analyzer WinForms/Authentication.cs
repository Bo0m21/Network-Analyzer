using Network_Analyzer_WinForms.Extensions;
using Network_Analyzer_WinForms.Services;
using Network_Analyzer_WinForms.Utilities;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Network_Analyzer_WinForms
{
    public partial class Authentication : Form
    {
        private BackendServce _backendServce;

        public Authentication()
        {
            InitializeComponent();
            Localizer.LocalizeForm(this);

            _backendServce = BackendServce.GetService();
        }

        private void btnAuth_Click(object sender, System.EventArgs e)
        {
            try
            {
                var asdsadsad = _backendServce.AuthenticateAsync(new UserAuthReqModel()
                {
                    Username = tbLogin.Text,
                    Password = tbPassword.Text
                }).Result;


            }
            catch (Exception ex)
            {
                var message = ex.TreatmentException();



                Trace.TraceError(ex.Message);

                lblInformation.Text = Localizer.LocalizeString("Authentication.ErrorsAuthentication");
            }
        }

        private void btnClear_Click(object sender, System.EventArgs e)
        {
            tbLogin.Clear();
            tbPassword.Clear();

            lblInformation.Text = Localizer.LocalizeString("Authentication.AllFieldCleared");
        }
    }
}
