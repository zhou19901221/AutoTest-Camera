namespace 自动测试
{
    partial class IO模块控件
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.输入组 = new System.Windows.Forms.GroupBox();
            this.输出组 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // 输入组
            // 
            this.输入组.Location = new System.Drawing.Point(20, 20);
            this.输入组.Name = "输入组";
            this.输入组.Size = new System.Drawing.Size(550, 550);
            this.输入组.TabIndex = 0;
            this.输入组.TabStop = false;
            this.输入组.Text = "IO输入 (NO:1)";
            // 
            // 输出组
            // 
            this.输出组.Location = new System.Drawing.Point(600, 20);
            this.输出组.Name = "输出组";
            this.输出组.Size = new System.Drawing.Size(550, 550);
            this.输出组.TabIndex = 1;
            this.输出组.TabStop = false;
            this.输出组.Text = "IO输出 (NO:5)";
            // 
            // IO模块控件
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.输出组);
            this.Controls.Add(this.输入组);
            this.Name = "IO模块控件";
            this.Size = new System.Drawing.Size(1200, 600);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.GroupBox 输入组;
        private System.Windows.Forms.GroupBox 输出组;
    }
}