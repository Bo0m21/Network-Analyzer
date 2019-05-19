namespace Network_Analyzer
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.gbGeneralSettings = new System.Windows.Forms.GroupBox();
            this.lblPortListener = new System.Windows.Forms.Label();
            this.tbPortListener = new System.Windows.Forms.TextBox();
            this.lblAddressListener = new System.Windows.Forms.Label();
            this.tbAddressListener = new System.Windows.Forms.TextBox();
            this.cbProgramLanguage = new System.Windows.Forms.ComboBox();
            this.lblProgramLanguage = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblInformation = new System.Windows.Forms.Label();
            this.gbListenerSettings = new System.Windows.Forms.GroupBox();
            this.tbFolderSaved = new System.Windows.Forms.TextBox();
            this.lblFolderSaved = new System.Windows.Forms.Label();
            this.gbGeneralSettings.SuspendLayout();
            this.gbListenerSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbGeneralSettings
            // 
            this.gbGeneralSettings.Controls.Add(this.cbProgramLanguage);
            this.gbGeneralSettings.Controls.Add(this.lblProgramLanguage);
            this.gbGeneralSettings.Location = new System.Drawing.Point(12, 12);
            this.gbGeneralSettings.Name = "gbGeneralSettings";
            this.gbGeneralSettings.Size = new System.Drawing.Size(303, 46);
            this.gbGeneralSettings.TabIndex = 0;
            this.gbGeneralSettings.TabStop = false;
            this.gbGeneralSettings.Text = "Settings.GeneralSettings";
            // 
            // lblPortListener
            // 
            this.lblPortListener.AutoSize = true;
            this.lblPortListener.Location = new System.Drawing.Point(6, 48);
            this.lblPortListener.Name = "lblPortListener";
            this.lblPortListener.Size = new System.Drawing.Size(104, 13);
            this.lblPortListener.TabIndex = 5;
            this.lblPortListener.Text = "Settings.PortListener";
            // 
            // tbPortListener
            // 
            this.tbPortListener.Location = new System.Drawing.Point(147, 45);
            this.tbPortListener.Name = "tbPortListener";
            this.tbPortListener.Size = new System.Drawing.Size(150, 20);
            this.tbPortListener.TabIndex = 4;
            // 
            // lblAddressListener
            // 
            this.lblAddressListener.AutoSize = true;
            this.lblAddressListener.Location = new System.Drawing.Point(6, 22);
            this.lblAddressListener.Name = "lblAddressListener";
            this.lblAddressListener.Size = new System.Drawing.Size(123, 13);
            this.lblAddressListener.TabIndex = 3;
            this.lblAddressListener.Text = "Settings.AddressListener";
            // 
            // tbAddressListener
            // 
            this.tbAddressListener.Location = new System.Drawing.Point(147, 19);
            this.tbAddressListener.Name = "tbAddressListener";
            this.tbAddressListener.Size = new System.Drawing.Size(150, 20);
            this.tbAddressListener.TabIndex = 2;
            // 
            // cbProgramLanguage
            // 
            this.cbProgramLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProgramLanguage.FormattingEnabled = true;
            this.cbProgramLanguage.Location = new System.Drawing.Point(147, 19);
            this.cbProgramLanguage.Name = "cbProgramLanguage";
            this.cbProgramLanguage.Size = new System.Drawing.Size(150, 21);
            this.cbProgramLanguage.TabIndex = 1;
            // 
            // lblProgramLanguage
            // 
            this.lblProgramLanguage.AutoSize = true;
            this.lblProgramLanguage.Location = new System.Drawing.Point(6, 22);
            this.lblProgramLanguage.Name = "lblProgramLanguage";
            this.lblProgramLanguage.Size = new System.Drawing.Size(135, 13);
            this.lblProgramLanguage.TabIndex = 0;
            this.lblProgramLanguage.Text = "Settings.ProgramLanguage";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 167);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(125, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Settings.Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(190, 167);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Settings.Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // lblInformation
            // 
            this.lblInformation.AutoSize = true;
            this.lblInformation.Location = new System.Drawing.Point(12, 195);
            this.lblInformation.Name = "lblInformation";
            this.lblInformation.Size = new System.Drawing.Size(100, 13);
            this.lblInformation.TabIndex = 12;
            this.lblInformation.Text = "Settings.Information";
            // 
            // gbListenerSettings
            // 
            this.gbListenerSettings.Controls.Add(this.lblFolderSaved);
            this.gbListenerSettings.Controls.Add(this.tbFolderSaved);
            this.gbListenerSettings.Controls.Add(this.lblPortListener);
            this.gbListenerSettings.Controls.Add(this.lblAddressListener);
            this.gbListenerSettings.Controls.Add(this.tbPortListener);
            this.gbListenerSettings.Controls.Add(this.tbAddressListener);
            this.gbListenerSettings.Location = new System.Drawing.Point(12, 64);
            this.gbListenerSettings.Name = "gbListenerSettings";
            this.gbListenerSettings.Size = new System.Drawing.Size(303, 97);
            this.gbListenerSettings.TabIndex = 13;
            this.gbListenerSettings.TabStop = false;
            this.gbListenerSettings.Text = "Settings.ListenerSettings";
            // 
            // tbFolderSaved
            // 
            this.tbFolderSaved.Location = new System.Drawing.Point(147, 71);
            this.tbFolderSaved.Name = "tbFolderSaved";
            this.tbFolderSaved.Size = new System.Drawing.Size(150, 20);
            this.tbFolderSaved.TabIndex = 6;
            // 
            // lblFolderSaved
            // 
            this.lblFolderSaved.AutoSize = true;
            this.lblFolderSaved.Location = new System.Drawing.Point(6, 74);
            this.lblFolderSaved.Name = "lblFolderSaved";
            this.lblFolderSaved.Size = new System.Drawing.Size(108, 13);
            this.lblFolderSaved.TabIndex = 7;
            this.lblFolderSaved.Text = "Settings.FolderSaved";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 217);
            this.Controls.Add(this.gbListenerSettings);
            this.Controls.Add(this.lblInformation);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gbGeneralSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.Text = "Settings.Text";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.gbGeneralSettings.ResumeLayout(false);
            this.gbGeneralSettings.PerformLayout();
            this.gbListenerSettings.ResumeLayout(false);
            this.gbListenerSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbGeneralSettings;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cbProgramLanguage;
        private System.Windows.Forms.Label lblProgramLanguage;
        private System.Windows.Forms.Label lblAddressListener;
        private System.Windows.Forms.TextBox tbAddressListener;
        private System.Windows.Forms.Label lblPortListener;
        private System.Windows.Forms.TextBox tbPortListener;
        private System.Windows.Forms.Label lblInformation;
        private System.Windows.Forms.GroupBox gbListenerSettings;
        private System.Windows.Forms.Label lblFolderSaved;
        private System.Windows.Forms.TextBox tbFolderSaved;
    }
}