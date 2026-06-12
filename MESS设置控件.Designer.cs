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
            this.components = new System.ComponentModel.Container();
            this.MESS网络组 = new System.Windows.Forms.GroupBox();
            this.MESS功能开启框 = new System.Windows.Forms.CheckBox();
            this.服务器组 = new System.Windows.Forms.GroupBox();
            this.端口框 = new System.Windows.Forms.NumericUpDown();
            this.端口标签 = new System.Windows.Forms.Label();
            this.IP地址框 = new System.Windows.Forms.TextBox();
            this.IP地址标签 = new System.Windows.Forms.Label();
            this.条码枪组 = new System.Windows.Forms.GroupBox();
            this.端口8框 = new System.Windows.Forms.NumericUpDown();
            this.端口8标签 = new System.Windows.Forms.Label();
            this.端口7框 = new System.Windows.Forms.NumericUpDown();
            this.端口7标签 = new System.Windows.Forms.Label();
            this.端口6框 = new System.Windows.Forms.NumericUpDown();
            this.端口6标签 = new System.Windows.Forms.Label();
            this.端口5框 = new System.Windows.Forms.NumericUpDown();
            this.端口5标签 = new System.Windows.Forms.Label();
            this.端口4框 = new System.Windows.Forms.NumericUpDown();
            this.端口4标签 = new System.Windows.Forms.Label();
            this.端口3框 = new System.Windows.Forms.NumericUpDown();
            this.端口3标签 = new System.Windows.Forms.Label();
            this.端口2框 = new System.Windows.Forms.NumericUpDown();
            this.端口2标签 = new System.Windows.Forms.Label();
            this.端口1框 = new System.Windows.Forms.NumericUpDown();
            this.端口1标签 = new System.Windows.Forms.Label();
            this.波特率框 = new System.Windows.Forms.NumericUpDown();
            this.波特率标签 = new System.Windows.Forms.Label();
            this.条码枪数量框 = new System.Windows.Forms.NumericUpDown();
            this.条码枪数量标签 = new System.Windows.Forms.Label();
            this.条码枪类型框 = new System.Windows.Forms.ComboBox();
            this.条码枪类型标签 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.端口框)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.端口8框)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.端口7框)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.端口6框)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.端口5框)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.端口4框)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.端口3框)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.端口2框)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.端口1框)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.波特率框)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.条码枪数量框)).BeginInit();
            this.MESS网络组.SuspendLayout();
            this.服务器组.SuspendLayout();
            this.条码枪组.SuspendLayout();
            this.SuspendLayout();
            // 
            // MESS网络组
            // 
            this.MESS网络组.Controls.Add(this.MESS功能开启框);
            this.MESS网络组.Location = new System.Drawing.Point(20, 20);
            this.MESS网络组.Name = "MESS网络组";
            this.MESS网络组.Size = new System.Drawing.Size(300, 60);
            this.MESS网络组.TabIndex = 0;
            this.MESS网络组.TabStop = false;
            this.MESS网络组.Text = "MESS网络设置";
            // 
            // MESS功能开启框
            // 
            this.MESS功能开启框.AutoSize = true;
            this.MESS功能开启框.Location = new System.Drawing.Point(20, 25);
            this.MESS功能开启框.Name = "MESS功能开启框";
            this.MESS功能开启框.Size = new System.Drawing.Size(116, 21);
            this.MESS功能开启框.TabIndex = 0;
            this.MESS功能开启框.Text = "MESS功能开启";
            this.MESS功能开启框.UseVisualStyleBackColor = true;
            // 
            // 服务器组
            // 
            this.服务器组.Controls.Add(this.端口框);
            this.服务器组.Controls.Add(this.端口标签);
            this.服务器组.Controls.Add(this.IP地址框);
            this.服务器组.Controls.Add(this.IP地址标签);
            this.服务器组.Location = new System.Drawing.Point(20, 90);
            this.服务器组.Name = "服务器组";
            this.服务器组.Size = new System.Drawing.Size(400, 80);
            this.服务器组.TabIndex = 1;
            this.服务器组.TabStop = false;
            this.服务器组.Text = "服务器设置";
            // 
            // IP地址标签
            // 
            this.IP地址标签.AutoSize = true;
            this.IP地址标签.Location = new System.Drawing.Point(20, 30);
            this.IP地址标签.Name = "IP地址标签";
            this.IP地址标签.Size = new System.Drawing.Size(56, 17);
            this.IP地址标签.TabIndex = 0;
            this.IP地址标签.Text = "IP地址：";
            // 
            // IP地址框
            // 
            this.IP地址框.Location = new System.Drawing.Point(100, 27);
            this.IP地址框.Name = "IP地址框";
            this.IP地址框.Size = new System.Drawing.Size(200, 23);
            this.IP地址框.TabIndex = 1;
            this.IP地址框.Text = "192.168.2.100";
            // 
            // 端口标签
            // 
            this.端口标签.AutoSize = true;
            this.端口标签.Location = new System.Drawing.Point(20, 55);
            this.端口标签.Name = "端口标签";
            this.端口标签.Size = new System.Drawing.Size(44, 17);
            this.端口标签.TabIndex = 2;
            this.端口标签.Text = "端口：";
            // 
            // 端口框
            // 
            this.端口框.Location = new System.Drawing.Point(100, 52);
            this.端口框.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.端口框.Name = "端口框";
            this.端口框.Size = new System.Drawing.Size(80, 23);
            this.端口框.TabIndex = 3;
            this.端口框.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // 条码枪组
            // 
            this.条码枪组.Controls.Add(this.端口8框);
            this.条码枪组.Controls.Add(this.端口8标签);
            this.条码枪组.Controls.Add(this.端口7框);
            this.条码枪组.Controls.Add(this.端口7标签);
            this.条码枪组.Controls.Add(this.端口6框);
            this.条码枪组.Controls.Add(this.端口6标签);
            this.条码枪组.Controls.Add(this.端口5框);
            this.条码枪组.Controls.Add(this.端口5标签);
            this.条码枪组.Controls.Add(this.端口4框);
            this.条码枪组.Controls.Add(this.端口4标签);
            this.条码枪组.Controls.Add(this.端口3框);
            this.条码枪组.Controls.Add(this.端口3标签);
            this.条码枪组.Controls.Add(this.端口2框);
            this.条码枪组.Controls.Add(this.端口2标签);
            this.条码枪组.Controls.Add(this.端口1框);
            this.条码枪组.Controls.Add(this.端口1标签);
            this.条码枪组.Controls.Add(this.波特率框);
            this.条码枪组.Controls.Add(this.波特率标签);
            this.条码枪组.Controls.Add(this.条码枪数量框);
            this.条码枪组.Controls.Add(this.条码枪数量标签);
            this.条码枪组.Controls.Add(this.条码枪类型框);
            this.条码枪组.Controls.Add(this.条码枪类型标签);
            this.条码枪组.Location = new System.Drawing.Point(20, 180);
            this.条码枪组.Name = "条码枪组";
            this.条码枪组.Size = new System.Drawing.Size(600, 200);
            this.条码枪组.TabIndex = 2;
            this.条码枪组.TabStop = false;
            this.条码枪组.Text = "条码枪设置";
            // 
            // 条码枪类型标签
            // 
            this.条码枪类型标签.AutoSize = true;
            this.条码枪类型标签.Location = new System.Drawing.Point(20, 25);
            this.条码枪类型标签.Name = "条码枪类型标签";
            this.条码枪类型标签.Size = new System.Drawing.Size(80, 17);
            this.条码枪类型标签.TabIndex = 0;
            this.条码枪类型标签.Text = "条码枪类型：";
            // 
            // 条码枪类型框
            // 
            this.条码枪类型框.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.条码枪类型框.FormattingEnabled = true;
            this.条码枪类型框.Items.AddRange(new object[] {
            "USB",
            "串口"});
            this.条码枪类型框.Location = new System.Drawing.Point(120, 22);
            this.条码枪类型框.Name = "条码枪类型框";
            this.条码枪类型框.Size = new System.Drawing.Size(100, 23);
            this.条码枪类型框.TabIndex = 1;
            // 
            // 条码枪数量标签
            // 
            this.条码枪数量标签.AutoSize = true;
            this.条码枪数量标签.Location = new System.Drawing.Point(250, 25);
            this.条码枪数量标签.Name = "条码枪数量标签";
            this.条码枪数量标签.Size = new System.Drawing.Size(80, 17);
            this.条码枪数量标签.TabIndex = 2;
            this.条码枪数量标签.Text = "条码枪数量：";
            // 
            // 条码枪数量框
            // 
            this.条码枪数量框.Location = new System.Drawing.Point(370, 22);
            this.条码枪数量框.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.条码枪数量框.Name = "条码枪数量框";
            this.条码枪数量框.Size = new System.Drawing.Size(80, 23);
            this.条码枪数量框.TabIndex = 3;
            // 
            // 波特率标签
            // 
            this.波特率标签.AutoSize = true;
            this.波特率标签.Location = new System.Drawing.Point(20, 55);
            this.波特率标签.Name = "波特率标签";
            this.波特率标签.Size = new System.Drawing.Size(56, 17);
            this.波特率标签.TabIndex = 4;
            this.波特率标签.Text = "波特率：";
            // 
            // 波特率框
            // 
            this.波特率框.Location = new System.Drawing.Point(100, 52);
            this.波特率框.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.波特率框.Name = "波特率框";
            this.波特率框.Size = new System.Drawing.Size(80, 23);
            this.波特率框.TabIndex = 5;
            this.波特率框.Value = new decimal(new int[] {
            115200,
            0,
            0,
            0});
            // 
            // 端口1标签
            // 
            this.端口1标签.AutoSize = true;
            this.端口1标签.Location = new System.Drawing.Point(20, 85);
            this.端口1标签.Name = "端口1标签";
            this.端口1标签.Size = new System.Drawing.Size(44, 17);
            this.端口1标签.TabIndex = 6;
            this.端口1标签.Text = "1端口：";
            // 
            // 端口1框
            // 
            this.端口1框.Location = new System.Drawing.Point(80, 82);
            this.端口1框.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.端口1框.Name = "端口1框";
            this.端口1框.Size = new System.Drawing.Size(80, 23);
            this.端口1框.TabIndex = 7;
            this.端口1框.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // 端口2标签
            // 
            this.端口2标签.AutoSize = true;
            this.端口2标签.Location = new System.Drawing.Point(170, 85);
            this.端口2标签.Name = "端口2标签";
            this.端口2标签.Size = new System.Drawing.Size(44, 17);
            this.端口2标签.TabIndex = 8;
            this.端口2标签.Text = "2端口：";
            // 
            // 端口2框
            // 
            this.端口2框.Location = new System.Drawing.Point(230, 82);
            this.端口2框.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.端口2框.Name = "端口2框";
            this.端口2框.Size = new System.Drawing.Size(80, 23);
            this.端口2框.TabIndex = 9;
            this.端口2框.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // 端口3标签
            // 
            this.端口3标签.AutoSize = true;
            this.端口3标签.Location = new System.Drawing.Point(320, 85);
            this.端口3标签.Name = "端口3标签";
            this.端口3标签.Size = new System.Drawing.Size(44, 17);
            this.端口3标签.TabIndex = 10;
            this.端口3标签.Text = "3端口：";
            // 
            // 端口3框
            // 
            this.端口3框.Location = new System.Drawing.Point(380, 82);
            this.端口3框.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.端口3框.Name = "端口3框";
            this.端口3框.Size = new System.Drawing.Size(80, 23);
            this.端口3框.TabIndex = 11;
            this.端口3框.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // 端口4标签
            // 
            this.端口4标签.AutoSize = true;
            this.端口4标签.Location = new System.Drawing.Point(470, 85);
            this.端口4标签.Name = "端口4标签";
            this.端口4标签.Size = new System.Drawing.Size(44, 17);
            this.端口4标签.TabIndex = 12;
            this.端口4标签.Text = "4端口：";
            // 
            // 端口4框
            // 
            this.端口4框.Location = new System.Drawing.Point(530, 82);
            this.端口4框.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.端口4框.Name = "端口4框";
            this.端口4框.Size = new System.Drawing.Size(80, 23);
            this.端口4框.TabIndex = 13;
            this.端口4框.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // 端口5标签
            // 
            this.端口5标签.AutoSize = true;
            this.端口5标签.Location = new System.Drawing.Point(20, 115);
            this.端口5标签.Name = "端口5标签";
            this.端口5标签.Size = new System.Drawing.Size(44, 17);
            this.端口5标签.TabIndex = 14;
            this.端口5标签.Text = "5端口：";
            // 
            // 端口5框
            // 
            this.端口5框.Location = new System.Drawing.Point(80, 112);
            this.端口5框.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.端口5框.Name = "端口5框";
            this.端口5框.Size = new System.Drawing.Size(80, 23);
            this.端口5框.TabIndex = 15;
            this.端口5框.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // 端口6标签
            // 
            this.端口6标签.AutoSize = true;
            this.端口6标签.Location = new System.Drawing.Point(170, 115);
            this.端口6标签.Name = "端口6标签";
            this.端口6标签.Size = new System.Drawing.Size(44, 17);
            this.端口6标签.TabIndex = 16;
            this.端口6标签.Text = "6端口：";
            // 
            // 端口6框
            // 
            this.端口6框.Location = new System.Drawing.Point(230, 112);
            this.端口6框.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.端口6框.Name = "端口6框";
            this.端口6框.Size = new System.Drawing.Size(80, 23);
            this.端口6框.TabIndex = 17;
            this.端口6框.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // 端口7标签
            // 
            this.端口7标签.AutoSize = true;
            this.端口7标签.Location = new System.Drawing.Point(320, 115);
            this.端口7标签.Name = "端口7标签";
            this.端口7标签.Size = new System.Drawing.Size(44, 17);
            this.端口7标签.TabIndex = 18;
            this.端口7标签.Text = "7端口：";
            // 
            // 端口7框
            // 
            this.端口7框.Location = new System.Drawing.Point(380, 112);
            this.端口7框.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.端口7框.Name = "端口7框";
            this.端口7框.Size = new System.Drawing.Size(80, 23);
            this.端口7框.TabIndex = 19;
            this.端口7框.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // 端口8标签
            // 
            this.端口8标签.AutoSize = true;
            this.端口8标签.Location = new System.Drawing.Point(470, 115);
            this.端口8标签.Name = "端口8标签";
            this.端口8标签.Size = new System.Drawing.Size(44, 17);
            this.端口8标签.TabIndex = 20;
            this.端口8标签.Text = "8端口：";
            // 
            // 端口8框
            // 
            this.端口8框.Location = new System.Drawing.Point(530, 112);
            this.端口8框.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.端口8框.Name = "端口8框";
            this.端口8框.Size = new System.Drawing.Size(80, 23);
            this.端口8框.TabIndex = 21;
            this.端口8框.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // MESS设置控件
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.条码枪组);
            this.Controls.Add(this.服务器组);
            this.Controls.Add(this.MESS网络组);
            this.Name = "MESS设置控件";
            this.Size = new System.Drawing.Size(1200, 500);
            ((System.ComponentModel.ISupportInitialize)(this.端口框)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.端口8框)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.端口7框)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.端口6框)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.端口5框)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.端口4框)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.端口3框)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.端口2框)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.端口1框)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.波特率框)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.条码枪数量框)).EndInit();
            this.MESS网络组.ResumeLayout(false);
            this.MESS网络组.PerformLayout();
            this.服务器组.ResumeLayout(false);
            this.服务器组.PerformLayout();
            this.条码枪组.ResumeLayout(false);
            this.条码枪组.PerformLayout();
            this.ResumeLayout(false);

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