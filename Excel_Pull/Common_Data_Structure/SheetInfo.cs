using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel_Pull.Common_Data;

namespace Excel_Pull.Common_Data_Structure
{
    /// <summary>
    /// Sheet Info just keep a sheet info 
    /// </summary>
    public class SheetInfo
    {
        #region Prototype
        // Name is not required but if you named a name , you can reuse it by the name .
        public string Name;
        // It will record the information which will be ignore from all the sheet .
        // irrelated Item is a list , and why ? 
        // Actually , a irrelated item record may only is a string , but string compare is to waste ,
        // and it may have some garbage(LAJI) in the whole record .
        // However , using a list to stored the cutted record element can make the storage using less ,
        // and search or judge a record more faster , and more adapted .
        private List<string> irrelated_Item;
        public List<string> Irrelated_Item { get { return irrelated_Item; } }
        // It will record the infromation which will be record as the common infromation for all the tables in a sheet .
        // I will give the reasons as same as the irrelated item .
        private List<string> record_Item;
        public List<string> Record_Item { get { return record_Item; } }
        // table information
        private Table table;
        public Table Table_ { get { return table; } }
        #endregion
        public SheetInfo()
        {
            irrelated_Item = new List<string>();
            record_Item = new List<string>();
            table = new Table();
        }
        public void Add_Irrelated_Item(string line,bool isSplit = true,char[] splitChar = null)
        {
            irrelated_Item.List_Add_Item(line, isSplit, splitChar);
        }
        public void Irrelated_Item_Clear()
        {
            irrelated_Item.Clear();
        }
        public void Add_Record_Item(string line,bool isSplit = true,char[] splitChar = null) {
            record_Item.List_Add_Item(line, isSplit, splitChar);
        }
        public void Record_Item_Clear()
        {
            record_Item.Clear();
        }
    }
    public enum Table_Style
    {
        Comfirm_Size,
        Changeing_Size
    }
    public class Table {
        #region Prototype
        // Record the table border up and down and left and right border .
        // Here the table border we talk is the not the really border but the flag which will match all the table .
        // > Match what ? 
        // > By using the flag we can match the next table information , knowing the range and the header and so on .
        // By smart analying given data , Process will try to give the some range date , and user can adjust them.
        private List<string> table_range;
        public List<string> Table_Range { get { return table_range; } }
        // Layers is the count of the table header .
        // > How to calculate ?
        // > Just related the count of the header lines .
        private int layers;
        public int Layers { get { return layers; } private set { layers = value; /* reSize the header */} }
        // (x/y)header is record the header information and the size is related with the layers .
        // Array will be create dynamically when the layers is change .
        // Similarly , its record is not the real thing but the some flag .
        public List<List<string>> xheader = null;
        public List<List<string>> XHeader { get { return xheader; } }
        public List<List<string>> yheader = null;
        public List<List<string>> YHeader { get { return yheader; } }
        // the var have two optional value to set ,
        // Comfirm Size  : the header and body is fixed .
        // Changing Size : table size is not fixed for any table in the sheet 
        public Table_Style TableStyle { get; set; }
        #endregion
        public Table()
        {
            table_range = new List<string>();
            layers = 0;
            xheader = new List<List<string>>();
            yheader = new List<List<string>>();
        }
    }
}
