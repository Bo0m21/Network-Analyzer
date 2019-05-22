namespace Network_Analyzer
{
    partial class Editor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
            this.msMenu = new System.Windows.Forms.MenuStrip();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpPackets = new System.Windows.Forms.TabPage();
            this.cbAutoScroll = new System.Windows.Forms.CheckBox();
            this.btnUpdatePackets = new System.Windows.Forms.Button();
            this.cbAutoUpdateDataGridView = new System.Windows.Forms.CheckBox();
            this.btnClearPackets = new System.Windows.Forms.Button();
            this.cbTypeEncryptionPackets = new System.Windows.Forms.ComboBox();
            this.cbTypePackets = new System.Windows.Forms.ComboBox();
            this.dgvPackets = new System.Windows.Forms.DataGridView();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PacketType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PacketOpcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PacketName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblInformation = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tpPackets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPackets)).BeginInit();
            this.SuspendLayout();
            // 
            // msMenu
            // 
            this.msMenu.Location = new System.Drawing.Point(0, 0);
            this.msMenu.Name = "msMenu";
            this.msMenu.Size = new System.Drawing.Size(1184, 24);
            this.msMenu.TabIndex = 0;
            this.msMenu.Text = "menuStrip1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpPackets);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(330, 603);
            this.tabControl1.TabIndex = 1;
            // 
            // tpPackets
            // 
            this.tpPackets.BackColor = System.Drawing.SystemColors.Control;
            this.tpPackets.Controls.Add(this.cbAutoScroll);
            this.tpPackets.Controls.Add(this.btnUpdatePackets);
            this.tpPackets.Controls.Add(this.cbAutoUpdateDataGridView);
            this.tpPackets.Controls.Add(this.btnClearPackets);
            this.tpPackets.Controls.Add(this.cbTypeEncryptionPackets);
            this.tpPackets.Controls.Add(this.cbTypePackets);
            this.tpPackets.Controls.Add(this.dgvPackets);
            this.tpPackets.Location = new System.Drawing.Point(4, 22);
            this.tpPackets.Name = "tpPackets";
            this.tpPackets.Padding = new System.Windows.Forms.Padding(3);
            this.tpPackets.Size = new System.Drawing.Size(322, 577);
            this.tpPackets.TabIndex = 0;
            this.tpPackets.Text = "Editor.Packets";
            // 
            // cbAutoScroll
            // 
            this.cbAutoScroll.AutoSize = true;
            this.cbAutoScroll.Location = new System.Drawing.Point(6, 502);
            this.cbAutoScroll.Name = "cbAutoScroll";
            this.cbAutoScroll.Size = new System.Drawing.Size(104, 17);
            this.cbAutoScroll.TabIndex = 21;
            this.cbAutoScroll.Text = "Editor.AutoScroll";
            this.cbAutoScroll.UseVisualStyleBackColor = true;
            // 
            // btnUpdatePackets
            // 
            this.btnUpdatePackets.Location = new System.Drawing.Point(6, 548);
            this.btnUpdatePackets.Name = "btnUpdatePackets";
            this.btnUpdatePackets.Size = new System.Drawing.Size(152, 23);
            this.btnUpdatePackets.TabIndex = 19;
            this.btnUpdatePackets.Text = "Editor.UpdatePackets";
            this.btnUpdatePackets.UseVisualStyleBackColor = true;
            this.btnUpdatePackets.Click += new System.EventHandler(this.BtnUpdatePackets_Click);
            // 
            // cbAutoUpdateDataGridView
            // 
            this.cbAutoUpdateDataGridView.AutoSize = true;
            this.cbAutoUpdateDataGridView.Location = new System.Drawing.Point(6, 525);
            this.cbAutoUpdateDataGridView.Name = "cbAutoUpdateDataGridView";
            this.cbAutoUpdateDataGridView.Size = new System.Drawing.Size(178, 17);
            this.cbAutoUpdateDataGridView.TabIndex = 17;
            this.cbAutoUpdateDataGridView.Text = "Editor.AutoUpdateDataGridView";
            this.cbAutoUpdateDataGridView.UseVisualStyleBackColor = true;
            this.cbAutoUpdateDataGridView.CheckedChanged += new System.EventHandler(this.CbAutoUpdateDataGridView_CheckedChanged);
            // 
            // btnClearPackets
            // 
            this.btnClearPackets.Location = new System.Drawing.Point(164, 548);
            this.btnClearPackets.Name = "btnClearPackets";
            this.btnClearPackets.Size = new System.Drawing.Size(152, 23);
            this.btnClearPackets.TabIndex = 18;
            this.btnClearPackets.Text = "Editor.ClearPackets";
            this.btnClearPackets.UseVisualStyleBackColor = true;
            this.btnClearPackets.Click += new System.EventHandler(this.BtnClearPackets_Click);
            // 
            // cbTypeEncryptionPackets
            // 
            this.cbTypeEncryptionPackets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeEncryptionPackets.FormattingEnabled = true;
            this.cbTypeEncryptionPackets.Items.AddRange(new object[] {
            "Editor.Encrypted",
            "Editor.Decrypted"});
            this.cbTypeEncryptionPackets.Location = new System.Drawing.Point(6, 6);
            this.cbTypeEncryptionPackets.Name = "cbTypeEncryptionPackets";
            this.cbTypeEncryptionPackets.Size = new System.Drawing.Size(137, 21);
            this.cbTypeEncryptionPackets.TabIndex = 13;
            this.cbTypeEncryptionPackets.SelectedIndexChanged += new System.EventHandler(this.CbTypeEncryptionPackets_SelectedIndexChanged);
            // 
            // cbTypePackets
            // 
            this.cbTypePackets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypePackets.FormattingEnabled = true;
            this.cbTypePackets.Items.AddRange(new object[] {
            "Editor.AllPackets",
            "Editor.ClientToServer",
            "Editor.ServerToClient"});
            this.cbTypePackets.Location = new System.Drawing.Point(149, 6);
            this.cbTypePackets.Name = "cbTypePackets";
            this.cbTypePackets.Size = new System.Drawing.Size(167, 21);
            this.cbTypePackets.TabIndex = 12;
            this.cbTypePackets.SelectedIndexChanged += new System.EventHandler(this.CbTypePackets_SelectedIndexChanged);
            // 
            // dgvPackets
            // 
            this.dgvPackets.AllowDrop = true;
            this.dgvPackets.AllowUserToAddRows = false;
            this.dgvPackets.AllowUserToDeleteRows = false;
            this.dgvPackets.AllowUserToOrderColumns = true;
            this.dgvPackets.AllowUserToResizeColumns = false;
            this.dgvPackets.AllowUserToResizeRows = false;
            this.dgvPackets.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPackets.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPackets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPackets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number,
            this.Id,
            this.PacketType,
            this.PacketOpcode,
            this.PacketName});
            this.dgvPackets.Location = new System.Drawing.Point(6, 33);
            this.dgvPackets.Name = "dgvPackets";
            this.dgvPackets.ReadOnly = true;
            this.dgvPackets.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvPackets.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPackets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPackets.Size = new System.Drawing.Size(310, 463);
            this.dgvPackets.TabIndex = 3;
            this.dgvPackets.SelectionChanged += new System.EventHandler(this.DgvPackets_SelectionChanged);
            // 
            // Number
            // 
            this.Number.HeaderText = "№";
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
            this.Number.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Number.Width = 50;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Id.Visible = false;
            // 
            // PacketType
            // 
            this.PacketType.HeaderText = "Editor.PacketType";
            this.PacketType.Name = "PacketType";
            this.PacketType.ReadOnly = true;
            this.PacketType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PacketType.Width = 80;
            // 
            // PacketOpcode
            // 
            this.PacketOpcode.HeaderText = "Editor.PacketOpcode";
            this.PacketOpcode.Name = "PacketOpcode";
            this.PacketOpcode.ReadOnly = true;
            this.PacketOpcode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PacketOpcode.Visible = false;
            this.PacketOpcode.Width = 160;
            // 
            // PacketName
            // 
            this.PacketName.HeaderText = "Editor.PacketName";
            this.PacketName.Name = "PacketName";
            this.PacketName.ReadOnly = true;
            this.PacketName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PacketName.Width = 160;
            // 
            // lblInformation
            // 
            this.lblInformation.AutoSize = true;
            this.lblInformation.Location = new System.Drawing.Point(12, 633);
            this.lblInformation.Name = "lblInformation";
            this.lblInformation.Size = new System.Drawing.Size(89, 13);
            this.lblInformation.TabIndex = 12;
            this.lblInformation.Text = "Editor.Information";
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 655);
            this.Controls.Add(this.lblInformation);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.msMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMenu;
            this.Name = "Editor";
            this.Text = "Editor.Text";
            this.Load += new System.EventHandler(this.Editor_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpPackets.ResumeLayout(false);
            this.tpPackets.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPackets)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpPackets;
        private System.Windows.Forms.DataGridView dgvPackets;
        private System.Windows.Forms.CheckBox cbAutoScroll;
        private System.Windows.Forms.Button btnUpdatePackets;
        private System.Windows.Forms.CheckBox cbAutoUpdateDataGridView;
        private System.Windows.Forms.Button btnClearPackets;
        private System.Windows.Forms.ComboBox cbTypeEncryptionPackets;
        private System.Windows.Forms.ComboBox cbTypePackets;
        private System.Windows.Forms.Label lblInformation;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn PacketType;
        private System.Windows.Forms.DataGridViewTextBoxColumn PacketOpcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn PacketName;
    }
}