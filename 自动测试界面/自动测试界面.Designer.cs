namespace 自动测试
{
    partial class 自动测试界面
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
            顶部面板 = new Panel();
            返回按钮 = new Button();
            测试记录按钮 = new Button();
            查看调试图按钮 = new Button();
            信息标签 = new Label();
            测试时间标签 = new Label();
            机器类型标签 = new Label();
            标题标签 = new Label();
            左侧面板 = new Panel();
            检测项表格 = new DataGridView();
            中部面板 = new Panel();
            测试控制面板 = new Panel();
            SN标签2 = new TextBox();
            开始测试按钮 = new Button();
            当前配置标签 = new Label();
            控制按钮面板 = new Panel();
            端口状态按钮 = new Button();
            平台控制按钮 = new Button();
            参数设置按钮 = new Button();
            暂时静音框 = new CheckBox();
            图像调试框 = new CheckBox();
            显示大图按钮 = new Button();
            手动测试按钮 = new Button();
            图像显示区 = new PictureBox();
            复位按钮 = new Button();
            右侧面板 = new Panel();
            日志面板 = new GroupBox();
            日志文本框 = new TextBox();
            板状态面板 = new GroupBox();
            板状态容器 = new TableLayoutPanel();
            统计面板 = new GroupBox();
            通过率值标签 = new Label();
            失败值标签 = new Label();
            OK值标签 = new Label();
            总数值标签 = new Label();
            通过率标签 = new Label();
            失败数标签 = new Label();
            OK数标签 = new Label();
            总数标签 = new Label();
            label1 = new Label();
            label2 = new Label();
            SN标签1 = new TextBox();
            label3 = new Label();
            SN标签3 = new TextBox();
            label4 = new Label();
            SN标签4 = new TextBox();
            label5 = new Label();
            SN标签5 = new TextBox();
            label6 = new Label();
            SN标签6 = new TextBox();
            label7 = new Label();
            SN标签7 = new TextBox();
            label8 = new Label();
            SN标签8 = new TextBox();
            顶部面板.SuspendLayout();
            左侧面板.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)检测项表格).BeginInit();
            中部面板.SuspendLayout();
            测试控制面板.SuspendLayout();
            控制按钮面板.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)图像显示区).BeginInit();
            右侧面板.SuspendLayout();
            日志面板.SuspendLayout();
            板状态面板.SuspendLayout();
            统计面板.SuspendLayout();
            SuspendLayout();
            // 
            // 顶部面板
            // 
            顶部面板.BackColor = Color.FromArgb(230, 230, 230);
            顶部面板.Controls.Add(返回按钮);
            顶部面板.Controls.Add(测试记录按钮);
            顶部面板.Controls.Add(查看调试图按钮);
            顶部面板.Controls.Add(信息标签);
            顶部面板.Controls.Add(测试时间标签);
            顶部面板.Controls.Add(机器类型标签);
            顶部面板.Controls.Add(标题标签);
            顶部面板.Dock = DockStyle.Top;
            顶部面板.Location = new Point(0, 0);
            顶部面板.Name = "顶部面板";
            顶部面板.Size = new Size(1440, 60);
            顶部面板.TabIndex = 0;
            // 
            // 返回按钮
            // 
            返回按钮.Location = new Point(1320, 12);
            返回按钮.Name = "返回按钮";
            返回按钮.Size = new Size(80, 36);
            返回按钮.TabIndex = 7;
            返回按钮.Text = "返回";
            返回按钮.UseVisualStyleBackColor = true;
            返回按钮.Click += 返回按钮_Click;
            // 
            // 测试记录按钮
            // 
            测试记录按钮.Location = new Point(1160, 12);
            测试记录按钮.Name = "测试记录按钮";
            测试记录按钮.Size = new Size(90, 36);
            测试记录按钮.TabIndex = 6;
            测试记录按钮.Text = "测试记录";
            测试记录按钮.UseVisualStyleBackColor = true;
            测试记录按钮.Click += 测试记录按钮_Click;
            // 
            // 查看调试图按钮
            // 
            查看调试图按钮.Location = new Point(950, 12);
            查看调试图按钮.Name = "查看调试图按钮";
            查看调试图按钮.Size = new Size(100, 36);
            查看调试图按钮.TabIndex = 4;
            查看调试图按钮.Text = "查看调试图";
            查看调试图按钮.UseVisualStyleBackColor = true;
            // 
            // 信息标签
            // 
            信息标签.AutoSize = true;
            信息标签.Font = new Font("Microsoft YaHei UI", 10F);
            信息标签.ForeColor = Color.Red;
            信息标签.Location = new Point(600, 20);
            信息标签.Name = "信息标签";
            信息标签.Size = new Size(129, 20);
            信息标签.TabIndex = 3;
            信息标签.Text = "信息: PLC通讯错误!";
            // 
            // 测试时间标签
            // 
            测试时间标签.AutoSize = true;
            测试时间标签.Font = new Font("Microsoft YaHei UI", 10F);
            测试时间标签.Location = new Point(430, 20);
            测试时间标签.Name = "测试时间标签";
            测试时间标签.Size = new Size(107, 20);
            测试时间标签.TabIndex = 2;
            测试时间标签.Text = "测试时间: 0.000";
            // 
            // 机器类型标签
            // 
            机器类型标签.AutoSize = true;
            机器类型标签.Font = new Font("Microsoft YaHei UI", 10F);
            机器类型标签.Location = new Point(240, 20);
            机器类型标签.Name = "机器类型标签";
            机器类型标签.Size = new Size(138, 20);
            机器类型标签.TabIndex = 1;
            机器类型标签.Text = "机器类型: 半自动FCT";
            // 
            // 标题标签
            // 
            标题标签.AutoSize = true;
            标题标签.Font = new Font("Microsoft YaHei UI", 14F, FontStyle.Bold);
            标题标签.Location = new Point(15, 15);
            标题标签.Name = "标题标签";
            标题标签.Size = new Size(162, 26);
            标题标签.TabIndex = 0;
            标题标签.Text = "在线FCT测试系统";
            // 
            // 左侧面板
            // 
            左侧面板.Controls.Add(检测项表格);
            左侧面板.Location = new Point(5, 65);
            左侧面板.Name = "左侧面板";
            左侧面板.Size = new Size(480, 830);
            左侧面板.TabIndex = 1;
            // 
            // 检测项表格
            // 
            检测项表格.AllowUserToAddRows = false;
            检测项表格.AllowUserToDeleteRows = false;
            检测项表格.AllowUserToResizeRows = false;
            检测项表格.BackgroundColor = Color.White;
            检测项表格.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            检测项表格.Dock = DockStyle.Fill;
            检测项表格.Location = new Point(0, 0);
            检测项表格.MultiSelect = false;
            检测项表格.Name = "检测项表格";
            检测项表格.ReadOnly = true;
            检测项表格.RowHeadersVisible = false;
            检测项表格.Size = new Size(480, 830);
            检测项表格.TabIndex = 0;
            // 
            // 中部面板
            // 
            中部面板.Controls.Add(SN标签1);
            中部面板.Controls.Add(SN标签8);
            中部面板.Controls.Add(SN标签7);
            中部面板.Controls.Add(SN标签6);
            中部面板.Controls.Add(label8);
            中部面板.Controls.Add(SN标签5);
            中部面板.Controls.Add(label7);
            中部面板.Controls.Add(SN标签4);
            中部面板.Controls.Add(label6);
            中部面板.Controls.Add(SN标签3);
            中部面板.Controls.Add(label5);
            中部面板.Controls.Add(SN标签2);
            中部面板.Controls.Add(label4);
            中部面板.Controls.Add(label2);
            中部面板.Controls.Add(label3);
            中部面板.Controls.Add(测试控制面板);
            中部面板.Controls.Add(label1);
            中部面板.Controls.Add(当前配置标签);
            中部面板.Controls.Add(控制按钮面板);
            中部面板.Controls.Add(图像显示区);
            中部面板.Location = new Point(490, 65);
            中部面板.Name = "中部面板";
            中部面板.Size = new Size(530, 830);
            中部面板.TabIndex = 2;
            // 
            // 测试控制面板
            // 
            测试控制面板.BackColor = Color.FromArgb(230, 230, 230);
            测试控制面板.Controls.Add(开始测试按钮);
            测试控制面板.Controls.Add(手动测试按钮);
            测试控制面板.Location = new Point(5, 500);
            测试控制面板.Name = "测试控制面板";
            测试控制面板.Size = new Size(520, 50);
            测试控制面板.TabIndex = 3;
            // 
            // SN标签2
            // 
            SN标签2.Location = new Point(41, 585);
            SN标签2.Name = "SN标签2";
            SN标签2.Size = new Size(178, 23);
            SN标签2.TabIndex = 7;
            // 
            // 开始测试按钮
            // 
            开始测试按钮.BackColor = Color.FromArgb(0, 128, 0);
            开始测试按钮.FlatStyle = FlatStyle.Flat;
            开始测试按钮.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold);
            开始测试按钮.ForeColor = Color.White;
            开始测试按钮.Location = new Point(5, 5);
            开始测试按钮.Name = "开始测试按钮";
            开始测试按钮.Size = new Size(90, 35);
            开始测试按钮.TabIndex = 1;
            开始测试按钮.Text = "开始测试";
            开始测试按钮.UseVisualStyleBackColor = false;
            开始测试按钮.Click += 开始测试按钮_Click;
            // 
            // 当前配置标签
            // 
            当前配置标签.AutoSize = true;
            当前配置标签.Font = new Font("Microsoft YaHei UI", 10F);
            当前配置标签.ForeColor = Color.Blue;
            当前配置标签.Location = new Point(5, 470);
            当前配置标签.Name = "当前配置标签";
            当前配置标签.Size = new Size(114, 20);
            当前配置标签.TabIndex = 2;
            当前配置标签.Text = "当前配置: 未加载";
            // 
            // 控制按钮面板
            // 
            控制按钮面板.BackColor = Color.FromArgb(230, 230, 230);
            控制按钮面板.Controls.Add(端口状态按钮);
            控制按钮面板.Controls.Add(平台控制按钮);
            控制按钮面板.Controls.Add(参数设置按钮);
            控制按钮面板.Controls.Add(暂时静音框);
            控制按钮面板.Controls.Add(图像调试框);
            控制按钮面板.Controls.Add(显示大图按钮);
            控制按钮面板.Location = new Point(5, 415);
            控制按钮面板.Name = "控制按钮面板";
            控制按钮面板.Size = new Size(520, 45);
            控制按钮面板.TabIndex = 1;
            // 
            // 端口状态按钮
            // 
            端口状态按钮.Location = new Point(440, 8);
            端口状态按钮.Name = "端口状态按钮";
            端口状态按钮.Size = new Size(75, 30);
            端口状态按钮.TabIndex = 5;
            端口状态按钮.Text = "端口状态";
            端口状态按钮.UseVisualStyleBackColor = true;
            // 
            // 平台控制按钮
            // 
            平台控制按钮.Location = new Point(355, 8);
            平台控制按钮.Name = "平台控制按钮";
            平台控制按钮.Size = new Size(75, 30);
            平台控制按钮.TabIndex = 4;
            平台控制按钮.Text = "平台控制";
            平台控制按钮.UseVisualStyleBackColor = true;
            // 
            // 参数设置按钮
            // 
            参数设置按钮.Location = new Point(270, 8);
            参数设置按钮.Name = "参数设置按钮";
            参数设置按钮.Size = new Size(75, 30);
            参数设置按钮.TabIndex = 3;
            参数设置按钮.Text = "参数设置";
            参数设置按钮.UseVisualStyleBackColor = true;
            // 
            // 暂时静音框
            // 
            暂时静音框.AutoSize = true;
            暂时静音框.Location = new Point(180, 12);
            暂时静音框.Name = "暂时静音框";
            暂时静音框.Size = new Size(75, 21);
            暂时静音框.TabIndex = 2;
            暂时静音框.Text = "暂时静音";
            暂时静音框.UseVisualStyleBackColor = true;
            // 
            // 图像调试框
            // 
            图像调试框.AutoSize = true;
            图像调试框.Location = new Point(90, 12);
            图像调试框.Name = "图像调试框";
            图像调试框.Size = new Size(75, 21);
            图像调试框.TabIndex = 1;
            图像调试框.Text = "图像调试";
            图像调试框.UseVisualStyleBackColor = true;
            // 
            // 显示大图按钮
            // 
            显示大图按钮.Location = new Point(5, 8);
            显示大图按钮.Name = "显示大图按钮";
            显示大图按钮.Size = new Size(75, 30);
            显示大图按钮.TabIndex = 0;
            显示大图按钮.Text = "显示大图";
            显示大图按钮.UseVisualStyleBackColor = true;
            // 
            // 手动测试按钮
            // 
            手动测试按钮.BackColor = Color.FromArgb(43, 87, 154);
            手动测试按钮.FlatStyle = FlatStyle.Flat;
            手动测试按钮.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold);
            手动测试按钮.ForeColor = Color.White;
            手动测试按钮.Location = new Point(303, 5);
            手动测试按钮.Name = "手动测试按钮";
            手动测试按钮.Size = new Size(90, 35);
            手动测试按钮.TabIndex = 0;
            手动测试按钮.Text = "手动测试";
            手动测试按钮.UseVisualStyleBackColor = false;
            // 
            // 图像显示区
            // 
            图像显示区.BackColor = Color.Black;
            图像显示区.Location = new Point(5, 5);
            图像显示区.Name = "图像显示区";
            图像显示区.Size = new Size(520, 400);
            图像显示区.TabIndex = 0;
            图像显示区.TabStop = false;
            // 
            // 复位按钮
            // 
            复位按钮.Location = new Point(0, 0);
            复位按钮.Name = "复位按钮";
            复位按钮.Size = new Size(75, 23);
            复位按钮.TabIndex = 0;
            // 
            // 右侧面板
            // 
            右侧面板.Controls.Add(日志面板);
            右侧面板.Controls.Add(板状态面板);
            右侧面板.Controls.Add(统计面板);
            右侧面板.Location = new Point(1025, 65);
            右侧面板.Name = "右侧面板";
            右侧面板.Size = new Size(410, 830);
            右侧面板.TabIndex = 3;
            // 
            // 日志面板
            // 
            日志面板.Controls.Add(日志文本框);
            日志面板.Location = new Point(5, 325);
            日志面板.Name = "日志面板";
            日志面板.Size = new Size(400, 500);
            日志面板.TabIndex = 2;
            日志面板.TabStop = false;
            日志面板.Text = "操作日志";
            // 
            // 日志文本框
            // 
            日志文本框.BackColor = Color.White;
            日志文本框.Dock = DockStyle.Fill;
            日志文本框.Location = new Point(3, 19);
            日志文本框.Multiline = true;
            日志文本框.Name = "日志文本框";
            日志文本框.ReadOnly = true;
            日志文本框.ScrollBars = ScrollBars.Vertical;
            日志文本框.Size = new Size(394, 478);
            日志文本框.TabIndex = 0;
            // 
            // 板状态面板
            // 
            板状态面板.Controls.Add(板状态容器);
            板状态面板.Location = new Point(5, 135);
            板状态面板.Name = "板状态面板";
            板状态面板.Size = new Size(400, 180);
            板状态面板.TabIndex = 1;
            板状态面板.TabStop = false;
            板状态面板.Text = "板测试状态";
            // 
            // 板状态容器
            // 
            板状态容器.BackColor = Color.White;
            板状态容器.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            板状态容器.ColumnCount = 8;
            板状态容器.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            板状态容器.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            板状态容器.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            板状态容器.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            板状态容器.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            板状态容器.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            板状态容器.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            板状态容器.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            板状态容器.Location = new Point(10, 25);
            板状态容器.Name = "板状态容器";
            板状态容器.RowCount = 4;
            板状态容器.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            板状态容器.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            板状态容器.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            板状态容器.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            板状态容器.Size = new Size(380, 140);
            板状态容器.TabIndex = 0;
            // 
            // 统计面板
            // 
            统计面板.Controls.Add(通过率值标签);
            统计面板.Controls.Add(失败值标签);
            统计面板.Controls.Add(OK值标签);
            统计面板.Controls.Add(总数值标签);
            统计面板.Controls.Add(通过率标签);
            统计面板.Controls.Add(失败数标签);
            统计面板.Controls.Add(OK数标签);
            统计面板.Controls.Add(总数标签);
            统计面板.Location = new Point(5, 5);
            统计面板.Name = "统计面板";
            统计面板.Size = new Size(400, 120);
            统计面板.TabIndex = 0;
            统计面板.TabStop = false;
            统计面板.Text = "测试统计";
            // 
            // 通过率值标签
            // 
            通过率值标签.AutoSize = true;
            通过率值标签.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold);
            通过率值标签.ForeColor = Color.Blue;
            通过率值标签.Location = new Point(270, 28);
            通过率值标签.Name = "通过率值标签";
            通过率值标签.Size = new Size(60, 22);
            通过率值标签.TabIndex = 7;
            通过率值标签.Text = "0.00%";
            // 
            // 失败值标签
            // 
            失败值标签.AutoSize = true;
            失败值标签.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold);
            失败值标签.ForeColor = Color.Red;
            失败值标签.Location = new Point(80, 88);
            失败值标签.Name = "失败值标签";
            失败值标签.Size = new Size(20, 22);
            失败值标签.TabIndex = 6;
            失败值标签.Text = "0";
            // 
            // OK值标签
            // 
            OK值标签.AutoSize = true;
            OK值标签.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold);
            OK值标签.ForeColor = Color.Green;
            OK值标签.Location = new Point(80, 58);
            OK值标签.Name = "OK值标签";
            OK值标签.Size = new Size(20, 22);
            OK值标签.TabIndex = 5;
            OK值标签.Text = "0";
            // 
            // 总数值标签
            // 
            总数值标签.AutoSize = true;
            总数值标签.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold);
            总数值标签.Location = new Point(80, 28);
            总数值标签.Name = "总数值标签";
            总数值标签.Size = new Size(20, 22);
            总数值标签.TabIndex = 4;
            总数值标签.Text = "0";
            // 
            // 通过率标签
            // 
            通过率标签.AutoSize = true;
            通过率标签.Font = new Font("Microsoft YaHei UI", 10F);
            通过率标签.Location = new Point(200, 30);
            通过率标签.Name = "通过率标签";
            通过率标签.Size = new Size(47, 20);
            通过率标签.TabIndex = 3;
            通过率标签.Text = "PASS:";
            // 
            // 失败数标签
            // 
            失败数标签.AutoSize = true;
            失败数标签.Font = new Font("Microsoft YaHei UI", 10F);
            失败数标签.ForeColor = Color.Red;
            失败数标签.Location = new Point(15, 90);
            失败数标签.Name = "失败数标签";
            失败数标签.Size = new Size(35, 20);
            失败数标签.TabIndex = 2;
            失败数标签.Text = "Fail:";
            // 
            // OK数标签
            // 
            OK数标签.AutoSize = true;
            OK数标签.Font = new Font("Microsoft YaHei UI", 10F);
            OK数标签.Location = new Point(15, 60);
            OK数标签.Name = "OK数标签";
            OK数标签.Size = new Size(32, 20);
            OK数标签.TabIndex = 1;
            OK数标签.Text = "OK:";
            // 
            // 总数标签
            // 
            总数标签.AutoSize = true;
            总数标签.Font = new Font("Microsoft YaHei UI", 10F);
            总数标签.Location = new Point(15, 30);
            总数标签.Name = "总数标签";
            总数标签.Size = new Size(46, 20);
            总数标签.TabIndex = 0;
            总数标签.Text = "Total:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 588);
            label1.Name = "label1";
            label1.Size = new Size(25, 17);
            label1.TabIndex = 6;
            label1.Text = "SN";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 559);
            label2.Name = "label2";
            label2.Size = new Size(25, 17);
            label2.TabIndex = 6;
            label2.Text = "SN";
            // 
            // SN标签1
            // 
            SN标签1.Location = new Point(41, 556);
            SN标签1.Name = "SN标签1";
            SN标签1.Size = new Size(178, 23);
            SN标签1.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 617);
            label3.Name = "label3";
            label3.Size = new Size(25, 17);
            label3.TabIndex = 6;
            label3.Text = "SN";
            // 
            // SN标签3
            // 
            SN标签3.Location = new Point(41, 614);
            SN标签3.Name = "SN标签3";
            SN标签3.Size = new Size(178, 23);
            SN标签3.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 646);
            label4.Name = "label4";
            label4.Size = new Size(25, 17);
            label4.TabIndex = 6;
            label4.Text = "SN";
            // 
            // SN标签4
            // 
            SN标签4.Location = new Point(41, 643);
            SN标签4.Name = "SN标签4";
            SN标签4.Size = new Size(178, 23);
            SN标签4.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 675);
            label5.Name = "label5";
            label5.Size = new Size(25, 17);
            label5.TabIndex = 6;
            label5.Text = "SN";
            // 
            // SN标签5
            // 
            SN标签5.Location = new Point(41, 672);
            SN标签5.Name = "SN标签5";
            SN标签5.Size = new Size(178, 23);
            SN标签5.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(10, 704);
            label6.Name = "label6";
            label6.Size = new Size(25, 17);
            label6.TabIndex = 6;
            label6.Text = "SN";
            // 
            // SN标签6
            // 
            SN标签6.Location = new Point(41, 701);
            SN标签6.Name = "SN标签6";
            SN标签6.Size = new Size(178, 23);
            SN标签6.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(10, 733);
            label7.Name = "label7";
            label7.Size = new Size(25, 17);
            label7.TabIndex = 6;
            label7.Text = "SN";
            // 
            // SN标签7
            // 
            SN标签7.Location = new Point(41, 730);
            SN标签7.Name = "SN标签7";
            SN标签7.Size = new Size(178, 23);
            SN标签7.TabIndex = 7;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(10, 762);
            label8.Name = "label8";
            label8.Size = new Size(25, 17);
            label8.TabIndex = 6;
            label8.Text = "SN";
            // 
            // SN标签8
            // 
            SN标签8.Location = new Point(41, 759);
            SN标签8.Name = "SN标签8";
            SN标签8.Size = new Size(178, 23);
            SN标签8.TabIndex = 7;
            // 
            // 自动测试界面
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(232, 232, 232);
            ClientSize = new Size(1440, 900);
            Controls.Add(右侧面板);
            Controls.Add(中部面板);
            Controls.Add(左侧面板);
            Controls.Add(顶部面板);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "自动测试界面";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "在线FCT测试系统";
            顶部面板.ResumeLayout(false);
            顶部面板.PerformLayout();
            左侧面板.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)检测项表格).EndInit();
            中部面板.ResumeLayout(false);
            中部面板.PerformLayout();
            测试控制面板.ResumeLayout(false);
            控制按钮面板.ResumeLayout(false);
            控制按钮面板.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)图像显示区).EndInit();
            右侧面板.ResumeLayout(false);
            日志面板.ResumeLayout(false);
            日志面板.PerformLayout();
            板状态面板.ResumeLayout(false);
            统计面板.ResumeLayout(false);
            统计面板.PerformLayout();
            ResumeLayout(false);
        }

        private Panel 顶部面板;
        private Label 标题标签;
        private Label 机器类型标签;
        private Label 测试时间标签;
        private Label 信息标签;
        private Button 查看调试图按钮;
        private Button 测试记录按钮;
        private Button 返回按钮;
        private Panel 左侧面板;
        private DataGridView 检测项表格;
        private Panel 中部面板;
        private PictureBox 图像显示区;
        private Panel 控制按钮面板;
        private Button 显示大图按钮;
        private CheckBox 图像调试框;
        private CheckBox 暂时静音框;
        private Button 参数设置按钮;
        private Button 平台控制按钮;
        private Button 端口状态按钮;
        private Button 复位按钮;
        private Label 当前配置标签;
        private Panel 测试控制面板;
        private Button 手动测试按钮;
        private Button 开始测试按钮;
        private TextBox SN标签2;
        private Panel 右侧面板;
        private GroupBox 统计面板;
        private Label 总数标签;
        private Label OK数标签;
        private Label 失败数标签;
        private Label 通过率标签;
        private Label 总数值标签;
        private Label OK值标签;
        private Label 失败值标签;
        private Label 通过率值标签;
        private GroupBox 板状态面板;
        private TableLayoutPanel 板状态容器;
        private GroupBox 日志面板;
        private TextBox 日志文本框;
        private TextBox SN标签1;
        private TextBox SN标签8;
        private TextBox SN标签7;
        private TextBox SN标签6;
        private Label label8;
        private TextBox SN标签5;
        private Label label7;
        private TextBox SN标签4;
        private Label label6;
        private TextBox SN标签3;
        private Label label5;
        private Label label4;
        private Label label2;
        private Label label3;
        private Label label1;
    }
}
