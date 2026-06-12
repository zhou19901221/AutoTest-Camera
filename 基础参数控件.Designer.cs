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
            this.components = new System.ComponentModel.Container();
            this.测试设置组 = new System.Windows.Forms.GroupBox();
            this.测试类型框 = new System.Windows.Forms.ComboBox();
            this.测试类型标签 = new System.Windows.Forms.Label();
            this.串口设置组 = new System.Windows.Forms.GroupBox();
            this.波特率框 = new System.Windows.Forms.ComboBox();
            this.波特率标签 = new System.Windows.Forms.Label();
            this.端口框 = new System.Windows.Forms.NumericUpDown();
            this.端口标签 = new System.Windows.Forms.Label();
            this.程控电源组 = new System.Windows.Forms.GroupBox();
            this.电流单位标签 = new System.Windows.Forms.Label();
            this.电流框 = new System.Windows.Forms.NumericUpDown();
            this.电流标签 = new System.Windows.Forms.Label();
            this.频率单位标签 = new System.Windows.Forms.Label();
            this.频率框 = new System.Windows.Forms.NumericUpDown();
            this.频率标签 = new System.Windows.Forms.Label();
            this.电压单位标签 = new System.Windows.Forms.Label();
            this.电压框 = new System.Windows.Forms.NumericUpDown();
            this.电压标签 = new System.Windows.Forms.Label();
            this.程控波特率框 = new System.Windows.Forms.NumericUpDown();
            this.程控波特率标签 = new System.Windows.Forms.Label();
            this.校验位框 = new System.Windows.Forms.ComboBox();
            this.校验位标签 = new System.Windows.Forms.Label();
            this.类型框 = new System.Windows.Forms.ComboBox();
            this.类型标签 = new System.Windows.Forms.Label();
            this.无程控框 = new System.Windows.Forms.ComboBox();
            this.无程控标签 = new System.Windows.Forms.Label();
            this.基础设置组 = new System.Windows.Forms.GroupBox();
            this.全局量程框 = new System.Windows.Forms.CheckBox();
            this.开机自动运行框 = new System.Windows.Forms.CheckBox();
            this.显示环境温度湿度框 = new System.Windows.Forms.CheckBox();
            this.安全门框 = new System.Windows.Forms.CheckBox();
            this.NG授权管理框 = new System.Windows.Forms.CheckBox();
            this.测试界面显示机器电压框 = new System.Windows.Forms.CheckBox();
            this.平台上升光幕保护框 = new System.Windows.Forms.CheckBox();
            this.平台下降光幕保护框 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.端口框)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.电流框)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.频率框)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.电压框)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.程控波特率框)).BeginInit();
            this.测试设置组.SuspendLayout();
            this.串口设置组.SuspendLayout();
            this.程控电源组.SuspendLayout();
            this.基础设置组.SuspendLayout();
            this.SuspendLayout();
            // 
            // 测试设置组
            // 
            this.测试设置组.Controls.Add(this.测试类型框);
            this.测试设置组.Controls.Add(this.测试类型标签);
            this.测试设置组.Location = new System.Drawing.Point(20, 20);
            this.测试设置组.Name = "测试设置组";
            this.测试设置组.Size = new System.Drawing.Size(350, 60);
            this.测试设置组.TabIndex = 0;
            this.测试设置组.TabStop = false;
            this.测试设置组.Text = "测试设置";
            // 
            // 测试类型标签
            // 
            this.测试类型标签.AutoSize = true;
            this.测试类型标签.Location = new System.Drawing.Point(20, 25);
            this.测试类型标签.Name = "测试类型标签";
            this.测试类型标签.Size = new System.Drawing.Size(68, 17);
            this.测试类型标签.TabIndex = 0;
            this.测试类型标签.Text = "测试类型：";
            // 
            // 测试类型框
            // 
            this.测试类型框.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.测试类型框.FormattingEnabled = true;
            this.测试类型框.Items.AddRange(new object[] {
            "半自动FCT",
            "自动FCT",
            "手动FCT"});
            this.测试类型框.Location = new System.Drawing.Point(100, 22);
            this.测试类型框.Name = "测试类型框";
            this.测试类型框.Size = new System.Drawing.Size(200, 23);
            this.测试类型框.TabIndex = 1;
            // 
            // 串口设置组
            // 
            this.串口设置组.Controls.Add(this.波特率框);
            this.串口设置组.Controls.Add(this.波特率标签);
            this.串口设置组.Controls.Add(this.端口框);
            this.串口设置组.Controls.Add(this.端口标签);
            this.串口设置组.Location = new System.Drawing.Point(20, 90);
            this.串口设置组.Name = "串口设置组";
            this.串口设置组.Size = new System.Drawing.Size(350, 60);
            this.串口设置组.TabIndex = 1;
            this.串口设置组.TabStop = false;
            this.串口设置组.Text = "串口设置";
            // 
            // 端口标签
            // 
            this.端口标签.AutoSize = true;
            this.端口标签.Location = new System.Drawing.Point(20, 25);
            this.端口标签.Name = "端口标签";
            this.端口标签.Size = new System.Drawing.Size(44, 17);
            this.端口标签.TabIndex = 0;
            this.端口标签.Text = "端口：";
            // 
            // 端口框
            // 
            this.端口框.Location = new System.Drawing.Point(80, 22);
            this.端口框.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.端口框.Name = "端口框";
            this.端口框.Size = new System.Drawing.Size(80, 23);
            this.端口框.TabIndex = 1;
            this.端口框.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // 波特率标签
            // 
            this.波特率标签.AutoSize = true;
            this.波特率标签.Location = new System.Drawing.Point(180, 25);
            this.波特率标签.Name = "波特率标签";
            this.波特率标签.Size = new System.Drawing.Size(56, 17);
            this.波特率标签.TabIndex = 2;
            this.波特率标签.Text = "波特率：";
            // 
            // 波特率框
            // 
            this.波特率框.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.波特率框.FormattingEnabled = true;
            this.波特率框.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.波特率框.Location = new System.Drawing.Point(240, 22);
            this.波特率框.Name = "波特率框";
            this.波特率框.Size = new System.Drawing.Size(100, 23);
            this.波特率框.TabIndex = 3;
            // 
            // 程控电源组
            // 
            this.程控电源组.Controls.Add(this.电流单位标签);
            this.程控电源组.Controls.Add(this.电流框);
            this.程控电源组.Controls.Add(this.电流标签);
            this.程控电源组.Controls.Add(this.频率单位标签);
            this.程控电源组.Controls.Add(this.频率框);
            this.程控电源组.Controls.Add(this.频率标签);
            this.程控电源组.Controls.Add(this.电压单位标签);
            this.程控电源组.Controls.Add(this.电压框);
            this.程控电源组.Controls.Add(this.电压标签);
            this.程控电源组.Controls.Add(this.程控波特率框);
            this.程控电源组.Controls.Add(this.程控波特率标签);
            this.程控电源组.Controls.Add(this.校验位框);
            this.程控电源组.Controls.Add(this.校验位标签);
            this.程控电源组.Controls.Add(this.类型框);
            this.程控电源组.Controls.Add(this.类型标签);
            this.程控电源组.Controls.Add(this.无程控框);
            this.程控电源组.Controls.Add(this.无程控标签);
            this.程控电源组.Location = new System.Drawing.Point(20, 160);
            this.程控电源组.Name = "程控电源组";
            this.程控电源组.Size = new System.Drawing.Size(500, 120);
            this.程控电源组.TabIndex = 2;
            this.程控电源组.TabStop = false;
            this.程控电源组.Text = "程控电源";
            // 
            // 无程控标签
            // 
            this.无程控标签.AutoSize = true;
            this.无程控标签.Location = new System.Drawing.Point(20, 25);
            this.无程控标签.Name = "无程控标签";
            this.无程控标签.Size = new System.Drawing.Size(56, 17);
            this.无程控标签.TabIndex = 0;
            this.无程控标签.Text = "无程控：";
            // 
            // 无程控框
            // 
            this.无程控框.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.无程控框.FormattingEnabled = true;
            this.无程控框.Items.AddRange(new object[] {
            "无程控",
            "程控"});
            this.无程控框.Location = new System.Drawing.Point(100, 22);
            this.无程控框.Name = "无程控框";
            this.无程控框.Size = new System.Drawing.Size(100, 23);
            this.无程控框.TabIndex = 1;
            // 
            // 类型标签
            // 
            this.类型标签.AutoSize = true;
            this.类型标签.Location = new System.Drawing.Point(220, 25);
            this.类型标签.Name = "类型标签";
            this.类型标签.Size = new System.Drawing.Size(44, 17);
            this.类型标签.TabIndex = 2;
            this.类型标签.Text = "类型：";
            // 
            // 类型框
            // 
            this.类型框.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.类型框.FormattingEnabled = true;
            this.类型框.Items.AddRange(new object[] {
            "安姆泰克",
            "其他"});
            this.类型框.Location = new System.Drawing.Point(280, 22);
            this.类型框.Name = "类型框";
            this.类型框.Size = new System.Drawing.Size(100, 23);
            this.类型框.TabIndex = 3;
            // 
            // 校验位标签
            // 
            this.校验位标签.AutoSize = true;
            this.校验位标签.Location = new System.Drawing.Point(20, 55);
            this.校验位标签.Name = "校验位标签";
            this.校验位标签.Size = new System.Drawing.Size(56, 17);
            this.校验位标签.TabIndex = 4;
            this.校验位标签.Text = "校验位：";
            // 
            // 校验位框
            // 
            this.校验位框.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.校验位框.FormattingEnabled = true;
            this.校验位框.Items.AddRange(new object[] {
            "NONE",
            "EVEN",
            "ODD"});
            this.校验位框.Location = new System.Drawing.Point(80, 52);
            this.校验位框.Name = "校验位框";
            this.校验位框.Size = new System.Drawing.Size(80, 23);
            this.校验位框.TabIndex = 5;
            // 
            // 程控波特率标签
            // 
            this.程控波特率标签.AutoSize = true;
            this.程控波特率标签.Location = new System.Drawing.Point(180, 55);
            this.程控波特率标签.Name = "程控波特率标签";
            this.程控波特率标签.Size = new System.Drawing.Size(56, 17);
            this.程控波特率标签.TabIndex = 6;
            this.程控波特率标签.Text = "波特率：";
            // 
            // 程控波特率框
            // 
            this.程控波特率框.Location = new System.Drawing.Point(260, 52);
            this.程控波特率框.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.程控波特率框.Name = "程控波特率框";
            this.程控波特率框.Size = new System.Drawing.Size(80, 23);
            this.程控波特率框.TabIndex = 7;
            this.程控波特率框.Value = new decimal(new int[] {
            115200,
            0,
            0,
            0});
            // 
            // 电压标签
            // 
            this.电压标签.AutoSize = true;
            this.电压标签.Location = new System.Drawing.Point(20, 85);
            this.电压标签.Name = "电压标签";
            this.电压标签.Size = new System.Drawing.Size(44, 17);
            this.电压标签.TabIndex = 8;
            this.电压标签.Text = "电压：";
            // 
            // 电压框
            // 
            this.电压框.Location = new System.Drawing.Point(80, 82);
            this.电压框.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.电压框.Name = "电压框";
            this.电压框.Size = new System.Drawing.Size(80, 23);
            this.电压框.TabIndex = 9;
            this.电压框.Value = new decimal(new int[] {
            220,
            0,
            0,
            0});
            // 
            // 电压单位标签
            // 
            this.电压单位标签.AutoSize = true;
            this.电压单位标签.Location = new System.Drawing.Point(170, 85);
            this.电压单位标签.Name = "电压单位标签";
            this.电压单位标签.Size = new System.Drawing.Size(17, 17);
            this.电压单位标签.TabIndex = 10;
            this.电压单位标签.Text = "V";
            // 
            // 频率标签
            // 
            this.频率标签.AutoSize = true;
            this.频率标签.Location = new System.Drawing.Point(200, 85);
            this.频率标签.Name = "频率标签";
            this.频率标签.Size = new System.Drawing.Size(44, 17);
            this.频率标签.TabIndex = 11;
            this.频率标签.Text = "频率：";
            // 
            // 频率框
            // 
            this.频率框.Location = new System.Drawing.Point(260, 82);
            this.频率框.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.频率框.Name = "频率框";
            this.频率框.Size = new System.Drawing.Size(80, 23);
            this.频率框.TabIndex = 12;
            this.频率框.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // 频率单位标签
            // 
            this.频率单位标签.AutoSize = true;
            this.频率单位标签.Location = new System.Drawing.Point(350, 85);
            this.频率单位标签.Name = "频率单位标签";
            this.频率单位标签.Size = new System.Drawing.Size(23, 17);
            this.频率单位标签.TabIndex = 13;
            this.频率单位标签.Text = "Hz";
            // 
            // 电流标签
            // 
            this.电流标签.AutoSize = true;
            this.电流标签.Location = new System.Drawing.Point(20, 115);
            this.电流标签.Name = "电流标签";
            this.电流标签.Size = new System.Drawing.Size(44, 17);
            this.电流标签.TabIndex = 14;
            this.电流标签.Text = "电流：";
            // 
            // 电流框
            // 
            this.电流框.Location = new System.Drawing.Point(80, 112);
            this.电流框.DecimalPlaces = 1;
            this.电流框.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.电流框.Name = "电流框";
            this.电流框.Size = new System.Drawing.Size(80, 23);
            this.电流框.TabIndex = 15;
            this.电流框.Value = new decimal(new int[] {
            20,
            0,
            0,
            65536});
            // 
            // 电流单位标签
            // 
            this.电流单位标签.AutoSize = true;
            this.电流单位标签.Location = new System.Drawing.Point(170, 115);
            this.电流单位标签.Name = "电流单位标签";
            this.电流单位标签.Size = new System.Drawing.Size(17, 17);
            this.电流单位标签.TabIndex = 16;
            this.电流单位标签.Text = "A";
            // 
            // 基础设置组
            // 
            this.基础设置组.Controls.Add(this.全局量程框);
            this.基础设置组.Controls.Add(this.开机自动运行框);
            this.基础设置组.Controls.Add(this.显示环境温度湿度框);
            this.基础设置组.Controls.Add(this.安全门框);
            this.基础设置组.Controls.Add(this.NG授权管理框);
            this.基础设置组.Controls.Add(this.测试界面显示机器电压框);
            this.基础设置组.Controls.Add(this.平台上升光幕保护框);
            this.基础设置组.Controls.Add(this.平台下降光幕保护框);
            this.基础设置组.Location = new System.Drawing.Point(20, 290);
            this.基础设置组.Name = "基础设置组";
            this.基础设置组.Size = new System.Drawing.Size(400, 150);
            this.基础设置组.TabIndex = 3;
            this.基础设置组.TabStop = false;
            this.基础设置组.Text = "基础设置";
            // 
            // 平台下降光幕保护框
            // 
            this.平台下降光幕保护框.AutoSize = true;
            this.平台下降光幕保护框.Checked = true;
            this.平台下降光幕保护框.CheckState = System.Windows.Forms.CheckState.Checked;
            this.平台下降光幕保护框.Location = new System.Drawing.Point(20, 25);
            this.平台下降光幕保护框.Name = "平台下降光幕保护框";
            this.平台下降光幕保护框.Size = new System.Drawing.Size(148, 21);
            this.平台下降光幕保护框.TabIndex = 0;
            this.平台下降光幕保护框.Text = "平台下降光幕保护";
            this.平台下降光幕保护框.UseVisualStyleBackColor = true;
            // 
            // 平台上升光幕保护框
            // 
            this.平台上升光幕保护框.AutoSize = true;
            this.平台上升光幕保护框.Location = new System.Drawing.Point(20, 50);
            this.平台上升光幕保护框.Name = "平台上升光幕保护框";
            this.平台上升光幕保护框.Size = new System.Drawing.Size(148, 21);
            this.平台上升光幕保护框.TabIndex = 1;
            this.平台上升光幕保护框.Text = "平台上升光幕保护";
            this.平台上升光幕保护框.UseVisualStyleBackColor = true;
            // 
            // 测试界面显示机器电压框
            // 
            this.测试界面显示机器电压框.AutoSize = true;
            this.测试界面显示机器电压框.Checked = true;
            this.测试界面显示机器电压框.CheckState = System.Windows.Forms.CheckState.Checked;
            this.测试界面显示机器电压框.Location = new System.Drawing.Point(20, 75);
            this.测试界面显示机器电压框.Name = "测试界面显示机器电压框";
            this.测试界面显示机器电压框.Size = new System.Drawing.Size(172, 21);
            this.测试界面显示机器电压框.TabIndex = 2;
            this.测试界面显示机器电压框.Text = "测试界面显示机器电压";
            this.测试界面显示机器电压框.UseVisualStyleBackColor = true;
            // 
            // NG授权管理框
            // 
            this.NG授权管理框.AutoSize = true;
            this.NG授权管理框.Location = new System.Drawing.Point(20, 100);
            this.NG授权管理框.Name = "NG授权管理框";
            this.NG授权管理框.Size = new System.Drawing.Size(104, 21);
            this.NG授权管理框.TabIndex = 3;
            this.NG授权管理框.Text = "NG授权管理";
            this.NG授权管理框.UseVisualStyleBackColor = true;
            // 
            // 安全门框
            // 
            this.安全门框.AutoSize = true;
            this.安全门框.Location = new System.Drawing.Point(200, 25);
            this.安全门框.Name = "安全门框";
            this.安全门框.Size = new System.Drawing.Size(68, 21);
            this.安全门框.TabIndex = 4;
            this.安全门框.Text = "安全门";
            this.安全门框.UseVisualStyleBackColor = true;
            // 
            // 显示环境温度湿度框
            // 
            this.显示环境温度湿度框.AutoSize = true;
            this.显示环境温度湿度框.Location = new System.Drawing.Point(200, 50);
            this.显示环境温度湿度框.Name = "显示环境温度湿度框";
            this.显示环境温度湿度框.Size = new System.Drawing.Size(148, 21);
            this.显示环境温度湿度框.TabIndex = 5;
            this.显示环境温度湿度框.Text = "显示环境温度湿度";
            this.显示环境温度湿度框.UseVisualStyleBackColor = true;
            // 
            // 开机自动运行框
            // 
            this.开机自动运行框.AutoSize = true;
            this.开机自动运行框.Location = new System.Drawing.Point(200, 75);
            this.开机自动运行框.Name = "开机自动运行框";
            this.开机自动运行框.Size = new System.Drawing.Size(104, 21);
            this.开机自动运行框.TabIndex = 6;
            this.开机自动运行框.Text = "开机自动运行";
            this.开机自动运行框.UseVisualStyleBackColor = true;
            // 
            // 全局量程框
            // 
            this.全局量程框.AutoSize = true;
            this.全局量程框.Location = new System.Drawing.Point(200, 100);
            this.全局量程框.Name = "全局量程框";
            this.全局量程框.Size = new System.Drawing.Size(80, 21);
            this.全局量程框.TabIndex = 7;
            this.全局量程框.Text = "全局量程";
            this.全局量程框.UseVisualStyleBackColor = true;
            // 
            // 基础参数控件
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.基础设置组);
            this.Controls.Add(this.程控电源组);
            this.Controls.Add(this.串口设置组);
            this.Controls.Add(this.测试设置组);
            this.Name = "基础参数控件";
            this.Size = new System.Drawing.Size(1200, 500);
            ((System.ComponentModel.ISupportInitialize)(this.端口框)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.电流框)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.频率框)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.电压框)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.程控波特率框)).EndInit();
            this.测试设置组.ResumeLayout(false);
            this.测试设置组.PerformLayout();
            this.串口设置组.ResumeLayout(false);
            this.串口设置组.PerformLayout();
            this.程控电源组.ResumeLayout(false);
            this.程控电源组.PerformLayout();
            this.基础设置组.ResumeLayout(false);
            this.基础设置组.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.CheckBox NG授权管理框;
        private System.Windows.Forms.CheckBox 测试界面显示机器电压框;
        private System.Windows.Forms.CheckBox 平台上升光幕保护框;
        private System.Windows.Forms.CheckBox 平台下降光幕保护框;
    }
}