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
    public partial class fDetailTask : KryptonForm, IUpdatableForm
    {
        private Module module = Module.Instance();
        private List<MyTask> tasks = Module.Instance().Tasks;

        private int taskID;
        private List<Step> steps;

        public fDetailTask()
        {
            InitializeComponent();
        }
        private static fDetailTask instance;
        public static fDetailTask Instance()
        {
            if (instance == null) instance = new fDetailTask();
            return instance;
        }

        private void fDetailTask_Load(object sender, EventArgs e)
        {
            taskID = module.taskIDCurrent;
            steps = tasks[taskID].Steps;

            this.Text = $"Detail task {taskID} : {tasks[taskID].Name}";

            flpDetailTask.Controls.Clear();

            for (int i = 0; i < steps.Count; i++)
            {
                KryptonPanel childPanel = CreatePanel(steps[i].ID);
                flpDetailTask.Controls.Add(childPanel);
            }
        }

        public KryptonPanel CreatePanel(int stepID)
        {
            KryptonPanel childPanel = new KryptonPanel();
            childPanel.Width = 730;
            childPanel.Height = 100;
            childPanel.StateNormal.Color1 = Color.Transparent;

            //---------------------------------------------------------
            KryptonPanel panelContainTextbox = new KryptonPanel();
            panelContainTextbox.Dock = DockStyle.Fill;
            panelContainTextbox.StateNormal.Color1 = Color.Transparent;

            //
            Step step = steps[stepID];
            string content = "Step: " + step.ID + Environment.NewLine +
                "Name : " + step.Name + Environment.NewLine +
                "Check Condition: " + step.Condition + Environment.NewLine +
                "Check for the existence of: " + step.ImageCondition + Environment.NewLine +
                "Action: " + step.ActionDescription + Environment.NewLine +
                "Complete: " + step.IsComplete;

            KryptonTextBox txbDetail = new KryptonTextBox();
            txbDetail.Text = content;
            txbDetail.Dock = DockStyle.Fill;
            txbDetail.StateDisabled.Back.Color1 = Color.FromArgb(255,255,255);
            txbDetail.StateDisabled.Content.Color1 = Color.FromArgb(79, 82, 101);
            txbDetail.Enabled = true;
            txbDetail.ReadOnly = true;
            txbDetail.Multiline = true;
            txbDetail.ScrollBars = ScrollBars.Vertical;

            panelContainTextbox.Controls.Add(txbDetail);

            //---------------------------------------------------------
            KryptonPanel panelContainButton = new KryptonPanel();
            panelContainButton.Dock = DockStyle.Right;
            panelContainButton.Width = 100;
            panelContainButton.StateNormal.Color1 = Color.Transparent;
            //
            KryptonPanel panelContainButtonTop = new KryptonPanel();
            panelContainButtonTop.Dock = DockStyle.Top;
            panelContainButtonTop.Height = 50;
            panelContainButtonTop.StateNormal.Color1 = Color.Transparent;
            //
            KryptonButton btnEditStep = new KryptonButton();
            btnEditStep.Text = "Edit step";
            btnEditStep.Dock = DockStyle.Bottom;
            btnEditStep.Height = 25;
            btnEditStep.Click += new EventHandler(btnEditStep_Click);
            btnEditStep.PaletteMode = PaletteMode.Office2007Blue;
            btnEditStep.Tag = stepID;
            //
            panelContainButtonTop.Controls.Add(btnEditStep);
            //
            KryptonPanel panelContainButtonBottom = new KryptonPanel();
            panelContainButtonBottom.Dock = DockStyle.Bottom;
            panelContainButtonBottom.Height = 50;
            panelContainButtonBottom.StateNormal.Color1 = Color.Transparent;
            //
            KryptonButton btnDeleteStep = new KryptonButton();
            btnDeleteStep.Text = "Delete step";
            btnDeleteStep.Dock = DockStyle.Top;
            btnDeleteStep.Height = 25;
            btnDeleteStep.Click += new EventHandler(btnDeleteStep_Click);
            btnDeleteStep.PaletteMode = PaletteMode.Office2007Blue;
            btnDeleteStep.Tag = stepID;
            //
            panelContainButtonBottom.Controls.Add(btnDeleteStep);
            //
            panelContainButton.Controls.Add(panelContainButtonTop);
            panelContainButton.Controls.Add(panelContainButtonBottom);

            //Disable khi complete ----------------------------------------------------
            if (tasks[taskID].IsComplete)
            {
                btnEditStep.Enabled = false;
                btnDeleteStep.Enabled = false;
                btnAddStep.Enabled = false;
            }
            else btnAddStep.Enabled = true;

            //----------------------------------------------------
            childPanel.Controls.Add(panelContainTextbox);
            childPanel.Controls.Add(panelContainButton);

            return childPanel;
        }
        public void btnEditStep_Click(object sender, EventArgs e)
        {
            module.taskIDCurrent = taskID;
            KryptonButton btn = (KryptonButton)sender;

            fAddStep f = fAddStep.Instance();
            f.Method = 2; //chế độ edit
            f.SetStepID((int)btn.Tag);
            f.ShowDialog();
            UpdateUI();
            fMain fMain = fMain.Instance();
            fMain.UpdateUI();
        }
        public void btnDeleteStep_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to delete the step?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                KryptonButton btn = (KryptonButton)sender;
                steps.RemoveAt((int)btn.Tag);
                UpdateUI();
            }
        }

        public void UpdateUI()
        {
            flpDetailTask.Controls.Clear();

            //cập nhật index và startTime
            for (int i = 0; i < steps.Count; i++)
            {
                steps[i].ID = i;
                steps[i].StartTime = tasks[taskID].StartTime.AddSeconds(tasks[taskID].WaitingTime * i);
            }

            //thêm UI vào lại
            foreach (Step step in steps)
            {
                KryptonPanel childPanel = this.CreatePanel(step.ID);
                flpDetailTask.Controls.Add(childPanel);
            }
        }

        private void btnAddStep_Click_1(object sender, EventArgs e)
        {
            module.taskIDCurrent = taskID;
            fAddStep f = fAddStep.Instance();
            f.Method = 1; //chế độ tạo mới
            f.ShowDialog();
            UpdateUI();
            fMain fMain = fMain.Instance();
            fMain.UpdateUI();
        }

    }
}
