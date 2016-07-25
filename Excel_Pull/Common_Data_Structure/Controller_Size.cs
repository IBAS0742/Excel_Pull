using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_Pull.Common_Data_Structure
{
    /// <summary>
    /// Fro any controller size defined
    /// </summary>
    public class Controller_Size
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Controller_Size(int width,int height) {
            if (width <= 0)
            {
                width = 10;
            }
            if (height <= 0)
            {
                height = 10;
            }
            Width = width;
            Height = height;
        }
    }
}
