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

        private static fAddStep instance;
        public static fAddStep Instance()
        {
            if (instance == null) instance = new fAddStep();
            return instance;
        }
        private fAddStep()
        {
            InitializeComponent();
            //this.ControlBox = false; //tắt nút x
        }

        private void fAddStep_Load(object sender, EventArgs e)
        {
            parentID = module.taskIDCurrent;

            cbCheckCondition.Checked = false;
            txbLinkCondition.Enabled = false;
            btnBrowserCondition.Enabled = false;
            rbtnOpenApp.Checked = true;
            rbtnShortcutKey.Checked = true;
            rbtnEnterCommand.Checked = true;


            lbParentTaskID.Text = "Task " + parentID.ToString();
            lbTaskName.Text = Module.Instance().Tasks[parentID].Name;
            if (tasks[parentID].Steps == null)
                stepID = 0;
            else
                stepID = tasks[parentID].Steps.Count;

            lbStepID.Text = "Step " + stepID;
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
                        keyCodes = new KeyCode[] { KeyCode.LWIN, KeyCode.KEY_D },
                        TaskID = parentID
                    };
                    contentAction = "Shortcut Key\"" + "KeyCode.LWIN, KeyCode.KEY_D" + "\"";

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
                        Command = "shutdown -s",
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

                //Thêm step xong thì lưu data
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
            pnSendKey.Enabled = false;
            pnCommand.Enabled = false;
        }

        private void rbtnClick_CheckedChanged(object sender, EventArgs e)
        {
            pnOpenApp.Enabled = false;
            pnClick.Enabled = true;
            pnSendKey.Enabled = false;
            pnCommand.Enabled = false;
        }
        private void rbtnUseKeyboard_CheckedChanged(object sender, EventArgs e)
        {
            pnOpenApp.Enabled = false;
            pnClick.Enabled = false;
            pnSendKey.Enabled = true;
            pnCommand.Enabled = false;
        }

        private void rbtnExecuteCommand_CheckedChanged(object sender, EventArgs e)
        {
            pnOpenApp.Enabled = false;
            pnClick.Enabled = false;
            pnSendKey.Enabled = false;
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
