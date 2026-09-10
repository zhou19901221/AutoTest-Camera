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
            端口框 = new ComboBox();
            端口标签 = new Label();
            程控电源组 = new GroupBox();
            无程控框 = new ComboBox();
            无程控标签 = new Label();
            电源设置按钮 = new Button();
            基础设置组 = new GroupBox();
            伺服框 = new CheckBox();
            全局量程框 = new CheckBox();
            开机自动运行框 = new CheckBox();
            显示环境温度湿度框 = new CheckBox();
            安全门框 = new CheckBox();
            测试界面显示机器电压框 = new CheckBox();
            平台上升光幕保护框 = new CheckBox();
            平台下降光幕保护框 = new CheckBox();
            串口通讯板组 = new GroupBox();
            串口停止位 = new ComboBox();
            串口校验 = new ComboBox();
            串口数据位 = new ComboBox();
            串口波特率 = new ComboBox();
            串口校验标签 = new Label();
            串口停止位标签 = new Label();
            串口数据位标签 = new Label();
            串口波特率标签2 = new Label();
            测试设置组.SuspendLayout();
            串口设置组.SuspendLayout();
            程控电源组.SuspendLayout();
            基础设置组.SuspendLayout();
            串口通讯板组.SuspendLayout();
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
            串口设置组.Size = new Size(350, 55);
            串口设置组.TabIndex = 1;
            串口设置组.TabStop = false;
            串口设置组.Text = "串口设置";
            // 
            // 波特率框
            // 
            波特率框.DropDownStyle = ComboBoxStyle.DropDownList;
            波特率框.FormattingEnabled = true;
            波特率框.Items.AddRange(new object[] { "9600", "19200", "38400", "57600", "115200", "1000000" });
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
            端口框.DropDownStyle = ComboBoxStyle.DropDownList;
            端口框.Location = new Point(80, 22);
            端口框.Name = "端口框";
            端口框.Size = new Size(100, 25);
            端口框.TabIndex = 1;
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
            程控电源组.Controls.Add(无程控框);
            程控电源组.Controls.Add(无程控标签);
            程控电源组.Controls.Add(电源设置按钮);
            程控电源组.Location = new Point(20, 294);
            程控电源组.Name = "程控电源组";
            程控电源组.Size = new Size(350, 169);
            程控电源组.TabIndex = 2;
            程控电源组.TabStop = false;
            程控电源组.Text = "程控电源";
            // 
            // 无程控框
            // 
            无程控框.DropDownStyle = ComboBoxStyle.DropDownList;
            无程控框.FormattingEnabled = true;
            无程控框.Items.AddRange(new object[] { "无程控", "程控", "一迈YM600-Y60-L15" });
            无程控框.Location = new Point(70, 21);
            无程控框.Name = "无程控框";
            无程控框.Size = new Size(245, 25);
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
            // 电源设置按钮
            // 
            电源设置按钮.Location = new Point(80, 96);
            电源设置按钮.Name = "电源设置按钮";
            电源设置按钮.Size = new Size(210, 30);
            电源设置按钮.TabIndex = 17;
            电源设置按钮.Text = "电源设置";
            电源设置按钮.UseVisualStyleBackColor = true;
            电源设置按钮.Click += 电源设置按钮_Click;
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
            // 串口通讯板组
            // 
            串口通讯板组.Controls.Add(串口停止位);
            串口通讯板组.Controls.Add(串口校验);
            串口通讯板组.Controls.Add(串口数据位);
            串口通讯板组.Controls.Add(串口波特率);
            串口通讯板组.Controls.Add(串口校验标签);
            串口通讯板组.Controls.Add(串口停止位标签);
            串口通讯板组.Controls.Add(串口数据位标签);
            串口通讯板组.Controls.Add(串口波特率标签2);
            串口通讯板组.Location = new Point(20, 149);
            串口通讯板组.Name = "串口通讯板组";
            串口通讯板组.Size = new Size(350, 139);
            串口通讯板组.TabIndex = 4;
            串口通讯板组.TabStop = false;
            串口通讯板组.Text = "串口通讯板";
            // 
            // 串口停止位
            // 
            串口停止位.DropDownStyle = ComboBoxStyle.DropDownList;
            串口停止位.FormattingEnabled = true;
            串口停止位.Items.AddRange(new object[] { "1", "1.5", "2" });
            串口停止位.Location = new Point(80, 94);
            串口停止位.Name = "串口停止位";
            串口停止位.Size = new Size(100, 25);
            串口停止位.TabIndex = 4;
            // 
            // 串口校验
            // 
            串口校验.DropDownStyle = ComboBoxStyle.DropDownList;
            串口校验.FormattingEnabled = true;
            串口校验.Items.AddRange(new object[] { "None", "Odd", "Even", "Mark", "Space" });
            串口校验.Location = new Point(264, 24);
            串口校验.Name = "串口校验";
            串口校验.Size = new Size(71, 25);
            串口校验.TabIndex = 2;
            // 
            // 串口数据位
            // 
            串口数据位.DropDownStyle = ComboBoxStyle.DropDownList;
            串口数据位.FormattingEnabled = true;
            串口数据位.Items.AddRange(new object[] { "5", "6", "7", "8" });
            串口数据位.Location = new Point(80, 58);
            串口数据位.Name = "串口数据位";
            串口数据位.Size = new Size(100, 25);
            串口数据位.TabIndex = 3;
            // 
            // 串口波特率
            // 
            串口波特率.DropDownStyle = ComboBoxStyle.DropDownList;
            串口波特率.FormattingEnabled = true;
            串口波特率.Items.AddRange(new object[] { "9600", "19200", "38400", "57600", "115200" });
            串口波特率.Location = new Point(80, 24);
            串口波特率.Name = "串口波特率";
            串口波特率.Size = new Size(100, 25);
            串口波特率.TabIndex = 1;
            // 
            // 串口校验标签
            // 
            串口校验标签.AutoSize = true;
            串口校验标签.Location = new Point(204, 27);
            串口校验标签.Name = "串口校验标签";
            串口校验标签.Size = new Size(44, 17);
            串口校验标签.TabIndex = 7;
            串口校验标签.Text = "校验：";
            // 
            // 串口停止位标签
            // 
            串口停止位标签.AutoSize = true;
            串口停止位标签.Location = new Point(20, 97);
            串口停止位标签.Name = "串口停止位标签";
            串口停止位标签.Size = new Size(56, 17);
            串口停止位标签.TabIndex = 6;
            串口停止位标签.Text = "停止位：";
            // 
            // 串口数据位标签
            // 
            串口数据位标签.AutoSize = true;
            串口数据位标签.Location = new Point(20, 61);
            串口数据位标签.Name = "串口数据位标签";
            串口数据位标签.Size = new Size(56, 17);
            串口数据位标签.TabIndex = 5;
            串口数据位标签.Text = "数据位：";
            // 
            // 串口波特率标签2
            // 
            串口波特率标签2.AutoSize = true;
            串口波特率标签2.Location = new Point(20, 27);
            串口波特率标签2.Name = "串口波特率标签2";
            串口波特率标签2.Size = new Size(56, 17);
            串口波特率标签2.TabIndex = 0;
            串口波特率标签2.Text = "波特率：";
            // 
            // 基础参数控件
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(串口通讯板组);
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
            程控电源组.ResumeLayout(false);
            基础设置组.ResumeLayout(false);
            基础设置组.PerformLayout();
            串口通讯板组.ResumeLayout(false);
            串口通讯板组.PerformLayout();
            ResumeLayout(false);

        }

        private System.Windows.Forms.GroupBox 测试设置组;
        private System.Windows.Forms.ComboBox 测试类型框;
        private System.Windows.Forms.Label 测试类型标签;
        private System.Windows.Forms.GroupBox 串口设置组;
        private System.Windows.Forms.ComboBox 波特率框;
        private System.Windows.Forms.Label 波特率标签;
        private System.Windows.Forms.ComboBox 端口框;
        private System.Windows.Forms.Label 端口标签;
        private System.Windows.Forms.GroupBox 程控电源组;
        private System.Windows.Forms.Button 电源设置按钮;
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
        private GroupBox 串口通讯板组;
        private ComboBox 串口停止位;
        private ComboBox 串口校验;
        private ComboBox 串口数据位;
        private ComboBox 串口波特率;
        private Label 串口校验标签;
        private Label 串口停止位标签;
        private Label 串口数据位标签;
        private Label 串口波特率标签2;
    }
}