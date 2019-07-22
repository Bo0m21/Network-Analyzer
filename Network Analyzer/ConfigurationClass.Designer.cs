namespace Network_Analyzer
{
	partial class ConfigurationClass
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationClass));
			this.lblInformation = new System.Windows.Forms.Label();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.gbGeleral = new System.Windows.Forms.GroupBox();
			this.lblName = new System.Windows.Forms.Label();
			this.tbName = new System.Windows.Forms.TextBox();
			this.lblOpcode = new System.Windows.Forms.Label();
			this.tbOpcode = new System.Windows.Forms.TextBox();
			this.gbGeleral.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblInformation
			// 
			this.lblInformation.AutoSize = true;
			this.lblInformation.Location = new System.Drawing.Point(12, 144);
			this.lblInformation.Name = "lblInformation";
			this.lblInformation.Size = new System.Drawing.Size(149, 13);
			this.lblInformation.TabIndex = 19;
			this.lblInformation.Text = "ConfigurationClass.Information";
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(247, 118);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(125, 23);
			this.btnSave.TabIndex = 18;
			this.btnSave.Text = "ConfigurationClass.Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(12, 118);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(125, 23);
			this.btnCancel.TabIndex = 17;
			this.btnCancel.Text = "ConfigurationClass.Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
			// 
			// gbGeleral
			// 
			this.gbGeleral.Controls.Add(this.lblOpcode);
			this.gbGeleral.Controls.Add(this.tbOpcode);
			this.gbGeleral.Controls.Add(this.lblName);
			this.gbGeleral.Controls.Add(this.tbName);
			this.gbGeleral.Location = new System.Drawing.Point(12, 11);
			this.gbGeleral.Name = "gbGeleral";
			this.gbGeleral.Size = new System.Drawing.Size(360, 101);
			this.gbGeleral.TabIndex = 16;
			this.gbGeleral.TabStop = false;
			this.gbGeleral.Text = "ConfigurationClass.Geleral";
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblName.Location = new System.Drawing.Point(6, 16);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(147, 15);
			this.lblName.TabIndex = 22;
			this.lblName.Text = "ConfigurationClass.Name";
			// 
			// tbName
			// 
			this.tbName.Location = new System.Drawing.Point(6, 34);
			this.tbName.Name = "tbName";
			this.tbName.Size = new System.Drawing.Size(348, 20);
			this.tbName.TabIndex = 21;
			// 
			// lblOpcode
			// 
			this.lblOpcode.AutoSize = true;
			this.lblOpcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblOpcode.Location = new System.Drawing.Point(6, 57);
			this.lblOpcode.Name = "lblOpcode";
			this.lblOpcode.Size = new System.Drawing.Size(156, 15);
			this.lblOpcode.TabIndex = 24;
			this.lblOpcode.Text = "ConfigurationClass.Opcode";
			// 
			// tbOpcode
			// 
			this.tbOpcode.Location = new System.Drawing.Point(6, 75);
			this.tbOpcode.Name = "tbOpcode";
			this.tbOpcode.Size = new System.Drawing.Size(348, 20);
			this.tbOpcode.TabIndex = 23;
			// 
			// ConfigurationClass
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(384, 166);
			this.Controls.Add(this.lblInformation);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.gbGeleral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "ConfigurationClass";
			this.Text = "ConfigurationClass.Text";
			this.Load += new System.EventHandler(this.ConfigurationClass_Load);
			this.gbGeleral.ResumeLayout(false);
			this.gbGeleral.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblInformation;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.GroupBox gbGeleral;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.TextBox tbName;
		private System.Windows.Forms.Label lblOpcode;
		private System.Windows.Forms.TextBox tbOpcode;
	}
}