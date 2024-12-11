using ComponentFactory.Krypton.Toolkit;
using KAutoHelper;
using KT_Timer_App.Entity;
using KT_Timer_App.Handle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace KT_Timer_App
{
    public partial class fMain : KryptonForm, IUpdateUI
    {
        private Module module = Module.Instance();
        private DataHandle dataHandle = DataHandle.Instance();
        private LogHandle logHandle = LogHandle.Instance();
        private fAbout formAbout = fAbout.Instance();

        public NotifyIcon NotifyIconFMain { get; set; }
        private ToolTip toolTipFMain;

        //
        private static fMain instance;
        public static fMain Instance()
        {
            if (instance == null) instance = new fMain();
            return instance;
        }
        private fMain()
        {
            InitializeComponent();
            NotifyIconFMain = notifyIcon1;
            logHandle.LoadLog();
            toolTipFMain = new ToolTip();
            toolTipFMain.SetToolTip(pbShowLogTable, "Show/Hide Log Table");
            toolTipFMain.SetToolTip(pbClearLog, "Clear Log");
            toolTipFMain.SetToolTip(pbLogo, "About");

            //mới khởi tạo thì hiện panel log
            pnLog.Visible = true;

            //không cho chọn thời gian ở quá khứ
            dtpTaskStartTime.MinDate = DateTime.Today;
        }
        
        private void Main_Load(object sender, EventArgs e)
        {
            timerLbTimeNow.Start();
            module.Tasks = dataHandle.ReadData();
            //load form lên, nếu trong data có 1 task nào ở quá khứ mà không repeat thì gán cho là hoàn thành
            //tiện thể truyền fMain vào cho các task con nhận giá trị để dễ gọi
            foreach (KTTask task in module.Tasks)
            {
                //check minStartTime lần đầu
                if (task.StartTime <= module.minStartDateTime)
                {
                    module.minStartDateTime = task.StartTime;
                }

                //truyền fMain vào cho mỗi task
                task.SelectFormMain(this);
                
                if(task.StartTime < DateTime.Now)
                {
                    if (task.Repeat)
                    {
                        // Lấy thời gian hiện tại
                        DateTime today = DateTime.Today;

                        // Tạo DateTime với ngày hôm nay và thời gian gốc của inputDate
                        DateTime newDate = new DateTime(today.Year, today.Month, today.Day,
                                                        task.StartTime.Hour, task.StartTime.Minute, task.StartTime.Second);

                        // Kiểm tra nếu newDate vẫn nhỏ hơn hiện tại (nghĩa là hôm nay đã trôi qua giờ đó)
                        if (newDate < DateTime.Now)
                        {
                            // thì chuyển sang ngày mai
                            task.StartTime = newDate.AddDays(1);
                        }
                        else
                        {
                            task.StartTime = newDate;
                        }
                    }
                    else
                    {
                        task.IsComplete = true;
                    }
                }
            }
            UpdateUI();
        }
        private void fMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            timerLbTimeNow.Stop();
        }
        private void timerLbTimeNow_Tick(object sender, EventArgs e)
        {
            lbTimeNow.Text = DateTime.Now.ToString("dd/MM/yyyy | HH:mm:ss");
            //txbTaskName.Text = module.minStartDateTime.ToString();
            //cập nhật cho task bar
            if (notifyIcon1.Visible)
            {
                if (module.minStartDateTime == DateTime.MaxValue)
                    notifyIcon1.Text = "Empty task...";
                else
                    //cập nhật cho task bar
                    notifyIcon1.Text = "Next task : " + module.minStartDateTime.ToString("HH:mm:ss");
                    
            }    

            //ở đây chỉ check minStartDateTime rồi cập nhật cho module, trong mỗi task tự kiểm tra
            //nếu gần tới thời gian chạy của task gần nhất thì mới kiểm tra, thực hiện, xóa các kiểu, tránh tốn chi phí vòng for
            if (DateTime.Now >= module.minStartDateTime)
            {
                for (int i = 0; i < module.Tasks.Count; i++)
                {
                    if (module.Tasks[i].StartTime <= DateTime.Now)
                    {
                        if(!module.Tasks[i].IsComplete)
                        {
                            //thực hiện task nếu task vẫn chưa xong
                            module.Tasks[i].RunTask();
                        }    
                        else
                        {
                            //cập nhật giao diện
                            UpdateIndexes(i);
                            UpdateUI();

                            //set lại minStartDateTime mới
                            module.SetMinStartDateTime();

                            //chạy xong thì lưu data
                            dataHandle.WriteData(module.Tasks);
                            
                            //break;
                        }    
                    }
                }
            }
        }

        private void btnAddNewTask_Click(object sender, EventArgs e)
        {
            int taskID = module.Tasks.Count;
            
            string taskName = txbTaskName.Text;
            if (string.IsNullOrEmpty(txbTaskName.Text))
            {
                MessageBox.Show("Please enter a task name.");
                return;
            }
            
            DateTime taskStartTime = dtpTaskStartTime.Value;
            if(dtpTaskStartTime.Value <= DateTime.Now)
            {
                MessageBox.Show("Please select a future time.");
                return;
            }
            if(dtpTaskStartTime.Value <= module.minStartDateTime)
            {
                module.minStartDateTime = dtpTaskStartTime.Value;
            }

            KTTask task = new KTTask(taskID,taskName, taskStartTime);
            task.SelectFormMain(this); //set form main để bên trong class biết cha của nó
            module.Tasks.Add(task);
            logHandle.AddLog(taskID, $"Add new task : '{taskName}'");
            UpdateUI();

            //tạo task xong thì lưu data
            dataHandle.WriteData(module.Tasks);
        }
        public void UpdateUI()
        {
            flpTaskList.Controls.Clear();
            UpdateIndexes(0);
            foreach (KTTask task in module.Tasks)
            {
                KryptonPanel childPanel = task.CreatePanel();
                flpTaskList.Controls.Add(childPanel);
            }

            RefreshLogTableUI();
        }
        public void RefreshLogTableUI()
        {
            // Refresh lại DataGridView
            dgvLog.DataSource = logHandle.GetLogList();
            if (dgvLog.Rows.Count > 0)
            {
                dgvLog.CurrentCell = dgvLog.Rows[0].Cells[0]; // luôn chọn hàng đầu tiên
            }
        }
        private void UpdateIndexes(int startIndex)
        {
            for (int i = startIndex; i < module.Tasks.Count; i++)
            {
                module.Tasks[i].ID = i;
            }
        }

        private void lbClearTxbTaskName_Click(object sender, EventArgs e)
        {
            txbTaskName.Text = string.Empty;
        }
        
        private void pbClearLog_Click(object sender, EventArgs e)
        {
            logHandle.ClearLog();
        }
        private void pbShowTableLog_Click(object sender, EventArgs e)
        {
            if (pnLog.Visible)
            {
                pnLog.Visible = false;
                pbShowLogTable.Image = Properties.Resources.icons8_closed_eye_96px;
            }
            else
            {
                pnLog.Visible = true;
                pbShowLogTable.Image = Properties.Resources.icons8_eye_96px;
            }
        }
        private void pbLogo_Click(object sender, EventArgs e)
        {
            formAbout.ShowDialog();
        }

        /// <summary>
        /// Set icon and info on TaskBar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fMain_SizeChanged(object sender, EventArgs e)
        {
            bool MousePoiterNotOnTaskBar = Screen.GetWorkingArea(this).Contains(Cursor.Position);

            if(this.WindowState == FormWindowState.Minimized && MousePoiterNotOnTaskBar)
            {
                notifyIcon1.Icon = this.Icon;
                this.ShowInTaskbar = false;
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            if(this.WindowState == FormWindowState.Normal)
            {
                this.ShowInTaskbar = true;
                notifyIcon1.Visible = false;
            }
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
        
    }
}
