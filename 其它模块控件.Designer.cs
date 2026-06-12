namespace 自动测试
{
    partial class 其它模块控件
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
            this.功率组 = new System.Windows.Forms.GroupBox();
            this.通讯组 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // 功率组
            // 
            this.功率组.Location = new System.Drawing.Point(20, 20);
            this.功率组.Name = "功率组";
            this.功率组.Size = new System.Drawing.Size(550, 550);
            this.功率组.TabIndex = 0;
            this.功率组.TabStop = false;
            this.功率组.Text = "功率采集 (NO:30)";
            // 
            // 通讯组
            // 
            this.通讯组.Location = new System.Drawing.Point(600, 20);
            this.通讯组.Name = "通讯组";
            this.通讯组.Size = new System.Drawing.Size(300, 100);
            this.通讯组.TabIndex = 1;
            this.通讯组.TabStop = false;
            this.通讯组.Text = "通讯模块数";
            // 
            // 其它模块控件
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.通讯组);
            this.Controls.Add(this.功率组);
            this.Name = "其它模块控件";
            this.Size = new System.Drawing.Size(1200, 600);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.GroupBox 功率组;
        private System.Windows.Forms.GroupBox 通讯组;
    }
}