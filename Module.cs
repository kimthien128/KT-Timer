using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT_Timer_App
{
    internal class Module
    {
        public List<MyTask> Tasks {  get; set; }
        public DateTime minStartDateTime { get; set; }
        public string log { get; set; }
        
        public int taskIDCurrent { get; set; }

        private static Module instance;
        public static Module Instance()
        {
            if(instance == null) instance = new Module();
            return instance;
        }
        private Module()
        {
            Tasks = new List<MyTask>();
            minStartDateTime = DateTime.MaxValue;
        }

        private string lastLog = string.Empty;
        public void WriteLog(KryptonTextBox TextBox)
        {
            if(log != lastLog)
            {
                TextBox.Text = log + Environment.NewLine + TextBox.Text; // Thêm văn bản
                //TextBox.SelectionStart = txbLog.Text.Length; // Đặt con trỏ ở cuối
                //TextBox.ScrollToCaret(); // Lăn đến vị trí con trỏ
                lastLog = log;
            }
        }

        public void SetMinStartDateTime()
        {
            //set lại minStartDateTime mới
            minStartDateTime = DateTime.MaxValue;
            for (int i = 0; i < Tasks.Count; i++)
            {
                if (Tasks[i].StartTime <= minStartDateTime && !Tasks[i].IsComplete)
                {
                    minStartDateTime = Tasks[i].StartTime;
                }
            }
        }
    }
}
