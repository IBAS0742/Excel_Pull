using Excel_Pull.Common_Data;
using Excel_Pull.Common_Data_Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel_Pull.Common_Methods;

namespace Excel_Pull.PersonalControllers
{
    public partial class ShowResult : Form
    {
        public ResultLine RL_Sheet_One { get; set; } = new ResultLine() {
            Location = new Point(40,10),
            Enabled = true
        };
        public ResultLine RL_Sheet_Two { get; set; } = new ResultLine() {
            Location = new Point(40,60),
            Enabled = false
        };
        public ResultLine RL_Table_One { get; set; } = new ResultLine() {
            Location = new Point(40,10),
            Enabled = true
        };
        public ResultLine RL_Table_Two { get; set; } = new ResultLine() {
            Location = new Point(40,60),
            Enabled = false
        };
        public ShowResult()
        {
            InitializeComponent();
        }

        private void ShowResult_Load(object sender, EventArgs e)
        {
            Add_Exit_Btn();
            Add_Ok_Btn();
            this.BackColor = FormAppearence.Main_Form_Color;
            this.Opacity = 0.9;
            R_Sheet_One.Checked = true;
            R_Table_One.Checked = true;
            Common_Method.AddMoveEvent(this, typeof(Form1));
            Sheet_Panel.Controls.Add(RL_Sheet_One);
            Sheet_Panel.Controls.Add(RL_Sheet_Two);
            Table_Panel.Controls.Add(RL_Table_One);
            Table_Panel.Controls.Add(RL_Table_Two);
            R_Sheet_One.Click += (sender_, e_) => {
                if (((RadioButton)sender_).Checked)
                {
                    RL_Sheet_One.Enabled = true;
                    RL_Sheet_Two.Enabled = false;
                }
            };
            R_Sheet_Two.Click += (sender_, e_) => {
                if (((RadioButton)sender_).Checked)
                {
                    RL_Sheet_One.Enabled = false;
                    RL_Sheet_Two.Enabled = true;
                }
            };
            R_Table_One.Click += (sender_, e_) => {
                if (((RadioButton)sender_).Checked)
                {
                    RL_Table_One.Enabled = true;
                    RL_Table_Two.Enabled = false;
                }
            };
            R_Table_Two.Click += (sender_, e_) => {
                if (((RadioButton)sender_).Checked)
                {
                    RL_Table_One.Enabled = false;
                    RL_Table_Two.Enabled = true;
                }
            };
        }
        private void Add_Exit_Btn()
        {
            MyButton mb_exit = new MyButton(
                    new Common_Data_Structure.Border_DS()
                    {
                        Border_Color = Color.FromArgb(124, 158, 255),
                        Border_Width = 1
                    },
                    new Common_Data_Structure.Controller_Size(20,20),
                    new Common_Data_Structure.ControllerWord(
                        "X",
                        Exit_Font.Font,
                        Color.FromArgb(159, 245, 178),
                        Position_.Default,
                        0,
                        0),
                    Color.FromArgb(124, 158, 255)
                )
            {
                Location = new Point(2,2),
            };
            mb_exit.Click += (sender, e) => {
                this.Close();
            };
            this.Controls.Add(mb_exit);
        }
        private void Add_Ok_Btn()
        {
            MyButton mb_exit = new MyButton(
                    new Common_Data_Structure.Border_DS()
                    {
                        Border_Color = Color.FromArgb(124, 158, 255),
                        Border_Width = 1
                    },
                    new Common_Data_Structure.Controller_Size(20, 20),
                    new Common_Data_Structure.ControllerWord(
                        "OK",
                        Exit_Font.Font,
                        Color.FromArgb(159, 245, 178),
                        Position_.Default,
                        0,
                        0),
                    Color.FromArgb(124, 158, 255)
                )
            {
                Location = new Point(10,320),
            };
        }
    }
}
