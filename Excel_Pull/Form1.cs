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
using Excel_Pull.Common_Methods;

namespace Excel_Pull
{
    public partial class Form1 : Form
    {
        private List<string> FileList = new List<string>();
        private string[] ext = new string[2] {
            "xls",
            "xlsx"
        };

        private DataColumn dc_file = new DataColumn("FileName",typeof(string));
        private MyButton Convert;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = FormAppearence.Main_Form_Color;
            this.Opacity = FormAppearence.MouseOver;
            Common_Method.AddMoveEvent(this, typeof(Form1));
            Set_gdv();
        }
        private void Set_gdv()
        {
            dataGridView1.BackgroundColor = Color.FromArgb(125, 125, 125);
            dataGridView1.ColumnCount = 2;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = (dataGridView1.Width - 121);
            dataGridView1.ReadOnly = true;
            dataGridView1.DefaultCellStyle.Font = label2.Font;
            dataGridView1.MouseEnter += (sender, e) =>
            {
                this.Opacity = FormAppearence.MouseEnter;
            };
            dataGridView1.CellClick += (sender, e) =>
            {
                contextMenuStrip1.Show(
                    Control.MousePosition.X + 10,
                    Control.MousePosition.Y + 10
                );
            };
        }
        //private void Form1_MouseEnter(object sender, EventArgs e)
        //{
        //    this.Opacity = FormAppearence.MouseEnter;
        //}

        //private void Form1_MouseLeave(object sender, EventArgs e)
        //{
        //    this.Opacity = FormAppearence.MouseOver;
        //}

