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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            this.timerLbTimeNow = new System.Windows.Forms.Timer(this.components);
            this.kryptonPalette1 = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            this.pnBar = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pbSaveData = new System.Windows.Forms.PictureBox();
            this.pbSetting = new System.Windows.Forms.PictureBox();
            this.pnLogo = new System.Windows.Forms.Panel();
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
            this.txbLog = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.pnHeader = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.lbTimeNow = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.pnBar.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSaveData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSetting)).BeginInit();
            this.pnContainer.SuspendLayout();
            this.pnMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnAddNewTask)).BeginInit();
            this.pnAddNewTask.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnLog)).BeginInit();
            this.pnLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnHeader)).BeginInit();
            this.pnHeader.SuspendLayout();
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
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(217)))));
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
            // pnBar
            // 
            this.pnBar.Controls.Add(this.flowLayoutPanel1);
            this.pnBar.Controls.Add(this.pnLogo);
            this.pnBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnBar.Location = new System.Drawing.Point(0, 0);
            this.pnBar.Name = "pnBar";
            this.pnBar.Padding = new System.Windows.Forms.Padding(5);
            this.pnBar.Size = new System.Drawing.Size(100, 539);
            this.pnBar.TabIndex = 17;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.pbSaveData);
            this.flowLayoutPanel1.Controls.Add(this.pbSetting);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.ForeColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(5, 95);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(20);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(90, 439);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // pbSaveData
            // 
            this.pbSaveData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSaveData.Image = global::KT_Timer_App.Properties.Resources.icons8_save_96px;
            this.pbSaveData.Location = new System.Drawing.Point(23, 23);
            this.pbSaveData.Name = "pbSaveData";
            this.pbSaveData.Size = new System.Drawing.Size(45, 45);
            this.pbSaveData.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSaveData.TabIndex = 3;
            this.pbSaveData.TabStop = false;
            this.pbSaveData.Click += new System.EventHandler(this.pbSaveData_Click);
            // 
            // pbSetting
            // 
            this.pbSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSetting.Image = global::KT_Timer_App.Properties.Resources.icons8_settings_96px;
            this.pbSetting.Location = new System.Drawing.Point(23, 74);
            this.pbSetting.Name = "pbSetting";
            this.pbSetting.Size = new System.Drawing.Size(45, 45);
            this.pbSetting.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSetting.TabIndex = 4;
            this.pbSetting.TabStop = false;
            // 
            // pnLogo
            // 
            this.pnLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnLogo.BackgroundImage")));
            this.pnLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnLogo.Location = new System.Drawing.Point(5, 5);
            this.pnLogo.Name = "pnLogo";
            this.pnLogo.Size = new System.Drawing.Size(90, 90);
            this.pnLogo.TabIndex = 0;
            // 
            // pnContainer
            // 
            this.pnContainer.Controls.Add(this.pnMain);
            this.pnContainer.Controls.Add(this.pnBar);
            this.pnContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnContainer.Location = new System.Drawing.Point(0, 0);
            this.pnContainer.Name = "pnContainer";
            this.pnContainer.Size = new System.Drawing.Size(779, 539);
            this.pnContainer.TabIndex = 18;
            // 
            // pnMain
            // 
            this.pnMain.Controls.Add(this.flpTaskList);
            this.pnMain.Controls.Add(this.pnAddNewTask);
            this.pnMain.Controls.Add(this.pnLog);
            this.pnMain.Controls.Add(this.pnHeader);
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMain.Location = new System.Drawing.Point(100, 0);
            this.pnMain.Name = "pnMain";
            this.pnMain.Padding = new System.Windows.Forms.Padding(5);
            this.pnMain.Size = new System.Drawing.Size(679, 539);
            this.pnMain.TabIndex = 18;
            // 
            // flpTaskList
            // 
            this.flpTaskList.AutoScroll = true;
            this.flpTaskList.BackColor = System.Drawing.Color.Transparent;
            this.flpTaskList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTaskList.Location = new System.Drawing.Point(5, 121);
            this.flpTaskList.Name = "flpTaskList";
            this.flpTaskList.Padding = new System.Windows.Forms.Padding(21, 10, 0, 0);
            this.flpTaskList.Size = new System.Drawing.Size(669, 359);
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
            this.pnAddNewTask.Location = new System.Drawing.Point(5, 44);
            this.pnAddNewTask.Name = "pnAddNewTask";
            this.pnAddNewTask.Padding = new System.Windows.Forms.Padding(15, 15, 21, 15);
            this.pnAddNewTask.Size = new System.Drawing.Size(669, 77);
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
            this.lbClearTxbTaskName.Location = new System.Drawing.Point(207, 39);
            this.lbClearTxbTaskName.Name = "lbClearTxbTaskName";
            this.lbClearTxbTaskName.Size = new System.Drawing.Size(13, 16);
            this.lbClearTxbTaskName.TabIndex = 14;
            this.lbClearTxbTaskName.Text = "x";
            this.lbClearTxbTaskName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbClearTxbTaskName.Click += new System.EventHandler(this.lbClearTxbTaskName_Click);
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(265, 8);
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
            this.txbTaskName.Size = new System.Drawing.Size(205, 33);
            this.txbTaskName.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.txbTaskName.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(217)))));
            this.txbTaskName.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txbTaskName.StateCommon.Border.Rounding = 15;
            this.txbTaskName.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.txbTaskName.TabIndex = 9;
            this.txbTaskName.Text = "Chấm công về";
            // 
            // dtpTaskStartTime
            // 
            this.dtpTaskStartTime.CustomFormat = "dd/MM/yyyy |  HH:mm:ss";
            this.dtpTaskStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTaskStartTime.Location = new System.Drawing.Point(265, 34);
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
            this.btnAddNewTask.Location = new System.Drawing.Point(498, 15);
            this.btnAddNewTask.Name = "btnAddNewTask";
            this.btnAddNewTask.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnAddNewTask.Size = new System.Drawing.Size(150, 47);
            this.btnAddNewTask.TabIndex = 3;
            this.btnAddNewTask.Values.Text = "Create new task";
            this.btnAddNewTask.Click += new System.EventHandler(this.btnAddNewTask_Click);
            // 
            // pnLog
            // 
            this.pnLog.Controls.Add(this.txbLog);
            this.pnLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnLog.Location = new System.Drawing.Point(5, 480);
            this.pnLog.Name = "pnLog";
            this.pnLog.Size = new System.Drawing.Size(669, 54);
            this.pnLog.StateNormal.Color1 = System.Drawing.Color.Transparent;
            this.pnLog.TabIndex = 14;
            // 
            // txbLog
            // 
            this.txbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbLog.Location = new System.Drawing.Point(0, 0);
            this.txbLog.Multiline = true;
            this.txbLog.Name = "txbLog";
            this.txbLog.ReadOnly = true;
            this.txbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbLog.Size = new System.Drawing.Size(669, 54);
            this.txbLog.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(232)))));
            this.txbLog.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txbLog.StateCommon.Border.Rounding = 12;
            this.txbLog.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.txbLog.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txbLog.StateNormal.Content.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(82)))), ((int)(((byte)(101)))));
            this.txbLog.StateNormal.Content.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbLog.TabIndex = 0;
            // 
            // pnHeader
            // 
            this.pnHeader.Controls.Add(this.lbTimeNow);
            this.pnHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHeader.Location = new System.Drawing.Point(5, 5);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(669, 39);
            this.pnHeader.StateNormal.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.pnHeader.TabIndex = 4;
            // 
            // lbTimeNow
            // 
            this.lbTimeNow.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.TitleControl;
            this.lbTimeNow.Location = new System.Drawing.Point(249, 4);
            this.lbTimeNow.Name = "lbTimeNow";
            this.lbTimeNow.Size = new System.Drawing.Size(205, 29);
            this.lbTimeNow.StateNormal.ShortText.Color1 = System.Drawing.Color.Black;
            this.lbTimeNow.TabIndex = 3;
            this.lbTimeNow.Values.Text = "22/12/2022 | 12:22:22";
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(779, 539);
            this.Controls.Add(this.pnContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "fMain";
            this.Palette = this.kryptonPalette1;
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KT Timer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fMain_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.pnBar.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSaveData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSetting)).EndInit();
            this.pnContainer.ResumeLayout(false);
            this.pnMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnAddNewTask)).EndInit();
            this.pnAddNewTask.ResumeLayout(false);
            this.pnAddNewTask.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnLog)).EndInit();
            this.pnLog.ResumeLayout(false);
            this.pnLog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnHeader)).EndInit();
            this.pnHeader.ResumeLayout(false);
            this.pnHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timerLbTimeNow;
        private ComponentFactory.Krypton.Toolkit.KryptonPalette kryptonPalette1;
        private System.Windows.Forms.Panel pnBar;
        private System.Windows.Forms.Panel pnLogo;
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
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txbLog;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel pnHeader;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lbTimeNow;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox pbSaveData;
        private System.Windows.Forms.PictureBox pbSetting;
    }
}

