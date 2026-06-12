namespace 自动测试
{
    partial class 平台视觉控件
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
            this.X轴组 = new System.Windows.Forms.GroupBox();
            this.Y轴组 = new System.Windows.Forms.GroupBox();
            this.相机组 = new System.Windows.Forms.GroupBox();
            this.平台组 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // X轴组
            // 
            this.X轴组.Location = new System.Drawing.Point(20, 20);
            this.X轴组.Name = "X轴组";
            this.X轴组.Size = new System.Drawing.Size(300, 280);
            this.X轴组.TabIndex = 0;
            this.X轴组.TabStop = false;
            this.X轴组.Text = "X轴马达设置";
            // 
            // Y轴组
            // 
            this.Y轴组.Location = new System.Drawing.Point(340, 20);
            this.Y轴组.Name = "Y轴组";
            this.Y轴组.Size = new System.Drawing.Size(300, 280);
            this.Y轴组.TabIndex = 1;
            this.Y轴组.TabStop = false;
            this.Y轴组.Text = "Y轴马达设置";
            // 
            // 相机组
            // 
            this.相机组.Location = new System.Drawing.Point(660, 20);
            this.相机组.Name = "相机组";
            this.相机组.Size = new System.Drawing.Size(500, 350);
            this.相机组.TabIndex = 2;
            this.相机组.TabStop = false;
            this.相机组.Text = "工业相机分辨率设置";
            // 
            // 平台组
            // 
            this.平台组.Location = new System.Drawing.Point(20, 320);
            this.平台组.Name = "平台组";
            this.平台组.Size = new System.Drawing.Size(600, 120);
            this.平台组.TabIndex = 3;
            this.平台组.TabStop = false;
            this.平台组.Text = "平台与工作点信息";
            // 
            // 平台视觉控件
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.平台组);
            this.Controls.Add(this.相机组);
            this.Controls.Add(this.Y轴组);
            this.Controls.Add(this.X轴组);
            this.Name = "平台视觉控件";
            this.Size = new System.Drawing.Size(1200, 500);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.GroupBox X轴组;
        private System.Windows.Forms.GroupBox Y轴组;
        private System.Windows.Forms.GroupBox 相机组;
        private System.Windows.Forms.GroupBox 平台组;
    }
}