namespace 自动测试
{
    partial class 测试记录页面
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
            起始时间框 = new DateTimePicker();
            结束时间框 = new DateTimePicker();
            配置框 = new ComboBox();
            结果框 = new ComboBox();
            SN框 = new TextBox();
            查询按钮 = new Button();
            时间标签 = new Label();
            到标签 = new Label();
            配置标签 = new Label();
            结果标签 = new Label();
            SN标签 = new Label();
            记录表格 = new DataGridView();
            筛选面板.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)记录表格).BeginInit();
            SuspendLayout();
            // 
            // 筛选面板
            // 
            筛选面板.Controls.Add(SN标签);
            筛选面板.Controls.Add(SN框);
            筛选面板.Controls.Add(结果标签);
            筛选面板.Controls.Add(结果框);
            筛选面板.Controls.Add(配置标签);
            筛选面板.Controls.Add(配置框);
            筛选面板.Controls.Add(到标签);
            筛选面板.Controls.Add(时间标签);
            筛选面板.Controls.Add(结束时间框);
            筛选面板.Controls.Add(起始时间框);
            筛选面板.Controls.Add(查询按钮);
            筛选面板.Dock = DockStyle.Top;
            筛选面板.Location = new Point(0, 0);
            筛选面板.Name = "筛选面板";
            筛选面板.Size = new Size(1200, 55);
            筛选面板.TabIndex = 0;
            // 
            // 起始时间框
            // 
            起始时间框.CustomFormat = "yyyy-MM-dd";
            起始时间框.Format = DateTimePickerFormat.Custom;
            起始时间框.Location = new Point(62, 14);
            起始时间框.Name = "起始时间框";
            起始时间框.Size = new Size(120, 27);
            起始时间框.TabIndex = 0;
            // 
            // 结束时间框
            // 
            结束时间框.CustomFormat = "yyyy-MM-dd";
            结束时间框.Format = DateTimePickerFormat.Custom;
            结束时间框.Location = new Point(212, 14);
            结束时间框.Name = "结束时间框";
            结束时间框.Size = new Size(120, 27);
            结束时间框.TabIndex = 1;
            // 
            // 配置框
            // 
            配置框.DropDownStyle = ComboBoxStyle.DropDownList;
            配置框.FormattingEnabled = true;
            配置框.Location = new Point(398, 14);
            配置框.Name = "配置框";
            配置框.Size = new Size(170, 28);
            配置框.TabIndex = 2;
            // 
            // 结果框
            // 
            结果框.DropDownStyle = ComboBoxStyle.DropDownList;
            结果框.FormattingEnabled = true;
            结果框.Location = new Point(626, 14);
            结果框.Name = "结果框";
            结果框.Size = new Size(90, 28);
            结果框.TabIndex = 3;
            // 
            // SN框
            // 
            SN框.Location = new Point(762, 14);
            SN框.Name = "SN框";
            SN框.Size = new Size(160, 27);
            SN框.TabIndex = 4;
            // 
            // 查询按钮
            // 
            查询按钮.Location = new Point(940, 12);
            查询按钮.Name = "查询按钮";
            查询按钮.Size = new Size(80, 30);
            查询按钮.TabIndex = 5;
            查询按钮.Text = "查询";
            查询按钮.UseVisualStyleBackColor = true;
            查询按钮.Click += 查询按钮_Click;
            // 
            // 时间标签
            // 
            时间标签.AutoSize = true;
            时间标签.Location = new Point(12, 18);
            时间标签.Name = "时间标签";
            时间标签.Size = new Size(54, 20);
            时间标签.TabIndex = 6;
            时间标签.Text = "日期：";
            // 
            // 到标签
            // 
            到标签.AutoSize = true;
            到标签.Location = new Point(187, 18);
            到标签.Name = "到标签";
            到标签.Size = new Size(24, 20);
            到标签.TabIndex = 7;
            到标签.Text = "至";
            // 
            // 配置标签
            // 
            配置标签.AutoSize = true;
            配置标签.Location = new Point(338, 18);
            配置标签.Name = "配置标签";
            配置标签.Size = new Size(54, 20);
            配置标签.TabIndex = 8;
            配置标签.Text = "配置：";
            // 
            // 结果标签
            // 
            结果标签.AutoSize = true;
            结果标签.Location = new Point(574, 18);
            结果标签.Name = "结果标签";
            结果标签.Size = new Size(54, 20);
            结果标签.TabIndex = 9;
            结果标签.Text = "结果：";
            // 
            // SN标签
            // 
            SN标签.AutoSize = true;
            SN标签.Location = new Point(724, 18);
            SN标签.Name = "SN标签";
            SN标签.Size = new Size(33, 20);
            SN标签.TabIndex = 10;
            SN标签.Text = "SN";
            // 
            // 记录表格
            // 
            记录表格.AllowUserToAddRows = false;
            记录表格.AllowUserToDeleteRows = false;
            记录表格.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            记录表格.Dock = DockStyle.Fill;
            记录表格.Location = new Point(0, 55);
            记录表格.Name = "记录表格";
            记录表格.ReadOnly = true;
            记录表格.RowHeadersVisible = false;
            记录表格.RowHeadersWidth = 51;
            记录表格.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            记录表格.Size = new Size(1200, 645);
            记录表格.TabIndex = 1;
            // 
            // 测试记录页面
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 700);
            Controls.Add(记录表格);
            Controls.Add(筛选面板);
            Name = "测试记录页面";
            Text = "测试记录";
            筛选面板.ResumeLayout(false);
            筛选面板.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)记录表格).EndInit();
            ResumeLayout(false);
        }

        private Panel 筛选面板;
        private DateTimePicker 起始时间框;
        private DateTimePicker 结束时间框;
        private ComboBox 配置框;
        private ComboBox 结果框;
        private TextBox SN框;
        private Button 查询按钮;
        private Label 时间标签;
        private Label 到标签;
        private Label 配置标签;
        private Label 结果标签;
        private Label SN标签;
        private DataGridView 记录表格;
    }
}
