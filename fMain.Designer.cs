namespace KT_Timer_App
{
    partial class fMain
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            this.timerLbTimeNow = new System.Windows.Forms.Timer(this.components);
            this.kryptonPalette1 = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            this.pnContainer = new System.Windows.Forms.Panel();
            this.pnMain = new System.Windows.Forms.Panel();
            this.flpTaskList = new System.Windows.Forms.FlowLayoutPanel();
            this.pnAddNewTask = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.lbClearTxbTaskName = new System.Windows.Forms.Label();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txbTaskName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.dtpTaskStartTime = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.btnAddNewTask = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.pnLog = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.dgvLog = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Task = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Log = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnHeader = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.lbTimeNow = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.pnBar = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pbSaveData = new System.Windows.Forms.PictureBox();
            this.pbRefreshUI = new System.Windows.Forms.PictureBox();
            this.pnControlLog = new System.Windows.Forms.Panel();
            this.pbClearLog = new System.Windows.Forms.PictureBox();
            this.pbShowLogTable = new System.Windows.Forms.PictureBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnContainer.SuspendLayout();
            this.pnMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnAddNewTask)).BeginInit();
            this.pnAddNewTask.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnLog)).BeginInit();
            this.pnLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnHeader)).BeginInit();
            this.pnHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.pnBar.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSaveData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRefreshUI)).BeginInit();
            this.pnControlLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClearLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShowLogTable)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerLbTimeNow
            // 
            this.timerLbTimeNow.Enabled = true;
            this.timerLbTimeNow.Interval = 1000;
            this.timerLbTimeNow.Tick += new System.EventHandler(this.timerLbTimeNow_Tick);
            // 
            // kryptonPalette1
            // 
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.Color1 = System.Drawing.Color.Gray;
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.None;
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.Rounding = 12;
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.ButtonEdgeInset = 10;
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Content.Padding = new System.Windows.Forms.Padding(10, -1, -1, -1);
            // 
            // pnContainer
            // 
            this.pnContainer.Controls.Add(this.pnMain);
            this.pnContainer.Controls.Add(this.pnBar);
            this.pnContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnContainer.Location = new System.Drawing.Point(0, 0);
            this.pnContainer.Name = "pnContainer";
            this.pnContainer.Padding = new System.Windows.Forms.Padding(5);
            this.pnContainer.Size = new System.Drawing.Size(884, 581);
            this.pnContainer.TabIndex = 18;
            // 
            // pnMain
            // 
            this.pnMain.Controls.Add(this.flpTaskList);
            this.pnMain.Controls.Add(this.pnAddNewTask);
            this.pnMain.Controls.Add(this.pnLog);
            this.pnMain.Controls.Add(this.pnHeader);
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMain.Location = new System.Drawing.Point(85, 5);
            this.pnMain.Name = "pnMain";
            this.pnMain.Padding = new System.Windows.Forms.Padding(5);
            this.pnMain.Size = new System.Drawing.Size(794, 571);
            this.pnMain.TabIndex = 18;
            // 
            // flpTaskList
            // 
            this.flpTaskList.AutoScroll = true;
            this.flpTaskList.BackColor = System.Drawing.Color.Transparent;
            this.flpTaskList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTaskList.Location = new System.Drawing.Point(5, 140);
            this.flpTaskList.Name = "flpTaskList";
            this.flpTaskList.Padding = new System.Windows.Forms.Padding(21, 10, 0, 0);
            this.flpTaskList.Size = new System.Drawing.Size(784, 336);
            this.flpTaskList.TabIndex = 15;
            // 
            // pnAddNewTask
            // 
            this.pnAddNewTask.Controls.Add(this.lbClearTxbTaskName);
            this.pnAddNewTask.Controls.Add(this.kryptonLabel6);
            this.pnAddNewTask.Controls.Add(this.kryptonLabel5);
            this.pnAddNewTask.Controls.Add(this.txbTaskName);
            this.pnAddNewTask.Controls.Add(this.dtpTaskStartTime);
            this.pnAddNewTask.Controls.Add(this.btnAddNewTask);
            this.pnAddNewTask.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnAddNewTask.Location = new System.Drawing.Point(5, 63);
            this.pnAddNewTask.Name = "pnAddNewTask";
            this.pnAddNewTask.Padding = new System.Windows.Forms.Padding(15, 15, 40, 15);
            this.pnAddNewTask.Size = new System.Drawing.Size(784, 77);
            this.pnAddNewTask.StateNormal.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.pnAddNewTask.StateNormal.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(217)))));
            this.pnAddNewTask.StateNormal.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.SolidBottomLine;
            this.pnAddNewTask.TabIndex = 5;
            // 
            // lbClearTxbTaskName
            // 
            this.lbClearTxbTaskName.AutoSize = true;
            this.lbClearTxbTaskName.BackColor = System.Drawing.Color.White;
            this.lbClearTxbTaskName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbClearTxbTaskName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClearTxbTaskName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(133)))));
            this.lbClearTxbTaskName.Location = new System.Drawing.Point(278, 39);
            this.lbClearTxbTaskName.Name = "lbClearTxbTaskName";
            this.lbClearTxbTaskName.Size = new System.Drawing.Size(13, 16);
            this.lbClearTxbTaskName.TabIndex = 14;
            this.lbClearTxbTaskName.Text = "x";
            this.lbClearTxbTaskName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbClearTxbTaskName.Click += new System.EventHandler(this.lbClearTxbTaskName_Click);
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(362, 8);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(109, 20);
            this.kryptonLabel6.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonLabel6.StateNormal.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonLabel6.TabIndex = 11;
            this.kryptonLabel6.Values.Text = "Choose start time:";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(24, 8);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(100, 20);
            this.kryptonLabel5.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonLabel5.StateNormal.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonLabel5.TabIndex = 10;
            this.kryptonLabel5.Values.Text = "Enter task name:";
            // 
            // txbTaskName
            // 
            this.txbTaskName.Location = new System.Drawing.Point(24, 33);
            this.txbTaskName.Name = "txbTaskName";
            this.txbTaskName.Size = new System.Drawing.Size(281, 33);
            this.txbTaskName.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.txbTaskName.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(217)))));
            this.txbTaskName.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txbTaskName.StateCommon.Border.Rounding = 15;
            this.txbTaskName.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.txbTaskName.TabIndex = 9;
            // 
            // dtpTaskStartTime
            // 
            this.dtpTaskStartTime.CustomFormat = "dd/MM/yyyy |  HH:mm:ss";
            this.dtpTaskStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTaskStartTime.Location = new System.Drawing.Point(362, 34);
            this.dtpTaskStartTime.Name = "dtpTaskStartTime";
            this.dtpTaskStartTime.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.dtpTaskStartTime.Size = new System.Drawing.Size(176, 31);
            this.dtpTaskStartTime.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.dtpTaskStartTime.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(217)))));
            this.dtpTaskStartTime.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.dtpTaskStartTime.StateCommon.Border.Rounding = 15;
            this.dtpTaskStartTime.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.dtpTaskStartTime.TabIndex = 6;
            // 
            // btnAddNewTask
            // 
            this.btnAddNewTask.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAddNewTask.Location = new System.Drawing.Point(594, 15);
            this.btnAddNewTask.Name = "btnAddNewTask";
            this.btnAddNewTask.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnAddNewTask.Size = new System.Drawing.Size(150, 47);
            this.btnAddNewTask.TabIndex = 3;
            this.btnAddNewTask.Values.Text = "Create new task";
            this.btnAddNewTask.Click += new System.EventHandler(this.btnAddNewTask_Click);
            // 
            // pnLog
            // 
            this.pnLog.Controls.Add(this.dgvLog);
            this.pnLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnLog.Location = new System.Drawing.Point(5, 476);
            this.pnLog.Name = "pnLog";
            this.pnLog.Size = new System.Drawing.Size(784, 90);
            this.pnLog.StateNormal.Color1 = System.Drawing.Color.Transparent;
            this.pnLog.TabIndex = 14;
            // 
            // dgvLog
            // 
            this.dgvLog.AllowUserToAddRows = false;
            this.dgvLog.AllowUserToDeleteRows = false;
            this.dgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Time,
            this.Task,
            this.Log});
            this.dgvLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLog.Location = new System.Drawing.Point(0, 0);
            this.dgvLog.Name = "dgvLog";
            this.dgvLog.ReadOnly = true;
            this.dgvLog.Size = new System.Drawing.Size(784, 90);
            this.dgvLog.StateCommon.Background.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(224)))), ((int)(((byte)(239)))));
            this.dgvLog.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dgvLog.TabIndex = 6;
            // 
            // Time
            // 
            this.Time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Time.DataPropertyName = "Time";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy HH:mm:ss";
            dataGridViewCellStyle1.NullValue = null;
            this.Time.DefaultCellStyle = dataGridViewCellStyle1;
            this.Time.HeaderText = "Time";
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            this.Time.Width = 62;
            // 
            // Task
            // 
            this.Task.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Task.DataPropertyName = "Task";
            this.Task.HeaderText = "Task ID";
            this.Task.Name = "Task";
            this.Task.ReadOnly = true;
            this.Task.Width = 72;
            // 
            // Log
            // 
            this.Log.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Log.DataPropertyName = "Log";
            this.Log.HeaderText = "Log";
            this.Log.Name = "Log";
            this.Log.ReadOnly = true;
            // 
            // pnHeader
            // 
            this.pnHeader.Controls.Add(this.pbLogo);
            this.pnHeader.Controls.Add(this.lbTimeNow);
            this.pnHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHeader.Location = new System.Drawing.Point(5, 5);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(784, 58);
            this.pnHeader.StateNormal.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.pnHeader.TabIndex = 4;
            // 
            // pbLogo
            // 
            this.pbLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbLogo.Image = global::KT_Timer_App.Properties.Resources.logo_KT_Studio_Yellow_05;
            this.pbLogo.Location = new System.Drawing.Point(0, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(58, 58);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 6;
            this.pbLogo.TabStop = false;
            this.pbLogo.Click += new System.EventHandler(this.pbLogo_Click);
            // 
            // lbTimeNow
            // 
            this.lbTimeNow.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.TitleControl;
            this.lbTimeNow.Location = new System.Drawing.Point(292, 13);
            this.lbTimeNow.Name = "lbTimeNow";
            this.lbTimeNow.Size = new System.Drawing.Size(205, 29);
            this.lbTimeNow.StateNormal.ShortText.Color1 = System.Drawing.Color.Black;
            this.lbTimeNow.TabIndex = 3;
            this.lbTimeNow.Values.Text = "22/12/2022 | 12:22:22";
            // 
            // pnBar
            // 
            this.pnBar.Controls.Add(this.flowLayoutPanel1);
            this.pnBar.Controls.Add(this.pnControlLog);
            this.pnBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnBar.Location = new System.Drawing.Point(5, 5);
            this.pnBar.Name = "pnBar";
            this.pnBar.Padding = new System.Windows.Forms.Padding(5);
            this.pnBar.Size = new System.Drawing.Size(80, 571);
            this.pnBar.TabIndex = 17;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.pbSaveData);
            this.flowLayoutPanel1.Controls.Add(this.pbRefreshUI);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.ForeColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(5, 5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(70, 471);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // pbSaveData
            // 
            this.pbSaveData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSaveData.Image = global::KT_Timer_App.Properties.Resources.icons8_save_96px;
            this.pbSaveData.Location = new System.Drawing.Point(13, 13);
            this.pbSaveData.Name = "pbSaveData";
            this.pbSaveData.Size = new System.Drawing.Size(45, 45);
            this.pbSaveData.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSaveData.TabIndex = 3;
            this.pbSaveData.TabStop = false;
            this.pbSaveData.Click += new System.EventHandler(this.pbSaveData_Click);
            // 
            // pbRefreshUI
            // 
            this.pbRefreshUI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbRefreshUI.Image = global::KT_Timer_App.Properties.Resources.icons8_refresh_96px;
            this.pbRefreshUI.Location = new System.Drawing.Point(13, 64);
            this.pbRefreshUI.Name = "pbRefreshUI";
            this.pbRefreshUI.Size = new System.Drawing.Size(45, 45);
            this.pbRefreshUI.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbRefreshUI.TabIndex = 5;
            this.pbRefreshUI.TabStop = false;
            this.pbRefreshUI.Click += new System.EventHandler(this.pbRefreshUI_Click);
            // 
            // pnControlLog
            // 
            this.pnControlLog.Controls.Add(this.pbClearLog);
            this.pnControlLog.Controls.Add(this.pbShowLogTable);
            this.pnControlLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnControlLog.Location = new System.Drawing.Point(5, 476);
            this.pnControlLog.Name = "pnControlLog";
            this.pnControlLog.Size = new System.Drawing.Size(70, 90);
            this.pnControlLog.TabIndex = 6;
            // 
            // pbClearLog
            // 
            this.pbClearLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbClearLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbClearLog.Image = global::KT_Timer_App.Properties.Resources.icons8_broom_96px;
            this.pbClearLog.Location = new System.Drawing.Point(0, 45);
            this.pbClearLog.Name = "pbClearLog";
            this.pbClearLog.Size = new System.Drawing.Size(70, 45);
            this.pbClearLog.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbClearLog.TabIndex = 8;
            this.pbClearLog.TabStop = false;
            this.pbClearLog.Click += new System.EventHandler(this.pbClearLog_Click);
            // 
            // pbShowLogTable
            // 
            this.pbShowLogTable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbShowLogTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbShowLogTable.Image = global::KT_Timer_App.Properties.Resources.icons8_closed_eye_96px;
            this.pbShowLogTable.Location = new System.Drawing.Point(0, 0);
            this.pbShowLogTable.Name = "pbShowLogTable";
            this.pbShowLogTable.Size = new System.Drawing.Size(70, 45);
            this.pbShowLogTable.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbShowLogTable.TabIndex = 7;
            this.pbShowLogTable.TabStop = false;
            this.pbShowLogTable.Click += new System.EventHandler(this.pbShowTableLog_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(104, 48);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // fMain
            // 
            this.AcceptButton = this.btnAddNewTask;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(884, 581);
            this.Controls.Add(this.pnContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.Name = "fMain";
            this.Palette = this.kryptonPalette1;
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KT Timer v1.0";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fMain_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.SizeChanged += new System.EventHandler(this.fMain_SizeChanged);
            this.pnContainer.ResumeLayout(false);
            this.pnMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnAddNewTask)).EndInit();
            this.pnAddNewTask.ResumeLayout(false);
            this.pnAddNewTask.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnLog)).EndInit();
            this.pnLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnHeader)).EndInit();
            this.pnHeader.ResumeLayout(false);
            this.pnHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.pnBar.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSaveData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRefreshUI)).EndInit();
            this.pnControlLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbClearLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShowLogTable)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timerLbTimeNow;
        private ComponentFactory.Krypton.Toolkit.KryptonPalette kryptonPalette1;
        private System.Windows.Forms.Panel pnContainer;
        private System.Windows.Forms.Panel pnMain;
        private System.Windows.Forms.FlowLayoutPanel flpTaskList;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel pnAddNewTask;
        private System.Windows.Forms.Label lbClearTxbTaskName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txbTaskName;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpTaskStartTime;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAddNewTask;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel pnLog;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel pnHeader;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lbTimeNow;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel pnBar;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Task;
        private System.Windows.Forms.DataGridViewTextBoxColumn Log;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox pbSaveData;
        private System.Windows.Forms.PictureBox pbRefreshUI;
        private System.Windows.Forms.Panel pnControlLog;
        private System.Windows.Forms.PictureBox pbClearLog;
        private System.Windows.Forms.PictureBox pbShowLogTable;
        private System.Windows.Forms.PictureBox pbLogo;
    }
}

