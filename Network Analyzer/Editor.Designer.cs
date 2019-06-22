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
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.btnStructureDouble = new System.Windows.Forms.Button();
            this.btnFieldDouble = new System.Windows.Forms.Button();
            this.tbDouble = new System.Windows.Forms.TextBox();
            this.btnStructureUlong = new System.Windows.Forms.Button();
            this.btnFieldUlong = new System.Windows.Forms.Button();
            this.tbUlong = new System.Windows.Forms.TextBox();
            this.btnStructureUint = new System.Windows.Forms.Button();
            this.btnFieldUint = new System.Windows.Forms.Button();
            this.tbUint = new System.Windows.Forms.TextBox();
            this.btnStructureUshort = new System.Windows.Forms.Button();
            this.btnFieldUshort = new System.Windows.Forms.Button();
            this.tbUshort = new System.Windows.Forms.TextBox();
            this.btnStructureSbyte = new System.Windows.Forms.Button();
            this.btnFieldSbyte = new System.Windows.Forms.Button();
            this.tbSbyte = new System.Windows.Forms.TextBox();
            this.btnStructureFloat = new System.Windows.Forms.Button();
            this.btnFieldFloat = new System.Windows.Forms.Button();
            this.tbFloat = new System.Windows.Forms.TextBox();
            this.btnStructureLong = new System.Windows.Forms.Button();
            this.btnFieldLong = new System.Windows.Forms.Button();
            this.tbLong = new System.Windows.Forms.TextBox();
            this.btnStructureInt = new System.Windows.Forms.Button();
            this.btnFieldInt = new System.Windows.Forms.Button();
            this.tbInt = new System.Windows.Forms.TextBox();
            this.btnStructureShort = new System.Windows.Forms.Button();
            this.btnFieldShort = new System.Windows.Forms.Button();
            this.tbShort = new System.Windows.Forms.TextBox();
            this.btnStructureByte = new System.Windows.Forms.Button();
            this.btnFieldByte = new System.Windows.Forms.Button();
            this.tbByte = new System.Windows.Forms.TextBox();
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
            this.btnDeleteConfigurationField = new System.Windows.Forms.Button();
            this.btnAddConfigurationField = new System.Windows.Forms.Button();
            this.dgvConfigurationFields = new System.Windows.Forms.DataGridView();
            this.tbConfigurationPacketDescription = new System.Windows.Forms.TextBox();
            this.lblConfigurationPacketDescription = new System.Windows.Forms.Label();
            this.lblConfigurationName = new System.Windows.Forms.Label();
            this.tbConfigurationPacketName = new System.Windows.Forms.TextBox();
            this.ConfigurationPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConfigurationType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConfigurationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConfigurationValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvConfigurationFields)).BeginInit();
            this.SuspendLayout();
            // 
            // msMenu
            // 
            this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hexEditorToolStripMenuItem,
            this.decryptorToolStripMenuItem,
            this.configurationToolStripMenuItem});
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
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadConfigurationToolStripMenuItem,
            this.saveConfigurationToolStripMenuItem,
            this.createConfigurationToolStripMenuItem});
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(127, 20);
            this.configurationToolStripMenuItem.Text = "Editor.Configuration";
            // 
            // loadConfigurationToolStripMenuItem
            // 
            this.loadConfigurationToolStripMenuItem.Name = "loadConfigurationToolStripMenuItem";
            this.loadConfigurationToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.loadConfigurationToolStripMenuItem.Text = "Editor.LoadConfiguration";
            this.loadConfigurationToolStripMenuItem.Click += new System.EventHandler(this.LoadConfigurationToolStripMenuItem_Click);
            // 
            // saveConfigurationToolStripMenuItem
            // 
            this.saveConfigurationToolStripMenuItem.Name = "saveConfigurationToolStripMenuItem";
            this.saveConfigurationToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.saveConfigurationToolStripMenuItem.Text = "Editor.SaveConfiguration";
            this.saveConfigurationToolStripMenuItem.Click += new System.EventHandler(this.SaveConfigurationToolStripMenuItem_Click);
            // 
            // createConfigurationToolStripMenuItem
            // 
            this.createConfigurationToolStripMenuItem.Name = "createConfigurationToolStripMenuItem";
            this.createConfigurationToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.createConfigurationToolStripMenuItem.Text = "Editor.CreateConfiguration";
            this.createConfigurationToolStripMenuItem.Click += new System.EventHandler(this.CreateConfigurationToolStripMenuItem_Click);
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
            this.hbHexEditor.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hbHexEditor.Size = new System.Drawing.Size(560, 549);
            this.hbHexEditor.StringViewVisible = true;
            this.hbHexEditor.TabIndex = 9;
            this.hbHexEditor.UseFixedBytesPerLine = true;
            this.hbHexEditor.VScrollBarVisible = true;
            this.hbHexEditor.SelectionStartChanged += new System.EventHandler(this.HbHexEditor_SelectionStartChanged);
            this.hbHexEditor.SelectionLengthChanged += new System.EventHandler(this.HbHexEditor_SelectionLengthChanged);
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
            this.gbDataTypes.Controls.Add(this.btnStructureDouble);
            this.gbDataTypes.Controls.Add(this.btnFieldDouble);
            this.gbDataTypes.Controls.Add(this.tbDouble);
            this.gbDataTypes.Controls.Add(this.btnStructureUlong);
            this.gbDataTypes.Controls.Add(this.btnFieldUlong);
            this.gbDataTypes.Controls.Add(this.tbUlong);
            this.gbDataTypes.Controls.Add(this.btnStructureUint);
            this.gbDataTypes.Controls.Add(this.btnFieldUint);
            this.gbDataTypes.Controls.Add(this.tbUint);
            this.gbDataTypes.Controls.Add(this.btnStructureUshort);
            this.gbDataTypes.Controls.Add(this.btnFieldUshort);
            this.gbDataTypes.Controls.Add(this.tbUshort);
            this.gbDataTypes.Controls.Add(this.btnStructureSbyte);
            this.gbDataTypes.Controls.Add(this.btnFieldSbyte);
            this.gbDataTypes.Controls.Add(this.tbSbyte);
            this.gbDataTypes.Controls.Add(this.btnStructureFloat);
            this.gbDataTypes.Controls.Add(this.btnFieldFloat);
            this.gbDataTypes.Controls.Add(this.tbFloat);
            this.gbDataTypes.Controls.Add(this.btnStructureLong);
            this.gbDataTypes.Controls.Add(this.btnFieldLong);
            this.gbDataTypes.Controls.Add(this.tbLong);
            this.gbDataTypes.Controls.Add(this.btnStructureInt);
            this.gbDataTypes.Controls.Add(this.btnFieldInt);
            this.gbDataTypes.Controls.Add(this.tbInt);
            this.gbDataTypes.Controls.Add(this.btnStructureShort);
            this.gbDataTypes.Controls.Add(this.btnFieldShort);
            this.gbDataTypes.Controls.Add(this.tbShort);
            this.gbDataTypes.Controls.Add(this.btnStructureByte);
            this.gbDataTypes.Controls.Add(this.btnFieldByte);
            this.gbDataTypes.Controls.Add(this.tbByte);
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
            this.gbDataTypes.Size = new System.Drawing.Size(330, 280);
            this.gbDataTypes.TabIndex = 39;
            this.gbDataTypes.TabStop = false;
            this.gbDataTypes.Text = "Editor.DataTypes";
            // 
            // btnStructureDouble
            // 
            this.btnStructureDouble.Location = new System.Drawing.Point(288, 251);
            this.btnStructureDouble.Name = "btnStructureDouble";
            this.btnStructureDouble.Size = new System.Drawing.Size(36, 23);
            this.btnStructureDouble.TabIndex = 53;
            this.btnStructureDouble.Text = "Two";
            this.btnStructureDouble.UseVisualStyleBackColor = true;
            // 
            // btnFieldDouble
            // 
            this.btnFieldDouble.Location = new System.Drawing.Point(247, 251);
            this.btnFieldDouble.Name = "btnFieldDouble";
            this.btnFieldDouble.Size = new System.Drawing.Size(35, 23);
            this.btnFieldDouble.TabIndex = 52;
            this.btnFieldDouble.Text = "One";
            this.btnFieldDouble.UseVisualStyleBackColor = true;
            // 
            // tbDouble
            // 
            this.tbDouble.Location = new System.Drawing.Point(59, 253);
            this.tbDouble.Name = "tbDouble";
            this.tbDouble.ReadOnly = true;
            this.tbDouble.Size = new System.Drawing.Size(182, 20);
            this.tbDouble.TabIndex = 51;
            // 
            // btnStructureUlong
            // 
            this.btnStructureUlong.Location = new System.Drawing.Point(288, 225);
            this.btnStructureUlong.Name = "btnStructureUlong";
            this.btnStructureUlong.Size = new System.Drawing.Size(36, 23);
            this.btnStructureUlong.TabIndex = 50;
            this.btnStructureUlong.Text = "Two";
            this.btnStructureUlong.UseVisualStyleBackColor = true;
            // 
            // btnFieldUlong
            // 
            this.btnFieldUlong.Location = new System.Drawing.Point(247, 225);
            this.btnFieldUlong.Name = "btnFieldUlong";
            this.btnFieldUlong.Size = new System.Drawing.Size(35, 23);
            this.btnFieldUlong.TabIndex = 49;
            this.btnFieldUlong.Text = "One";
            this.btnFieldUlong.UseVisualStyleBackColor = true;
            // 
            // tbUlong
            // 
            this.tbUlong.Location = new System.Drawing.Point(59, 227);
            this.tbUlong.Name = "tbUlong";
            this.tbUlong.ReadOnly = true;
            this.tbUlong.Size = new System.Drawing.Size(182, 20);
            this.tbUlong.TabIndex = 48;
            // 
            // btnStructureUint
            // 
            this.btnStructureUint.Location = new System.Drawing.Point(288, 199);
            this.btnStructureUint.Name = "btnStructureUint";
            this.btnStructureUint.Size = new System.Drawing.Size(36, 23);
            this.btnStructureUint.TabIndex = 47;
            this.btnStructureUint.Text = "Two";
            this.btnStructureUint.UseVisualStyleBackColor = true;
            // 
            // btnFieldUint
            // 
            this.btnFieldUint.Location = new System.Drawing.Point(247, 199);
            this.btnFieldUint.Name = "btnFieldUint";
            this.btnFieldUint.Size = new System.Drawing.Size(35, 23);
            this.btnFieldUint.TabIndex = 46;
            this.btnFieldUint.Text = "One";
            this.btnFieldUint.UseVisualStyleBackColor = true;
            // 
            // tbUint
            // 
            this.tbUint.Location = new System.Drawing.Point(59, 201);
            this.tbUint.Name = "tbUint";
            this.tbUint.ReadOnly = true;
            this.tbUint.Size = new System.Drawing.Size(182, 20);
            this.tbUint.TabIndex = 45;
            // 
            // btnStructureUshort
            // 
            this.btnStructureUshort.Location = new System.Drawing.Point(288, 173);
            this.btnStructureUshort.Name = "btnStructureUshort";
            this.btnStructureUshort.Size = new System.Drawing.Size(36, 23);
            this.btnStructureUshort.TabIndex = 44;
            this.btnStructureUshort.Text = "Two";
            this.btnStructureUshort.UseVisualStyleBackColor = true;
            // 
            // btnFieldUshort
            // 
            this.btnFieldUshort.Location = new System.Drawing.Point(247, 173);
            this.btnFieldUshort.Name = "btnFieldUshort";
            this.btnFieldUshort.Size = new System.Drawing.Size(35, 23);
            this.btnFieldUshort.TabIndex = 43;
            this.btnFieldUshort.Text = "One";
            this.btnFieldUshort.UseVisualStyleBackColor = true;
            // 
            // tbUshort
            // 
            this.tbUshort.Location = new System.Drawing.Point(59, 175);
            this.tbUshort.Name = "tbUshort";
            this.tbUshort.ReadOnly = true;
            this.tbUshort.Size = new System.Drawing.Size(182, 20);
            this.tbUshort.TabIndex = 42;
            // 
            // btnStructureSbyte
            // 
            this.btnStructureSbyte.Location = new System.Drawing.Point(288, 147);
            this.btnStructureSbyte.Name = "btnStructureSbyte";
            this.btnStructureSbyte.Size = new System.Drawing.Size(36, 23);
            this.btnStructureSbyte.TabIndex = 41;
            this.btnStructureSbyte.Text = "Two";
            this.btnStructureSbyte.UseVisualStyleBackColor = true;
            // 
            // btnFieldSbyte
            // 
            this.btnFieldSbyte.Location = new System.Drawing.Point(247, 147);
            this.btnFieldSbyte.Name = "btnFieldSbyte";
            this.btnFieldSbyte.Size = new System.Drawing.Size(35, 23);
            this.btnFieldSbyte.TabIndex = 40;
            this.btnFieldSbyte.Text = "One";
            this.btnFieldSbyte.UseVisualStyleBackColor = true;
            // 
            // tbSbyte
            // 
            this.tbSbyte.Location = new System.Drawing.Point(59, 149);
            this.tbSbyte.Name = "tbSbyte";
            this.tbSbyte.ReadOnly = true;
            this.tbSbyte.Size = new System.Drawing.Size(182, 20);
            this.tbSbyte.TabIndex = 39;
            // 
            // btnStructureFloat
            // 
            this.btnStructureFloat.Location = new System.Drawing.Point(288, 121);
            this.btnStructureFloat.Name = "btnStructureFloat";
            this.btnStructureFloat.Size = new System.Drawing.Size(36, 23);
            this.btnStructureFloat.TabIndex = 38;
            this.btnStructureFloat.Text = "Two";
            this.btnStructureFloat.UseVisualStyleBackColor = true;
            // 
            // btnFieldFloat
            // 
            this.btnFieldFloat.Location = new System.Drawing.Point(247, 121);
            this.btnFieldFloat.Name = "btnFieldFloat";
            this.btnFieldFloat.Size = new System.Drawing.Size(35, 23);
            this.btnFieldFloat.TabIndex = 37;
            this.btnFieldFloat.Text = "One";
            this.btnFieldFloat.UseVisualStyleBackColor = true;
            // 
            // tbFloat
            // 
            this.tbFloat.Location = new System.Drawing.Point(59, 123);
            this.tbFloat.Name = "tbFloat";
            this.tbFloat.ReadOnly = true;
            this.tbFloat.Size = new System.Drawing.Size(182, 20);
            this.tbFloat.TabIndex = 36;
            // 
            // btnStructureLong
            // 
            this.btnStructureLong.Location = new System.Drawing.Point(288, 95);
            this.btnStructureLong.Name = "btnStructureLong";
            this.btnStructureLong.Size = new System.Drawing.Size(36, 23);
            this.btnStructureLong.TabIndex = 35;
            this.btnStructureLong.Text = "Two";
            this.btnStructureLong.UseVisualStyleBackColor = true;
            // 
            // btnFieldLong
            // 
            this.btnFieldLong.Location = new System.Drawing.Point(247, 95);
            this.btnFieldLong.Name = "btnFieldLong";
            this.btnFieldLong.Size = new System.Drawing.Size(35, 23);
            this.btnFieldLong.TabIndex = 34;
            this.btnFieldLong.Text = "One";
            this.btnFieldLong.UseVisualStyleBackColor = true;
            // 
            // tbLong
            // 
            this.tbLong.Location = new System.Drawing.Point(59, 97);
            this.tbLong.Name = "tbLong";
            this.tbLong.ReadOnly = true;
            this.tbLong.Size = new System.Drawing.Size(182, 20);
            this.tbLong.TabIndex = 33;
            // 
            // btnStructureInt
            // 
            this.btnStructureInt.Location = new System.Drawing.Point(288, 69);
            this.btnStructureInt.Name = "btnStructureInt";
            this.btnStructureInt.Size = new System.Drawing.Size(36, 23);
            this.btnStructureInt.TabIndex = 32;
            this.btnStructureInt.Text = "Two";
            this.btnStructureInt.UseVisualStyleBackColor = true;
            // 
            // btnFieldInt
            // 
            this.btnFieldInt.Location = new System.Drawing.Point(247, 69);
            this.btnFieldInt.Name = "btnFieldInt";
            this.btnFieldInt.Size = new System.Drawing.Size(35, 23);
            this.btnFieldInt.TabIndex = 31;
            this.btnFieldInt.Text = "One";
            this.btnFieldInt.UseVisualStyleBackColor = true;
            // 
            // tbInt
            // 
            this.tbInt.Location = new System.Drawing.Point(59, 71);
            this.tbInt.Name = "tbInt";
            this.tbInt.ReadOnly = true;
            this.tbInt.Size = new System.Drawing.Size(182, 20);
            this.tbInt.TabIndex = 30;
            // 
            // btnStructureShort
            // 
            this.btnStructureShort.Location = new System.Drawing.Point(288, 43);
            this.btnStructureShort.Name = "btnStructureShort";
            this.btnStructureShort.Size = new System.Drawing.Size(36, 23);
            this.btnStructureShort.TabIndex = 29;
            this.btnStructureShort.Text = "Two";
            this.btnStructureShort.UseVisualStyleBackColor = true;
            // 
            // btnFieldShort
            // 
            this.btnFieldShort.Location = new System.Drawing.Point(247, 43);
            this.btnFieldShort.Name = "btnFieldShort";
            this.btnFieldShort.Size = new System.Drawing.Size(35, 23);
            this.btnFieldShort.TabIndex = 28;
            this.btnFieldShort.Text = "One";
            this.btnFieldShort.UseVisualStyleBackColor = true;
            // 
            // tbShort
            // 
            this.tbShort.Location = new System.Drawing.Point(59, 45);
            this.tbShort.Name = "tbShort";
            this.tbShort.ReadOnly = true;
            this.tbShort.Size = new System.Drawing.Size(182, 20);
            this.tbShort.TabIndex = 27;
            // 
            // btnStructureByte
            // 
            this.btnStructureByte.Location = new System.Drawing.Point(288, 17);
            this.btnStructureByte.Name = "btnStructureByte";
            this.btnStructureByte.Size = new System.Drawing.Size(36, 23);
            this.btnStructureByte.TabIndex = 26;
            this.btnStructureByte.Text = "Two";
            this.btnStructureByte.UseVisualStyleBackColor = true;
            // 
            // btnFieldByte
            // 
            this.btnFieldByte.Location = new System.Drawing.Point(247, 17);
            this.btnFieldByte.Name = "btnFieldByte";
            this.btnFieldByte.Size = new System.Drawing.Size(35, 23);
            this.btnFieldByte.TabIndex = 25;
            this.btnFieldByte.Text = "One";
            this.btnFieldByte.UseVisualStyleBackColor = true;
            // 
            // tbByte
            // 
            this.tbByte.Location = new System.Drawing.Point(59, 19);
            this.tbByte.Name = "tbByte";
            this.tbByte.ReadOnly = true;
            this.tbByte.Size = new System.Drawing.Size(182, 20);
            this.tbByte.TabIndex = 24;
            // 
            // lblDoubleType
            // 
            this.lblDoubleType.AutoSize = true;
            this.lblDoubleType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDoubleType.Location = new System.Drawing.Point(6, 254);
            this.lblDoubleType.Name = "lblDoubleType";
            this.lblDoubleType.Size = new System.Drawing.Size(82, 15);
            this.lblDoubleType.TabIndex = 23;
            this.lblDoubleType.Text = "Types.Double";
            // 
            // lblFloatType
            // 
            this.lblFloatType.AutoSize = true;
            this.lblFloatType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFloatType.Location = new System.Drawing.Point(6, 124);
            this.lblFloatType.Name = "lblFloatType";
            this.lblFloatType.Size = new System.Drawing.Size(69, 15);
            this.lblFloatType.TabIndex = 22;
            this.lblFloatType.Text = "Types.Float";
            // 
            // lblUlongType
            // 
            this.lblUlongType.AutoSize = true;
            this.lblUlongType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblUlongType.Location = new System.Drawing.Point(6, 228);
            this.lblUlongType.Name = "lblUlongType";
            this.lblUlongType.Size = new System.Drawing.Size(75, 15);
            this.lblUlongType.TabIndex = 21;
            this.lblUlongType.Text = "Types.Ulong";
            // 
            // lblLongType
            // 
            this.lblLongType.AutoSize = true;
            this.lblLongType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLongType.Location = new System.Drawing.Point(6, 98);
            this.lblLongType.Name = "lblLongType";
            this.lblLongType.Size = new System.Drawing.Size(70, 15);
            this.lblLongType.TabIndex = 20;
            this.lblLongType.Text = "Types.Long";
            // 
            // lblUintType
            // 
            this.lblUintType.AutoSize = true;
            this.lblUintType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblUintType.Location = new System.Drawing.Point(6, 202);
            this.lblUintType.Name = "lblUintType";
            this.lblUintType.Size = new System.Drawing.Size(64, 15);
            this.lblUintType.TabIndex = 19;
            this.lblUintType.Text = "Types.Uint";
            // 
            // lblIntType
            // 
            this.lblIntType.AutoSize = true;
            this.lblIntType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblIntType.Location = new System.Drawing.Point(6, 72);
            this.lblIntType.Name = "lblIntType";
            this.lblIntType.Size = new System.Drawing.Size(55, 15);
            this.lblIntType.TabIndex = 18;
            this.lblIntType.Text = "Types.Int";
            // 
            // lblUshortType
            // 
            this.lblUshortType.AutoSize = true;
            this.lblUshortType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblUshortType.Location = new System.Drawing.Point(6, 176);
            this.lblUshortType.Name = "lblUshortType";
            this.lblUshortType.Size = new System.Drawing.Size(78, 15);
            this.lblUshortType.TabIndex = 17;
            this.lblUshortType.Text = "Types.Ushort";
            // 
            // lblShortType
            // 
            this.lblShortType.AutoSize = true;
            this.lblShortType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblShortType.Location = new System.Drawing.Point(6, 46);
            this.lblShortType.Name = "lblShortType";
            this.lblShortType.Size = new System.Drawing.Size(71, 15);
            this.lblShortType.TabIndex = 16;
            this.lblShortType.Text = "Types.Short";
            // 
            // lblSbyteType
            // 
            this.lblSbyteType.AutoSize = true;
            this.lblSbyteType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSbyteType.Location = new System.Drawing.Point(6, 150);
            this.lblSbyteType.Name = "lblSbyteType";
            this.lblSbyteType.Size = new System.Drawing.Size(72, 15);
            this.lblSbyteType.TabIndex = 15;
            this.lblSbyteType.Text = "Types.Sbyte";
            // 
            // lblByteType
            // 
            this.lblByteType.AutoSize = true;
            this.lblByteType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblByteType.Location = new System.Drawing.Point(6, 20);
            this.lblByteType.Name = "lblByteType";
            this.lblByteType.Size = new System.Drawing.Size(65, 15);
            this.lblByteType.TabIndex = 14;
            this.lblByteType.Text = "Types.Byte";
            // 
            // cbSequenceType
            // 
            this.cbSequenceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSequenceType.FormattingEnabled = true;
            this.cbSequenceType.Items.AddRange(new object[] {
            "SequenceTypes.LittleEndian",
            "SequenceTypes.BigEndian"});
            this.cbSequenceType.Location = new System.Drawing.Point(6, 61);
            this.cbSequenceType.Name = "cbSequenceType";
            this.cbSequenceType.Size = new System.Drawing.Size(330, 21);
            this.cbSequenceType.TabIndex = 39;
            this.cbSequenceType.SelectedIndexChanged += new System.EventHandler(this.CbSequenceType_SelectedIndexChanged);
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
            this.tpConfiguration.Controls.Add(this.btnDeleteConfigurationField);
            this.tpConfiguration.Controls.Add(this.btnAddConfigurationField);
            this.tpConfiguration.Controls.Add(this.dgvConfigurationFields);
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
            // btnDeleteConfigurationField
            // 
            this.btnDeleteConfigurationField.Location = new System.Drawing.Point(184, 548);
            this.btnDeleteConfigurationField.Name = "btnDeleteConfigurationField";
            this.btnDeleteConfigurationField.Size = new System.Drawing.Size(152, 23);
            this.btnDeleteConfigurationField.TabIndex = 23;
            this.btnDeleteConfigurationField.Text = "Editor.DeleteConfigurationField";
            this.btnDeleteConfigurationField.UseVisualStyleBackColor = true;
            this.btnDeleteConfigurationField.Click += new System.EventHandler(this.BtnDeleteConfigurationField_Click);
            // 
            // btnAddConfigurationField
            // 
            this.btnAddConfigurationField.Location = new System.Drawing.Point(6, 548);
            this.btnAddConfigurationField.Name = "btnAddConfigurationField";
            this.btnAddConfigurationField.Size = new System.Drawing.Size(152, 23);
            this.btnAddConfigurationField.TabIndex = 22;
            this.btnAddConfigurationField.Text = "Editor.AddConfigurationField";
            this.btnAddConfigurationField.UseVisualStyleBackColor = true;
            this.btnAddConfigurationField.Click += new System.EventHandler(this.BtnAddConfigurationField_Click);
            // 
            // dgvConfigurationFields
            // 
            this.dgvConfigurationFields.AllowDrop = true;
            this.dgvConfigurationFields.AllowUserToAddRows = false;
            this.dgvConfigurationFields.AllowUserToDeleteRows = false;
            this.dgvConfigurationFields.AllowUserToOrderColumns = true;
            this.dgvConfigurationFields.AllowUserToResizeColumns = false;
            this.dgvConfigurationFields.AllowUserToResizeRows = false;
            this.dgvConfigurationFields.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConfigurationFields.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvConfigurationFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConfigurationFields.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ConfigurationPosition,
            this.ConfigurationType,
            this.ConfigurationName,
            this.ConfigurationValue});
            this.dgvConfigurationFields.Location = new System.Drawing.Point(6, 117);
            this.dgvConfigurationFields.Name = "dgvConfigurationFields";
            this.dgvConfigurationFields.ReadOnly = true;
            this.dgvConfigurationFields.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvConfigurationFields.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvConfigurationFields.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConfigurationFields.Size = new System.Drawing.Size(330, 295);
            this.dgvConfigurationFields.TabIndex = 22;
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
            // ConfigurationPosition
            // 
            this.ConfigurationPosition.HeaderText = "Editor.ConfigurationPosition";
            this.ConfigurationPosition.Name = "ConfigurationPosition";
            this.ConfigurationPosition.ReadOnly = true;
            this.ConfigurationPosition.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ConfigurationPosition.Width = 75;
            // 
            // ConfigurationType
            // 
            this.ConfigurationType.HeaderText = "Editor.ConfigurationType";
            this.ConfigurationType.Name = "ConfigurationType";
            this.ConfigurationType.ReadOnly = true;
            this.ConfigurationType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ConfigurationType.Width = 75;
            // 
            // ConfigurationName
            // 
            this.ConfigurationName.HeaderText = "Editor.ConfigurationName";
            this.ConfigurationName.Name = "ConfigurationName";
            this.ConfigurationName.ReadOnly = true;
            this.ConfigurationName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ConfigurationName.Width = 150;
            // 
            // ConfigurationValue
            // 
            this.ConfigurationValue.HeaderText = "Editor.ConfigurationValue";
            this.ConfigurationValue.Name = "ConfigurationValue";
            this.ConfigurationValue.ReadOnly = true;
            this.ConfigurationValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            this.MaximizeBox = false;
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvConfigurationFields)).EndInit();
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
		private System.Windows.Forms.DataGridView dgvConfigurationFields;
		private System.Windows.Forms.Button btnDeleteConfigurationField;
		private System.Windows.Forms.Button btnAddConfigurationField;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createConfigurationToolStripMenuItem;
        private System.Windows.Forms.TextBox tbByte;
        private System.Windows.Forms.Button btnStructureByte;
        private System.Windows.Forms.Button btnFieldByte;
        private System.Windows.Forms.Button btnStructureDouble;
        private System.Windows.Forms.Button btnFieldDouble;
        private System.Windows.Forms.TextBox tbDouble;
        private System.Windows.Forms.Button btnStructureUlong;
        private System.Windows.Forms.Button btnFieldUlong;
        private System.Windows.Forms.TextBox tbUlong;
        private System.Windows.Forms.Button btnStructureUint;
        private System.Windows.Forms.Button btnFieldUint;
        private System.Windows.Forms.TextBox tbUint;
        private System.Windows.Forms.Button btnStructureUshort;
        private System.Windows.Forms.Button btnFieldUshort;
        private System.Windows.Forms.TextBox tbUshort;
        private System.Windows.Forms.Button btnStructureSbyte;
        private System.Windows.Forms.Button btnFieldSbyte;
        private System.Windows.Forms.TextBox tbSbyte;
        private System.Windows.Forms.Button btnStructureFloat;
        private System.Windows.Forms.Button btnFieldFloat;
        private System.Windows.Forms.TextBox tbFloat;
        private System.Windows.Forms.Button btnStructureLong;
        private System.Windows.Forms.Button btnFieldLong;
        private System.Windows.Forms.TextBox tbLong;
        private System.Windows.Forms.Button btnStructureInt;
        private System.Windows.Forms.Button btnFieldInt;
        private System.Windows.Forms.TextBox tbInt;
        private System.Windows.Forms.Button btnStructureShort;
        private System.Windows.Forms.Button btnFieldShort;
        private System.Windows.Forms.TextBox tbShort;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConfigurationPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConfigurationType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConfigurationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConfigurationValue;
    }
}