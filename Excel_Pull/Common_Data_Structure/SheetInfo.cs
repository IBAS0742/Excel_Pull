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
        public List<string> Irrelated_Item { get; private set; } = new List<string>();
        // It will record the infromation which will be record as the common infromation for all the tables in a sheet .
        // I will give the reasons as same as the irrelated item .
        public List<string> Record_Item_ { get; private set; } = new List<string>();
        public List<List<string>> Record_Item { get; private set; } = new List<List<string>>();
        // table information
        public Table Table_ { get; private set; } = new Table();
        // For the first line is in the datatable header 
        // so if it is not nessary to get information in the header ,
        // I can ignore there exist a line , and program can run faster .
        public bool isNeededGetFirstLine { get; set; } = true;
        public AnalizeResult ar { get; private set; } = new AnalizeResult();
        #endregion
    }
    public enum Table_Style
    {
        Comfirm_Size,
        Changeing_Size
    }
    /// <summary>
    /// At here , what I need to record is not the exactly infromation but the table border
    /// </summary>
    public class Table {
        #region Prototype
        public List<string> Irrelate_Item { get; private set; } = new List<string>();
        public List<string> Record_Item_ { get; private set; } = new List<string>();
        public List<List<string>> Record_Item { get; private set; } = new List<List<string>>();
        public List<HeaderInfo> XHeader { get; private set; } = new List<HeaderInfo>();
        public List<HeaderInfo> YHeader { get; private set; } = new List<HeaderInfo>();
        public Table_Style TableStyle { get; set; }
        #endregion
    }

    public class AnalizeResult
    {
        public List<Loc> Sheet_Record { get; private set; } = new List<Loc>();
        public List<Loc> Table_Record { get; private set; } = new List<Loc>();
        public string TableStartKeyWord { get; set; }
        public int KeyWordRow { get; set; }
        public bool isFullSheet { get; set; } = false;
        public List<int> Sheet_Index { get; private set; } = new List<int>();
        public bool isFullTable { get; set; } = false;
        public List<int> Table_Index { get; private set; } = new List<int>();
        public int Sheet_Start { get; set; } = 0;
        public int Table_Start { get; set; } = 0;
        public int xHeaderFrom { get; set; } = 0;
        public int yHeaderFrom { get; set; } = 0;
    }
    public class Loc
    {
        public int x { get; set; }
        public int y { get; set; }
    }
}
