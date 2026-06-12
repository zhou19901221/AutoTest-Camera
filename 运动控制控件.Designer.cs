namespace 自动测试
{
    partial class 运动控制控件
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
            this.components = new System.ComponentModel.Container();
            this.主运组 = new System.Windows.Forms.GroupBox();
            this.调宽组 = new System.Windows.Forms.GroupBox();
            this.校正按钮 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // 主运组
            // 
            this.主运组.Location = new System.Drawing.Point(20, 20);
            this.主运组.Name = "主运组";
            this.主运组.Size = new System.Drawing.Size(400, 280);
            this.主运组.TabIndex = 0;
            this.主运组.TabStop = false;
            this.主运组.Text = "主运输入马达设置";
            // 
            // 调宽组
            // 
            this.调宽组.Location = new System.Drawing.Point(450, 20);
            this.调宽组.Name = "调宽组";
            this.调宽组.Size = new System.Drawing.Size(400, 350);
            this.调宽组.TabIndex = 1;
            this.调宽组.TabStop = false;
            this.调宽组.Text = "调宽马达设置";
            // 
            // 校正按钮
            // 
            this.校正按钮.Location = new System.Drawing.Point(450, 380);
            this.校正按钮.Name = "校正按钮";
            this.校正按钮.Size = new System.Drawing.Size(120, 30);
            this.校正按钮.TabIndex = 2;
            this.校正按钮.Text = "调宽参数校正";
            this.校正按钮.UseVisualStyleBackColor = true;
            // 
            // 运动控制控件
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.校正按钮);
            this.Controls.Add(this.调宽组);
            this.Controls.Add(this.主运组);
            this.Name = "运动控制控件";
            this.Size = new System.Drawing.Size(1200, 500);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.GroupBox 主运组;
        private System.Windows.Forms.GroupBox 调宽组;
        private System.Windows.Forms.Button 校正按钮;
    }
}