        private void Form1_Shown(object sender, EventArgs e)
        {
            Add_Exit_Button();
            Add_FileOpen_Button();
            Add_DirectoryOpen_Button();
            Add_Convert_Button();
        }
        private void Add_Exit_Button()
        {
            MyButton mb = new MyButton(new Border_DS(4, Color.FromArgb(200, 145, 247, 195)),
                               new Controller_Size(0,0),//(35, 15),
                               new ControllerWord(
                                   "EXIT",
                                   label1.Font,
                                   Color.White,//Color.DarkViolet,
                                   Position_.Default,
                                   0,
                                   0
                                   ),
                               Color.FromArgb(196, 78, 245)//Color.FromArgb(255, 117, 255, 153)
                               )
            { Mode = Mode_.Resize};
            mb.Location = new Point(20, 20);
            this.Controls.Add(mb);
            mb.Click += (sender, e) => {
                this.Close();
            };
            mb.MouseHover += (sender, e) =>
            {
                //this.Opacity = Common_Data.FormAppearence.MouseEnter;
                ((MyButton)sender).BackColor = Color.FromArgb(138, 157, 160);
            };
            mb.MouseLeave += (sender, e) =>
            {
                ((MyButton)sender).BackColor = ((MyButton)sender).BgColor;
            };
        }
        private void AddToGDV()
        {
            Convert.Visible = false;
            dataGridView1.Rows.Clear();
            for (int i = 0;i < FileList.Count;i++)
            {
                dataGridView1.Rows.Add(
                                        "NS__" + (i + 1),
                                        (FileList[i]
                                            .Split('\\')
                                            .Distinct()
                                            .Last())
                                        );
            }
            if (FileList.Count > 0)
            {
                Convert.Visible = true;
            }
        }
        private void Add_FileOpen_Button()
        {
            MyButton mb = new MyButton(new Border_DS(4, Color.FromArgb(200, 145, 247, 195)),
                               new Controller_Size(0, 0),//(35, 15),
                               new ControllerWord(
                                   "Open File",
                                   label1.Font,
                                   Color.White,//Color.DarkViolet,
                                   Position_.Default,
                                   0,
                                   0
                                   ),
                               Color.FromArgb(196, 78, 245)//Color.FromArgb(255, 117, 255, 153)
                               )
            { Mode = Mode_.Resize };
            mb.Location = new Point(20, 60);
            this.Controls.Add(mb);
            mb.Click += (sender, e) => {
                OpenFileDialog ofd = new OpenFileDialog() {
                    CheckFileExists = true,
                    Title = "Select some Excel files :",
                    Multiselect = true,
                    ShowHelp = true,
                    InitialDirectory = OtherData.ExcelRootDirectory
                };
                //ofd.Filter = "Excel97-2003工作簿(xls)|*.xls|Excel工作簿(xlsx)|*.xlsx";
                ofd.Filter = "Excel工作簿(xlsx)|*.xlsx|Excel97-2003工作簿(xls)|*.xls";
                DialogResult dr = ofd.ShowDialog();
                FileList.Clear();
                FileList.AddRange(ofd.FileNames);
                AddToGDV();
            };
            mb.MouseHover += (sender, e) =>
            {
                //this.Opacity = Common_Data.FormAppearence.MouseEnter;
                ((MyButton)sender).BackColor = Color.FromArgb(138, 157, 160);
            };
            mb.MouseLeave += (sender, e) =>
            {
                ((MyButton)sender).BackColor = ((MyButton)sender).BgColor;
            };
        }
        private void Add_DirectoryOpen_Button()
        {
            MyButton mb = new MyButton(new Border_DS(4, Color.FromArgb(200, 145, 247, 195)),
                               new Controller_Size(0, 0),//(35, 15),
                               new ControllerWord(
                                   "Open Directory",
                                   label1.Font,
                                   Color.White,//Color.DarkViolet,
                                   Position_.Default,
                                   0,
                                   0
                                   ),
                               Color.FromArgb(196, 78, 245)//Color.FromArgb(255, 117, 255, 153)
                               )
            { Mode = Mode_.Resize };
            mb.Location = new Point(20, 100);
            this.Controls.Add(mb);
            mb.Click += (sender, e) => {
                FolderBrowserDialog fbd = new FolderBrowserDialog() {
                    Description = "Select a folder which contain Excel files .",
                    ShowNewFolderButton = true,
                    RootFolder = Environment.SpecialFolder.Desktop
                };
                fbd.ShowDialog();
                if (string.IsNullOrEmpty(fbd.SelectedPath)) {
                    return;
                }
                FileList.Clear();
                Common_Method.GetFile(fbd.SelectedPath, ext,ref FileList);
                dataGridView1.Rows.Clear();
                AddToGDV();
            };
            mb.MouseHover += (sender, e) =>
            {
                //this.Opacity = Common_Data.FormAppearence.MouseEnter;
                ((MyButton)sender).BackColor = Color.FromArgb(138, 157, 160);
            };
            mb.MouseLeave += (sender, e) =>
            {
                ((MyButton)sender).BackColor = ((MyButton)sender).BgColor;
            };
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    int index = dataGridView1.SelectedRows[0].Index;
                    dataGridView1.Rows.RemoveAt(index);
                    FileList.RemoveAt(index);
                }
                catch{ }
            }
        }

        private void Add_Convert_Button()
        {
            Convert = new MyButton(new Border_DS(4, Color.FromArgb(200, 145, 247, 195)),
                               new Controller_Size(0, 0),//(35, 15),
                               new ControllerWord(
                                   "Convert",
                                   label1.Font,
                                   Color.White,//Color.DarkViolet,
                                   Position_.Default,
                                   0,
                                   0
                                   ),
                               Color.FromArgb(196, 78, 245)//Color.FromArgb(255, 117, 255, 153)
                               )
            { Mode = Mode_.Resize };
            Convert.Location = new Point(20, 140);
            this.Controls.Add(Convert);
            Convert.Click += (sender, e) => {
                CutTable ct = new CutTable() {
                    TargetFile = FileList[0]
                };
                ct.ShowDialog();
            };
            Convert.MouseHover += (sender, e) =>
            {
                //this.Opacity = Common_Data.FormAppearence.MouseEnter;
                ((MyButton)sender).BackColor = Color.FromArgb(138, 157, 160);
            };
            Convert.MouseLeave += (sender, e) =>
            {
                ((MyButton)sender).BackColor = ((MyButton)sender).BgColor;
            };
            Convert.Visible = false;
        }

        private void refleshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddToGDV();
        }
    }
}
