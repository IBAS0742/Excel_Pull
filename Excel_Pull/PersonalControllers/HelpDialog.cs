using Excel_Pull.Common_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excel_Pull.PersonalControllers
{
    public partial class HelpDialog : Form
    {
        public string Text
        {
            set { textBox1.Text = value; }
        }
        public HelpDialog()
        {
            InitializeComponent();
        }

        private void Help_Load(object sender, EventArgs e)
        {
            this.BackColor = FormAppearence.Main_Form_Color;
            this.Opacity = 0.9;
            Common_Method.AddMoveEvent(this, typeof(Form1));
        }

        //private void Help_DoubleClick(object sender, EventArgs e)
        //{
        //    this.Close();
        //}
    }
}
