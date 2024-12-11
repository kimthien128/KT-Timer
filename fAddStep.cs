using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using KAutoHelper;
using static System.Net.Mime.MediaTypeNames;
using static KT_Timer_App.Module;
using System.Diagnostics;

namespace KT_Timer_App
{
    public partial class fAddStep : KryptonForm
    {
        private Module module = Module.Instance();
        private List<KTTask> tasks = Module.Instance().Tasks;
        private DataHandle dataHandle = DataHandle.Instance();
        //
        private Process[] processArr {  get; set; }
        //
        private int taskID;
        private int stepID;
        private string nameStep;
        private DateTime startTimeStep;
        private bool condition;
        private string linkCondition;
        private ActionType actionType;
        private string contentAction;
        //
        private OpenFileDialog openFileDialog = new OpenFileDialog();
        //
        public int Method { get; set; } //1: tạo mới , 2: cập nhật
        public void SetStepID(int stepId)
        {
            this.stepID = stepId;
        }
        //
        private static fAddStep instance;
        public static fAddStep Instance()
        {
            if (instance == null) instance = new fAddStep();
            return instance;
        }

        private fAddStep()
        {
            InitializeComponent();
        }

        private void fAddStep_Load(object sender, EventArgs e)
        {
            taskID = module.taskIDCurrent;

            lbParentTaskID.Text = "Task " + taskID.ToString();
            lbTaskName.Text = Module.Instance().Tasks[taskID].Name;

            //load process vào cbb
            processArr = Process.GetProcesses();
            cbbProcess.DataSource = processArr;
            cbbProcess.DisplayMember = "ProcessName";
            cbbProcess.ValueMember = "Id";
            

            //load các giá trị cần thiết vào cbb dùng cho keyboard
            List<KeyCodeItem> keycodeList = module.keyCodeList;
            List<KeyCodeItem> keycodeSeleted1 = new List<KeyCodeItem>();
            List<KeyCodeItem> keycodeSeleted2 = new List<KeyCodeItem>();
            List<KeyCodeItem> keycodeSeleted3 = new List<KeyCodeItem>();

            //tạo key empty trước
            KeyCodeItem keyEmpty = new KeyCodeItem();
            keyEmpty.NameKey = "";
            keyEmpty.Value = -1;

            //cbbKey1
            keycodeSeleted1 = module.GetSelectedKeyCodeValues(27,16,17,18,91, 13);
            keycodeSeleted1.Insert(0, keyEmpty);
            
            cbbKey1.DataSource = keycodeSeleted1;
            cbbKey1.DisplayMember = "NameKey";
            cbbKey1.ValueMember = "KeyCode";

            //cbbKey2
            keycodeSeleted2 = module.GetSelectedKeyCodeValues(27, 16, 17, 18, 91, 13);
            keycodeSeleted2.Insert(0, keyEmpty);

            cbbKey2.DataSource = keycodeSeleted2;
            cbbKey2.DisplayMember = "NameKey";
            cbbKey2.ValueMember = "KeyCode";

            //cbbKey3
            foreach (KeyCodeItem item in keycodeList)
            {
                if ( (item.Value >= 48 && item.Value <= 90) || (item.Value >= 112 && item.Value <= 123))
                {
                    keycodeSeleted3.Add(item);
                }
            }
            keycodeSeleted3.Insert(0, keyEmpty);
            cbbKey3.DataSource = keycodeSeleted3;
            cbbKey3.DisplayMember = "NameKey";
            cbbKey3.ValueMember = "KeyCode";


            //nếu là chế độ tạo mới
            if (Method == 1)
            {
                this.Text = "Add new step";
                btnAddStep.Visible = true;
                btnUpdateStep.Visible = false;

                if (tasks[taskID].Steps.Count == 0)
                    stepID = 0;
                else
                    stepID = tasks[taskID].Steps.Count;

                lbStepID.Text = "Step " + stepID;

                cbCheckCondition.Checked = false;
                txbLinkCondition.Enabled = false;
                btnBrowserCondition.Enabled = false;
                lbCheckCondition.Enabled = false;

                rbtnOpenApp.Checked = true;
                rbtnShortcutKey.Checked = true;
                rbtnEnterCommand.Checked = true;
            }
            //nếu là chế độ cập nhật
            else if (Method == 2)
            {
                this.Text = "Edit step " + stepID;
                btnAddStep.Visible = false;
                btnUpdateStep.Visible = true;

                Step s = tasks[taskID].Steps[stepID];

                txbStepName.Text = s.Name;
                this.startTimeStep = s.StartTime;
                
                //ImageCondition
                if (!string.IsNullOrEmpty(s.ImageCondition))
                {
                    cbCheckCondition.Checked = true;
                    txbLinkCondition.Text = s.ImageCondition;
                }
                else
                {
                    cbCheckCondition.Checked = false;
                    txbLinkCondition.Text = string.Empty;
                    txbLinkCondition.Enabled = false;
                    btnBrowserCondition.Enabled = false;
                    lbCheckCondition.Enabled = false;
                }
                
                //AppPath
                if (!string.IsNullOrEmpty(s.Action.AppPath))
                {
                    rbtnOpenApp.Checked = true;
                    txbLinkApp.Text = s.Action.AppPath;
                }
                else
                {
                    txbLinkApp.Text = string.Empty;
                }

                //ProcessName
                if (!string.IsNullOrEmpty(s.Action.ProcessName))
                {
                    rbtnKillProcess.Checked = true;
                    cbbProcess.SelectedIndex = SelectComboBoxByNameToIndex(cbbProcess,s.Action.ProcessName);
                }
                else
                {
                    cbbProcess.SelectedIndex = -1;
                }

                //ButtonImage
                if (!string.IsNullOrEmpty(s.Action.ButtonImage))
                {
                    rbtnClick.Checked = true;
                    txbLinkButtonImage.Text = s.Action.ButtonImage;
                    nudX.Value = s.Action.X;
                    nudY.Value = s.Action.Y;
                    switch ((int)s.Action.eMouseKey)
                    {
                        case 0: //left
                            cbRightClick.Checked = false;
                            cbDoubleClick.Checked = false;
                            break;
                        case 1: //right
                            cbRightClick.Checked = true;
                            cbDoubleClick.Checked = false;
                            break;
                        case 2: //double left
                            cbRightClick.Checked = false;
                            cbDoubleClick.Checked = true;
                            break;
                        case 3: //double right
                            cbRightClick.Checked = true;
                            cbDoubleClick.Checked = true;
                            break;
                        default:
                            cbRightClick.Checked = false;
                            cbDoubleClick.Checked = false;
                            break;
                    }
                }
                else
                {
                    txbLinkButtonImage.Text = string.Empty;
                }
                
                //KeyboardType
                switch ((int)s.Action.KeyboardType)
                {
                    case 0: //none
                        cbbKey1.SelectedIndex = -1;
                        cbbKey2.SelectedIndex = -1;
                        txbText.Text = string.Empty;
                        break;
                    case 1://shortcut
                        rbtnUseKeyboard.Checked = true;
                        rbtnShortcutKey.Checked = true;
                        short[] numbers = { 27, 16, 17, 18, 91, 13 };
                        //kiểm tra mảng có bao nhiêu phần tử
                        switch (s.Action.keyCodes.Length)
                        {
                            case 1:
                                short a1 = (short)s.Action.keyCodes[0];
                                if (numbers.Contains(a1)) //kiểm tra nó có thuộc về cbb1 không
                                {
                                    cbbKey1.SelectedValue = s.Action.keyCodes[0];
                                }
                                else // nếu không thì chắc chắn là của ccb3
                                {
                                    cbbKey3.SelectedValue = s.Action.keyCodes[0];
                                }
                                break;
                            case 2: // có 2 trường hợp 1-2, 1-3, vì 2-3 giống 1-3
                                //vậy [0] chắc chắn của ccb1
                                cbbKey1.SelectedValue = s.Action.keyCodes[0];

                                //chỉ cần xét thằng số 2
                                short b2 = (short)s.Action.keyCodes[1];
                                //TH 1-2
                                if (numbers.Contains(b2)) //kiểm tra nó có thuộc về cbb2 không
                                {
                                    cbbKey2.SelectedValue = s.Action.keyCodes[1];
                                }
                                else // nếu không thì chắc chắn là của ccb3
                                {
                                    cbbKey3.SelectedValue = s.Action.keyCodes[1];
                                }
                                break;
                            case 3:
                                cbbKey1.SelectedValue = s.Action.keyCodes[0];
                                cbbKey2.SelectedValue = s.Action.keyCodes[1];
                                cbbKey3.SelectedValue = s.Action.keyCodes[2];
                                break;
                            default:
                                break;
                        }
                        break;
                    case 2://string
                        rbtnUseKeyboard.Checked = true;
                        rbtnText.Checked = true;
                        txbText.Text = s.Action.Text;
                        break;
                    default:
                        break;
                }
                
                //Message
                if (!string.IsNullOrEmpty(s.Action.Message))
                {
                    rbtnShowMessage.Checked = true;
                    txbMessage.Text = s.Action.Message;
                }
                else
                {
                    txbMessage.Text = string.Empty;
                }
                
                //Command
                if (!string.IsNullOrEmpty(s.Action.Command))
                {
                    rbtnExecuteCommand.Checked = true;
                    if (s.Action.Command.Contains("shutdown"))
                    {
                        rbtnShutdown.Checked = true;
                    }
                    else
                    {
                        rbtnEnterCommand.Checked = true;
                        txbCommand.Text = s.Action.Command;
                    }
                }
                else
                {
                    txbCommand.Text = string.Empty;
                }
            }

        }
        private int SelectComboBoxByNameToIndex(KryptonComboBox comboBox, string name)
        {
            for (int i = 0; i < comboBox.Items.Count; i++)
            {
                var item = comboBox.Items[i];

                // Nếu sử dụng đối tượng, cần kiểm tra với thuộc tính Name
                if (item is Process process && process.ProcessName == name)
                {
                    comboBox.SelectedIndex = i;
                    return i;
                }
                // Nếu item là chuỗi hoặc kiểu khác, kiểm tra trực tiếp
                //else 
                //if (item.ToString() == name)
                //{
                //    comboBox.SelectedIndex = i;
                //    return i;
                //}
            }
            return -1;
        }
        private bool Valid()
        {
            contentAction = string.Empty;
            linkCondition = string.Empty;
            
            nameStep = txbStepName.Text;

            if(cbCheckCondition.Checked)
            {
                if(txbLinkCondition.Text == string.Empty)
                {
                    MessageBox.Show("Please upload the image to verify its existence (*.PNG)");
                    return false;
                }
                else
                {
                    linkCondition = txbLinkCondition.Text;
                }
            }

            if(rbtnOpenApp.Checked)
            {
                if (txbLinkApp.Text == string.Empty)
                {
                    MessageBox.Show("Please enter path application");
                    return false;
                }
                else
                {
                    actionType = new ActionType
                    {
                        Type = ActionType.TypeAction.OpenApp,
                        AppPath = txbLinkApp.Text,
                        TaskID = taskID
                    };
                    contentAction = "Open app \"" + txbLinkApp.Text + "\"";
                }
            }
            else if (rbtnKillProcess.Checked)
            {
                if(cbbProcess.SelectedValue == null)
                {
                    MessageBox.Show("Please select a process to close");
                    return false;
                }
                else
                {

                    actionType = new ActionType
                    {
                        Type = ActionType.TypeAction.KillProcess,
                        ProcessName = cbbProcess.Text,
                        //ProcessId = (int)cbbProcess.SelectedValue,
                        TaskID = taskID
                    };
                    contentAction = "Kill process \"" + cbbProcess.Text + "_" + cbbProcess.SelectedValue + "\"";
                }
            }
            else if(rbtnClick.Checked)
            {
                if (txbLinkButtonImage.Text == string.Empty)
                {
                    MessageBox.Show("Please enter path image (*.PNG)");
                    return false;
                }
                else
                {
                    //kiểm tra chọn click chuột như thế nào
                    EMouseKey eClick = EMouseKey.LEFT;
                    string typeClick = "Left";

                    if (cbRightClick.Checked)
                    {
                        if (cbDoubleClick.Checked)
                        {
                            eClick = EMouseKey.DOUBLE_RIGHT;
                            
                            typeClick = "Double Right";
                        }    
                        else
                        {
                            eClick = EMouseKey.RIGHT;
                            typeClick = "Right";
                        }    
                    }
                    else
                    {
                        if (cbDoubleClick.Checked)
                        {
                            eClick = EMouseKey.DOUBLE_LEFT;
                            typeClick = "Double Left";
                        }    
                    }

                    actionType = new ActionType
                    {
                        Type = ActionType.TypeAction.ClickButton,
                        ButtonImage = txbLinkButtonImage.Text,
                        eMouseKey = eClick,
                        X = (int)nudX.Value,
                        Y = (int)nudY.Value,
                        TaskID = taskID
                    };

                    contentAction = typeClick + " Click on button \"" + txbLinkButtonImage.Text + "\"";
                }
            }
            else if (rbtnUseKeyboard.Checked)
            {
                //cần làm rõ nội dung chổ này thêm nữa, có thể tạo 1 actiontype ban đầu khi khởi tạo step, chỉ cần truyền tham số trong mỗi if
                if(rbtnShortcutKey.Checked)
                {
                    List<KeyCode> validValues = new List<KeyCode>();
                    if(cbbKey1.SelectedIndex > 0) 
                        validValues.Add((KeyCode)cbbKey1.SelectedValue);
                    if(cbbKey2.SelectedIndex > 0) 
                        validValues.Add((KeyCode)cbbKey2.SelectedValue);
                    if(cbbKey3.SelectedIndex > 0) 
                        validValues.Add((KeyCode)cbbKey3.SelectedValue);

                    if(validValues.Count <= 0)
                    {
                        MessageBox.Show("Please select shortcut key");
                        return false;
                    }
                    else
                    {
                        actionType = new ActionType
                        {
                            Type = ActionType.TypeAction.UseKeyboard,
                            KeyboardType = ActionType.TypeKeyboard.Shortcut,
                            keyCodes = validValues.ToArray(),
                            TaskID = taskID
                        };
                        contentAction = "Shortcut Key : " + string.Join(" + ", validValues);
                    }
                }
                else if (rbtnText.Checked)
                {
                    if (string.IsNullOrEmpty(txbText.Text))
                    {
                        MessageBox.Show("Please enter text");
                        return false;
                    }
                    else
                    {
                        actionType = new ActionType
                        {
                            Type = ActionType.TypeAction.UseKeyboard,
                            KeyboardType = ActionType.TypeKeyboard.String,
                            Text = txbText.Text,
                            TaskID = taskID
                        };
                        contentAction = "Send Text \"" + txbText.Text + "\"";
                    }
                }
                else //nếu không có cái nào được chọn thì valid failed
                {
                    MessageBox.Show("Please select use keyboard method");
                    return false;
                }
            }
            else if (rbtnShowMessage.Checked)
            {
                if (txbMessage.Text == string.Empty)
                {
                    MessageBox.Show("Please enter message");
                    return false;
                }
                else
                {
                    actionType = new ActionType
                    {
                        Type = ActionType.TypeAction.ShowMessage,
                        Message = txbMessage.Text,
                        TaskID = taskID
                    };
                    contentAction = "Show message \"" + txbMessage.Text + "\""; ;
                }
            }
            else if(rbtnExecuteCommand.Checked)
            {
                if (rbtnEnterCommand.Checked)
                {
                    if(txbCommand.Text == string.Empty)
                    {
                        MessageBox.Show("Please enter command");
                        return false;
                    }
                    else
                    {
                        actionType = new ActionType
                        {
                            Type = ActionType.TypeAction.RunCommand,
                            Command = txbCommand.Text,
                            TaskID = taskID
                        };
                        contentAction = "Execute command \"" + txbCommand.Text + "\""; ;
                    }
                }
                else if (rbtnShutdown.Checked)
                {
                    actionType = new ActionType
                    {
                        Type = ActionType.TypeAction.RunCommand,
                        Command = "shutdown -s -t 1",
                        TaskID = taskID
                    };
                    contentAction = "Shutdown computer";
                }
                else //nếu không có cái nào được chọn thì valid failed
                {
                    MessageBox.Show("Please select Command method");
                    return false;
                }

            }
            return true;
        }

