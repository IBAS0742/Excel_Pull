using Excel_Pull.Common_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Excel_Pull.Common_Data_Structure;

namespace Excel_Pull.PersonalControllers
{
    public enum oColor {
        SHEET_IR = 0,
        SHEET_RE = 1,
        TABLE_IR = 2,
        TABLE_RE = 3
    };
    public enum Table_Structure {
        SHEET_IR,
        SHEET_RE,
        TABLE_IR,
        TABLE_RE,
        TABLE_X_HEADER,
        TABLE_Y_HEADER,
        NULL
    }
    public partial class CutTable : Form
    {
        #region Prototype
        /// <summary>
        /// dtable_ is the nature table
        /// dtable is the partly copy table
        /// TargetFile is the file contianing tables
        /// toppest is the count of the TargetFile toppest 'toppest' records
        /// curTop is the current count of the table rows
        /// FirstRow is the selected First row index
        /// LastRow is the selected Last row index
        /// </summary>
        public DataTable dtable_ = null;
        public DataTable dtable = null;
        public string TargetFile { get; set; }
        public int toppest { get; set; }
        public int curTop { get; set; }
        private int FirstRow = -1;
        private int LastRow = -1;
        private int FirstCol = -1;
        private int LastCol = -1;
        private int ColumnCount;
        // curSheet is the sheet in that time have been shown in the datagridview1
        // totalSheet is total sheet count which the opened excel file have .
        private int curSheet;
        private int totalSheet;
        // at list you can get all the information about the opened excel file .
        private DataSet list;
        // One Sheet have one corresponding Sheet_Info .
        // In Sheet_Info there are recording that the sheet level information and the table information ,
        // and according to the Sheet_Info , program can get more exactly data (or execute more exactly) . 
        private List<SheetInfo> Sheet_Info = null;
        // Color scheme is the default and private value defined in the program not changing by user .
        // olastColor will using at the irrelated information and one line one color . 
        static private List<Color> xColorScheme = OtherData.Blue;
        private int xlastColor = 0;
        static private List<Color> yColorScheme = OtherData.Green;
        private int ylastColor = 0;
        // get from oColor
        static private List<Color> oColorScheme = OtherData.Light_Color;
        // Sheet_Irrelate and Sheet_Record and Table_X_Header and Table_Y_Header 
        // will record the location of the selected cells , and it is easily when remove the selected cells .
        // x/yColorUseTime will record the color using statue and 
        // when one line have a cell have been selected or dis_selected program will search 
        // wheather have a cell is colored in the same row (column) ,
        // and then increate or decline the record value .
        private List<CellLocation> Sheet_Irrelate = new List<CellLocation>();
        private List<CellLocation> Sheet_Record = new List<CellLocation>();
        private List<CellLocation> Table_Irrelate = new List<CellLocation>();
        private List<CellLocation> Table_Record = new List<CellLocation>();
        private List<CellLocation> Table_X_Header = new List<CellLocation>();
        private int[] xColorUseTime = new int[xColorScheme.Count];
        private List<CellLocation> Table_Y_Header = new List<CellLocation>();
        private int[] yColorUseTime = new int[yColorScheme.Count];
        #endregion
        #region System Controllers Event
        public CutTable()
        {
            InitializeComponent();
        }
        private void CutTable_Shown(object sender, EventArgs e)
        {
            Reload();
        }
        private void CutTable_Load(object sender, EventArgs e)
        {
            this.BackColor = FormAppearence.Main_Form_Color;
            this.Opacity = 0.9;
            Common_Method.AddMoveEvent(this, typeof(Form1));
            dataGridView1.ColumnHeadersVisible = false;
            //dataGridView1.AllowUserToAddRows = false;
            Set_DGV();
            toppest = 100;
        }
        #endregion
        #region Other Self Defined Method
        public void GetList()
        {
            //DataSet list = ExcelG.GetExcel(@"D:\C#\测试\数据挖掘_hjs\B赛题数据\附件1：旅客列车梯形密度表\201501-12\01月\1.xlsx");
            list = ExcelG.GetExcel(TargetFile);
            if (!File.Exists(TargetFile))
            {
                return;
            }
            totalSheet = list.Tables.Count;
            curSheet = 0;
            if (Sheet_Info == null)
            {
                Sheet_Info = new List<SheetInfo>();
                for (int i = 0;i < totalSheet;i++)
                {
                    Sheet_Info.Add(new SheetInfo());
                }
                OtherData.Sheet_Info = Sheet_Info;
            }
            GetSheet();
        }
        private bool GetSheet()
        {
            if (curSheet >= totalSheet)
            {
                return false;
            }
            DataTable dt = list.Tables[curSheet];
            if (dtable != null)
            {
                dtable_.Clear();
                dtable_ = null;
                dtable.Clear();
                dtable = null;
            }
            int j;
            dtable = new DataTable();
            dtable_ = new DataTable();
            ColumnCount = dt.Columns.Count;
            for (j = 0; j < dt.Columns.Count; j++)
            {
                dtable.Columns.Add(dt.Columns[j].ColumnName);
                dtable.Columns[j].DataType = typeof(string);
                dtable_.Columns.Add(dt.Columns[j].ColumnName);
                dtable_.Columns[j].DataType = typeof(string);
            }
            DataRow dr = dtable.NewRow();
            DataRow dr_ = dtable_.NewRow();
            for (j = 0; j < dt.Columns.Count; j++)
            {
                if (dt.Columns[j].ColumnName[0] != 'F')
                {
                    dr[j] = dt.Columns[j].ColumnName;
                    dr_[j] = dt.Columns[j].ColumnName;
                }
                else
                {
                    dr[j] = "";
                    dr_[j] = "";
                }
            }
            dtable.Rows.Add(dr);
            for (j = 0; j < dt.Rows.Count && j < toppest; j++)
            {
                dtable.ImportRow(dt.Rows[j]);
            }
            curTop = j;
            dtable.Rows.RemoveAt(j);
            for (j = 0; j < dt.Rows.Count; j++)
            {
                dtable_.ImportRow(dt.Rows[j]);
            }
            toppest = j;
            return true;
        }
        public void Reload()
        {
            if (dtable == null)
            {
                GetList();
            }
            else {
                //dtable.Rows.Clear();
                //for (int j = 0;j < toppest && j < dtable.Rows.Count;j++)
                //{
                //    dtable.ImportRow(dtable_.Rows[j]);
                //}
            }
            dataGridView1.DataSource = dtable;
        }
        private void Set_DGV()
        {
            dataGridView1.ColumnHeadersVisible = false;
            //dataGridView1.Enabled = false;
            dataGridView1.MouseClick += (sender, e) =>
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (FirstRow != -1 && LastRow != -1)
                    {
                        for (int i = FirstRow; i <= LastRow; i++)
                        {
                            if (FirstCol != -1 && LastCol != -1)
                            {
                                for (int j = FirstCol; j <= LastCol; j++)
                                {
                                    dataGridView1.Rows[i].Cells[j].Style.BackColor = OtherData.DataGridView_First_Color;
                                }
                            }
                            else
                            {
                                dataGridView1.Rows[i].DefaultCellStyle.BackColor = OtherData.DataGridView_First_Color;
                            }
                        }
                    }
                    contextMenuStrip1.Show(
                        Control.MousePosition.X + 10,
                        Control.MousePosition.Y + 10
                    );
                }
            };
        }
        private void Add_One_Item_In_List(List<CellLocation> list,Color Tag_Color,object tag)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                dataGridView1
                    .SelectedCells[0]
                        .Style
                            .BackColor = Tag_Color;
                list.Add_(new CellLocation()
                {
                    X = dataGridView1.SelectedCells[0].RowIndex,
                    Y = dataGridView1.SelectedCells[0].ColumnIndex
                });

                dataGridView1
                    .SelectedCells[0]
                        .Tag = tag;
            }
        }
        private void Clear_List(List<CellLocation> list) {
            for (int i = 0;i < list.Count;i++)
            {
                dataGridView1
                    .Rows[list[i].X]
                        .Cells[list[i].Y]
                            .Style
                                .BackColor
                                    = OtherData.DataGridView_First_Color;

                dataGridView1
                    .Rows[list[i].X]
                        .Cells[list[i].Y]
                            .Tag = Table_Structure.NULL;
            }
            list.Clear();
        }
        private void Analize_Table()
        {
            int xlen = dataGridView1.ColumnCount,
                ylen = dataGridView1.RowCount - 1,
                i,
                j,
                firstX = -1;
            Table_Structure ts;
            #region Analize the selections
            for (i = 0;i < ylen;i++)
            {
                for (j = 0;j < xlen;j++)
                {
                    DataGridViewCell cell = dataGridView1.Rows[i].Cells[j];
                    ts = (dataGridView1.Rows[i].Cells[j].Tag == null)?Table_Structure.NULL: (Table_Structure)dataGridView1.Rows[i].Cells[j].Tag;
                    #region SHEET_IR SHEET_RE TABLE_IR TABLE_RE
                    if (ts == Table_Structure.SHEET_IR)
                    {
                        Sheet_Info[curSheet].isNeededGetFirstLine = false;
                        Sheet_Info[curSheet].Irrelated_Item.Add(cell.Value.ToString());
                        cell.Tag = Table_Structure.NULL;
                    } else if (ts == Table_Structure.SHEET_RE)
                    {
                        List<string> li = new List<string>();
                        Sheet_Info[curSheet].ar.Sheet_Record.Add(new Loc() { x = j,y = i});
                        Sheet_Info[curSheet].Record_Item_.Add(cell.Value.ToString());
                        li.Clear();
                        li.List_Add_Item(cell.Value.ToString());
                        Sheet_Info[curSheet].Record_Item.Add(li);
                        cell.Tag = Table_Structure.NULL;
                    } else if (ts == Table_Structure.TABLE_IR)
                    {
                        Sheet_Info[curSheet].Table_.Irrelate_Item.List_Add_Item(cell.Value.ToString());
                        cell.Tag = Table_Structure.NULL;
                    } else if (ts == Table_Structure.TABLE_RE)
                    {
                        List<string> li = new List<string>();
                        Sheet_Info[curSheet].ar.Table_Record.Add(new Loc() { x = j, y = i });
                        Sheet_Info[curSheet].Table_.Record_Item_.Add(cell.Value.ToString());
                        li.Clear();
                        li.List_Add_Item(cell.Value.ToString());
                        Sheet_Info[curSheet].Table_.Record_Item.Add(li);
                        cell.Tag = Table_Structure.NULL;
                    }
                    #endregion
                    #region Table_X_Header
                    else if (ts == Table_Structure.TABLE_X_HEADER)
                    {
                        // scan a horizon line
                        if (firstX < 0)
                        {
                            firstX = i;
                        }
                        HeaderInfo hi = new HeaderInfo();
                        int k;
                        for (k = 0;k < xlen;k++)
                        {
                            if (dataGridView1.Rows[i].Cells[k].Tag != null) {
                                if ((Table_Structure)dataGridView1.Rows[i].Cells[k].Tag == Table_Structure.TABLE_X_HEADER)
                                {
                                    break;
                                }
                            } else
                            {
                                hi.Flag.List_Add_Item(dataGridView1.Rows[i].Cells[k].Value.ToString());
                            }
                        }
                        hi.FromCell = k;
                        for (; k < xlen; k++)
                        {
                            if (dataGridView1.Rows[i].Cells[k].Tag != null)
                            {
                                if ((Table_Structure)dataGridView1.Rows[i].Cells[k].Tag != Table_Structure.TABLE_X_HEADER)
                                {
                                    break;
                                } else
                                {
                                    dataGridView1.Rows[i].Cells[k].Tag = Table_Structure.NULL;
                                }
                            }
                        }
                        k--;
                        hi.ToCell = xlen - k;
                        for (;k < xlen;k++)
                        {
                            hi.Flag.List_Add_Item(dataGridView1.Rows[i].Cells[k].Value.ToString());
                        }
                        Sheet_Info[curSheet].Table_.XHeader.Add(hi);
                    }
                    #endregion
                    #region Table_Y_Header
                    else if (ts == Table_Structure.TABLE_Y_HEADER)
                    {
                        // scan a vertical line
                        HeaderInfo hi = new HeaderInfo();
                        int k;
                        for (k = 0; k < ylen; k++)
                        {
                            if (dataGridView1.Rows[k].Cells[j].Tag != null)
                            {
                                if ((Table_Structure)dataGridView1.Rows[k].Cells[j].Tag == Table_Structure.TABLE_Y_HEADER)
                                {
                                    break;
                                }
                            }
                            else
                            {
                                hi.Flag.List_Add_Item(dataGridView1.Rows[k].Cells[j].Value.ToString());
                            }
                        }
                        if (firstX < 0)
                        {
                            hi.FromCell = k;
                        }
                        else
                        {
                            hi.FromCell = k - firstX;
                        }
                        for (; k < ylen; k++)
                        {
                            if (dataGridView1.Rows[k].Cells[j].Tag != null)
                            {
                                if ((Table_Structure)dataGridView1.Rows[k].Cells[j].Tag != Table_Structure.TABLE_Y_HEADER)
                                {
                                    break;
                                }
                                else
                                {
                                    dataGridView1.Rows[k].Cells[j].Tag = Table_Structure.NULL;
                                }
                            }
                        }
                        k--;
                        hi.ToCell = ylen - k;
                        for (; k < ylen; k++)
                        {
                            hi.Flag.List_Add_Item(dataGridView1.Rows[k].Cells[j].Value.ToString());
                        }
                        Sheet_Info[curSheet].Table_.YHeader.Add(hi);
                    }
                    #endregion
                    else
                    {
                    }
                }
            }
            #endregion
        }
        #endregion
        #region ToolStriptMenu ##########################################
        #region Auto Column Width
        private void autoColumnWidthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        #endregion
        #region Show More
        private void showMoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sm = Interaction.InputBox(
                "Please Input A Nuber , And It Belong To [-" + curTop + ",Max_Row_Count]",
                "Show More"
                );
            int sm_ = 0;
            FirstRow = LastRow = -1;
            try
            {
                sm_ = Convert.ToInt32(sm);
            }
            catch
            {
            }
            //toppest += sm_;
            if (sm_ < 0) {
                while (sm_ != 0 && curTop > 1)
                {
                    curTop--;
                    dtable.Rows.RemoveAt(curTop);
                    sm_++;
                }
            } else if (sm_ > 0) {
                int totalRows = dtable_.Rows.Count;
                while (sm_ != 0 && curTop < totalRows)
                {
                    dtable.ImportRow(dtable_.Rows[curTop - 1]);
                    curTop++;
                    sm_--;
                }
            }
        }
        private void showAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i;
            FirstRow = LastRow = -1;
            for (i = 0;i < curTop;i++)
            {
                dtable.Rows.RemoveAt(0);
            }
            for (i = 0;i < toppest;i++)
            {
                dtable.ImportRow(dtable_.Rows[i]);
            }
            curTop = toppest;
        }
        private void reloadTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetList();
            Reload();
        }
        #endregion
        #region Cut Table Operate
        private void asFirstRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                FirstRow = dataGridView1.SelectedRows[0].Index;
            } else if (dataGridView1.SelectedCells.Count > 0)
            {
                FirstRow = dataGridView1.SelectedCells[0].RowIndex;
            } else
            {
                return;
            }
            if (LastRow != -1)
            {
                if (FirstRow > LastRow)
                {
                    int t = FirstRow;
                    FirstRow = LastRow;
                    LastRow = t;
                }
            }
        }
        private void asLastRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                LastRow = dataGridView1.SelectedRows[0].Index;
            }
            else if (dataGridView1.SelectedCells.Count > 0)
            {
                LastRow = dataGridView1.SelectedCells[0].RowIndex;
            }
            else
            {
                return;
            }
            if (FirstRow != -1)
            {
                if (FirstRow > LastRow)
                {
                    int t = FirstRow;
                    FirstRow = LastRow;
                    LastRow = t;
                }
            }
        }
        private void showSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FirstRow != -1 && LastRow != -1)
            {
                for (int i = FirstRow;i <= LastRow;i++)
                {
                    if (FirstCol != -1 && LastCol != -1)
                    {
                        for (int j = FirstCol;j <= LastCol;j++)
                        {
                            dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.FromArgb(249, 200, 255);
                        }
                    } else { 
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(249, 200, 255);
                    }
                }
            } else
            {
                if (FirstRow == -1)
                {
                    if (LastRow == -1)
                    {
                        MessageBox.Show("You have not select FirstRow and LastRow", "Error", MessageBoxButtons.OK);
                    }
                    else
                    {
                        dataGridView1.Rows[LastRow].DefaultCellStyle.BackColor = Color.FromArgb(249, 200, 255);
                        MessageBox.Show("You have not select FirstRow", "Error", MessageBoxButtons.OK);
                    }
                } else
                {
                    dataGridView1.Rows[FirstRow].DefaultCellStyle.BackColor = Color.FromArgb(249, 200, 255);
                    MessageBox.Show("You have not select Last Row", "Error", MessageBoxButtons.OK);
                }
            }
        }
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = LastRow - FirstRow + 1;
            int i;
            for (i = 0;i < FirstRow;i++)
            {
                dtable.Rows.RemoveAt(0);
            }
            for (i = 0; i < count; i++) ;
            count = dtable.Rows.Count;
            for (;count > i;count--)
            {
                dtable.Rows.RemoveAt(i);
            }
            FirstRow = LastRow = -1;
            if (FirstCol != -1 && LastCol != -1)
            {
                for (i = 0;i < FirstCol;i++)
                {
                    dtable.Columns.RemoveAt(0);
                }
                for (i = LastCol + 1;i < ColumnCount;i++)
                {
                    dtable.Columns.RemoveAt(LastCol + 1);
                }
                ColumnCount = dtable.Columns.Count;
            }
            FirstCol = LastCol = -1;
        }
        private void asFirstColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FirstCol = dataGridView1.SelectedCells[0].ColumnIndex;
            if (LastCol != -1)
            {
                if (LastCol < FirstCol)
                {
                    int t = FirstCol;
                    FirstCol = LastCol;
                    LastCol = t;
                }
            }
        }
        private void asLastColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LastCol = dataGridView1.SelectedCells[0].ColumnIndex;
            if (FirstCol != -1)
            {
                if (LastCol < FirstCol)
                {
                    int t = FirstCol;
                    FirstCol = LastCol;
                    LastCol = t;
                }
            }
        }
        private void overToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cut_Table.Visible = false;
            Resolve_A_Table.Visible = true;
        }
        #endregion
        #region Resolve A Table *
        //Mood : -_- , A new day is going now is 2016-07-28 13:06:47
        #region Sheet Level
        #region Irrelated Item
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_One_Item_In_List(Sheet_Irrelate, oColorScheme[(int)oColor.SHEET_IR],Table_Structure.SHEET_IR);
        }
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clear_List(Sheet_Irrelate);
        }
        #endregion
        #region Record Item
        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Add_One_Item_In_List(Sheet_Record, oColorScheme[(int)oColor.SHEET_RE],Table_Structure.SHEET_RE);
        }
        private void clearToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Clear_List(Sheet_Record);
        }
        #endregion
        #endregion
        #region Table Level
        #region Irrelated Item
        private void addToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Add_One_Item_In_List(Table_Irrelate, oColorScheme[(int)oColor.TABLE_IR], Table_Structure.TABLE_IR);
        }
        private void clearToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Clear_List(Table_Irrelate);
        }
        #endregion
        #region Record Item
        private void addToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Add_One_Item_In_List(Table_Record, oColorScheme[(int)oColor.TABLE_RE], Table_Structure.TABLE_RE);
        }
        private void removeToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Clear_List(Table_Record);
        }
        #endregion
        #region X Header Item
        private void addToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                for (int i = 0;i < dataGridView1.SelectedCells.Count;i++)
                {
                    if (dataGridView1.SelectedCells[i].Style.BackColor.ToArgb() == -1 ||
                        dataGridView1.SelectedCells[i].Style.BackColor.ToArgb() == 0)
                    {
                        int x = dataGridView1.SelectedCells[i].RowIndex,
                            y = dataGridView1.SelectedCells[i].ColumnIndex,
                            j;
                        bool isColored = false;
                        for (j = 0;j < Table_X_Header.Count;j++)
                        {
                            if (Table_X_Header[j].X == x)
                            {
                                dataGridView1.SelectedCells[i].Tag = Table_Structure.TABLE_X_HEADER;
                                dataGridView1.SelectedCells[i].Style.BackColor =
                                    dataGridView1.Rows[Table_X_Header[j].X]
                                        .Cells[Table_X_Header[j].Y].Style.BackColor;
                                isColored = true;
                                if (Table_X_Header[j].Y == y)
                                {
                                }
                                else
                                {
                                    for (int k = 0; k < xColorScheme.Count; k++)
                                    {
                                        if (xColorScheme[j] == dataGridView1.SelectedCells[i].Style.BackColor)
                                        {
                                            xColorUseTime[j]++;
                                            break;
                                        }
                                    }
                                }
                                break;
                            }
                        }
                        Table_X_Header.Add_(new CellLocation()
                        {
                            X = x,
                            Y = y
                        });
                        if (!isColored)
                        {
                            for (j = 0;j < xColorScheme.Count;j++)
                            {
                                if (xColorUseTime[j] == 0)
                                {
                                    dataGridView1.SelectedCells[i].Tag = Table_Structure.TABLE_X_HEADER;
                                    dataGridView1.SelectedCells[i].Style.BackColor = xColorScheme[j];
                                    xColorUseTime[j] = 1;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
        private void clearToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count < 0)
            {
                return;
            }
            for (int i = 0;i < dataGridView1.SelectedCells.Count;i++)
            {

                if (dataGridView1.SelectedCells[i].Style.BackColor.ToArgb() == -1 ||
                    dataGridView1.SelectedCells[i].Style.BackColor.ToArgb() == 0) { } else
                {
                    Table_X_Header.Remove_(new CellLocation()
                    {
                        X = dataGridView1.SelectedCells[i].RowIndex,
                        Y = dataGridView1.SelectedCells[i].ColumnIndex
                    });
                    for (int j = 0; j < xColorUseTime.Count();j++)
                    {
                        if (xColorScheme[j] == dataGridView1.SelectedCells[i].Style.BackColor)
                        {
                            xColorUseTime[j]--;
                            dataGridView1.SelectedCells[i].Style.BackColor = OtherData.DataGridView_First_Color;
                            break;
                        }
                    }
                }
            }
        }
        #endregion
        #region Y Header Item
        private void addToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                for (int i = 0; i < dataGridView1.SelectedCells.Count; i++)
                {
                    if (dataGridView1.SelectedCells[i].Style.BackColor.ToArgb() == -1 ||
                        dataGridView1.SelectedCells[i].Style.BackColor.ToArgb() == 0)
                    {
                        int x = dataGridView1.SelectedCells[i].RowIndex,
                            y = dataGridView1.SelectedCells[i].ColumnIndex,
                            j;
                        bool isColored = false;
                        for (j = 0; j < Table_Y_Header.Count; j++)
                        {
                            if (Table_Y_Header[j].Y == y)
                            {
                                dataGridView1.SelectedCells[i].Tag = Table_Structure.TABLE_Y_HEADER;
                                dataGridView1.SelectedCells[i].Style.BackColor =
                                    dataGridView1.Rows[Table_Y_Header[j].X]
                                        .Cells[Table_Y_Header[j].Y].Style.BackColor;
                                isColored = true;
                                if (Table_Y_Header[j].X == x)
                                {
                                }
                                else
                                {
                                    for (int k = 0; k < yColorScheme.Count; k++)
                                    {
                                        if (yColorScheme[j] == dataGridView1.SelectedCells[i].Style.BackColor)
                                        {
                                            yColorUseTime[j]++;
                                            break;
                                        }
                                    }
                                }
                                break;
                            }
                        }
                        Table_Y_Header.Add_(new CellLocation()
                        {
                            X = x,
                            Y = y
                        });
                        if (!isColored)
                        {
                            for (j = 0; j < yColorScheme.Count; j++)
                            {
                                if (yColorUseTime[j] == 0)
                                {
                                    dataGridView1.SelectedCells[i].Tag = Table_Structure.TABLE_Y_HEADER;
                                    dataGridView1.SelectedCells[i].Style.BackColor = yColorScheme[j];
                                    yColorUseTime[j] = 1;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
        private void clearToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count < 0)
            {
                return;
            }
            for (int i = 0; i < dataGridView1.SelectedCells.Count; i++)
            {
                if (dataGridView1.SelectedCells[i].Style.BackColor.ToArgb() == -1 ||
                    dataGridView1.SelectedCells[i].Style.BackColor.ToArgb() == 0) { }
                else
                {
                    Table_Y_Header.Remove_(new CellLocation()
                    {
                        X = dataGridView1.SelectedCells[i].RowIndex,
                        Y = dataGridView1.SelectedCells[i].ColumnIndex
                    });
                    for (int j = 0; j < xColorUseTime.Count(); j++)
                    {
                        if (yColorScheme[j] == dataGridView1.SelectedCells[i].Style.BackColor)
                        {
                            yColorUseTime[j]--;
                            dataGridView1.SelectedCells[i].Style.BackColor = OtherData.DataGridView_First_Color;
                            break;
                        }
                    }
                }
            }
        }
        #region
        #endregion
        #endregion
        #region Table Style
        private void comfirmSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comfirmSizeToolStripMenuItem.BackColor = Color.FromArgb(150, 127, 255, 0);
            changingSizeToolStripMenuItem.BackColor = OtherData.DataGridView_First_Color;
            Sheet_Info[curSheet].Table_.TableStyle = Table_Style.Comfirm_Size;
        }
        private void changingSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changingSizeToolStripMenuItem.BackColor = Color.FromArgb(150, 127, 255, 0);
            comfirmSizeToolStripMenuItem.BackColor = OtherData.DataGridView_First_Color;
            Sheet_Info[curSheet].Table_.TableStyle = Table_Style.Changeing_Size;
        }
        #endregion
        #endregion
        #region Reset
        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #region Over
        private void overToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Analize_Table();
            ShowResult sr = new ShowResult();
            sr.RL_Sheet_One.list = new List<string>();
            Sheet_Info[curSheet].Record_Item.ForEach(
                    n => {
                        sr.RL_Sheet_One.list.AddRange(n);
                    }
                );
            sr.RL_Sheet_Two.list = Sheet_Info[curSheet].Record_Item_;
            sr.RL_Table_One.list = new List<string>();
            Sheet_Info[curSheet].Table_.Record_Item.ForEach(
                    n =>
                    {
                        sr.RL_Table_One.list.AddRange(n);
                    }
                );
            sr.RL_Table_Two.list = Sheet_Info[curSheet].Table_.Record_Item_;
            sr.ShowDialog();
        }
        #endregion
        #endregion
        #region From Header
        private void formHeaderToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #region ShowInfo
        private void showInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #region Next Sheet
        private void nextSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you finish the current sheet operate ?","Warning",MessageBoxButtons.YesNo) == DialogResult.No) {
                return;
            }
            curSheet++;
            if (!GetSheet())
            {
                MessageBox.Show("Have not next sheet , it is the last sheet .","Warning",MessageBoxButtons.OK);
            }
        }
        #endregion
        #region Example
        private void exampleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #region Help
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpDialog hd = new HelpDialog() {
                Text = "**Double Click To Close This**\r\n\r\n" +
                       "Your should select a table first , you can choose anyone ,but I suggest you to choose the first one or the smallest one ." +
                       "And then select some cell in the table which is the first Row first cell and " +
                       "last Row last cell , and the header Row first cell ." +
                       "And sometimes , there are something special , like a table statement , " +
                       "so you also need to select them . \r\n\r\n" + 
                       "If you do not know how to do you can open the example and try to do with me ."
            };
            hd.DoubleClick += (sender_, e_) => {
                ((HelpDialog)sender_).Close();
            };
            hd.ShowDialog();
        }
        #endregion
        #region Close
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #endregion
    }
}

