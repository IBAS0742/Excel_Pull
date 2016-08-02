namespace Excel_Pull.PersonalControllers
{
    partial class ShowResult
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowResult));
            this.Sheet_Panel = new System.Windows.Forms.Panel();
            this.R_Sheet_Two = new System.Windows.Forms.RadioButton();
            this.R_Sheet_One = new System.Windows.Forms.RadioButton();
            this.Table_Panel = new System.Windows.Forms.Panel();
            this.R_Table_Two = new System.Windows.Forms.RadioButton();
            this.R_Table_One = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Exit_Font = new System.Windows.Forms.Label();
            this.Sheet_Panel.SuspendLayout();
            this.Table_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Sheet_Panel
            // 
            this.Sheet_Panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Sheet_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Sheet_Panel.Controls.Add(this.R_Sheet_Two);
            this.Sheet_Panel.Controls.Add(this.R_Sheet_One);
            this.Sheet_Panel.Location = new System.Drawing.Point(13, 60);
            this.Sheet_Panel.Name = "Sheet_Panel";
            this.Sheet_Panel.Size = new System.Drawing.Size(1158, 115);
            this.Sheet_Panel.TabIndex = 0;
            // 
            // R_Sheet_Two
            // 
            this.R_Sheet_Two.AutoSize = true;
            this.R_Sheet_Two.Location = new System.Drawing.Point(18, 75);
            this.R_Sheet_Two.Name = "R_Sheet_Two";
            this.R_Sheet_Two.Size = new System.Drawing.Size(14, 13);
            this.R_Sheet_Two.TabIndex = 1;
            this.R_Sheet_Two.TabStop = true;
            this.R_Sheet_Two.UseVisualStyleBackColor = true;
            // 
            // R_Sheet_One
            // 
            this.R_Sheet_One.AutoSize = true;
            this.R_Sheet_One.Location = new System.Drawing.Point(18, 25);
            this.R_Sheet_One.Name = "R_Sheet_One";
            this.R_Sheet_One.Size = new System.Drawing.Size(14, 13);
            this.R_Sheet_One.TabIndex = 0;
            this.R_Sheet_One.TabStop = true;
            this.R_Sheet_One.UseVisualStyleBackColor = true;
            // 
            // Table_Panel
            // 
            this.Table_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Table_Panel.Controls.Add(this.R_Table_Two);
            this.Table_Panel.Controls.Add(this.R_Table_One);
            this.Table_Panel.Location = new System.Drawing.Point(13, 202);
            this.Table_Panel.Name = "Table_Panel";
            this.Table_Panel.Size = new System.Drawing.Size(1158, 115);
            this.Table_Panel.TabIndex = 1;
            // 
            // R_Table_Two
            // 
            this.R_Table_Two.AutoSize = true;
            this.R_Table_Two.Location = new System.Drawing.Point(18, 72);
            this.R_Table_Two.Name = "R_Table_Two";
            this.R_Table_Two.Size = new System.Drawing.Size(14, 13);
            this.R_Table_Two.TabIndex = 1;
            this.R_Table_Two.TabStop = true;
            this.R_Table_Two.UseVisualStyleBackColor = true;
            // 
            // R_Table_One
            // 
            this.R_Table_One.AutoSize = true;
            this.R_Table_One.Location = new System.Drawing.Point(18, 24);
            this.R_Table_One.Name = "R_Table_One";
            this.R_Table_One.Size = new System.Drawing.Size(14, 13);
            this.R_Table_One.TabIndex = 0;
            this.R_Table_One.TabStop = true;
            this.R_Table_One.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(16, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sheet Level";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(16, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Table Level";
            // 
            // Exit_Font
            // 
            this.Exit_Font.AutoSize = true;
            this.Exit_Font.Font = new System.Drawing.Font("Lucida Fax", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit_Font.Location = new System.Drawing.Point(9, 320);
            this.Exit_Font.Name = "Exit_Font";
            this.Exit_Font.Size = new System.Drawing.Size(0, 23);
            this.Exit_Font.TabIndex = 4;
            this.Exit_Font.Visible = false;
            // 
            // ShowResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 352);
            this.Controls.Add(this.Exit_Font);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Table_Panel);
            this.Controls.Add(this.Sheet_Panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ShowResult";
            this.Text = "ShowResult";
            this.Load += new System.EventHandler(this.ShowResult_Load);
            this.Sheet_Panel.ResumeLayout(false);
            this.Sheet_Panel.PerformLayout();
            this.Table_Panel.ResumeLayout(false);
            this.Table_Panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Sheet_Panel;
        private System.Windows.Forms.RadioButton R_Sheet_Two;
        private System.Windows.Forms.RadioButton R_Sheet_One;
        private System.Windows.Forms.Panel Table_Panel;
        private System.Windows.Forms.RadioButton R_Table_One;
        private System.Windows.Forms.RadioButton R_Table_Two;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Exit_Font;
    }
}