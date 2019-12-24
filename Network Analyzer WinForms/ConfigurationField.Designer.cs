namespace Network_Analyzer_WinForms
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
			this.lblArrayLength = new System.Windows.Forms.Label();
			this.tbArrayLength = new System.Windows.Forms.TextBox();
			this.cbArray = new System.Windows.Forms.CheckBox();
			this.tbValue = new System.Windows.Forms.TextBox();
			this.lblValue = new System.Windows.Forms.Label();
			this.lblSequenceType = new System.Windows.Forms.Label();
			this.cbSequenceType = new System.Windows.Forms.ComboBox();
			this.cbCommon = new System.Windows.Forms.ComboBox();
			this.lblCommon = new System.Windows.Forms.Label();
			this.lblPosition = new System.Windows.Forms.Label();
			this.tbPosition = new System.Windows.Forms.TextBox();
			this.cbType = new System.Windows.Forms.ComboBox();
			this.lblType = new System.Windows.Forms.Label();
			this.lblDescription = new System.Windows.Forms.Label();
			this.tbDescription = new System.Windows.Forms.TextBox();
			this.lblName = new System.Windows.Forms.Label();
			this.tbName = new System.Windows.Forms.TextBox();
			this.lblInformation = new System.Windows.Forms.Label();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.gbGeleral.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbGeleral
			// 
			this.gbGeleral.Controls.Add(this.lblArrayLength);
			this.gbGeleral.Controls.Add(this.tbArrayLength);
			this.gbGeleral.Controls.Add(this.cbArray);
			this.gbGeleral.Controls.Add(this.tbValue);
			this.gbGeleral.Controls.Add(this.lblValue);
			this.gbGeleral.Controls.Add(this.lblSequenceType);
			this.gbGeleral.Controls.Add(this.cbSequenceType);
			this.gbGeleral.Controls.Add(this.cbCommon);
			this.gbGeleral.Controls.Add(this.lblCommon);
			this.gbGeleral.Controls.Add(this.lblPosition);
			this.gbGeleral.Controls.Add(this.tbPosition);
			this.gbGeleral.Controls.Add(this.cbType);
			this.gbGeleral.Controls.Add(this.lblType);
			this.gbGeleral.Controls.Add(this.lblDescription);
			this.gbGeleral.Controls.Add(this.tbDescription);
			this.gbGeleral.Controls.Add(this.lblName);
			this.gbGeleral.Controls.Add(this.tbName);
			this.gbGeleral.Location = new System.Drawing.Point(12, 12);
			this.gbGeleral.Name = "gbGeleral";
			this.gbGeleral.Size = new System.Drawing.Size(360, 365);
			this.gbGeleral.TabIndex = 0;
			this.gbGeleral.TabStop = false;
			this.gbGeleral.Text = "ConfigurationField.Geleral";
			// 
			// lblArrayLength
			// 
			this.lblArrayLength.AutoSize = true;
			this.lblArrayLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblArrayLength.Location = new System.Drawing.Point(6, 121);
			this.lblArrayLength.Name = "lblArrayLength";
			this.lblArrayLength.Size = new System.Drawing.Size(175, 15);
			this.lblArrayLength.TabIndex = 56;
			this.lblArrayLength.Text = "ConfigurationField.ArrayLength";
			// 
			// tbArrayLength
			// 
			this.tbArrayLength.Enabled = false;
			this.tbArrayLength.Location = new System.Drawing.Point(6, 139);
			this.tbArrayLength.Name = "tbArrayLength";
			this.tbArrayLength.Size = new System.Drawing.Size(348, 20);
			this.tbArrayLength.TabIndex = 55;
			this.tbArrayLength.Text = "0";
			// 
			// cbArray
			// 
			this.cbArray.AutoSize = true;
			this.cbArray.Location = new System.Drawing.Point(6, 101);
			this.cbArray.Name = "cbArray";
			this.cbArray.Size = new System.Drawing.Size(137, 17);
			this.cbArray.TabIndex = 54;
			this.cbArray.Text = "ConfigurationField.Array";
			this.cbArray.UseVisualStyleBackColor = true;
			this.cbArray.CheckedChanged += new System.EventHandler(this.CbArray_CheckedChanged);
			// 
			// tbValue
			// 
			this.tbValue.Location = new System.Drawing.Point(75, 335);
			this.tbValue.Name = "tbValue";
			this.tbValue.ReadOnly = true;
			this.tbValue.Size = new System.Drawing.Size(279, 20);
			this.tbValue.TabIndex = 53;
			// 
			// lblValue
			// 
			this.lblValue.AutoSize = true;
			this.lblValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblValue.Location = new System.Drawing.Point(6, 336);
			this.lblValue.Name = "lblValue";
			this.lblValue.Size = new System.Drawing.Size(141, 15);
			this.lblValue.TabIndex = 42;
			this.lblValue.Text = "ConfigurationField.Value";
			// 
			// lblSequenceType
			// 
			this.lblSequenceType.AutoSize = true;
			this.lblSequenceType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblSequenceType.Location = new System.Drawing.Point(6, 162);
			this.lblSequenceType.Name = "lblSequenceType";
			this.lblSequenceType.Size = new System.Drawing.Size(192, 15);
			this.lblSequenceType.TabIndex = 41;
			this.lblSequenceType.Text = "ConfigurationField.SequenceType";
			// 
			// cbSequenceType
			// 
			this.cbSequenceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSequenceType.FormattingEnabled = true;
			this.cbSequenceType.Items.AddRange(new object[] {
            "SequenceTypes.LittleEndian",
            "SequenceTypes.BigEndian"});
			this.cbSequenceType.Location = new System.Drawing.Point(6, 180);
			this.cbSequenceType.Name = "cbSequenceType";
			this.cbSequenceType.Size = new System.Drawing.Size(348, 21);
			this.cbSequenceType.TabIndex = 40;
			this.cbSequenceType.SelectedIndexChanged += new System.EventHandler(this.CbSequenceType_SelectedIndexChanged);
			// 
			// cbCommon
			// 
			this.cbCommon.Enabled = false;
			this.cbCommon.FormattingEnabled = true;
			this.cbCommon.Location = new System.Drawing.Point(6, 264);
			this.cbCommon.Name = "cbCommon";
			this.cbCommon.Size = new System.Drawing.Size(348, 21);
			this.cbCommon.TabIndex = 31;
			this.cbCommon.TextChanged += new System.EventHandler(this.CbCommon_TextChanged);
			// 
			// lblCommon
			// 
			this.lblCommon.AutoSize = true;
			this.lblCommon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblCommon.Location = new System.Drawing.Point(6, 246);
			this.lblCommon.Name = "lblCommon";
			this.lblCommon.Size = new System.Drawing.Size(193, 15);
			this.lblCommon.TabIndex = 30;
			this.lblCommon.Text = "ConfigurationField.CommonString";
			// 
			// lblPosition
			// 
			this.lblPosition.AutoSize = true;
			this.lblPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblPosition.Location = new System.Drawing.Point(6, 291);
			this.lblPosition.Name = "lblPosition";
			this.lblPosition.Size = new System.Drawing.Size(154, 15);
			this.lblPosition.TabIndex = 29;
			this.lblPosition.Text = "ConfigurationField.Position";
			// 
			// tbPosition
			// 
			this.tbPosition.Location = new System.Drawing.Point(6, 309);
			this.tbPosition.Name = "tbPosition";
			this.tbPosition.Size = new System.Drawing.Size(348, 20);
			this.tbPosition.TabIndex = 28;
			this.tbPosition.Text = "0";
			this.tbPosition.TextChanged += new System.EventHandler(this.TbPosition_TextChanged);
			// 
			// cbType
			// 
			this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbType.FormattingEnabled = true;
			this.cbType.Items.AddRange(new object[] {
            "Types.Byte",
            "Types.Sbyte",
            "Types.Short",
            "Types.Ushort",
            "Types.Int",
            "Types.Uint",
            "Types.Long",
            "Types.Ulong",
            "Types.Float",
            "Types.Double",
            "Types.String",
            "Types.Structure"});
			this.cbType.Location = new System.Drawing.Point(6, 222);
			this.cbType.Name = "cbType";
			this.cbType.Size = new System.Drawing.Size(348, 21);
			this.cbType.TabIndex = 27;
			this.cbType.SelectedIndexChanged += new System.EventHandler(this.CbType_SelectedIndexChanged);
			// 
			// lblType
			// 
			this.lblType.AutoSize = true;
			this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblType.Location = new System.Drawing.Point(6, 204);
			this.lblType.Name = "lblType";
			this.lblType.Size = new System.Drawing.Size(136, 15);
			this.lblType.TabIndex = 26;
			this.lblType.Text = "ConfigurationField.Type";
			// 
			// lblDescription
			// 
			this.lblDescription.AutoSize = true;
			this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblDescription.Location = new System.Drawing.Point(6, 57);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(172, 15);
			this.lblDescription.TabIndex = 24;
			this.lblDescription.Text = "ConfigurationField.Description";
			// 
			// tbDescription
			// 
			this.tbDescription.Location = new System.Drawing.Point(6, 75);
			this.tbDescription.Name = "tbDescription";
			this.tbDescription.Size = new System.Drawing.Size(348, 20);
			this.tbDescription.TabIndex = 23;
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblName.Location = new System.Drawing.Point(6, 16);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(144, 15);
			this.lblName.TabIndex = 22;
			this.lblName.Text = "ConfigurationField.Name";
			// 
			// tbName
			// 
			this.tbName.Location = new System.Drawing.Point(6, 34);
			this.tbName.Name = "tbName";
			this.tbName.Size = new System.Drawing.Size(348, 20);
			this.tbName.TabIndex = 21;
			// 
			// lblInformation
			// 
			this.lblInformation.AutoSize = true;
			this.lblInformation.Location = new System.Drawing.Point(12, 409);
			this.lblInformation.Name = "lblInformation";
			this.lblInformation.Size = new System.Drawing.Size(146, 13);
			this.lblInformation.TabIndex = 15;
			this.lblInformation.Text = "ConfigurationField.Information";
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(247, 383);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(125, 23);
			this.btnSave.TabIndex = 14;
			this.btnSave.Text = "ConfigurationField.Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(12, 383);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(125, 23);
			this.btnCancel.TabIndex = 13;
			this.btnCancel.Text = "ConfigurationField.Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
			// 
			// ConfigurationField
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(384, 431);
			this.Controls.Add(this.lblInformation);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.gbGeleral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "ConfigurationField";
			this.Text = "ConfigurationField.Text";
			this.Load += new System.EventHandler(this.ConfigurationField_Load);
			this.gbGeleral.ResumeLayout(false);
			this.gbGeleral.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbGeleral;
        private System.Windows.Forms.Label lblInformation;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.TextBox tbPosition;
        private System.Windows.Forms.ComboBox cbCommon;
        private System.Windows.Forms.Label lblCommon;
        private System.Windows.Forms.Label lblSequenceType;
        private System.Windows.Forms.ComboBox cbSequenceType;
        private System.Windows.Forms.Label lblValue;
		private System.Windows.Forms.TextBox tbValue;
		private System.Windows.Forms.CheckBox cbArray;
		private System.Windows.Forms.Label lblArrayLength;
		private System.Windows.Forms.TextBox tbArrayLength;
	}
}