using System;
using System.Diagnostics;
using System.Windows.Forms;
using Network_Analyzer_WinForms.Extensions;
using Network_Analyzer_WinForms.Services;
using Network_Analyzer_WinForms.Utilities;

namespace Network_Analyzer_WinForms
{
    public partial class Authentication : Form
    {
        private readonly BackendServce _backendServce;

        public Authentication()
        {
            InitializeComponent();
            Localizer.LocalizeForm(this);

            // For tested
            tbLogin.Text = "string";
            tbPassword.Text = "string";

            _backendServce = BackendServce.GetService();
        }

        private async void btnAuth_Click(object sender, EventArgs e)
        {
            try
            {
                UserAuthResModel userAuthResponce = await _backendServce.AuthenticateAsync(new UserAuthReqModel
                {
                    Username = tbLogin.Text,
                    Password = tbPassword.Text
                });

                _backendServce.SetToken(userAuthResponce.Token);

                // Hide this form
                Hide();

                // Starting main form
                Main mainForm = new Main();
                mainForm.ShowDialog();

                // Cloae application
                Application.Exit();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
                lblInformation.Text = ex.GetExceptionMessage();
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