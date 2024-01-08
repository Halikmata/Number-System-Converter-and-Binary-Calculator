using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Architecture_and_Organization_midterm_project
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnNymSysConv_Click(object sender, EventArgs e)
        {
            var NumSysConv = new Number_System_Converter();
            NumSysConv.Show();
        }

        private void btnBinaryCalc_Click(object sender, EventArgs e)
        {
            var Calc = new Binary_Calculator();
            Calc.Show();
        }
    }
}
