using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel_Pull.Common_Data_Structure;

namespace Excel_Pull.PersonalControllers
{
    public enum Mode_{
        Auto ,              //if word length is longger than the box , box will auto to resize
        Strict,             //if word length is longger than the box , box will not be resize
        Resize,             //if word length is not equal the box , box will be resize
        Default = Auto,     //default value is auto

    }
    public partial class MyButton : UserControl
    {
        public Border_DS Border_Info { get; set; }
        public Controller_Size C_S { get; set; }
        public ControllerWord C_W { get; set; }
        public Mode_ Mode { get; set; }
        public Color BgColor { get; set; }
        public MyButton(Border_DS border_info, Controller_Size cs, ControllerWord cw,Color bgColor)
        {
            InitializeComponent();
            Border_Info = border_info;
            C_S = cs;
            C_W = cw;
            this.BackColor = bgColor;
            BgColor = bgColor;
            Mode = Mode_.Auto;
        }
        private void DrawBorder_World()
        {
            Graphics g = this.CreateGraphics();
            #region Pre_Calc
            SizeF sizef = g.MeasureString(C_W.Text, C_W.Font_);
            if (Mode == Mode_.Auto)
            {
                if (sizef.Width > C_S.Width) {
                    C_S.Width = (int)(sizef.Width + 1 );
                }
            } else if (Mode == Mode_.Resize)
            {
                if (sizef.Width != C_S.Width)
                {
                    C_S.Width = (int)(sizef.Width + 1);
                }
                if (sizef.Height != C_S.Height)
                {
                    C_S.Height = (int)(sizef.Height + 1);
                }
            }
            double font_top = (C_S.Height - sizef.Height) / 2,
                font_right = (C_S.Width - sizef.Width);
            #endregion
            #region Point A B C D E F G H 
            //  A_________B
            //    E_____F
            //  
            //    H_____G
            //  D_________C
            Point
                A = new Point(0,
                              0),
                B = new Point(C_S.Width + Border_Info.Border_Width_Left + Border_Info.Border_Width_Right,
                              0),
                C = new Point(C_S.Width + Border_Info.Border_Width_Left + Border_Info.Border_Width_Right,
                              C_S.Height + Border_Info.Border_Width_Top + Border_Info.Border_Width_Bottom),
                D = new Point(0,
                              C_S.Height + Border_Info.Border_Width_Top + Border_Info.Border_Width_Bottom),
                E = new Point(Border_Info.Border_Width_Left,
                              Border_Info.Border_Width_Top),
                F = new Point(C_S.Width + Border_Info.Border_Width_Left,
                              Border_Info.Border_Width_Top),
                G = new Point(C_S.Width + Border_Info.Border_Width_Left,
                              C_S.Height + Border_Info.Border_Width_Top),
                H = new Point(Border_Info.Border_Width_Left,
                              C_S.Height + Border_Info.Border_Width_Top);
            #endregion
            #region DrawWorld
            {
                //MessageBox.Show("width = " + sizef.Width + "\nHeight = " + sizef.Height);
                if (C_W.PutPosition == Position_.Default)
                {
                    g.DrawString(C_W.Text, C_W.Font_, new SolidBrush(C_W.FontColor), new Point((int)(E.X + font_right / 2), (int)(E.Y + font_top)));
                }
                else if (C_W.PutPosition == Position_.Left)
                {
                    g.DrawString(C_W.Text, C_W.Font_, new SolidBrush(C_W.FontColor), new Point(E.X, (int)(E.Y + font_top)));
                }
                else if (C_W.PutPosition == Position_.Right)
                {
                    g.DrawString(C_W.Text, C_W.Font_, new SolidBrush(C_W.FontColor), new Point((int)(E.X + font_right), (int)(E.Y + font_top)));
                }
                else
                {
                    g.DrawString(C_W.Text, C_W.Font_, new SolidBrush(C_W.FontColor), new Point((int)(E.X + C_W.OffsetX), (int)(E.Y + C_W.OffsetY)));
                }
            }
            #endregion
            #region DrawBorder
            if (Border_Info.Border_Width == 0)
            {
                this.Width = C_S.Width;
                this.Height = C_S.Height;
            }
            else
            {
                this.Width = C.X;
                this.Height = C.Y;
                g.FillPolygon(new SolidBrush(Border_Info.Border_Color_Top), new Point[] { A, B, F, E });
                g.FillPolygon(new SolidBrush(Border_Info.Border_Color_Right), new Point[] { B, C, G, F });
                g.FillPolygon(new SolidBrush(Border_Info.Border_Color_Bottom), new Point[] { C, D, H, G });
                g.FillPolygon(new SolidBrush(Border_Info.Border_Color_Left), new Point[] { D, A, E, H });
            }
            #endregion
        }

        private void MyButton_Load(object sender, EventArgs e)
        {
            DrawBorder_World();
        }

        private void MyButton_Paint(object sender, PaintEventArgs e)
        {
            DrawBorder_World();
        }
    }
}
