using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel_Pull.Common_Data;

namespace Excel_Pull
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = FormAppearence.Main_Form_Color;
            this.Opacity = FormAppearence.MouseOver;
            Common_Method.AddMoveEvent(this, typeof(Form1));
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            this.Opacity = FormAppearence.MouseEnter;
        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            this.Opacity = FormAppearence.MouseOver;
        }
    }
}
