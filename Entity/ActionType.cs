using KAutoHelper;
using KT_Timer_App.Handle;
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
        private LogHandle logHandle = LogHandle.Instance();

        public int TaskID {  get; set; }
        public enum TypeAction { OpenApp, KillProcess, ClickButton, UseKeyboard, ShowMessage, RunCommand }
        public TypeAction Type { get; set; }
        public string AppPath { get; set; } // Dùng cho OpenApp
        public string ProcessName { get; set; } // Dùng cho KillProcess
        //public int ProcessId { get; set; } // Dùng cho KillProcess
        public string ButtonImage { get; set; } // Dùng cho ClickButton
        public int X { get; set; } // Dùng cho ClickButton
        public int Y { get; set; } // Dùng cho ClickButton
        public EMouseKey eMouseKey { get; set; } // Dùng cho ClickButton, 0: left, 1:right, 2:double left, 3: double right
        public enum TypeKeyboard { None, Shortcut, String}
        public TypeKeyboard KeyboardType { get; set; }
        public KeyCode[] keyCodes { get; set; }
        public string Text { get; set; }
        public string Message { get; set; }
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
                        Console.WriteLine("không thực hiện được Open App");
                        result = false;
                    }
                    break;
                case TypeAction.KillProcess:
                    try
                    {
                        Process[] processToKill = Process.GetProcessesByName(ProcessName);
                        processToKill[0].Kill(); //kill đứa đầu tiên tìm thấy
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Can not kill process: {ex.Message}");
                    }
                    break;
                case TypeAction.ClickButton:
                    // Thực hiện logic nhấn nút
                    if (!CheckImageExistAndClick(ButtonImage, eMouseKey))
                    {
                        result = false;
                    }
                    break;
                case TypeAction.UseKeyboard:
                    //Thực hiện dùng bàn phím
                    if (KeyboardType == TypeKeyboard.Shortcut)
                    {
                        // xử lý nhiều loại nút ở đây
                        AutoControl.SendMultiKeysFocus(keyCodes);
                    }
                    else if (KeyboardType == TypeKeyboard.String)
                    {
                        AutoControl.SendStringFocus(Text);
                    }
                    else
                        result = false;
                    break;
                case TypeAction.ShowMessage:
                    //thực hiện hiển thị message
                    fMain.Instance().NotifyIconFMain.Icon = fMain.Instance().Icon; //phải có icon mới chạy được
                    //fMain.Instance().NotifyIconFMain.Visible = true;
                    fMain.Instance().NotifyIconFMain.ShowBalloonTip(5000, "Message", Message, ToolTipIcon.Info);
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
                    }
                    break;
            }
            return result;
        }
        
        private bool CheckImageExistAndClick(string imagePath, EMouseKey eClick)
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
                    AutoControl.MouseClick(resBitmap.Value.X + X, resBitmap.Value.Y + Y, eClick);
                    return true;
                }
                return false; //không tìm thấy vùng con
            }
            else
            {
                logHandle.AddLog(TaskID, $"Hình ảnh \"{imagePath}\" không tồn tại");
                return false;
            }
        }
    }
}
