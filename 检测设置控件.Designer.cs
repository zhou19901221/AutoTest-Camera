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
            检测设置组 = new GroupBox();
            numericUpDown3 = new NumericUpDown();
            label5 = new Label();
            检测间隔框 = new NumericUpDown();
            检测间隔标签 = new Label();
            检测次数框 = new NumericUpDown();
            检测次数标签 = new Label();
            groupBox3 = new GroupBox();
            numericUpDown4 = new NumericUpDown();
            label6 = new Label();
            numericUpDown7 = new NumericUpDown();
            label9 = new Label();
            检测设置组.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)检测间隔框).BeginInit();
            ((System.ComponentModel.ISupportInitialize)检测次数框).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown7).BeginInit();
            SuspendLayout();
            // 
            // 检测设置组
            // 
            检测设置组.Controls.Add(numericUpDown3);
            检测设置组.Controls.Add(label5);
            检测设置组.Controls.Add(检测间隔框);
            检测设置组.Controls.Add(检测间隔标签);
            检测设置组.Controls.Add(检测次数框);
            检测设置组.Controls.Add(检测次数标签);
            检测设置组.Location = new Point(20, 20);
            检测设置组.Name = "检测设置组";
            检测设置组.Size = new Size(230, 153);
            检测设置组.TabIndex = 0;
            检测设置组.TabStop = false;
            检测设置组.Text = "采样时间";
            // 
            // numericUpDown3
            // 
            numericUpDown3.Location = new Point(100, 106);
            numericUpDown3.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(80, 23);
            numericUpDown3.TabIndex = 5;
            numericUpDown3.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 109);
            label5.Name = "label5";
            label5.Size = new Size(68, 17);
            label5.TabIndex = 4;
            label5.Text = "检测间隔：";
            // 
            // 检测间隔框
            // 
            检测间隔框.Location = new Point(100, 68);
            检测间隔框.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            检测间隔框.Name = "检测间隔框";
            检测间隔框.Size = new Size(80, 23);
            检测间隔框.TabIndex = 5;
            检测间隔框.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // 检测间隔标签
            // 
            检测间隔标签.AutoSize = true;
            检测间隔标签.Location = new Point(20, 71);
            检测间隔标签.Name = "检测间隔标签";
            检测间隔标签.Size = new Size(68, 17);
            检测间隔标签.TabIndex = 4;
            检测间隔标签.Text = "检测间隔：";
            // 
            // 检测次数框
            // 
            检测次数框.Location = new Point(100, 25);
            检测次数框.Name = "检测次数框";
            检测次数框.Size = new Size(80, 23);
            检测次数框.TabIndex = 3;
            检测次数框.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // 检测次数标签
            // 
            检测次数标签.AutoSize = true;
            检测次数标签.Location = new Point(20, 28);
            检测次数标签.Name = "检测次数标签";
            检测次数标签.Size = new Size(68, 17);
            检测次数标签.TabIndex = 2;
            检测次数标签.Text = "检测次数：";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(numericUpDown4);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(numericUpDown7);
            groupBox3.Controls.Add(label9);
            groupBox3.Location = new Point(272, 20);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(309, 153);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "模块通讯异常设置";
            // 
            // numericUpDown4
            // 
            numericUpDown4.Location = new Point(100, 68);
            numericUpDown4.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDown4.Name = "numericUpDown4";
            numericUpDown4.Size = new Size(80, 23);
            numericUpDown4.TabIndex = 5;
            numericUpDown4.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(20, 71);
            label6.Name = "label6";
            label6.Size = new Size(68, 17);
            label6.TabIndex = 4;
            label6.Text = "检测间隔：";
            // 
            // numericUpDown7
            // 
            numericUpDown7.Location = new Point(100, 25);
            numericUpDown7.Name = "numericUpDown7";
            numericUpDown7.Size = new Size(80, 23);
            numericUpDown7.TabIndex = 3;
            numericUpDown7.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(20, 28);
            label9.Name = "label9";
            label9.Size = new Size(68, 17);
            label9.TabIndex = 2;
            label9.Text = "检测次数：";
            // 
            // 检测设置控件
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(groupBox3);
            Controls.Add(检测设置组);
            Name = "检测设置控件";
            Size = new Size(1200, 500);
            检测设置组.ResumeLayout(false);
            检测设置组.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ((System.ComponentModel.ISupportInitialize)检测间隔框).EndInit();
            ((System.ComponentModel.ISupportInitialize)检测次数框).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown7).EndInit();
            ResumeLayout(false);

        }

        private System.Windows.Forms.GroupBox 检测设置组;
        private System.Windows.Forms.NumericUpDown 检测间隔框;
        private System.Windows.Forms.Label 检测间隔标签;
        private System.Windows.Forms.NumericUpDown 检测次数框;
        private System.Windows.Forms.Label 检测次数标签;
        private NumericUpDown numericUpDown3;
        private Label label5;
        private GroupBox groupBox3;
        private NumericUpDown numericUpDown4;
        private Label label6;
        private NumericUpDown numericUpDown7;
        private Label label9;
    }
}