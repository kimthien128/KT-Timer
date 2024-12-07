using ComponentFactory.Krypton.Toolkit;
using Emgu.CV.Dnn;
using KAutoHelper;
using KT_Timer_App.Handle;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace KT_Timer_App
{
    internal class KTTask
    {
        private Module module = Module.Instance();
        private DataHandle dataHandle = DataHandle.Instance();
        private LogHandle logHandle = LogHandle.Instance();

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
        private IUpdateUI fMain;
        private Color bgColor = Color.FromArgb(217, 235, 255);
        private Color textColor = Color.FromArgb(0, 0, 0);
        private Color mainColor = Color.FromArgb(0, 122, 255);
        private Color successColor = Color.FromArgb(52, 199, 89);
        private Color failureColor = Color.FromArgb(255, 59, 48);
        public KTTask(int id, string name, DateTime startTime)
        {
            this.ID = id;
            this.Name = name;
            this.StartTime = startTime;
            this.Steps = new List<Step>();
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
            childPanel.Width = 750;
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
            PictureBox pbEditName = new PictureBox();
            pbEditName.Size = new Size(25,25);
            pbEditName.SizeMode = PictureBoxSizeMode.Zoom;
            pbEditName.Image = Properties.Resources.icons8_edit_80px;
            pbEditName.Dock = DockStyle.Right;
            pbEditName.Cursor = Cursors.Hand;
            pbEditName.Click += PbEditName_Click;

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
            panelContainName.Controls.Add(pbEditName);
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
            PictureBox pbEditStarTime = new PictureBox();
            pbEditStarTime.Size = new Size(25, 25);
            pbEditStarTime.SizeMode = PictureBoxSizeMode.Zoom;
            pbEditStarTime.Image = Properties.Resources.icons8_edit_80px;
            pbEditStarTime.Dock = DockStyle.Right;
            pbEditStarTime.Cursor = Cursors.Hand;
            pbEditStarTime.Click += PbEditStarTime_Click;
            //
            cbRepeat = new KryptonCheckBox();
            cbRepeat.Text = "Repeat everyday";
            cbRepeat.Checked = Repeat;
            cbRepeat.Dock = DockStyle.Bottom;
            cbRepeat.StateNormal.ShortText.Color1 = textColor;
            cbRepeat.CheckedChanged += CbRepeat_CheckedChanged;

            panelContainDateTime.Controls.Add(lbStartTime);
            panelContainDateTime.Controls.Add(pbEditStarTime);
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

            if (this.Steps.Count == 0)
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
            KryptonPanel panelContainButton2 = new KryptonPanel();
            panelContainButton2.Dock = DockStyle.Right;
            panelContainButton2.Width = 80;
            panelContainButton2.StateNormal.Color1 = Color.Transparent;

            //
            KryptonButton btnRunNow = new KryptonButton();
            btnRunNow.Text = "Run now";
            btnRunNow.Dock = DockStyle.Top;
            btnRunNow.Height = 32;
            btnRunNow.Click += new EventHandler(btnRunNow_Click);
            btnRunNow.PaletteMode = PaletteMode.Office2007Blue;
            btnRunNow.Enabled = false;
            if(Steps.Count > 0) btnRunNow.Enabled = true;

            //
            KryptonButton btnReEnable = new KryptonButton();
            btnReEnable.Text = "Re-Enable";
            btnReEnable.Dock = DockStyle.Bottom;
            btnReEnable.Height = 32;
            btnReEnable.Click += new EventHandler(btnReEnable_Click);
            btnReEnable.PaletteMode = PaletteMode.Office2007Blue;
            btnReEnable.Enabled = false;

            panelContainButton2.Controls.Add(btnRunNow);
            panelContainButton2.Controls.Add(btnReEnable);

            //----------------------------------------------------
            KryptonPanel panelContainButton1 = new KryptonPanel();
            panelContainButton1.Dock = DockStyle.Right;
            panelContainButton1.Width = 80;
            panelContainButton1.StateNormal.Color1 = Color.Transparent;
            
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

            panelContainButton1.Controls.Add(btnAddStep);
            panelContainButton1.Controls.Add(btnDeleteTask);

            //Disable khi complete ----------------------------------------------------
            if (IsComplete)
            {
                // Thêm Strikethrough vào FontStyle hiện tại của label1
                lbTaskName.StateNormal.ShortText.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular | FontStyle.Strikeout);
                pbEditName.Visible = false;
                pbEditStarTime.Visible = false;
                lbRemaining.Text = "     Time out";
                panelContainDateTime.Enabled = false;
                panelContainRemaining.Enabled = false;
                btnAddStep.Enabled = false;
                //timer.Stop();
                btnReEnable.Enabled = true;
            }


            //----------------------------------------------------
            childPanel.Controls.Add(panelContainName); //thằng nào Add trước thì bị thằng sau chiếm chỗ
            childPanel.Controls.Add(panelContainDateTime);
            childPanel.Controls.Add(panelContainStep);
            childPanel.Controls.Add(panelContainRemaining);
            childPanel.Controls.Add(panelContainButton2);
            childPanel.Controls.Add(panelContainButton1);
            

            return childPanel;
        }

        //run task
        public bool RunTask()
        {
            // Kiểm tra nếu task có các bước (steps) cần thực hiện
            if (Steps.Count > 0)
            {
                if (IsComplete) return true;
                
                bool checkOk = true;

                for (int i = 0; i < Steps.Count; i++)
                {
                    if (Steps[i].IsComplete) continue;
                    if(i==0) logHandle.AddLog(ID, "Task start");

                    Step step = Steps[i];
                    checkOk = true;

                    if (DateTime.Now >= step.StartTime)
                    {
                        //nếu step trước đó chưa hoàn thành thì bị lỗi => dừng task
                        if (i > 0 && !Steps[i - 1].IsComplete)
                        {
                            IsSuccess = false;
                            IsComplete = true;
                            checkOk = false;
                            break;
                        }

                        // Nếu cần kiểm tra điều kiện trước khi thực hiện action
                        if (step.Condition)
                        {
                            // Kiểm tra sự tồn tại của hình ảnh (image condition)
                            if (!CheckImageExist(ID, step.ImageCondition))
                            {
                                logHandle.AddLog(ID, $"Hình ảnh \"{step.ImageCondition}\" không tồn tại");
                                checkOk = false;
                            }
                        }

                        // Nếu điều kiện OK, thực thi action
                        if (checkOk)
                        {
                            checkOk = step.Action.Execute();
                            if (!checkOk)
                            {
                                step.IsComplete = false;
                                IsSuccess = false;
                                IsComplete = true;
                                logHandle.AddLog(ID, $"Task failed");
                                break;
                            }
                            else
                            {
                                step.IsComplete = true; // Đánh dấu bước đã hoàn thành

                                //nếu là step cuối cùng thì đánh dấu toàn bộ thành công
                                if (i == Steps.Count - 1)
                                {
                                    IsSuccess = true;
                                    IsComplete = true;
                                    logHandle.AddLog(ID, $"Task success");
                                }
                            }
                        }
                        else
                        {
                            step.IsComplete = false;
                            IsSuccess = false;
                            IsComplete = true;
                            logHandle.AddLog(ID, $"Task failed");
                            checkOk = false;
                            break;
                        }
                        
                    }
                }
                return checkOk;
            }
            else
            {
                IsSuccess = true;
                IsComplete = true;
                return true;
            }
        }

        //hàm phụ cho run task
        private bool CheckImageExist(int taskID, string imagePath)
        {
            //Cần copy toàn bộ file thư viện xử lý ảnh vào thư mục Debug

            var screen = CaptureHelper.CaptureScreen();//kết quả chụp màn hình
            //screen.Save("screen.PNG"); //lưu màn hình

            if (File.Exists(imagePath))
            {
                var subBitmap = ImageScanOpenCV.GetImage(imagePath); //truyền hình ảnh cần kiểm tra
                var resBitmap = ImageScanOpenCV.Find((Bitmap)screen, subBitmap);
                if (resBitmap != null)
                {
                    //tìm thấy vùng con
                    //resBitmap.Save("res.png");
                    return true;
                }
                return false; //không tìm thấy vùng con
            }
            else
            {
                logHandle.AddLog(taskID, $"Hình ảnh \"{imagePath}\" không tồn tại");
                return false;
            }
        }

        private void PbEditName_Click(object sender, EventArgs e)
        {
            fEditInfoDialog dialog = fEditInfoDialog.Instance();
            dialog.TaskID = ID;
            dialog.NewName = Name;
            dialog.NewStartTime = StartTime;
            dialog.Method = 1;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy giá trị từ dialog và cập nhật
                Name = dialog.NewName;
                logHandle.AddLog(ID, dialog.Status);

                //thay đổi xong thì lưu data
                dataHandle.WriteData(module.Tasks);

                fMain fMain = fMain.Instance();
                fMain.UpdateUI();
            }
        }
        private void PbEditStarTime_Click(object sender, EventArgs e)
        {
            fEditInfoDialog dialog = fEditInfoDialog.Instance();
            dialog.TaskID = ID;
            dialog.NewName = Name;
            dialog.NewStartTime = StartTime;
            dialog.Method = 2;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy giá trị từ dialog và cập nhật
                StartTime = dialog.NewStartTime;
                logHandle.AddLog(ID, dialog.Status);

                //set lại minStartDateTime
                module.SetMinStartDateTime();

                //thay đổi thời gian cho các step con
                SetStartTimeForChildStep();

                //thay đổi xong thì lưu data
                dataHandle.WriteData(module.Tasks);

                fMain fMain = fMain.Instance();
                fMain.UpdateUI();
            }
        }

        private void btnReEnable_Click(object sender, EventArgs e)
        {
            IsComplete = false;
            foreach (Step s in module.Tasks[ID].Steps)
            {
                s.IsComplete = false;
            }

            // Lấy thời gian hiện tại
            DateTime today = DateTime.Today;

            // Tạo DateTime với ngày hôm nay và thời gian gốc của inputDate
            DateTime newDate = new DateTime(today.Year, today.Month, today.Day, StartTime.Hour, StartTime.Minute, StartTime.Second);

            // Kiểm tra nếu newDate vẫn nhỏ hơn hiện tại (nghĩa là hôm nay đã trôi qua giờ đó)
            if (newDate < DateTime.Now)
            {
                // thì chuyển sang ngày mai
                StartTime = newDate.AddDays(1);
            }
            else
            {
                StartTime = newDate;
            }

            //set lại minStartDateTime
            module.SetMinStartDateTime();

            //thay đổi thời gian cho các step con
            SetStartTimeForChildStep();

            logHandle.AddLog(ID, "Re-Enable task");

            //thay đổi xong thì lưu data
            dataHandle.WriteData(module.Tasks);

            fMain fMain = fMain.Instance();
            fMain.UpdateUI();
        }

        private void btnRunNow_Click(object sender, EventArgs e)
        {
            // kích hoạt lại
            IsComplete = false;

            //set lại trạng thái isComplete cho các step con = false
            SetIsCompleteForChildStep();

            StartTime = DateTime.Now.AddSeconds(1);

            //thay đổi thời gian cho các step con
            SetStartTimeForChildStep();

            //set lại minStartDateTime
            module.SetMinStartDateTime();

            //thay đổi xong thì lưu data
            dataHandle.WriteData(module.Tasks);

            fMain fMain = fMain.Instance();
            fMain.UpdateUI();
        }

        private void CbRepeat_CheckedChanged(object sender, EventArgs e)
        {
            Repeat = cbRepeat.Checked;

            logHandle.AddLog(ID, $"Set Repeat everyday = {cbRepeat.Checked}");

            //thay đổi xong thì lưu data
            dataHandle.WriteData(module.Tasks);
        }

        private void NudWaitingTime_ValueChanged(object sender, EventArgs e)
        {
            WaitingTime = (int)nudWaitingTime.Value;
            logHandle.AddLog(ID, $"Set Time Interval = {nudWaitingTime.Value}s");

            //thay đổi timeStart của từng step con
            SetStartTimeForChildStep();

            //thay đổi xong thì lưu data
            dataHandle.WriteData(module.Tasks);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //WaitingTime = (int)nudWaitingTime.Value;

            if (StartTime > DateTime.Now)
                lbRemaining.Text = "     remaining " + Convert.ToString((int)(StartTime - DateTime.Now).TotalSeconds) + "s";
            else
            {
                //không nên cho run task ở đây, mặc dù bản thân nó tự chạy nhưng khi chọn chức năng run now sẽ phiền hơn
                //nếu nghiên cứu loại bỏ được minStartTime thì có thể runtask vào lại đây


                //check repeat
                if (IsComplete)
                {
                    //sau khi run xong mới check repeat
                    if (Repeat)
                    {
                        StartTime = StartTime.AddDays(1);

                        // kích hoạt lại
                        IsComplete = false;

                        //set lại trạng thái isComplete cho các step con = false
                        SetIsCompleteForChildStep();

                        //set lại minStartDateTime
                        module.SetMinStartDateTime();

                        //thay đổi thời gian cho các step con
                        SetStartTimeForChildStep();

                        //thay đổi xong thì lưu data
                        dataHandle.WriteData(module.Tasks);

                        fMain fMain = fMain.Instance();
                        fMain.UpdateUI();
                    }
                    else
                    {
                        lbRemaining.Text = "     Time out";
                        timer.Stop();
                    }
                }
            }
        }
        private void btnAddStep_Click(object sender, EventArgs e)
        {
            module.taskIDCurrent = ID;
            fAddStep f = fAddStep.Instance();
            f.Method = 1; //chế độ tạo mới
            if(f.ShowDialog() == DialogResult.OK)
                logHandle.AddLog(ID, "Add new step");

            fMain fMain = fMain.Instance();
            fMain.UpdateUI();
        }
        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to delete the task?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(dr == DialogResult.OK)
            {
                logHandle.AddLog(ID,"Delete task");
                module.Tasks.RemoveAt(ID);
                
                //xóa task xong thì lưu data
                dataHandle.WriteData(module.Tasks);
                
                fMain.UpdateUI();
                timer.Stop();
            }
        }
        private void btnViewDetailStep_Click(object sender, EventArgs e)
        {
            module.taskIDCurrent = ID;
            fDetailTask f = fDetailTask.Instance();
            f.ShowDialog();

            fMain fMain = fMain.Instance();
            fMain.UpdateUI();
        }
        
        private void SetStartTimeForChildStep()
        {
            if (Steps.Count > 0)
            {
                for (int i = 0; i < Steps.Count; i++)
                {
                    Steps[i].StartTime = StartTime.AddSeconds(WaitingTime * i);
                }
            }
        }

        private void SetIsCompleteForChildStep()
        {
            if (Steps.Count > 0)
            {
                foreach (Step s in module.Tasks[ID].Steps)
                {
                    s.IsComplete = false;
                }
            }
        }
    }
}