        private void btnAddStep_Click(object sender, EventArgs e)
        {
            if (Valid())
            {
                condition = cbCheckCondition.Checked;
                startTimeStep = tasks[taskID].StartTime.AddSeconds(tasks[taskID].WaitingTime * stepID);
                Step step = new Step(taskID, stepID, nameStep, startTimeStep, condition, linkCondition, actionType, contentAction);

                tasks[taskID].Steps.Add(step);

                //reset trạng thái 1 số btn
                txbStepName.Text = string.Empty;
                cbRightClick.Checked = false;
                cbDoubleClick.Checked = false;
                txbMessage.Text = string.Empty;

                //Thêm step xong thì lưu data
                dataHandle.WriteData(module.Tasks);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        private void btnUpdateStep_Click(object sender, EventArgs e)
        {
            if (Valid())
            {
                condition = cbCheckCondition.Checked;
                Step step = new Step(taskID, stepID, nameStep, startTimeStep, condition, linkCondition, actionType, contentAction);

                tasks[taskID].Steps[stepID] = step;

                //reset trạng thái 1 số btn
                txbStepName.Text = string.Empty;
                cbRightClick.Checked = false;
                cbDoubleClick.Checked = false;
                txbMessage.Text = string.Empty;

                //cập nhật step xong thì lưu data
                dataHandle.WriteData(module.Tasks);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            txbStepName.Text = string.Empty;
        }


        private void rbtnOpenApp_CheckedChanged(object sender, EventArgs e)
        {
            pnOpenApp.Enabled = true;
            pnKillProcess.Enabled = false;
            pnClick.Enabled = false;
            pnUseKeyboard.Enabled = false;
            pnMessage.Enabled = false;
            pnCommand.Enabled = false;
        }
        private void rbtnKillProcess_CheckedChanged(object sender, EventArgs e)
        {
            pnOpenApp.Enabled = false;
            pnKillProcess.Enabled = true;
            pnClick.Enabled = false;
            pnUseKeyboard.Enabled = false;
            pnMessage.Enabled = false;
            pnCommand.Enabled = false;
        }
        private void rbtnClick_CheckedChanged(object sender, EventArgs e)
        {
            pnOpenApp.Enabled = false;
            pnKillProcess.Enabled = false;
            pnClick.Enabled = true;
            pnUseKeyboard.Enabled = false;
            pnMessage.Enabled = false;
            pnCommand.Enabled = false;
        }
        private void rbtnUseKeyboard_CheckedChanged(object sender, EventArgs e)
        {
            pnOpenApp.Enabled = false;
            pnKillProcess.Enabled = false;
            pnClick.Enabled = false;
            pnUseKeyboard.Enabled = true;
            pnMessage.Enabled = false;
            pnCommand.Enabled = false;
        }
        private void rbtnShowMessage_CheckedChanged(object sender, EventArgs e)
        {
            pnOpenApp.Enabled = false;
            pnKillProcess.Enabled = false;
            pnClick.Enabled = false;
            pnUseKeyboard.Enabled = false;
            pnMessage.Enabled = true;
            pnCommand.Enabled = false;
        }
        private void rbtnExecuteCommand_CheckedChanged(object sender, EventArgs e)
        {
            pnOpenApp.Enabled = false;
            pnKillProcess.Enabled = false;
            pnClick.Enabled = false;
            pnUseKeyboard.Enabled = false;
            pnMessage.Enabled = false;
            pnCommand.Enabled = true;
        }
        private void rbtnShortcutKey_CheckedChanged(object sender, EventArgs e)
        {
            txbText.Enabled = false;
            cbbKey1.Enabled = true;
            cbbKey2.Enabled = true;
            cbbKey3.Enabled = true;
        }
        private void rbtnText_CheckedChanged(object sender, EventArgs e)
        {
            cbbKey1.Enabled = false;
            cbbKey2.Enabled = false;
            cbbKey3.Enabled = false;
            txbText.Enabled = true;
        }
        private void rbtnShutdown_CheckedChanged(object sender, EventArgs e)
        {
            txbCommand.Enabled = false;
        }

        private void rbtnEnterCommand_CheckedChanged(object sender, EventArgs e)
        {
            txbCommand.Enabled = true;
        }

        private void cbCheckCondition_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCheckCondition.Checked)
            {
                txbLinkCondition.Enabled = true;
                btnBrowserCondition.Enabled = true;
                lbCheckCondition.Enabled = true;
            }
            else
            {
                txbLinkCondition.Enabled = false;
                btnBrowserCondition.Enabled = false;
                lbCheckCondition.Enabled = false;
            }
        }

        private void btnBrowserCondition_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Select File";
            //openFileDialog.InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),"Desktop");//@"C:\";
            openFileDialog.Filter = "Image file (*.PNG)|*.PNG";
            openFileDialog.FileName = string.Empty;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txbLinkCondition.Text = Path.GetFullPath(openFileDialog.FileName);
            }
        }


        private void btnBrowserImage_Click_1(object sender, EventArgs e)
        {
            openFileDialog.Title = "Select File";
            //openFileDialog.InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Desktop");
            openFileDialog.Filter = "Image file (*.PNG)|*.PNG";
            openFileDialog.FileName = string.Empty;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txbLinkButtonImage.Text = Path.GetFullPath(openFileDialog.FileName);
            }
        }

        private void btnBrowserApp_Click_1(object sender, EventArgs e)
        {
            openFileDialog.Title = "Select File";
            openFileDialog.Filter = "All files (*.*)|*.*";
            openFileDialog.FileName = string.Empty;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txbLinkApp.Text = Path.GetFullPath(openFileDialog.FileName);
            }
        }

        
    }
}
