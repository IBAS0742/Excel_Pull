using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excel_Pull.Common_Data
{
    class Common_Method
    {
        static public void AddMoveEvent(Object Obj,Type type)
        {
            //Object Obj = type.Assembly.CreateInstance(type.ToString());
            Point mouseOff = new Point();
            bool leftFlag = false;
            ((ContainerControl)Obj).MouseDown += (sender,e) => {
                if (e.Button == MouseButtons.Left) {
                    mouseOff = new Point(-e.X, -e.Y);
                    leftFlag = true;
                }
            };
            ((ContainerControl)Obj).MouseMove += (sender, e) =>
            {
                if (leftFlag)
                {
                    Point mouseSet = Control.MousePosition;
                    mouseSet.Offset(mouseOff.X, mouseOff.Y);  //calculate the last point
                    ((ContainerControl)sender).Location = mouseSet;
                }
            };
            ((ContainerControl)Obj).MouseUp += (sender, e) =>
            {
                if (leftFlag)
                {
                    leftFlag = false;
                }
            };
        }
    }
}
