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
            标题标签 = new Label();
            机器类型标签 = new Label();
            测试时间标签 = new Label();
            信息标签 = new Label();
            查看调试图按钮 = new Button();
            测试记录按钮 = new Button();
            临时统计按钮 = new Button();
            返回按钮 = new Button();
            左侧面板 = new Panel();
            检测项表格 = new DataGridView();
            中部面板 = new Panel();
            图像显示区 = new PictureBox();
            控制按钮面板 = new Panel();
            显示大图按钮 = new Button();
            图像调试框 = new CheckBox();
            暂时静音框 = new CheckBox();
            参数设置按钮 = new Button();
            平台控制按钮 = new Button();
            端口状态按钮 = new Button();
            复位按钮 = new Button();
            当前配置标签 = new Label();
            测试控制面板 = new Panel();
            手动测试按钮 = new Button();
            开始测试按钮 = new Button();
            循环框 = new CheckBox();
            循环次数框 = new NumericUpDown();
            平台升降框 = new CheckBox();
            回工作点框 = new CheckBox();
            右侧面板 = new Panel();
            统计面板 = new GroupBox();
            总数标签 = new Label();
            OK数标签 = new Label();
            失败数标签 = new Label();
            通过率标签 = new Label();
            总数值标签 = new Label();
            OK值标签 = new Label();
            失败值标签 = new Label();
            通过率值标签 = new Label();
            板状态面板 = new GroupBox();
            板状态容器 = new TableLayoutPanel();
            日志面板 = new GroupBox();
            日志文本框 = new TextBox();
            顶部面板.SuspendLayout();
            左侧面板.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)检测项表格).BeginInit();
            中部面板.SuspendLayout();
            控制按钮面板.SuspendLayout();
            测试控制面板.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)循环次数框).BeginInit();
            右侧面板.SuspendLayout();
            统计面板.SuspendLayout();
            板状态面板.SuspendLayout();
            日志面板.SuspendLayout();
            SuspendLayout();
            // 
            // 顶部面板
            // 
            顶部面板.BackColor = Color.FromArgb(230, 230, 230);
            顶部面板.Controls.Add(返回按钮);
            顶部面板.Controls.Add(临时统计按钮);
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
            // 标题标签
            // 
            标题标签.AutoSize = true;
            标题标签.Font = new Font("Microsoft YaHei UI", 14F, FontStyle.Bold);
            标题标签.Location = new Point(15, 15);
            标题标签.Name = "标题标签";
            标题标签.Size = new Size(200, 30);
            标题标签.TabIndex = 0;
            标题标签.Text = "在线FCT测试系统";
            // 
            // 机器类型标签
            // 
            机器类型标签.AutoSize = true;
            机器类型标签.Font = new Font("Microsoft YaHei UI", 10F);
            机器类型标签.Location = new Point(240, 20);
            机器类型标签.Name = "机器类型标签";
            机器类型标签.Size = new Size(150, 23);
            机器类型标签.TabIndex = 1;
            机器类型标签.Text = "机器类型: 半自动FCT";
            // 
            // 测试时间标签
            // 
            测试时间标签.AutoSize = true;
            测试时间标签.Font = new Font("Microsoft YaHei UI", 10F);
            测试时间标签.Location = new Point(430, 20);
            测试时间标签.Name = "测试时间标签";
            测试时间标签.Size = new Size(120, 23);
            测试时间标签.TabIndex = 2;
            测试时间标签.Text = "测试时间: 0.000";
            // 
            // 信息标签
            // 
            信息标签.AutoSize = true;
            信息标签.Font = new Font("Microsoft YaHei UI", 10F);
            信息标签.ForeColor = Color.Red;
            信息标签.Location = new Point(600, 20);
            信息标签.Name = "信息标签";
            信息标签.Size = new Size(180, 23);
            信息标签.TabIndex = 3;
            信息标签.Text = "信息: PLC通讯错误!";
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
            // 测试记录按钮
            // 
            测试记录按钮.Location = new Point(1060, 12);
            测试记录按钮.Name = "测试记录按钮";
            测试记录按钮.Size = new Size(90, 36);
            测试记录按钮.TabIndex = 5;
            测试记录按钮.Text = "测试记录";
            测试记录按钮.UseVisualStyleBackColor = true;
            // 
            // 临时统计按钮
            // 
            临时统计按钮.Location = new Point(1160, 12);
            临时统计按钮.Name = "临时统计按钮";
            临时统计按钮.Size = new Size(90, 36);
            临时统计按钮.TabIndex = 6;
            临时统计按钮.Text = "临时统计";
            临时统计按钮.UseVisualStyleBackColor = true;
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
            中部面板.Controls.Add(测试控制面板);
            中部面板.Controls.Add(当前配置标签);
            中部面板.Controls.Add(控制按钮面板);
            中部面板.Controls.Add(图像显示区);
            中部面板.Location = new Point(490, 65);
            中部面板.Name = "中部面板";
            中部面板.Size = new Size(530, 830);
            中部面板.TabIndex = 2;
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
            // 显示大图按钮
            // 
            显示大图按钮.Location = new Point(5, 8);
            显示大图按钮.Name = "显示大图按钮";
            显示大图按钮.Size = new Size(75, 30);
            显示大图按钮.TabIndex = 0;
            显示大图按钮.Text = "显示大图";
            显示大图按钮.UseVisualStyleBackColor = true;
            // 
            // 图像调试框
            // 
            图像调试框.AutoSize = true;
            图像调试框.Location = new Point(90, 12);
            图像调试框.Name = "图像调试框";
            图像调试框.Size = new Size(80, 22);
            图像调试框.TabIndex = 1;
            图像调试框.Text = "图像调试";
            图像调试框.UseVisualStyleBackColor = true;
            // 
            // 暂时静音框
            // 
            暂时静音框.AutoSize = true;
            暂时静音框.Location = new Point(180, 12);
            暂时静音框.Name = "暂时静音框";
            暂时静音框.Size = new Size(80, 22);
            暂时静音框.TabIndex = 2;
            暂时静音框.Text = "暂时静音";
            暂时静音框.UseVisualStyleBackColor = true;
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
            // 平台控制按钮
            // 
            平台控制按钮.Location = new Point(355, 8);
            平台控制按钮.Name = "平台控制按钮";
            平台控制按钮.Size = new Size(75, 30);
            平台控制按钮.TabIndex = 4;
            平台控制按钮.Text = "平台控制";
            平台控制按钮.UseVisualStyleBackColor = true;
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
            // 当前配置标签
            // 
            当前配置标签.AutoSize = true;
            当前配置标签.Font = new Font("Microsoft YaHei UI", 10F);
            当前配置标签.ForeColor = Color.Blue;
            当前配置标签.Location = new Point(5, 470);
            当前配置标签.Name = "当前配置标签";
            当前配置标签.Size = new Size(200, 23);
            当前配置标签.TabIndex = 2;
            当前配置标签.Text = "当前配置: 未加载";
            // 
            // 测试控制面板
            // 
            测试控制面板.BackColor = Color.FromArgb(230, 230, 230);
            测试控制面板.Controls.Add(回工作点框);
            测试控制面板.Controls.Add(平台升降框);
            测试控制面板.Controls.Add(循环次数框);
            测试控制面板.Controls.Add(循环框);
            测试控制面板.Controls.Add(开始测试按钮);
            测试控制面板.Controls.Add(手动测试按钮);
            测试控制面板.Location = new Point(5, 500);
            测试控制面板.Name = "测试控制面板";
            测试控制面板.Size = new Size(520, 50);
            测试控制面板.TabIndex = 3;
            // 
            // 手动测试按钮
            // 
            手动测试按钮.BackColor = Color.FromArgb(43, 87, 154);
            手动测试按钮.FlatStyle = FlatStyle.Flat;
            手动测试按钮.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold);
            手动测试按钮.ForeColor = Color.White;
            手动测试按钮.Location = new Point(5, 8);
            手动测试按钮.Name = "手动测试按钮";
            手动测试按钮.Size = new Size(90, 35);
            手动测试按钮.TabIndex = 0;
            手动测试按钮.Text = "手动测试";
            手动测试按钮.UseVisualStyleBackColor = false;
            // 
            // 开始测试按钮
            // 
            开始测试按钮.BackColor = Color.FromArgb(0, 128, 0);
            开始测试按钮.FlatStyle = FlatStyle.Flat;
            开始测试按钮.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold);
            开始测试按钮.ForeColor = Color.White;
            开始测试按钮.Location = new Point(105, 8);
            开始测试按钮.Name = "开始测试按钮";
            开始测试按钮.Size = new Size(90, 35);
            开始测试按钮.TabIndex = 1;
            开始测试按钮.Text = "开始测试";
            开始测试按钮.UseVisualStyleBackColor = false;
            // 
            // 循环框
            // 
            循环框.AutoSize = true;
            循环框.Location = new Point(210, 14);
            循环框.Name = "循环框";
            循环框.Size = new Size(55, 22);
            循环框.TabIndex = 2;
            循环框.Text = "循环";
            循环框.UseVisualStyleBackColor = true;
            // 
            // 循环次数框
            // 
            循环次数框.Location = new Point(275, 12);
            循环次数框.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            循环次数框.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            循环次数框.Name = "循环次数框";
            循环次数框.Size = new Size(60, 23);
            循环次数框.TabIndex = 3;
            循环次数框.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // 平台升降框
            // 
            平台升降框.AutoSize = true;
            平台升降框.Location = new Point(350, 14);
            平台升降框.Name = "平台升降框";
            平台升降框.Size = new Size(80, 22);
            平台升降框.TabIndex = 4;
            平台升降框.Text = "平台升降";
            平台升降框.UseVisualStyleBackColor = true;
            // 
            // 回工作点框
            // 
            回工作点框.AutoSize = true;
            回工作点框.Location = new Point(440, 14);
            回工作点框.Name = "回工作点框";
            回工作点框.Size = new Size(80, 22);
            回工作点框.TabIndex = 5;
            回工作点框.Text = "回工作点";
            回工作点框.UseVisualStyleBackColor = true;
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
            // 总数标签
            // 
            总数标签.AutoSize = true;
            总数标签.Font = new Font("Microsoft YaHei UI", 10F);
            总数标签.Location = new Point(15, 30);
            总数标签.Name = "总数标签";
            总数标签.Size = new Size(60, 23);
            总数标签.TabIndex = 0;
            总数标签.Text = "Total:";
            // 
            // OK数标签
            // 
            OK数标签.AutoSize = true;
            OK数标签.Font = new Font("Microsoft YaHei UI", 10F);
            OK数标签.Location = new Point(15, 60);
            OK数标签.Name = "OK数标签";
            OK数标签.Size = new Size(40, 23);
            OK数标签.TabIndex = 1;
            OK数标签.Text = "OK:";
            // 
            // 失败数标签
            // 
            失败数标签.AutoSize = true;
            失败数标签.Font = new Font("Microsoft YaHei UI", 10F);
            失败数标签.ForeColor = Color.Red;
            失败数标签.Location = new Point(15, 90);
            失败数标签.Name = "失败数标签";
            失败数标签.Size = new Size(50, 23);
            失败数标签.TabIndex = 2;
            失败数标签.Text = "Fail:";
            // 
            // 通过率标签
            // 
            通过率标签.AutoSize = true;
            通过率标签.Font = new Font("Microsoft YaHei UI", 10F);
            通过率标签.Location = new Point(200, 30);
            通过率标签.Name = "通过率标签";
            通过率标签.Size = new Size(60, 23);
            通过率标签.TabIndex = 3;
            通过率标签.Text = "PASS:";
            // 
            // 总数值标签
            // 
            总数值标签.AutoSize = true;
            总数值标签.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold);
            总数值标签.Location = new Point(80, 28);
            总数值标签.Name = "总数值标签";
            总数值标签.Size = new Size(20, 25);
            总数值标签.TabIndex = 4;
            总数值标签.Text = "0";
            // 
            // OK值标签
            // 
            OK值标签.AutoSize = true;
            OK值标签.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold);
            OK值标签.ForeColor = Color.Green;
            OK值标签.Location = new Point(80, 58);
            OK值标签.Name = "OK值标签";
            OK值标签.Size = new Size(20, 25);
            OK值标签.TabIndex = 5;
            OK值标签.Text = "0";
            // 
            // 失败值标签
            // 
            失败值标签.AutoSize = true;
            失败值标签.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold);
            失败值标签.ForeColor = Color.Red;
            失败值标签.Location = new Point(80, 88);
            失败值标签.Name = "失败值标签";
            失败值标签.Size = new Size(20, 25);
            失败值标签.TabIndex = 6;
            失败值标签.Text = "0";
            // 
            // 通过率值标签
            // 
            通过率值标签.AutoSize = true;
            通过率值标签.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold);
            通过率值标签.ForeColor = Color.Blue;
            通过率值标签.Location = new Point(270, 28);
            通过率值标签.Name = "通过率值标签";
            通过率值标签.Size = new Size(70, 25);
            通过率值标签.TabIndex = 7;
            通过率值标签.Text = "0.00%";
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
            板状态容器.Location = new Point(10, 25);
            板状态容器.Name = "板状态容器";
            板状态容器.RowCount = 4;
            板状态容器.Size = new Size(380, 140);
            板状态容器.TabIndex = 0;
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
            控制按钮面板.ResumeLayout(false);
            控制按钮面板.PerformLayout();
            测试控制面板.ResumeLayout(false);
            测试控制面板.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)循环次数框).EndInit();
            右侧面板.ResumeLayout(false);
            统计面板.ResumeLayout(false);
            统计面板.PerformLayout();
            板状态面板.ResumeLayout(false);
            日志面板.ResumeLayout(false);
            日志面板.PerformLayout();
            ResumeLayout(false);
        }

        private Panel 顶部面板;
        private Label 标题标签;
        private Label 机器类型标签;
        private Label 测试时间标签;
        private Label 信息标签;
        private Button 查看调试图按钮;
        private Button 测试记录按钮;
        private Button 临时统计按钮;
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
        private CheckBox 循环框;
        private NumericUpDown 循环次数框;
        private CheckBox 平台升降框;
        private CheckBox 回工作点框;
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
    }
}
