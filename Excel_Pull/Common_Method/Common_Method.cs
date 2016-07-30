using Excel_Pull.Common_Data_Structure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
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
        /// <summary>
        /// recurrence to find the file which ext includes ext
        /// </summary>
        /// <param name="path">target path</param>
        /// <param name="ext">target extern</param>
        /// <param name="FileName">result</param>
        static public void GetFile(string path,string[] ext,ref List<string> FileName)
        {
            string[] paths = Directory.GetDirectories(path);
            for (int i = 0;i < paths.Length;i++)
            {
                GetFile(paths[i],ext,ref FileName);
            }
            FileName.AddRange(
                Directory.GetFiles(path).Where(
                        m => {
                            string[] p = m.Split('.');
                            if (p.Length == 2)
                            {
                                if (ext.Contains(p[1]))
                                {
                                    return true;
                                }
                            }
                            return false;
                        }
                    )
            );
        }
    }

    //string pattern = "http://([^\\s]+)\"
    //Regex reg = new Regex( pattern, RegexOptions.IgnoreCase ); 
    public static class ExcelG
    {
        static public DataSet GetExcel(string fileName)
        {
            string connStr = "Provider=Microsoft.Jet.OLEDB.4.0;" + 
                             "Data Source=" + fileName + ";" + 
                             ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"";
            OleDbConnection odcon = new OleDbConnection(connStr);//建立连接
            odcon.Open();
            DataTable sTable = odcon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            //get all the sheet 
            DataTable dt = odcon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            DataSet ds = new DataSet();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                String sql = "SELECT * FROM  ["+ dt.Rows[i][2].ToString() + "]";            
                OleDbDataAdapter OleDaExcel = new OleDbDataAdapter(sql, odcon);
                OleDaExcel.Fill(ds, dt.Rows[i][2].ToString());// "table_" + i); // using sheet name , maybe sometime it is importance .
            }
            return ds;
        }
        static public void Dear()
        {

        }
    }
    public static class extern_method {
        // T is string this function only write for sheetinf class
        public static void List_Add_Item(this List<string> list,string line,bool isSplit = true,char[] splitChar = null)
        {
            if (isSplit)
            {
                if (splitChar == null)
                {
                    splitChar = new char[] { ' ' };
                }
                string[] items = line.Split(splitChar, StringSplitOptions.RemoveEmptyEntries).Distinct().ToArray();
                for (int i = 0; i < items.Count(); i++)
                {
                    if (list.Contains(items[i])) { }
                    else
                    {
                        list.Add(items[i]);
                    }
                }
            }
            else
            {
                if (list.Contains(line)) { }
                else
                {
                    list.Add(line);
                }
            }
        }
        public static bool Add_<T> (this List<T> list,T item)
        {
            if (list.Contains(item)) {
                return false;
            } else
            {
                list.Add(item);
                return true;
            }
        }
        public static bool Equals_(this Color c_1,Color c_2)
        {
            return c_1.ToArgb() == c_2.ToArgb();
        }
        public static bool Remove_(this List<CellLocation> list,CellLocation item)
        {
            for (int i = 0;i < list.Count;i++)
            {
                if (list[i].X == item.X && list[i].Y == item.Y)
                {
                    list.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
    }
}
