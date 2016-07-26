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
    public partial class MyFileOpen : Form
    {
        public enum ShowWhat
        {
            File,
            Directory
        }
        public Color BgColor { get; set; }
        public Color FColor { get; set; }
        public string FromPath;
        public MyFileOpen()
        {
            InitializeComponent();
            BgColor = Color.FromArgb(0, 255, 173);
            FColor = Color.FromArgb(135, 36,255);
            FromPath = @"c:\";
        }

        private void MyFileOpen_Load(object sender, EventArgs e)
        {
            this.BackColor = BgColor;
            this.Opacity = 0.8;
            Common_Method.AddMoveEvent(this, typeof(Form1));
            flowLayoutPanel1.Width = this.Width;
        }

        private void MyFileOpen_Shown(object sender, EventArgs e)
        {

        }
    }
}
