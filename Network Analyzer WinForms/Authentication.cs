﻿using Network_Analyzer_WinForms.Extensions;
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

        // Method for test
        private async void Authentication_Load(object sender, EventArgs e)
        {
            UserAuthResModel userAuthResponce = await _backendServce.AuthenticateAsync(new UserAuthReqModel()
            {
                Username = "string",
                Password = "string"
            });

            _backendServce.SetToken(userAuthResponce.Token);

            // Hide this form
            Hide();

            // Starting main form
            Main mainForm = new Main();
            mainForm.ShowDialog();

            // Show this form
            Show();
        }

        private async void btnAuth_Click(object sender, EventArgs e)
        {
            try
            {
                UserAuthResModel userAuthResponce = await _backendServce.AuthenticateAsync(new UserAuthReqModel()
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


                // Show this form
                Show();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
                lblInformation.Text = ExceptionExtension.GetExceptionMessage(ex);
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
