namespace Network_Analyzer_WinForms
{
    partial class Authentication
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Authentication));
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.cbRemember = new System.Windows.Forms.CheckBox();
            this.btnAuth = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblInformation = new System.Windows.Forms.Label();
            this.preLoad = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.preLoad.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(147, 48);
            this.tbLogin.Margin = new System.Windows.Forms.Padding(4);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(251, 22);
            this.tbLogin.TabIndex = 10;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(147, 80);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(4);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(251, 22);
            this.tbPassword.TabIndex = 12;
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(81, 52);
            this.lblLogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(137, 17);
            this.lblLogin.TabIndex = 9;
            this.lblLogin.Text = "Authentication.Login";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(81, 84);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(163, 17);
            this.lblPassword.TabIndex = 11;
            this.lblPassword.Text = "Authentication.Password";
            // 
            // cbRemember
            // 
            this.cbRemember.AutoSize = true;
            this.cbRemember.Location = new System.Drawing.Point(167, 112);
            this.cbRemember.Margin = new System.Windows.Forms.Padding(4);
            this.cbRemember.Name = "cbRemember";
            this.cbRemember.Size = new System.Drawing.Size(193, 21);
            this.cbRemember.TabIndex = 13;
            this.cbRemember.Text = "Authentication.Remember";
            this.cbRemember.UseVisualStyleBackColor = true;
            // 
            // btnAuth
            // 
            this.btnAuth.Location = new System.Drawing.Point(57, 146);
            this.btnAuth.Margin = new System.Windows.Forms.Padding(4);
            this.btnAuth.Name = "btnAuth";
            this.btnAuth.Size = new System.Drawing.Size(167, 28);
            this.btnAuth.TabIndex = 14;
            this.btnAuth.Text = "Authentication.Auth";
            this.btnAuth.UseVisualStyleBackColor = true;
            this.btnAuth.Click += new System.EventHandler(this.btnAuth_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(263, 146);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(167, 28);
            this.btnClear.TabIndex = 15;
            this.btnClear.Text = "Authentication.Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblInformation
            // 
            this.lblInformation.AutoSize = true;
            this.lblInformation.Location = new System.Drawing.Point(16, 198);
            this.lblInformation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInformation.Name = "lblInformation";
            this.lblInformation.Size = new System.Drawing.Size(172, 17);
            this.lblInformation.TabIndex = 16;
            this.lblInformation.Text = "Authentication.Information";
            // 
            // preLoad
            // 
            this.preLoad.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.preLoad.Controls.Add(this.label1);
            this.preLoad.Location = new System.Drawing.Point(-13, -11);
            this.preLoad.Name = "preLoad";
            this.preLoad.Size = new System.Drawing.Size(518, 245);
            this.preLoad.TabIndex = 17;
            this.preLoad.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(162, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loading...";
            // 
            // Authentication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 225);
            this.Controls.Add(this.preLoad);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.cbRemember);
            this.Controls.Add(this.btnAuth);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblInformation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Authentication";
            this.Text = "Authentication.Text";
            this.preLoad.ResumeLayout(false);
            this.preLoad.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.CheckBox cbRemember;
        private System.Windows.Forms.Button btnAuth;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblInformation;
        private System.Windows.Forms.Panel preLoad;
        private System.Windows.Forms.Label label1;
    }
}

