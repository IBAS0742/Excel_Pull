using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_Pull.Common_Data_Structure
{
    /// <summary>
    /// Fro user controller 
    /// </summary>
    public class ControllerWord
    {
        #region Prototype
        private Position_ putPosition = Position_.Default;
        public Position_ PutPosition { get { return putPosition; } set { putPosition = value; } }
        public float OffsetX { get; set; }
        public float OffsetY { get; set; }
        private string text;
        public string Text { get { return text; } set { text = value; } }
        private Font font;
        public Font Font_ { get { return font; }set { font = value; } }
        private Color color;
        public Color FontColor { get { return color; } set { color = value; } }
        #endregion
        public ControllerWord(string text_,Font f,Color color_,Position_ pos_,float ox,float oy)
        {
            PutPosition = pos_;
            OffsetX = ox;
            OffsetY = oy;
            Text = text_;
            Font_ = f;
            FontColor = color_;
        }
    }
    public enum Position_
    {
        Left,                   //put word in the left
        Right,                  //put word in the right
        Center,                 //put word in the center 
        Default = Center,       //default value is center
        User_Design              //user design
    }
}
