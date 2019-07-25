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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
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
			this.tcGeneral = new System.Windows.Forms.TabControl();
			this.tpPackets = new System.Windows.Forms.TabPage();
			this.cbAutoScroll = new System.Windows.Forms.CheckBox();
			this.btnUpdatePackets = new System.Windows.Forms.Button();
			this.cbAutoUpdateDataGridView = new System.Windows.Forms.CheckBox();
			this.btnClearPackets = new System.Windows.Forms.Button();
			this.cbTypeEncryptionPackets = new System.Windows.Forms.ComboBox();
			this.cbTypePackets = new System.Windows.Forms.ComboBox();
			this.dgvPackets = new System.Windows.Forms.DataGridView();
			this.PacketNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.PacketId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.PacketOpcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.PacketName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tpConfigurationPackets = new System.Windows.Forms.TabPage();
			this.dgvConfigurationPackets = new System.Windows.Forms.DataGridView();
			this.ConfigurationPacketNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ConfigurationPacketOpcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ConfigurationPacketName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tpStructures = new System.Windows.Forms.TabPage();
			this.dgvStructures = new System.Windows.Forms.DataGridView();
			this.StructureNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.StructureName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.lblInformation = new System.Windows.Forms.Label();
			this.gbHexEditor = new System.Windows.Forms.GroupBox();
			this.btnSearchClear = new System.Windows.Forms.Button();
			this.btnSearchStart = new System.Windows.Forms.Button();
			this.cbSearchType = new System.Windows.Forms.ComboBox();
			this.tbSearch = new System.Windows.Forms.TextBox();
			this.hbHexEditor = new HexBoxForm.HexBox();
			this.tpPacketInformation = new System.Windows.Forms.TabPage();
			this.gbDataTypes = new System.Windows.Forms.GroupBox();
			this.btnCopyByte = new System.Windows.Forms.Button();
			this.btnCopyShort = new System.Windows.Forms.Button();
			this.btnCopyInt = new System.Windows.Forms.Button();
			this.btnCopyLong = new System.Windows.Forms.Button();
			this.btnCopyFloat = new System.Windows.Forms.Button();
			this.btnCopySbyte = new System.Windows.Forms.Button();
			this.btnCopyUshort = new System.Windows.Forms.Button();
			this.btnCopyUint = new System.Windows.Forms.Button();
			this.btnCopyUlong = new System.Windows.Forms.Button();
			this.btnCopyDouble = new System.Windows.Forms.Button();
			this.btnCopyString = new System.Windows.Forms.Button();
			this.btnFieldString = new System.Windows.Forms.Button();
			this.tbString = new System.Windows.Forms.TextBox();
			this.lblStringType = new System.Windows.Forms.Label();
			this.lblSequenceType = new System.Windows.Forms.Label();
			this.cbSequenceType = new System.Windows.Forms.ComboBox();
			this.btnFieldDouble = new System.Windows.Forms.Button();
			this.tbDouble = new System.Windows.Forms.TextBox();
			this.btnFieldUlong = new System.Windows.Forms.Button();
			this.tbUlong = new System.Windows.Forms.TextBox();
			this.btnFieldUint = new System.Windows.Forms.Button();
			this.tbUint = new System.Windows.Forms.TextBox();
			this.btnFieldUshort = new System.Windows.Forms.Button();
			this.tbUshort = new System.Windows.Forms.TextBox();
			this.btnFieldSbyte = new System.Windows.Forms.Button();
			this.tbSbyte = new System.Windows.Forms.TextBox();
			this.btnFieldFloat = new System.Windows.Forms.Button();
			this.tbFloat = new System.Windows.Forms.TextBox();
			this.btnFieldLong = new System.Windows.Forms.Button();
			this.tbLong = new System.Windows.Forms.TextBox();
			this.btnFieldInt = new System.Windows.Forms.Button();
			this.tbInt = new System.Windows.Forms.TextBox();
			this.btnFieldShort = new System.Windows.Forms.Button();
			this.tbShort = new System.Windows.Forms.TextBox();
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
			this.gbGeneralInformation = new System.Windows.Forms.GroupBox();
			this.lblClassCount = new System.Windows.Forms.Label();
			this.lblSelectedLength = new System.Windows.Forms.Label();
			this.lblDataLength = new System.Windows.Forms.Label();
			this.lblSelectedIndex = new System.Windows.Forms.Label();
			this.tcConfiguration = new System.Windows.Forms.TabControl();
			this.tpConfiguration = new System.Windows.Forms.TabPage();
			this.btnConfigurationAdd = new System.Windows.Forms.Button();
			this.btnConfigurationDelete = new System.Windows.Forms.Button();
			this.btnConfigurationFieldEdit = new System.Windows.Forms.Button();
			this.btnConfigurationFieldDelete = new System.Windows.Forms.Button();
			this.btnConfigurationFieldAdd = new System.Windows.Forms.Button();
			this.dgvConfigurationFields = new System.Windows.Forms.DataGridView();
			this.ConfigurationFieldPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ConfigurationFieldType = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ConfigurationFieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ConfigurationFieldValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tbConfigurationDescription = new System.Windows.Forms.TextBox();
			this.lblConfigurationDescription = new System.Windows.Forms.Label();
			this.lblConfigurationName = new System.Windows.Forms.Label();
			this.tbConfigurationName = new System.Windows.Forms.TextBox();
			this.tpBindings = new System.Windows.Forms.TabPage();
			this.msMenu.SuspendLayout();
			this.tcGeneral.SuspendLayout();
			this.tpPackets.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvPackets)).BeginInit();
			this.tpConfigurationPackets.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvConfigurationPackets)).BeginInit();
			this.tpStructures.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvStructures)).BeginInit();
			this.gbHexEditor.SuspendLayout();
			this.tpPacketInformation.SuspendLayout();
			this.gbDataTypes.SuspendLayout();
			this.gbGeneralInformation.SuspendLayout();
			this.tcConfiguration.SuspendLayout();
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
			// tcGeneral
			// 
			this.tcGeneral.Controls.Add(this.tpPackets);
			this.tcGeneral.Controls.Add(this.tpConfigurationPackets);
			this.tcGeneral.Controls.Add(this.tpStructures);
			this.tcGeneral.Location = new System.Drawing.Point(12, 27);
			this.tcGeneral.Name = "tcGeneral";
			this.tcGeneral.SelectedIndex = 0;
			this.tcGeneral.Size = new System.Drawing.Size(330, 603);
			this.tcGeneral.TabIndex = 1;
			this.tcGeneral.SelectedIndexChanged += new System.EventHandler(this.TcGeneral_SelectedIndexChanged);
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
            this.PacketNumber,
            this.PacketId,
            this.PacketOpcode,
            this.PacketName});
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvPackets.DefaultCellStyle = dataGridViewCellStyle2;
			this.dgvPackets.Location = new System.Drawing.Point(6, 33);
			this.dgvPackets.Name = "dgvPackets";
			this.dgvPackets.ReadOnly = true;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvPackets.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dgvPackets.RowHeadersVisible = false;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dgvPackets.RowsDefaultCellStyle = dataGridViewCellStyle4;
			this.dgvPackets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvPackets.Size = new System.Drawing.Size(310, 463);
			this.dgvPackets.TabIndex = 3;
			this.dgvPackets.SelectionChanged += new System.EventHandler(this.DgvPackets_SelectionChanged);
			// 
			// PacketNumber
			// 
			this.PacketNumber.HeaderText = "№";
			this.PacketNumber.Name = "PacketNumber";
			this.PacketNumber.ReadOnly = true;
			this.PacketNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.PacketNumber.Width = 50;
			// 
			// PacketId
			// 
			this.PacketId.HeaderText = "Id";
			this.PacketId.Name = "PacketId";
			this.PacketId.ReadOnly = true;
			this.PacketId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.PacketId.Visible = false;
			// 
			// PacketOpcode
			// 
			this.PacketOpcode.HeaderText = "Editor.PacketOpcode";
			this.PacketOpcode.Name = "PacketOpcode";
			this.PacketOpcode.ReadOnly = true;
			this.PacketOpcode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.PacketOpcode.Width = 70;
			// 
			// PacketName
			// 
			this.PacketName.HeaderText = "Editor.PacketName";
			this.PacketName.Name = "PacketName";
			this.PacketName.ReadOnly = true;
			this.PacketName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.PacketName.Width = 170;
			// 
			// tpConfigurationPackets
			// 
			this.tpConfigurationPackets.BackColor = System.Drawing.SystemColors.Control;
			this.tpConfigurationPackets.Controls.Add(this.dgvConfigurationPackets);
			this.tpConfigurationPackets.Location = new System.Drawing.Point(4, 22);
			this.tpConfigurationPackets.Name = "tpConfigurationPackets";
			this.tpConfigurationPackets.Padding = new System.Windows.Forms.Padding(3);
			this.tpConfigurationPackets.Size = new System.Drawing.Size(322, 577);
			this.tpConfigurationPackets.TabIndex = 3;
			this.tpConfigurationPackets.Text = "Editor.ConfigurationPackets";
			// 
			// dgvConfigurationPackets
			// 
			this.dgvConfigurationPackets.AllowDrop = true;
			this.dgvConfigurationPackets.AllowUserToAddRows = false;
			this.dgvConfigurationPackets.AllowUserToDeleteRows = false;
			this.dgvConfigurationPackets.AllowUserToOrderColumns = true;
			this.dgvConfigurationPackets.AllowUserToResizeColumns = false;
			this.dgvConfigurationPackets.AllowUserToResizeRows = false;
			this.dgvConfigurationPackets.BackgroundColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvConfigurationPackets.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
			this.dgvConfigurationPackets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvConfigurationPackets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ConfigurationPacketNumber,
            this.ConfigurationPacketOpcode,
            this.ConfigurationPacketName});
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvConfigurationPackets.DefaultCellStyle = dataGridViewCellStyle6;
			this.dgvConfigurationPackets.Location = new System.Drawing.Point(6, 6);
			this.dgvConfigurationPackets.Name = "dgvConfigurationPackets";
			this.dgvConfigurationPackets.ReadOnly = true;
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvConfigurationPackets.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
			this.dgvConfigurationPackets.RowHeadersVisible = false;
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dgvConfigurationPackets.RowsDefaultCellStyle = dataGridViewCellStyle8;
			this.dgvConfigurationPackets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvConfigurationPackets.Size = new System.Drawing.Size(310, 565);
			this.dgvConfigurationPackets.TabIndex = 4;
			this.dgvConfigurationPackets.SelectionChanged += new System.EventHandler(this.DgvConfigurationPackets_SelectionChanged);
			// 
			// ConfigurationPacketNumber
			// 
			this.ConfigurationPacketNumber.HeaderText = "№";
			this.ConfigurationPacketNumber.Name = "ConfigurationPacketNumber";
			this.ConfigurationPacketNumber.ReadOnly = true;
			this.ConfigurationPacketNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.ConfigurationPacketNumber.Width = 50;
			// 
			// ConfigurationPacketOpcode
			// 
			this.ConfigurationPacketOpcode.HeaderText = "Editor.PacketOpcode";
			this.ConfigurationPacketOpcode.Name = "ConfigurationPacketOpcode";
			this.ConfigurationPacketOpcode.ReadOnly = true;
			this.ConfigurationPacketOpcode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.ConfigurationPacketOpcode.Width = 70;
			// 
			// ConfigurationPacketName
			// 
			this.ConfigurationPacketName.HeaderText = "Editor.PacketName";
			this.ConfigurationPacketName.Name = "ConfigurationPacketName";
			this.ConfigurationPacketName.ReadOnly = true;
			this.ConfigurationPacketName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.ConfigurationPacketName.Width = 170;
			// 
			// tpStructures
			// 
			this.tpStructures.BackColor = System.Drawing.SystemColors.Control;
			this.tpStructures.Controls.Add(this.dgvStructures);
			this.tpStructures.Location = new System.Drawing.Point(4, 22);
			this.tpStructures.Name = "tpStructures";
			this.tpStructures.Padding = new System.Windows.Forms.Padding(3);
			this.tpStructures.Size = new System.Drawing.Size(322, 577);
			this.tpStructures.TabIndex = 2;
			this.tpStructures.Text = "Editor.Structures";
			// 
			// dgvStructures
			// 
			this.dgvStructures.AllowDrop = true;
			this.dgvStructures.AllowUserToAddRows = false;
			this.dgvStructures.AllowUserToDeleteRows = false;
			this.dgvStructures.AllowUserToOrderColumns = true;
			this.dgvStructures.AllowUserToResizeColumns = false;
			this.dgvStructures.AllowUserToResizeRows = false;
			this.dgvStructures.BackgroundColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvStructures.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
			this.dgvStructures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvStructures.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StructureNumber,
            this.StructureName});
			dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvStructures.DefaultCellStyle = dataGridViewCellStyle10;
			this.dgvStructures.Location = new System.Drawing.Point(6, 6);
			this.dgvStructures.Name = "dgvStructures";
			this.dgvStructures.ReadOnly = true;
			dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvStructures.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
			this.dgvStructures.RowHeadersVisible = false;
			dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dgvStructures.RowsDefaultCellStyle = dataGridViewCellStyle12;
			this.dgvStructures.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvStructures.Size = new System.Drawing.Size(310, 565);
			this.dgvStructures.TabIndex = 4;
			this.dgvStructures.SelectionChanged += new System.EventHandler(this.DgvStructures_SelectionChanged);
			// 
			// StructureNumber
			// 
			this.StructureNumber.HeaderText = "№";
			this.StructureNumber.Name = "StructureNumber";
			this.StructureNumber.ReadOnly = true;
			this.StructureNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.StructureNumber.Width = 50;
			// 
			// StructureName
			// 
			this.StructureName.HeaderText = "Editor.StructureName";
			this.StructureName.Name = "StructureName";
			this.StructureName.ReadOnly = true;
			this.StructureName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.StructureName.Width = 240;
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
            "Editor.SearchName",
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
			this.gbDataTypes.Controls.Add(this.btnCopyByte);
			this.gbDataTypes.Controls.Add(this.btnCopyShort);
			this.gbDataTypes.Controls.Add(this.btnCopyInt);
			this.gbDataTypes.Controls.Add(this.btnCopyLong);
			this.gbDataTypes.Controls.Add(this.btnCopyFloat);
			this.gbDataTypes.Controls.Add(this.btnCopySbyte);
			this.gbDataTypes.Controls.Add(this.btnCopyUshort);
			this.gbDataTypes.Controls.Add(this.btnCopyUint);
			this.gbDataTypes.Controls.Add(this.btnCopyUlong);
			this.gbDataTypes.Controls.Add(this.btnCopyDouble);
			this.gbDataTypes.Controls.Add(this.btnCopyString);
			this.gbDataTypes.Controls.Add(this.btnFieldString);
			this.gbDataTypes.Controls.Add(this.tbString);
			this.gbDataTypes.Controls.Add(this.lblStringType);
			this.gbDataTypes.Controls.Add(this.lblSequenceType);
			this.gbDataTypes.Controls.Add(this.cbSequenceType);
			this.gbDataTypes.Controls.Add(this.btnFieldDouble);
			this.gbDataTypes.Controls.Add(this.tbDouble);
			this.gbDataTypes.Controls.Add(this.btnFieldUlong);
			this.gbDataTypes.Controls.Add(this.tbUlong);
			this.gbDataTypes.Controls.Add(this.btnFieldUint);
			this.gbDataTypes.Controls.Add(this.tbUint);
			this.gbDataTypes.Controls.Add(this.btnFieldUshort);
			this.gbDataTypes.Controls.Add(this.tbUshort);
			this.gbDataTypes.Controls.Add(this.btnFieldSbyte);
			this.gbDataTypes.Controls.Add(this.tbSbyte);
			this.gbDataTypes.Controls.Add(this.btnFieldFloat);
			this.gbDataTypes.Controls.Add(this.tbFloat);
			this.gbDataTypes.Controls.Add(this.btnFieldLong);
			this.gbDataTypes.Controls.Add(this.tbLong);
			this.gbDataTypes.Controls.Add(this.btnFieldInt);
			this.gbDataTypes.Controls.Add(this.tbInt);
			this.gbDataTypes.Controls.Add(this.btnFieldShort);
			this.gbDataTypes.Controls.Add(this.tbShort);
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
			this.gbDataTypes.Location = new System.Drawing.Point(6, 61);
			this.gbDataTypes.Name = "gbDataTypes";
			this.gbDataTypes.Size = new System.Drawing.Size(330, 376);
			this.gbDataTypes.TabIndex = 39;
			this.gbDataTypes.TabStop = false;
			this.gbDataTypes.Text = "Editor.DataTypes";
			// 
			// btnCopyByte
			// 
			this.btnCopyByte.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCopyByte.BackgroundImage")));
			this.btnCopyByte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnCopyByte.Location = new System.Drawing.Point(250, 46);
			this.btnCopyByte.Name = "btnCopyByte";
			this.btnCopyByte.Size = new System.Drawing.Size(34, 24);
			this.btnCopyByte.TabIndex = 68;
			this.btnCopyByte.UseVisualStyleBackColor = true;
			this.btnCopyByte.Click += new System.EventHandler(this.BtnConfigurationFieldInformationCopy_Click);
			// 
			// btnCopyShort
			// 
			this.btnCopyShort.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCopyShort.BackgroundImage")));
			this.btnCopyShort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnCopyShort.Location = new System.Drawing.Point(250, 76);
			this.btnCopyShort.Name = "btnCopyShort";
			this.btnCopyShort.Size = new System.Drawing.Size(34, 24);
			this.btnCopyShort.TabIndex = 67;
			this.btnCopyShort.UseVisualStyleBackColor = true;
			this.btnCopyShort.Click += new System.EventHandler(this.BtnConfigurationFieldInformationCopy_Click);
			// 
			// btnCopyInt
			// 
			this.btnCopyInt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCopyInt.BackgroundImage")));
			this.btnCopyInt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnCopyInt.Location = new System.Drawing.Point(250, 106);
			this.btnCopyInt.Name = "btnCopyInt";
			this.btnCopyInt.Size = new System.Drawing.Size(34, 24);
			this.btnCopyInt.TabIndex = 66;
			this.btnCopyInt.UseVisualStyleBackColor = true;
			this.btnCopyInt.Click += new System.EventHandler(this.BtnConfigurationFieldInformationCopy_Click);
			// 
			// btnCopyLong
			// 
			this.btnCopyLong.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCopyLong.BackgroundImage")));
			this.btnCopyLong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnCopyLong.Location = new System.Drawing.Point(250, 136);
			this.btnCopyLong.Name = "btnCopyLong";
			this.btnCopyLong.Size = new System.Drawing.Size(34, 24);
			this.btnCopyLong.TabIndex = 65;
			this.btnCopyLong.UseVisualStyleBackColor = true;
			this.btnCopyLong.Click += new System.EventHandler(this.BtnConfigurationFieldInformationCopy_Click);
			// 
			// btnCopyFloat
			// 
			this.btnCopyFloat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCopyFloat.BackgroundImage")));
			this.btnCopyFloat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnCopyFloat.Location = new System.Drawing.Point(250, 166);
			this.btnCopyFloat.Name = "btnCopyFloat";
			this.btnCopyFloat.Size = new System.Drawing.Size(34, 24);
			this.btnCopyFloat.TabIndex = 64;
			this.btnCopyFloat.UseVisualStyleBackColor = true;
			this.btnCopyFloat.Click += new System.EventHandler(this.BtnConfigurationFieldInformationCopy_Click);
			// 
			// btnCopySbyte
			// 
			this.btnCopySbyte.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCopySbyte.BackgroundImage")));
			this.btnCopySbyte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnCopySbyte.Location = new System.Drawing.Point(250, 196);
			this.btnCopySbyte.Name = "btnCopySbyte";
			this.btnCopySbyte.Size = new System.Drawing.Size(34, 24);
			this.btnCopySbyte.TabIndex = 63;
			this.btnCopySbyte.UseVisualStyleBackColor = true;
			this.btnCopySbyte.Click += new System.EventHandler(this.BtnConfigurationFieldInformationCopy_Click);
			// 
			// btnCopyUshort
			// 
			this.btnCopyUshort.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCopyUshort.BackgroundImage")));
			this.btnCopyUshort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnCopyUshort.Location = new System.Drawing.Point(250, 226);
			this.btnCopyUshort.Name = "btnCopyUshort";
			this.btnCopyUshort.Size = new System.Drawing.Size(34, 24);
			this.btnCopyUshort.TabIndex = 62;
			this.btnCopyUshort.UseVisualStyleBackColor = true;
			this.btnCopyUshort.Click += new System.EventHandler(this.BtnConfigurationFieldInformationCopy_Click);
			// 
			// btnCopyUint
			// 
			this.btnCopyUint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCopyUint.BackgroundImage")));
			this.btnCopyUint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnCopyUint.Location = new System.Drawing.Point(250, 256);
			this.btnCopyUint.Name = "btnCopyUint";
			this.btnCopyUint.Size = new System.Drawing.Size(34, 24);
			this.btnCopyUint.TabIndex = 61;
			this.btnCopyUint.UseVisualStyleBackColor = true;
			this.btnCopyUint.Click += new System.EventHandler(this.BtnConfigurationFieldInformationCopy_Click);
			// 
			// btnCopyUlong
			// 
			this.btnCopyUlong.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCopyUlong.BackgroundImage")));
			this.btnCopyUlong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnCopyUlong.Location = new System.Drawing.Point(250, 286);
			this.btnCopyUlong.Name = "btnCopyUlong";
			this.btnCopyUlong.Size = new System.Drawing.Size(34, 24);
			this.btnCopyUlong.TabIndex = 60;
			this.btnCopyUlong.UseVisualStyleBackColor = true;
			this.btnCopyUlong.Click += new System.EventHandler(this.BtnConfigurationFieldInformationCopy_Click);
			// 
			// btnCopyDouble
			// 
			this.btnCopyDouble.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCopyDouble.BackgroundImage")));
			this.btnCopyDouble.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnCopyDouble.Location = new System.Drawing.Point(250, 316);
			this.btnCopyDouble.Name = "btnCopyDouble";
			this.btnCopyDouble.Size = new System.Drawing.Size(34, 24);
			this.btnCopyDouble.TabIndex = 59;
			this.btnCopyDouble.UseVisualStyleBackColor = true;
			this.btnCopyDouble.Click += new System.EventHandler(this.BtnConfigurationFieldInformationCopy_Click);
			// 
			// btnCopyString
			// 
			this.btnCopyString.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCopyString.BackgroundImage")));
			this.btnCopyString.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnCopyString.Location = new System.Drawing.Point(250, 346);
			this.btnCopyString.Name = "btnCopyString";
			this.btnCopyString.Size = new System.Drawing.Size(34, 24);
			this.btnCopyString.TabIndex = 58;
			this.btnCopyString.UseVisualStyleBackColor = true;
			this.btnCopyString.Click += new System.EventHandler(this.BtnConfigurationFieldInformationCopy_Click);
			// 
			// btnFieldString
			// 
			this.btnFieldString.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFieldString.BackgroundImage")));
			this.btnFieldString.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnFieldString.Location = new System.Drawing.Point(290, 345);
			this.btnFieldString.Name = "btnFieldString";
			this.btnFieldString.Size = new System.Drawing.Size(34, 24);
			this.btnFieldString.TabIndex = 57;
			this.btnFieldString.UseVisualStyleBackColor = true;
			this.btnFieldString.Click += new System.EventHandler(this.BtnConfigurationFieldInformationAdd_Click);
			// 
			// tbString
			// 
			this.tbString.Location = new System.Drawing.Point(59, 349);
			this.tbString.Name = "tbString";
			this.tbString.ReadOnly = true;
			this.tbString.Size = new System.Drawing.Size(185, 20);
			this.tbString.TabIndex = 56;
			// 
			// lblStringType
			// 
			this.lblStringType.AutoSize = true;
			this.lblStringType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblStringType.Location = new System.Drawing.Point(6, 350);
			this.lblStringType.Name = "lblStringType";
			this.lblStringType.Size = new System.Drawing.Size(74, 15);
			this.lblStringType.TabIndex = 55;
			this.lblStringType.Text = "Types.String";
			// 
			// lblSequenceType
			// 
			this.lblSequenceType.AutoSize = true;
			this.lblSequenceType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblSequenceType.Location = new System.Drawing.Point(6, 20);
			this.lblSequenceType.Name = "lblSequenceType";
			this.lblSequenceType.Size = new System.Drawing.Size(124, 15);
			this.lblSequenceType.TabIndex = 54;
			this.lblSequenceType.Text = "Editor.SequenceType";
			// 
			// cbSequenceType
			// 
			this.cbSequenceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSequenceType.FormattingEnabled = true;
			this.cbSequenceType.Items.AddRange(new object[] {
            "SequenceTypes.LittleEndian",
            "SequenceTypes.BigEndian"});
			this.cbSequenceType.Location = new System.Drawing.Point(136, 19);
			this.cbSequenceType.Name = "cbSequenceType";
			this.cbSequenceType.Size = new System.Drawing.Size(188, 21);
			this.cbSequenceType.TabIndex = 39;
			this.cbSequenceType.SelectedIndexChanged += new System.EventHandler(this.CbSequenceType_SelectedIndexChanged);
			// 
			// btnFieldDouble
			// 
			this.btnFieldDouble.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFieldDouble.BackgroundImage")));
			this.btnFieldDouble.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnFieldDouble.Location = new System.Drawing.Point(290, 316);
			this.btnFieldDouble.Name = "btnFieldDouble";
			this.btnFieldDouble.Size = new System.Drawing.Size(34, 24);
			this.btnFieldDouble.TabIndex = 52;
			this.btnFieldDouble.UseVisualStyleBackColor = true;
			this.btnFieldDouble.Click += new System.EventHandler(this.BtnConfigurationFieldInformationAdd_Click);
			// 
			// tbDouble
			// 
			this.tbDouble.Location = new System.Drawing.Point(59, 319);
			this.tbDouble.Name = "tbDouble";
			this.tbDouble.ReadOnly = true;
			this.tbDouble.Size = new System.Drawing.Size(185, 20);
			this.tbDouble.TabIndex = 51;
			// 
			// btnFieldUlong
			// 
			this.btnFieldUlong.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFieldUlong.BackgroundImage")));
			this.btnFieldUlong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnFieldUlong.Location = new System.Drawing.Point(290, 286);
			this.btnFieldUlong.Name = "btnFieldUlong";
			this.btnFieldUlong.Size = new System.Drawing.Size(34, 24);
			this.btnFieldUlong.TabIndex = 49;
			this.btnFieldUlong.UseVisualStyleBackColor = true;
			this.btnFieldUlong.Click += new System.EventHandler(this.BtnConfigurationFieldInformationAdd_Click);
			// 
			// tbUlong
			// 
			this.tbUlong.Location = new System.Drawing.Point(59, 286);
			this.tbUlong.Name = "tbUlong";
			this.tbUlong.ReadOnly = true;
			this.tbUlong.Size = new System.Drawing.Size(185, 20);
			this.tbUlong.TabIndex = 48;
			// 
			// btnFieldUint
			// 
			this.btnFieldUint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFieldUint.BackgroundImage")));
			this.btnFieldUint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnFieldUint.Location = new System.Drawing.Point(290, 256);
			this.btnFieldUint.Name = "btnFieldUint";
			this.btnFieldUint.Size = new System.Drawing.Size(34, 24);
			this.btnFieldUint.TabIndex = 46;
			this.btnFieldUint.UseVisualStyleBackColor = true;
			this.btnFieldUint.Click += new System.EventHandler(this.BtnConfigurationFieldInformationAdd_Click);
			// 
			// tbUint
			// 
			this.tbUint.Location = new System.Drawing.Point(59, 259);
			this.tbUint.Name = "tbUint";
			this.tbUint.ReadOnly = true;
			this.tbUint.Size = new System.Drawing.Size(185, 20);
			this.tbUint.TabIndex = 45;
			// 
			// btnFieldUshort
			// 
			this.btnFieldUshort.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFieldUshort.BackgroundImage")));
			this.btnFieldUshort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnFieldUshort.Location = new System.Drawing.Point(290, 226);
			this.btnFieldUshort.Name = "btnFieldUshort";
			this.btnFieldUshort.Size = new System.Drawing.Size(34, 24);
			this.btnFieldUshort.TabIndex = 43;
			this.btnFieldUshort.UseVisualStyleBackColor = true;
			this.btnFieldUshort.Click += new System.EventHandler(this.BtnConfigurationFieldInformationAdd_Click);
			// 
			// tbUshort
			// 
			this.tbUshort.Location = new System.Drawing.Point(59, 229);
			this.tbUshort.Name = "tbUshort";
			this.tbUshort.ReadOnly = true;
			this.tbUshort.Size = new System.Drawing.Size(185, 20);
			this.tbUshort.TabIndex = 42;
			// 
			// btnFieldSbyte
			// 
			this.btnFieldSbyte.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFieldSbyte.BackgroundImage")));
			this.btnFieldSbyte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnFieldSbyte.Location = new System.Drawing.Point(290, 196);
			this.btnFieldSbyte.Name = "btnFieldSbyte";
			this.btnFieldSbyte.Size = new System.Drawing.Size(34, 24);
			this.btnFieldSbyte.TabIndex = 40;
			this.btnFieldSbyte.UseVisualStyleBackColor = true;
			this.btnFieldSbyte.Click += new System.EventHandler(this.BtnConfigurationFieldInformationAdd_Click);
			// 
			// tbSbyte
			// 
			this.tbSbyte.Location = new System.Drawing.Point(59, 199);
			this.tbSbyte.Name = "tbSbyte";
			this.tbSbyte.ReadOnly = true;
			this.tbSbyte.Size = new System.Drawing.Size(185, 20);
			this.tbSbyte.TabIndex = 39;
			// 
			// btnFieldFloat
			// 
			this.btnFieldFloat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFieldFloat.BackgroundImage")));
			this.btnFieldFloat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnFieldFloat.Location = new System.Drawing.Point(290, 166);
			this.btnFieldFloat.Name = "btnFieldFloat";
			this.btnFieldFloat.Size = new System.Drawing.Size(34, 24);
			this.btnFieldFloat.TabIndex = 37;
			this.btnFieldFloat.UseVisualStyleBackColor = true;
			this.btnFieldFloat.Click += new System.EventHandler(this.BtnConfigurationFieldInformationAdd_Click);
			// 
			// tbFloat
			// 
			this.tbFloat.Location = new System.Drawing.Point(59, 169);
			this.tbFloat.Name = "tbFloat";
			this.tbFloat.ReadOnly = true;
			this.tbFloat.Size = new System.Drawing.Size(185, 20);
			this.tbFloat.TabIndex = 36;
			// 
			// btnFieldLong
			// 
			this.btnFieldLong.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFieldLong.BackgroundImage")));
			this.btnFieldLong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnFieldLong.Location = new System.Drawing.Point(290, 136);
			this.btnFieldLong.Name = "btnFieldLong";
			this.btnFieldLong.Size = new System.Drawing.Size(34, 24);
			this.btnFieldLong.TabIndex = 34;
			this.btnFieldLong.UseVisualStyleBackColor = true;
			this.btnFieldLong.Click += new System.EventHandler(this.BtnConfigurationFieldInformationAdd_Click);
			// 
			// tbLong
			// 
			this.tbLong.Location = new System.Drawing.Point(59, 139);
			this.tbLong.Name = "tbLong";
			this.tbLong.ReadOnly = true;
			this.tbLong.Size = new System.Drawing.Size(185, 20);
			this.tbLong.TabIndex = 33;
			// 
			// btnFieldInt
			// 
			this.btnFieldInt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFieldInt.BackgroundImage")));
			this.btnFieldInt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnFieldInt.Location = new System.Drawing.Point(290, 106);
			this.btnFieldInt.Name = "btnFieldInt";
			this.btnFieldInt.Size = new System.Drawing.Size(34, 24);
			this.btnFieldInt.TabIndex = 31;
			this.btnFieldInt.UseVisualStyleBackColor = true;
			this.btnFieldInt.Click += new System.EventHandler(this.BtnConfigurationFieldInformationAdd_Click);
			// 
			// tbInt
			// 
			this.tbInt.Location = new System.Drawing.Point(59, 109);
			this.tbInt.Name = "tbInt";
			this.tbInt.ReadOnly = true;
			this.tbInt.Size = new System.Drawing.Size(185, 20);
			this.tbInt.TabIndex = 30;
			// 
			// btnFieldShort
			// 
			this.btnFieldShort.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFieldShort.BackgroundImage")));
			this.btnFieldShort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnFieldShort.Location = new System.Drawing.Point(290, 76);
			this.btnFieldShort.Name = "btnFieldShort";
			this.btnFieldShort.Size = new System.Drawing.Size(34, 24);
			this.btnFieldShort.TabIndex = 28;
			this.btnFieldShort.UseVisualStyleBackColor = true;
			this.btnFieldShort.Click += new System.EventHandler(this.BtnConfigurationFieldInformationAdd_Click);
			// 
			// tbShort
			// 
			this.tbShort.Location = new System.Drawing.Point(59, 79);
			this.tbShort.Name = "tbShort";
			this.tbShort.ReadOnly = true;
			this.tbShort.Size = new System.Drawing.Size(185, 20);
			this.tbShort.TabIndex = 27;
			// 
			// btnFieldByte
			// 
			this.btnFieldByte.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFieldByte.BackgroundImage")));
			this.btnFieldByte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnFieldByte.Location = new System.Drawing.Point(290, 46);
			this.btnFieldByte.Name = "btnFieldByte";
			this.btnFieldByte.Size = new System.Drawing.Size(34, 24);
			this.btnFieldByte.TabIndex = 25;
			this.btnFieldByte.UseVisualStyleBackColor = true;
			this.btnFieldByte.Click += new System.EventHandler(this.BtnConfigurationFieldInformationAdd_Click);
			// 
			// tbByte
			// 
			this.tbByte.Location = new System.Drawing.Point(59, 49);
			this.tbByte.Name = "tbByte";
			this.tbByte.ReadOnly = true;
			this.tbByte.Size = new System.Drawing.Size(185, 20);
			this.tbByte.TabIndex = 24;
			// 
			// lblDoubleType
			// 
			this.lblDoubleType.AutoSize = true;
			this.lblDoubleType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblDoubleType.Location = new System.Drawing.Point(6, 320);
			this.lblDoubleType.Name = "lblDoubleType";
			this.lblDoubleType.Size = new System.Drawing.Size(82, 15);
			this.lblDoubleType.TabIndex = 23;
			this.lblDoubleType.Text = "Types.Double";
			// 
			// lblFloatType
			// 
			this.lblFloatType.AutoSize = true;
			this.lblFloatType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblFloatType.Location = new System.Drawing.Point(6, 170);
			this.lblFloatType.Name = "lblFloatType";
			this.lblFloatType.Size = new System.Drawing.Size(69, 15);
			this.lblFloatType.TabIndex = 22;
			this.lblFloatType.Text = "Types.Float";
			// 
			// lblUlongType
			// 
			this.lblUlongType.AutoSize = true;
			this.lblUlongType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblUlongType.Location = new System.Drawing.Point(6, 287);
			this.lblUlongType.Name = "lblUlongType";
			this.lblUlongType.Size = new System.Drawing.Size(75, 15);
			this.lblUlongType.TabIndex = 21;
			this.lblUlongType.Text = "Types.Ulong";
			// 
			// lblLongType
			// 
			this.lblLongType.AutoSize = true;
			this.lblLongType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblLongType.Location = new System.Drawing.Point(6, 140);
			this.lblLongType.Name = "lblLongType";
			this.lblLongType.Size = new System.Drawing.Size(70, 15);
			this.lblLongType.TabIndex = 20;
			this.lblLongType.Text = "Types.Long";
			// 
			// lblUintType
			// 
			this.lblUintType.AutoSize = true;
			this.lblUintType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblUintType.Location = new System.Drawing.Point(6, 260);
			this.lblUintType.Name = "lblUintType";
			this.lblUintType.Size = new System.Drawing.Size(64, 15);
			this.lblUintType.TabIndex = 19;
			this.lblUintType.Text = "Types.Uint";
			// 
			// lblIntType
			// 
			this.lblIntType.AutoSize = true;
			this.lblIntType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblIntType.Location = new System.Drawing.Point(6, 110);
			this.lblIntType.Name = "lblIntType";
			this.lblIntType.Size = new System.Drawing.Size(55, 15);
			this.lblIntType.TabIndex = 18;
			this.lblIntType.Text = "Types.Int";
			// 
			// lblUshortType
			// 
			this.lblUshortType.AutoSize = true;
			this.lblUshortType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblUshortType.Location = new System.Drawing.Point(6, 230);
			this.lblUshortType.Name = "lblUshortType";
			this.lblUshortType.Size = new System.Drawing.Size(78, 15);
			this.lblUshortType.TabIndex = 17;
			this.lblUshortType.Text = "Types.Ushort";
			// 
			// lblShortType
			// 
			this.lblShortType.AutoSize = true;
			this.lblShortType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblShortType.Location = new System.Drawing.Point(6, 80);
			this.lblShortType.Name = "lblShortType";
			this.lblShortType.Size = new System.Drawing.Size(71, 15);
			this.lblShortType.TabIndex = 16;
			this.lblShortType.Text = "Types.Short";
			// 
			// lblSbyteType
			// 
			this.lblSbyteType.AutoSize = true;
			this.lblSbyteType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblSbyteType.Location = new System.Drawing.Point(6, 200);
			this.lblSbyteType.Name = "lblSbyteType";
			this.lblSbyteType.Size = new System.Drawing.Size(72, 15);
			this.lblSbyteType.TabIndex = 15;
			this.lblSbyteType.Text = "Types.Sbyte";
			// 
			// lblByteType
			// 
			this.lblByteType.AutoSize = true;
			this.lblByteType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblByteType.Location = new System.Drawing.Point(6, 50);
			this.lblByteType.Name = "lblByteType";
			this.lblByteType.Size = new System.Drawing.Size(65, 15);
			this.lblByteType.TabIndex = 14;
			this.lblByteType.Text = "Types.Byte";
			// 
			// gbGeneralInformation
			// 
			this.gbGeneralInformation.Controls.Add(this.lblClassCount);
			this.gbGeneralInformation.Controls.Add(this.lblSelectedLength);
			this.gbGeneralInformation.Controls.Add(this.lblDataLength);
			this.gbGeneralInformation.Controls.Add(this.lblSelectedIndex);
			this.gbGeneralInformation.Location = new System.Drawing.Point(6, 6);
			this.gbGeneralInformation.Name = "gbGeneralInformation";
			this.gbGeneralInformation.Size = new System.Drawing.Size(330, 49);
			this.gbGeneralInformation.TabIndex = 38;
			this.gbGeneralInformation.TabStop = false;
			this.gbGeneralInformation.Text = "Editor.GeneralInformation";
			// 
			// lblClassCount
			// 
			this.lblClassCount.AutoSize = true;
			this.lblClassCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblClassCount.Location = new System.Drawing.Point(6, 16);
			this.lblClassCount.Name = "lblClassCount";
			this.lblClassCount.Size = new System.Drawing.Size(104, 15);
			this.lblClassCount.TabIndex = 14;
			this.lblClassCount.Text = "Editor.ClassCount";
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
			// lblDataLength
			// 
			this.lblDataLength.AutoSize = true;
			this.lblDataLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblDataLength.Location = new System.Drawing.Point(6, 31);
			this.lblDataLength.Name = "lblDataLength";
			this.lblDataLength.Size = new System.Drawing.Size(106, 15);
			this.lblDataLength.TabIndex = 15;
			this.lblDataLength.Text = "Editor.DataLength";
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
			// tcConfiguration
			// 
			this.tcConfiguration.Controls.Add(this.tpPacketInformation);
			this.tcConfiguration.Controls.Add(this.tpConfiguration);
			this.tcConfiguration.Controls.Add(this.tpBindings);
			this.tcConfiguration.Location = new System.Drawing.Point(928, 27);
			this.tcConfiguration.Name = "tcConfiguration";
			this.tcConfiguration.SelectedIndex = 0;
			this.tcConfiguration.Size = new System.Drawing.Size(350, 603);
			this.tcConfiguration.TabIndex = 16;
			this.tcConfiguration.SelectedIndexChanged += new System.EventHandler(this.TcConfiguration_SelectedIndexChanged);
			// 
			// tpConfiguration
			// 
			this.tpConfiguration.BackColor = System.Drawing.SystemColors.Control;
			this.tpConfiguration.Controls.Add(this.btnConfigurationAdd);
			this.tpConfiguration.Controls.Add(this.btnConfigurationDelete);
			this.tpConfiguration.Controls.Add(this.btnConfigurationFieldEdit);
			this.tpConfiguration.Controls.Add(this.btnConfigurationFieldDelete);
			this.tpConfiguration.Controls.Add(this.btnConfigurationFieldAdd);
			this.tpConfiguration.Controls.Add(this.dgvConfigurationFields);
			this.tpConfiguration.Controls.Add(this.tbConfigurationDescription);
			this.tpConfiguration.Controls.Add(this.lblConfigurationDescription);
			this.tpConfiguration.Controls.Add(this.lblConfigurationName);
			this.tpConfiguration.Controls.Add(this.tbConfigurationName);
			this.tpConfiguration.Location = new System.Drawing.Point(4, 22);
			this.tpConfiguration.Name = "tpConfiguration";
			this.tpConfiguration.Padding = new System.Windows.Forms.Padding(3);
			this.tpConfiguration.Size = new System.Drawing.Size(342, 577);
			this.tpConfiguration.TabIndex = 1;
			this.tpConfiguration.Text = "Editor.Configuration";
			// 
			// btnConfigurationAdd
			// 
			this.btnConfigurationAdd.Location = new System.Drawing.Point(6, 548);
			this.btnConfigurationAdd.Name = "btnConfigurationAdd";
			this.btnConfigurationAdd.Size = new System.Drawing.Size(162, 23);
			this.btnConfigurationAdd.TabIndex = 26;
			this.btnConfigurationAdd.Text = "Editor.ConfigurationAdd";
			this.btnConfigurationAdd.UseVisualStyleBackColor = true;
			this.btnConfigurationAdd.Click += new System.EventHandler(this.BtnConfigurationAdd_Click);
			// 
			// btnConfigurationDelete
			// 
			this.btnConfigurationDelete.Location = new System.Drawing.Point(174, 548);
			this.btnConfigurationDelete.Name = "btnConfigurationDelete";
			this.btnConfigurationDelete.Size = new System.Drawing.Size(162, 23);
			this.btnConfigurationDelete.TabIndex = 25;
			this.btnConfigurationDelete.Text = "Editor.ConfigurationDelete";
			this.btnConfigurationDelete.UseVisualStyleBackColor = true;
			this.btnConfigurationDelete.Click += new System.EventHandler(this.BtnConfigurationDelete_Click);
			// 
			// btnConfigurationFieldEdit
			// 
			this.btnConfigurationFieldEdit.Location = new System.Drawing.Point(118, 519);
			this.btnConfigurationFieldEdit.Name = "btnConfigurationFieldEdit";
			this.btnConfigurationFieldEdit.Size = new System.Drawing.Size(106, 23);
			this.btnConfigurationFieldEdit.TabIndex = 24;
			this.btnConfigurationFieldEdit.Text = "Editor.ConfigurationFieldEdit";
			this.btnConfigurationFieldEdit.UseVisualStyleBackColor = true;
			this.btnConfigurationFieldEdit.Click += new System.EventHandler(this.BtnConfigurationFieldEdit_Click);
			// 
			// btnConfigurationFieldDelete
			// 
			this.btnConfigurationFieldDelete.Location = new System.Drawing.Point(230, 519);
			this.btnConfigurationFieldDelete.Name = "btnConfigurationFieldDelete";
			this.btnConfigurationFieldDelete.Size = new System.Drawing.Size(106, 23);
			this.btnConfigurationFieldDelete.TabIndex = 23;
			this.btnConfigurationFieldDelete.Text = "Editor.ConfigurationFieldDelete";
			this.btnConfigurationFieldDelete.UseVisualStyleBackColor = true;
			this.btnConfigurationFieldDelete.Click += new System.EventHandler(this.BtnConfigurationFieldDelete_Click);
			// 
			// btnConfigurationFieldAdd
			// 
			this.btnConfigurationFieldAdd.Location = new System.Drawing.Point(6, 519);
			this.btnConfigurationFieldAdd.Name = "btnConfigurationFieldAdd";
			this.btnConfigurationFieldAdd.Size = new System.Drawing.Size(106, 23);
			this.btnConfigurationFieldAdd.TabIndex = 22;
			this.btnConfigurationFieldAdd.Text = "Editor.ConfigurationFieldAdd";
			this.btnConfigurationFieldAdd.UseVisualStyleBackColor = true;
			this.btnConfigurationFieldAdd.Click += new System.EventHandler(this.BtnConfigurationFieldAdd_Click);
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
			dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvConfigurationFields.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
			this.dgvConfigurationFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvConfigurationFields.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ConfigurationFieldPosition,
            this.ConfigurationFieldType,
            this.ConfigurationFieldName,
            this.ConfigurationFieldValue});
			dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvConfigurationFields.DefaultCellStyle = dataGridViewCellStyle14;
			this.dgvConfigurationFields.Location = new System.Drawing.Point(6, 117);
			this.dgvConfigurationFields.Name = "dgvConfigurationFields";
			this.dgvConfigurationFields.ReadOnly = true;
			dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvConfigurationFields.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
			this.dgvConfigurationFields.RowHeadersVisible = false;
			dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dgvConfigurationFields.RowsDefaultCellStyle = dataGridViewCellStyle16;
			this.dgvConfigurationFields.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvConfigurationFields.Size = new System.Drawing.Size(330, 396);
			this.dgvConfigurationFields.TabIndex = 22;
			// 
			// ConfigurationFieldPosition
			// 
			this.ConfigurationFieldPosition.HeaderText = "Editor.ConfigurationFieldPosition";
			this.ConfigurationFieldPosition.Name = "ConfigurationFieldPosition";
			this.ConfigurationFieldPosition.ReadOnly = true;
			this.ConfigurationFieldPosition.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.ConfigurationFieldPosition.Width = 75;
			// 
			// ConfigurationFieldType
			// 
			this.ConfigurationFieldType.HeaderText = "Editor.ConfigurationFieldType";
			this.ConfigurationFieldType.Name = "ConfigurationFieldType";
			this.ConfigurationFieldType.ReadOnly = true;
			this.ConfigurationFieldType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.ConfigurationFieldType.Width = 75;
			// 
			// ConfigurationFieldName
			// 
			this.ConfigurationFieldName.HeaderText = "Editor.ConfigurationFieldName";
			this.ConfigurationFieldName.Name = "ConfigurationFieldName";
			this.ConfigurationFieldName.ReadOnly = true;
			this.ConfigurationFieldName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.ConfigurationFieldName.Width = 150;
			// 
			// ConfigurationFieldValue
			// 
			this.ConfigurationFieldValue.HeaderText = "Editor.ConfigurationFieldValue";
			this.ConfigurationFieldValue.Name = "ConfigurationFieldValue";
			this.ConfigurationFieldValue.ReadOnly = true;
			this.ConfigurationFieldValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// tbConfigurationDescription
			// 
			this.tbConfigurationDescription.Location = new System.Drawing.Point(6, 66);
			this.tbConfigurationDescription.Multiline = true;
			this.tbConfigurationDescription.Name = "tbConfigurationDescription";
			this.tbConfigurationDescription.Size = new System.Drawing.Size(330, 45);
			this.tbConfigurationDescription.TabIndex = 22;
			this.tbConfigurationDescription.Leave += new System.EventHandler(this.TbConfigurationDescription_Leave);
			// 
			// lblConfigurationDescription
			// 
			this.lblConfigurationDescription.AutoSize = true;
			this.lblConfigurationDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblConfigurationDescription.Location = new System.Drawing.Point(6, 48);
			this.lblConfigurationDescription.Name = "lblConfigurationDescription";
			this.lblConfigurationDescription.Size = new System.Drawing.Size(177, 15);
			this.lblConfigurationDescription.TabIndex = 21;
			this.lblConfigurationDescription.Text = "Editor.ConfigurationDescription";
			// 
			// lblConfigurationName
			// 
			this.lblConfigurationName.AutoSize = true;
			this.lblConfigurationName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblConfigurationName.Location = new System.Drawing.Point(6, 7);
			this.lblConfigurationName.Name = "lblConfigurationName";
			this.lblConfigurationName.Size = new System.Drawing.Size(149, 15);
			this.lblConfigurationName.TabIndex = 20;
			this.lblConfigurationName.Text = "Editor.ConfigurationName";
			// 
			// tbConfigurationName
			// 
			this.tbConfigurationName.Location = new System.Drawing.Point(6, 25);
			this.tbConfigurationName.Name = "tbConfigurationName";
			this.tbConfigurationName.Size = new System.Drawing.Size(330, 20);
			this.tbConfigurationName.TabIndex = 19;
			this.tbConfigurationName.Leave += new System.EventHandler(this.TbConfigurationName_Leave);
			// 
			// tpBindings
			// 
			this.tpBindings.BackColor = System.Drawing.SystemColors.Control;
			this.tpBindings.Location = new System.Drawing.Point(4, 22);
			this.tpBindings.Name = "tpBindings";
			this.tpBindings.Padding = new System.Windows.Forms.Padding(3);
			this.tpBindings.Size = new System.Drawing.Size(342, 577);
			this.tpBindings.TabIndex = 2;
			this.tpBindings.Text = "Editor.Bindings";
			// 
			// Editor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1290, 655);
			this.Controls.Add(this.tcConfiguration);
			this.Controls.Add(this.gbHexEditor);
			this.Controls.Add(this.lblInformation);
			this.Controls.Add(this.tcGeneral);
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
			this.tcGeneral.ResumeLayout(false);
			this.tpPackets.ResumeLayout(false);
			this.tpPackets.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvPackets)).EndInit();
			this.tpConfigurationPackets.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvConfigurationPackets)).EndInit();
			this.tpStructures.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvStructures)).EndInit();
			this.gbHexEditor.ResumeLayout(false);
			this.gbHexEditor.PerformLayout();
			this.tpPacketInformation.ResumeLayout(false);
			this.gbDataTypes.ResumeLayout(false);
			this.gbDataTypes.PerformLayout();
			this.gbGeneralInformation.ResumeLayout(false);
			this.gbGeneralInformation.PerformLayout();
			this.tcConfiguration.ResumeLayout(false);
			this.tpConfiguration.ResumeLayout(false);
			this.tpConfiguration.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvConfigurationFields)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.TabControl tcGeneral;
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
		private System.Windows.Forms.Label lblClassCount;
		private System.Windows.Forms.Label lblSelectedLength;
		private System.Windows.Forms.Label lblDataLength;
		private System.Windows.Forms.Label lblSelectedIndex;
		private System.Windows.Forms.TabControl tcConfiguration;
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
		private System.Windows.Forms.TextBox tbConfigurationName;
		private System.Windows.Forms.TextBox tbConfigurationDescription;
		private System.Windows.Forms.Label lblConfigurationDescription;
		private System.Windows.Forms.DataGridView dgvConfigurationFields;
		private System.Windows.Forms.Button btnConfigurationFieldDelete;
		private System.Windows.Forms.Button btnConfigurationFieldAdd;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createConfigurationToolStripMenuItem;
        private System.Windows.Forms.TextBox tbByte;
        private System.Windows.Forms.Button btnFieldByte;
        private System.Windows.Forms.Button btnFieldDouble;
        private System.Windows.Forms.TextBox tbDouble;
        private System.Windows.Forms.Button btnFieldUlong;
        private System.Windows.Forms.TextBox tbUlong;
        private System.Windows.Forms.Button btnFieldUint;
        private System.Windows.Forms.TextBox tbUint;
        private System.Windows.Forms.Button btnFieldUshort;
        private System.Windows.Forms.TextBox tbUshort;
        private System.Windows.Forms.Button btnFieldSbyte;
        private System.Windows.Forms.TextBox tbSbyte;
        private System.Windows.Forms.Button btnFieldFloat;
        private System.Windows.Forms.TextBox tbFloat;
        private System.Windows.Forms.Button btnFieldLong;
        private System.Windows.Forms.TextBox tbLong;
        private System.Windows.Forms.Button btnFieldInt;
        private System.Windows.Forms.TextBox tbInt;
        private System.Windows.Forms.Button btnFieldShort;
        private System.Windows.Forms.TextBox tbShort;
        private System.Windows.Forms.Label lblSequenceType;
		private System.Windows.Forms.Button btnConfigurationFieldEdit;
		private System.Windows.Forms.TabPage tpBindings;
		private System.Windows.Forms.TabPage tpStructures;
		private System.Windows.Forms.DataGridView dgvStructures;
		private System.Windows.Forms.DataGridViewTextBoxColumn ConfigurationFieldPosition;
		private System.Windows.Forms.DataGridViewTextBoxColumn ConfigurationFieldType;
		private System.Windows.Forms.DataGridViewTextBoxColumn ConfigurationFieldName;
		private System.Windows.Forms.DataGridViewTextBoxColumn ConfigurationFieldValue;
		private System.Windows.Forms.DataGridViewTextBoxColumn PacketNumber;
		private System.Windows.Forms.DataGridViewTextBoxColumn PacketId;
		private System.Windows.Forms.DataGridViewTextBoxColumn PacketOpcode;
		private System.Windows.Forms.DataGridViewTextBoxColumn PacketName;
		private System.Windows.Forms.DataGridViewTextBoxColumn StructureNumber;
		private System.Windows.Forms.DataGridViewTextBoxColumn StructureName;
		private System.Windows.Forms.Button btnConfigurationAdd;
		private System.Windows.Forms.Button btnConfigurationDelete;
		private System.Windows.Forms.TabPage tpConfigurationPackets;
		private System.Windows.Forms.DataGridView dgvConfigurationPackets;
		private System.Windows.Forms.DataGridViewTextBoxColumn ConfigurationPacketNumber;
		private System.Windows.Forms.DataGridViewTextBoxColumn ConfigurationPacketOpcode;
		private System.Windows.Forms.DataGridViewTextBoxColumn ConfigurationPacketName;
		private System.Windows.Forms.Button btnFieldString;
		private System.Windows.Forms.TextBox tbString;
		private System.Windows.Forms.Label lblStringType;
		private System.Windows.Forms.Button btnCopyByte;
		private System.Windows.Forms.Button btnCopyShort;
		private System.Windows.Forms.Button btnCopyInt;
		private System.Windows.Forms.Button btnCopyLong;
		private System.Windows.Forms.Button btnCopyFloat;
		private System.Windows.Forms.Button btnCopySbyte;
		private System.Windows.Forms.Button btnCopyUshort;
		private System.Windows.Forms.Button btnCopyUint;
		private System.Windows.Forms.Button btnCopyUlong;
		private System.Windows.Forms.Button btnCopyDouble;
		private System.Windows.Forms.Button btnCopyString;
	}
}