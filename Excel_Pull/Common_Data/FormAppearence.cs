using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel_Pull.Common_Data
{
    class FormAppearence
    {
        static public double MouseEnter { get { return 0.9; } }
        static public double MouseOver { get { return 0.5; } }
        static public Color Main_Form_Color { get { return Color.FromArgb(116, 253, 107); } }
    }
    class OtherData
    {
        static public string ExcelRootDirectory { get { return @"c:\"; } }
    }
}
