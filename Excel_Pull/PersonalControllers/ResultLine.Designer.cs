namespace Excel_Pull.PersonalControllers
{
    partial class ResultLine
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.FontLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FontLabel
            // 
            this.FontLabel.AutoSize = true;
            this.FontLabel.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FontLabel.Location = new System.Drawing.Point(790, 57);
            this.FontLabel.Name = "FontLabel";
            this.FontLabel.Size = new System.Drawing.Size(0, 16);
            this.FontLabel.TabIndex = 0;
            // 
            // ResultLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.FontLabel);
            this.Name = "ResultLine";
            this.Size = new System.Drawing.Size(1047, 68);
            this.Load += new System.EventHandler(this.ResultLine_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FontLabel;
    }
}
