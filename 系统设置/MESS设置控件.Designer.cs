namespace 自动测试
{
    partial class MESS设置控件
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
            MESS网络组 = new GroupBox();
            MESS功能开启框 = new CheckBox();
            服务器组 = new GroupBox();
            端口框 = new NumericUpDown();
            端口标签 = new Label();
            IP地址框 = new TextBox();
            IP地址标签 = new Label();
            条码枪组 = new GroupBox();
            端口8框 = new NumericUpDown();
            端口8标签 = new Label();
            端口7框 = new NumericUpDown();
            端口7标签 = new Label();
            端口6框 = new NumericUpDown();
            端口6标签 = new Label();
            端口5框 = new NumericUpDown();
            端口5标签 = new Label();
            端口4框 = new NumericUpDown();
            端口4标签 = new Label();
            端口3框 = new NumericUpDown();
            端口3标签 = new Label();
            端口2框 = new NumericUpDown();
            端口2标签 = new Label();
            端口1框 = new NumericUpDown();
            端口1标签 = new Label();
            波特率框 = new NumericUpDown();
            波特率标签 = new Label();
            条码枪数量框 = new NumericUpDown();
            条码枪数量标签 = new Label();
            条码枪类型框 = new ComboBox();
            条码枪类型标签 = new Label();
            MESS网络组.SuspendLayout();
            服务器组.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)端口框).BeginInit();
            条码枪组.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)端口8框).BeginInit();
            ((System.ComponentModel.ISupportInitialize)端口7框).BeginInit();
            ((System.ComponentModel.ISupportInitialize)端口6框).BeginInit();
            ((System.ComponentModel.ISupportInitialize)端口5框).BeginInit();
            ((System.ComponentModel.ISupportInitialize)端口4框).BeginInit();
            ((System.ComponentModel.ISupportInitialize)端口3框).BeginInit();
            ((System.ComponentModel.ISupportInitialize)端口2框).BeginInit();
            ((System.ComponentModel.ISupportInitialize)端口1框).BeginInit();
            ((System.ComponentModel.ISupportInitialize)波特率框).BeginInit();
            ((System.ComponentModel.ISupportInitialize)条码枪数量框).BeginInit();
            SuspendLayout();
            // 
            // MESS网络组
            // 
            MESS网络组.Controls.Add(MESS功能开启框);
            MESS网络组.Location = new Point(20, 20);
            MESS网络组.Name = "MESS网络组";
            MESS网络组.Size = new Size(827, 60);
            MESS网络组.TabIndex = 0;
            MESS网络组.TabStop = false;
            MESS网络组.Text = "MESS网络设置";
            // 
            // MESS功能开启框
            // 
            MESS功能开启框.AutoSize = true;
            MESS功能开启框.Location = new Point(20, 25);
            MESS功能开启框.Name = "MESS功能开启框";
            MESS功能开启框.Size = new Size(108, 21);
            MESS功能开启框.TabIndex = 0;
            MESS功能开启框.Text = "MESS功能开启";
            MESS功能开启框.UseVisualStyleBackColor = true;
            // 
            // 服务器组
            // 
            服务器组.Controls.Add(端口框);
            服务器组.Controls.Add(端口标签);
            服务器组.Controls.Add(IP地址框);
            服务器组.Controls.Add(IP地址标签);
            服务器组.Location = new Point(20, 90);
            服务器组.Name = "服务器组";
            服务器组.Size = new Size(827, 80);
            服务器组.TabIndex = 1;
            服务器组.TabStop = false;
            服务器组.Text = "服务器设置";
            // 
            // 端口框
            // 
            端口框.Location = new Point(100, 52);
            端口框.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            端口框.Name = "端口框";
            端口框.Size = new Size(80, 23);
            端口框.TabIndex = 3;
            端口框.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            // 
            // 端口标签
            // 
            端口标签.AutoSize = true;
            端口标签.Location = new Point(20, 55);
            端口标签.Name = "端口标签";
            端口标签.Size = new Size(44, 17);
            端口标签.TabIndex = 2;
            端口标签.Text = "端口：";
            // 
            // IP地址框
            // 
            IP地址框.Location = new Point(100, 27);
            IP地址框.Name = "IP地址框";
            IP地址框.Size = new Size(200, 23);
            IP地址框.TabIndex = 1;
            IP地址框.Text = "192.168.2.100";
            // 
            // IP地址标签
            // 
            IP地址标签.AutoSize = true;
            IP地址标签.Location = new Point(20, 30);
            IP地址标签.Name = "IP地址标签";
            IP地址标签.Size = new Size(55, 17);
            IP地址标签.TabIndex = 0;
            IP地址标签.Text = "IP地址：";
            // 
            // 条码枪组
            // 
            条码枪组.Controls.Add(端口8框);
            条码枪组.Controls.Add(端口8标签);
            条码枪组.Controls.Add(端口7框);
            条码枪组.Controls.Add(端口7标签);
            条码枪组.Controls.Add(端口6框);
            条码枪组.Controls.Add(端口6标签);
            条码枪组.Controls.Add(端口5框);
            条码枪组.Controls.Add(端口5标签);
            条码枪组.Controls.Add(端口4框);
            条码枪组.Controls.Add(端口4标签);
            条码枪组.Controls.Add(端口3框);
            条码枪组.Controls.Add(端口3标签);
            条码枪组.Controls.Add(端口2框);
            条码枪组.Controls.Add(端口2标签);
            条码枪组.Controls.Add(端口1框);
            条码枪组.Controls.Add(端口1标签);
            条码枪组.Controls.Add(波特率框);
            条码枪组.Controls.Add(波特率标签);
            条码枪组.Controls.Add(条码枪数量框);
            条码枪组.Controls.Add(条码枪数量标签);
            条码枪组.Controls.Add(条码枪类型框);
            条码枪组.Controls.Add(条码枪类型标签);
            条码枪组.Location = new Point(20, 180);
            条码枪组.Name = "条码枪组";
            条码枪组.Size = new Size(827, 200);
            条码枪组.TabIndex = 2;
            条码枪组.TabStop = false;
            条码枪组.Text = "条码枪设置";
            // 
            // 端口8框
            // 
            端口8框.Location = new Point(530, 112);
            端口8框.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            端口8框.Name = "端口8框";
            端口8框.Size = new Size(80, 23);
            端口8框.TabIndex = 21;
            端口8框.Value = new decimal(new int[] { 9, 0, 0, 0 });
            // 
            // 端口8标签
            // 
            端口8标签.AutoSize = true;
            端口8标签.Location = new Point(470, 115);
            端口8标签.Name = "端口8标签";
            端口8标签.Size = new Size(51, 17);
            端口8标签.TabIndex = 20;
            端口8标签.Text = "8端口：";
            // 
            // 端口7框
            // 
            端口7框.Location = new Point(380, 112);
            端口7框.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            端口7框.Name = "端口7框";
            端口7框.Size = new Size(80, 23);
            端口7框.TabIndex = 19;
            端口7框.Value = new decimal(new int[] { 8, 0, 0, 0 });
            // 
            // 端口7标签
            // 
            端口7标签.AutoSize = true;
            端口7标签.Location = new Point(320, 115);
            端口7标签.Name = "端口7标签";
            端口7标签.Size = new Size(51, 17);
            端口7标签.TabIndex = 18;
            端口7标签.Text = "7端口：";
            // 
            // 端口6框
            // 
            端口6框.Location = new Point(230, 112);
            端口6框.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            端口6框.Name = "端口6框";
            端口6框.Size = new Size(80, 23);
            端口6框.TabIndex = 17;
            端口6框.Value = new decimal(new int[] { 7, 0, 0, 0 });
            // 
            // 端口6标签
            // 
            端口6标签.AutoSize = true;
            端口6标签.Location = new Point(170, 115);
            端口6标签.Name = "端口6标签";
            端口6标签.Size = new Size(51, 17);
            端口6标签.TabIndex = 16;
            端口6标签.Text = "6端口：";
            // 
            // 端口5框
            // 
            端口5框.Location = new Point(80, 112);
            端口5框.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            端口5框.Name = "端口5框";
            端口5框.Size = new Size(80, 23);
            端口5框.TabIndex = 15;
            端口5框.Value = new decimal(new int[] { 6, 0, 0, 0 });
            // 
            // 端口5标签
            // 
            端口5标签.AutoSize = true;
            端口5标签.Location = new Point(20, 115);
            端口5标签.Name = "端口5标签";
            端口5标签.Size = new Size(51, 17);
            端口5标签.TabIndex = 14;
            端口5标签.Text = "5端口：";
            // 
            // 端口4框
            // 
            端口4框.Location = new Point(530, 82);
            端口4框.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            端口4框.Name = "端口4框";
            端口4框.Size = new Size(80, 23);
            端口4框.TabIndex = 13;
            端口4框.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // 端口4标签
            // 
            端口4标签.AutoSize = true;
            端口4标签.Location = new Point(470, 85);
            端口4标签.Name = "端口4标签";
            端口4标签.Size = new Size(51, 17);
            端口4标签.TabIndex = 12;
            端口4标签.Text = "4端口：";
            // 
            // 端口3框
            // 
            端口3框.Location = new Point(380, 82);
            端口3框.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            端口3框.Name = "端口3框";
            端口3框.Size = new Size(80, 23);
            端口3框.TabIndex = 11;
            端口3框.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // 端口3标签
            // 
            端口3标签.AutoSize = true;
            端口3标签.Location = new Point(320, 85);
            端口3标签.Name = "端口3标签";
            端口3标签.Size = new Size(51, 17);
            端口3标签.TabIndex = 10;
            端口3标签.Text = "3端口：";
            // 
            // 端口2框
            // 
            端口2框.Location = new Point(230, 82);
            端口2框.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            端口2框.Name = "端口2框";
            端口2框.Size = new Size(80, 23);
            端口2框.TabIndex = 9;
            端口2框.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // 端口2标签
            // 
            端口2标签.AutoSize = true;
            端口2标签.Location = new Point(170, 85);
            端口2标签.Name = "端口2标签";
            端口2标签.Size = new Size(51, 17);
            端口2标签.TabIndex = 8;
            端口2标签.Text = "2端口：";
            // 
            // 端口1框
            // 
            端口1框.Location = new Point(80, 82);
            端口1框.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            端口1框.Name = "端口1框";
            端口1框.Size = new Size(80, 23);
            端口1框.TabIndex = 7;
            端口1框.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // 端口1标签
            // 
            端口1标签.AutoSize = true;
            端口1标签.Location = new Point(20, 85);
            端口1标签.Name = "端口1标签";
            端口1标签.Size = new Size(51, 17);
            端口1标签.TabIndex = 6;
            端口1标签.Text = "1端口：";
            // 
            // 波特率框
            // 
            波特率框.Location = new Point(100, 52);
            波特率框.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            波特率框.Name = "波特率框";
            波特率框.Size = new Size(80, 23);
            波特率框.TabIndex = 5;
            波特率框.Value = new decimal(new int[] { 115200, 0, 0, 0 });
            // 
            // 波特率标签
            // 
            波特率标签.AutoSize = true;
            波特率标签.Location = new Point(20, 55);
            波特率标签.Name = "波特率标签";
            波特率标签.Size = new Size(56, 17);
            波特率标签.TabIndex = 4;
            波特率标签.Text = "波特率：";
            // 
            // 条码枪数量框
            // 
            条码枪数量框.Location = new Point(370, 22);
            条码枪数量框.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            条码枪数量框.Name = "条码枪数量框";
            条码枪数量框.Size = new Size(80, 23);
            条码枪数量框.TabIndex = 3;
            // 
            // 条码枪数量标签
            // 
            条码枪数量标签.AutoSize = true;
            条码枪数量标签.Location = new Point(250, 25);
            条码枪数量标签.Name = "条码枪数量标签";
            条码枪数量标签.Size = new Size(80, 17);
            条码枪数量标签.TabIndex = 2;
            条码枪数量标签.Text = "条码枪数量：";
            // 
            // 条码枪类型框
            // 
            条码枪类型框.DropDownStyle = ComboBoxStyle.DropDownList;
            条码枪类型框.FormattingEnabled = true;
            条码枪类型框.Items.AddRange(new object[] { "USB", "串口" });
            条码枪类型框.Location = new Point(120, 22);
            条码枪类型框.Name = "条码枪类型框";
            条码枪类型框.Size = new Size(100, 25);
            条码枪类型框.TabIndex = 1;
            // 
            // 条码枪类型标签
            // 
            条码枪类型标签.AutoSize = true;
            条码枪类型标签.Location = new Point(20, 25);
            条码枪类型标签.Name = "条码枪类型标签";
            条码枪类型标签.Size = new Size(80, 17);
            条码枪类型标签.TabIndex = 0;
            条码枪类型标签.Text = "条码枪类型：";
            // 
            // MESS设置控件
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(条码枪组);
            Controls.Add(服务器组);
            Controls.Add(MESS网络组);
            Name = "MESS设置控件";
            Size = new Size(1200, 500);
            MESS网络组.ResumeLayout(false);
            MESS网络组.PerformLayout();
            服务器组.ResumeLayout(false);
            服务器组.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)端口框).EndInit();
            条码枪组.ResumeLayout(false);
            条码枪组.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)端口8框).EndInit();
            ((System.ComponentModel.ISupportInitialize)端口7框).EndInit();
            ((System.ComponentModel.ISupportInitialize)端口6框).EndInit();
            ((System.ComponentModel.ISupportInitialize)端口5框).EndInit();
            ((System.ComponentModel.ISupportInitialize)端口4框).EndInit();
            ((System.ComponentModel.ISupportInitialize)端口3框).EndInit();
            ((System.ComponentModel.ISupportInitialize)端口2框).EndInit();
            ((System.ComponentModel.ISupportInitialize)端口1框).EndInit();
            ((System.ComponentModel.ISupportInitialize)波特率框).EndInit();
            ((System.ComponentModel.ISupportInitialize)条码枪数量框).EndInit();
            ResumeLayout(false);

        }

        private System.Windows.Forms.GroupBox MESS网络组;
        private System.Windows.Forms.CheckBox MESS功能开启框;
        private System.Windows.Forms.GroupBox 服务器组;
        private System.Windows.Forms.NumericUpDown 端口框;
        private System.Windows.Forms.Label 端口标签;
        private System.Windows.Forms.TextBox IP地址框;
        private System.Windows.Forms.Label IP地址标签;
        private System.Windows.Forms.GroupBox 条码枪组;
        private System.Windows.Forms.NumericUpDown 端口8框;
        private System.Windows.Forms.Label 端口8标签;
        private System.Windows.Forms.NumericUpDown 端口7框;
        private System.Windows.Forms.Label 端口7标签;
        private System.Windows.Forms.NumericUpDown 端口6框;
        private System.Windows.Forms.Label 端口6标签;
        private System.Windows.Forms.NumericUpDown 端口5框;
        private System.Windows.Forms.Label 端口5标签;
        private System.Windows.Forms.NumericUpDown 端口4框;
        private System.Windows.Forms.Label 端口4标签;
        private System.Windows.Forms.NumericUpDown 端口3框;
        private System.Windows.Forms.Label 端口3标签;
        private System.Windows.Forms.NumericUpDown 端口2框;
        private System.Windows.Forms.Label 端口2标签;
        private System.Windows.Forms.NumericUpDown 端口1框;
        private System.Windows.Forms.Label 端口1标签;
        private System.Windows.Forms.NumericUpDown 波特率框;
        private System.Windows.Forms.Label 波特率标签;
        private System.Windows.Forms.NumericUpDown 条码枪数量框;
        private System.Windows.Forms.Label 条码枪数量标签;
        private System.Windows.Forms.ComboBox 条码枪类型框;
        private System.Windows.Forms.Label 条码枪类型标签;
    }
}