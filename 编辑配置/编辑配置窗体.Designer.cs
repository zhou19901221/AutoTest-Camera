namespace 自动测试
{
    partial class 编辑配置窗体
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(编辑配置窗体));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            拼板数标签 = new Label();
            拼板数框 = new NumericUpDown();
            搜索框 = new TextBox();
            配置名列表 = new ListBox();
            增加配置按钮 = new Button();
            button1 = new Button();
            复制配置按钮 = new Button();
            导出配置按钮 = new Button();
            删除配置按钮 = new Button();
            导入配置按钮 = new Button();
            当前板选择组 = new GroupBox();
            当前板1框 = new RadioButton();
            当前板2框 = new RadioButton();
            当前板3框 = new RadioButton();
            当前板4框 = new RadioButton();
            当前板5框 = new RadioButton();
            当前板6框 = new RadioButton();
            增加项按钮 = new Button();
            功能导航 = new TabControl();
            功能测试页 = new TabPage();
            工位地址框 = new ComboBox();
            工位地址框2 = new ComboBox();
            工位地址框3 = new ComboBox();
            工位地址框4 = new ComboBox();
            发送内容框 = new TextBox();
            判定时间框 = new TextBox();
            重复次数标签 = new Label();
            重复次数框 = new TextBox();
            顺序填充按钮 = new Button();
            间隔1填充按钮 = new Button();
            间隔2填充按钮 = new Button();
            工位地址标签 = new Label();
            判定时间标签 = new Label();
            发送内容标签 = new Label();
            标签导航 = new TabControl();
            检测项页 = new TabPage();
            检测项表格 = new DataGridView();
            停用所有按钮 = new Button();
            复制项按钮 = new Button();
            保存项按钮 = new Button();
            插入项按钮 = new Button();
            粘贴项按钮 = new Button();
            启用所有按钮 = new Button();
            删除项按钮 = new Button();
            检测设置页 = new TabPage();
            单独SN标签 = new CheckBox();
            checkBox5 = new CheckBox();
            checkBox4 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox1 = new CheckBox();
            NG跳转勾选框 = new CheckBox();
            NG结束勾选框 = new CheckBox();
            NG跳转标签 = new Label();
            NG跳转框 = new TextBox();
            检测设置表格 = new DataGridView();
            设置名称列 = new DataGridViewTextBoxColumn();
            设置值列 = new DataGridViewTextBoxColumn();
            设置说明列 = new DataGridViewTextBoxColumn();
            排序列 = new DataGridViewTextBoxColumn();
            名称列 = new DataGridViewTextBoxColumn();
            类型列 = new DataGridViewComboBoxColumn();
            延时列 = new DataGridViewTextBoxColumn();
            最大值 = new DataGridViewTextBoxColumn();
            最小值 = new DataGridViewTextBoxColumn();
            设定值 = new DataGridViewTextBoxColumn();
            启用列 = new DataGridViewCheckBoxColumn();
            超时 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)拼板数框).BeginInit();
            当前板选择组.SuspendLayout();
            功能导航.SuspendLayout();
            功能测试页.SuspendLayout();
            标签导航.SuspendLayout();
            检测项页.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)检测项表格).BeginInit();
            检测设置页.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)检测设置表格).BeginInit();
            SuspendLayout();
            // 
            // 拼板数标签
            // 
            拼板数标签.Font = new Font("宋体", 18F);
            拼板数标签.Location = new Point(16, 37);
            拼板数标签.Name = "拼板数标签";
            拼板数标签.Size = new Size(76, 28);
            拼板数标签.TabIndex = 0;
            拼板数标签.Text = "拼板数：";
            拼板数标签.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // 拼板数框
            // 
            拼板数框.Font = new Font("宋体", 18F);
            拼板数框.Location = new Point(98, 32);
            拼板数框.Name = "拼板数框";
            拼板数框.Size = new Size(120, 35);
            拼板数框.TabIndex = 1;
            拼板数框.Value = new decimal(new int[] { 6, 0, 0, 0 });
            // 
            // 搜索框
            // 
            搜索框.Font = new Font("宋体", 18F);
            搜索框.Location = new Point(16, 84);
            搜索框.Name = "搜索框";
            搜索框.Size = new Size(288, 35);
            搜索框.TabIndex = 4;
            搜索框.Text = "搜索...";
            // 
            // 配置名列表
            // 
            配置名列表.Font = new Font("宋体", 18F);
            配置名列表.ItemHeight = 24;
            配置名列表.Location = new Point(16, 136);
            配置名列表.Name = "配置名列表";
            配置名列表.Size = new Size(288, 388);
            配置名列表.TabIndex = 5;
            // 
            // 增加配置按钮
            // 
            增加配置按钮.BackgroundImage = (Image)resources.GetObject("增加配置按钮.BackgroundImage");
            增加配置按钮.FlatStyle = FlatStyle.Flat;
            增加配置按钮.Font = new Font("宋体", 18F);
            增加配置按钮.Location = new Point(16, 553);
            增加配置按钮.Name = "增加配置按钮";
            增加配置按钮.Size = new Size(288, 36);
            增加配置按钮.TabIndex = 6;
            增加配置按钮.Text = "增加配置";
            增加配置按钮.UseVisualStyleBackColor = true;
            增加配置按钮.Click += 增加配置按钮_Click;
            // 
            // button1
            // 
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("宋体", 18F);
            button1.Location = new Point(16, 718);
            button1.Name = "button1";
            button1.Size = new Size(288, 36);
            button1.TabIndex = 7;
            button1.Text = "粘贴配置";
            button1.UseVisualStyleBackColor = true;
            button1.Click += 复制配置按钮_Click;
            // 
            // 复制配置按钮
            // 
            复制配置按钮.BackgroundImage = (Image)resources.GetObject("复制配置按钮.BackgroundImage");
            复制配置按钮.FlatStyle = FlatStyle.Flat;
            复制配置按钮.Font = new Font("宋体", 18F);
            复制配置按钮.Location = new Point(16, 663);
            复制配置按钮.Name = "复制配置按钮";
            复制配置按钮.Size = new Size(288, 36);
            复制配置按钮.TabIndex = 7;
            复制配置按钮.Text = "复制配置";
            复制配置按钮.UseVisualStyleBackColor = true;
            复制配置按钮.Click += 复制配置按钮_Click;
            // 
            // 导出配置按钮
            // 
            导出配置按钮.BackgroundImage = (Image)resources.GetObject("导出配置按钮.BackgroundImage");
            导出配置按钮.FlatStyle = FlatStyle.Flat;
            导出配置按钮.Font = new Font("宋体", 18F);
            导出配置按钮.Location = new Point(16, 773);
            导出配置按钮.Name = "导出配置按钮";
            导出配置按钮.Size = new Size(288, 36);
            导出配置按钮.TabIndex = 8;
            导出配置按钮.Text = "导出配置";
            导出配置按钮.UseVisualStyleBackColor = true;
            导出配置按钮.Click += 导出配置按钮_Click;
            // 
            // 删除配置按钮
            // 
            删除配置按钮.BackgroundImage = (Image)resources.GetObject("删除配置按钮.BackgroundImage");
            删除配置按钮.FlatStyle = FlatStyle.Flat;
            删除配置按钮.Font = new Font("宋体", 18F);
            删除配置按钮.Location = new Point(16, 608);
            删除配置按钮.Name = "删除配置按钮";
            删除配置按钮.Size = new Size(288, 36);
            删除配置按钮.TabIndex = 10;
            删除配置按钮.Text = "删除配置";
            删除配置按钮.UseVisualStyleBackColor = true;
            删除配置按钮.Click += 删除配置按钮_Click;
            // 
            // 导入配置按钮
            // 
            导入配置按钮.BackgroundImage = (Image)resources.GetObject("导入配置按钮.BackgroundImage");
            导入配置按钮.FlatStyle = FlatStyle.Flat;
            导入配置按钮.Font = new Font("宋体", 18F);
            导入配置按钮.Location = new Point(16, 828);
            导入配置按钮.Name = "导入配置按钮";
            导入配置按钮.Size = new Size(288, 36);
            导入配置按钮.TabIndex = 11;
            导入配置按钮.Text = "导入配置";
            导入配置按钮.UseVisualStyleBackColor = true;
            导入配置按钮.Click += 导入配置按钮_Click;
            // 
            // 当前板选择组
            // 
            当前板选择组.Controls.Add(当前板1框);
            当前板选择组.Controls.Add(当前板2框);
            当前板选择组.Controls.Add(当前板3框);
            当前板选择组.Controls.Add(当前板4框);
            当前板选择组.Controls.Add(当前板5框);
            当前板选择组.Controls.Add(当前板6框);
            当前板选择组.Font = new Font("宋体", 18F);
            当前板选择组.Location = new Point(336, 32);
            当前板选择组.Name = "当前板选择组";
            当前板选择组.Size = new Size(1568, 172);
            当前板选择组.TabIndex = 1;
            当前板选择组.TabStop = false;
            当前板选择组.Text = "当前板选择";
            // 
            // 当前板1框
            // 
            当前板1框.Checked = true;
            当前板1框.Location = new Point(20, 56);
            当前板1框.Name = "当前板1框";
            当前板1框.Size = new Size(55, 31);
            当前板1框.TabIndex = 0;
            当前板1框.TabStop = true;
            当前板1框.Text = "1";
            // 
            // 当前板2框
            // 
            当前板2框.Location = new Point(90, 56);
            当前板2框.Name = "当前板2框";
            当前板2框.Size = new Size(40, 24);
            当前板2框.TabIndex = 1;
            当前板2框.Text = "2";
            // 
            // 当前板3框
            // 
            当前板3框.Location = new Point(160, 56);
            当前板3框.Name = "当前板3框";
            当前板3框.Size = new Size(40, 24);
            当前板3框.TabIndex = 2;
            当前板3框.Text = "3";
            // 
            // 当前板4框
            // 
            当前板4框.Location = new Point(230, 56);
            当前板4框.Name = "当前板4框";
            当前板4框.Size = new Size(40, 24);
            当前板4框.TabIndex = 3;
            当前板4框.Text = "4";
            // 
            // 当前板5框
            // 
            当前板5框.Location = new Point(300, 56);
            当前板5框.Name = "当前板5框";
            当前板5框.Size = new Size(40, 24);
            当前板5框.TabIndex = 4;
            当前板5框.Text = "5";
            // 
            // 当前板6框
            // 
            当前板6框.Location = new Point(370, 56);
            当前板6框.Name = "当前板6框";
            当前板6框.Size = new Size(40, 24);
            当前板6框.TabIndex = 5;
            当前板6框.Text = "6";
            // 
            // 增加项按钮
            // 
            增加项按钮.BackColor = Color.FromArgb(233, 233, 233);
            增加项按钮.Font = new Font("宋体", 18F);
            增加项按钮.Location = new Point(16, 517);
            增加项按钮.Name = "增加项按钮";
            增加项按钮.Size = new Size(82, 36);
            增加项按钮.TabIndex = 1;
            增加项按钮.Text = "增加项";
            增加项按钮.UseVisualStyleBackColor = false;
            增加项按钮.Click += 增加项按钮_Click;
            // 
            // 功能导航
            // 
            功能导航.Controls.Add(功能测试页);
            功能导航.Location = new Point(336, 220);
            功能导航.Name = "功能导航";
            功能导航.SelectedIndex = 0;
            功能导航.Size = new Size(1568, 132);
            功能导航.TabIndex = 2;
            // 
            // 功能测试页
            // 
            功能测试页.BackColor = Color.FromArgb(247, 252, 255);
            功能测试页.Controls.Add(工位地址框);
            功能测试页.Controls.Add(工位地址框2);
            功能测试页.Controls.Add(工位地址框3);
            功能测试页.Controls.Add(工位地址框4);
            功能测试页.Controls.Add(发送内容框);
            功能测试页.Controls.Add(判定时间框);
            功能测试页.Controls.Add(重复次数标签);
            功能测试页.Controls.Add(重复次数框);
            功能测试页.Controls.Add(顺序填充按钮);
            功能测试页.Controls.Add(间隔1填充按钮);
            功能测试页.Controls.Add(间隔2填充按钮);
            功能测试页.Controls.Add(工位地址标签);
            功能测试页.Controls.Add(判定时间标签);
            功能测试页.Controls.Add(发送内容标签);
            功能测试页.Font = new Font("宋体", 16F);
            功能测试页.Location = new Point(4, 26);
            功能测试页.Name = "功能测试页";
            功能测试页.Size = new Size(1560, 102);
            功能测试页.TabIndex = 0;
            功能测试页.Text = "工位地址";
            // 
            // 工位地址框
            // 
            工位地址框.DropDownStyle = ComboBoxStyle.DropDownList;
            工位地址框.FormattingEnabled = true;
            工位地址框.Location = new Point(130, 27);
            工位地址框.Name = "工位地址框";
            工位地址框.Size = new Size(140, 29);
            工位地址框.TabIndex = 1;
            工位地址框.SelectedIndexChanged += 工位地址框_SelectedIndexChanged;
            // 
            // 工位地址框2
            // 
            工位地址框2.DropDownStyle = ComboBoxStyle.DropDownList;
            工位地址框2.FormattingEnabled = true;
            工位地址框2.Location = new Point(280, 27);
            工位地址框2.Name = "工位地址框2";
            工位地址框2.Size = new Size(140, 29);
            工位地址框2.TabIndex = 1;
            工位地址框2.Visible = false;
            工位地址框2.SelectedIndexChanged += 工位地址框2_SelectedIndexChanged;
            // 
            // 工位地址框3
            // 
            工位地址框3.DropDownStyle = ComboBoxStyle.DropDownList;
            工位地址框3.FormattingEnabled = true;
            工位地址框3.Location = new Point(430, 27);
            工位地址框3.Name = "工位地址框3";
            工位地址框3.Size = new Size(140, 29);
            工位地址框3.TabIndex = 1;
            工位地址框3.Visible = false;
            工位地址框3.SelectedIndexChanged += 工位地址框3_SelectedIndexChanged;
            // 
            // 工位地址框4
            // 
            工位地址框4.DropDownStyle = ComboBoxStyle.DropDownList;
            工位地址框4.FormattingEnabled = true;
            工位地址框4.Location = new Point(580, 27);
            工位地址框4.Name = "工位地址框4";
            工位地址框4.Size = new Size(140, 29);
            工位地址框4.TabIndex = 1;
            工位地址框4.Visible = false;
            工位地址框4.SelectedIndexChanged += 工位地址框4_SelectedIndexChanged;
            // 
            // 发送内容框
            // 
            发送内容框.Location = new Point(394, 25);
            发送内容框.Name = "发送内容框";
            发送内容框.Size = new Size(290, 32);
            发送内容框.TabIndex = 6;
            发送内容框.Visible = false;
            // 
            // 判定时间框
            // 
            判定时间框.Location = new Point(860, 25);
            判定时间框.Name = "判定时间框";
            判定时间框.Size = new Size(100, 32);
            判定时间框.TabIndex = 8;
            判定时间框.Text = "1000";
            判定时间框.Visible = false;
            // 
            // 重复次数标签
            // 
            重复次数标签.AutoSize = true;
            重复次数标签.Location = new Point(980, 30);
            重复次数标签.Name = "重复次数标签";
            重复次数标签.Size = new Size(120, 22);
            重复次数标签.TabIndex = 9;
            重复次数标签.Text = "重复次数：";
            重复次数标签.Visible = false;
            // 
            // 重复次数框
            // 
            重复次数框.Location = new Point(1095, 25);
            重复次数框.Name = "重复次数框";
            重复次数框.Size = new Size(80, 32);
            重复次数框.TabIndex = 10;
            重复次数框.Text = "1";
            重复次数框.Visible = false;
            // 
            // 顺序填充按钮
            // 
            顺序填充按钮.Location = new Point(750, 24);
            顺序填充按钮.Name = "顺序填充按钮";
            顺序填充按钮.Size = new Size(110, 34);
            顺序填充按钮.TabIndex = 2;
            顺序填充按钮.Text = "顺序填充";
            顺序填充按钮.UseVisualStyleBackColor = true;
            顺序填充按钮.Click += 顺序填充按钮_Click;
            // 
            // 间隔1填充按钮
            // 
            间隔1填充按钮.Location = new Point(870, 24);
            间隔1填充按钮.Name = "间隔1填充按钮";
            间隔1填充按钮.Size = new Size(110, 34);
            间隔1填充按钮.TabIndex = 3;
            间隔1填充按钮.Text = "间隔1填充";
            间隔1填充按钮.UseVisualStyleBackColor = true;
            间隔1填充按钮.Click += 间隔1填充按钮_Click;
            // 
            // 间隔2填充按钮
            // 
            间隔2填充按钮.Location = new Point(990, 24);
            间隔2填充按钮.Name = "间隔2填充按钮";
            间隔2填充按钮.Size = new Size(110, 34);
            间隔2填充按钮.TabIndex = 4;
            间隔2填充按钮.Text = "间隔2填充";
            间隔2填充按钮.UseVisualStyleBackColor = true;
            间隔2填充按钮.Click += 间隔2填充按钮_Click;
            // 
            // 工位地址标签
            // 
            工位地址标签.AutoSize = true;
            工位地址标签.Location = new Point(16, 30);
            工位地址标签.Name = "工位地址标签";
            工位地址标签.Size = new Size(120, 22);
            工位地址标签.TabIndex = 0;
            工位地址标签.Text = "工位地址：";
            // 
            // 判定时间标签
            // 
            判定时间标签.AutoSize = true;
            判定时间标签.Location = new Point(700, 30);
            判定时间标签.Name = "判定时间标签";
            判定时间标签.Size = new Size(164, 22);
            判定时间标签.TabIndex = 7;
            判定时间标签.Text = "判定时间(ms)：";
            判定时间标签.Visible = false;
            // 
            // 发送内容标签
            // 
            发送内容标签.AutoSize = true;
            发送内容标签.Location = new Point(280, 30);
            发送内容标签.Name = "发送内容标签";
            发送内容标签.Size = new Size(120, 22);
            发送内容标签.TabIndex = 5;
            发送内容标签.Text = "发送内容：";
            发送内容标签.Visible = false;
            // 
            // 标签导航
            // 
            标签导航.Controls.Add(检测项页);
            标签导航.Controls.Add(检测设置页);
            标签导航.Font = new Font("宋体", 18F);
            标签导航.Location = new Point(336, 368);
            标签导航.Name = "标签导航";
            标签导航.SelectedIndex = 0;
            标签导航.Size = new Size(1568, 625);
            标签导航.TabIndex = 3;
            标签导航.SelectedIndexChanged += 标签导航_SelectedIndexChanged;
            // 
            // 检测项页
            // 
            检测项页.BackColor = Color.FromArgb(247, 252, 255);
            检测项页.Controls.Add(增加项按钮);
            检测项页.Controls.Add(检测项表格);
            检测项页.Controls.Add(停用所有按钮);
            检测项页.Controls.Add(复制项按钮);
            检测项页.Controls.Add(保存项按钮);
            检测项页.Controls.Add(插入项按钮);
            检测项页.Controls.Add(粘贴项按钮);
            检测项页.Controls.Add(启用所有按钮);
            检测项页.Controls.Add(删除项按钮);
            检测项页.Location = new Point(4, 34);
            检测项页.Name = "检测项页";
            检测项页.Size = new Size(1560, 587);
            检测项页.TabIndex = 0;
            检测项页.Text = "检测项";
            检测项页.Click += 检测项页_Click;
            // 
            // 检测项表格
            // 
            检测项表格.BackgroundColor = Color.FromArgb(247, 252, 255);
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("宋体", 16F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            检测项表格.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            检测项表格.ColumnHeadersHeight = 44;
            检测项表格.Columns.AddRange(new DataGridViewColumn[] { 排序列, 名称列, 类型列, 延时列, 最大值, 最小值, 设定值, 启用列, 超时 });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("宋体", 14F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            检测项表格.DefaultCellStyle = dataGridViewCellStyle2;
            检测项表格.Location = new Point(16, 24);
            检测项表格.Name = "检测项表格";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("宋体", 14F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            检测项表格.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            检测项表格.Size = new Size(1536, 469);
            检测项表格.TabIndex = 0;
            // 
            // 停用所有按钮
            // 
            停用所有按钮.BackColor = Color.FromArgb(233, 233, 233);
            停用所有按钮.Font = new Font("宋体", 18F);
            停用所有按钮.Location = new Point(712, 517);
            停用所有按钮.Margin = new Padding(0);
            停用所有按钮.Name = "停用所有按钮";
            停用所有按钮.Size = new Size(120, 36);
            停用所有按钮.TabIndex = 8;
            停用所有按钮.Text = "停用所有";
            停用所有按钮.UseVisualStyleBackColor = false;
            停用所有按钮.Click += 停用所有按钮_Click;
            // 
            // 复制项按钮
            // 
            复制项按钮.BackColor = Color.FromArgb(233, 233, 233);
            复制项按钮.Font = new Font("宋体", 18F);
            复制项按钮.Location = new Point(298, 517);
            复制项按钮.Name = "复制项按钮";
            复制项按钮.Size = new Size(82, 36);
            复制项按钮.TabIndex = 4;
            复制项按钮.Text = "复制项";
            复制项按钮.UseVisualStyleBackColor = false;
            复制项按钮.Click += 复制项按钮_Click;
            // 
            // 保存项按钮
            // 
            保存项按钮.BackColor = Color.FromArgb(233, 233, 233);
            保存项按钮.Font = new Font("宋体", 18F);
            保存项按钮.Location = new Point(204, 517);
            保存项按钮.Name = "保存项按钮";
            保存项按钮.Size = new Size(82, 36);
            保存项按钮.TabIndex = 3;
            保存项按钮.Text = "保存项";
            保存项按钮.UseVisualStyleBackColor = false;
            保存项按钮.Click += 保存项按钮_Click;
            // 
            // 插入项按钮
            // 
            插入项按钮.BackColor = Color.FromArgb(233, 233, 233);
            插入项按钮.Font = new Font("宋体", 18F);
            插入项按钮.Location = new Point(110, 517);
            插入项按钮.Name = "插入项按钮";
            插入项按钮.Size = new Size(82, 36);
            插入项按钮.TabIndex = 2;
            插入项按钮.Text = "插入项";
            插入项按钮.UseVisualStyleBackColor = false;
            插入项按钮.Click += 插入项按钮_Click;
            // 
            // 粘贴项按钮
            // 
            粘贴项按钮.BackColor = Color.FromArgb(233, 233, 233);
            粘贴项按钮.Font = new Font("宋体", 18F);
            粘贴项按钮.Location = new Point(392, 517);
            粘贴项按钮.Name = "粘贴项按钮";
            粘贴项按钮.Size = new Size(82, 36);
            粘贴项按钮.TabIndex = 5;
            粘贴项按钮.Text = "粘贴项";
            粘贴项按钮.UseVisualStyleBackColor = false;
            粘贴项按钮.Click += 粘贴项按钮_Click;
            // 
            // 启用所有按钮
            // 
            启用所有按钮.BackColor = Color.FromArgb(233, 233, 233);
            启用所有按钮.Font = new Font("宋体", 18F);
            启用所有按钮.Location = new Point(580, 517);
            启用所有按钮.Name = "启用所有按钮";
            启用所有按钮.Size = new Size(120, 36);
            启用所有按钮.TabIndex = 7;
            启用所有按钮.Text = "启用所有";
            启用所有按钮.UseVisualStyleBackColor = false;
            启用所有按钮.Click += 启用所有按钮_Click;
            // 
            // 删除项按钮
            // 
            删除项按钮.BackColor = Color.FromArgb(233, 233, 233);
            删除项按钮.Font = new Font("宋体", 18F);
            删除项按钮.Location = new Point(486, 517);
            删除项按钮.Name = "删除项按钮";
            删除项按钮.Size = new Size(82, 36);
            删除项按钮.TabIndex = 6;
            删除项按钮.Text = "删除项";
            删除项按钮.UseVisualStyleBackColor = false;
            删除项按钮.Click += 删除项按钮_Click;
            // 
            // 检测设置页
            // 
            检测设置页.Controls.Add(单独SN标签);
            检测设置页.Controls.Add(checkBox5);
            检测设置页.Controls.Add(checkBox4);
            检测设置页.Controls.Add(checkBox3);
            检测设置页.Controls.Add(checkBox1);
            检测设置页.Controls.Add(NG跳转勾选框);
            检测设置页.Controls.Add(NG结束勾选框);
            检测设置页.Controls.Add(NG跳转标签);
            检测设置页.Controls.Add(NG跳转框);
            检测设置页.Controls.Add(检测设置表格);
            检测设置页.Location = new Point(4, 34);
            检测设置页.Name = "检测设置页";
            检测设置页.Size = new Size(1560, 587);
            检测设置页.TabIndex = 1;
            检测设置页.Text = "检测设置";
            检测设置页.UseVisualStyleBackColor = true;
            // 
            // 单独SN标签
            // 
            单独SN标签.AutoSize = true;
            单独SN标签.Location = new Point(16, 348);
            单独SN标签.Name = "单独SN标签";
            单独SN标签.Size = new Size(101, 28);
            单独SN标签.TabIndex = 18;
            单独SN标签.Text = "单独SN";
            单独SN标签.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            checkBox5.AutoSize = true;
            checkBox5.Location = new Point(16, 299);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(125, 28);
            checkBox5.TabIndex = 18;
            checkBox5.Text = "短路检测";
            checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(16, 244);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(173, 28);
            checkBox4.TabIndex = 18;
            checkBox4.Text = "超时结束供电";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(16, 189);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(149, 28);
            checkBox3.TabIndex = 18;
            checkBox3.Text = "超时NG跳转";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(16, 134);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(173, 28);
            checkBox1.TabIndex = 18;
            checkBox1.Text = "超时结束检测";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // NG跳转勾选框
            // 
            NG跳转勾选框.AutoSize = true;
            NG跳转勾选框.Location = new Point(16, 79);
            NG跳转勾选框.Name = "NG跳转勾选框";
            NG跳转勾选框.Size = new Size(101, 28);
            NG跳转勾选框.TabIndex = 18;
            NG跳转勾选框.Text = "NG跳转";
            NG跳转勾选框.UseVisualStyleBackColor = true;
            // 
            // NG结束勾选框
            // 
            NG结束勾选框.AutoSize = true;
            NG结束勾选框.Location = new Point(16, 24);
            NG结束勾选框.Name = "NG结束勾选框";
            NG结束勾选框.Size = new Size(101, 28);
            NG结束勾选框.TabIndex = 18;
            NG结束勾选框.Text = "NG结束";
            NG结束勾选框.UseVisualStyleBackColor = true;
            // 
            // NG跳转标签
            // 
            NG跳转标签.Location = new Point(152, 78);
            NG跳转标签.Name = "NG跳转标签";
            NG跳转标签.Size = new Size(80, 23);
            NG跳转标签.TabIndex = 16;
            NG跳转标签.Text = "NG跳转：";
            NG跳转标签.TextAlign = ContentAlignment.MiddleRight;
            // 
            // NG跳转框
            // 
            NG跳转框.Location = new Point(322, 78);
            NG跳转框.Name = "NG跳转框";
            NG跳转框.Size = new Size(80, 35);
            NG跳转框.TabIndex = 17;
            // 
            // 检测设置表格
            // 
            检测设置表格.BackgroundColor = Color.FromArgb(247, 252, 255);
            检测设置表格.Location = new Point(1, 4);
            检测设置表格.Name = "检测设置表格";
            检测设置表格.Size = new Size(1559, 580);
            检测设置表格.TabIndex = 0;
            检测设置表格.Visible = false;
            // 
            // 设置名称列
            // 
            设置名称列.HeaderText = "设置项";
            设置名称列.Name = "设置名称列";
            设置名称列.ReadOnly = true;
            设置名称列.Width = 150;
            // 
            // 设置值列
            // 
            设置值列.HeaderText = "设置值";
            设置值列.Name = "设置值列";
            设置值列.Width = 200;
            // 
            // 设置说明列
            // 
            设置说明列.HeaderText = "说明";
            设置说明列.Name = "设置说明列";
            设置说明列.ReadOnly = true;
            设置说明列.Width = 300;
            // 
            // 排序列
            // 
            排序列.FillWeight = 70F;
            排序列.HeaderText = "排序";
            排序列.Name = "排序列";
            排序列.Width = 112;
            // 
            // 名称列
            // 
            名称列.FillWeight = 170F;
            名称列.HeaderText = "名称";
            名称列.Name = "名称列";
            名称列.Width = 260;
            // 
            // 类型列
            // 
            类型列.HeaderText = "类型";
            类型列.Items.AddRange(new object[] { "继电器输出", "直流电压", "交流电压", "直流电流", "交流电流", "PWM检测", "声音检测", "电源输出", "输入功率", "串口输出", "相机检测", "程控电源" });
            类型列.Name = "类型列";
            类型列.Width = 200;
            // 
            // 延时列
            // 
            延时列.HeaderText = "延时";
            延时列.Name = "延时列";
            延时列.Width = 146;
            // 
            // 最大值
            // 
            最大值.HeaderText = "最大值";
            最大值.Name = "最大值";
            最大值.Width = 146;
            // 
            // 最小值
            // 
            最小值.HeaderText = "最小值";
            最小值.Name = "最小值";
            最小值.Width = 146;
            // 
            // 设定值
            // 
            设定值.HeaderText = "设定值";
            设定值.Name = "设定值";
            设定值.Width = 146;
            // 
            // 启用列
            // 
            启用列.HeaderText = "启用";
            启用列.Name = "启用列";
            启用列.Width = 132;
            // 
            // 超时
            // 
            超时.HeaderText = "超时";
            超时.Name = "超时";
            超时.Width = 160;
            // 
            // 编辑配置窗体
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(239, 242, 246);
            ClientSize = new Size(1920, 1008);
            Controls.Add(标签导航);
            Controls.Add(拼板数标签);
            Controls.Add(拼板数框);
            Controls.Add(当前板选择组);
            Controls.Add(搜索框);
            Controls.Add(配置名列表);
            Controls.Add(增加配置按钮);
            Controls.Add(功能导航);
            Controls.Add(button1);
            Controls.Add(复制配置按钮);
            Controls.Add(导出配置按钮);
            Controls.Add(删除配置按钮);
            Controls.Add(导入配置按钮);
            FormBorderStyle = FormBorderStyle.None;
            Name = "编辑配置窗体";
            StartPosition = FormStartPosition.CenterParent;
            Text = "配置编辑";
            Load += 编辑配置窗体_Load;
            ((System.ComponentModel.ISupportInitialize)拼板数框).EndInit();
            当前板选择组.ResumeLayout(false);
            功能导航.ResumeLayout(false);
            功能测试页.ResumeLayout(false);
            功能测试页.PerformLayout();
            标签导航.ResumeLayout(false);
            检测项页.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)检测项表格).EndInit();
            检测设置页.ResumeLayout(false);
            检测设置页.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)检测设置表格).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private Label 拼板数标签;
        private NumericUpDown 拼板数框;
        private TextBox 搜索框;
        private ListBox 配置名列表;
        private Button 增加配置按钮;
        private Button 复制配置按钮;
        private Button 导出配置按钮;
        private Button 删除配置按钮;
        private Button 导入配置按钮;

        private GroupBox 当前板选择组;
        private RadioButton 当前板1框;
        private RadioButton 当前板2框;
        private RadioButton 当前板3框;
        private RadioButton 当前板4框;
        private RadioButton 当前板5框;
        private RadioButton 当前板6框;

        private TabControl 功能导航;
        private TabPage 功能测试页;
        private Label 工位地址标签;
        private ComboBox 工位地址框;
        private ComboBox 工位地址框2;
        private ComboBox 工位地址框3;
        private ComboBox 工位地址框4;
        private Label 发送内容标签;
        private TextBox 发送内容框;
        private Label 判定时间标签;
        private TextBox 判定时间框;
        private Label 重复次数标签;
        private TextBox 重复次数框;
        private Button 顺序填充按钮;
        private Button 间隔1填充按钮;
        private Button 间隔2填充按钮;

        private TabControl 标签导航;
        private TabPage 检测项页;
        private DataGridView 检测项表格;
        private Button 增加项按钮;
        private Button 插入项按钮;
        private Button 保存项按钮;
        private Button 复制项按钮;
        private Button 粘贴项按钮;
        private Button 删除项按钮;
        private Button 启用所有按钮;
        private Button 停用所有按钮;

        private TabPage 检测设置页;
        private DataGridView 检测设置表格;
        private Button button1;
        private Label NG跳转标签;
        private TextBox NG跳转框;
        private CheckBox checkBox4;
        private CheckBox checkBox3;
        private CheckBox checkBox1;
        private CheckBox NG跳转勾选框;
        private CheckBox NG结束勾选框;
        private CheckBox checkBox5;
        private DataGridViewTextBoxColumn 设置名称列;
        private DataGridViewTextBoxColumn 设置值列;
        private DataGridViewTextBoxColumn 设置说明列;
        private CheckBox 单独SN标签;
        private DataGridViewTextBoxColumn 排序列;
        private DataGridViewTextBoxColumn 名称列;
        private DataGridViewComboBoxColumn 类型列;
        private DataGridViewTextBoxColumn 延时列;
        private DataGridViewTextBoxColumn 最大值;
        private DataGridViewTextBoxColumn 最小值;
        private DataGridViewTextBoxColumn 设定值;
        private DataGridViewCheckBoxColumn 启用列;
        private DataGridViewTextBoxColumn 超时;
    }
}
