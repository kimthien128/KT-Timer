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

namespace KT_Timer_App
{
    public partial class fAddStep : KryptonForm
    {
        private Module module = Module.Instance();
        private List<MyTask> tasks = Module.Instance().Tasks;
        private DataHandle dataHandle = DataHandle.Instance();

        private int parentID;
        private int stepID;
        private string nameStep;
        private DateTime startTimeStep;
        private bool condition;
        private string linkCondition;
        private ActionType actionType;
        private string contentAction;
        private OpenFileDialog openFileDialog = new OpenFileDialog();

        private bool isValid;
        public int Method { get; set; } //1: tạo mới , 2: cập nhật
        public void SetStepID(int stepId)
        {
            this.stepID = stepId;
        }

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
            parentID = module.taskIDCurrent;

            lbParentTaskID.Text = "Task " + parentID.ToString();
            lbTaskName.Text = Module.Instance().Tasks[parentID].Name;

            //load các giá trị cần thiết vào cbb dùng cho keyboard
            //giá trị truyền vào là giá trị của enum KeyCode
            module.LoadEnumValuesByRange(cbbKey, 48, 90);
            module.LoadEnumValuesByRange(cbbKey, 112, 123);
            module.LoadSelectedEnumValues(cbbModifierKey, KeyCode.ESC, KeyCode.SHIFT, KeyCode.CONTROL,KeyCode.LWIN,KeyCode.ALT);

            //nếu là chế độ tạo mới
            if (Method == 1)
            {
                this.Text = "Add new step";
                btnAddStep.Visible = true;
                btnUpdateStep.Visible = false;

                if (tasks[parentID].Steps == null)
                    stepID = 0;
                else
                    stepID = tasks[parentID].Steps.Count;

                lbStepID.Text = "Step " + stepID;

                cbCheckCondition.Checked = false;
                txbLinkCondition.Enabled = false;
                btnBrowserCondition.Enabled = false;

                rbtnOpenApp.Checked = true;
                rbtnShortcutKey.Checked = true;
                rbtnEnterCommand.Checked = true;

                cbbModifierKey.SelectedIndex = 3; //WIN
                cbbKey.SelectedIndex = 13; //D
            }
            //nếu là chế độ cập nhật
            else if (Method == 2)
            {
                this.Text = "Edit step " + stepID;
                btnAddStep.Visible = false;
                btnUpdateStep.Visible = true;

                Step s = tasks[parentID].Steps[stepID];

                txbStepName.Text = s.Name;
                this.startTimeStep = s.StartTime;
                //
                if (!string.IsNullOrEmpty(s.ImageCondition))
                {
                    cbCheckCondition.Checked = true;
                    txbLinkCondition.Text = s.ImageCondition;
                }
                else
                {
                    cbCheckCondition.Checked = false;
                    txbLinkCondition.Text = string.Empty;
                }
                //
                if (!string.IsNullOrEmpty(s.Action.AppPath))
                {
                    rbtnOpenApp.Checked = true;
                    txbLinkApp.Text = s.Action.AppPath;
                }
                else
                {
                    txbLinkApp.Text = string.Empty;
                }
                //
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
                //
                switch ((int)s.Action.KeyboardType)
                {
                    case 0: //none
                        cbbModifierKey.SelectedIndex = -1;
                        cbbKey.SelectedIndex = -1;
                        txbText.Text = string.Empty;
                        break;
                    case 1://shortcut
                        rbtnUseKeyboard.Checked = true;
                        rbtnShortcutKey.Checked = true;
                        //đang gặp lỗi
                        //cbbModifierKey.SelectedValue = s.Action.keyCodes[0];
                        //cbbKey.SelectedValue = s.Action.keyCodes[1];
                        break;
                    case 2://string
                        rbtnUseKeyboard.Checked = true;
                        rbtnText.Checked = true;
                        txbText.Text = s.Action.Text;
                        break;
                    default:
                        break;
                }
                //
                if (!string.IsNullOrEmpty(s.Action.Message))
                {
                    rbtnShowMessage.Checked = true;
                    txbMessage.Text = s.Action.Message;
                }
                else
                {
                    txbMessage.Text = string.Empty;
                }
                //
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

        private bool Valid()
        {
            isValid = true;
            contentAction = string.Empty;
            linkCondition = string.Empty;
            
            nameStep = txbStepName.Text;

            if(cbCheckCondition.Checked)
            {
                if(txbLinkCondition.Text == string.Empty)
                {
                    MessageBox.Show("Please upload the image to verify its existence (*.PNG)");
                    isValid = false;
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
                    isValid = false;
                }
                else
                {
                    actionType = new ActionType
                    {
                        Type = ActionType.TypeAction.OpenApp,
                        AppPath = txbLinkApp.Text,
                        TaskID = parentID
                    };
                    contentAction = "Open app \"" + txbLinkApp.Text + "\"";
                }
            }
            else if(rbtnClick.Checked)
            {
                if (txbLinkButtonImage.Text == string.Empty)
                {
                    MessageBox.Show("Please enter path image (*.PNG)");
                    isValid = false;
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
                        TaskID = parentID
                    };

                    contentAction = typeClick + " Click on button \"" + txbLinkButtonImage.Text + "\"";
                }
            }
            else if (rbtnUseKeyboard.Checked)
            {
                //cần làm rõ nội dung chổ này thêm nữa, có thể tạo 1 actiontype ban đầu khi khởi tọa step, chỉ cần truyền tham số trong mỗi if
                if(rbtnShortcutKey.Checked)
                {
                    
                    actionType = new ActionType
                    {
                        Type = ActionType.TypeAction.UseKeyboard,
                        KeyboardType = ActionType.TypeKeyboard.Shortcut,
                        keyCodes = ((ushort)cbbModifierKey.SelectedValue == 9999)
                            ? new KeyCode[] { (KeyCode)cbbKey.SelectedValue } // Nếu là 9999, chỉ thêm cbbKey
                            : new KeyCode[] { (KeyCode)cbbModifierKey.SelectedValue, (KeyCode)cbbKey.SelectedValue }, // Ngược lại, thêm cả hai
                        TaskID = parentID
                    };
                    contentAction = "Shortcut Key\"" + cbbModifierKey.SelectedValue.ToString() + ", " + cbbKey.Text + "\"";

                }
                else if (rbtnText.Checked)
                {
                    actionType = new ActionType
                    {
                        Type = ActionType.TypeAction.UseKeyboard,
                        KeyboardType = ActionType.TypeKeyboard.String,
                        Text = txbText.Text,
                        TaskID = parentID
                    };
                    contentAction = "Send Text \"" + txbText.Text + "\"";
                }
            }
            else if (rbtnShowMessage.Checked)
            {
                if (txbMessage.Text == string.Empty)
                {
                    MessageBox.Show("Please enter message");
                    isValid = false;
                }
                else
                {
                    actionType = new ActionType
                    {
                        Type = ActionType.TypeAction.ShowMessage,
                        Message = txbMessage.Text,
                        TaskID = parentID
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
                        isValid = false;
                    }
                    else
                    {
                        actionType = new ActionType
                        {
                            Type = ActionType.TypeAction.RunCommand,
                            Command = txbCommand.Text,
                            TaskID = parentID
                        };
                        contentAction = "Execute command \"" + txbCommand.Text + "\""; ;
                    }
                }
                else if (rbtnShutdown.Checked)
                {
                    actionType = new ActionType
                    {
                        Type = ActionType.TypeAction.RunCommand,
                        Command = "shutdown -s -t 0",
                        TaskID = parentID
                    };
                    contentAction = "Shutdown computer";
                }
                
            }
            return isValid;
        }

