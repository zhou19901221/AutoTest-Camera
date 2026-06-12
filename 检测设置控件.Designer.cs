namespace 自动测试
{
    partial class 检测设置控件
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
            this.检测设置组 = new System.Windows.Forms.GroupBox();
            this.保存图像框 = new System.Windows.Forms.CheckBox();
            this.声音提示框 = new System.Windows.Forms.CheckBox();
            this.异常自动停止框 = new System.Windows.Forms.CheckBox();
            this.自动记录结果框 = new System.Windows.Forms.CheckBox();
            this.检测间隔单位标签 = new System.Windows.Forms.Label();
            this.检测间隔框 = new System.Windows.Forms.NumericUpDown();
            this.检测间隔标签 = new System.Windows.Forms.Label();
            this.检测次数框 = new System.Windows.Forms.NumericUpDown();
            this.检测次数标签 = new System.Windows.Forms.Label();
            this.检测模式框 = new System.Windows.Forms.ComboBox();
            this.检测模式标签 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.检测间隔框)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.检测次数框)).BeginInit();
            this.检测设置组.SuspendLayout();
            this.SuspendLayout();
            // 
            // 检测设置组
            // 
            this.检测设置组.Controls.Add(this.保存图像框);
            this.检测设置组.Controls.Add(this.声音提示框);
            this.检测设置组.Controls.Add(this.异常自动停止框);
            this.检测设置组.Controls.Add(this.自动记录结果框);
            this.检测设置组.Controls.Add(this.检测间隔单位标签);
            this.检测设置组.Controls.Add(this.检测间隔框);
            this.检测设置组.Controls.Add(this.检测间隔标签);
            this.检测设置组.Controls.Add(this.检测次数框);
            this.检测设置组.Controls.Add(this.检测次数标签);
            this.检测设置组.Controls.Add(this.检测模式框);
            this.检测设置组.Controls.Add(this.检测模式标签);
            this.检测设置组.Location = new System.Drawing.Point(20, 20);
            this.检测设置组.Name = "检测设置组";
            this.检测设置组.Size = new System.Drawing.Size(700, 200);
            this.检测设置组.TabIndex = 0;
            this.检测设置组.TabStop = false;
            this.检测设置组.Text = "检测设置";
            // 
            // 检测模式标签
            // 
            this.检测模式标签.AutoSize = true;
            this.检测模式标签.Location = new System.Drawing.Point(20, 25);
            this.检测模式标签.Name = "检测模式标签";
            this.检测模式标签.Size = new System.Drawing.Size(68, 17);
            this.检测模式标签.TabIndex = 0;
            this.检测模式标签.Text = "检测模式：";
            // 
            // 检测模式框
            // 
            this.检测模式框.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.检测模式框.FormattingEnabled = true;
            this.检测模式框.Items.AddRange(new object[] {
            "自动检测",
            "手动检测",
            "半自动检测"});
            this.检测模式框.Location = new System.Drawing.Point(100, 22);
            this.检测模式框.Name = "检测模式框";
            this.检测模式框.Size = new System.Drawing.Size(150, 23);
            this.检测模式框.TabIndex = 1;
            // 
            // 检测次数标签
            // 
            this.检测次数标签.AutoSize = true;
            this.检测次数标签.Location = new System.Drawing.Point(300, 25);
            this.检测次数标签.Name = "检测次数标签";
            this.检测次数标签.Size = new System.Drawing.Size(68, 17);
            this.检测次数标签.TabIndex = 2;
            this.检测次数标签.Text = "检测次数：";
            // 
            // 检测次数框
            // 
            this.检测次数框.Location = new System.Drawing.Point(380, 22);
            this.检测次数框.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.检测次数框.Name = "检测次数框";
            this.检测次数框.Size = new System.Drawing.Size(80, 23);
            this.检测次数框.TabIndex = 3;
            this.检测次数框.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // 检测间隔标签
            // 
            this.检测间隔标签.AutoSize = true;
            this.检测间隔标签.Location = new System.Drawing.Point(500, 25);
            this.检测间隔标签.Name = "检测间隔标签";
            this.检测间隔标签.Size = new System.Drawing.Size(68, 17);
            this.检测间隔标签.TabIndex = 4;
            this.检测间隔标签.Text = "检测间隔：";
            // 
            // 检测间隔框
            // 
            this.检测间隔框.Location = new System.Drawing.Point(580, 22);
            this.检测间隔框.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.检测间隔框.Name = "检测间隔框";
            this.检测间隔框.Size = new System.Drawing.Size(80, 23);
            this.检测间隔框.TabIndex = 5;
            this.检测间隔框.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // 检测间隔单位标签
            // 
            this.检测间隔单位标签.AutoSize = true;
            this.检测间隔单位标签.Location = new System.Drawing.Point(680, 25);
            this.检测间隔单位标签.Name = "检测间隔单位标签";
            this.检测间隔单位标签.Size = new System.Drawing.Size(20, 17);
            this.检测间隔单位标签.TabIndex = 6;
            this.检测间隔单位标签.Text = "ms";
            // 
            // 自动记录结果框
            // 
            this.自动记录结果框.AutoSize = true;
            this.自动记录结果框.Checked = true;
            this.自动记录结果框.CheckState = System.Windows.Forms.CheckState.Checked;
            this.自动记录结果框.Location = new System.Drawing.Point(20, 60);
            this.自动记录结果框.Name = "自动记录结果框";
            this.自动记录结果框.Size = new System.Drawing.Size(116, 21);
            this.自动记录结果框.TabIndex = 7;
            this.自动记录结果框.Text = "自动记录结果";
            this.自动记录结果框.UseVisualStyleBackColor = true;
            // 
            // 异常自动停止框
            // 
            this.异常自动停止框.AutoSize = true;
            this.异常自动停止框.Checked = true;
            this.异常自动停止框.CheckState = System.Windows.Forms.CheckState.Checked;
            this.异常自动停止框.Location = new System.Drawing.Point(200, 60);
            this.异常自动停止框.Name = "异常自动停止框";
            this.异常自动停止框.Size = new System.Drawing.Size(116, 21);
            this.异常自动停止框.TabIndex = 8;
            this.异常自动停止框.Text = "异常自动停止";
            this.异常自动停止框.UseVisualStyleBackColor = true;
            // 
            // 声音提示框
            // 
            this.声音提示框.AutoSize = true;
            this.声音提示框.Location = new System.Drawing.Point(380, 60);
            this.声音提示框.Name = "声音提示框";
            this.声音提示框.Size = new System.Drawing.Size(80, 21);
            this.声音提示框.TabIndex = 9;
            this.声音提示框.Text = "声音提示";
            this.声音提示框.UseVisualStyleBackColor = true;
            // 
            // 保存图像框
            // 
            this.保存图像框.AutoSize = true;
            this.保存图像框.Checked = true;
            this.保存图像框.CheckState = System.Windows.Forms.CheckState.Checked;
            this.保存图像框.Location = new System.Drawing.Point(540, 60);
            this.保存图像框.Name = "保存图像框";
            this.保存图像框.Size = new System.Drawing.Size(80, 21);
            this.保存图像框.TabIndex = 10;
            this.保存图像框.Text = "保存图像";
            this.保存图像框.UseVisualStyleBackColor = true;
            // 
            // 检测设置控件
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.检测设置组);
            this.Name = "检测设置控件";
            this.Size = new System.Drawing.Size(1200, 500);
            ((System.ComponentModel.ISupportInitialize)(this.检测间隔框)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.检测次数框)).EndInit();
            this.检测设置组.ResumeLayout(false);
            this.检测设置组.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.GroupBox 检测设置组;
        private System.Windows.Forms.CheckBox 保存图像框;
        private System.Windows.Forms.CheckBox 声音提示框;
        private System.Windows.Forms.CheckBox 异常自动停止框;
        private System.Windows.Forms.CheckBox 自动记录结果框;
        private System.Windows.Forms.Label 检测间隔单位标签;
        private System.Windows.Forms.NumericUpDown 检测间隔框;
        private System.Windows.Forms.Label 检测间隔标签;
        private System.Windows.Forms.NumericUpDown 检测次数框;
        private System.Windows.Forms.Label 检测次数标签;
        private System.Windows.Forms.ComboBox 检测模式框;
        private System.Windows.Forms.Label 检测模式标签;
    }
}