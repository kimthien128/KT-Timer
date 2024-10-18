using KAutoHelper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KT_Timer_App
{
    internal class ActionType
    {
        private Module module = Module.Instance();

        public int TaskID {  get; set; }
        public enum TypeAction { OpenApp, ClickButton, RunCommand }
        public TypeAction Type { get; set; }
        public string AppPath { get; set; } // Dùng cho OpenApp
        public string ButtonImage { get; set; } // Dùng cho ClickButton
        public string Command { get; set; } // Dùng cho RunCommand

        public bool Execute()
        {
            bool result = true;
            switch (Type)
            {
                case TypeAction.OpenApp:
                    try
                    {
                        Process.Start(AppPath);
                    }
                    catch
                    {
                        result = false;
                        MessageBox.Show("Invalid input");
                    }
                    
                    break;

                case TypeAction.ClickButton:
                    // Thực hiện logic nhấn nút
                    if (!CheckImageExistAndClick(ButtonImage))
                    {
                        result = false;
                    }
                    break;

                case TypeAction.RunCommand:
                    //làm phần hứng kết quả
                    ProcessStartInfo startInfo = new ProcessStartInfo("cmd.exe", "/c " + Command + " & pause");
                    try
                    {
                        Process.Start(startInfo);
                    }
                    catch
                    {
                        result = false;
                        MessageBox.Show("Invalid input");
                    }
                    break;
            }
            return result;
        }
        
        public bool CheckImageExistAndClick(string imagePath)
        {
            //Cần copy toàn bộ file thư viện xử lý ảnh vào thư mục Debug

            var screen = CaptureHelper.CaptureScreen();//kết quả chụp màn hình
            //screen.Save("screen.PNG"); //lưu màn hình

            if (File.Exists(imagePath))
            {
                var subBitmap = ImageScanOpenCV.GetImage(imagePath); //truyền hình ảnh cần kiểm tra
                Point? resBitmap = ImageScanOpenCV.FindOutPoint((Bitmap)screen, subBitmap);
                if (resBitmap != null)
                {
                    //tìm thấy vùng con
                    AutoControl.MouseClick(resBitmap.Value);
                    return true;
                }
                return false; //không tìm thấy vùng con
            }
            else
            {
                module.log += $"{DateTime.Now} | Task: {TaskID} | Hình ảnh \"{imagePath}\" không tồn tại" + Environment.NewLine;
                return false;
            }
        }
    }
}
