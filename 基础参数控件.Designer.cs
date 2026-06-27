namespace 自动测试
{
    partial class 基础参数控件
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
            测试设置组 = new GroupBox();
            测试类型框 = new ComboBox();
            测试类型标签 = new Label();
            串口设置组 = new GroupBox();
            波特率框 = new ComboBox();
            波特率标签 = new Label();
            端口框 = new NumericUpDown();
            端口标签 = new Label();
            程控电源组 = new GroupBox();
            电流单位标签 = new Label();
            电流框 = new NumericUpDown();
            电流标签 = new Label();
            频率单位标签 = new Label();
            频率框 = new NumericUpDown();
            频率标签 = new Label();
            电压单位标签 = new Label();
            电压框 = new NumericUpDown();
            电压标签 = new Label();
            程控波特率框 = new NumericUpDown();
            程控波特率标签 = new Label();
            校验位框 = new ComboBox();
            校验位标签 = new Label();
            类型框 = new ComboBox();
            类型标签 = new Label();
            无程控框 = new ComboBox();
            无程控标签 = new Label();
            基础设置组 = new GroupBox();
            伺服框 = new CheckBox();
            全局量程框 = new CheckBox();
            开机自动运行框 = new CheckBox();
            显示环境温度湿度框 = new CheckBox();
            安全门框 = new CheckBox();
            测试界面显示机器电压框 = new CheckBox();
            平台上升光幕保护框 = new CheckBox();
            平台下降光幕保护框 = new CheckBox();
            测试设置组.SuspendLayout();
            串口设置组.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)端口框).BeginInit();
            程控电源组.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)电流框).BeginInit();
            ((System.ComponentModel.ISupportInitialize)频率框).BeginInit();
            ((System.ComponentModel.ISupportInitialize)电压框).BeginInit();
            ((System.ComponentModel.ISupportInitialize)程控波特率框).BeginInit();
            基础设置组.SuspendLayout();
            SuspendLayout();
            // 
            // 测试设置组
            // 
            测试设置组.Controls.Add(测试类型框);
            测试设置组.Controls.Add(测试类型标签);
            测试设置组.Location = new Point(20, 20);
            测试设置组.Name = "测试设置组";
            测试设置组.Size = new Size(350, 60);
            测试设置组.TabIndex = 0;
            测试设置组.TabStop = false;
            测试设置组.Text = "测试设置";
            // 
            // 测试类型框
            // 
            测试类型框.DropDownStyle = ComboBoxStyle.DropDownList;
            测试类型框.FormattingEnabled = true;
            测试类型框.Items.AddRange(new object[] { "半自动FCT", "自动FCT", "手动FCT" });
            测试类型框.Location = new Point(100, 22);
            测试类型框.Name = "测试类型框";
            测试类型框.Size = new Size(200, 25);
            测试类型框.TabIndex = 1;
            // 
            // 测试类型标签
            // 
            测试类型标签.AutoSize = true;
            测试类型标签.Location = new Point(20, 25);
            测试类型标签.Name = "测试类型标签";
            测试类型标签.Size = new Size(68, 17);
            测试类型标签.TabIndex = 0;
            测试类型标签.Text = "测试类型：";
            // 
            // 串口设置组
            // 
            串口设置组.Controls.Add(波特率框);
            串口设置组.Controls.Add(波特率标签);
            串口设置组.Controls.Add(端口框);
            串口设置组.Controls.Add(端口标签);
            串口设置组.Location = new Point(20, 88);
            串口设置组.Name = "串口设置组";
            串口设置组.Size = new Size(350, 60);
            串口设置组.TabIndex = 1;
            串口设置组.TabStop = false;
            串口设置组.Text = "串口设置";
            // 
            // 波特率框
            // 
            波特率框.DropDownStyle = ComboBoxStyle.DropDownList;
            波特率框.FormattingEnabled = true;
            波特率框.Items.AddRange(new object[] { "9600", "19200", "38400", "57600", "115200" });
            波特率框.Location = new Point(240, 22);
            波特率框.Name = "波特率框";
            波特率框.Size = new Size(100, 25);
            波特率框.TabIndex = 3;
            // 
            // 波特率标签
            // 
            波特率标签.AutoSize = true;
            波特率标签.Location = new Point(180, 25);
            波特率标签.Name = "波特率标签";
            波特率标签.Size = new Size(56, 17);
            波特率标签.TabIndex = 2;
            波特率标签.Text = "波特率：";
            // 
            // 端口框
            // 
            端口框.Location = new Point(80, 22);
            端口框.Name = "端口框";
            端口框.Size = new Size(80, 23);
            端口框.TabIndex = 1;
            端口框.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // 端口标签
            // 
            端口标签.AutoSize = true;
            端口标签.Location = new Point(20, 25);
            端口标签.Name = "端口标签";
            端口标签.Size = new Size(44, 17);
            端口标签.TabIndex = 0;
            端口标签.Text = "端口：";
            // 
            // 程控电源组
            // 
            程控电源组.Controls.Add(电流单位标签);
            程控电源组.Controls.Add(电流框);
            程控电源组.Controls.Add(电流标签);
            程控电源组.Controls.Add(频率单位标签);
            程控电源组.Controls.Add(频率框);
            程控电源组.Controls.Add(频率标签);
            程控电源组.Controls.Add(电压单位标签);
            程控电源组.Controls.Add(电压框);
            程控电源组.Controls.Add(电压标签);
            程控电源组.Controls.Add(程控波特率框);
            程控电源组.Controls.Add(程控波特率标签);
            程控电源组.Controls.Add(校验位框);
            程控电源组.Controls.Add(校验位标签);
            程控电源组.Controls.Add(类型框);
            程控电源组.Controls.Add(类型标签);
            程控电源组.Controls.Add(无程控框);
            程控电源组.Controls.Add(无程控标签);
            程控电源组.Location = new Point(20, 166);
            程控电源组.Name = "程控电源组";
            程控电源组.Size = new Size(350, 297);
            程控电源组.TabIndex = 2;
            程控电源组.TabStop = false;
            程控电源组.Text = "程控电源";
            // 
            // 电流单位标签
            // 
            电流单位标签.AutoSize = true;
            电流单位标签.Location = new Point(180, 229);
            电流单位标签.Name = "电流单位标签";
            电流单位标签.Size = new Size(16, 17);
            电流单位标签.TabIndex = 16;
            电流单位标签.Text = "A";
            // 
            // 电流框
            // 
            电流框.DecimalPlaces = 1;
            电流框.Location = new Point(70, 226);
            电流框.Name = "电流框";
            电流框.Size = new Size(100, 23);
            电流框.TabIndex = 15;
            电流框.Value = new decimal(new int[] { 20, 0, 0, 65536 });
            // 
            // 电流标签
            // 
            电流标签.Location = new Point(8, 229);
            电流标签.Name = "电流标签";
            电流标签.Size = new Size(56, 17);
            电流标签.TabIndex = 14;
            电流标签.Text = "电流：";
            电流标签.TextAlign = ContentAlignment.MiddleRight;
            // 
            // 频率单位标签
            // 
            频率单位标签.AutoSize = true;
            频率单位标签.Location = new Point(180, 127);
            频率单位标签.Name = "频率单位标签";
            频率单位标签.Size = new Size(23, 17);
            频率单位标签.TabIndex = 13;
            频率单位标签.Text = "Hz";
            // 
            // 频率框
            // 
            频率框.Location = new Point(70, 90);
            频率框.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            频率框.Name = "频率框";
            频率框.Size = new Size(100, 23);
            频率框.TabIndex = 12;
            频率框.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // 频率标签
            // 
            频率标签.Location = new Point(8, 93);
            频率标签.Name = "频率标签";
            频率标签.Size = new Size(56, 17);
            频率标签.TabIndex = 11;
            频率标签.Text = "频率：";
            频率标签.TextAlign = ContentAlignment.MiddleRight;
            // 
            // 电压单位标签
            // 
            电压单位标签.AutoSize = true;
            电压单位标签.Location = new Point(180, 195);
            电压单位标签.Name = "电压单位标签";
            电压单位标签.Size = new Size(16, 17);
            电压单位标签.TabIndex = 10;
            电压单位标签.Text = "V";
            // 
            // 电压框
            // 
            电压框.Location = new Point(70, 192);
            电压框.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            电压框.Name = "电压框";
            电压框.Size = new Size(100, 23);
            电压框.TabIndex = 9;
            电压框.Value = new decimal(new int[] { 220, 0, 0, 0 });
            // 
            // 电压标签
            // 
            电压标签.Location = new Point(8, 195);
            电压标签.Name = "电压标签";
            电压标签.Size = new Size(56, 17);
            电压标签.TabIndex = 8;
            电压标签.Text = "电压：";
            电压标签.TextAlign = ContentAlignment.MiddleRight;
            // 
            // 程控波特率框
            // 
            程控波特率框.Location = new Point(70, 124);
            程控波特率框.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            程控波特率框.Name = "程控波特率框";
            程控波特率框.Size = new Size(100, 23);
            程控波特率框.TabIndex = 7;
            程控波特率框.Value = new decimal(new int[] { 115200, 0, 0, 0 });
            // 
            // 程控波特率标签
            // 
            程控波特率标签.Location = new Point(8, 127);
            程控波特率标签.Name = "程控波特率标签";
            程控波特率标签.Size = new Size(56, 17);
            程控波特率标签.TabIndex = 6;
            程控波特率标签.Text = "波特率：";
            程控波特率标签.TextAlign = ContentAlignment.MiddleRight;
            // 
            // 校验位框
            // 
            校验位框.DropDownStyle = ComboBoxStyle.DropDownList;
            校验位框.FormattingEnabled = true;
            校验位框.Items.AddRange(new object[] { "NONE", "EVEN", "ODD" });
            校验位框.Location = new Point(70, 158);
            校验位框.Name = "校验位框";
            校验位框.Size = new Size(100, 25);
            校验位框.TabIndex = 5;
            // 
            // 校验位标签
            // 
            校验位标签.Location = new Point(8, 161);
            校验位标签.Name = "校验位标签";
            校验位标签.Size = new Size(56, 17);
            校验位标签.TabIndex = 4;
            校验位标签.Text = "校验位：";
            校验位标签.TextAlign = ContentAlignment.MiddleRight;
            // 
            // 类型框
            // 
            类型框.DropDownStyle = ComboBoxStyle.DropDownList;
            类型框.FormattingEnabled = true;
            类型框.Items.AddRange(new object[] { "安姆泰克", "其他" });
            类型框.Location = new Point(70, 55);
            类型框.Name = "类型框";
            类型框.Size = new Size(100, 25);
            类型框.TabIndex = 3;
            // 
            // 类型标签
            // 
            类型标签.Location = new Point(8, 59);
            类型标签.Name = "类型标签";
            类型标签.Size = new Size(56, 17);
            类型标签.TabIndex = 2;
            类型标签.Text = "类型：";
            类型标签.TextAlign = ContentAlignment.MiddleRight;
            // 
            // 无程控框
            // 
            无程控框.DropDownStyle = ComboBoxStyle.DropDownList;
            无程控框.FormattingEnabled = true;
            无程控框.Items.AddRange(new object[] { "无程控", "程控" });
            无程控框.Location = new Point(70, 21);
            无程控框.Name = "无程控框";
            无程控框.Size = new Size(100, 25);
            无程控框.TabIndex = 1;
            // 
            // 无程控标签
            // 
            无程控标签.Location = new Point(8, 25);
            无程控标签.Name = "无程控标签";
            无程控标签.Size = new Size(56, 17);
            无程控标签.TabIndex = 0;
            无程控标签.Text = "无程控：";
            无程控标签.TextAlign = ContentAlignment.MiddleRight;
            // 
            // 基础设置组
            // 
            基础设置组.Controls.Add(伺服框);
            基础设置组.Controls.Add(全局量程框);
            基础设置组.Controls.Add(开机自动运行框);
            基础设置组.Controls.Add(显示环境温度湿度框);
            基础设置组.Controls.Add(安全门框);
            基础设置组.Controls.Add(测试界面显示机器电压框);
            基础设置组.Controls.Add(平台上升光幕保护框);
            基础设置组.Controls.Add(平台下降光幕保护框);
            基础设置组.Location = new Point(398, 20);
            基础设置组.Name = "基础设置组";
            基础设置组.Size = new Size(704, 443);
            基础设置组.TabIndex = 3;
            基础设置组.TabStop = false;
            基础设置组.Text = "基础设置";
            // 
            // 伺服框
            // 
            伺服框.AutoSize = true;
            伺服框.Location = new Point(20, 201);
            伺服框.Name = "伺服框";
            伺服框.Size = new Size(51, 21);
            伺服框.TabIndex = 7;
            伺服框.Text = "伺服";
            伺服框.UseVisualStyleBackColor = true;
            // 
            // 全局量程框
            // 
            全局量程框.AutoSize = true;
            全局量程框.Location = new Point(20, 177);
            全局量程框.Name = "全局量程框";
            全局量程框.Size = new Size(75, 21);
            全局量程框.TabIndex = 7;
            全局量程框.Text = "全局量程";
            全局量程框.UseVisualStyleBackColor = true;
            // 
            // 开机自动运行框
            // 
            开机自动运行框.AutoSize = true;
            开机自动运行框.Location = new Point(20, 152);
            开机自动运行框.Name = "开机自动运行框";
            开机自动运行框.Size = new Size(99, 21);
            开机自动运行框.TabIndex = 6;
            开机自动运行框.Text = "开机自动运行";
            开机自动运行框.UseVisualStyleBackColor = true;
            // 
            // 显示环境温度湿度框
            // 
            显示环境温度湿度框.AutoSize = true;
            显示环境温度湿度框.Location = new Point(20, 127);
            显示环境温度湿度框.Name = "显示环境温度湿度框";
            显示环境温度湿度框.Size = new Size(123, 21);
            显示环境温度湿度框.TabIndex = 5;
            显示环境温度湿度框.Text = "显示环境温度湿度";
            显示环境温度湿度框.UseVisualStyleBackColor = true;
            // 
            // 安全门框
            // 
            安全门框.AutoSize = true;
            安全门框.Location = new Point(20, 102);
            安全门框.Name = "安全门框";
            安全门框.Size = new Size(63, 21);
            安全门框.TabIndex = 4;
            安全门框.Text = "安全门";
            安全门框.UseVisualStyleBackColor = true;
            // 
            // 测试界面显示机器电压框
            // 
            测试界面显示机器电压框.AutoSize = true;
            测试界面显示机器电压框.Checked = true;
            测试界面显示机器电压框.CheckState = CheckState.Checked;
            测试界面显示机器电压框.Location = new Point(20, 75);
            测试界面显示机器电压框.Name = "测试界面显示机器电压框";
            测试界面显示机器电压框.Size = new Size(147, 21);
            测试界面显示机器电压框.TabIndex = 2;
            测试界面显示机器电压框.Text = "测试界面显示机器电压";
            测试界面显示机器电压框.UseVisualStyleBackColor = true;
            // 
            // 平台上升光幕保护框
            // 
            平台上升光幕保护框.AutoSize = true;
            平台上升光幕保护框.Location = new Point(20, 50);
            平台上升光幕保护框.Name = "平台上升光幕保护框";
            平台上升光幕保护框.Size = new Size(123, 21);
            平台上升光幕保护框.TabIndex = 1;
            平台上升光幕保护框.Text = "平台上升光幕保护";
            平台上升光幕保护框.UseVisualStyleBackColor = true;
            // 
            // 平台下降光幕保护框
            // 
            平台下降光幕保护框.AutoSize = true;
            平台下降光幕保护框.Checked = true;
            平台下降光幕保护框.CheckState = CheckState.Checked;
            平台下降光幕保护框.Location = new Point(20, 25);
            平台下降光幕保护框.Name = "平台下降光幕保护框";
            平台下降光幕保护框.Size = new Size(123, 21);
            平台下降光幕保护框.TabIndex = 0;
            平台下降光幕保护框.Text = "平台下降光幕保护";
            平台下降光幕保护框.UseVisualStyleBackColor = true;
            // 
            // 基础参数控件
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(基础设置组);
            Controls.Add(程控电源组);
            Controls.Add(串口设置组);
            Controls.Add(测试设置组);
            Name = "基础参数控件";
            Size = new Size(1200, 500);
            测试设置组.ResumeLayout(false);
            测试设置组.PerformLayout();
            串口设置组.ResumeLayout(false);
            串口设置组.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)端口框).EndInit();
            程控电源组.ResumeLayout(false);
            程控电源组.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)电流框).EndInit();
            ((System.ComponentModel.ISupportInitialize)频率框).EndInit();
            ((System.ComponentModel.ISupportInitialize)电压框).EndInit();
            ((System.ComponentModel.ISupportInitialize)程控波特率框).EndInit();
            基础设置组.ResumeLayout(false);
            基础设置组.PerformLayout();
            ResumeLayout(false);

        }

        private System.Windows.Forms.GroupBox 测试设置组;
        private System.Windows.Forms.ComboBox 测试类型框;
        private System.Windows.Forms.Label 测试类型标签;
        private System.Windows.Forms.GroupBox 串口设置组;
        private System.Windows.Forms.ComboBox 波特率框;
        private System.Windows.Forms.Label 波特率标签;
        private System.Windows.Forms.NumericUpDown 端口框;
        private System.Windows.Forms.Label 端口标签;
        private System.Windows.Forms.GroupBox 程控电源组;
        private System.Windows.Forms.Label 电流单位标签;
        private System.Windows.Forms.NumericUpDown 电流框;
        private System.Windows.Forms.Label 电流标签;
        private System.Windows.Forms.Label 频率单位标签;
        private System.Windows.Forms.NumericUpDown 频率框;
        private System.Windows.Forms.Label 频率标签;
        private System.Windows.Forms.Label 电压单位标签;
        private System.Windows.Forms.NumericUpDown 电压框;
        private System.Windows.Forms.Label 电压标签;
        private System.Windows.Forms.NumericUpDown 程控波特率框;
        private System.Windows.Forms.Label 程控波特率标签;
        private System.Windows.Forms.ComboBox 校验位框;
        private System.Windows.Forms.Label 校验位标签;
        private System.Windows.Forms.ComboBox 类型框;
        private System.Windows.Forms.Label 类型标签;
        private System.Windows.Forms.ComboBox 无程控框;
        private System.Windows.Forms.Label 无程控标签;
        private System.Windows.Forms.GroupBox 基础设置组;
        private System.Windows.Forms.CheckBox 全局量程框;
        private System.Windows.Forms.CheckBox 开机自动运行框;
        private System.Windows.Forms.CheckBox 显示环境温度湿度框;
        private System.Windows.Forms.CheckBox 安全门框;
        private System.Windows.Forms.CheckBox 测试界面显示机器电压框;
        private System.Windows.Forms.CheckBox 平台上升光幕保护框;
        private System.Windows.Forms.CheckBox 平台下降光幕保护框;
        private CheckBox 伺服框;
    }
}