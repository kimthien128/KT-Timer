﻿using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KT_Timer_App
{
    internal class MyTask
    {
        private Module module = Module.Instance();
        private DataHandle dataHandle = DataHandle.Instance();

        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public List<Step> Steps { get; set; }
        public bool Repeat { get; set; }
        public int WaitingTime { get; set; } // mỗi step cách nhau 1 khoảng thời gian
        public bool IsComplete { get; set; } //chạy xong == true
        public bool IsSuccess { get; set; } //thành công == true

        private Timer timer = new Timer(); //timer này để chạy lbRemaining + cbRepeat
        private KryptonLabel lbRemaining;
        private KryptonCheckBox cbRepeat;
        private KryptonNumericUpDown nudWaitingTime;
        private IUpdatableForm fMain;
        private Color bgColor = Color.FromArgb(217, 235, 255);
        private Color textColor = Color.FromArgb(0, 0, 0);
        private Color mainColor = Color.FromArgb(0, 122, 255);
        private Color successColor = Color.FromArgb(52, 199, 89);
        private Color failureColor = Color.FromArgb(255, 59, 48);
        public MyTask(int id, string name, DateTime startTime)
        {
            this.ID = id;
            this.Name = name;
            this.StartTime = startTime;
            IsSuccess = false;
            IsComplete = false;
        }
        public void SelectFormMain(fMain formMain)
        {
            this.fMain = formMain;
        }
        public KryptonPanel CreatePanel()
        {
            KryptonPanel childPanel = new KryptonPanel();
            childPanel.Width = 623;
            childPanel.Height = 74;
            childPanel.StateNormal.Color1 = Color.FromArgb(242, 242, 247);
            childPanel.StateNormal.Color2 = Color.FromArgb(209, 211, 217);
            childPanel.StateNormal.ColorStyle = PaletteColorStyle.SolidBottomLine;
            childPanel.Padding = new Padding(5);

            //----------------------------------------------------
            KryptonPanel panelContainName = new KryptonPanel();
            panelContainName.Dock = DockStyle.Fill;
            panelContainName.StateNormal.Color1 = Color.Transparent;
            panelContainName.StateDisabled.Color1 = Color.Transparent;
            //
            KryptonLabel lbTaskName = new KryptonLabel();
            lbTaskName.Text = this.ID + ". " + this.Name;
            lbTaskName.LabelStyle = LabelStyle.BoldControl;
            lbTaskName.StateNormal.ShortText.Color1 = textColor;
            lbTaskName.AutoSize = true;
            lbTaskName.MinimumSize = new Size(150, 0);
            lbTaskName.Dock = DockStyle.Bottom;
            //
            KryptonPanel panelContainStatus = new KryptonPanel();
            panelContainStatus.Dock = DockStyle.Bottom;
            panelContainStatus.Height = 20;
            panelContainStatus.StateNormal.Color1 = Color.Transparent;
            panelContainStatus.StateDisabled.Color1 = Color.Transparent;
            //
            KryptonButton btnShowStatus = new KryptonButton();
            btnShowStatus.Text = string.Empty;
            btnShowStatus.Dock = DockStyle.Left;
            btnShowStatus.Width = 20;
            btnShowStatus.PaletteMode = PaletteMode.SparkleBlue;
            btnShowStatus.Enabled = false;
            btnShowStatus.StateDisabled.Border.Rounding = 20;
            btnShowStatus.StateDisabled.Border.Color1 = Color.Transparent;
            btnShowStatus.StateDisabled.Back.Color1 = mainColor;
            btnShowStatus.StateDisabled.Back.Color2 = Color.White;

            if (IsComplete)
            {
                if (IsSuccess) btnShowStatus.StateDisabled.Back.Color1 = successColor;
                else btnShowStatus.StateDisabled.Back.Color1 = failureColor;
            }

            panelContainStatus.Controls.Add(btnShowStatus);

            panelContainName.Controls.Add(lbTaskName);
            panelContainName.Controls.Add(panelContainStatus);

            //----------------------------------------------------
            KryptonPanel panelContainDateTime = new KryptonPanel();
            panelContainDateTime.Dock = DockStyle.Right;
            panelContainDateTime.Width = 130;
            panelContainDateTime.StateNormal.Color1 = Color.Transparent;
            panelContainDateTime.StateDisabled.Color1 = Color.Transparent;

            //
            KryptonLabel lbStartTime = new KryptonLabel();
            lbStartTime.Text = StartTime.ToString("dd/MM/yyyy") + "\n" + StartTime.ToString("HH:mm:ss");
            lbStartTime.StateNormal.ShortText.Color1 = textColor;
            lbStartTime.AutoSize = true;
            lbStartTime.MinimumSize = new Size(100, 0);
            lbStartTime.MaximumSize = new Size(100, 0);

            //
            cbRepeat = new KryptonCheckBox();
            cbRepeat.Text = "Repeat everyday";
            cbRepeat.Checked = Repeat;
            cbRepeat.Dock = DockStyle.Bottom;
            cbRepeat.StateNormal.ShortText.Color1 = textColor;
            cbRepeat.CheckedChanged += CbRepeat_CheckedChanged;

            panelContainDateTime.Controls.Add(lbStartTime);
            panelContainDateTime.Controls.Add(cbRepeat);

            //----------------------------------------------------
            KryptonPanel panelContainStep = new KryptonPanel();
            panelContainStep.Dock = DockStyle.Right;
            panelContainStep.Width = 80;
            panelContainStep.StateNormal.Color1 = Color.Transparent;
            panelContainStep.StateDisabled.Color1 = Color.Transparent;

            //
            KryptonButton btnViewDetailStep = new KryptonButton();
            btnViewDetailStep.Text = "View details";
            btnViewDetailStep.Dock = DockStyle.Bottom;
            btnViewDetailStep.Height = 32;
            btnViewDetailStep.Click += new EventHandler(btnViewDetailStep_Click);
            btnViewDetailStep.PaletteMode = PaletteMode.Office2007Blue;

            //
            KryptonLabel lbStep = new KryptonLabel();
            lbStep.AutoSize = true;
            lbStep.MinimumSize = new Size(50, 32);
            lbStep.Dock = DockStyle.Top;
            lbStep.LabelStyle = LabelStyle.GroupBoxCaption;

            if (this.Steps == null || this.Steps.Count == 0)
            {
                lbStep.Text = "0 steps";
                lbStep.StateNormal.ShortText.Color1 = Color.FromArgb(127, 127, 133);
                btnViewDetailStep.Enabled = false;
            }
            else
            {
                lbStep.Text = this.Steps.Count.ToString() + " steps";
                lbStep.StateNormal.ShortText.Color1 = textColor;
                btnViewDetailStep.Enabled = true;
            }

            panelContainStep.Controls.Add(lbStep);
            panelContainStep.Controls.Add(btnViewDetailStep);

            //timer----------------------------------------------------

            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            //----------------------------------------------------
            KryptonPanel panelContainRemaining = new KryptonPanel();
            panelContainRemaining.Dock = DockStyle.Right;
            panelContainRemaining.Width = 150;
            panelContainRemaining.StateNormal.Color1 = Color.Transparent;
            panelContainRemaining.StateDisabled.Color1 = Color.Transparent;
            panelContainRemaining.Padding = new Padding(0,0,8,0);

            //
            KryptonPanel panelContainRemainingTop = new KryptonPanel();
            panelContainRemainingTop.Dock = DockStyle.Top;
            panelContainRemainingTop.Height = 38;
            panelContainRemainingTop.StateNormal.Color1 = Color.Transparent;
            panelContainRemainingTop.StateDisabled.Color1 = Color.Transparent;

            //
            lbRemaining = new KryptonLabel();
            lbRemaining.Text = string.Empty;
            lbRemaining.StateNormal.ShortText.Color1 = textColor;
            //lbRemaining.AutoSize = true;
            //lbRemaining.MinimumSize = new Size(150, 0);
            //lbRemaining.MaximumSize = new Size(150, 0);
            lbRemaining.LabelStyle = LabelStyle.BoldControl;
            lbRemaining.Dock = DockStyle.Fill;

            //
            KryptonPanel panelContainRemainingBottom = new KryptonPanel();
            panelContainRemainingBottom.Dock = DockStyle.Bottom;
            panelContainRemainingBottom.Height = 26;
            panelContainRemainingBottom.StateNormal.Color1 = Color.Transparent;
            panelContainRemainingBottom.StateDisabled.Color1 = Color.Transparent;

            //
            KryptonLabel lbWaitingTime = new KryptonLabel();
            lbWaitingTime.Text = "Time interval (s):";
            lbWaitingTime.LabelStyle = LabelStyle.NormalControl;
            lbWaitingTime .Dock = DockStyle.Right;
            lbWaitingTime.StateNormal.ShortText.Color1 = textColor;

            //
            nudWaitingTime = new KryptonNumericUpDown();
            nudWaitingTime.Minimum = 1;
            nudWaitingTime.Maximum = 60;
            if (WaitingTime <= nudWaitingTime.Minimum) WaitingTime = (int)nudWaitingTime.Minimum;
            if (WaitingTime >= nudWaitingTime.Maximum) WaitingTime = (int)nudWaitingTime.Maximum;
            nudWaitingTime.Value = WaitingTime;
            nudWaitingTime.Width = 40;
            nudWaitingTime.Dock = DockStyle.Right;
            nudWaitingTime.ValueChanged += NudWaitingTime_ValueChanged;

            //
            panelContainRemaining.Controls.Add(panelContainRemainingTop);
            panelContainRemainingTop.Controls.Add(lbRemaining);
            panelContainRemaining.Controls.Add(panelContainRemainingBottom);
            panelContainRemainingBottom.Controls.Add(lbWaitingTime);
            panelContainRemainingBottom.Controls.Add(nudWaitingTime);

            //----------------------------------------------------
            KryptonPanel panelContainButton = new KryptonPanel();
            panelContainButton.Dock = DockStyle.Right;
            panelContainButton.Width = 80;
            panelContainButton.StateNormal.Color1 = Color.Transparent;
            
            //
            KryptonButton btnAddStep = new KryptonButton();
            btnAddStep.Text = "Add step";
            btnAddStep.Dock = DockStyle.Top;
            btnAddStep.Height = 32;
            btnAddStep.Click += new EventHandler(btnAddStep_Click);
            btnAddStep.PaletteMode = PaletteMode.Office2007Blue;

            //
            KryptonButton btnDeleteTask = new KryptonButton();
            btnDeleteTask.Text = "Delete Task";
            btnDeleteTask.Dock = DockStyle.Bottom;
            btnDeleteTask.Height = 32;
            btnDeleteTask.Click += new EventHandler(btnDeleteTask_Click);
            btnDeleteTask.PaletteMode = PaletteMode.Office2007Blue;

            panelContainButton.Controls.Add(btnAddStep);
            panelContainButton.Controls.Add(btnDeleteTask);

            //Disable khi complete ----------------------------------------------------
            if (IsComplete)
            {
                // Thêm Strikethrough vào FontStyle hiện tại của label1
                lbTaskName.StateNormal.ShortText.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular | FontStyle.Strikeout);
                lbRemaining.Text = "     Time out";
                panelContainDateTime.Enabled = false;
                panelContainRemaining.Enabled = false;
                btnAddStep.Enabled = false;
                timer.Stop();
            }


            //----------------------------------------------------
            childPanel.Controls.Add(panelContainName); //thằng nào Add trước thì bị thằng sau chiếm chỗ
            childPanel.Controls.Add(panelContainDateTime);
            childPanel.Controls.Add(panelContainStep);
            childPanel.Controls.Add(panelContainRemaining);
            childPanel.Controls.Add(panelContainButton);
            

            return childPanel;
        }

        private void CbRepeat_CheckedChanged(object sender, EventArgs e)
        {
            Repeat = cbRepeat.Checked;

            //thay đổi xong thì lưu data
            dataHandle.GhiDuLieu(module.Tasks);
        }

        private void NudWaitingTime_ValueChanged(object sender, EventArgs e)
        {
            WaitingTime = (int)nudWaitingTime.Value;
            module.log = $"{DateTime.Now} | Task: {ID} | Set Time Interval = {nudWaitingTime.Value}";

            //thay đổi timeStart của từng step con
            if (Steps != null && Steps.Count > 0)
            for(int i = 0; i < Steps.Count; i++)
            {
                    Steps[i].StartTime = StartTime.AddSeconds(WaitingTime * i);
            }

            //thay đổi xong thì lưu data
            dataHandle.GhiDuLieu(module.Tasks);
        }

        public void timer_Tick(object sender, EventArgs e)
        {
            WaitingTime = (int)nudWaitingTime.Value;

            if (StartTime > DateTime.Now)
                lbRemaining.Text = "     remaining " + Convert.ToString((int)(StartTime - DateTime.Now).TotalSeconds) + "s";
            else
            {
                //nên cho run task ở đây
                

                //sau khi run xong mới check repeat
                if (Repeat)
                    StartTime = StartTime.AddDays(1);
                else
                    lbRemaining.Text = "     Time out";
            }
        }
        public void btnAddStep_Click(object sender, EventArgs e)
        {
            module.taskIDCurrent = ID;
            fAddStep f = fAddStep.Instance();
            f.ShowDialog();

            fMain fMain = fMain.Instance();
            fMain.UpdateUI();
        }
        public void btnDeleteTask_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to delete the task?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(dr == DialogResult.OK)
            {
                module.Tasks.RemoveAt(ID);
                fMain.UpdateUI();
                timer.Stop();
            }
            
            //xóa task xong thì lưu data
            dataHandle.GhiDuLieu(module.Tasks);
        }
        public void btnViewDetailStep_Click(object sender, EventArgs e)
        {
            module.taskIDCurrent = ID;
            fDetailTask f = fDetailTask.Instance();
            f.ShowDialog();

            fMain fMain = fMain.Instance();
            fMain.UpdateUI();
        }
        
    }
}