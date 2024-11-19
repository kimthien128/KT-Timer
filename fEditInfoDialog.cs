using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KT_Timer_App
{
    public partial class fEditInfoDialog : KryptonForm
    {
        public int TaskID { get; set; }
        public string NewName { get; set; }
        public DateTime NewStartTime { get; set; }
        public string Status { get; private set; }
        public int Method { get; set; } //1: Edit task name , 2: Edit start time
        //
        private static fEditInfoDialog instance;
        public static fEditInfoDialog Instance()
        {
            if (instance == null) instance = new fEditInfoDialog();
            return instance;
        }
        public fEditInfoDialog()
        {
            InitializeComponent();
        }

        private void fEditInfoDialog_Load(object sender, EventArgs e)
        {
            if (Method == 1)
            {
                txbNewName.Visible = true;
                dtpNewStartTime.Visible = false;
                pnBtn.Visible = true;

                lbNameAction.Text = "New name: ";
                txbNewName.Text = NewName;
                txbNewName.Focus();
                txbNewName.SelectAll();
            }
            else if(Method == 2)
            {
                txbNewName.Visible = false;
                dtpNewStartTime.Visible = true;
                pnBtn.Visible = true;

                //không cho chọn thời gian ở quá khứ
                dtpNewStartTime.MinDate = DateTime.Today;
                
                lbNameAction.Text = "New start time: ";
                dtpNewStartTime.Value = NewStartTime;
                dtpNewStartTime.Focus();
            }
            else
            {
                txbNewName.Visible = false;
                dtpNewStartTime.Visible = false;
                pnBtn.Visible = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(Method == 1)
            {
                NewName = txbNewName.Text.Trim();

                if (string.IsNullOrEmpty(NewName))
                {
                    MessageBox.Show("Enter new name");
                    return;
                }

                this.DialogResult = DialogResult.OK;
                Status = "Change task name : " + NewName;
                this.Close();
            }
            else if(Method == 2)
            {
                NewStartTime = dtpNewStartTime.Value;
                if (dtpNewStartTime.Value < DateTime.Now)
                {
                    MessageBox.Show("Set new start time in future");
                    return;
                }
                if (dtpNewStartTime.Value == default)
                {
                    MessageBox.Show("Edit new start time");
                    return;
                }
                
                this.DialogResult = DialogResult.OK;
                Status = "Change start time : " + NewStartTime;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Đóng dialog với kết quả Cancel
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
