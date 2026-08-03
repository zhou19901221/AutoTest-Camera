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
            功能导航 = new TabControl();
            功能测试页 = new TabPage();
            工位地址标签 = new Label();
            工位地址框 = new ComboBox();
            标签导航 = new TabControl();
            检测项页 = new TabPage();
            检测项表格 = new DataGridView();
            排序列 = new DataGridViewTextBoxColumn();
            名称列 = new DataGridViewTextBoxColumn();
            类型列 = new DataGridViewComboBoxColumn();
            延时列 = new DataGridViewTextBoxColumn();
            最大值 = new DataGridViewTextBoxColumn();
            最小值 = new DataGridViewTextBoxColumn();
            设定值 = new DataGridViewTextBoxColumn();
            启用列 = new DataGridViewCheckBoxColumn();
            超时 = new DataGridViewTextBoxColumn();
            增加项按钮 = new Button();
            插入项按钮 = new Button();
            保存项按钮 = new Button();
            复制项按钮 = new Button();
            粘贴项按钮 = new Button();
            删除项按钮 = new Button();
            启用所有按钮 = new Button();
            停用所有按钮 = new Button();
            检测设置页 = new TabPage();
            NG跳转标签 = new Label();
            NG跳转框 = new TextBox();
            检测设置表格 = new DataGridView();
            显示环境温度湿度框 = new CheckBox();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox4 = new CheckBox();
            checkBox5 = new CheckBox();
            textBox1 = new TextBox();
            label1 = new Label();
            左侧面板.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)拼板数框).BeginInit();
            右侧面板.SuspendLayout();
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
            右侧面板.Controls.Add(增加项按钮);
            右侧面板.Controls.Add(功能导航);
            右侧面板.Controls.Add(标签导航);
            右侧面板.Controls.Add(插入项按钮);
            右侧面板.Controls.Add(停用所有按钮);
            右侧面板.Controls.Add(粘贴项按钮);
            右侧面板.Controls.Add(保存项按钮);
            右侧面板.Controls.Add(删除项按钮);
            右侧面板.Controls.Add(启用所有按钮);
            右侧面板.Controls.Add(复制项按钮);
            右侧面板.Location = new Point(220, 0);
            右侧面板.Name = "右侧面板";
            右侧面板.Size = new Size(1180, 850);
            右侧面板.TabIndex = 1;
            右侧面板.Paint += 右侧面板_Paint;
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
            // 功能导航
            // 
            功能导航.Controls.Add(功能测试页);
            功能导航.Location = new Point(10, 106);
            功能导航.Name = "功能导航";
            功能导航.SelectedIndex = 0;
            功能导航.Size = new Size(1146, 97);
            功能导航.TabIndex = 2;
            // 
            // 功能测试页
            // 
            功能测试页.Controls.Add(工位地址标签);
            功能测试页.Controls.Add(工位地址框);
            功能测试页.Location = new Point(4, 26);
            功能测试页.Name = "功能测试页";
            功能测试页.Size = new Size(1138, 67);
            功能测试页.TabIndex = 0;
            功能测试页.Text = "工位地址";
            功能测试页.UseVisualStyleBackColor = true;
            // 
            // 工位地址标签
            // 
            工位地址标签.AutoSize = true;
            工位地址标签.Location = new Point(16, 23);
            工位地址标签.Name = "工位地址标签";
            工位地址标签.Size = new Size(68, 17);
            工位地址标签.TabIndex = 0;
            工位地址标签.Text = "工位地址：";
            // 
            // 工位地址框
            // 
            工位地址框.DropDownStyle = ComboBoxStyle.DropDownList;
            工位地址框.FormattingEnabled = true;
            工位地址框.Location = new Point(86, 20);
            工位地址框.Name = "工位地址框";
            工位地址框.Size = new Size(120, 25);
            工位地址框.TabIndex = 1;
            // 
            // 标签导航
            // 
            标签导航.Controls.Add(检测项页);
            标签导航.Controls.Add(检测设置页);
            标签导航.Location = new Point(14, 206);
            标签导航.Name = "标签导航";
            标签导航.SelectedIndex = 0;
            标签导航.Size = new Size(1142, 610);
            标签导航.TabIndex = 3;
            // 
            // 检测项页
            // 
            检测项页.Controls.Add(检测项表格);
            检测项页.Location = new Point(4, 26);
            检测项页.Name = "检测项页";
            检测项页.Size = new Size(1134, 580);
            检测项页.TabIndex = 0;
            检测项页.Text = "检测项";
            检测项页.UseVisualStyleBackColor = true;
            // 
            // 检测项表格
            // 
            检测项表格.Columns.AddRange(new DataGridViewColumn[] { 排序列, 名称列, 类型列, 延时列, 最大值, 最小值, 设定值, 启用列, 超时 });
            检测项表格.Location = new Point(3, 8);
            检测项表格.Name = "检测项表格";
            检测项表格.Size = new Size(1128, 569);
            检测项表格.TabIndex = 0;
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
            类型列.Items.AddRange(new object[] { "继电器输出", "直流电压", "交流电压", "直流电流", "交流电流", "PWM检测", "声音检测", "电源输出", "串口输出", "相机检测" });
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
            // 超时
            // 
            超时.HeaderText = "超时";
            超时.Name = "超时";
            // 
            // 增加项按钮
            // 
            增加项按钮.Location = new Point(16, 822);
            增加项按钮.Name = "增加项按钮";
            增加项按钮.Size = new Size(75, 25);
            增加项按钮.TabIndex = 1;
            增加项按钮.Text = "增加项";
            增加项按钮.UseVisualStyleBackColor = true;
            增加项按钮.Click += 增加项按钮_Click;
            // 
            // 插入项按钮
            // 
            插入项按钮.Location = new Point(97, 822);
            插入项按钮.Name = "插入项按钮";
            插入项按钮.Size = new Size(75, 25);
            插入项按钮.TabIndex = 2;
            插入项按钮.Text = "插入项";
            插入项按钮.UseVisualStyleBackColor = true;
            插入项按钮.Click += 插入项按钮_Click;
            // 
            // 保存项按钮
            // 
            保存项按钮.Location = new Point(178, 822);
            保存项按钮.Name = "保存项按钮";
            保存项按钮.Size = new Size(75, 25);
            保存项按钮.TabIndex = 3;
            保存项按钮.Text = "保存项";
            保存项按钮.UseVisualStyleBackColor = true;
            保存项按钮.Click += 保存项按钮_Click;
            // 
            // 复制项按钮
            // 
            复制项按钮.Location = new Point(259, 822);
            复制项按钮.Name = "复制项按钮";
            复制项按钮.Size = new Size(75, 25);
            复制项按钮.TabIndex = 4;
            复制项按钮.Text = "复制项";
            复制项按钮.UseVisualStyleBackColor = true;
            复制项按钮.Click += 复制项按钮_Click;
            // 
            // 粘贴项按钮
            // 
            粘贴项按钮.Location = new Point(340, 822);
            粘贴项按钮.Name = "粘贴项按钮";
            粘贴项按钮.Size = new Size(75, 25);
            粘贴项按钮.TabIndex = 5;
            粘贴项按钮.Text = "粘贴项";
            粘贴项按钮.UseVisualStyleBackColor = true;
            粘贴项按钮.Click += 粘贴项按钮_Click;
            // 
            // 删除项按钮
            // 
            删除项按钮.Location = new Point(421, 822);
            删除项按钮.Name = "删除项按钮";
            删除项按钮.Size = new Size(75, 25);
            删除项按钮.TabIndex = 6;
            删除项按钮.Text = "删除项";
            删除项按钮.UseVisualStyleBackColor = true;
            删除项按钮.Click += 删除项按钮_Click;
            // 
            // 启用所有按钮
            // 
            启用所有按钮.Location = new Point(502, 822);
            启用所有按钮.Name = "启用所有按钮";
            启用所有按钮.Size = new Size(75, 25);
            启用所有按钮.TabIndex = 7;
            启用所有按钮.Text = "启用所有";
            启用所有按钮.UseVisualStyleBackColor = true;
            启用所有按钮.Click += 启用所有按钮_Click;
            // 
            // 停用所有按钮
            // 
            停用所有按钮.Location = new Point(583, 822);
            停用所有按钮.Name = "停用所有按钮";
            停用所有按钮.Size = new Size(75, 25);
            停用所有按钮.TabIndex = 8;
            停用所有按钮.Text = "停用所有";
            停用所有按钮.UseVisualStyleBackColor = true;
            停用所有按钮.Click += 停用所有按钮_Click;
            // 
            // 检测设置页
            // 
            检测设置页.Controls.Add(checkBox5);
            检测设置页.Controls.Add(checkBox4);
            检测设置页.Controls.Add(checkBox3);
            检测设置页.Controls.Add(checkBox1);
            检测设置页.Controls.Add(checkBox2);
            检测设置页.Controls.Add(显示环境温度湿度框);
            检测设置页.Controls.Add(label1);
            检测设置页.Controls.Add(textBox1);
            检测设置页.Controls.Add(NG跳转标签);
            检测设置页.Controls.Add(NG跳转框);
            检测设置页.Controls.Add(检测设置表格);
            检测设置页.Location = new Point(4, 26);
            检测设置页.Name = "检测设置页";
            检测设置页.Size = new Size(1134, 588);
            检测设置页.TabIndex = 1;
            检测设置页.Text = "检测设置";
            检测设置页.UseVisualStyleBackColor = true;
            // 
            // NG跳转标签
            // 
            NG跳转标签.Location = new Point(133, 51);
            NG跳转标签.Name = "NG跳转标签";
            NG跳转标签.Size = new Size(80, 23);
            NG跳转标签.TabIndex = 16;
            NG跳转标签.Text = "NG跳转：";
            NG跳转标签.TextAlign = ContentAlignment.MiddleRight;
            // 
            // NG跳转框
            // 
            NG跳转框.Location = new Point(213, 51);
            NG跳转框.Name = "NG跳转框";
            NG跳转框.Size = new Size(80, 23);
            NG跳转框.TabIndex = 17;
            // 
            // 检测设置表格
            // 
            检测设置表格.Location = new Point(3, 3);
            检测设置表格.Name = "检测设置表格";
            检测设置表格.Size = new Size(1128, 440);
            检测设置表格.TabIndex = 0;
            // 
            // 显示环境温度湿度框
            // 
            显示环境温度湿度框.AutoSize = true;
            显示环境温度湿度框.Location = new Point(16, 24);
            显示环境温度湿度框.Name = "显示环境温度湿度框";
            显示环境温度湿度框.Size = new Size(70, 21);
            显示环境温度湿度框.TabIndex = 18;
            显示环境温度湿度框.Text = "NG结束";
            显示环境温度湿度框.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(16, 78);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(99, 21);
            checkBox1.TabIndex = 18;
            checkBox1.Text = "超时结束检测";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(16, 51);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(70, 21);
            checkBox2.TabIndex = 18;
            checkBox2.Text = "NG跳转";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(16, 105);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(94, 21);
            checkBox3.TabIndex = 18;
            checkBox3.Text = "超时NG跳转";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(16, 132);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(99, 21);
            checkBox4.TabIndex = 18;
            checkBox4.Text = "超时结束供电";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            checkBox5.AutoSize = true;
            checkBox5.Location = new Point(16, 159);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(99, 21);
            checkBox5.TabIndex = 18;
            checkBox5.Text = "上电检测电压";
            checkBox5.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(213, 159);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(80, 23);
            textBox1.TabIndex = 17;
            // 
            // label1
            // 
            label1.Location = new Point(133, 159);
            label1.Name = "label1";
            label1.Size = new Size(80, 23);
            label1.TabIndex = 16;
            label1.Text = "上电电压：";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // 编辑配置窗体
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 1001);
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

        private TabControl 功能导航;
        private TabPage 功能测试页;
        private Label 工位地址标签;
        private ComboBox 工位地址框;

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
        private DataGridViewTextBoxColumn 排序列;
        private DataGridViewTextBoxColumn 名称列;
        private DataGridViewComboBoxColumn 类型列;
        private DataGridViewTextBoxColumn 延时列;
        private DataGridViewTextBoxColumn 最大值;
        private DataGridViewTextBoxColumn 最小值;
        private DataGridViewTextBoxColumn 设定值;
        private DataGridViewCheckBoxColumn 启用列;
        private DataGridViewTextBoxColumn 超时;
        private CheckBox checkBox4;
        private CheckBox checkBox3;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox 显示环境温度湿度框;
        private CheckBox checkBox5;
        private Label label1;
        private TextBox textBox1;
    }
}
