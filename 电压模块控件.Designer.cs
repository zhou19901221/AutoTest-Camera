namespace 自动测试
{
    partial class 电压模块控件
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
            this.基础组 = new System.Windows.Forms.GroupBox();
            this.采集组 = new System.Windows.Forms.GroupBox();
            this.输出组 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // 基础组
            // 
            this.基础组.Location = new System.Drawing.Point(20, 20);
            this.基础组.Name = "基础组";
            this.基础组.Size = new System.Drawing.Size(700, 200);
            this.基础组.TabIndex = 0;
            this.基础组.TabStop = false;
            this.基础组.Text = "电压模块基础设置";
            // 
            // 采集组
            // 
            this.采集组.Location = new System.Drawing.Point(20, 230);
            this.采集组.Name = "采集组";
            this.采集组.Size = new System.Drawing.Size(1140, 350);
            this.采集组.TabIndex = 1;
            this.采集组.TabStop = false;
            this.采集组.Text = "电压采集 (NO:10)";
            // 
            // 输出组
            // 
            this.输出组.Location = new System.Drawing.Point(20, 590);
            this.输出组.Name = "输出组";
            this.输出组.Size = new System.Drawing.Size(1140, 350);
            this.输出组.TabIndex = 2;
            this.输出组.TabStop = false;
            this.输出组.Text = "电压输出 (NO:60)";
            // 
            // 电压模块控件
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.输出组);
            this.Controls.Add(this.采集组);
            this.Controls.Add(this.基础组);
            this.Name = "电压模块控件";
            this.Size = new System.Drawing.Size(1200, 1000);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.GroupBox 基础组;
        private System.Windows.Forms.GroupBox 采集组;
        private System.Windows.Forms.GroupBox 输出组;
    }
}