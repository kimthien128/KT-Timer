namespace KT_Timer_App
{
    partial class fEditInfoDialog
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.txbNewName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.dtpNewStartTime = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbNameAction = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.pnBtn = new System.Windows.Forms.Panel();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonPalette1 = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            this.panel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnBtn.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(5, 5);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(404, 58);
            this.panel2.TabIndex = 11;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.txbNewName);
            this.flowLayoutPanel1.Controls.Add(this.dtpNewStartTime);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(140, 5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5, 15, 20, 5);
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(259, 48);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // txbNewName
            // 
            this.txbNewName.Location = new System.Drawing.Point(34, 18);
            this.txbNewName.Name = "txbNewName";
            this.txbNewName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txbNewName.Size = new System.Drawing.Size(197, 23);
            this.txbNewName.TabIndex = 0;
            // 
            // dtpNewStartTime
            // 
            this.dtpNewStartTime.CustomFormat = "dd/MM/yyyy |  HH:mm:ss";
            this.dtpNewStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNewStartTime.Location = new System.Drawing.Point(34, 47);
            this.dtpNewStartTime.Name = "dtpNewStartTime";
            this.dtpNewStartTime.Size = new System.Drawing.Size(197, 21);
            this.dtpNewStartTime.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lbNameAction);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(5, 5);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(30, 5, 5, 5);
            this.panel3.Size = new System.Drawing.Size(135, 48);
            this.panel3.TabIndex = 0;
            // 
            // lbNameAction
            // 
            this.lbNameAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbNameAction.Location = new System.Drawing.Point(30, 5);
            this.lbNameAction.Name = "lbNameAction";
            this.lbNameAction.Size = new System.Drawing.Size(100, 38);
            this.lbNameAction.TabIndex = 6;
            this.lbNameAction.Values.Text = "New name :";
            // 
            // pnBtn
            // 
            this.pnBtn.Controls.Add(this.btnCancel);
            this.pnBtn.Controls.Add(this.btnSave);
            this.pnBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnBtn.Location = new System.Drawing.Point(5, 69);
            this.pnBtn.Name = "pnBtn";
            this.pnBtn.Padding = new System.Windows.Forms.Padding(5);
            this.pnBtn.Size = new System.Drawing.Size(404, 49);
            this.pnBtn.TabIndex = 12;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(251, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnCancel.Size = new System.Drawing.Size(120, 25);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Values.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(35, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnSave.Size = new System.Drawing.Size(120, 25);
            this.btnSave.TabIndex = 1;
            this.btnSave.Values.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.Rounding = 8;
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.ButtonEdgeInset = 10;
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Content.Padding = new System.Windows.Forms.Padding(10, -1, -1, -1);
            // 
            // fEditInfoDialog
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(414, 123);
            this.Controls.Add(this.pnBtn);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "fEditInfoDialog";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Palette = this.kryptonPalette1;
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.fEditInfoDialog_Load);
            this.panel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pnBtn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txbNewName;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpNewStartTime;
        private System.Windows.Forms.Panel panel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lbNameAction;
        private System.Windows.Forms.Panel pnBtn;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSave;
        private ComponentFactory.Krypton.Toolkit.KryptonPalette kryptonPalette1;
    }
}