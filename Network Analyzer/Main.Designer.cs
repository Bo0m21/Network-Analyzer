using Network_Analyzer.Localization;

namespace Network_Analyzer
{
    partial class Main
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.msMenu = new System.Windows.Forms.MenuStrip();
            this.listenerWorkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startListenerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopListenerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionsWorkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadConnectionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveConnectionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionsGridWorkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearConnentionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateDataGridViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblVersion = new System.Windows.Forms.Label();
            this.gbConnectionsWork = new System.Windows.Forms.GroupBox();
            this.cbAutoSaveConnections = new System.Windows.Forms.CheckBox();
            this.btnSaveConnections = new System.Windows.Forms.Button();
            this.btnLoadConnections = new System.Windows.Forms.Button();
            this.lblInformation = new System.Windows.Forms.Label();
            this.gbConnections = new System.Windows.Forms.GroupBox();
            this.dgvConnections = new System.Windows.Forms.DataGridView();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServerAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Received = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Send = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Disconnected = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblAllConnections = new System.Windows.Forms.Label();
            this.gbConnectionsGridWork = new System.Windows.Forms.GroupBox();
            this.btnClearConnentions = new System.Windows.Forms.Button();
            this.btnUpdateDataGridView = new System.Windows.Forms.Button();
            this.cbAutoUpdateDataGridView = new System.Windows.Forms.CheckBox();
            this.gbControl = new System.Windows.Forms.GroupBox();
            this.btnStopListener = new System.Windows.Forms.Button();
            this.btnStartListener = new System.Windows.Forms.Button();
            this.msMenu.SuspendLayout();
            this.gbConnectionsWork.SuspendLayout();
            this.gbConnections.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConnections)).BeginInit();
            this.gbConnectionsGridWork.SuspendLayout();
            this.gbControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMenu
            // 
            this.msMenu.BackColor = System.Drawing.SystemColors.Control;
            this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listenerWorkToolStripMenuItem,
            this.connectionsWorkToolStripMenuItem,
            this.connectionsGridWorkToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.msMenu.Location = new System.Drawing.Point(0, 0);
            this.msMenu.Name = "msMenu";
            this.msMenu.Size = new System.Drawing.Size(870, 24);
            this.msMenu.TabIndex = 0;
            this.msMenu.Text = "menuStrip1";
            // 
            // listenerWorkToolStripMenuItem
            // 
            this.listenerWorkToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startListenerToolStripMenuItem,
            this.stopListenerToolStripMenuItem});
            this.listenerWorkToolStripMenuItem.Name = "listenerWorkToolStripMenuItem";
            this.listenerWorkToolStripMenuItem.Size = new System.Drawing.Size(118, 20);
            this.listenerWorkToolStripMenuItem.Text = "Main.ListenerWork";
            // 
            // startListenerToolStripMenuItem
            // 
            this.startListenerToolStripMenuItem.Name = "startListenerToolStripMenuItem";
            this.startListenerToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.startListenerToolStripMenuItem.Text = "Main.StartListener";
            this.startListenerToolStripMenuItem.Click += new System.EventHandler(this.BtnStartListener_Click);
            // 
            // stopListenerToolStripMenuItem
            // 
            this.stopListenerToolStripMenuItem.Name = "stopListenerToolStripMenuItem";
            this.stopListenerToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.stopListenerToolStripMenuItem.Text = "Main.StopListener";
            this.stopListenerToolStripMenuItem.Click += new System.EventHandler(this.BtnStopListener_Click);
            // 
            // connectionsWorkToolStripMenuItem
            // 
            this.connectionsWorkToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadConnectionsToolStripMenuItem,
            this.saveConnectionsToolStripMenuItem});
            this.connectionsWorkToolStripMenuItem.Name = "connectionsWorkToolStripMenuItem";
            this.connectionsWorkToolStripMenuItem.Size = new System.Drawing.Size(144, 20);
            this.connectionsWorkToolStripMenuItem.Text = "Main.ConnectionsWork";
            // 
            // loadConnectionsToolStripMenuItem
            // 
            this.loadConnectionsToolStripMenuItem.Name = "loadConnectionsToolStripMenuItem";
            this.loadConnectionsToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.loadConnectionsToolStripMenuItem.Text = "Main.LoadConnections";
            this.loadConnectionsToolStripMenuItem.Click += new System.EventHandler(this.BtnLoadConnections_Click);
            // 
            // saveConnectionsToolStripMenuItem
            // 
            this.saveConnectionsToolStripMenuItem.Name = "saveConnectionsToolStripMenuItem";
            this.saveConnectionsToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.saveConnectionsToolStripMenuItem.Text = "Main.SaveConnections";
            this.saveConnectionsToolStripMenuItem.Click += new System.EventHandler(this.BtnSaveConnections_Click);
            // 
            // connectionsGridWorkToolStripMenuItem
            // 
            this.connectionsGridWorkToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearConnentionsToolStripMenuItem,
            this.updateDataGridViewToolStripMenuItem});
            this.connectionsGridWorkToolStripMenuItem.Name = "connectionsGridWorkToolStripMenuItem";
            this.connectionsGridWorkToolStripMenuItem.Size = new System.Drawing.Size(166, 20);
            this.connectionsGridWorkToolStripMenuItem.Text = "Main.ConnectionsGridWork";
            // 
            // clearConnentionsToolStripMenuItem
            // 
            this.clearConnentionsToolStripMenuItem.Name = "clearConnentionsToolStripMenuItem";
            this.clearConnentionsToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.clearConnentionsToolStripMenuItem.Text = "Main.ClearConnentions";
            this.clearConnentionsToolStripMenuItem.Click += new System.EventHandler(this.BtnClearConnentions_Click);
            // 
            // updateDataGridViewToolStripMenuItem
            // 
            this.updateDataGridViewToolStripMenuItem.Name = "updateDataGridViewToolStripMenuItem";
            this.updateDataGridViewToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.updateDataGridViewToolStripMenuItem.Text = "Main.UpdateDataGridView";
            this.updateDataGridViewToolStripMenuItem.Click += new System.EventHandler(this.BtnUpdateDataGridView_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.settingsToolStripMenuItem.Text = "Main.Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // lblVersion
            // 
            this.lblVersion.Location = new System.Drawing.Point(727, 320);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(125, 13);
            this.lblVersion.TabIndex = 12;
            this.lblVersion.Text = "Main.Version";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // gbConnectionsWork
            // 
            this.gbConnectionsWork.Controls.Add(this.cbAutoSaveConnections);
            this.gbConnectionsWork.Controls.Add(this.btnSaveConnections);
            this.gbConnectionsWork.Controls.Add(this.btnLoadConnections);
            this.gbConnectionsWork.Location = new System.Drawing.Point(12, 111);
            this.gbConnectionsWork.Name = "gbConnectionsWork";
            this.gbConnectionsWork.Size = new System.Drawing.Size(202, 100);
            this.gbConnectionsWork.TabIndex = 8;
            this.gbConnectionsWork.TabStop = false;
            this.gbConnectionsWork.Text = "Main.ConnectionsWork";
            // 
            // cbAutoSaveConnections
            // 
            this.cbAutoSaveConnections.AutoSize = true;
            this.cbAutoSaveConnections.Location = new System.Drawing.Point(6, 77);
            this.cbAutoSaveConnections.Name = "cbAutoSaveConnections";
            this.cbAutoSaveConnections.Size = new System.Drawing.Size(158, 17);
            this.cbAutoSaveConnections.TabIndex = 4;
            this.cbAutoSaveConnections.Text = "Main.AutoSaveConnections";
            this.cbAutoSaveConnections.UseVisualStyleBackColor = true;
            this.cbAutoSaveConnections.CheckedChanged += new System.EventHandler(this.CbAutoSaveConnections_CheckedChanged);
            // 
            // btnSaveConnections
            // 
            this.btnSaveConnections.Location = new System.Drawing.Point(6, 48);
            this.btnSaveConnections.Name = "btnSaveConnections";
            this.btnSaveConnections.Size = new System.Drawing.Size(190, 23);
            this.btnSaveConnections.TabIndex = 1;
            this.btnSaveConnections.Text = "Main.SaveConnections";
            this.btnSaveConnections.UseVisualStyleBackColor = true;
            this.btnSaveConnections.Click += new System.EventHandler(this.BtnSaveConnections_Click);
            // 
            // btnLoadConnections
            // 
            this.btnLoadConnections.Location = new System.Drawing.Point(6, 19);
            this.btnLoadConnections.Name = "btnLoadConnections";
            this.btnLoadConnections.Size = new System.Drawing.Size(190, 23);
            this.btnLoadConnections.TabIndex = 0;
            this.btnLoadConnections.Text = "Main.LoadConnections";
            this.btnLoadConnections.UseVisualStyleBackColor = true;
            this.btnLoadConnections.Click += new System.EventHandler(this.BtnLoadConnections_Click);
            // 
            // lblInformation
            // 
            this.lblInformation.AutoSize = true;
            this.lblInformation.Location = new System.Drawing.Point(12, 320);
            this.lblInformation.Name = "lblInformation";
            this.lblInformation.Size = new System.Drawing.Size(85, 13);
            this.lblInformation.TabIndex = 11;
            this.lblInformation.Text = "Main.Information";
            // 
            // gbConnections
            // 
            this.gbConnections.Controls.Add(this.dgvConnections);
            this.gbConnections.Controls.Add(this.lblAllConnections);
            this.gbConnections.Location = new System.Drawing.Point(220, 27);
            this.gbConnections.Name = "gbConnections";
            this.gbConnections.Size = new System.Drawing.Size(638, 290);
            this.gbConnections.TabIndex = 10;
            this.gbConnections.TabStop = false;
            this.gbConnections.Text = "Main.Connections";
            // 
            // dgvConnections
            // 
            this.dgvConnections.AllowDrop = true;
            this.dgvConnections.AllowUserToAddRows = false;
            this.dgvConnections.AllowUserToDeleteRows = false;
            this.dgvConnections.AllowUserToOrderColumns = true;
            this.dgvConnections.AllowUserToResizeColumns = false;
            this.dgvConnections.AllowUserToResizeRows = false;
            this.dgvConnections.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConnections.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvConnections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConnections.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number,
            this.Id,
            this.ClientAddress,
            this.ServerAddress,
            this.Received,
            this.Send,
            this.Disconnected});
            this.dgvConnections.Location = new System.Drawing.Point(6, 19);
            this.dgvConnections.Name = "dgvConnections";
            this.dgvConnections.ReadOnly = true;
            this.dgvConnections.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvConnections.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvConnections.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConnections.Size = new System.Drawing.Size(626, 265);
            this.dgvConnections.TabIndex = 1;
            this.dgvConnections.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvConnections_CellDoubleClick);
            this.dgvConnections.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvConnections_KeyDown);
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
            // ClientAddress
            // 
            this.ClientAddress.HeaderText = "Main.Connections.ClientAddress";
            this.ClientAddress.Name = "ClientAddress";
            this.ClientAddress.ReadOnly = true;
            this.ClientAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ClientAddress.Width = 150;
            // 
            // ServerAddress
            // 
            this.ServerAddress.HeaderText = "Main.Connections.ServerAddress";
            this.ServerAddress.Name = "ServerAddress";
            this.ServerAddress.ReadOnly = true;
            this.ServerAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ServerAddress.Width = 150;
            // 
            // Received
            // 
            this.Received.HeaderText = "Main.Connections.Received";
            this.Received.Name = "Received";
            this.Received.ReadOnly = true;
            this.Received.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Received.Width = 85;
            // 
            // Send
            // 
            this.Send.HeaderText = "Main.Connections.Send";
            this.Send.Name = "Send";
            this.Send.ReadOnly = true;
            this.Send.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Send.Width = 85;
            // 
            // Disconnected
            // 
            this.Disconnected.HeaderText = "Main.Connections.Disconnected";
            this.Disconnected.Name = "Disconnected";
            this.Disconnected.ReadOnly = true;
            this.Disconnected.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Disconnected.Width = 86;
            // 
            // lblAllConnections
            // 
            this.lblAllConnections.Location = new System.Drawing.Point(497, 0);
            this.lblAllConnections.Name = "lblAllConnections";
            this.lblAllConnections.Size = new System.Drawing.Size(135, 13);
            this.lblAllConnections.TabIndex = 7;
            this.lblAllConnections.Text = "Main.AllConnections";
            this.lblAllConnections.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // gbConnectionsGridWork
            // 
            this.gbConnectionsGridWork.Controls.Add(this.btnClearConnentions);
            this.gbConnectionsGridWork.Controls.Add(this.btnUpdateDataGridView);
            this.gbConnectionsGridWork.Controls.Add(this.cbAutoUpdateDataGridView);
            this.gbConnectionsGridWork.Location = new System.Drawing.Point(12, 217);
            this.gbConnectionsGridWork.Name = "gbConnectionsGridWork";
            this.gbConnectionsGridWork.Size = new System.Drawing.Size(202, 100);
            this.gbConnectionsGridWork.TabIndex = 9;
            this.gbConnectionsGridWork.TabStop = false;
            this.gbConnectionsGridWork.Text = "Main.ConnectionsGridWork";
            // 
            // btnClearConnentions
            // 
            this.btnClearConnentions.Location = new System.Drawing.Point(6, 19);
            this.btnClearConnentions.Name = "btnClearConnentions";
            this.btnClearConnentions.Size = new System.Drawing.Size(190, 23);
            this.btnClearConnentions.TabIndex = 9;
            this.btnClearConnentions.Text = "Main.ClearConnentions";
            this.btnClearConnentions.UseVisualStyleBackColor = true;
            this.btnClearConnentions.Click += new System.EventHandler(this.BtnClearConnentions_Click);
            // 
            // btnUpdateDataGridView
            // 
            this.btnUpdateDataGridView.Location = new System.Drawing.Point(6, 48);
            this.btnUpdateDataGridView.Name = "btnUpdateDataGridView";
            this.btnUpdateDataGridView.Size = new System.Drawing.Size(190, 23);
            this.btnUpdateDataGridView.TabIndex = 6;
            this.btnUpdateDataGridView.Text = "Main.UpdateDataGridView";
            this.btnUpdateDataGridView.UseVisualStyleBackColor = true;
            this.btnUpdateDataGridView.Click += new System.EventHandler(this.BtnUpdateDataGridView_Click);
            // 
            // cbAutoUpdateDataGridView
            // 
            this.cbAutoUpdateDataGridView.AutoSize = true;
            this.cbAutoUpdateDataGridView.Location = new System.Drawing.Point(6, 77);
            this.cbAutoUpdateDataGridView.Name = "cbAutoUpdateDataGridView";
            this.cbAutoUpdateDataGridView.Size = new System.Drawing.Size(174, 17);
            this.cbAutoUpdateDataGridView.TabIndex = 3;
            this.cbAutoUpdateDataGridView.Text = "Main.AutoUpdateDataGridView";
            this.cbAutoUpdateDataGridView.UseVisualStyleBackColor = true;
            this.cbAutoUpdateDataGridView.CheckedChanged += new System.EventHandler(this.CbAutoUpdateDataGridView_CheckedChanged);
            // 
            // gbControl
            // 
            this.gbControl.Controls.Add(this.btnStopListener);
            this.gbControl.Controls.Add(this.btnStartListener);
            this.gbControl.Location = new System.Drawing.Point(12, 27);
            this.gbControl.Name = "gbControl";
            this.gbControl.Size = new System.Drawing.Size(202, 78);
            this.gbControl.TabIndex = 7;
            this.gbControl.TabStop = false;
            this.gbControl.Text = "Main.ListenerWork";
            // 
            // btnStopListener
            // 
            this.btnStopListener.Enabled = false;
            this.btnStopListener.Location = new System.Drawing.Point(6, 48);
            this.btnStopListener.Name = "btnStopListener";
            this.btnStopListener.Size = new System.Drawing.Size(190, 23);
            this.btnStopListener.TabIndex = 1;
            this.btnStopListener.Text = "Main.StopListener";
            this.btnStopListener.UseVisualStyleBackColor = true;
            this.btnStopListener.Click += new System.EventHandler(this.BtnStopListener_Click);
            // 
            // btnStartListener
            // 
            this.btnStartListener.Location = new System.Drawing.Point(6, 19);
            this.btnStartListener.Name = "btnStartListener";
            this.btnStartListener.Size = new System.Drawing.Size(190, 23);
            this.btnStartListener.TabIndex = 0;
            this.btnStartListener.Text = "Main.StartListener";
            this.btnStartListener.UseVisualStyleBackColor = true;
            this.btnStartListener.Click += new System.EventHandler(this.BtnStartListener_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 342);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.gbConnectionsWork);
            this.Controls.Add(this.lblInformation);
            this.Controls.Add(this.gbConnections);
            this.Controls.Add(this.gbConnectionsGridWork);
            this.Controls.Add(this.gbControl);
            this.Controls.Add(this.msMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMenu;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Main.Text";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.msMenu.ResumeLayout(false);
            this.msMenu.PerformLayout();
            this.gbConnectionsWork.ResumeLayout(false);
            this.gbConnectionsWork.PerformLayout();
            this.gbConnections.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConnections)).EndInit();
            this.gbConnectionsGridWork.ResumeLayout(false);
            this.gbConnectionsGridWork.PerformLayout();
            this.gbControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.GroupBox gbConnectionsWork;
        private System.Windows.Forms.Button btnSaveConnections;
        private System.Windows.Forms.Button btnLoadConnections;
        private System.Windows.Forms.Label lblInformation;
        private System.Windows.Forms.GroupBox gbConnections;
        private System.Windows.Forms.DataGridView dgvConnections;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServerAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Received;
        private System.Windows.Forms.DataGridViewTextBoxColumn Send;
        private System.Windows.Forms.DataGridViewTextBoxColumn Disconnected;
        private System.Windows.Forms.GroupBox gbConnectionsGridWork;
        private System.Windows.Forms.Button btnClearConnentions;
        private System.Windows.Forms.Label lblAllConnections;
        private System.Windows.Forms.Button btnUpdateDataGridView;
        private System.Windows.Forms.CheckBox cbAutoUpdateDataGridView;
        private System.Windows.Forms.GroupBox gbControl;
        private System.Windows.Forms.Button btnStopListener;
        private System.Windows.Forms.Button btnStartListener;
        private System.Windows.Forms.ToolStripMenuItem listenerWorkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startListenerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopListenerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionsWorkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadConnectionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveConnectionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionsGridWorkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearConnentionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateDataGridViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.CheckBox cbAutoSaveConnections;
    }
}

