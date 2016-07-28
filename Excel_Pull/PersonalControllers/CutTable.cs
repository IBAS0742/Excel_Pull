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
        //
        private int curSheet;
        private int totalSheet;
        //
        private DataSet list;
        // 
        private List<SheetInfo> Sheet_Info = null;
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
            dataGridView1.CellClick += (sender, e) => {
                if (FirstRow != -1 && LastRow != -1)
                {
                    for (int i = FirstRow; i <= LastRow; i++)
                    {
                        if (FirstCol != -1 && LastCol != -1)
                        {
                            for (int j = FirstCol; j <= LastCol; j++)
                            {
                                dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;
                            }
                        }
                        else
                        {
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        }
                    }
                }
                contextMenuStrip1.Show(
                    Control.MousePosition.X + 10,
                    Control.MousePosition.Y + 10
                );
            };
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
        #endregion
        #region Resolve A Table *
        //Mood : -_- , A new day is going now is 2016-07-28 13:06:47
        #region Sheet Level
        #region Irrelated Item
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                Sheet_Info[curSheet].Add_Irrelated_Item(
                        dataGridView1
                            .SelectedCells[0]
                                .Value
                                    .ToString()
                    );
            }
        }
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sheet_Info[curSheet].Irrelated_Item_Clear();
        }
        #endregion
        #region Record Item
        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                Sheet_Info[curSheet].Add_Record_Item(
                        dataGridView1
                            .SelectedCells[0]
                                .Value
                                    .ToString()
                    );
            }
        }
        private void removeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Sheet_Info[curSheet].Record_Item_Clear();
        }
        #endregion
        #endregion
        #region Table Level
        #region Record Item
        private void addToolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }
        private void removeToolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #region X Header Item
        private void addToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }
        private void removeToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #region Y Header Item
        private void addToolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }
        private void removeToolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }
        #region
        #endregion
        #endregion
        #region Table Style
        private void comfirmSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comfirmSizeToolStripMenuItem.BackColor = Color.FromArgb(150, 127, 255, 0);
            changingSizeToolStripMenuItem.BackColor = Color.White;
            Sheet_Info[curSheet].Table_.TableStyle = Table_Style.Comfirm_Size;
        }
        private void changingSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changingSizeToolStripMenuItem.BackColor = Color.FromArgb(150, 127, 255, 0);
            comfirmSizeToolStripMenuItem.BackColor = Color.White;
            Sheet_Info[curSheet].Table_.TableStyle = Table_Style.Changeing_Size;
        }
        #endregion
        #endregion From Header
        private void formHeaderToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #region ShowInfo
        private void showInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
 *            ________________________________________________________________________________________________
 * Resolve A Table   -| * Sheet Level      -| //(At this child menu all the operate is point to the sheet)
 *                                          | * Common irrelated Item   -| * Add \ * Clear
 *                                          | * Common record Item      -| * Add \ * Remove
 *                    | * Table Level      -| // (At this child menu all the operate is point to the table)
 *                                          | * Record Item             -| * Add \ * Remove
 *                                          | * X Header Item           -| * Add \ * Remove
 *                                          | * Y Header Item           -| * Add \ * Remove
 *                                          | * Form Header              : according to the X and Y header item to form header
 *                                          | * Border Style            -| * Comfirm Size \ * Changing Size
 *                    | * Other            -| //(Cut Table Rule can Record at here)
 *                                          | * ???
 *            ________________________________________________________________________________________________
 * ShowInfo   :   Show the information that up to now what the operate user have done .
 * Example    :   Show one or more example for user and it will simple for my work .
 * Help       :   show the help for user and aim to make user know how to use it .
 * Close      :   close the window
 */

/* 
 * My operate steps will show as follow :
 * Firstly   , cut a little part but is complete part .
 * Secondly  , split the little part , one is belong to a table and another is belong to a sheet (or all table) .
 * Thirdly   , the sheet's part will be cut as two part that is irrelated part which will be ignore 
 *             and another is record part which will be save as part of the information of all the table.
 * Forthly   , to split the table part , you can get two part of them , and one is header part which alway is the toppest and leftest line on a table,
 *             and another part is data part .
 * Fifthly   , show the information you had make and you also can go to next step straightly .
 * Sixthly   , give some rule or some adjustment to make the programe more smart to process you file .
 * Seventhly , begin to deal with files .
 */