/*
 * Every Sheet show one by one
 * Show table need to using asyncTask
 * 2016-07-28 21:32:39 : You can find there are many function have a simillar structure , so it is terrible .
 */

/*
 * ToolStriptMenu
 * Auto Column Width : Auto Adjust the Column Width
 *            ________________________________________________________________________________________________
 * Show More         -| * Show More ... :    Show more rows on the DataGridView if you can not view a whole table and selection will be reinit
 *                    | * Show All      :    The nature table will be shown on the DataGridView
 *                    | * Reload        :    All the operate will be draw back
 *            ________________________________________________________________________________________________
 * Cut Table         -| * As First Row  :    Select The Table (not only the table body) first row
 *                    | * As Last Row   :    Select The Table (not only the table body) last row
 *                    | * As First Col  :    Select The Table first column
 *                    | * As Last Col   :    Select The Table last column
 *                    | * Show Select   :    Only Show The Select Border not to Cut
 *                    | * Cut           :    Cut the table and only the selection on the DataGridView
 *                    | * Over          :    Prevent user mistake operate , and will close this menu open next menu
 *            ________________________________________________________________________________________________
 * Resolve A Table   -| * Sheet Level      -| //(At this child menu all the operate is point to the sheet)
 *                                          | * Common irrelated Item   -| * Add \ * Clear
 *                                          | * Common record Item      -| * Add \ * Clear
 *                    | * Table Level      -| // (At this child menu all the operate is point to the table)
 *                                          | * Record Item             -| * Add \ * Clear
 *                                          | * X Header Item           -| * Add \ * Clear
 *                                          | * Y Header Item           -| * Add \ * Clear
 *                                          | * Form Header              : according to the X and Y header item to form header
 *                                          | * Border Style            -| * Comfirm Size \ * Changing Size
 *                    | * Reset : reinit all the selections 
 *                    | * Over  : Arraising a signal , let program start to work and to analise the user selections .
 *                    | * Other            -| //(Cut Table Rule can Record at here)
 *                                          | * ???
 *            ________________________________________________________________________________________________
 * ShowInfo   :   Show the information that up to now what the operate user have done .
 * Next Sheet :   Show Next Sheet and user should be promise the curency sheet have be ovre .
 * Example    :   Show one or more example for user and it will simple for my work .
 * Help       :   show the help for user and aim to make user know how to use it .
 * Close      :   close the window
 */

