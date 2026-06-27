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
            左侧面板 = new Panel();
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
            右侧面板 = new Panel();
            当前板选择组 = new GroupBox();
            当前板1框 = new RadioButton();
            当前板2框 = new RadioButton();
            当前板3框 = new RadioButton();
            当前板4框 = new RadioButton();
            当前板5框 = new RadioButton();
            当前板6框 = new RadioButton();
            标签导航 = new TabControl();
            检测项页 = new TabPage();
            检测项表格 = new DataGridView();
            增加项按钮 = new Button();
            插入项按钮 = new Button();
            保存项按钮 = new Button();
            复制项按钮 = new Button();
            粘贴项按钮 = new Button();
            删除项按钮 = new Button();
            启用所有按钮 = new Button();
            停用所有按钮 = new Button();
            偏移校正按钮 = new Button();
            检测设置页 = new TabPage();
            检测设置表格 = new DataGridView();
            复制参数框 = new CheckBox();
            复制区块按钮 = new Button();
            增加子项按钮 = new Button();
            保存子项按钮 = new Button();
            删除子项按钮 = new Button();
            删除所有子项按钮 = new Button();
            参数设置组 = new GroupBox();
            类型标签 = new Label();
            类型框 = new ComboBox();
            读取时间标签 = new Label();
            读取时间框 = new NumericUpDown();
            读取间隔标签 = new Label();
            读取间隔框 = new NumericUpDown();
            持续时间标签 = new Label();
            持续时间框 = new NumericUpDown();
            极性检测标签 = new Label();
            极性检测框 = new ComboBox();
            OK跳转标签 = new Label();
            OK跳转框 = new TextBox();
            OK循环标签 = new Label();
            OK循环框 = new NumericUpDown();
            NG跳转标签 = new Label();
            NG跳转框 = new TextBox();
            NG循环标签 = new Label();
            NG循环框 = new NumericUpDown();
            全局坐标管理按钮 = new Button();
            输出按钮 = new Button();
            保存项参数按钮 = new Button();
            配置信息组 = new GroupBox();
            配置名称标签 = new Label();
            配置名称框 = new TextBox();
            日期标签 = new Label();
            日期框 = new TextBox();
            当前配置标签 = new Label();
            当前配置框 = new TextBox();
            选为当前按钮 = new Button();
            关闭并保存按钮 = new Button();
            关闭按钮 = new Button();
            排序列 = new DataGridViewTextBoxColumn();
            名称列 = new DataGridViewTextBoxColumn();
            类型列 = new DataGridViewComboBoxColumn();
            延时列 = new DataGridViewTextBoxColumn();
            最大值 = new DataGridViewTextBoxColumn();
            最小值 = new DataGridViewTextBoxColumn();
            设定值 = new DataGridViewTextBoxColumn();
            启用列 = new DataGridViewCheckBoxColumn();
            左侧面板.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)拼板数框).BeginInit();
            右侧面板.SuspendLayout();
            当前板选择组.SuspendLayout();
            标签导航.SuspendLayout();
            检测项页.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)检测项表格).BeginInit();
            检测设置页.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)检测设置表格).BeginInit();
            参数设置组.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)读取时间框).BeginInit();
            ((System.ComponentModel.ISupportInitialize)读取间隔框).BeginInit();
            ((System.ComponentModel.ISupportInitialize)持续时间框).BeginInit();
            ((System.ComponentModel.ISupportInitialize)OK循环框).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NG循环框).BeginInit();
            配置信息组.SuspendLayout();
            SuspendLayout();
            // 
            // 左侧面板
            // 
            左侧面板.Controls.Add(拼板数标签);
            左侧面板.Controls.Add(拼板数框);
            左侧面板.Controls.Add(搜索框);
            左侧面板.Controls.Add(配置名列表);
            左侧面板.Controls.Add(增加配置按钮);
            左侧面板.Controls.Add(button1);
            左侧面板.Controls.Add(复制配置按钮);
            左侧面板.Controls.Add(导出配置按钮);
            左侧面板.Controls.Add(删除配置按钮);
            左侧面板.Controls.Add(导入配置按钮);
            左侧面板.Location = new Point(0, 0);
            左侧面板.Name = "左侧面板";
            左侧面板.Size = new Size(220, 850);
            左侧面板.TabIndex = 0;
            // 
            // 拼板数标签
            // 
            拼板数标签.Location = new Point(10, 10);
            拼板数标签.Name = "拼板数标签";
            拼板数标签.Size = new Size(50, 23);
            拼板数标签.TabIndex = 0;
            拼板数标签.Text = "拼板数：";
            // 
            // 拼板数框
            // 
            拼板数框.Location = new Point(60, 10);
            拼板数框.Name = "拼板数框";
            拼板数框.Size = new Size(60, 23);
            拼板数框.TabIndex = 1;
            拼板数框.Value = new decimal(new int[] { 6, 0, 0, 0 });
            // 
            // 搜索框
            // 
            搜索框.Location = new Point(10, 39);
            搜索框.Name = "搜索框";
            搜索框.Size = new Size(175, 23);
            搜索框.TabIndex = 4;
            搜索框.Text = "搜索...";
            // 
            // 配置名列表
            // 
            配置名列表.ItemHeight = 17;
            配置名列表.Location = new Point(10, 76);
            配置名列表.Name = "配置名列表";
            配置名列表.Size = new Size(195, 480);
            配置名列表.TabIndex = 5;
            // 
            // 增加配置按钮
            // 
            增加配置按钮.Location = new Point(12, 580);
            增加配置按钮.Name = "增加配置按钮";
            增加配置按钮.Size = new Size(195, 30);
            增加配置按钮.TabIndex = 6;
            增加配置按钮.Text = "增加配置";
            增加配置按钮.UseVisualStyleBackColor = true;
            增加配置按钮.Click += 增加配置按钮_Click;
            // 
            // button1
            // 
            button1.Location = new Point(12, 688);
            button1.Name = "button1";
            button1.Size = new Size(195, 30);
            button1.TabIndex = 7;
            button1.Text = "粘贴配置";
            button1.UseVisualStyleBackColor = true;
            button1.Click += 复制配置按钮_Click;
            // 
            // 复制配置按钮
            // 
            复制配置按钮.Location = new Point(12, 652);
            复制配置按钮.Name = "复制配置按钮";
            复制配置按钮.Size = new Size(195, 30);
            复制配置按钮.TabIndex = 7;
            复制配置按钮.Text = "复制配置";
            复制配置按钮.UseVisualStyleBackColor = true;
            复制配置按钮.Click += 复制配置按钮_Click;
            // 
            // 导出配置按钮
            // 
            导出配置按钮.Location = new Point(12, 758);
            导出配置按钮.Name = "导出配置按钮";
            导出配置按钮.Size = new Size(195, 30);
            导出配置按钮.TabIndex = 8;
            导出配置按钮.Text = "导出配置";
            导出配置按钮.UseVisualStyleBackColor = true;
            导出配置按钮.Click += 导出配置按钮_Click;
            // 
            // 删除配置按钮
            // 
            删除配置按钮.Location = new Point(12, 616);
            删除配置按钮.Name = "删除配置按钮";
            删除配置按钮.Size = new Size(195, 30);
            删除配置按钮.TabIndex = 10;
            删除配置按钮.Text = "删除配置";
            删除配置按钮.UseVisualStyleBackColor = true;
            删除配置按钮.Click += 删除配置按钮_Click;
            // 
            // 导入配置按钮
            // 
            导入配置按钮.Location = new Point(10, 794);
            导入配置按钮.Name = "导入配置按钮";
            导入配置按钮.Size = new Size(195, 30);
            导入配置按钮.TabIndex = 11;
            导入配置按钮.Text = "导入配置";
            导入配置按钮.UseVisualStyleBackColor = true;
            导入配置按钮.Click += 导入配置按钮_Click;
            // 
            // 右侧面板
            // 
            右侧面板.Controls.Add(当前板选择组);
            右侧面板.Controls.Add(标签导航);
            右侧面板.Controls.Add(复制参数框);
            右侧面板.Controls.Add(复制区块按钮);
            右侧面板.Controls.Add(增加子项按钮);
            右侧面板.Controls.Add(保存子项按钮);
            右侧面板.Controls.Add(删除子项按钮);
            右侧面板.Controls.Add(删除所有子项按钮);
            右侧面板.Controls.Add(参数设置组);
            右侧面板.Controls.Add(全局坐标管理按钮);
            右侧面板.Controls.Add(输出按钮);
            右侧面板.Controls.Add(保存项参数按钮);
            右侧面板.Controls.Add(配置信息组);
            右侧面板.Controls.Add(关闭并保存按钮);
            右侧面板.Controls.Add(关闭按钮);
            右侧面板.Location = new Point(220, 0);
            右侧面板.Name = "右侧面板";
            右侧面板.Size = new Size(1180, 850);
            右侧面板.TabIndex = 1;
            // 
            // 当前板选择组
            // 
            当前板选择组.Controls.Add(当前板1框);
            当前板选择组.Controls.Add(当前板2框);
            当前板选择组.Controls.Add(当前板3框);
            当前板选择组.Controls.Add(当前板4框);
            当前板选择组.Controls.Add(当前板5框);
            当前板选择组.Controls.Add(当前板6框);
            当前板选择组.Location = new Point(10, 10);
            当前板选择组.Name = "当前板选择组";
            当前板选择组.Size = new Size(1150, 86);
            当前板选择组.TabIndex = 1;
            当前板选择组.TabStop = false;
            当前板选择组.Text = "当前板选择";
            // 
            // 当前板1框
            // 
            当前板1框.Checked = true;
            当前板1框.Location = new Point(20, 20);
            当前板1框.Name = "当前板1框";
            当前板1框.Size = new Size(40, 24);
            当前板1框.TabIndex = 0;
            当前板1框.TabStop = true;
            当前板1框.Text = "1";
            // 
            // 当前板2框
            // 
            当前板2框.Location = new Point(90, 20);
            当前板2框.Name = "当前板2框";
            当前板2框.Size = new Size(40, 24);
            当前板2框.TabIndex = 1;
            当前板2框.Text = "2";
            // 
            // 当前板3框
            // 
            当前板3框.Location = new Point(160, 20);
            当前板3框.Name = "当前板3框";
            当前板3框.Size = new Size(40, 24);
            当前板3框.TabIndex = 2;
            当前板3框.Text = "3";
            // 
            // 当前板4框
            // 
            当前板4框.Location = new Point(230, 20);
            当前板4框.Name = "当前板4框";
            当前板4框.Size = new Size(40, 24);
            当前板4框.TabIndex = 3;
            当前板4框.Text = "4";
            // 
            // 当前板5框
            // 
            当前板5框.Location = new Point(300, 20);
            当前板5框.Name = "当前板5框";
            当前板5框.Size = new Size(40, 24);
            当前板5框.TabIndex = 4;
            当前板5框.Text = "5";
            // 
            // 当前板6框
            // 
            当前板6框.Location = new Point(370, 20);
            当前板6框.Name = "当前板6框";
            当前板6框.Size = new Size(40, 24);
            当前板6框.TabIndex = 5;
            当前板6框.Text = "6";
            // 
            // 标签导航
            // 
            标签导航.Controls.Add(检测项页);
            标签导航.Controls.Add(检测设置页);
            标签导航.Location = new Point(10, 146);
            标签导航.Name = "标签导航";
            标签导航.SelectedIndex = 0;
            标签导航.Size = new Size(1150, 410);
            标签导航.TabIndex = 2;
            // 
            // 检测项页
            // 
            检测项页.Controls.Add(检测项表格);
            检测项页.Controls.Add(增加项按钮);
            检测项页.Controls.Add(插入项按钮);
            检测项页.Controls.Add(保存项按钮);
            检测项页.Controls.Add(复制项按钮);
            检测项页.Controls.Add(粘贴项按钮);
            检测项页.Controls.Add(删除项按钮);
            检测项页.Controls.Add(启用所有按钮);
            检测项页.Controls.Add(停用所有按钮);
            检测项页.Controls.Add(偏移校正按钮);
            检测项页.Location = new Point(4, 26);
            检测项页.Name = "检测项页";
            检测项页.Size = new Size(1142, 380);
            检测项页.TabIndex = 0;
            检测项页.Text = "检测项";
            检测项页.UseVisualStyleBackColor = true;
            // 
            // 检测项表格
            // 
            检测项表格.Columns.AddRange(new DataGridViewColumn[] { 排序列, 名称列, 类型列, 延时列, 最大值, 最小值, 设定值, 启用列 });
            检测项表格.Location = new Point(6, 8);
            检测项表格.Name = "检测项表格";
            检测项表格.Size = new Size(1136, 200);
            检测项表格.TabIndex = 0;
            // 
            // 增加项按钮
            // 
            增加项按钮.Location = new Point(16, 209);
            增加项按钮.Name = "增加项按钮";
            增加项按钮.Size = new Size(75, 25);
            增加项按钮.TabIndex = 1;
            增加项按钮.Text = "增加项";
            增加项按钮.UseVisualStyleBackColor = true;
            增加项按钮.Click += 增加项按钮_Click;
            // 
            // 插入项按钮
            // 
            插入项按钮.Location = new Point(97, 209);
            插入项按钮.Name = "插入项按钮";
            插入项按钮.Size = new Size(75, 25);
            插入项按钮.TabIndex = 2;
            插入项按钮.Text = "插入项";
            插入项按钮.UseVisualStyleBackColor = true;
            插入项按钮.Click += 插入项按钮_Click;
            // 
            // 保存项按钮
            // 
            保存项按钮.Location = new Point(178, 209);
            保存项按钮.Name = "保存项按钮";
            保存项按钮.Size = new Size(75, 25);
            保存项按钮.TabIndex = 3;
            保存项按钮.Text = "保存项";
            保存项按钮.UseVisualStyleBackColor = true;
            保存项按钮.Click += 保存项按钮_Click;
            // 
            // 复制项按钮
            // 
            复制项按钮.Location = new Point(259, 209);
            复制项按钮.Name = "复制项按钮";
            复制项按钮.Size = new Size(75, 25);
            复制项按钮.TabIndex = 4;
            复制项按钮.Text = "复制项";
            复制项按钮.UseVisualStyleBackColor = true;
            复制项按钮.Click += 复制项按钮_Click;
            // 
            // 粘贴项按钮
            // 
            粘贴项按钮.Location = new Point(340, 209);
            粘贴项按钮.Name = "粘贴项按钮";
            粘贴项按钮.Size = new Size(75, 25);
            粘贴项按钮.TabIndex = 5;
            粘贴项按钮.Text = "粘贴项";
            粘贴项按钮.UseVisualStyleBackColor = true;
            粘贴项按钮.Click += 粘贴项按钮_Click;
            // 
            // 删除项按钮
            // 
            删除项按钮.Location = new Point(421, 209);
            删除项按钮.Name = "删除项按钮";
            删除项按钮.Size = new Size(75, 25);
            删除项按钮.TabIndex = 6;
            删除项按钮.Text = "删除项";
            删除项按钮.UseVisualStyleBackColor = true;
            删除项按钮.Click += 删除项按钮_Click;
            // 
            // 启用所有按钮
            // 
            启用所有按钮.Location = new Point(502, 209);
            启用所有按钮.Name = "启用所有按钮";
            启用所有按钮.Size = new Size(75, 25);
            启用所有按钮.TabIndex = 7;
            启用所有按钮.Text = "启用所有";
            启用所有按钮.UseVisualStyleBackColor = true;
            启用所有按钮.Click += 启用所有按钮_Click;
            // 
            // 停用所有按钮
            // 
            停用所有按钮.Location = new Point(583, 209);
            停用所有按钮.Name = "停用所有按钮";
            停用所有按钮.Size = new Size(75, 25);
            停用所有按钮.TabIndex = 8;
            停用所有按钮.Text = "停用所有";
            停用所有按钮.UseVisualStyleBackColor = true;
            停用所有按钮.Click += 停用所有按钮_Click;
            // 
            // 偏移校正按钮
            // 
            偏移校正按钮.Location = new Point(664, 209);
            偏移校正按钮.Name = "偏移校正按钮";
            偏移校正按钮.Size = new Size(75, 25);
            偏移校正按钮.TabIndex = 9;
            偏移校正按钮.Text = "偏移校正";
            偏移校正按钮.UseVisualStyleBackColor = true;
            偏移校正按钮.Click += 偏移校正按钮_Click;
            // 
            // 检测设置页
            // 
            检测设置页.Controls.Add(检测设置表格);
            检测设置页.Location = new Point(4, 26);
            检测设置页.Name = "检测设置页";
            检测设置页.Size = new Size(1142, 380);
            检测设置页.TabIndex = 1;
            检测设置页.Text = "检测设置";
            检测设置页.UseVisualStyleBackColor = true;
            // 
            // 检测设置表格
            // 
            检测设置表格.Location = new Point(3, 3);
            检测设置表格.Name = "检测设置表格";
            检测设置表格.Size = new Size(1136, 230);
            检测设置表格.TabIndex = 0;
            // 
            // 复制参数框
            // 
            复制参数框.Location = new Point(10, 569);
            复制参数框.Name = "复制参数框";
            复制参数框.Size = new Size(100, 24);
            复制参数框.TabIndex = 3;
            复制参数框.Text = "复制参数";
            // 
            // 复制区块按钮
            // 
            复制区块按钮.Location = new Point(120, 569);
            复制区块按钮.Name = "复制区块按钮";
            复制区块按钮.Size = new Size(85, 25);
            复制区块按钮.TabIndex = 4;
            复制区块按钮.Text = "复制区块";
            复制区块按钮.UseVisualStyleBackColor = true;
            复制区块按钮.Click += 复制区块按钮_Click;
            // 
            // 增加子项按钮
            // 
            增加子项按钮.Location = new Point(215, 569);
            增加子项按钮.Name = "增加子项按钮";
            增加子项按钮.Size = new Size(85, 25);
            增加子项按钮.TabIndex = 5;
            增加子项按钮.Text = "增加子项";
            增加子项按钮.UseVisualStyleBackColor = true;
            增加子项按钮.Click += 增加子项按钮_Click;
            // 
            // 保存子项按钮
            // 
            保存子项按钮.Location = new Point(310, 569);
            保存子项按钮.Name = "保存子项按钮";
            保存子项按钮.Size = new Size(85, 25);
            保存子项按钮.TabIndex = 6;
            保存子项按钮.Text = "保存子项";
            保存子项按钮.UseVisualStyleBackColor = true;
            保存子项按钮.Click += 保存子项按钮_Click;
            // 
            // 删除子项按钮
            // 
            删除子项按钮.Location = new Point(405, 569);
            删除子项按钮.Name = "删除子项按钮";
            删除子项按钮.Size = new Size(85, 25);
            删除子项按钮.TabIndex = 7;
            删除子项按钮.Text = "删除子项";
            删除子项按钮.UseVisualStyleBackColor = true;
            删除子项按钮.Click += 删除子项按钮_Click;
            // 
            // 删除所有子项按钮
            // 
            删除所有子项按钮.Location = new Point(500, 569);
            删除所有子项按钮.Name = "删除所有子项按钮";
            删除所有子项按钮.Size = new Size(100, 25);
            删除所有子项按钮.TabIndex = 8;
            删除所有子项按钮.Text = "删除所有子项";
            删除所有子项按钮.UseVisualStyleBackColor = true;
            删除所有子项按钮.Click += 删除所有子项按钮_Click;
            // 
            // 参数设置组
            // 
            参数设置组.Controls.Add(类型标签);
            参数设置组.Controls.Add(类型框);
            参数设置组.Controls.Add(读取时间标签);
            参数设置组.Controls.Add(读取时间框);
            参数设置组.Controls.Add(读取间隔标签);
            参数设置组.Controls.Add(读取间隔框);
            参数设置组.Controls.Add(持续时间标签);
            参数设置组.Controls.Add(持续时间框);
            参数设置组.Controls.Add(极性检测标签);
            参数设置组.Controls.Add(极性检测框);
            参数设置组.Controls.Add(OK跳转标签);
            参数设置组.Controls.Add(OK跳转框);
            参数设置组.Controls.Add(OK循环标签);
            参数设置组.Controls.Add(OK循环框);
            参数设置组.Controls.Add(NG跳转标签);
            参数设置组.Controls.Add(NG跳转框);
            参数设置组.Controls.Add(NG循环标签);
            参数设置组.Controls.Add(NG循环框);
            参数设置组.Location = new Point(7, 600);
            参数设置组.Name = "参数设置组";
            参数设置组.Size = new Size(1150, 120);
            参数设置组.TabIndex = 9;
            参数设置组.TabStop = false;
            参数设置组.Text = "参数设置";
            // 
            // 类型标签
            // 
            类型标签.Location = new Point(20, 25);
            类型标签.Name = "类型标签";
            类型标签.Size = new Size(50, 23);
            类型标签.TabIndex = 0;
            类型标签.Text = "类型：";
            类型标签.TextAlign = ContentAlignment.MiddleRight;
            // 
            // 类型框
            // 
            类型框.Items.AddRange(new object[] { "恒定比对", "范围比对", "动态比对" });
            类型框.Location = new Point(70, 25);
            类型框.Name = "类型框";
            类型框.Size = new Size(100, 25);
            类型框.TabIndex = 1;
            // 
            // 读取时间标签
            // 
            读取时间标签.Location = new Point(180, 25);
            读取时间标签.Name = "读取时间标签";
            读取时间标签.Size = new Size(70, 23);
            读取时间标签.TabIndex = 2;
            读取时间标签.Text = "读取时间：";
            读取时间标签.TextAlign = ContentAlignment.MiddleRight;
            // 
            // 读取时间框
            // 
            读取时间框.Location = new Point(250, 25);
            读取时间框.Name = "读取时间框";
            读取时间框.Size = new Size(80, 23);
            读取时间框.TabIndex = 3;
            // 
            // 读取间隔标签
            // 
            读取间隔标签.Location = new Point(340, 25);
            读取间隔标签.Name = "读取间隔标签";
            读取间隔标签.Size = new Size(70, 23);
            读取间隔标签.TabIndex = 4;
            读取间隔标签.Text = "读取间隔：";
            读取间隔标签.TextAlign = ContentAlignment.MiddleRight;
            // 
            // 读取间隔框
            // 
            读取间隔框.Location = new Point(410, 25);
            读取间隔框.Name = "读取间隔框";
            读取间隔框.Size = new Size(80, 23);
            读取间隔框.TabIndex = 5;
            // 
            // 持续时间标签
            // 
            持续时间标签.Location = new Point(500, 25);
            持续时间标签.Name = "持续时间标签";
            持续时间标签.Size = new Size(70, 23);
            持续时间标签.TabIndex = 6;
            持续时间标签.Text = "持续时间：";
            持续时间标签.TextAlign = ContentAlignment.MiddleRight;
            // 
            // 持续时间框
            // 
            持续时间框.Location = new Point(570, 25);
            持续时间框.Name = "持续时间框";
            持续时间框.Size = new Size(80, 23);
            持续时间框.TabIndex = 7;
            // 
            // 极性检测标签
            // 
            极性检测标签.Location = new Point(660, 25);
            极性检测标签.Name = "极性检测标签";
            极性检测标签.Size = new Size(70, 23);
            极性检测标签.TabIndex = 8;
            极性检测标签.Text = "极性检测：";
            极性检测标签.TextAlign = ContentAlignment.MiddleRight;
            // 
            // 极性检测框
            // 
            极性检测框.Items.AddRange(new object[] { "正向", "反向", "双向" });
            极性检测框.Location = new Point(730, 25);
            极性检测框.Name = "极性检测框";
            极性检测框.Size = new Size(80, 25);
            极性检测框.TabIndex = 9;
            // 
            // OK跳转标签
            // 
            OK跳转标签.Location = new Point(20, 60);
            OK跳转标签.Name = "OK跳转标签";
            OK跳转标签.Size = new Size(80, 23);
            OK跳转标签.TabIndex = 10;
            OK跳转标签.Text = "OK跳转：";
            OK跳转标签.TextAlign = ContentAlignment.MiddleRight;
            // 
            // OK跳转框
            // 
            OK跳转框.Location = new Point(100, 60);
            OK跳转框.Name = "OK跳转框";
            OK跳转框.Size = new Size(80, 23);
            OK跳转框.TabIndex = 11;
            // 
            // OK循环标签
            // 
            OK循环标签.Location = new Point(190, 60);
            OK循环标签.Name = "OK循环标签";
            OK循环标签.Size = new Size(70, 23);
            OK循环标签.TabIndex = 12;
            OK循环标签.Text = "循环次数：";
            OK循环标签.TextAlign = ContentAlignment.MiddleRight;
            // 
            // OK循环框
            // 
            OK循环框.Location = new Point(260, 60);
            OK循环框.Name = "OK循环框";
            OK循环框.Size = new Size(80, 23);
            OK循环框.TabIndex = 13;
            // 
            // NG跳转标签
            // 
            NG跳转标签.Location = new Point(360, 60);
            NG跳转标签.Name = "NG跳转标签";
            NG跳转标签.Size = new Size(80, 23);
            NG跳转标签.TabIndex = 14;
            NG跳转标签.Text = "NG跳转：";
            NG跳转标签.TextAlign = ContentAlignment.MiddleRight;
            // 
            // NG跳转框
            // 
            NG跳转框.Location = new Point(440, 60);
            NG跳转框.Name = "NG跳转框";
            NG跳转框.Size = new Size(80, 23);
            NG跳转框.TabIndex = 15;
            // 
            // NG循环标签
            // 
            NG循环标签.Location = new Point(530, 60);
            NG循环标签.Name = "NG循环标签";
            NG循环标签.Size = new Size(70, 23);
            NG循环标签.TabIndex = 16;
            NG循环标签.Text = "循环次数：";
            NG循环标签.TextAlign = ContentAlignment.MiddleRight;
            // 
            // NG循环框
            // 
            NG循环框.Location = new Point(600, 60);
            NG循环框.Name = "NG循环框";
            NG循环框.Size = new Size(80, 23);
            NG循环框.TabIndex = 17;
            // 
            // 全局坐标管理按钮
            // 
            全局坐标管理按钮.Location = new Point(7, 726);
            全局坐标管理按钮.Name = "全局坐标管理按钮";
            全局坐标管理按钮.Size = new Size(120, 30);
            全局坐标管理按钮.TabIndex = 10;
            全局坐标管理按钮.Text = "全局坐标管理";
            全局坐标管理按钮.UseVisualStyleBackColor = true;
            全局坐标管理按钮.Click += 全局坐标管理按钮_Click;
            // 
            // 输出按钮
            // 
            输出按钮.Location = new Point(137, 726);
            输出按钮.Name = "输出按钮";
            输出按钮.Size = new Size(100, 30);
            输出按钮.TabIndex = 11;
            输出按钮.Text = "(X/K)输出";
            输出按钮.UseVisualStyleBackColor = true;
            输出按钮.Click += 输出按钮_Click;
            // 
            // 保存项参数按钮
            // 
            保存项参数按钮.Location = new Point(247, 726);
            保存项参数按钮.Name = "保存项参数按钮";
            保存项参数按钮.Size = new Size(100, 30);
            保存项参数按钮.TabIndex = 12;
            保存项参数按钮.Text = "保存项参数";
            保存项参数按钮.UseVisualStyleBackColor = true;
            保存项参数按钮.Click += 保存项参数按钮_Click;
            // 
            // 配置信息组
            // 
            配置信息组.Controls.Add(配置名称标签);
            配置信息组.Controls.Add(配置名称框);
            配置信息组.Controls.Add(日期标签);
            配置信息组.Controls.Add(日期框);
            配置信息组.Controls.Add(当前配置标签);
            配置信息组.Controls.Add(当前配置框);
            配置信息组.Controls.Add(选为当前按钮);
            配置信息组.Location = new Point(367, 726);
            配置信息组.Name = "配置信息组";
            配置信息组.Size = new Size(790, 70);
            配置信息组.TabIndex = 13;
            配置信息组.TabStop = false;
            配置信息组.Text = "配置信息";
            // 
            // 配置名称标签
            // 
            配置名称标签.Location = new Point(20, 25);
            配置名称标签.Name = "配置名称标签";
            配置名称标签.Size = new Size(70, 23);
            配置名称标签.TabIndex = 0;
            配置名称标签.Text = "配置名称：";
            配置名称标签.TextAlign = ContentAlignment.MiddleRight;
            // 
            // 配置名称框
            // 
            配置名称框.Location = new Point(90, 25);
            配置名称框.Name = "配置名称框";
            配置名称框.Size = new Size(120, 23);
            配置名称框.TabIndex = 1;
            // 
            // 日期标签
            // 
            日期标签.Location = new Point(220, 25);
            日期标签.Name = "日期标签";
            日期标签.Size = new Size(50, 23);
            日期标签.TabIndex = 2;
            日期标签.Text = "日期：";
            日期标签.TextAlign = ContentAlignment.MiddleRight;
            // 
            // 日期框
            // 
            日期框.Location = new Point(270, 25);
            日期框.Name = "日期框";
            日期框.Size = new Size(100, 23);
            日期框.TabIndex = 3;
            // 
            // 当前配置标签
            // 
            当前配置标签.Location = new Point(380, 25);
            当前配置标签.Name = "当前配置标签";
            当前配置标签.Size = new Size(70, 23);
            当前配置标签.TabIndex = 4;
            当前配置标签.Text = "当前配置：";
            当前配置标签.TextAlign = ContentAlignment.MiddleRight;
            // 
            // 当前配置框
            // 
            当前配置框.Location = new Point(450, 25);
            当前配置框.Name = "当前配置框";
            当前配置框.Size = new Size(120, 23);
            当前配置框.TabIndex = 5;
            // 
            // 选为当前按钮
            // 
            选为当前按钮.Location = new Point(520, 25);
            选为当前按钮.Name = "选为当前按钮";
            选为当前按钮.Size = new Size(75, 25);
            选为当前按钮.TabIndex = 6;
            选为当前按钮.Text = "选为当前";
            选为当前按钮.UseVisualStyleBackColor = true;
            选为当前按钮.Click += 选为当前按钮_Click;
            // 
            // 关闭并保存按钮
            // 
            关闭并保存按钮.Location = new Point(970, 810);
            关闭并保存按钮.Name = "关闭并保存按钮";
            关闭并保存按钮.Size = new Size(100, 30);
            关闭并保存按钮.TabIndex = 14;
            关闭并保存按钮.Text = "关闭并保存";
            关闭并保存按钮.UseVisualStyleBackColor = true;
            关闭并保存按钮.Click += 关闭并保存按钮_Click;
            // 
            // 关闭按钮
            // 
            关闭按钮.Location = new Point(1080, 810);
            关闭按钮.Name = "关闭按钮";
            关闭按钮.Size = new Size(100, 30);
            关闭按钮.TabIndex = 15;
            关闭按钮.Text = "关闭";
            关闭按钮.UseVisualStyleBackColor = true;
            关闭按钮.Click += 关闭按钮_Click;
            // 
            // 排序列
            // 
            排序列.HeaderText = "排序";
            排序列.Name = "排序列";
            排序列.Width = 60;
            // 
            // 名称列
            // 
            名称列.HeaderText = "名称";
            名称列.Name = "名称列";
            名称列.Width = 150;
            // 
            // 类型列
            // 
            类型列.HeaderText = "类型";
            类型列.Items.AddRange(new object[] { "继电器输出", "输入检测", "直流电压", "交流电压", "直流电流", "交流电流", "声音采集", "相机检测", "串口输出" });
            类型列.Name = "类型列";
            // 
            // 延时列
            // 
            延时列.HeaderText = "延时";
            延时列.Name = "延时列";
            延时列.Width = 80;
            // 
            // 最大值
            // 
            最大值.HeaderText = "最大值";
            最大值.Name = "最大值";
            // 
            // 最小值
            // 
            最小值.HeaderText = "最小值";
            最小值.Name = "最小值";
            // 
            // 设定值
            // 
            设定值.HeaderText = "设定值";
            设定值.Name = "设定值";
            // 
            // 启用列
            // 
            启用列.HeaderText = "启用";
            启用列.Name = "启用列";
            启用列.Width = 60;
            // 
            // 编辑配置窗体
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 850);
            Controls.Add(左侧面板);
            Controls.Add(右侧面板);
            Name = "编辑配置窗体";
            StartPosition = FormStartPosition.CenterParent;
            Text = "配置编辑";
            Load += 编辑配置窗体_Load;
            左侧面板.ResumeLayout(false);
            左侧面板.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)拼板数框).EndInit();
            右侧面板.ResumeLayout(false);
            当前板选择组.ResumeLayout(false);
            标签导航.ResumeLayout(false);
            检测项页.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)检测项表格).EndInit();
            检测设置页.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)检测设置表格).EndInit();
            参数设置组.ResumeLayout(false);
            参数设置组.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)读取时间框).EndInit();
            ((System.ComponentModel.ISupportInitialize)读取间隔框).EndInit();
            ((System.ComponentModel.ISupportInitialize)持续时间框).EndInit();
            ((System.ComponentModel.ISupportInitialize)OK循环框).EndInit();
            ((System.ComponentModel.ISupportInitialize)NG循环框).EndInit();
            配置信息组.ResumeLayout(false);
            配置信息组.PerformLayout();
            ResumeLayout(false);
        }

        private Panel 左侧面板;
        private Label 拼板数标签;
        private NumericUpDown 拼板数框;
        private TextBox 搜索框;
        private ListBox 配置名列表;
        private Button 增加配置按钮;
        private Button 复制配置按钮;
        private Button 导出配置按钮;
        private Button 删除配置按钮;
        private Button 导入配置按钮;

        private Panel 右侧面板;

        private GroupBox 当前板选择组;
        private RadioButton 当前板1框;
        private RadioButton 当前板2框;
        private RadioButton 当前板3框;
        private RadioButton 当前板4框;
        private RadioButton 当前板5框;
        private RadioButton 当前板6框;

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
        private Button 偏移校正按钮;

        private TabPage 检测设置页;
        private DataGridView 检测设置表格;

        private CheckBox 复制参数框;
        private Button 复制区块按钮;
        private Button 增加子项按钮;
        private Button 保存子项按钮;
        private Button 删除子项按钮;
        private Button 删除所有子项按钮;

        private GroupBox 参数设置组;
        private Label 类型标签;
        private ComboBox 类型框;
        private Label 读取时间标签;
        private NumericUpDown 读取时间框;
        private Label 读取间隔标签;
        private NumericUpDown 读取间隔框;
        private Label 持续时间标签;
        private NumericUpDown 持续时间框;
        private Label 极性检测标签;
        private ComboBox 极性检测框;

        private Label OK跳转标签;
        private TextBox OK跳转框;
        private Label OK循环标签;
        private NumericUpDown OK循环框;
        private Label NG跳转标签;
        private TextBox NG跳转框;
        private Label NG循环标签;
        private NumericUpDown NG循环框;

        private Button 全局坐标管理按钮;
        private Button 输出按钮;
        private Button 保存项参数按钮;

        private GroupBox 配置信息组;
        private Label 配置名称标签;
        private TextBox 配置名称框;
        private Label 日期标签;
        private TextBox 日期框;
        private Label 当前配置标签;
        private TextBox 当前配置框;
        private Button 选为当前按钮;

        private Button 关闭并保存按钮;
        private Button 关闭按钮;
        private Button button1;
        private DataGridViewTextBoxColumn 排序列;
        private DataGridViewTextBoxColumn 名称列;
        private DataGridViewComboBoxColumn 类型列;
        private DataGridViewTextBoxColumn 延时列;
        private DataGridViewTextBoxColumn 最大值;
        private DataGridViewTextBoxColumn 最小值;
        private DataGridViewTextBoxColumn 设定值;
        private DataGridViewCheckBoxColumn 启用列;
    }
}
