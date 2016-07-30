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
    }
    public enum Table_Style
    {
        Comfirm_Size,
        Changeing_Size
    }
    /// <summary>
    /// At here , what I need to record it is not the exactly infromation but the table border
    /// </summary>
    public class Table {
        #region Prototype
        public List<string> Irrelate_Item { get; private set; } = new List<string>();
        public List<string> Record_Item { get; private set; } = new List<string>();
        public List<HeaderInfo> XHeader { get; private set; } = new List<HeaderInfo>();
        public List<HeaderInfo> YHeader { get; private set; } = new List<HeaderInfo>();
        public Table_Style TableStyle { get; set; }
        #endregion
        public Table()
        {
        }
    }
}
