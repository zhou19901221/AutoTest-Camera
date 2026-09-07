namespace 自动测试
{
    partial class 一迈电源设置窗体
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            电源?.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            通讯组 = new GroupBox();
            端口标签 = new Label();
            端口框 = new ComboBox();
            波特率标签 = new Label();
            波特率框 = new ComboBox();
            连接按钮 = new Button();
            断开按钮 = new Button();
            通讯状态标签 = new Label();
            电源状态组 = new GroupBox();
            电源控制组 = new GroupBox();
            控制提示标签 = new Label();
            启动电源按钮 = new Button();
            停止电源按钮 = new Button();
            远程控制按钮 = new Button();
            本地控制按钮 = new Button();
            蜂鸣器勾选 = new CheckBox();
            P1勾选 = new CheckBox();
            P2勾选 = new CheckBox();
            P3勾选 = new CheckBox();
            P4勾选 = new CheckBox();
            应用控制按钮 = new Button();
            控制字标签 = new Label();
            输出设置组 = new GroupBox();
            电压设置标签 = new Label();
            电压设置框 = new NumericUpDown();
            电压单位标签 = new Label();
            电流设置标签 = new Label();
            电流设置框 = new NumericUpDown();
            电流单位标签 = new Label();
            功率设置标签 = new Label();
            功率设置框 = new NumericUpDown();
            功率单位标签 = new Label();
            写入输出按钮 = new Button();
            PWM设置组 = new GroupBox();
            PWM周期标签 = new Label();
            PWM周期框 = new NumericUpDown();
            开通1标签 = new Label();
            开通1框 = new NumericUpDown();
            开通2标签 = new Label();
            开通2框 = new NumericUpDown();
            写入PWM按钮 = new Button();
            通信保护组 = new GroupBox();
            过压保护标签 = new Label();
            过压保护框 = new NumericUpDown();
            过压单位标签 = new Label();
            过流保护标签 = new Label();
            过流保护框 = new NumericUpDown();
            过流单位标签 = new Label();
            默认限压标签 = new Label();
            默认限压框 = new NumericUpDown();
            限压单位标签 = new Label();
            默认限流标签 = new Label();
            默认限流框 = new NumericUpDown();
            限流单位标签 = new Label();
            读取参数按钮 = new Button();
            写入通信保护按钮 = new Button();
            通讯组.SuspendLayout();
            电源控制组.SuspendLayout();
            输出设置组.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)电压设置框).BeginInit();
            ((System.ComponentModel.ISupportInitialize)电流设置框).BeginInit();
            ((System.ComponentModel.ISupportInitialize)功率设置框).BeginInit();
            PWM设置组.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PWM周期框).BeginInit();
            ((System.ComponentModel.ISupportInitialize)开通1框).BeginInit();
            ((System.ComponentModel.ISupportInitialize)开通2框).BeginInit();
            通信保护组.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)过压保护框).BeginInit();
            ((System.ComponentModel.ISupportInitialize)过流保护框).BeginInit();
            ((System.ComponentModel.ISupportInitialize)默认限压框).BeginInit();
            ((System.ComponentModel.ISupportInitialize)默认限流框).BeginInit();
            SuspendLayout();
            // 
            // 通讯组
            // 
            通讯组.Controls.Add(端口标签);
            通讯组.Controls.Add(端口框);
            通讯组.Controls.Add(波特率标签);
            通讯组.Controls.Add(波特率框);
            通讯组.Controls.Add(连接按钮);
            通讯组.Controls.Add(断开按钮);
            通讯组.Controls.Add(通讯状态标签);
            通讯组.Location = new Point(20, 15);
            通讯组.Name = "通讯组";
            通讯组.Size = new Size(1080, 65);
            通讯组.TabIndex = 0;
            通讯组.TabStop = false;
            通讯组.Text = "通讯连接";
            // 
            // 端口标签
            // 
            端口标签.AutoSize = true;
            端口标签.Location = new Point(20, 27);
            端口标签.Name = "端口标签";
            端口标签.Size = new Size(44, 17);
            端口标签.TabIndex = 0;
            端口标签.Text = "端口：";
            // 
            // 端口框
            // 
            端口框.DropDownStyle = ComboBoxStyle.DropDownList;
            端口框.Location = new Point(70, 24);
            端口框.Name = "端口框";
            端口框.Size = new Size(100, 25);
            端口框.TabIndex = 1;
            // 
            // 波特率标签
            // 
            波特率标签.AutoSize = true;
            波特率标签.Location = new Point(180, 27);
            波特率标签.Name = "波特率标签";
            波特率标签.Size = new Size(56, 17);
            波特率标签.TabIndex = 2;
            波特率标签.Text = "波特率：";
            // 
            // 波特率框
            // 
            波特率框.DropDownStyle = ComboBoxStyle.DropDownList;
            波特率框.FormattingEnabled = true;
            波特率框.Items.AddRange(new object[] { "9600", "19200", "38400", "57600", "115200" });
            波特率框.Location = new Point(250, 24);
            波特率框.Name = "波特率框";
            波特率框.Size = new Size(100, 25);
            波特率框.TabIndex = 3;
            // 
            // 连接按钮
            // 
            连接按钮.Location = new Point(390, 22);
            连接按钮.Name = "连接按钮";
            连接按钮.Size = new Size(90, 30);
            连接按钮.TabIndex = 4;
            连接按钮.Text = "连接";
            连接按钮.UseVisualStyleBackColor = true;
            连接按钮.Click += 连接按钮_Click;
            // 
            // 断开按钮
            // 
            断开按钮.Location = new Point(495, 22);
            断开按钮.Name = "断开按钮";
            断开按钮.Size = new Size(90, 30);
            断开按钮.TabIndex = 5;
            断开按钮.Text = "断开";
            断开按钮.UseVisualStyleBackColor = true;
            断开按钮.Click += 断开按钮_Click;
            // 
            // 通讯状态标签
            // 
            通讯状态标签.AutoSize = true;
            通讯状态标签.ForeColor = Color.Red;
            通讯状态标签.Location = new Point(620, 28);
            通讯状态标签.Name = "通讯状态标签";
            通讯状态标签.Size = new Size(44, 17);
            通讯状态标签.TabIndex = 6;
            通讯状态标签.Text = "未连接";
            // 
            // 电源状态组
            // 
            电源状态组.Location = new Point(20, 95);
            电源状态组.Name = "电源状态组";
            电源状态组.Size = new Size(560, 525);
            电源状态组.TabIndex = 1;
            电源状态组.TabStop = false;
            电源状态组.Text = "电源状态";
            // 
            // 电源控制组
            // 
            电源控制组.Controls.Add(控制提示标签);
            电源控制组.Controls.Add(启动电源按钮);
            电源控制组.Controls.Add(停止电源按钮);
            电源控制组.Controls.Add(远程控制按钮);
            电源控制组.Controls.Add(本地控制按钮);
            电源控制组.Controls.Add(蜂鸣器勾选);
            电源控制组.Controls.Add(P1勾选);
            电源控制组.Controls.Add(P2勾选);
            电源控制组.Controls.Add(P3勾选);
            电源控制组.Controls.Add(P4勾选);
            电源控制组.Controls.Add(应用控制按钮);
            电源控制组.Controls.Add(控制字标签);
            电源控制组.Location = new Point(600, 95);
            电源控制组.Name = "电源控制组";
            电源控制组.Size = new Size(500, 220);
            电源控制组.TabIndex = 2;
            电源控制组.TabStop = false;
            电源控制组.Text = "电源控制";
            // 
            // 控制提示标签
            // 
            控制提示标签.AutoSize = true;
            控制提示标签.ForeColor = Color.Gray;
            控制提示标签.Location = new Point(20, 28);
            控制提示标签.Name = "控制提示标签";
            控制提示标签.Size = new Size(287, 17);
            控制提示标签.TabIndex = 0;
            控制提示标签.Text = "启动/停止/远程/本地立即生效，勾选项点击应用生效";
            // 
            // 启动电源按钮
            // 
            启动电源按钮.Location = new Point(20, 55);
            启动电源按钮.Name = "启动电源按钮";
            启动电源按钮.Size = new Size(110, 35);
            启动电源按钮.TabIndex = 1;
            启动电源按钮.Text = "启动电源";
            启动电源按钮.UseVisualStyleBackColor = true;
            启动电源按钮.Click += 启动电源按钮_Click;
            // 
            // 停止电源按钮
            // 
            停止电源按钮.Location = new Point(150, 55);
            停止电源按钮.Name = "停止电源按钮";
            停止电源按钮.Size = new Size(110, 35);
            停止电源按钮.TabIndex = 2;
            停止电源按钮.Text = "停止电源";
            停止电源按钮.UseVisualStyleBackColor = true;
            停止电源按钮.Click += 停止电源按钮_Click;
            // 
            // 远程控制按钮
            // 
            远程控制按钮.Location = new Point(280, 55);
            远程控制按钮.Name = "远程控制按钮";
            远程控制按钮.Size = new Size(100, 35);
            远程控制按钮.TabIndex = 3;
            远程控制按钮.Text = "远程控制";
            远程控制按钮.UseVisualStyleBackColor = true;
            远程控制按钮.Click += 远程控制按钮_Click;
            // 
            // 本地控制按钮
            // 
            本地控制按钮.Location = new Point(395, 55);
            本地控制按钮.Name = "本地控制按钮";
            本地控制按钮.Size = new Size(85, 35);
            本地控制按钮.TabIndex = 4;
            本地控制按钮.Text = "本地控制";
            本地控制按钮.UseVisualStyleBackColor = true;
            本地控制按钮.Click += 本地控制按钮_Click;
            // 
            // 蜂鸣器勾选
            // 
            蜂鸣器勾选.AutoSize = true;
            蜂鸣器勾选.Location = new Point(20, 108);
            蜂鸣器勾选.Name = "蜂鸣器勾选";
            蜂鸣器勾选.Size = new Size(63, 21);
            蜂鸣器勾选.TabIndex = 5;
            蜂鸣器勾选.Text = "蜂鸣器";
            蜂鸣器勾选.UseVisualStyleBackColor = true;
            // 
            // P1勾选
            // 
            P1勾选.AutoSize = true;
            P1勾选.Location = new Point(120, 108);
            P1勾选.Name = "P1勾选";
            P1勾选.Size = new Size(41, 21);
            P1勾选.TabIndex = 6;
            P1勾选.Text = "P1";
            P1勾选.UseVisualStyleBackColor = true;
            // 
            // P2勾选
            // 
            P2勾选.AutoSize = true;
            P2勾选.Location = new Point(195, 108);
            P2勾选.Name = "P2勾选";
            P2勾选.Size = new Size(41, 21);
            P2勾选.TabIndex = 7;
            P2勾选.Text = "P2";
            P2勾选.UseVisualStyleBackColor = true;
            // 
            // P3勾选
            // 
            P3勾选.AutoSize = true;
            P3勾选.Location = new Point(270, 108);
            P3勾选.Name = "P3勾选";
            P3勾选.Size = new Size(41, 21);
            P3勾选.TabIndex = 8;
            P3勾选.Text = "P3";
            P3勾选.UseVisualStyleBackColor = true;
            // 
            // P4勾选
            // 
            P4勾选.AutoSize = true;
            P4勾选.Location = new Point(345, 108);
            P4勾选.Name = "P4勾选";
            P4勾选.Size = new Size(41, 21);
            P4勾选.TabIndex = 9;
            P4勾选.Text = "P4";
            P4勾选.UseVisualStyleBackColor = true;
            // 
            // 应用控制按钮
            // 
            应用控制按钮.Location = new Point(20, 145);
            应用控制按钮.Name = "应用控制按钮";
            应用控制按钮.Size = new Size(110, 32);
            应用控制按钮.TabIndex = 10;
            应用控制按钮.Text = "应用勾选项";
            应用控制按钮.UseVisualStyleBackColor = true;
            应用控制按钮.Click += 应用控制按钮_Click;
            // 
            // 控制字标签
            // 
            控制字标签.AutoSize = true;
            控制字标签.ForeColor = Color.Gray;
            控制字标签.Location = new Point(160, 152);
            控制字标签.Name = "控制字标签";
            控制字标签.Size = new Size(67, 17);
            控制字标签.TabIndex = 11;
            控制字标签.Text = "控制字:----";
            // 
            // 输出设置组
            // 
            输出设置组.Controls.Add(电压设置标签);
            输出设置组.Controls.Add(电压设置框);
            输出设置组.Controls.Add(电压单位标签);
            输出设置组.Controls.Add(电流设置标签);
            输出设置组.Controls.Add(电流设置框);
            输出设置组.Controls.Add(电流单位标签);
            输出设置组.Controls.Add(功率设置标签);
            输出设置组.Controls.Add(功率设置框);
            输出设置组.Controls.Add(功率单位标签);
            输出设置组.Controls.Add(写入输出按钮);
            输出设置组.Location = new Point(600, 325);
            输出设置组.Name = "输出设置组";
            输出设置组.Size = new Size(500, 185);
            输出设置组.TabIndex = 3;
            输出设置组.TabStop = false;
            输出设置组.Text = "输出设置";
            // 
            // 电压设置标签
            // 
            电压设置标签.AutoSize = true;
            电压设置标签.Location = new Point(20, 35);
            电压设置标签.Name = "电压设置标签";
            电压设置标签.Size = new Size(68, 17);
            电压设置标签.TabIndex = 0;
            电压设置标签.Text = "输出电压：";
            // 
            // 电压设置框
            // 
            电压设置框.DecimalPlaces = 3;
            电压设置框.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            电压设置框.Location = new Point(110, 32);
            电压设置框.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            电压设置框.Name = "电压设置框";
            电压设置框.Size = new Size(110, 23);
            电压设置框.TabIndex = 1;
            // 
            // 电压单位标签
            // 
            电压单位标签.AutoSize = true;
            电压单位标签.Location = new Point(226, 35);
            电压单位标签.Name = "电压单位标签";
            电压单位标签.Size = new Size(16, 17);
            电压单位标签.TabIndex = 2;
            电压单位标签.Text = "V";
            // 
            // 电流设置标签
            // 
            电流设置标签.AutoSize = true;
            电流设置标签.Location = new Point(280, 35);
            电流设置标签.Name = "电流设置标签";
            电流设置标签.Size = new Size(68, 17);
            电流设置标签.TabIndex = 3;
            电流设置标签.Text = "输出电流：";
            // 
            // 电流设置框
            // 
            电流设置框.DecimalPlaces = 3;
            电流设置框.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            电流设置框.Location = new Point(370, 32);
            电流设置框.Name = "电流设置框";
            电流设置框.Size = new Size(110, 23);
            电流设置框.TabIndex = 4;
            // 
            // 电流单位标签
            // 
            电流单位标签.AutoSize = true;
            电流单位标签.Location = new Point(486, 35);
            电流单位标签.Name = "电流单位标签";
            电流单位标签.Size = new Size(16, 17);
            电流单位标签.TabIndex = 5;
            电流单位标签.Text = "A";
            // 
            // 功率设置标签
            // 
            功率设置标签.AutoSize = true;
            功率设置标签.Location = new Point(20, 75);
            功率设置标签.Name = "功率设置标签";
            功率设置标签.Size = new Size(68, 17);
            功率设置标签.TabIndex = 6;
            功率设置标签.Text = "限制功率：";
            // 
            // 功率设置框
            // 
            功率设置框.DecimalPlaces = 1;
            功率设置框.Location = new Point(110, 72);
            功率设置框.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            功率设置框.Name = "功率设置框";
            功率设置框.Size = new Size(110, 23);
            功率设置框.TabIndex = 7;
            // 
            // 功率单位标签
            // 
            功率单位标签.AutoSize = true;
            功率单位标签.Location = new Point(226, 75);
            功率单位标签.Name = "功率单位标签";
            功率单位标签.Size = new Size(20, 17);
            功率单位标签.TabIndex = 8;
            功率单位标签.Text = "W";
            // 
            // 写入输出按钮
            // 
            写入输出按钮.Location = new Point(280, 95);
            写入输出按钮.Name = "写入输出按钮";
            写入输出按钮.Size = new Size(120, 35);
            写入输出按钮.TabIndex = 9;
            写入输出按钮.Text = "写入输出设置";
            写入输出按钮.UseVisualStyleBackColor = true;
            写入输出按钮.Click += 写入输出按钮_Click;
            // 
            // PWM设置组
            // 
            PWM设置组.Controls.Add(PWM周期标签);
            PWM设置组.Controls.Add(PWM周期框);
            PWM设置组.Controls.Add(开通1标签);
            PWM设置组.Controls.Add(开通1框);
            PWM设置组.Controls.Add(开通2标签);
            PWM设置组.Controls.Add(开通2框);
            PWM设置组.Controls.Add(写入PWM按钮);
            PWM设置组.Location = new Point(600, 520);
            PWM设置组.Name = "PWM设置组";
            PWM设置组.Size = new Size(500, 100);
            PWM设置组.TabIndex = 4;
            PWM设置组.TabStop = false;
            PWM设置组.Text = "PWM设置(选配)";
            // 
            // PWM周期标签
            // 
            PWM周期标签.AutoSize = true;
            PWM周期标签.Location = new Point(20, 35);
            PWM周期标签.Name = "PWM周期标签";
            PWM周期标签.Size = new Size(75, 17);
            PWM周期标签.TabIndex = 0;
            PWM周期标签.Text = "PWM周期：";
            // 
            // PWM周期框
            // 
            PWM周期框.Location = new Point(110, 32);
            PWM周期框.Maximum = new decimal(new int[] { 429496729, 5, 0, 0 });
            PWM周期框.Name = "PWM周期框";
            PWM周期框.Size = new Size(110, 23);
            PWM周期框.TabIndex = 1;
            // 
            // 开通1标签
            // 
            开通1标签.AutoSize = true;
            开通1标签.Location = new Point(250, 35);
            开通1标签.Name = "开通1标签";
            开通1标签.Size = new Size(51, 17);
            开通1标签.TabIndex = 2;
            开通1标签.Text = "开通1：";
            // 
            // 开通1框
            // 
            开通1框.Location = new Point(315, 32);
            开通1框.Maximum = new decimal(new int[] { 429496729, 5, 0, 0 });
            开通1框.Name = "开通1框";
            开通1框.Size = new Size(110, 23);
            开通1框.TabIndex = 3;
            // 
            // 开通2标签
            // 
            开通2标签.AutoSize = true;
            开通2标签.Location = new Point(20, 68);
            开通2标签.Name = "开通2标签";
            开通2标签.Size = new Size(51, 17);
            开通2标签.TabIndex = 4;
            开通2标签.Text = "开通2：";
            // 
            // 开通2框
            // 
            开通2框.Location = new Point(110, 65);
            开通2框.Maximum = new decimal(new int[] { 429496729, 5, 0, 0 });
            开通2框.Name = "开通2框";
            开通2框.Size = new Size(110, 23);
            开通2框.TabIndex = 5;
            // 
            // 写入PWM按钮
            // 
            写入PWM按钮.Location = new Point(250, 62);
            写入PWM按钮.Name = "写入PWM按钮";
            写入PWM按钮.Size = new Size(130, 30);
            写入PWM按钮.TabIndex = 6;
            写入PWM按钮.Text = "写入PWM设置";
            写入PWM按钮.UseVisualStyleBackColor = true;
            写入PWM按钮.Click += 写入PWM按钮_Click;
            // 
            // 通信保护组
            // 
            通信保护组.Controls.Add(过压保护标签);
            通信保护组.Controls.Add(过压保护框);
            通信保护组.Controls.Add(过压单位标签);
            通信保护组.Controls.Add(过流保护标签);
            通信保护组.Controls.Add(过流保护框);
            通信保护组.Controls.Add(过流单位标签);
            通信保护组.Controls.Add(默认限压标签);
            通信保护组.Controls.Add(默认限压框);
            通信保护组.Controls.Add(限压单位标签);
            通信保护组.Controls.Add(默认限流标签);
            通信保护组.Controls.Add(默认限流框);
            通信保护组.Controls.Add(限流单位标签);
            通信保护组.Controls.Add(读取参数按钮);
            通信保护组.Controls.Add(写入通信保护按钮);
            通信保护组.Location = new Point(20, 640);
            通信保护组.Name = "通信保护组";
            通信保护组.Size = new Size(1080, 140);
            通信保护组.TabIndex = 5;
            通信保护组.TabStop = false;
            通信保护组.Text = "通信与保护设置";
            // 
            // 过压保护标签
            // 
            过压保护标签.AutoSize = true;
            过压保护标签.Location = new Point(471, 32);
            过压保护标签.Name = "过压保护标签";
            过压保护标签.Size = new Size(68, 17);
            过压保护标签.TabIndex = 4;
            过压保护标签.Text = "过压保护：";
            // 
            // 过压保护框
            // 
            过压保护框.DecimalPlaces = 3;
            过压保护框.Location = new Point(551, 29);
            过压保护框.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            过压保护框.Name = "过压保护框";
            过压保护框.Size = new Size(100, 23);
            过压保护框.TabIndex = 5;
            // 
            // 过压单位标签
            // 
            过压单位标签.AutoSize = true;
            过压单位标签.Location = new Point(657, 32);
            过压单位标签.Name = "过压单位标签";
            过压单位标签.Size = new Size(16, 17);
            过压单位标签.TabIndex = 6;
            过压单位标签.Text = "V";
            // 
            // 过流保护标签
            // 
            过流保护标签.AutoSize = true;
            过流保护标签.Location = new Point(695, 29);
            过流保护标签.Name = "过流保护标签";
            过流保护标签.Size = new Size(68, 17);
            过流保护标签.TabIndex = 7;
            过流保护标签.Text = "过流保护：";
            // 
            // 过流保护框
            // 
            过流保护框.DecimalPlaces = 3;
            过流保护框.Location = new Point(775, 26);
            过流保护框.Name = "过流保护框";
            过流保护框.Size = new Size(100, 23);
            过流保护框.TabIndex = 8;
            // 
            // 过流单位标签
            // 
            过流单位标签.AutoSize = true;
            过流单位标签.Location = new Point(881, 29);
            过流单位标签.Name = "过流单位标签";
            过流单位标签.Size = new Size(16, 17);
            过流单位标签.TabIndex = 9;
            过流单位标签.Text = "A";
            // 
            // 默认限压标签
            // 
            默认限压标签.AutoSize = true;
            默认限压标签.Location = new Point(6, 32);
            默认限压标签.Name = "默认限压标签";
            默认限压标签.Size = new Size(68, 17);
            默认限压标签.TabIndex = 10;
            默认限压标签.Text = "默认限压：";
            // 
            // 默认限压框
            // 
            默认限压框.DecimalPlaces = 3;
            默认限压框.Location = new Point(77, 29);
            默认限压框.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            默认限压框.Name = "默认限压框";
            默认限压框.Size = new Size(100, 23);
            默认限压框.TabIndex = 11;
            // 
            // 限压单位标签
            // 
            限压单位标签.AutoSize = true;
            限压单位标签.Location = new Point(182, 32);
            限压单位标签.Name = "限压单位标签";
            限压单位标签.Size = new Size(16, 17);
            限压单位标签.TabIndex = 12;
            限压单位标签.Text = "V";
            // 
            // 默认限流标签
            // 
            默认限流标签.AutoSize = true;
            默认限流标签.Location = new Point(225, 32);
            默认限流标签.Name = "默认限流标签";
            默认限流标签.Size = new Size(68, 17);
            默认限流标签.TabIndex = 13;
            默认限流标签.Text = "默认限流：";
            // 
            // 默认限流框
            // 
            默认限流框.DecimalPlaces = 3;
            默认限流框.Location = new Point(305, 29);
            默认限流框.Name = "默认限流框";
            默认限流框.Size = new Size(100, 23);
            默认限流框.TabIndex = 14;
            // 
            // 限流单位标签
            // 
            限流单位标签.AutoSize = true;
            限流单位标签.Location = new Point(411, 32);
            限流单位标签.Name = "限流单位标签";
            限流单位标签.Size = new Size(16, 17);
            限流单位标签.TabIndex = 15;
            限流单位标签.Text = "A";
            // 
            // 读取参数按钮
            // 
            读取参数按钮.Location = new Point(757, 92);
            读取参数按钮.Name = "读取参数按钮";
            读取参数按钮.Size = new Size(110, 32);
            读取参数按钮.TabIndex = 16;
            读取参数按钮.Text = "读取参数";
            读取参数按钮.UseVisualStyleBackColor = true;
            读取参数按钮.Click += 读取参数按钮_Click;
            // 
            // 写入通信保护按钮
            // 
            写入通信保护按钮.Location = new Point(887, 92);
            写入通信保护按钮.Name = "写入通信保护按钮";
            写入通信保护按钮.Size = new Size(140, 32);
            写入通信保护按钮.TabIndex = 17;
            写入通信保护按钮.Text = "写入通信与保护";
            写入通信保护按钮.UseVisualStyleBackColor = true;
            写入通信保护按钮.Click += 写入通信保护按钮_Click;
            // 
            // 一迈电源设置窗体
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 240, 240);
            ClientSize = new Size(1120, 800);
            Controls.Add(通信保护组);
            Controls.Add(PWM设置组);
            Controls.Add(输出设置组);
            Controls.Add(电源控制组);
            Controls.Add(电源状态组);
            Controls.Add(通讯组);
            Name = "一迈电源设置窗体";
            Text = "一迈YM600-Y60-L15 电源设置";
            FormClosing += 一迈电源设置窗体_FormClosing;
            通讯组.ResumeLayout(false);
            通讯组.PerformLayout();
            电源控制组.ResumeLayout(false);
            电源控制组.PerformLayout();
            输出设置组.ResumeLayout(false);
            输出设置组.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)电压设置框).EndInit();
            ((System.ComponentModel.ISupportInitialize)电流设置框).EndInit();
            ((System.ComponentModel.ISupportInitialize)功率设置框).EndInit();
            PWM设置组.ResumeLayout(false);
            PWM设置组.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PWM周期框).EndInit();
            ((System.ComponentModel.ISupportInitialize)开通1框).EndInit();
            ((System.ComponentModel.ISupportInitialize)开通2框).EndInit();
            通信保护组.ResumeLayout(false);
            通信保护组.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)过压保护框).EndInit();
            ((System.ComponentModel.ISupportInitialize)过流保护框).EndInit();
            ((System.ComponentModel.ISupportInitialize)默认限压框).EndInit();
            ((System.ComponentModel.ISupportInitialize)默认限流框).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox 通讯组;
        private System.Windows.Forms.Label 端口标签;
        private System.Windows.Forms.ComboBox 端口框;
        private System.Windows.Forms.Label 波特率标签;
        private System.Windows.Forms.ComboBox 波特率框;
        private System.Windows.Forms.Button 连接按钮;
        private System.Windows.Forms.Button 断开按钮;
        private System.Windows.Forms.Label 通讯状态标签;
        private System.Windows.Forms.GroupBox 电源状态组;
        private System.Windows.Forms.GroupBox 电源控制组;
        private System.Windows.Forms.Label 控制提示标签;
        private System.Windows.Forms.Button 启动电源按钮;
        private System.Windows.Forms.Button 停止电源按钮;
        private System.Windows.Forms.Button 远程控制按钮;
        private System.Windows.Forms.Button 本地控制按钮;
        private System.Windows.Forms.CheckBox 蜂鸣器勾选;
        private System.Windows.Forms.CheckBox P1勾选;
        private System.Windows.Forms.CheckBox P2勾选;
        private System.Windows.Forms.CheckBox P3勾选;
        private System.Windows.Forms.CheckBox P4勾选;
        private System.Windows.Forms.Button 应用控制按钮;
        private System.Windows.Forms.Label 控制字标签;
        private System.Windows.Forms.GroupBox 输出设置组;
        private System.Windows.Forms.Label 电压设置标签;
        private System.Windows.Forms.NumericUpDown 电压设置框;
        private System.Windows.Forms.Label 电压单位标签;
        private System.Windows.Forms.Label 电流设置标签;
        private System.Windows.Forms.NumericUpDown 电流设置框;
        private System.Windows.Forms.Label 电流单位标签;
        private System.Windows.Forms.Label 功率设置标签;
        private System.Windows.Forms.NumericUpDown 功率设置框;
        private System.Windows.Forms.Label 功率单位标签;
        private System.Windows.Forms.Button 写入输出按钮;
        private System.Windows.Forms.GroupBox PWM设置组;
        private System.Windows.Forms.Label PWM周期标签;
        private System.Windows.Forms.NumericUpDown PWM周期框;
        private System.Windows.Forms.Label 开通1标签;
        private System.Windows.Forms.NumericUpDown 开通1框;
        private System.Windows.Forms.Label 开通2标签;
        private System.Windows.Forms.NumericUpDown 开通2框;
        private System.Windows.Forms.Button 写入PWM按钮;
        private System.Windows.Forms.GroupBox 通信保护组;
        private System.Windows.Forms.Label 过压保护标签;
        private System.Windows.Forms.NumericUpDown 过压保护框;
        private System.Windows.Forms.Label 过压单位标签;
        private System.Windows.Forms.Label 过流保护标签;
        private System.Windows.Forms.NumericUpDown 过流保护框;
        private System.Windows.Forms.Label 过流单位标签;
        private System.Windows.Forms.Label 默认限压标签;
        private System.Windows.Forms.NumericUpDown 默认限压框;
        private System.Windows.Forms.Label 限压单位标签;
        private System.Windows.Forms.Label 默认限流标签;
        private System.Windows.Forms.NumericUpDown 默认限流框;
        private System.Windows.Forms.Label 限流单位标签;
        private System.Windows.Forms.Button 读取参数按钮;
        private System.Windows.Forms.Button 写入通信保护按钮;
    }
}