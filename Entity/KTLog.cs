using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT_Timer_App.Entity
{
    internal class KTLog
    {
        public DateTime Time { get; set; }
        public int Task {  get; set; }
        public string TaskName {  get; set; }
        public string Log { get; set; }
        public KTLog(DateTime time, int task, string taskName, string log)
        {
            Time = time;
            Task = task;
            TaskName = taskName;
            Log = log;
        }
    }
}
