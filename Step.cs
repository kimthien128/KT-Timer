using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KT_Timer_App
{
    internal class Step
    {
        public int ParentID {  get; set; }
        public int ID { get; set; }
        public string Name { get; set; } //Tên step cần thực hiện
        public DateTime StartTime { get; set; }
        public bool Condition { get; set; } //VD step trước đó đã hoàn thành chưa, hoặc nút gì đó đã xuất hiện chưa
        public string ImageCondition { get; set; }
        public ActionType Action { get; set; }
        public string ActionDescription { get; set; }
        public bool IsComplete { get; set; } // trạng thái hoàn thành hay chưa
        public Step (int parentID, int id, string name, DateTime startTime, bool condition, string linkCondition, ActionType type, string actionDescription)
        {
            this.ParentID = parentID;
            this.ID = id;
            this.Name = name;
            this.StartTime = startTime;
            this.Condition = condition;
            this.ImageCondition = linkCondition;
            this.Action = type;
            this.ActionDescription = actionDescription;
        }
    }
}
