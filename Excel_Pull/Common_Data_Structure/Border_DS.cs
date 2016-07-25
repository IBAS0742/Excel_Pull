using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_Pull.Common_Data_Structure
{
    /// <summary>
    /// Controller Border (Data Structure)
    /// for user controller , for designing user UI
    /// </summary>
    public class Border_DS
    {
        #region Prototype
        private int border_Width;
        public int Border_Width { get { return border_Width; } set { border_Width = value; Width_Same(); } }
        private int[] border_Widths = new int[4];
        public int Border_Width_Top { get { return border_Widths[0]; } set { border_Widths[0] = value; } }
        public int Border_Width_Right { get { return border_Widths[1]; } set { border_Widths[1] = value; } }
        public int Border_Width_Bottom { get { return border_Widths[2]; } set { border_Widths[2] = value; } }
        public int Border_Width_Left { get { return border_Widths[3]; } set { border_Widths[3] = value; } }
        private Color border_Color = new Color();
        public Color Border_Color { get { return border_Color; } set { border_Color = value;Color_Same(); } }
        private Color[] border_colors = new Color[4] { new Color(),new Color(), new Color(),new Color() };
        public Color Border_Color_Top { get { return border_colors[0]; } set { border_colors[0] = value; } }
        public Color Border_Color_Right { get { return border_colors[1]; } set { border_colors[1] = value; } }
        public Color Border_Color_Bottom { get { return border_colors[2]; } set { border_colors[2] = value; } }
        public Color Border_Color_Left { get { return border_colors[3]; } set { border_colors[3] = value; } }
        #endregion
        /// <summary>
        /// Default Value
        /// </summary>
        public Border_DS() {
            Border_Width = 0;
            Border_Color = Color.FromArgb(1, 0, 0, 0);
        }
        /// <summary>
        /// set the same with and color
        /// </summary>
        /// <param name="width">same width</param>
        /// <param name="color">same color</param>
        public Border_DS(int width,Color color) {
            Border_Width = width;
            Border_Color = color;
        }
        /// <summary>
        /// set different color for four borders , the order is top \ right \ bottom \ left
        /// </summary>
        /// <param name="width"></param>
        /// <param name="color"></param>
        public Border_DS(int [] width,Color[] color) {
            int i;
            Border_Width = -1;
            for (i = 0;i < width.Length && i < 4;i++) {
                border_Widths[i] = width[i];
            }
            for (;i < 4;i++)
            {
                border_Widths[i] = 0;
            }
            for (i = 0; i < color.Length && i < 4; i++)
            {
                border_colors[i] = color[i];
            }
            for (; i < 4; i++)
            {
                border_colors[i] = Color.FromArgb(0,1,1,1);
            }
        }
        private void Width_Same()
        {
            Border_Width_Bottom =
                Border_Width_Left =
                    Border_Width_Right =
                        Border_Width_Top =
                            Border_Width;
        }
        private void Color_Same()
        {
            Border_Color_Bottom =
                Border_Color_Left =
                    Border_Color_Right =
                        Border_Color_Top =
                            Border_Color;
        }
    }
}
