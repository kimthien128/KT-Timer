using ComponentFactory.Krypton.Toolkit;
using KAutoHelper;
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
    public partial class fMain : KryptonForm, IUpdatableForm
    {
        private Module module = Module.Instance();
        private DataHandle dataHandle = DataHandle.Instance();

        private static fMain instance;
        public static fMain Instance()
        {
            if (instance == null) instance = new fMain();
            return instance;
        }
        private fMain()
        {
            InitializeComponent();
        }
        
        private void Main_Load(object sender, EventArgs e)
        {
            timerLbTimeNow.Start();
            module.Tasks = dataHandle.DocDuLieu();
            //load form lên, nếu trong data có 1 task nào ở quá khứ mà không repeat thì gán cho là hoàn thành
            //tiện thể truyền fMain vào cho các task con nhận giá trị để dễ gọi
            foreach (MyTask task in module.Tasks)
            {
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

            module.WriteLog(txbLog); // log chỉ write khi có thay đổi nên để mỗi tick không sao

            //ở đây chỉ check minStartDateTime rồi cập nhật cho module, trong mỗi task tự kiểm tra
            //nếu gần tới thời gian chạy của task gần nhất thì mới kiểm tra, thực hiện, xóa các kiểu, tránh tốn chi phí vòng for
            if (DateTime.Now >= module.minStartDateTime)
            {
                for (int i = 0; i < module.Tasks.Count; i++)
                {
                    if (module.Tasks[i].StartTime <= DateTime.Now && !module.Tasks[i].IsComplete)
                    {

                        //thực hiện task, bool
                        RunTask(module.Tasks[i].ID);

                        //cập nhật giao diện
                        UpdateIndexes(i);
                        UpdateUI();

                        //đặt lại maxValue cho biến min
                        module.minStartDateTime = DateTime.MaxValue;
                        break;
                    }
                }

                //set lại minStartDateTime mới
                for (int i = 0; i < module.Tasks.Count; i++)
                {
                    if (module.Tasks[i].StartTime <= module.minStartDateTime && !module.Tasks[i].IsComplete)
                    {
                        module.minStartDateTime = dtpTaskStartTime.Value;
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

            MyTask task = new MyTask(taskID,taskName, taskStartTime);
            task.SelectFormMain(this); //set form main để bên trong class biết cha của nó
            module.Tasks.Add(task);
            UpdateUI();

            //tạo task xong thì lưu data
            dataHandle.GhiDuLieu(module.Tasks);
        }
        public void UpdateUI()
        {
            flpTaskList.Controls.Clear();
            UpdateIndexes(0);
            foreach (MyTask task in module.Tasks)
            {
                KryptonPanel childPanel = task.CreatePanel();
                flpTaskList.Controls.Add(childPanel);
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

        private void RunTask(int taskID)
        {
            // Kiểm tra nếu task có các bước (steps) cần thực hiện
            if (module.Tasks[taskID].Steps != null && module.Tasks[taskID].Steps.Count > 0)
            {
                if (module.Tasks[taskID].IsComplete) return;

                bool checkOk;

                for(int i = 0; i < module.Tasks[taskID].Steps.Count; i++)
                {
                    if (module.Tasks[taskID].Steps[i].IsComplete) continue;

                    Step step = module.Tasks[taskID].Steps[i];
                    checkOk = true;

                    if (DateTime.Now >= step.StartTime)
                    {
                        //nếu step trước đó chưa hoàn thành thì bị lỗi => dừng task
                        if (i > 0 && !module.Tasks[taskID].Steps[i-1].IsComplete)
                        {
                            module.Tasks[taskID].IsSuccess = false;
                            module.Tasks[taskID].IsComplete = true;
                            return;
                        }

                        // Nếu cần kiểm tra điều kiện trước khi thực hiện action
                        if (step.Condition)
                        {
                            // Kiểm tra sự tồn tại của hình ảnh (image condition)
                            if (!CheckImageExist(taskID, step.ImageCondition))
                            {
                                checkOk = false;
                            }
                        }

                        // Nếu điều kiện OK, thực thi action
                        if (checkOk)
                        {
                            if (step.Action.Execute())
                            {
                                step.IsComplete = true; // Đánh dấu bước đã hoàn thành
                            }
                            else
                            {
                                step.IsComplete = false;
                                module.Tasks[taskID].IsSuccess = false;
                                module.Tasks[taskID].IsComplete = true;
                                return;
                            }
                        }
                        else
                        {
                            step.IsComplete = false;
                            module.Tasks[taskID].IsSuccess = false;
                            module.Tasks[taskID].IsComplete = true;
                            return;
                        }

                        if(i == module.Tasks[taskID].Steps.Count - 1)
                        {
                            module.Tasks[taskID].IsSuccess = true;
                            module.Tasks[taskID].IsComplete = true;
                            return;
                        }
                    }
                }
            }
            else
            {
                module.Tasks[taskID].IsSuccess = true;
                module.Tasks[taskID].IsComplete = true;
            }
        }


        private bool CheckImageExist(int taskID, string imagePath)
        {
            //Cần copy toàn bộ file thư viện xử lý ảnh vào thư mục Debug

            var screen = CaptureHelper.CaptureScreen();//kết quả chụp màn hình
            //screen.Save("screen.PNG"); //lưu màn hình

            if(File.Exists(imagePath))
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
                module.log = $"{DateTime.Now} | Task: {taskID} | Hình ảnh \"{imagePath}\" không tồn tại";
                return false;
            }
        }

        private void pbSaveData_Click(object sender, EventArgs e)
        {
            dataHandle.GhiDuLieu(module.Tasks);
        }

        
    }
}
