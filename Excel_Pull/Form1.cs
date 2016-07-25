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
using Excel_Pull.PersonalControllers;
using Excel_Pull.Common_Data_Structure;

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

        private void Form1_Shown(object sender, EventArgs e)
        {
            Add_Exit_Button();
        }
        private void Add_Exit_Button()
        {
            MyButton mb = new MyButton(new Border_DS(4, Color.FromArgb(200, 145, 247, 195)),
                               new Controller_Size(35,15),
                               new ControllerWord(
                                   "EXIT",
                                   label1.Font,
                                   Color.DarkViolet,
                                   Position_.Default,
                                   0,
                                   0
                                   ),
                               Color.FromArgb(255, 117, 255, 153)
                               );
            mb.Location = new Point(20, 20);
            this.Controls.Add(mb);
            mb.Click += (sender, e) => {
                this.Close();
            };
        }
    }
}
