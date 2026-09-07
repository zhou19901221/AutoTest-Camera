namespace 自动测试
{
    partial class 日志页面
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
            筛选面板 = new Panel();
            类别标签 = new Label();
            类别框 = new ComboBox();
            关键词标签 = new Label();
            关键词框 = new TextBox();
            起始时间标签 = new Label();
            起始时间框 = new DateTimePicker();
            结束时间标签 = new Label();
            结束时间框 = new DateTimePicker();
            查询按钮 = new Button();
            导出按钮 = new Button();
            清空按钮 = new Button();
            日志表格 = new DataGridView();
            筛选面板.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)日志表格).BeginInit();
            SuspendLayout();
            // 
            // 筛选面板
            // 
            筛选面板.Controls.Add(类别标签);
            筛选面板.Controls.Add(类别框);
            筛选面板.Controls.Add(关键词标签);
            筛选面板.Controls.Add(关键词框);
            筛选面板.Controls.Add(起始时间标签);
            筛选面板.Controls.Add(起始时间框);
            筛选面板.Controls.Add(结束时间标签);
            筛选面板.Controls.Add(结束时间框);
            筛选面板.Controls.Add(查询按钮);
            筛选面板.Controls.Add(导出按钮);
            筛选面板.Controls.Add(清空按钮);
            筛选面板.Location = new Point(0, 0);
            筛选面板.Name = "筛选面板";
            筛选面板.Size = new Size(1200, 50);
            筛选面板.TabIndex = 0;
            // 
            // 类别标签
            // 
            类别标签.AutoSize = true;
            类别标签.Location = new Point(10, 16);
            类别标签.Name = "类别标签";
            类别标签.Size = new Size(44, 17);
            类别标签.TabIndex = 0;
            类别标签.Text = "类别：";
            // 
            // 类别框
            // 
            类别框.DropDownStyle = ComboBoxStyle.DropDownList;
            类别框.Items.AddRange(new object[] { "全部", "配置操作", "测试操作", "系统操作", "用户操作", "硬件操作", "数据操作", "调试操作" });
            类别框.Location = new Point(60, 12);
            类别框.Name = "类别框";
            类别框.Size = new Size(110, 25);
            类别框.TabIndex = 1;
            类别框.SelectedIndex = 0;
            // 
            // 关键词标签
            // 
            关键词标签.AutoSize = true;
            关键词标签.Location = new Point(180, 16);
            关键词标签.Name = "关键词标签";
            关键词标签.Size = new Size(56, 17);
            关键词标签.TabIndex = 2;
            关键词标签.Text = "关键词：";
            // 
            // 关键词框
            // 
            关键词框.Location = new Point(240, 12);
            关键词框.Name = "关键词框";
            关键词框.Size = new Size(150, 23);
            关键词框.TabIndex = 3;
            // 
            // 起始时间标签
            // 
            起始时间标签.AutoSize = true;
            起始时间标签.Location = new Point(410, 16);
            起始时间标签.Name = "起始时间标签";
            起始时间标签.Size = new Size(68, 17);
            起始时间标签.TabIndex = 4;
            起始时间标签.Text = "起始时间：";
            // 
            // 起始时间框
            // 
            起始时间框.Format = DateTimePickerFormat.Short;
            起始时间框.Location = new Point(480, 12);
            起始时间框.Name = "起始时间框";
            起始时间框.Size = new Size(120, 23);
            起始时间框.TabIndex = 5;
            // 
            // 结束时间标签
            // 
            结束时间标签.AutoSize = true;
            结束时间标签.Location = new Point(610, 16);
            结束时间标签.Name = "结束时间标签";
            结束时间标签.Size = new Size(68, 17);
            结束时间标签.TabIndex = 6;
            结束时间标签.Text = "结束时间：";
            // 
            // 结束时间框
            // 
            结束时间框.Format = DateTimePickerFormat.Short;
            结束时间框.Location = new Point(680, 12);
            结束时间框.Name = "结束时间框";
            结束时间框.Size = new Size(120, 23);
            结束时间框.TabIndex = 7;
            // 
            // 查询按钮
            // 
            查询按钮.Location = new Point(820, 10);
            查询按钮.Name = "查询按钮";
            查询按钮.Size = new Size(75, 28);
            查询按钮.TabIndex = 8;
            查询按钮.Text = "查询";
            查询按钮.UseVisualStyleBackColor = true;
            查询按钮.Click += 查询按钮_Click;
            // 
            // 导出按钮
            // 
            导出按钮.Location = new Point(905, 10);
            导出按钮.Name = "导出按钮";
            导出按钮.Size = new Size(75, 28);
            导出按钮.TabIndex = 9;
            导出按钮.Text = "导出";
            导出按钮.UseVisualStyleBackColor = true;
            导出按钮.Click += 导出按钮_Click;
            // 
            // 清空按钮
            // 
            清空按钮.Location = new Point(990, 10);
            清空按钮.Name = "清空按钮";
            清空按钮.Size = new Size(75, 28);
            清空按钮.TabIndex = 10;
            清空按钮.Text = "清空";
            清空按钮.UseVisualStyleBackColor = true;
            清空按钮.Click += 清空按钮_Click;
            // 
            // 日志表格
            // 
            日志表格.AllowUserToAddRows = false;
            日志表格.AllowUserToDeleteRows = false;
            日志表格.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            日志表格.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            日志表格.Location = new Point(0, 55);
            日志表格.Name = "日志表格";
            日志表格.ReadOnly = true;
            日志表格.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            日志表格.Size = new Size(1200, 645);
            日志表格.TabIndex = 1;
            // 
            // 日志页面
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 700);
            Controls.Add(日志表格);
            Controls.Add(筛选面板);
            Name = "日志页面";
            StartPosition = FormStartPosition.CenterParent;
            Text = "操作日志";
            筛选面板.ResumeLayout(false);
            筛选面板.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)日志表格).EndInit();
            ResumeLayout(false);
        }

        private Panel 筛选面板;
        private Label 类别标签;
        private ComboBox 类别框;
        private Label 关键词标签;
        private TextBox 关键词框;
        private Label 起始时间标签;
        private DateTimePicker 起始时间框;
        private Label 结束时间标签;
        private DateTimePicker 结束时间框;
        private Button 查询按钮;
        private Button 导出按钮;
        private Button 清空按钮;
        private DataGridView 日志表格;
    }
}