/* 
 * My operate steps will show as follow :
 * Firstly      , cut a little part but is complete part .
 * Secondly     , split the little part , one is belong to a table and another is belong to a sheet (or all table) .
 * Thirdly      , the sheet's part will be cut as two part that is irrelated part which will be ignore 
 *                and another is record part which will be save as part of the information of all the table.
 * Forthly      , to split the table part , you can get two part of them , and one is header part which alway is the toppest and leftest line on a table,
 *                and another part is data part .
 * Fifthly      , show the information you had make and you also can go to next step straightly .
 * Sixthly      , give some rule or some adjustment to make the programe more smart to process you file .
 * Seventhly    , begin to deal with files .
 * Additionally , all the excel will have a same operate that the first excel have defined .
 */

/*
 * How To Add Color ?
 * Sheet Level only have to color : irrelated item and record two color which from ocolorScheme
 * Table header have two set color : x and y header 
 * Table irrelate item have one color
 * Table record item have on color
 */

/*
 * warning : 
 *  header must be some cells together .
 */

/*
 * How to do when over get the informations ?
 * How to thinking ?
 * * First , what I can get ? (Here only talk about the table level .)
 * I will get the x and y header informations and also get the local about the x and y header .
 * * And then ? (I am just talking about the table level .)
 * How to dear with the x and y header ?
 * Set their data structure and data length ? Prepare for database to store them ?
 * Set their relation (x to y is ) ?
 */

/*
 * How To Store The Table in The DataBase ?
 * TABLE_ID SHEET_RE TABLE_RE
 * RECORD_ID TABLE_ID X_H_1 X_H_2 ... Y_H_1 Y_H_2 ... VALUE
 */

