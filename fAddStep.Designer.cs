namespace KT_Timer_App
{
    partial class fAddStep
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
            this.btnAddStep = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lbStepID = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lbTaskName = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txbLinkApp = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txbLinkButtonImage = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.pnCommand = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.txbCommand = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.rbtnShutdown = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.rbtnEnterCommand = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txbStepName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lbParentTaskID = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.rbtnOpenApp = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.rbtnClick = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.rbtnExecuteCommand = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.pnAction = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonPalette1 = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cbCheckCondition = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.btnBrowserCondition = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txbLinkCondition = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel9 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnBrowserApp = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnBrowserImage = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnCommand)).BeginInit();
            this.pnCommand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnAction)).BeginInit();
            this.pnAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddStep
            // 
            this.btnAddStep.Location = new System.Drawing.Point(24, 425);
            this.btnAddStep.Name = "btnAddStep";
            this.btnAddStep.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnAddStep.Size = new System.Drawing.Size(328, 25);
            this.btnAddStep.TabIndex = 0;
            this.btnAddStep.Values.Text = "Add Step (Enter)";
            this.btnAddStep.Click += new System.EventHandler(this.btnAddStep_Click);
            // 
            // lbStepID
            // 
            this.lbStepID.Location = new System.Drawing.Point(24, 55);
            this.lbStepID.Name = "lbStepID";
            this.lbStepID.Size = new System.Drawing.Size(47, 20);
            this.lbStepID.TabIndex = 3;
            this.lbStepID.Values.Text = "StepID";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(162, 250);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(187, 20);
            this.kryptonLabel3.TabIndex = 5;
            this.kryptonLabel3.Values.Text = "Enter path button image (*.PNG)";
            // 
            // lbTaskName
            // 
            this.lbTaskName.Location = new System.Drawing.Point(100, 19);
            this.lbTaskName.Name = "lbTaskName";
            this.lbTaskName.Size = new System.Drawing.Size(68, 20);
            this.lbTaskName.TabIndex = 7;
            this.lbTaskName.Values.Text = "Task name";
            // 
            // txbLinkApp
            // 
            this.txbLinkApp.Location = new System.Drawing.Point(163, 213);
            this.txbLinkApp.Name = "txbLinkApp";
            this.txbLinkApp.Size = new System.Drawing.Size(199, 23);
            this.txbLinkApp.TabIndex = 11;
            this.txbLinkApp.Text = "www.google.com";
            // 
            // txbLinkButtonImage
            // 
            this.txbLinkButtonImage.Location = new System.Drawing.Point(163, 276);
            this.txbLinkButtonImage.Name = "txbLinkButtonImage";
            this.txbLinkButtonImage.Size = new System.Drawing.Size(199, 23);
            this.txbLinkButtonImage.TabIndex = 13;
            // 
            // pnCommand
            // 
            this.pnCommand.Controls.Add(this.txbCommand);
            this.pnCommand.Controls.Add(this.rbtnShutdown);
            this.pnCommand.Controls.Add(this.rbtnEnterCommand);
            this.pnCommand.Location = new System.Drawing.Point(162, 330);
            this.pnCommand.Name = "pnCommand";
            this.pnCommand.Size = new System.Drawing.Size(296, 69);
            this.pnCommand.StateNormal.Color1 = System.Drawing.Color.Transparent;
            this.pnCommand.TabIndex = 20;
            // 
            // txbCommand
            // 
            this.txbCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txbCommand.Location = new System.Drawing.Point(10, 33);
            this.txbCommand.Name = "txbCommand";
            this.txbCommand.Size = new System.Drawing.Size(189, 23);
            this.txbCommand.TabIndex = 18;
            this.txbCommand.Text = "ping ktstudio.vn";
            // 
            // rbtnShutdown
            // 
            this.rbtnShutdown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtnShutdown.Location = new System.Drawing.Point(205, 7);
            this.rbtnShutdown.Name = "rbtnShutdown";
            this.rbtnShutdown.Size = new System.Drawing.Size(78, 20);
            this.rbtnShutdown.TabIndex = 8;
            this.rbtnShutdown.Values.Text = "Shutdown";
            this.rbtnShutdown.CheckedChanged += new System.EventHandler(this.rbtnShutdown_CheckedChanged);
            // 
            // rbtnEnterCommand
            // 
            this.rbtnEnterCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtnEnterCommand.Location = new System.Drawing.Point(10, 7);
            this.rbtnEnterCommand.Name = "rbtnEnterCommand";
            this.rbtnEnterCommand.Size = new System.Drawing.Size(109, 20);
            this.rbtnEnterCommand.TabIndex = 0;
            this.rbtnEnterCommand.Values.Text = "Enter command";
            this.rbtnEnterCommand.CheckedChanged += new System.EventHandler(this.rbtnEnterCommand_CheckedChanged);
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(100, 55);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(69, 20);
            this.kryptonLabel6.TabIndex = 22;
            this.kryptonLabel6.Values.Text = "Step name";
            // 
            // txbStepName
            // 
            this.txbStepName.Location = new System.Drawing.Point(175, 52);
            this.txbStepName.Name = "txbStepName";
            this.txbStepName.Size = new System.Drawing.Size(283, 23);
            this.txbStepName.TabIndex = 21;
            // 
            // lbParentTaskID
            // 
            this.lbParentTaskID.Location = new System.Drawing.Point(24, 19);
            this.lbParentTaskID.Name = "lbParentTaskID";
            this.lbParentTaskID.Size = new System.Drawing.Size(82, 20);
            this.lbParentTaskID.TabIndex = 2;
            this.lbParentTaskID.Values.Text = "ParentTaskID";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(368, 425);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Black;
            this.btnCancel.Size = new System.Drawing.Size(90, 25);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Values.Text = "Cancel (ESC)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // rbtnOpenApp
            // 
            this.rbtnOpenApp.Location = new System.Drawing.Point(19, 31);
            this.rbtnOpenApp.Name = "rbtnOpenApp";
            this.rbtnOpenApp.Size = new System.Drawing.Size(118, 20);
            this.rbtnOpenApp.TabIndex = 0;
            this.rbtnOpenApp.Values.Text = "Open Application";
            this.rbtnOpenApp.CheckedChanged += new System.EventHandler(this.rbtnOpenApp_CheckedChanged);
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(13, 3);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(54, 20);
            this.kryptonLabel5.TabIndex = 6;
            this.kryptonLabel5.Values.Text = "Action *";
            // 
            // rbtnClick
            // 
            this.rbtnClick.Location = new System.Drawing.Point(19, 94);
            this.rbtnClick.Name = "rbtnClick";
            this.rbtnClick.Size = new System.Drawing.Size(106, 20);
            this.rbtnClick.TabIndex = 7;
            this.rbtnClick.Values.Text = "Click on button";
            this.rbtnClick.CheckedChanged += new System.EventHandler(this.rbtnClick_CheckedChanged);
            // 
            // rbtnExecuteCommand
            // 
            this.rbtnExecuteCommand.Location = new System.Drawing.Point(19, 172);
            this.rbtnExecuteCommand.Name = "rbtnExecuteCommand";
            this.rbtnExecuteCommand.Size = new System.Drawing.Size(79, 20);
            this.rbtnExecuteCommand.TabIndex = 8;
            this.rbtnExecuteCommand.Values.Text = "Command";
            this.rbtnExecuteCommand.CheckedChanged += new System.EventHandler(this.rbtnExecuteCommand_CheckedChanged);
            // 
            // pnAction
            // 
            this.pnAction.Controls.Add(this.kryptonLabel2);
            this.pnAction.Controls.Add(this.kryptonLabel1);
            this.pnAction.Controls.Add(this.rbtnExecuteCommand);
            this.pnAction.Controls.Add(this.rbtnClick);
            this.pnAction.Controls.Add(this.kryptonLabel5);
            this.pnAction.Controls.Add(this.rbtnOpenApp);
            this.pnAction.Location = new System.Drawing.Point(9, 182);
            this.pnAction.Name = "pnAction";
            this.pnAction.Size = new System.Drawing.Size(147, 217);
            this.pnAction.StateNormal.Color1 = System.Drawing.Color.Transparent;
            this.pnAction.TabIndex = 8;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(6, 55);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(134, 20);
            this.kryptonLabel2.TabIndex = 25;
            this.kryptonLabel2.Values.Text = "-------------------------";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(3, 138);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(134, 20);
            this.kryptonLabel1.TabIndex = 24;
            this.kryptonLabel1.Values.Text = "-------------------------";
            // 
            // kryptonPalette1
            // 
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.None;
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.Rounding = 12;
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.ButtonEdgeInset = 10;
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Content.Padding = new System.Windows.Forms.Padding(10, -1, -1, -1);
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(163, 187);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(198, 20);
            this.kryptonLabel4.TabIndex = 24;
            this.kryptonLabel4.Values.Text = "Enter path application (or website)";
            // 
            // cbCheckCondition
            // 
            this.cbCheckCondition.Location = new System.Drawing.Point(28, 103);
            this.cbCheckCondition.Name = "cbCheckCondition";
            this.cbCheckCondition.Size = new System.Drawing.Size(111, 20);
            this.cbCheckCondition.TabIndex = 25;
            this.cbCheckCondition.Values.Text = "Check condition";
            this.cbCheckCondition.CheckedChanged += new System.EventHandler(this.cbCheckCondition_CheckedChanged);
            // 
            // btnBrowserCondition
            // 
            this.btnBrowserCondition.Location = new System.Drawing.Point(368, 128);
            this.btnBrowserCondition.Name = "btnBrowserCondition";
            this.btnBrowserCondition.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnBrowserCondition.Size = new System.Drawing.Size(90, 25);
            this.btnBrowserCondition.TabIndex = 28;
            this.btnBrowserCondition.Values.Text = "Browser";
            this.btnBrowserCondition.Click += new System.EventHandler(this.btnBrowserCondition_Click);
            // 
            // txbLinkCondition
            // 
            this.txbLinkCondition.Location = new System.Drawing.Point(163, 129);
            this.txbLinkCondition.Name = "txbLinkCondition";
            this.txbLinkCondition.Size = new System.Drawing.Size(199, 23);
            this.txbLinkCondition.TabIndex = 27;
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Location = new System.Drawing.Point(162, 103);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(185, 20);
            this.kryptonLabel7.TabIndex = 26;
            this.kryptonLabel7.Values.Text = "Enter path condition file (*.PNG)";
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.Location = new System.Drawing.Point(15, 156);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.Size = new System.Drawing.Size(446, 20);
            this.kryptonLabel8.TabIndex = 29;
            this.kryptonLabel8.Values.Text = "---------------------------------------------------------------------------------" +
    "-------";
            // 
            // kryptonLabel9
            // 
            this.kryptonLabel9.Location = new System.Drawing.Point(12, 81);
            this.kryptonLabel9.Name = "kryptonLabel9";
            this.kryptonLabel9.Size = new System.Drawing.Size(446, 20);
            this.kryptonLabel9.TabIndex = 30;
            this.kryptonLabel9.Values.Text = "---------------------------------------------------------------------------------" +
    "-------";
            // 
            // btnBrowserApp
            // 
            this.btnBrowserApp.Location = new System.Drawing.Point(367, 212);
            this.btnBrowserApp.Name = "btnBrowserApp";
            this.btnBrowserApp.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnBrowserApp.Size = new System.Drawing.Size(90, 25);
            this.btnBrowserApp.TabIndex = 31;
            this.btnBrowserApp.Values.Text = "Browser";
            this.btnBrowserApp.Click += new System.EventHandler(this.btnBrowserApp_Click);
            // 
            // btnBrowserImage
            // 
            this.btnBrowserImage.Location = new System.Drawing.Point(367, 275);
            this.btnBrowserImage.Name = "btnBrowserImage";
            this.btnBrowserImage.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnBrowserImage.Size = new System.Drawing.Size(90, 25);
            this.btnBrowserImage.TabIndex = 32;
            this.btnBrowserImage.Values.Text = "Browser";
            this.btnBrowserImage.Click += new System.EventHandler(this.btnBrowserImage_Click);
            // 
            // fAddStep
            // 
            this.AcceptButton = this.btnAddStep;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(488, 475);
            this.Controls.Add(this.btnBrowserImage);
            this.Controls.Add(this.btnBrowserApp);
            this.Controls.Add(this.kryptonLabel9);
            this.Controls.Add(this.kryptonLabel8);
            this.Controls.Add(this.btnBrowserCondition);
            this.Controls.Add(this.txbLinkCondition);
            this.Controls.Add(this.kryptonLabel7);
            this.Controls.Add(this.cbCheckCondition);
            this.Controls.Add(this.kryptonLabel4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.kryptonLabel6);
            this.Controls.Add(this.txbStepName);
            this.Controls.Add(this.pnCommand);
            this.Controls.Add(this.txbLinkButtonImage);
            this.Controls.Add(this.txbLinkApp);
            this.Controls.Add(this.pnAction);
            this.Controls.Add(this.lbTaskName);
            this.Controls.Add(this.kryptonLabel3);
            this.Controls.Add(this.lbStepID);
            this.Controls.Add(this.lbParentTaskID);
            this.Controls.Add(this.btnAddStep);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fAddStep";
            this.Palette = this.kryptonPalette1;
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add new step";
            this.Load += new System.EventHandler(this.fAddStep_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnCommand)).EndInit();
            this.pnCommand.ResumeLayout(false);
            this.pnCommand.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnAction)).EndInit();
            this.pnAction.ResumeLayout(false);
            this.pnAction.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAddStep;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lbStepID;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lbTaskName;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txbLinkApp;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txbLinkButtonImage;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel pnCommand;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txbCommand;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbtnShutdown;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbtnEnterCommand;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txbStepName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lbParentTaskID;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbtnOpenApp;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbtnClick;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbtnExecuteCommand;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel pnAction;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonPalette kryptonPalette1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox cbCheckCondition;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnBrowserCondition;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txbLinkCondition;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel8;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel9;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnBrowserApp;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnBrowserImage;
    }
}