        private void btnAddStep_Click(object sender, EventArgs e)
        {
            if (Valid())
            {
                condition = cbCheckCondition.Checked;
                startTimeStep = tasks[parentID].StartTime.AddSeconds(tasks[parentID].WaitingTime * stepID);
                Step step = new Step(parentID, stepID, nameStep, startTimeStep, condition, linkCondition, actionType, contentAction);

                if (tasks[parentID].Steps == null)
                    tasks[parentID].Steps = new List<Step>();

                tasks[parentID].Steps.Add(step);

                //reset trạng thái 1 số btn
                txbStepName.Text = string.Empty;
                cbRightClick.Checked = false;
                cbDoubleClick.Checked = false;
                txbMessage.Text = string.Empty;

                //Thêm step xong thì lưu data
                dataHandle.GhiDuLieu(module.Tasks);

                this.Close();
            }
        }
        private void btnUpdateStep_Click(object sender, EventArgs e)
        {
            if (Valid())
            {
                condition = cbCheckCondition.Checked;
                Step step = new Step(parentID, stepID, nameStep, startTimeStep, condition, linkCondition, actionType, contentAction);

                tasks[parentID].Steps[stepID] = step;

                //reset trạng thái 1 số btn
                txbStepName.Text = string.Empty;
                cbRightClick.Checked = false;
                cbDoubleClick.Checked = false;
                txbMessage.Text = string.Empty;

                //cập nhật step xong thì lưu data
                dataHandle.GhiDuLieu(module.Tasks);

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
            pnClick.Enabled = false;
            pnUseKeyboard.Enabled = false;
            txbMessage.Enabled = false;
            pnCommand.Enabled = false;
        }

        private void rbtnClick_CheckedChanged(object sender, EventArgs e)
        {
            pnOpenApp.Enabled = false;
            pnClick.Enabled = true;
            pnUseKeyboard.Enabled = false;
            txbMessage.Enabled = false;
            pnCommand.Enabled = false;
        }
        private void rbtnUseKeyboard_CheckedChanged(object sender, EventArgs e)
        {
            pnOpenApp.Enabled = false;
            pnClick.Enabled = false;
            pnUseKeyboard.Enabled = true;
            txbMessage.Enabled = false;
            pnCommand.Enabled = false;
        }
        private void rbtnShowMessage_CheckedChanged(object sender, EventArgs e)
        {
            pnOpenApp.Enabled = false;
            pnClick.Enabled = false;
            pnUseKeyboard.Enabled = false;
            txbMessage.Enabled = true;
            pnCommand.Enabled = false;
        }
        private void rbtnExecuteCommand_CheckedChanged(object sender, EventArgs e)
        {
            pnOpenApp.Enabled = false;
            pnClick.Enabled = false;
            pnUseKeyboard.Enabled = false;
            txbMessage.Enabled = false;
            pnCommand.Enabled = true;
        }
        private void rbtnShortcutKey_CheckedChanged(object sender, EventArgs e)
        {
            txbText.Enabled = false;
            cbbModifierKey.Enabled = true;
            cbbKey.Enabled = true;
        }
        private void rbtnText_CheckedChanged(object sender, EventArgs e)
        {
            cbbModifierKey.Enabled = false;
            cbbKey.Enabled = false;
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
            }
            else
            {
                txbLinkCondition.Enabled = false;
                btnBrowserCondition.Enabled = false;
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
            else
            {
                txbLinkCondition.Text = string.Empty;
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
            else
            {
                txbLinkButtonImage.Text = string.Empty;
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
            else
            {
                txbLinkApp.Text = string.Empty;
            }
        }

    }
}
