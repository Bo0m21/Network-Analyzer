namespace Network_Analyzer.Configuration
{
    partial class ConfigurationField
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationField));
            this.gbGeleral = new System.Windows.Forms.GroupBox();
            this.lblInformation = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gbGeleral
            // 
            this.gbGeleral.Location = new System.Drawing.Point(12, 12);
            this.gbGeleral.Name = "gbGeleral";
            this.gbGeleral.Size = new System.Drawing.Size(360, 185);
            this.gbGeleral.TabIndex = 0;
            this.gbGeleral.TabStop = false;
            this.gbGeleral.Text = "ConfigurationField.Geleral";
            // 
            // lblInformation
            // 
            this.lblInformation.AutoSize = true;
            this.lblInformation.Location = new System.Drawing.Point(12, 229);
            this.lblInformation.Name = "lblInformation";
            this.lblInformation.Size = new System.Drawing.Size(146, 13);
            this.lblInformation.TabIndex = 15;
            this.lblInformation.Text = "ConfigurationField.Information";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(247, 203);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 23);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "ConfigurationField.Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 203);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(125, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "ConfigurationField.Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // ConfigurationField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 251);
            this.Controls.Add(this.lblInformation);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gbGeleral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConfigurationField";
            this.Text = "ConfigurationField.Text";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbGeleral;
        private System.Windows.Forms.Label lblInformation;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}