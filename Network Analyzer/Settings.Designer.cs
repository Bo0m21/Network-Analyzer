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
            this.gbGeneralSettings = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblProgramLanguage = new System.Windows.Forms.Label();
            this.cbProgramLanguage = new System.Windows.Forms.ComboBox();
            this.tbAddressListener = new System.Windows.Forms.TextBox();
            this.lblAddressListener = new System.Windows.Forms.Label();
            this.tbPortListener = new System.Windows.Forms.TextBox();
            this.lblPortListener = new System.Windows.Forms.Label();
            this.gbGeneralSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbGeneralSettings
            // 
            this.gbGeneralSettings.Controls.Add(this.lblPortListener);
            this.gbGeneralSettings.Controls.Add(this.tbPortListener);
            this.gbGeneralSettings.Controls.Add(this.lblAddressListener);
            this.gbGeneralSettings.Controls.Add(this.tbAddressListener);
            this.gbGeneralSettings.Controls.Add(this.cbProgramLanguage);
            this.gbGeneralSettings.Controls.Add(this.lblProgramLanguage);
            this.gbGeneralSettings.Location = new System.Drawing.Point(12, 12);
            this.gbGeneralSettings.Name = "gbGeneralSettings";
            this.gbGeneralSettings.Size = new System.Drawing.Size(297, 98);
            this.gbGeneralSettings.TabIndex = 0;
            this.gbGeneralSettings.TabStop = false;
            this.gbGeneralSettings.Text = "Settings.GeneralSettings";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 116);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(125, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Settings.Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(184, 116);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Settings.Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
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
            // cbProgramLanguage
            // 
            this.cbProgramLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProgramLanguage.FormattingEnabled = true;
            this.cbProgramLanguage.Items.AddRange(new object[] {
            "English",
            "Русский"});
            this.cbProgramLanguage.Location = new System.Drawing.Point(166, 19);
            this.cbProgramLanguage.Name = "cbProgramLanguage";
            this.cbProgramLanguage.Size = new System.Drawing.Size(125, 21);
            this.cbProgramLanguage.TabIndex = 1;
            // 
            // tbAddressListener
            // 
            this.tbAddressListener.Location = new System.Drawing.Point(166, 46);
            this.tbAddressListener.Name = "tbAddressListener";
            this.tbAddressListener.Size = new System.Drawing.Size(125, 20);
            this.tbAddressListener.TabIndex = 2;
            // 
            // lblAddressListener
            // 
            this.lblAddressListener.AutoSize = true;
            this.lblAddressListener.Location = new System.Drawing.Point(6, 49);
            this.lblAddressListener.Name = "lblAddressListener";
            this.lblAddressListener.Size = new System.Drawing.Size(123, 13);
            this.lblAddressListener.TabIndex = 3;
            this.lblAddressListener.Text = "Settings.AddressListener";
            // 
            // tbPortListener
            // 
            this.tbPortListener.Location = new System.Drawing.Point(166, 72);
            this.tbPortListener.Name = "tbPortListener";
            this.tbPortListener.Size = new System.Drawing.Size(125, 20);
            this.tbPortListener.TabIndex = 4;
            // 
            // lblPortListener
            // 
            this.lblPortListener.AutoSize = true;
            this.lblPortListener.Location = new System.Drawing.Point(6, 75);
            this.lblPortListener.Name = "lblPortListener";
            this.lblPortListener.Size = new System.Drawing.Size(104, 13);
            this.lblPortListener.TabIndex = 5;
            this.lblPortListener.Text = "Settings.PortListener";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 151);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gbGeneralSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Settings";
            this.Text = "Settings.Text";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.gbGeneralSettings.ResumeLayout(false);
            this.gbGeneralSettings.PerformLayout();
            this.ResumeLayout(false);

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
    }
}