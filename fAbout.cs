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
    public partial class fAbout : KryptonForm
    {
        private static fAbout instance;
        public static fAbout Instance()
        {
            if(instance == null) instance = new fAbout();
            return instance;
        }
        
        private fAbout()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {

        }

        private void btnCheckUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}
