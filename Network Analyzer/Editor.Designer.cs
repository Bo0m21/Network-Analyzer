using HexBoxForm;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
            this.msMenu = new System.Windows.Forms.MenuStrip();
            this.hexEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hexEditorEncodingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.encodingAsciiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.encodingUnicodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.encodingUTF8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.encodingWindows1251ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decryptorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDecryptorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unloadDecryptorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.PacketName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblInformation = new System.Windows.Forms.Label();
            this.gbHexEditor = new System.Windows.Forms.GroupBox();
            this.btnSearchClear = new System.Windows.Forms.Button();
            this.btnSearchStart = new System.Windows.Forms.Button();
            this.cbSearchType = new System.Windows.Forms.ComboBox();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.hbHexEditor = new HexBoxForm.HexBox();
            this.tpPacketInformation = new System.Windows.Forms.TabPage();
            this.gbDataTypes = new System.Windows.Forms.GroupBox();
            this.lblDoubleType = new System.Windows.Forms.Label();
            this.lblFloatType = new System.Windows.Forms.Label();
            this.lblUlongType = new System.Windows.Forms.Label();
            this.lblLongType = new System.Windows.Forms.Label();
            this.lblUintType = new System.Windows.Forms.Label();
            this.lblIntType = new System.Windows.Forms.Label();
            this.lblUshortType = new System.Windows.Forms.Label();
            this.lblShortType = new System.Windows.Forms.Label();
            this.lblSbyteType = new System.Windows.Forms.Label();
            this.lblByteType = new System.Windows.Forms.Label();
            this.cbSequenceType = new System.Windows.Forms.ComboBox();
            this.gbGeneralInformation = new System.Windows.Forms.GroupBox();
            this.lblAllPackets = new System.Windows.Forms.Label();
            this.lblSelectedLength = new System.Windows.Forms.Label();
            this.lblLengthPacket = new System.Windows.Forms.Label();
            this.lblSelectedIndex = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tpConfiguration = new System.Windows.Forms.TabPage();
            this.btnDeleteFieldConfiguration = new System.Windows.Forms.Button();
            this.btnAddFieldConfiguration = new System.Windows.Forms.Button();
            this.dgvFieldsConfiguration = new System.Windows.Forms.DataGridView();
            this.ConfigurationPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConfigurationType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ConfigurationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbConfigurationPacketDescription = new System.Windows.Forms.TextBox();
            this.lblConfigurationPacketDescription = new System.Windows.Forms.Label();
            this.lblConfigurationName = new System.Windows.Forms.Label();
            this.tbConfigurationPacketName = new System.Windows.Forms.TextBox();
            this.msMenu.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpPackets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPackets)).BeginInit();
            this.gbHexEditor.SuspendLayout();
            this.tpPacketInformation.SuspendLayout();
            this.gbDataTypes.SuspendLayout();
            this.gbGeneralInformation.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tpConfiguration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFieldsConfiguration)).BeginInit();
            this.SuspendLayout();
            // 
            // msMenu
            // 
            this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hexEditorToolStripMenuItem,
            this.decryptorToolStripMenuItem});
            this.msMenu.Location = new System.Drawing.Point(0, 0);
            this.msMenu.Name = "msMenu";
            this.msMenu.Size = new System.Drawing.Size(1290, 24);
            this.msMenu.TabIndex = 0;
            this.msMenu.Text = "menuStrip1";
            // 
            // hexEditorToolStripMenuItem
            // 
            this.hexEditorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hexEditorEncodingToolStripMenuItem});
            this.hexEditorToolStripMenuItem.Name = "hexEditorToolStripMenuItem";
            this.hexEditorToolStripMenuItem.Size = new System.Drawing.Size(105, 20);
            this.hexEditorToolStripMenuItem.Text = "Editor.HexEditor";
            // 
            // hexEditorEncodingToolStripMenuItem
            // 
            this.hexEditorEncodingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.encodingAsciiToolStripMenuItem,
            this.encodingUnicodeToolStripMenuItem,
            this.encodingUTF8ToolStripMenuItem,
            this.encodingWindows1251ToolStripMenuItem});
            this.hexEditorEncodingToolStripMenuItem.Name = "hexEditorEncodingToolStripMenuItem";
            this.hexEditorEncodingToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.hexEditorEncodingToolStripMenuItem.Text = "Editor.HexEditorEncoding";
            // 
            // encodingAsciiToolStripMenuItem
            // 
            this.encodingAsciiToolStripMenuItem.Name = "encodingAsciiToolStripMenuItem";
            this.encodingAsciiToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.encodingAsciiToolStripMenuItem.Text = "Editor.EncodingAscii";
            this.encodingAsciiToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.encodingAsciiToolStripMenuItem.Click += new System.EventHandler(this.EncodingInstall_Click);
            // 
            // encodingUnicodeToolStripMenuItem
            // 
            this.encodingUnicodeToolStripMenuItem.Name = "encodingUnicodeToolStripMenuItem";
            this.encodingUnicodeToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.encodingUnicodeToolStripMenuItem.Text = "Editor.EncodingUnicode";
            this.encodingUnicodeToolStripMenuItem.Click += new System.EventHandler(this.EncodingInstall_Click);
            // 
            // encodingUTF8ToolStripMenuItem
            // 
            this.encodingUTF8ToolStripMenuItem.Name = "encodingUTF8ToolStripMenuItem";
            this.encodingUTF8ToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.encodingUTF8ToolStripMenuItem.Text = "Editor.EncodingUTF8";
            this.encodingUTF8ToolStripMenuItem.Click += new System.EventHandler(this.EncodingInstall_Click);
            // 
            // encodingWindows1251ToolStripMenuItem
            // 
            this.encodingWindows1251ToolStripMenuItem.Name = "encodingWindows1251ToolStripMenuItem";
            this.encodingWindows1251ToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.encodingWindows1251ToolStripMenuItem.Text = "Editor.EncodingWindows1251";
            this.encodingWindows1251ToolStripMenuItem.Click += new System.EventHandler(this.EncodingInstall_Click);
            // 
            // decryptorToolStripMenuItem
            // 
            this.decryptorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadDecryptorToolStripMenuItem,
            this.unloadDecryptorToolStripMenuItem});
            this.decryptorToolStripMenuItem.Name = "decryptorToolStripMenuItem";
            this.decryptorToolStripMenuItem.Size = new System.Drawing.Size(105, 20);
            this.decryptorToolStripMenuItem.Text = "Editor.Decryptor";
            // 
            // loadDecryptorToolStripMenuItem
            // 
            this.loadDecryptorToolStripMenuItem.Name = "loadDecryptorToolStripMenuItem";
            this.loadDecryptorToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.loadDecryptorToolStripMenuItem.Text = "Editor.LoadDecryptor";
            this.loadDecryptorToolStripMenuItem.Click += new System.EventHandler(this.LoadDecryptorToolStripMenuItem_Click);
            // 
            // unloadDecryptorToolStripMenuItem
            // 
            this.unloadDecryptorToolStripMenuItem.Name = "unloadDecryptorToolStripMenuItem";
            this.unloadDecryptorToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.unloadDecryptorToolStripMenuItem.Text = "Editor.UnloadDecryptor";
            this.unloadDecryptorToolStripMenuItem.Click += new System.EventHandler(this.UnloadDecryptorToolStripMenuItem_Click);
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
            "Editor.SelectEncrypted",
            "Editor.SelectDecrypted"});
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
            "Editor.SelectAllPackets",
            "Editor.SelectClientToServer",
            "Editor.SelectServerToClient"});
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
            // gbHexEditor
            // 
            this.gbHexEditor.Controls.Add(this.btnSearchClear);
            this.gbHexEditor.Controls.Add(this.btnSearchStart);
            this.gbHexEditor.Controls.Add(this.cbSearchType);
            this.gbHexEditor.Controls.Add(this.tbSearch);
            this.gbHexEditor.Controls.Add(this.hbHexEditor);
            this.gbHexEditor.Location = new System.Drawing.Point(348, 27);
            this.gbHexEditor.Name = "gbHexEditor";
            this.gbHexEditor.Size = new System.Drawing.Size(574, 603);
            this.gbHexEditor.TabIndex = 13;
            this.gbHexEditor.TabStop = false;
            this.gbHexEditor.Text = "Editor.HexEditor";
            // 
            // btnSearchClear
            // 
            this.btnSearchClear.Location = new System.Drawing.Point(492, 574);
            this.btnSearchClear.Name = "btnSearchClear";
            this.btnSearchClear.Size = new System.Drawing.Size(75, 23);
            this.btnSearchClear.TabIndex = 14;
            this.btnSearchClear.Text = "Editor.SearchClear";
            this.btnSearchClear.UseVisualStyleBackColor = true;
            this.btnSearchClear.Click += new System.EventHandler(this.BtnSearchClear_Click);
            // 
            // btnSearchStart
            // 
            this.btnSearchStart.Location = new System.Drawing.Point(412, 574);
            this.btnSearchStart.Name = "btnSearchStart";
            this.btnSearchStart.Size = new System.Drawing.Size(75, 23);
            this.btnSearchStart.TabIndex = 12;
            this.btnSearchStart.Text = "Editor.SearchStart";
            this.btnSearchStart.UseVisualStyleBackColor = true;
            this.btnSearchStart.Click += new System.EventHandler(this.BtnSearchStart_Click);
            // 
            // cbSearchType
            // 
            this.cbSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearchType.FormattingEnabled = true;
            this.cbSearchType.Items.AddRange(new object[] {
            "Editor.SearchOpcode",
            "Editor.SearchBytes"});
            this.cbSearchType.Location = new System.Drawing.Point(6, 576);
            this.cbSearchType.Name = "cbSearchType";
            this.cbSearchType.Size = new System.Drawing.Size(121, 21);
            this.cbSearchType.TabIndex = 13;
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(133, 576);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(273, 20);
            this.tbSearch.TabIndex = 11;
            // 
            // hbHexEditor
            // 
            this.hbHexEditor.AllowDrop = true;
            this.hbHexEditor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.hbHexEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hbHexEditor.ColumnInfoVisible = true;
            this.hbHexEditor.Font = new System.Drawing.Font("Consolas", 9F);
            this.hbHexEditor.HexCasing = HexBoxForm.HexCasing.Lower;
            this.hbHexEditor.LineInfoVisible = true;
            this.hbHexEditor.Location = new System.Drawing.Point(7, 19);
            this.hbHexEditor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.hbHexEditor.Name = "hbHexEditor";
            this.hbHexEditor.ReadOnly = true;
            this.hbHexEditor.SelectionBackColor = System.Drawing.Color.Coral;
            this.hbHexEditor.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hbHexEditor.Size = new System.Drawing.Size(560, 549);
            this.hbHexEditor.StringViewVisible = true;
            this.hbHexEditor.TabIndex = 9;
            this.hbHexEditor.UseFixedBytesPerLine = true;
            this.hbHexEditor.VScrollBarVisible = true;
            this.hbHexEditor.SelectionStartChanged += new System.EventHandler(this.HbHexEditor_SelectionStartChanged_1);
            this.hbHexEditor.SelectionLengthChanged += new System.EventHandler(this.HbHexEditor_SelectionLengthChanged_1);
            this.hbHexEditor.Paint += new System.Windows.Forms.PaintEventHandler(this.HbHexEditor_Paint);
            // 
            // tpPacketInformation
            // 
            this.tpPacketInformation.BackColor = System.Drawing.SystemColors.Control;
            this.tpPacketInformation.Controls.Add(this.gbDataTypes);
            this.tpPacketInformation.Controls.Add(this.cbSequenceType);
            this.tpPacketInformation.Controls.Add(this.gbGeneralInformation);
            this.tpPacketInformation.Location = new System.Drawing.Point(4, 22);
            this.tpPacketInformation.Name = "tpPacketInformation";
            this.tpPacketInformation.Padding = new System.Windows.Forms.Padding(3);
            this.tpPacketInformation.Size = new System.Drawing.Size(342, 577);
            this.tpPacketInformation.TabIndex = 0;
            this.tpPacketInformation.Text = "Editor.PacketInformation";
            // 
            // gbDataTypes
            // 
            this.gbDataTypes.Controls.Add(this.lblDoubleType);
            this.gbDataTypes.Controls.Add(this.lblFloatType);
            this.gbDataTypes.Controls.Add(this.lblUlongType);
            this.gbDataTypes.Controls.Add(this.lblLongType);
            this.gbDataTypes.Controls.Add(this.lblUintType);
            this.gbDataTypes.Controls.Add(this.lblIntType);
            this.gbDataTypes.Controls.Add(this.lblUshortType);
            this.gbDataTypes.Controls.Add(this.lblShortType);
            this.gbDataTypes.Controls.Add(this.lblSbyteType);
            this.gbDataTypes.Controls.Add(this.lblByteType);
            this.gbDataTypes.Location = new System.Drawing.Point(6, 88);
            this.gbDataTypes.Name = "gbDataTypes";
            this.gbDataTypes.Size = new System.Drawing.Size(330, 94);
            this.gbDataTypes.TabIndex = 39;
            this.gbDataTypes.TabStop = false;
            this.gbDataTypes.Text = "Editor.DataTypes";
            // 
            // lblDoubleType
            // 
            this.lblDoubleType.AutoSize = true;
            this.lblDoubleType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDoubleType.Location = new System.Drawing.Point(166, 76);
            this.lblDoubleType.Name = "lblDoubleType";
            this.lblDoubleType.Size = new System.Drawing.Size(108, 15);
            this.lblDoubleType.TabIndex = 23;
            this.lblDoubleType.Text = "Editor.DoubleType";
            // 
            // lblFloatType
            // 
            this.lblFloatType.AutoSize = true;
            this.lblFloatType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFloatType.Location = new System.Drawing.Point(6, 76);
            this.lblFloatType.Name = "lblFloatType";
            this.lblFloatType.Size = new System.Drawing.Size(95, 15);
            this.lblFloatType.TabIndex = 22;
            this.lblFloatType.Text = "Editor.FloatType";
            // 
            // lblUlongType
            // 
            this.lblUlongType.AutoSize = true;
            this.lblUlongType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblUlongType.Location = new System.Drawing.Point(166, 61);
            this.lblUlongType.Name = "lblUlongType";
            this.lblUlongType.Size = new System.Drawing.Size(101, 15);
            this.lblUlongType.TabIndex = 21;
            this.lblUlongType.Text = "Editor.UlongType";
            // 
            // lblLongType
            // 
            this.lblLongType.AutoSize = true;
            this.lblLongType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLongType.Location = new System.Drawing.Point(6, 61);
            this.lblLongType.Name = "lblLongType";
            this.lblLongType.Size = new System.Drawing.Size(96, 15);
            this.lblLongType.TabIndex = 20;
            this.lblLongType.Text = "Editor.LongType";
            // 
            // lblUintType
            // 
            this.lblUintType.AutoSize = true;
            this.lblUintType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblUintType.Location = new System.Drawing.Point(166, 46);
            this.lblUintType.Name = "lblUintType";
            this.lblUintType.Size = new System.Drawing.Size(90, 15);
            this.lblUintType.TabIndex = 19;
            this.lblUintType.Text = "Editor.UintType";
            // 
            // lblIntType
            // 
            this.lblIntType.AutoSize = true;
            this.lblIntType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblIntType.Location = new System.Drawing.Point(6, 46);
            this.lblIntType.Name = "lblIntType";
            this.lblIntType.Size = new System.Drawing.Size(81, 15);
            this.lblIntType.TabIndex = 18;
            this.lblIntType.Text = "Editor.IntType";
            // 
            // lblUshortType
            // 
            this.lblUshortType.AutoSize = true;
            this.lblUshortType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblUshortType.Location = new System.Drawing.Point(166, 31);
            this.lblUshortType.Name = "lblUshortType";
            this.lblUshortType.Size = new System.Drawing.Size(104, 15);
            this.lblUshortType.TabIndex = 17;
            this.lblUshortType.Text = "Editor.UshortType";
            // 
            // lblShortType
            // 
            this.lblShortType.AutoSize = true;
            this.lblShortType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblShortType.Location = new System.Drawing.Point(6, 31);
            this.lblShortType.Name = "lblShortType";
            this.lblShortType.Size = new System.Drawing.Size(97, 15);
            this.lblShortType.TabIndex = 16;
            this.lblShortType.Text = "Editor.ShortType";
            // 
            // lblSbyteType
            // 
            this.lblSbyteType.AutoSize = true;
            this.lblSbyteType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSbyteType.Location = new System.Drawing.Point(166, 16);
            this.lblSbyteType.Name = "lblSbyteType";
            this.lblSbyteType.Size = new System.Drawing.Size(98, 15);
            this.lblSbyteType.TabIndex = 15;
            this.lblSbyteType.Text = "Editor.SbyteType";
            // 
            // lblByteType
            // 
            this.lblByteType.AutoSize = true;
            this.lblByteType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblByteType.Location = new System.Drawing.Point(6, 16);
            this.lblByteType.Name = "lblByteType";
            this.lblByteType.Size = new System.Drawing.Size(91, 15);
            this.lblByteType.TabIndex = 14;
            this.lblByteType.Text = "Editor.ByteType";
            // 
            // cbSequenceType
            // 
            this.cbSequenceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSequenceType.FormattingEnabled = true;
            this.cbSequenceType.Items.AddRange(new object[] {
            "Little endian",
            "Big endian"});
            this.cbSequenceType.Location = new System.Drawing.Point(6, 61);
            this.cbSequenceType.Name = "cbSequenceType";
            this.cbSequenceType.Size = new System.Drawing.Size(330, 21);
            this.cbSequenceType.TabIndex = 39;
            this.cbSequenceType.SelectedIndexChanged += new System.EventHandler(this.CbSequenceType_SelectedIndexChanged_1);
            // 
            // gbGeneralInformation
            // 
            this.gbGeneralInformation.Controls.Add(this.lblAllPackets);
            this.gbGeneralInformation.Controls.Add(this.lblSelectedLength);
            this.gbGeneralInformation.Controls.Add(this.lblLengthPacket);
            this.gbGeneralInformation.Controls.Add(this.lblSelectedIndex);
            this.gbGeneralInformation.Location = new System.Drawing.Point(6, 6);
            this.gbGeneralInformation.Name = "gbGeneralInformation";
            this.gbGeneralInformation.Size = new System.Drawing.Size(330, 49);
            this.gbGeneralInformation.TabIndex = 38;
            this.gbGeneralInformation.TabStop = false;
            this.gbGeneralInformation.Text = "Editor.GeneralInformation";
            // 
            // lblAllPackets
            // 
            this.lblAllPackets.AutoSize = true;
            this.lblAllPackets.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAllPackets.Location = new System.Drawing.Point(6, 16);
            this.lblAllPackets.Name = "lblAllPackets";
            this.lblAllPackets.Size = new System.Drawing.Size(98, 15);
            this.lblAllPackets.TabIndex = 14;
            this.lblAllPackets.Text = "Editor.AllPackets";
            // 
            // lblSelectedLength
            // 
            this.lblSelectedLength.AutoSize = true;
            this.lblSelectedLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSelectedLength.Location = new System.Drawing.Point(166, 31);
            this.lblSelectedLength.Name = "lblSelectedLength";
            this.lblSelectedLength.Size = new System.Drawing.Size(128, 15);
            this.lblSelectedLength.TabIndex = 37;
            this.lblSelectedLength.Text = "Editor.SelectedLength";
            // 
            // lblLengthPacket
            // 
            this.lblLengthPacket.AutoSize = true;
            this.lblLengthPacket.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLengthPacket.Location = new System.Drawing.Point(6, 31);
            this.lblLengthPacket.Name = "lblLengthPacket";
            this.lblLengthPacket.Size = new System.Drawing.Size(117, 15);
            this.lblLengthPacket.TabIndex = 15;
            this.lblLengthPacket.Text = "Editor.LengthPacket";
            // 
            // lblSelectedIndex
            // 
            this.lblSelectedIndex.AutoSize = true;
            this.lblSelectedIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSelectedIndex.Location = new System.Drawing.Point(166, 16);
            this.lblSelectedIndex.Name = "lblSelectedIndex";
            this.lblSelectedIndex.Size = new System.Drawing.Size(120, 15);
            this.lblSelectedIndex.TabIndex = 35;
            this.lblSelectedIndex.Text = "Editor.SelectedIndex";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tpPacketInformation);
            this.tabControl2.Controls.Add(this.tpConfiguration);
            this.tabControl2.Location = new System.Drawing.Point(928, 27);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(350, 603);
            this.tabControl2.TabIndex = 16;
            // 
            // tpConfiguration
            // 
            this.tpConfiguration.BackColor = System.Drawing.SystemColors.Control;
            this.tpConfiguration.Controls.Add(this.btnDeleteFieldConfiguration);
            this.tpConfiguration.Controls.Add(this.btnAddFieldConfiguration);
            this.tpConfiguration.Controls.Add(this.dgvFieldsConfiguration);
            this.tpConfiguration.Controls.Add(this.tbConfigurationPacketDescription);
            this.tpConfiguration.Controls.Add(this.lblConfigurationPacketDescription);
            this.tpConfiguration.Controls.Add(this.lblConfigurationName);
            this.tpConfiguration.Controls.Add(this.tbConfigurationPacketName);
            this.tpConfiguration.Location = new System.Drawing.Point(4, 22);
            this.tpConfiguration.Name = "tpConfiguration";
            this.tpConfiguration.Padding = new System.Windows.Forms.Padding(3);
            this.tpConfiguration.Size = new System.Drawing.Size(342, 577);
            this.tpConfiguration.TabIndex = 1;
            this.tpConfiguration.Text = "Editor.Configuration";
            // 
            // btnDeleteFieldConfiguration
            // 
            this.btnDeleteFieldConfiguration.Location = new System.Drawing.Point(184, 548);
            this.btnDeleteFieldConfiguration.Name = "btnDeleteFieldConfiguration";
            this.btnDeleteFieldConfiguration.Size = new System.Drawing.Size(152, 23);
            this.btnDeleteFieldConfiguration.TabIndex = 23;
            this.btnDeleteFieldConfiguration.Text = "Editor.DeleteFieldConfiguration";
            this.btnDeleteFieldConfiguration.UseVisualStyleBackColor = true;
            // 
            // btnAddFieldConfiguration
            // 
            this.btnAddFieldConfiguration.Location = new System.Drawing.Point(6, 548);
            this.btnAddFieldConfiguration.Name = "btnAddFieldConfiguration";
            this.btnAddFieldConfiguration.Size = new System.Drawing.Size(152, 23);
            this.btnAddFieldConfiguration.TabIndex = 22;
            this.btnAddFieldConfiguration.Text = "Editor.AddFieldConfiguration";
            this.btnAddFieldConfiguration.UseVisualStyleBackColor = true;
            // 
            // dgvFieldsConfiguration
            // 
            this.dgvFieldsConfiguration.AllowDrop = true;
            this.dgvFieldsConfiguration.AllowUserToAddRows = false;
            this.dgvFieldsConfiguration.AllowUserToDeleteRows = false;
            this.dgvFieldsConfiguration.AllowUserToOrderColumns = true;
            this.dgvFieldsConfiguration.AllowUserToResizeColumns = false;
            this.dgvFieldsConfiguration.AllowUserToResizeRows = false;
            this.dgvFieldsConfiguration.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFieldsConfiguration.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvFieldsConfiguration.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFieldsConfiguration.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ConfigurationPosition,
            this.ConfigurationType,
            this.ConfigurationName});
            this.dgvFieldsConfiguration.Location = new System.Drawing.Point(6, 117);
            this.dgvFieldsConfiguration.Name = "dgvFieldsConfiguration";
            this.dgvFieldsConfiguration.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvFieldsConfiguration.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvFieldsConfiguration.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFieldsConfiguration.Size = new System.Drawing.Size(330, 295);
            this.dgvFieldsConfiguration.TabIndex = 22;
            // 
            // ConfigurationPosition
            // 
            this.ConfigurationPosition.HeaderText = "Editor.ConfigurationPosition";
            this.ConfigurationPosition.Name = "ConfigurationPosition";
            this.ConfigurationPosition.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ConfigurationPosition.Width = 75;
            // 
            // ConfigurationType
            // 
            this.ConfigurationType.HeaderText = "Editor.ConfigurationType";
            this.ConfigurationType.Name = "ConfigurationType";
            this.ConfigurationType.Width = 75;
            // 
            // ConfigurationName
            // 
            this.ConfigurationName.HeaderText = "Editor.ConfigurationName";
            this.ConfigurationName.Name = "ConfigurationName";
            this.ConfigurationName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ConfigurationName.Width = 150;
            // 
            // tbConfigurationPacketDescription
            // 
            this.tbConfigurationPacketDescription.Location = new System.Drawing.Point(6, 66);
            this.tbConfigurationPacketDescription.Multiline = true;
            this.tbConfigurationPacketDescription.Name = "tbConfigurationPacketDescription";
            this.tbConfigurationPacketDescription.Size = new System.Drawing.Size(330, 45);
            this.tbConfigurationPacketDescription.TabIndex = 22;
            // 
            // lblConfigurationPacketDescription
            // 
            this.lblConfigurationPacketDescription.AutoSize = true;
            this.lblConfigurationPacketDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblConfigurationPacketDescription.Location = new System.Drawing.Point(6, 48);
            this.lblConfigurationPacketDescription.Name = "lblConfigurationPacketDescription";
            this.lblConfigurationPacketDescription.Size = new System.Drawing.Size(214, 15);
            this.lblConfigurationPacketDescription.TabIndex = 21;
            this.lblConfigurationPacketDescription.Text = "Editor.ConfigurationPacketDescription";
            // 
            // lblConfigurationName
            // 
            this.lblConfigurationName.AutoSize = true;
            this.lblConfigurationName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblConfigurationName.Location = new System.Drawing.Point(6, 7);
            this.lblConfigurationName.Name = "lblConfigurationName";
            this.lblConfigurationName.Size = new System.Drawing.Size(186, 15);
            this.lblConfigurationName.TabIndex = 20;
            this.lblConfigurationName.Text = "Editor.ConfigurationPacketName";
            // 
            // tbConfigurationPacketName
            // 
            this.tbConfigurationPacketName.Location = new System.Drawing.Point(6, 25);
            this.tbConfigurationPacketName.Name = "tbConfigurationPacketName";
            this.tbConfigurationPacketName.Size = new System.Drawing.Size(330, 20);
            this.tbConfigurationPacketName.TabIndex = 19;
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1290, 655);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.gbHexEditor);
            this.Controls.Add(this.lblInformation);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.msMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMenu;
            this.Name = "Editor";
            this.Text = "Editor.Text";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Editor_FormClosing);
            this.Load += new System.EventHandler(this.Editor_Load);
            this.msMenu.ResumeLayout(false);
            this.msMenu.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tpPackets.ResumeLayout(false);
            this.tpPackets.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPackets)).EndInit();
            this.gbHexEditor.ResumeLayout(false);
            this.gbHexEditor.PerformLayout();
            this.tpPacketInformation.ResumeLayout(false);
            this.gbDataTypes.ResumeLayout(false);
            this.gbDataTypes.PerformLayout();
            this.gbGeneralInformation.ResumeLayout(false);
            this.gbGeneralInformation.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tpConfiguration.ResumeLayout(false);
            this.tpConfiguration.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFieldsConfiguration)).EndInit();
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
        private System.Windows.Forms.GroupBox gbHexEditor;
        private HexBox hbHexEditor;
        private System.Windows.Forms.Button btnSearchClear;
        private System.Windows.Forms.Button btnSearchStart;
        private System.Windows.Forms.ComboBox cbSearchType;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn PacketName;
		private System.Windows.Forms.ToolStripMenuItem hexEditorToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem decryptorToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem hexEditorEncodingToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem encodingAsciiToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem encodingUnicodeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem encodingUTF8ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem encodingWindows1251ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadDecryptorToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem unloadDecryptorToolStripMenuItem;
		private System.Windows.Forms.TabPage tpPacketInformation;
		private System.Windows.Forms.GroupBox gbGeneralInformation;
		private System.Windows.Forms.Label lblAllPackets;
		private System.Windows.Forms.Label lblSelectedLength;
		private System.Windows.Forms.Label lblLengthPacket;
		private System.Windows.Forms.Label lblSelectedIndex;
		private System.Windows.Forms.TabControl tabControl2;
		private System.Windows.Forms.ComboBox cbSequenceType;
		private System.Windows.Forms.GroupBox gbDataTypes;
		private System.Windows.Forms.Label lblByteType;
		private System.Windows.Forms.Label lblSbyteType;
		private System.Windows.Forms.Label lblShortType;
		private System.Windows.Forms.Label lblUshortType;
		private System.Windows.Forms.Label lblUintType;
		private System.Windows.Forms.Label lblIntType;
		private System.Windows.Forms.Label lblUlongType;
		private System.Windows.Forms.Label lblLongType;
		private System.Windows.Forms.Label lblDoubleType;
		private System.Windows.Forms.Label lblFloatType;
		private System.Windows.Forms.TabPage tpConfiguration;
		private System.Windows.Forms.Label lblConfigurationName;
		private System.Windows.Forms.TextBox tbConfigurationPacketName;
		private System.Windows.Forms.TextBox tbConfigurationPacketDescription;
		private System.Windows.Forms.Label lblConfigurationPacketDescription;
		private System.Windows.Forms.DataGridView dgvFieldsConfiguration;
		private System.Windows.Forms.DataGridViewTextBoxColumn ConfigurationPosition;
		private System.Windows.Forms.DataGridViewComboBoxColumn ConfigurationType;
		private System.Windows.Forms.DataGridViewTextBoxColumn ConfigurationName;
		private System.Windows.Forms.Button btnDeleteFieldConfiguration;
		private System.Windows.Forms.Button btnAddFieldConfiguration;
	}
}