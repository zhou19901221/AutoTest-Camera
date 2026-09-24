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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(自动测试界面));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            返回按钮 = new Button();
            测试记录按钮 = new Button();
            信息标签 = new Label();
            测试时间标签 = new Label();
            标题标签 = new Label();
            左侧面板 = new Panel();
            检测项表格 = new DataGridView();
            SN标签1 = new TextBox();
            SN标签8 = new TextBox();
            SN标签7 = new TextBox();
            SN标签6 = new TextBox();
            label8 = new Label();
            开始测试按钮 = new Button();
            SN标签5 = new TextBox();
            label7 = new Label();
            SN标签4 = new TextBox();
            label6 = new Label();
            SN标签3 = new TextBox();
            label5 = new Label();
            SN标签2 = new TextBox();
            label4 = new Label();
            label2 = new Label();
            label3 = new Label();
            手动拼版输入框 = new TextBox();
            手动拼版勾选框 = new CheckBox();
            超时时间输入框 = new TextBox();
            超时时间标签 = new Label();
            超时勾选框 = new CheckBox();
            手动测试按钮 = new Button();
            label1 = new Label();
            当前配置标签 = new Label();
            端口状态按钮 = new Button();
            暂时静音框 = new CheckBox();
            显示大图按钮 = new Button();
            图像显示区 = new PictureBox();
            复位按钮 = new Button();
            日志面板 = new GroupBox();
            日志文本框 = new TextBox();
            统计面板 = new GroupBox();
            板状态面板 = new GroupBox();
            板状态容器 = new TableLayoutPanel();
            通过率值标签 = new Label();
            失败值标签 = new Label();
            OK值标签 = new Label();
            总数值标签 = new Label();
            通过率标签 = new Label();
            失败数标签 = new Label();
            OK数标签 = new Label();
            总数标签 = new Label();
            pictureBox1 = new PictureBox();
            左侧面板.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)检测项表格).BeginInit();
            ((System.ComponentModel.ISupportInitialize)图像显示区).BeginInit();
            日志面板.SuspendLayout();
            板状态面板.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // 返回按钮
            // 
            返回按钮.BackgroundImage = (Image)resources.GetObject("返回按钮.BackgroundImage");
            返回按钮.FlatStyle = FlatStyle.Flat;
            返回按钮.Font = new Font("宋体", 18F, FontStyle.Bold);
            返回按钮.Location = new Point(1820, 16);
            返回按钮.Name = "返回按钮";
            返回按钮.Size = new Size(84, 36);
            返回按钮.TabIndex = 7;
            返回按钮.Text = "返回";
            返回按钮.UseVisualStyleBackColor = true;
            返回按钮.Click += 返回按钮_Click;
            // 
            // 测试记录按钮
            // 
            测试记录按钮.BackgroundImage = (Image)resources.GetObject("测试记录按钮.BackgroundImage");
            测试记录按钮.FlatStyle = FlatStyle.Flat;
            测试记录按钮.Font = new Font("宋体", 18F, FontStyle.Bold);
            测试记录按钮.Location = new Point(1676, 16);
            测试记录按钮.Name = "测试记录按钮";
            测试记录按钮.Size = new Size(120, 36);
            测试记录按钮.TabIndex = 6;
            测试记录按钮.Text = "测试记录";
            测试记录按钮.UseVisualStyleBackColor = true;
            测试记录按钮.UseWaitCursor = true;
            测试记录按钮.Click += 测试记录按钮_Click;
            // 
            // 信息标签
            // 
            信息标签.AutoSize = true;
            信息标签.Font = new Font("宋体", 18F, FontStyle.Bold);
            信息标签.ForeColor = Color.Red;
            信息标签.Location = new Point(817, 21);
            信息标签.Name = "信息标签";
            信息标签.Size = new Size(238, 24);
            信息标签.TabIndex = 3;
            信息标签.Text = "信息: PLC通讯错误!";
            // 
            // 测试时间标签
            // 
            测试时间标签.AutoSize = true;
            测试时间标签.Font = new Font("宋体", 18F, FontStyle.Bold);
            测试时间标签.Location = new Point(832, 447);
            测试时间标签.Name = "测试时间标签";
            测试时间标签.Size = new Size(201, 24);
            测试时间标签.TabIndex = 2;
            测试时间标签.Text = "测试时间: 0.000";
            // 
            // 标题标签
            // 
            标题标签.AutoSize = true;
            标题标签.Font = new Font("宋体", 20F, FontStyle.Bold);
            标题标签.Location = new Point(16, 21);
            标题标签.Name = "标题标签";
            标题标签.Size = new Size(225, 27);
            标题标签.TabIndex = 0;
            标题标签.Text = "在线FCT测试系统";
            // 
            // 左侧面板
            // 
            左侧面板.Controls.Add(检测项表格);
            左侧面板.Location = new Point(0, 68);
            左侧面板.Name = "左侧面板";
            左侧面板.Size = new Size(504, 925);
            左侧面板.TabIndex = 1;
            // 
            // 检测项表格
            // 
            检测项表格.AllowUserToAddRows = false;
            检测项表格.AllowUserToDeleteRows = false;
            检测项表格.AllowUserToResizeRows = false;
            检测项表格.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("宋体", 18F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            检测项表格.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            检测项表格.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("宋体", 18F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            检测项表格.DefaultCellStyle = dataGridViewCellStyle2;
            检测项表格.Dock = DockStyle.Fill;
            检测项表格.Location = new Point(0, 0);
            检测项表格.MultiSelect = false;
            检测项表格.Name = "检测项表格";
            检测项表格.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("宋体", 18F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            检测项表格.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            检测项表格.RowHeadersVisible = false;
            检测项表格.Size = new Size(504, 925);
            检测项表格.TabIndex = 0;
            // 
            // SN标签1
            // 
            SN标签1.Anchor = AnchorStyles.None;
            SN标签1.Font = new Font("宋体", 18F, FontStyle.Bold);
            SN标签1.Location = new Point(597, 604);
            SN标签1.Name = "SN标签1";
            SN标签1.Size = new Size(289, 35);
            SN标签1.TabIndex = 7;
            // 
            // SN标签8
            // 
            SN标签8.Font = new Font("宋体", 18F, FontStyle.Bold);
            SN标签8.Location = new Point(597, 941);
            SN标签8.Name = "SN标签8";
            SN标签8.Size = new Size(289, 35);
            SN标签8.TabIndex = 7;
            // 
            // SN标签7
            // 
            SN标签7.Font = new Font("宋体", 18F, FontStyle.Bold);
            SN标签7.Location = new Point(597, 893);
            SN标签7.Name = "SN标签7";
            SN标签7.Size = new Size(289, 35);
            SN标签7.TabIndex = 7;
            // 
            // SN标签6
            // 
            SN标签6.Font = new Font("宋体", 18F, FontStyle.Bold);
            SN标签6.Location = new Point(597, 845);
            SN标签6.Name = "SN标签6";
            SN标签6.Size = new Size(289, 35);
            SN标签6.TabIndex = 7;
            // 
            // label8
            // 
            label8.Font = new Font("宋体", 18F);
            label8.Location = new Point(545, 945);
            label8.Name = "label8";
            label8.Size = new Size(54, 26);
            label8.TabIndex = 6;
            label8.Text = "SN1:\r\n";
            // 
            // 开始测试按钮
            // 
            开始测试按钮.BackColor = Color.FromArgb(112, 215, 121);
            开始测试按钮.FlatStyle = FlatStyle.Flat;
            开始测试按钮.Font = new Font("宋体", 18F, FontStyle.Bold);
            开始测试按钮.ForeColor = Color.White;
            开始测试按钮.Location = new Point(545, 552);
            开始测试按钮.Name = "开始测试按钮";
            开始测试按钮.Size = new Size(120, 36);
            开始测试按钮.TabIndex = 1;
            开始测试按钮.Text = "开始测试";
            开始测试按钮.UseVisualStyleBackColor = false;
            开始测试按钮.Click += 开始测试按钮_Click;
            // 
            // SN标签5
            // 
            SN标签5.Font = new Font("宋体", 18F, FontStyle.Bold);
            SN标签5.Location = new Point(597, 797);
            SN标签5.Name = "SN标签5";
            SN标签5.Size = new Size(289, 35);
            SN标签5.TabIndex = 7;
            // 
            // label7
            // 
            label7.Font = new Font("宋体", 18F);
            label7.Location = new Point(545, 897);
            label7.Name = "label7";
            label7.Size = new Size(54, 26);
            label7.TabIndex = 6;
            label7.Text = "SN1:\r\n";
            // 
            // SN标签4
            // 
            SN标签4.Font = new Font("宋体", 18F, FontStyle.Bold);
            SN标签4.Location = new Point(597, 749);
            SN标签4.Name = "SN标签4";
            SN标签4.Size = new Size(289, 35);
            SN标签4.TabIndex = 7;
            // 
            // label6
            // 
            label6.Font = new Font("宋体", 18F);
            label6.Location = new Point(545, 849);
            label6.Name = "label6";
            label6.Size = new Size(54, 26);
            label6.TabIndex = 6;
            label6.Text = "SN1:\r\n";
            // 
            // SN标签3
            // 
            SN标签3.Font = new Font("宋体", 18F, FontStyle.Bold);
            SN标签3.Location = new Point(597, 701);
            SN标签3.Name = "SN标签3";
            SN标签3.Size = new Size(289, 35);
            SN标签3.TabIndex = 7;
            // 
            // label5
            // 
            label5.Font = new Font("宋体", 18F);
            label5.Location = new Point(545, 801);
            label5.Name = "label5";
            label5.Size = new Size(54, 26);
            label5.TabIndex = 6;
            label5.Text = "SN1:\r\n";
            // 
            // SN标签2
            // 
            SN标签2.Font = new Font("宋体", 18F, FontStyle.Bold);
            SN标签2.Location = new Point(597, 653);
            SN标签2.Name = "SN标签2";
            SN标签2.Size = new Size(289, 35);
            SN标签2.TabIndex = 7;
            // 
            // label4
            // 
            label4.Font = new Font("宋体", 18F);
            label4.Location = new Point(545, 753);
            label4.Name = "label4";
            label4.Size = new Size(54, 26);
            label4.TabIndex = 6;
            label4.Text = "SN1:\r\n";
            // 
            // label2
            // 
            label2.Font = new Font("宋体", 18F);
            label2.Location = new Point(545, 609);
            label2.Name = "label2";
            label2.Size = new Size(54, 26);
            label2.TabIndex = 6;
            label2.Text = "SN1:\r\n";
            // 
            // label3
            // 
            label3.Font = new Font("宋体", 18F);
            label3.Location = new Point(545, 705);
            label3.Name = "label3";
            label3.Size = new Size(54, 26);
            label3.TabIndex = 6;
            label3.Text = "SN1:\r\n";
            // 
            // 手动拼版输入框
            // 
            手动拼版输入框.Font = new Font("宋体", 18F, FontStyle.Bold);
            手动拼版输入框.Location = new Point(1026, 657);
            手动拼版输入框.Name = "手动拼版输入框";
            手动拼版输入框.Size = new Size(443, 35);
            手动拼版输入框.TabIndex = 7;
            手动拼版输入框.Text = "1";
            // 
            // 手动拼版勾选框
            // 
            手动拼版勾选框.Font = new Font("宋体", 18F, FontStyle.Bold);
            手动拼版勾选框.Location = new Point(1026, 604);
            手动拼版勾选框.Name = "手动拼版勾选框";
            手动拼版勾选框.Size = new Size(131, 36);
            手动拼版勾选框.TabIndex = 6;
            手动拼版勾选框.Text = "指定拼版";
            手动拼版勾选框.TextAlign = ContentAlignment.MiddleCenter;
            手动拼版勾选框.UseVisualStyleBackColor = true;
            // 
            // 超时时间输入框
            // 
            超时时间输入框.Font = new Font("宋体", 18F, FontStyle.Bold);
            超时时间输入框.Location = new Point(1305, 553);
            超时时间输入框.Name = "超时时间输入框";
            超时时间输入框.Size = new Size(36, 35);
            超时时间输入框.TabIndex = 5;
            超时时间输入框.Text = "5";
            // 
            // 超时时间标签
            // 
            超时时间标签.Font = new Font("宋体", 18F, FontStyle.Bold);
            超时时间标签.Location = new Point(1238, 552);
            超时时间标签.Name = "超时时间标签";
            超时时间标签.Size = new Size(61, 36);
            超时时间标签.TabIndex = 4;
            超时时间标签.Text = "秒后";
            超时时间标签.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // 超时勾选框
            // 
            超时勾选框.Font = new Font("宋体", 18F, FontStyle.Bold);
            超时勾选框.Location = new Point(1162, 552);
            超时勾选框.Name = "超时勾选框";
            超时勾选框.Size = new Size(81, 36);
            超时勾选框.TabIndex = 3;
            超时勾选框.Text = "超时";
            超时勾选框.UseVisualStyleBackColor = true;
            超时勾选框.CheckedChanged += 超时勾选框_CheckedChanged;
            // 
            // 手动测试按钮
            // 
            手动测试按钮.BackColor = Color.FromArgb(43, 87, 154);
            手动测试按钮.FlatStyle = FlatStyle.Flat;
            手动测试按钮.Font = new Font("宋体", 18F, FontStyle.Bold);
            手动测试按钮.ForeColor = Color.White;
            手动测试按钮.Location = new Point(1026, 552);
            手动测试按钮.Name = "手动测试按钮";
            手动测试按钮.Size = new Size(120, 36);
            手动测试按钮.TabIndex = 0;
            手动测试按钮.Text = "手动测试";
            手动测试按钮.UseVisualStyleBackColor = false;
            手动测试按钮.Click += 手动测试按钮_Click;
            // 
            // label1
            // 
            label1.Font = new Font("宋体", 18F);
            label1.Location = new Point(545, 657);
            label1.Name = "label1";
            label1.Size = new Size(54, 26);
            label1.TabIndex = 6;
            label1.Text = "SN1:\r\n";
            // 
            // 当前配置标签
            // 
            当前配置标签.AutoSize = true;
            当前配置标签.Font = new Font("宋体", 18F, FontStyle.Bold);
            当前配置标签.ForeColor = Color.Blue;
            当前配置标签.Location = new Point(545, 493);
            当前配置标签.Name = "当前配置标签";
            当前配置标签.Size = new Size(211, 24);
            当前配置标签.TabIndex = 2;
            当前配置标签.Text = "当前配置: 未加载";
            // 
            // 端口状态按钮
            // 
            端口状态按钮.BackColor = Color.FromArgb(43, 87, 154);
            端口状态按钮.BackgroundImage = (Image)resources.GetObject("端口状态按钮.BackgroundImage");
            端口状态按钮.FlatStyle = FlatStyle.Flat;
            端口状态按钮.Font = new Font("宋体", 18F, FontStyle.Bold);
            端口状态按钮.ForeColor = Color.Black;
            端口状态按钮.Location = new Point(1052, 441);
            端口状态按钮.Name = "端口状态按钮";
            端口状态按钮.Size = new Size(120, 36);
            端口状态按钮.TabIndex = 5;
            端口状态按钮.Text = "端口状态";
            端口状态按钮.UseVisualStyleBackColor = false;
            // 
            // 暂时静音框
            // 
            暂时静音框.AutoSize = true;
            暂时静音框.Font = new Font("宋体", 18F, FontStyle.Bold);
            暂时静音框.Location = new Point(684, 445);
            暂时静音框.Name = "暂时静音框";
            暂时静音框.Size = new Size(129, 28);
            暂时静音框.TabIndex = 2;
            暂时静音框.Text = "暂时静音";
            暂时静音框.UseVisualStyleBackColor = true;
            // 
            // 显示大图按钮
            // 
            显示大图按钮.BackColor = Color.Red;
            显示大图按钮.BackgroundImage = (Image)resources.GetObject("显示大图按钮.BackgroundImage");
            显示大图按钮.FlatStyle = FlatStyle.Flat;
            显示大图按钮.Font = new Font("宋体", 18F, FontStyle.Bold);
            显示大图按钮.Location = new Point(545, 441);
            显示大图按钮.Margin = new Padding(0);
            显示大图按钮.Name = "显示大图按钮";
            显示大图按钮.Size = new Size(120, 36);
            显示大图按钮.TabIndex = 0;
            显示大图按钮.Text = "显示大图";
            显示大图按钮.UseVisualStyleBackColor = false;
            // 
            // 图像显示区
            // 
            图像显示区.BackColor = Color.Black;
            图像显示区.Location = new Point(521, 69);
            图像显示区.Name = "图像显示区";
            图像显示区.Size = new Size(962, 356);
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
            // 日志面板
            // 
            日志面板.Controls.Add(日志文本框);
            日志面板.Font = new Font("宋体", 18F, FontStyle.Bold);
            日志面板.Location = new Point(1500, 552);
            日志面板.Name = "日志面板";
            日志面板.Size = new Size(420, 441);
            日志面板.TabIndex = 2;
            日志面板.TabStop = false;
            日志面板.Text = "操作日志";
            // 
            // 日志文本框
            // 
            日志文本框.BackColor = Color.White;
            日志文本框.Dock = DockStyle.Fill;
            日志文本框.Font = new Font("宋体", 18F, FontStyle.Bold);
            日志文本框.Location = new Point(3, 31);
            日志文本框.Multiline = true;
            日志文本框.Name = "日志文本框";
            日志文本框.ReadOnly = true;
            日志文本框.ScrollBars = ScrollBars.Vertical;
            日志文本框.Size = new Size(414, 407);
            日志文本框.TabIndex = 0;
            // 
            // 统计面板
            // 
            统计面板.Font = new Font("宋体", 18F, FontStyle.Bold);
            统计面板.Location = new Point(1500, 78);
            统计面板.Name = "统计面板";
            统计面板.Size = new Size(420, 232);
            统计面板.TabIndex = 0;
            统计面板.TabStop = false;
            统计面板.Text = "测试统计";
            // 
            // 板状态面板
            // 
            板状态面板.Controls.Add(板状态容器);
            板状态面板.Font = new Font("宋体", 18F, FontStyle.Bold);
            板状态面板.Location = new Point(1500, 316);
            板状态面板.Name = "板状态面板";
            板状态面板.Size = new Size(420, 220);
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
            板状态容器.Location = new Point(18, 64);
            板状态容器.Name = "板状态容器";
            板状态容器.RowCount = 4;
            板状态容器.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            板状态容器.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            板状态容器.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            板状态容器.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            板状态容器.Size = new Size(388, 140);
            板状态容器.TabIndex = 0;
            // 
            // 通过率值标签
            // 
            通过率值标签.Font = new Font("宋体", 18F, FontStyle.Bold);
            通过率值标签.ForeColor = Color.Blue;
            通过率值标签.Location = new Point(1825, 260);
            通过率值标签.Name = "通过率值标签";
            通过率值标签.Size = new Size(95, 22);
            通过率值标签.TabIndex = 7;
            通过率值标签.Text = "0.00%";
            // 
            // 失败值标签
            // 
            失败值标签.Font = new Font("宋体", 18F, FontStyle.Bold);
            失败值标签.ForeColor = Color.Red;
            失败值标签.Location = new Point(1825, 218);
            失败值标签.Name = "失败值标签";
            失败值标签.Size = new Size(20, 22);
            失败值标签.TabIndex = 6;
            失败值标签.Text = "0";
            // 
            // OK值标签
            // 
            OK值标签.Font = new Font("宋体", 18F, FontStyle.Bold);
            OK值标签.ForeColor = Color.Lime;
            OK值标签.Location = new Point(1825, 176);
            OK值标签.Name = "OK值标签";
            OK值标签.Size = new Size(20, 22);
            OK值标签.TabIndex = 5;
            OK值标签.Text = "0";
            // 
            // 总数值标签
            // 
            总数值标签.Font = new Font("宋体", 18F, FontStyle.Bold);
            总数值标签.Location = new Point(1825, 134);
            总数值标签.Name = "总数值标签";
            总数值标签.Size = new Size(20, 22);
            总数值标签.TabIndex = 4;
            总数值标签.Text = "0";
            // 
            // 通过率标签
            // 
            通过率标签.Font = new Font("宋体", 18F, FontStyle.Bold);
            通过率标签.Location = new Point(1743, 258);
            通过率标签.Name = "通过率标签";
            通过率标签.Size = new Size(88, 26);
            通过率标签.TabIndex = 3;
            通过率标签.Text = "PASS:";
            通过率标签.TextAlign = ContentAlignment.MiddleRight;
            // 
            // 失败数标签
            // 
            失败数标签.Font = new Font("宋体", 18F, FontStyle.Bold);
            失败数标签.ForeColor = Color.Red;
            失败数标签.Location = new Point(1743, 216);
            失败数标签.Name = "失败数标签";
            失败数标签.Size = new Size(88, 26);
            失败数标签.TabIndex = 2;
            失败数标签.Text = "Fail:";
            失败数标签.TextAlign = ContentAlignment.MiddleRight;
            // 
            // OK数标签
            // 
            OK数标签.Font = new Font("宋体", 18F, FontStyle.Bold);
            OK数标签.ForeColor = Color.Lime;
            OK数标签.Location = new Point(1743, 174);
            OK数标签.Name = "OK数标签";
            OK数标签.Size = new Size(88, 26);
            OK数标签.TabIndex = 1;
            OK数标签.Text = "OK:";
            OK数标签.TextAlign = ContentAlignment.MiddleRight;
            // 
            // 总数标签
            // 
            总数标签.Font = new Font("宋体", 18F, FontStyle.Bold);
            总数标签.Location = new Point(1743, 132);
            总数标签.Name = "总数标签";
            总数标签.Size = new Size(88, 26);
            总数标签.TabIndex = 0;
            总数标签.Text = "Total:";
            总数标签.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(0, 16);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1920, 36);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // 自动测试界面
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 242, 246);
            ClientSize = new Size(1920, 1008);
            Controls.Add(通过率值标签);
            Controls.Add(显示大图按钮);
            Controls.Add(失败值标签);
            Controls.Add(暂时静音框);
            Controls.Add(OK值标签);
            Controls.Add(端口状态按钮);
            Controls.Add(通过率标签);
            Controls.Add(失败数标签);
            Controls.Add(总数值标签);
            Controls.Add(OK数标签);
            Controls.Add(超时时间标签);
            Controls.Add(超时时间输入框);
            Controls.Add(手动拼版输入框);
            Controls.Add(标题标签);
            Controls.Add(总数标签);
            Controls.Add(超时勾选框);
            Controls.Add(手动拼版勾选框);
            Controls.Add(手动测试按钮);
            Controls.Add(测试时间标签);
            Controls.Add(信息标签);
            Controls.Add(测试记录按钮);
            Controls.Add(返回按钮);
            Controls.Add(图像显示区);
            Controls.Add(SN标签1);
            Controls.Add(日志面板);
            Controls.Add(SN标签8);
            Controls.Add(板状态面板);
            Controls.Add(SN标签7);
            Controls.Add(SN标签6);
            Controls.Add(label8);
            Controls.Add(左侧面板);
            Controls.Add(开始测试按钮);
            Controls.Add(SN标签5);
            Controls.Add(label7);
            Controls.Add(当前配置标签);
            Controls.Add(SN标签4);
            Controls.Add(label1);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(SN标签3);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(SN标签2);
            Controls.Add(pictureBox1);
            Controls.Add(统计面板);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Name = "自动测试界面";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "在线FCT测试系统";
            左侧面板.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)检测项表格).EndInit();
            ((System.ComponentModel.ISupportInitialize)图像显示区).EndInit();
            日志面板.ResumeLayout(false);
            日志面板.PerformLayout();
            板状态面板.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private Label 标题标签;
        private Label 测试时间标签;
        private Label 信息标签;
        private Button 测试记录按钮;
        private Button 返回按钮;
        private Panel 左侧面板;
        private DataGridView 检测项表格;
        private PictureBox 图像显示区;
        private Button 显示大图按钮;
        private CheckBox 暂时静音框;
        private Button 端口状态按钮;
        private Button 复位按钮;
        private Label 当前配置标签;
        private TextBox 手动拼版输入框;
        private CheckBox 手动拼版勾选框;
        private TextBox 超时时间输入框;
        private Label 超时时间标签;
        private CheckBox 超时勾选框;
        private Button 手动测试按钮;
        private Button 开始测试按钮;
        private TextBox SN标签2;
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
        private PictureBox pictureBox1;
    }
}
