using KT_Timer_App.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace KT_Timer_App.Handle
{
    internal class LogHandle
    {
        private string filepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\KT Timer\\log.json";
        //private string filepath = Environment.CurrentDirectory + "\\log.json";
        
        private BindingList<KTLog> logList; //dùng BindingList để khi thay đổi dữ liệu mới cập nhật

        public BindingList<KTLog> GetLogList() {  return logList; }

        //
        private static LogHandle instance;
        public static LogHandle Instance()
        {
            if (instance == null) instance = new LogHandle();
            return instance;
        }
        private LogHandle()
        {
            logList = new BindingList<KTLog>();
        }
        //
        public void LoadLog()
        {
            // Đảm bảo thư mục tồn tại trước khi tạo file
            string directoryPath = Path.GetDirectoryName(filepath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            if (!File.Exists(filepath))
            {
                using (StreamWriter file = File.CreateText(filepath))
                {
                    file.WriteLine("[]");
                }
                logList = new BindingList<KTLog>();
            }
            else
            {
                StreamReader file = new StreamReader(filepath);
                var jsonData = file.ReadToEnd();
                logList = JsonConvert.DeserializeObject<BindingList<KTLog>>(jsonData);
                file.Close();
            }
        }
        private void WriteLog(BindingList<KTLog> logList)
        {
            var jsonData = JsonConvert.SerializeObject(logList);
            File.WriteAllText(filepath, jsonData);
        }

        public void AddLog(int taskID, string log)
        {
            //dùng insert để đảm bảo log mới luôn lên đầu
            logList.Insert(0, new KTLog(DateTime.Now, taskID, Module.Instance().Tasks[taskID].Name, log));

            //đồng thời cũng ghi vào file
            WriteLog(logList);

            fMain fMain = fMain.Instance();
            fMain.RefreshLogTableUI();
        }

        public void ClearLog()
        {
            logList.Clear();
            WriteLog(logList);
        }
    }
}
