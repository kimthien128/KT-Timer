using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace KT_Timer_App
{
    internal class DataHandle
    {
        private string filepath = Directory.GetParent(Environment.CurrentDirectory).FullName + "\\data.json";

        private static DataHandle instance;
        public static DataHandle Instance()
        {
            if(instance == null) instance = new DataHandle();
            return instance;
        }

        private DataHandle() { }
        public List<MyTask> DocDuLieu()
        {
            if(!File.Exists(filepath))
            {
                return new List<MyTask>();
            }
            var jsonData = File.ReadAllText(filepath);
            return JsonConvert.DeserializeObject<List<MyTask>>(jsonData);
        }

        public void GhiDuLieu(List<MyTask> tasksList)
        {
            var jsonData = JsonConvert.SerializeObject(tasksList);
            File.WriteAllText(filepath, jsonData);
        }
    }
}
