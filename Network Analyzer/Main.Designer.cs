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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.msMenu = new System.Windows.Forms.MenuStrip();
            this.lblVersion = new System.Windows.Forms.Label();
            this.gbConnectionsWork = new System.Windows.Forms.GroupBox();
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
            this.gbConnectionsGridWork = new System.Windows.Forms.GroupBox();
            this.btnClearConnentions = new System.Windows.Forms.Button();
            this.lblAllConnections = new System.Windows.Forms.Label();
            this.lblAllConnectionsText = new System.Windows.Forms.Label();
            this.btnUpdateDataGridView = new System.Windows.Forms.Button();
            this.btnClearDataGridView = new System.Windows.Forms.Button();
            this.cbAutoUpdateDataGridView = new System.Windows.Forms.CheckBox();
            this.gbControl = new System.Windows.Forms.GroupBox();
            this.btnRollToTray = new System.Windows.Forms.Button();
            this.btnStopListener = new System.Windows.Forms.Button();
            this.btnStartListener = new System.Windows.Forms.Button();
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
            this.msMenu.Location = new System.Drawing.Point(0, 0);
            this.msMenu.Name = "msMenu";
            this.msMenu.Size = new System.Drawing.Size(870, 24);
            this.msMenu.TabIndex = 0;
            this.msMenu.Text = "menuStrip1";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(777, 364);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(81, 13);
            this.lblVersion.TabIndex = 12;
            this.lblVersion.Text = "Main.Version";
            // 
            // gbConnectionsWork
            // 
            this.gbConnectionsWork.Controls.Add(this.btnSaveConnections);
            this.gbConnectionsWork.Controls.Add(this.btnLoadConnections);
            this.gbConnectionsWork.Location = new System.Drawing.Point(12, 110);
            this.gbConnectionsWork.Name = "gbConnectionsWork";
            this.gbConnectionsWork.Size = new System.Drawing.Size(202, 77);
            this.gbConnectionsWork.TabIndex = 8;
            this.gbConnectionsWork.TabStop = false;
            this.gbConnectionsWork.Text = "Main.ConnectionsWork";
            // 
            // btnSaveConnections
            // 
            this.btnSaveConnections.Location = new System.Drawing.Point(6, 48);
            this.btnSaveConnections.Name = "btnSaveConnections";
            this.btnSaveConnections.Size = new System.Drawing.Size(190, 23);
            this.btnSaveConnections.TabIndex = 1;
            this.btnSaveConnections.Text = "Main.SaveConnections";
            this.btnSaveConnections.UseVisualStyleBackColor = true;
            // 
            // btnLoadConnections
            // 
            this.btnLoadConnections.Location = new System.Drawing.Point(6, 19);
            this.btnLoadConnections.Name = "btnLoadConnections";
            this.btnLoadConnections.Size = new System.Drawing.Size(190, 23);
            this.btnLoadConnections.TabIndex = 0;
            this.btnLoadConnections.Text = "Main.LoadConnections";
            this.btnLoadConnections.UseVisualStyleBackColor = true;
            // 
            // lblInformation
            // 
            this.lblInformation.AutoSize = true;
            this.lblInformation.Location = new System.Drawing.Point(12, 364);
            this.lblInformation.Name = "lblInformation";
            this.lblInformation.Size = new System.Drawing.Size(160, 13);
            this.lblInformation.TabIndex = 11;
            this.lblInformation.Text = "Main.Information";
            // 
            // gbConnections
            // 
            this.gbConnections.Controls.Add(this.dgvConnections);
            this.gbConnections.Location = new System.Drawing.Point(220, 27);
            this.gbConnections.Name = "gbConnections";
            this.gbConnections.Size = new System.Drawing.Size(638, 334);
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConnections.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvConnections.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvConnections.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConnections.Size = new System.Drawing.Size(626, 309);
            this.dgvConnections.TabIndex = 1;
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
            // gbConnectionsGridWork
            // 
            this.gbConnectionsGridWork.Controls.Add(this.btnClearConnentions);
            this.gbConnectionsGridWork.Controls.Add(this.lblAllConnections);
            this.gbConnectionsGridWork.Controls.Add(this.lblAllConnectionsText);
            this.gbConnectionsGridWork.Controls.Add(this.btnUpdateDataGridView);
            this.gbConnectionsGridWork.Controls.Add(this.btnClearDataGridView);
            this.gbConnectionsGridWork.Controls.Add(this.cbAutoUpdateDataGridView);
            this.gbConnectionsGridWork.Location = new System.Drawing.Point(12, 193);
            this.gbConnectionsGridWork.Name = "gbConnectionsGridWork";
            this.gbConnectionsGridWork.Size = new System.Drawing.Size(202, 168);
            this.gbConnectionsGridWork.TabIndex = 9;
            this.gbConnectionsGridWork.TabStop = false;
            this.gbConnectionsGridWork.Text = "Main.ConnectionsGridWork";
            // 
            // btnClearConnentions
            // 
            this.btnClearConnentions.Location = new System.Drawing.Point(6, 74);
            this.btnClearConnentions.Name = "btnClearConnentions";
            this.btnClearConnentions.Size = new System.Drawing.Size(190, 23);
            this.btnClearConnentions.TabIndex = 9;
            this.btnClearConnentions.Text = "Main.ClearConnentions";
            this.btnClearConnentions.UseVisualStyleBackColor = true;
            // 
            // lblAllConnections
            // 
            this.lblAllConnections.AutoSize = true;
            this.lblAllConnections.Location = new System.Drawing.Point(115, 16);
            this.lblAllConnections.Name = "lblAllConnections";
            this.lblAllConnections.Size = new System.Drawing.Size(13, 13);
            this.lblAllConnections.TabIndex = 8;
            this.lblAllConnections.Text = "0";
            // 
            // lblAllConnectionsText
            // 
            this.lblAllConnectionsText.AutoSize = true;
            this.lblAllConnectionsText.Location = new System.Drawing.Point(6, 16);
            this.lblAllConnectionsText.Name = "lblAllConnectionsText";
            this.lblAllConnectionsText.Size = new System.Drawing.Size(103, 13);
            this.lblAllConnectionsText.TabIndex = 7;
            this.lblAllConnectionsText.Text = "Main.AllConnections";
            // 
            // btnUpdateDataGridView
            // 
            this.btnUpdateDataGridView.Location = new System.Drawing.Point(6, 115);
            this.btnUpdateDataGridView.Name = "btnUpdateDataGridView";
            this.btnUpdateDataGridView.Size = new System.Drawing.Size(190, 23);
            this.btnUpdateDataGridView.TabIndex = 6;
            this.btnUpdateDataGridView.Text = "Main.UpdateDataGridView";
            this.btnUpdateDataGridView.UseVisualStyleBackColor = true;
            // 
            // btnClearDataGridView
            // 
            this.btnClearDataGridView.Location = new System.Drawing.Point(6, 44);
            this.btnClearDataGridView.Name = "btnClearDataGridView";
            this.btnClearDataGridView.Size = new System.Drawing.Size(190, 23);
            this.btnClearDataGridView.TabIndex = 5;
            this.btnClearDataGridView.Text = "Main.ClearDataGridView";
            this.btnClearDataGridView.UseVisualStyleBackColor = true;
            // 
            // cbAutoUpdateDataGridView
            // 
            this.cbAutoUpdateDataGridView.AutoSize = true;
            this.cbAutoUpdateDataGridView.Location = new System.Drawing.Point(6, 144);
            this.cbAutoUpdateDataGridView.Name = "cbAutoUpdateDataGridView";
            this.cbAutoUpdateDataGridView.Size = new System.Drawing.Size(173, 17);
            this.cbAutoUpdateDataGridView.TabIndex = 3;
            this.cbAutoUpdateDataGridView.Text = "Main.AutoUpdateDataGridView";
            this.cbAutoUpdateDataGridView.UseVisualStyleBackColor = true;
            // 
            // gbControl
            // 
            this.gbControl.Controls.Add(this.btnRollToTray);
            this.gbControl.Controls.Add(this.btnStopListener);
            this.gbControl.Controls.Add(this.btnStartListener);
            this.gbControl.Location = new System.Drawing.Point(12, 27);
            this.gbControl.Name = "gbControl";
            this.gbControl.Size = new System.Drawing.Size(202, 77);
            this.gbControl.TabIndex = 7;
            this.gbControl.TabStop = false;
            this.gbControl.Text = "Main.Control";
            // 
            // btnRollToTray
            // 
            this.btnRollToTray.Enabled = false;
            this.btnRollToTray.Location = new System.Drawing.Point(6, 48);
            this.btnRollToTray.Name = "btnRollToTray";
            this.btnRollToTray.Size = new System.Drawing.Size(190, 23);
            this.btnRollToTray.TabIndex = 2;
            this.btnRollToTray.Text = "Main.RollToTray";
            this.btnRollToTray.UseVisualStyleBackColor = true;
            // 
            // btnStopListener
            // 
            this.btnStopListener.Enabled = false;
            this.btnStopListener.Location = new System.Drawing.Point(104, 19);
            this.btnStopListener.Name = "btnStopListener";
            this.btnStopListener.Size = new System.Drawing.Size(92, 23);
            this.btnStopListener.TabIndex = 1;
            this.btnStopListener.Text = "Main.StopListener";
            this.btnStopListener.UseVisualStyleBackColor = true;
            // 
            // btnStartListener
            // 
            this.btnStartListener.Location = new System.Drawing.Point(6, 19);
            this.btnStartListener.Name = "btnStartListener";
            this.btnStartListener.Size = new System.Drawing.Size(92, 23);
            this.btnStartListener.TabIndex = 0;
            this.btnStartListener.Text = "Main.StartListener";
            this.btnStartListener.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 386);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.gbConnectionsWork);
            this.Controls.Add(this.lblInformation);
            this.Controls.Add(this.gbConnections);
            this.Controls.Add(this.gbConnectionsGridWork);
            this.Controls.Add(this.gbControl);
            this.Controls.Add(this.msMenu);
            this.MainMenuStrip = this.msMenu;
            this.Name = "Main";
            this.Text = "Main.Text";
            this.gbConnectionsWork.ResumeLayout(false);
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
        private System.Windows.Forms.Label lblAllConnectionsText;
        private System.Windows.Forms.Button btnUpdateDataGridView;
        private System.Windows.Forms.Button btnClearDataGridView;
        private System.Windows.Forms.CheckBox cbAutoUpdateDataGridView;
        private System.Windows.Forms.GroupBox gbControl;
        private System.Windows.Forms.Button btnRollToTray;
        private System.Windows.Forms.Button btnStopListener;
        private System.Windows.Forms.Button btnStartListener;
    }
}

