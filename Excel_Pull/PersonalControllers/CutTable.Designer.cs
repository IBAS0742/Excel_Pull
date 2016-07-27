namespace Excel_Pull.PersonalControllers
{
    partial class CutTable
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CutTable));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.autoColumnWidthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showMoreTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showMoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asFirstRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asLastRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asFirstColumnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asLastColumnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exampleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resolveATableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(10, 10);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(896, 439);
            this.dataGridView1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoColumnWidthToolStripMenuItem,
            this.showMoreTableToolStripMenuItem,
            this.cutTableToolStripMenuItem,
            this.resolveATableToolStripMenuItem,
            this.showInfoToolStripMenuItem,
            this.exampleToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(190, 180);
            // 
            // autoColumnWidthToolStripMenuItem
            // 
            this.autoColumnWidthToolStripMenuItem.Name = "autoColumnWidthToolStripMenuItem";
            this.autoColumnWidthToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.autoColumnWidthToolStripMenuItem.Text = "Auto Column Width";
            this.autoColumnWidthToolStripMenuItem.Click += new System.EventHandler(this.autoColumnWidthToolStripMenuItem_Click);
            // 
            // showMoreTableToolStripMenuItem
            // 
            this.showMoreTableToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showMoreToolStripMenuItem,
            this.showAllToolStripMenuItem,
            this.reloadTableToolStripMenuItem});
            this.showMoreTableToolStripMenuItem.Name = "showMoreTableToolStripMenuItem";
            this.showMoreTableToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.showMoreTableToolStripMenuItem.Text = "Show More Table";
            // 
            // showMoreToolStripMenuItem
            // 
            this.showMoreToolStripMenuItem.Name = "showMoreToolStripMenuItem";
            this.showMoreToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.showMoreToolStripMenuItem.Text = "Show More ...";
            this.showMoreToolStripMenuItem.Click += new System.EventHandler(this.showMoreToolStripMenuItem_Click);
            // 
            // showAllToolStripMenuItem
            // 
            this.showAllToolStripMenuItem.Name = "showAllToolStripMenuItem";
            this.showAllToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.showAllToolStripMenuItem.Text = "Show All";
            this.showAllToolStripMenuItem.Click += new System.EventHandler(this.showAllToolStripMenuItem_Click);
            // 
            // reloadTableToolStripMenuItem
            // 
            this.reloadTableToolStripMenuItem.Name = "reloadTableToolStripMenuItem";
            this.reloadTableToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.reloadTableToolStripMenuItem.Text = "Reload Table";
            this.reloadTableToolStripMenuItem.Click += new System.EventHandler(this.reloadTableToolStripMenuItem_Click);
            // 
            // cutTableToolStripMenuItem
            // 
            this.cutTableToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asFirstRowToolStripMenuItem,
            this.asLastRowToolStripMenuItem,
            this.asFirstColumnToolStripMenuItem,
            this.asLastColumnToolStripMenuItem,
            this.showSelectedToolStripMenuItem,
            this.cutToolStripMenuItem});
            this.cutTableToolStripMenuItem.Name = "cutTableToolStripMenuItem";
            this.cutTableToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.cutTableToolStripMenuItem.Text = "CutTable";
            // 
            // asFirstRowToolStripMenuItem
            // 
            this.asFirstRowToolStripMenuItem.Name = "asFirstRowToolStripMenuItem";
            this.asFirstRowToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.asFirstRowToolStripMenuItem.Text = "As First Row";
            this.asFirstRowToolStripMenuItem.Click += new System.EventHandler(this.asFirstRowToolStripMenuItem_Click);
            // 
            // asLastRowToolStripMenuItem
            // 
            this.asLastRowToolStripMenuItem.Name = "asLastRowToolStripMenuItem";
            this.asLastRowToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.asLastRowToolStripMenuItem.Text = "As Last Row";
            this.asLastRowToolStripMenuItem.Click += new System.EventHandler(this.asLastRowToolStripMenuItem_Click);
            // 
            // asFirstColumnToolStripMenuItem
            // 
            this.asFirstColumnToolStripMenuItem.Name = "asFirstColumnToolStripMenuItem";
            this.asFirstColumnToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.asFirstColumnToolStripMenuItem.Text = "As First Column";
            this.asFirstColumnToolStripMenuItem.Click += new System.EventHandler(this.asFirstColumnToolStripMenuItem_Click);
            // 
            // asLastColumnToolStripMenuItem
            // 
            this.asLastColumnToolStripMenuItem.Name = "asLastColumnToolStripMenuItem";
            this.asLastColumnToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.asLastColumnToolStripMenuItem.Text = "As Last Column";
            this.asLastColumnToolStripMenuItem.Click += new System.EventHandler(this.asLastColumnToolStripMenuItem_Click);
            // 
            // showSelectedToolStripMenuItem
            // 
            this.showSelectedToolStripMenuItem.Name = "showSelectedToolStripMenuItem";
            this.showSelectedToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.showSelectedToolStripMenuItem.Text = "Show Selected";
            this.showSelectedToolStripMenuItem.Click += new System.EventHandler(this.showSelectedToolStripMenuItem_Click);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // showInfoToolStripMenuItem
            // 
            this.showInfoToolStripMenuItem.Name = "showInfoToolStripMenuItem";
            this.showInfoToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.showInfoToolStripMenuItem.Text = "ShowInfo";
            this.showInfoToolStripMenuItem.Click += new System.EventHandler(this.showInfoToolStripMenuItem_Click);
            // 
            // exampleToolStripMenuItem
            // 
            this.exampleToolStripMenuItem.Name = "exampleToolStripMenuItem";
            this.exampleToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.exampleToolStripMenuItem.Text = "Example";
            this.exampleToolStripMenuItem.Click += new System.EventHandler(this.exampleToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // resolveATableToolStripMenuItem
            // 
            this.resolveATableToolStripMenuItem.Name = "resolveATableToolStripMenuItem";
            this.resolveATableToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.resolveATableToolStripMenuItem.Text = "Resolve A Table";
            // 
            // CutTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(917, 457);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CutTable";
            this.Text = "CutTable";
            this.Load += new System.EventHandler(this.CutTable_Load);
            this.Shown += new System.EventHandler(this.CutTable_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asFirstRowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asLastRowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showMoreTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showMoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exampleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asFirstColumnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asLastColumnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoColumnWidthToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resolveATableToolStripMenuItem;
    }
}