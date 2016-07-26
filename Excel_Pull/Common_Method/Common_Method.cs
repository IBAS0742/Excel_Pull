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
                OleDaExcel.Fill(ds, "table_" + i);//dt.Rows[i][2].ToString());
            }
            return ds;
        }
        static public void Dear()
        {

        }
    }
}
