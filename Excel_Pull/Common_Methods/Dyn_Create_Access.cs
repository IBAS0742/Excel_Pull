using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADOX;
using System.IO;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Excel_Pull.Common_Methods
{
    public class Dyn_Create_Access
    {
        public ADOX.Catalog catalog { get; private set; } = new ADOX.Catalog();
        public string FileName { get; set; }
        public Dyn_Create_Access(string fileName)
        {
            FileName = fileName;
            if (File.Exists(FileName))
            {
                return;
            }
            else
            {
                catalog.Create("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Jet OLEDB:Engine Type=5");
            }
        }
        public void create_table(string tableName,List<string> headerName,List<int> headerType,List<int> headerSize){
            ADODB.Connection cn = new ADODB.Connection();
            cn.Open("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileName, null, null, -1);
            catalog.ActiveConnection = cn;
            ADOX.Table table = new ADOX.Table();
            table.Name = tableName;

            ADOX.Column column = new ADOX.Column();
            column.ParentCatalog = catalog;
            column.Name = "ID";
            column.Type = DataTypeEnum.adInteger;
            column.DefinedSize = 9;
            //column.Properties["AutoIncrement"].Value = true;
            table.Columns.Append(column, DataTypeEnum.adInteger, 9);
            table.Keys.Append("FirstTablePrimaryKey", KeyTypeEnum.adKeyPrimary, column, null, null);

            for (int i = 0;i < headerName.Count;i++)
            {
                table.Columns.Append(headerName[i], (DataTypeEnum)headerType[i],headerSize[i]);
            }
            try { 
                catalog.Tables.Append(table);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            cn.Close();
        }
        public void Non_Query(string sqlStr) {
            string strConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileName + ";Persist Security Info=False";
            OleDbConnection conn = new OleDbConnection(strConnection);
            conn.Open();
            OleDbCommand com = new OleDbCommand(sqlStr,conn);
            com.ExecuteNonQuery();
            conn.Close();
        }
    }
}
