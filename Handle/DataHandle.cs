using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.ComponentModel;
using KT_Timer_App.Entity;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace KT_Timer_App
{
    internal class DataHandle
    {
        private string filepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\KT Timer\\data.json";
        //private string filepath = Environment.CurrentDirectory + "\\data.json";

        private static DataHandle instance;
        public static DataHandle Instance()
        {
            if(instance == null) instance = new DataHandle();
            return instance;
        }

        private DataHandle() { }
        public List<KTTask> ReadData()
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
                return new List<KTTask>();
            }
            else
            {
                StreamReader file = new StreamReader(filepath);
                var jsonData = file.ReadToEnd();
                var list = JsonConvert.DeserializeObject<List<KTTask>>(jsonData);
                file.Close();
                return list;
            }
        }

        public void WriteData(List<KTTask> tasksList)
        {
            var jsonData = JsonConvert.SerializeObject(tasksList);
            File.WriteAllText(filepath, jsonData);
        }
    }
}
