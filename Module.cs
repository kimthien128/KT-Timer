using ComponentFactory.Krypton.Toolkit;
using KAutoHelper;
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


        public class EnumItem
        {
            public KeyCode Key { get; set; }
            public ushort Value { get; set; }

            public EnumItem(KeyCode key)
            {
                Key = key;
                Value = (ushort)key;
            }
        }


        public void LoadEnumValuesByRange(KryptonComboBox comboBox, ushort minValue, ushort maxValue)
        {
            // Tạo danh sách các item từ enum và lọc theo khoảng giá trị
            List<EnumItem> newItems = Enum.GetValues(typeof(KeyCode))
                                           .Cast<KeyCode>()
                                           .Select(k => new EnumItem(k))
                                           .Where(item => item.Value >= minValue && item.Value <= maxValue)
                                           .ToList();

            // Lấy danh sách item hiện có trong ComboBox
            List<EnumItem> existingItems = comboBox.DataSource as List<EnumItem> ?? new List<EnumItem>();

            // Thêm các giá trị mới vào danh sách nếu chưa có
            foreach (var item in newItems)
            {
                if (!existingItems.Any(i => i.Value == item.Value)) // Kiểm tra trùng lặp
                {
                    existingItems.Add(item); // Thêm vào danh sách nếu chưa tồn tại
                }
            }

            // Cập nhật lại DataSource của ComboBox
            comboBox.DataSource = null;

            // Gán DataSource cho ComboBox
            comboBox.DataSource = existingItems;
            comboBox.DisplayMember = "Key";   // Hiển thị tên enum
            comboBox.ValueMember = "Value";   // Giá trị tương ứng
        }





        public void LoadSelectedEnumValues(KryptonComboBox comboBox, params KeyCode[] selectedValues)
        {
            // Đưa các giá trị đã chọn vào ComboBox
            comboBox.DataSource = selectedValues.ToList();
        }
    }

}
