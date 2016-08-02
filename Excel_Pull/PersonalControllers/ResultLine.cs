using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel_Pull.Common_Data;
using Excel_Pull.Common_Data_Structure;

namespace Excel_Pull.PersonalControllers
{
    /// <summary>
    /// this control is match the ShowResult when I using more datagridview , I found some confuse thing .
    /// </summary>
    public partial class ResultLine : UserControl
    {
        private List<MyButton> mbs = new List<MyButton>();
        private ComboBox cb = new ComboBox();
        public List<string> list { get; set; }
        private int counter = 0;
        public ResultLine()
        {
            InitializeComponent();
        }

        private void ResultLine_Load(object sender, EventArgs e)
        {
            this.Height = 50;
            cb.Visible = false;
            cb.DataSource = DataBase_Data_Struct.Data_Type;
            cb.FlatStyle = FlatStyle.Flat;
            cb.SelectedValueChanged += (sender_, e_) => {
                if ((MyButton)((ComboBox)sender_).Tag == null)
                {
                    return;
                }
                ((MyButton)((ComboBox)sender_).Tag).Tag = ((ComboBox)sender_).SelectedIndex;
                ((MyButton)((ComboBox)sender_).Tag).C_W.Text = ((ComboBox)sender_).SelectedValue.ToString();
                ((MyButton)((ComboBox)sender_).Tag).ReDraw();
                ((ComboBox)sender_).Tag = null;
                ((ComboBox)sender_).Visible = false;
            };
            this.Controls.Add(cb);
            int i;
            mbs.Clear();
            int offx = 0;
            for (i = 0;i < list.Count;i++)
            {
                MyButton mb = myLabel_.MB(counter, list[counter], FontLabel.Font);
                mbs.Add(mb);
                this.Controls.Add(mb);
                mb.Location = new Point(offx,5);
                MyButton mb_ = myLabel_.MB(counter, DataBase_Data_Struct.Data_Type[0], FontLabel.Font,mb.Width - 2);
                mbs.Add(mb_);
                this.Controls.Add(mb_);
                mb_.Location = new Point(offx,25);
                mb_.Tag = 0;
                mb.Tag = counter;
                counter++;
                offx += mb.Width + 1;
                mb.Click += (sender_, e_) =>
                {
                    if (MessageBox.Show("Delete " + ((MyButton)sender_).C_W.Text + " ?","Warning !",MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        int index = Convert.ToInt32(((MyButton)sender_).Tag);
                        int width = ((MyButton)sender_).Width;
                        mbs[index * 2].Visible = false;
                        mbs[index * 2 + 1].Visible = false;
                        for (int ii = index * 2 + 1;ii < mbs.Count;ii++)
                        {
                            mbs[ii].Left -= width;
                        }
                    }
                };
                mb_.Click += (sender_, e_) =>
                {
                    Rectangle rect = ((MyButton)sender_).GetCurRectangle;
                    cb.Width = rect.Width - 2;
                    cb.Height = rect.Height;
                    cb.Top = rect.Top + 1;
                    cb.Left = rect.Left + 1;
                    cb.Visible = true;
                    cb.BackColor = ((MyButton)sender_).BackColor;
                    cb.Tag = sender_;
                    cb.Text = DataBase_Data_Struct.Data_Type[Convert.ToInt32(((MyButton)sender_).Tag)];
                };
            }
        }
        private void Disables() { }
    }
    public class myLabel : Label
    {
        public myLabel(Font f)
        {
            BorderStyle = BorderStyle.FixedSingle;
            Font = f;
            Width = 75;
            Height = 23;
        }
    }
    public class myLabel_
    {
        public static MyButton MB(int index,string text,Font f,int width = 60)
        {
            MyButton mb = new MyButton(
                    new Border_DS() {
                        Border_Width = 1,
                        Border_Color = Color.Black
                    },
                    new Controller_Size(width,20),
                    new ControllerWord(
                        text,
                        f,
                        Color.Black,
                        Position_.Default,
                        0,
                        0
                        ),
                    OtherData.Light_Color[index % OtherData.Light_Color.Count]

                );
            return mb;
        }
    }
}
