namespace 自动测试
{
    partial class 电流模块控件
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
            this.采集组 = new System.Windows.Forms.GroupBox();
            this.输出组 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // 采集组
            // 
            this.采集组.Location = new System.Drawing.Point(20, 20);
            this.采集组.Name = "采集组";
            this.采集组.Size = new System.Drawing.Size(550, 550);
            this.采集组.TabIndex = 0;
            this.采集组.TabStop = false;
            this.采集组.Text = "电流采集 (NO:20)";
            // 
            // 输出组
            // 
            this.输出组.Location = new System.Drawing.Point(600, 20);
            this.输出组.Name = "输出组";
            this.输出组.Size = new System.Drawing.Size(550, 550);
            this.输出组.TabIndex = 1;
            this.输出组.TabStop = false;
            this.输出组.Text = "电流输出 (NO:70)";
            // 
            // 电流模块控件
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.输出组);
            this.Controls.Add(this.采集组);
            this.Name = "电流模块控件";
            this.Size = new System.Drawing.Size(1200, 600);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.GroupBox 采集组;
        private System.Windows.Forms.GroupBox 输出组;
    }
}