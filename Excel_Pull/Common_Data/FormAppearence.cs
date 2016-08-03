using Excel_Pull.Common_Data_Structure;
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
        static public double MouseEnter { get { return 0.8; } }
        static public double MouseOver { get { return 0.5; } }
        static public Color Main_Form_Color { get { return Color.FromArgb(116, 253, 107); } }
    }
    public class DataBase_Data_Struct
    {
        public static List<string> Data_Type
        {
            get;
            private set;
        } = new List<string>() {
            "STRING",
            "INT",
            "DOUBLE",
        };
    }
    class OtherData
    {
        static public string ExcelRootDirectory { get { return @"c:\"; } }
        static public List<SheetInfo> Sheet_Info { get; set; }
        #region Blue color schemes
        static public List<Color> Blue = new List<Color>() {
            Color.FromArgb(223, 255, 246),
            Color.FromArgb(153, 249, 222),
            Color.FromArgb(65, 234, 211),
            Color.FromArgb(39, 209, 236),
            Color.FromArgb(1, 138, 255),
            Color.FromArgb(0, 81, 230),
            Color.Blue,
            Color.FromArgb(33, 0, 210),
            Color.FromArgb(2, 0, 128),
        };
        #endregion
        #region Green color schemes
        static public List<Color> Green = new List<Color>() {
            Color.FromArgb(201, 245, 213),
            Color.FromArgb(155, 247, 180),
            Color.FromArgb(151, 255, 118),
            Color.FromArgb(155, 236, 141),
            Color.FromArgb(169, 224, 118),
            Color.FromArgb(131, 212, 111),
            Color.FromArgb(106, 181, 87),
            Color.FromArgb(114, 193, 8),
            Color.Green
        };
        #endregion
        #region Red color schemes
        static public List<Color> Red = new List<Color>()
        {
            Color.FromArgb(254, 235, 255),
            Color.FromArgb(247, 216, 249),
            Color.FromArgb(247, 188, 251),
            Color.FromArgb(248, 142, 255),
            Color.FromArgb(249, 123, 222),
            Color.FromArgb(255, 42, 209),
            Color.FromArgb(255, 42, 121),
            Color.FromArgb(245, 39, 39),
            Color.FromArgb(185, 0, 0),
        };
        #endregion
        #region Light_Color color schemes
        static public List<Color> Light_Color = new List<Color>() {
            Color.FromArgb(245, 217, 217),
            Color.FromArgb(249, 233, 243),
            Color.FromArgb(251, 188, 249),
            Color.FromArgb(195, 177, 249),
            Color.FromArgb(150, 157, 247),
            Color.FromArgb(121, 175, 255),
            Color.FromArgb(150, 206, 253),
            Color.FromArgb(150, 243, 253),
            Color.FromArgb(140, 255, 196),
            Color.FromArgb(167, 251, 151),
            Color.FromArgb(225, 253, 170),
            Color.FromArgb(245, 227, 161),
            Color.FromArgb(251, 205, 136),
            Color.FromArgb(251, 168, 136),
        };
        #endregion
        static public Color DataGridView_First_Color { get; } = Color.White;
    }
    /// <summary>
    /// Something Error , so I copy the DataTypeEnum from ADOX
    /// </summary>
    public enum DataTypeEnum_
    {
        adEmpty = 0,
        adSmallInt = 2,
        adInteger = 3,
        adSingle = 4,
        adDouble = 5,
        adCurrency = 6,
        adDate = 7,
        adBSTR = 8,
        adIDispatch = 9,
        adError = 10,
        adBoolean = 11,
        adVariant = 12,
        adIUnknown = 13,
        adDecimal = 14,
        adTinyInt = 16,
        adUnsignedTinyInt = 17,
        adUnsignedSmallInt = 18,
        adUnsignedInt = 19,
        adBigInt = 20,
        adUnsignedBigInt = 21,
        adFileTime = 64,
        adGUID = 72,
        adBinary = 128,
        adChar = 129,
        adWChar = 130,
        adNumeric = 131,
        adUserDefined = 132,
        adDBDate = 133,
        adDBTime = 134,
        adDBTimeStamp = 135,
        adChapter = 136,
        adPropVariant = 138,
        adVarNumeric = 139,
        adVarChar = 200,
        adLongVarChar = 201,
        adVarWChar = 202,
        adLongVarWChar = 203,
        adVarBinary = 204,
        adLongVarBinary = 205
    }
}
