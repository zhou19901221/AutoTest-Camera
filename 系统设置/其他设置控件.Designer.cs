namespace 自动测试
{
    partial class 其他设置控件
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
            this.网络组 = new System.Windows.Forms.GroupBox();
            this.内存偏移框 = new System.Windows.Forms.NumericUpDown();
            this.内存偏移标签 = new System.Windows.Forms.Label();
            this.PLC端口框 = new System.Windows.Forms.NumericUpDown();
            this.PLC端口标签 = new System.Windows.Forms.Label();
            this.PLC地址框 = new System.Windows.Forms.TextBox();
            this.PLC地址标签 = new System.Windows.Forms.Label();
            this.License组 = new System.Windows.Forms.GroupBox();
            this.Days标签 = new System.Windows.Forms.Label();
            this.Days框 = new System.Windows.Forms.NumericUpDown();
            this.LicensePrompt框 = new System.Windows.Forms.CheckBox();
            this.License框 = new System.Windows.Forms.CheckBox();
            this.颜色组 = new System.Windows.Forms.GroupBox();
            this.空走状态框 = new System.Windows.Forms.ComboBox();
            this.空走状态标签 = new System.Windows.Forms.Label();
            this.当前路径框 = new System.Windows.Forms.ComboBox();
            this.当前路径标签 = new System.Windows.Forms.Label();
            this.路径颜色框 = new System.Windows.Forms.ComboBox();
            this.路径颜色标签 = new System.Windows.Forms.Label();
            this.选择状态框 = new System.Windows.Forms.ComboBox();
            this.选择状态标签 = new System.Windows.Forms.Label();
            this.通讯组 = new System.Windows.Forms.GroupBox();
            this.保存文件路径框 = new System.Windows.Forms.TextBox();
            this.保存文件路径标签 = new System.Windows.Forms.Label();
            this.字符格式框 = new System.Windows.Forms.CheckBox();
            this.记录类型框 = new System.Windows.Forms.ComboBox();
            this.记录类型标签 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.内存偏移框)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PLC端口框)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Days框)).BeginInit();
            this.网络组.SuspendLayout();
            this.License组.SuspendLayout();
            this.颜色组.SuspendLayout();
            this.通讯组.SuspendLayout();
            this.SuspendLayout();
            // 
            // 网络组
            // 
            this.网络组.Controls.Add(this.内存偏移框);
            this.网络组.Controls.Add(this.内存偏移标签);
            this.网络组.Controls.Add(this.PLC端口框);
            this.网络组.Controls.Add(this.PLC端口标签);
            this.网络组.Controls.Add(this.PLC地址框);
            this.网络组.Controls.Add(this.PLC地址标签);
            this.网络组.Location = new System.Drawing.Point(20, 20);
            this.网络组.Name = "网络组";
            this.网络组.Size = new System.Drawing.Size(350, 100);
            this.网络组.TabIndex = 0;
            this.网络组.TabStop = false;
            this.网络组.Text = "网络设置";
            // 
            // PLC地址标签
            // 
            this.PLC地址标签.AutoSize = true;
            this.PLC地址标签.Location = new System.Drawing.Point(20, 25);
            this.PLC地址标签.Name = "PLC地址标签";
            this.PLC地址标签.Size = new System.Drawing.Size(60, 17);
            this.PLC地址标签.TabIndex = 0;
            this.PLC地址标签.Text = "PLC地址：";
            // 
            // PLC地址框
            // 
            this.PLC地址框.Location = new System.Drawing.Point(100, 22);
            this.PLC地址框.Name = "PLC地址框";
            this.PLC地址框.Size = new System.Drawing.Size(200, 23);
            this.PLC地址框.TabIndex = 1;
            this.PLC地址框.Text = "192.168.1.1";
            // 
            // PLC端口标签
            // 
            this.PLC端口标签.AutoSize = true;
            this.PLC端口标签.Location = new System.Drawing.Point(20, 55);
            this.PLC端口标签.Name = "PLC端口标签";
            this.PLC端口标签.Size = new System.Drawing.Size(60, 17);
            this.PLC端口标签.TabIndex = 2;
            this.PLC端口标签.Text = "PLC端口：";
            // 
            // PLC端口框
            // 
            this.PLC端口框.Location = new System.Drawing.Point(100, 52);
            this.PLC端口框.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.PLC端口框.Name = "PLC端口框";
            this.PLC端口框.Size = new System.Drawing.Size(80, 23);
            this.PLC端口框.TabIndex = 3;
            this.PLC端口框.Value = new decimal(new int[] {
            520,
            0,
            0,
            0});
            // 
            // 内存偏移标签
            // 
            this.内存偏移标签.AutoSize = true;
            this.内存偏移标签.Location = new System.Drawing.Point(180, 55);
            this.内存偏移标签.Name = "内存偏移标签";
            this.内存偏移标签.Size = new System.Drawing.Size(68, 17);
            this.内存偏移标签.TabIndex = 4;
            this.内存偏移标签.Text = "内存偏移：";
            // 
            // 内存偏移框
            // 
            this.内存偏移框.Location = new System.Drawing.Point(260, 52);
            this.内存偏移框.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.内存偏移框.Name = "内存偏移框";
            this.内存偏移框.Size = new System.Drawing.Size(80, 23);
            this.内存偏移框.TabIndex = 5;
            // 
            // License组
            // 
            this.License组.Controls.Add(this.Days标签);
            this.License组.Controls.Add(this.Days框);
            this.License组.Controls.Add(this.LicensePrompt框);
            this.License组.Controls.Add(this.License框);
            this.License组.Location = new System.Drawing.Point(400, 20);
            this.License组.Name = "License组";
            this.License组.Size = new System.Drawing.Size(350, 100);
            this.License组.TabIndex = 1;
            this.License组.TabStop = false;
            this.License组.Text = "License";
            // 
            // License框
            // 
            this.License框.AutoSize = true;
            this.License框.Location = new System.Drawing.Point(20, 25);
            this.License框.Name = "License框";
            this.License框.Size = new System.Drawing.Size(68, 21);
            this.License框.TabIndex = 0;
            this.License框.Text = "License";
            this.License框.UseVisualStyleBackColor = true;
            // 
            // LicensePrompt框
            // 
            this.LicensePrompt框.AutoSize = true;
            this.LicensePrompt框.Checked = true;
            this.LicensePrompt框.CheckState = System.Windows.Forms.CheckState.Checked;
            this.LicensePrompt框.Location = new System.Drawing.Point(20, 55);
            this.LicensePrompt框.Name = "LicensePrompt框";
            this.LicensePrompt框.Size = new System.Drawing.Size(116, 21);
            this.LicensePrompt框.TabIndex = 1;
            this.LicensePrompt框.Text = "License Prompt";
            this.LicensePrompt框.UseVisualStyleBackColor = true;
            // 
            // Days框
            // 
            this.Days框.Location = new System.Drawing.Point(150, 52);
            this.Days框.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.Days框.Name = "Days框";
            this.Days框.Size = new System.Drawing.Size(80, 23);
            this.Days框.TabIndex = 2;
            // 
            // Days标签
            // 
            this.Days标签.AutoSize = true;
            this.Days标签.Location = new System.Drawing.Point(240, 55);
            this.Days标签.Name = "Days标签";
            this.Days标签.Size = new System.Drawing.Size(35, 17);
            this.Days标签.TabIndex = 3;
            this.Days标签.Text = "Days";
            // 
            // 颜色组
            // 
            this.颜色组.Controls.Add(this.空走状态框);
            this.颜色组.Controls.Add(this.空走状态标签);
            this.颜色组.Controls.Add(this.当前路径框);
            this.颜色组.Controls.Add(this.当前路径标签);
            this.颜色组.Controls.Add(this.路径颜色框);
            this.颜色组.Controls.Add(this.路径颜色标签);
            this.颜色组.Controls.Add(this.选择状态框);
            this.颜色组.Controls.Add(this.选择状态标签);
            this.颜色组.Location = new System.Drawing.Point(20, 130);
            this.颜色组.Name = "颜色组";
            this.颜色组.Size = new System.Drawing.Size(500, 120);
            this.颜色组.TabIndex = 2;
            this.颜色组.TabStop = false;
            this.颜色组.Text = "相机平台路径状态色";
            // 
            // 选择状态标签
            // 
            this.选择状态标签.AutoSize = true;
            this.选择状态标签.Location = new System.Drawing.Point(20, 25);
            this.选择状态标签.Name = "选择状态标签";
            this.选择状态标签.Size = new System.Drawing.Size(68, 17);
            this.选择状态标签.TabIndex = 0;
            this.选择状态标签.Text = "选择状态：";
            // 
            // 选择状态框
            // 
            this.选择状态框.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.选择状态框.FormattingEnabled = true;
            this.选择状态框.Items.AddRange(new object[] {
            "dLime",
            "dRed",
            "dBlue"});
            this.选择状态框.Location = new System.Drawing.Point(120, 22);
            this.选择状态框.Name = "选择状态框";
            this.选择状态框.Size = new System.Drawing.Size(100, 23);
            this.选择状态框.TabIndex = 1;
            this.选择状态框.SelectedIndex = 0;
            // 
            // 路径颜色标签
            // 
            this.路径颜色标签.AutoSize = true;
            this.路径颜色标签.Location = new System.Drawing.Point(250, 25);
            this.路径颜色标签.Size = new System.Drawing.Size(68, 17);
            this.路径颜色标签.TabIndex = 2;
            this.路径颜色标签.Text = "路径颜色：";
            // 
            // 路径颜色框
            // 
            this.路径颜色框.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.路径颜色框.FormattingEnabled = true;
            this.路径颜色框.Items.AddRange(new object[] {
            "dAqua",
            "dRed",
            "dBlue"});
            this.路径颜色框.Location = new System.Drawing.Point(350, 22);
            this.路径颜色框.Name = "路径颜色框";
            this.路径颜色框.Size = new System.Drawing.Size(100, 23);
            this.路径颜色框.TabIndex = 3;
            this.路径颜色框.SelectedIndex = 0;
            // 
            // 当前路径标签
            // 
            this.当前路径标签.AutoSize = true;
            this.当前路径标签.Location = new System.Drawing.Point(20, 55);
            this.当前路径标签.Name = "当前路径标签";
            this.当前路径标签.Size = new System.Drawing.Size(68, 17);
            this.当前路径标签.TabIndex = 4;
            this.当前路径标签.Text = "当前路径：";
            // 
            // 当前路径框
            // 
            this.当前路径框.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.当前路径框.FormattingEnabled = true;
            this.当前路径框.Items.AddRange(new object[] {
            "dFuchsia",
            "dRed",
            "dBlue"});
            this.当前路径框.Location = new System.Drawing.Point(120, 52);
            this.当前路径框.Name = "当前路径框";
            this.当前路径框.Size = new System.Drawing.Size(100, 23);
            this.当前路径框.TabIndex = 5;
            this.当前路径框.SelectedIndex = 0;
            // 
            // 空走状态标签
            // 
            this.空走状态标签.AutoSize = true;
            this.空走状态标签.Location = new System.Drawing.Point(250, 55);
            this.空走状态标签.Name = "空走状态标签";
            this.空走状态标签.Size = new System.Drawing.Size(68, 17);
            this.空走状态标签.TabIndex = 6;
            this.空走状态标签.Text = "空走状态：";
            // 
            // 空走状态框
            // 
            this.空走状态框.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.空走状态框.FormattingEnabled = true;
            this.空走状态框.Items.AddRange(new object[] {
            "dBlue",
            "dRed",
            "dGreen"});
            this.空走状态框.Location = new System.Drawing.Point(350, 52);
            this.空走状态框.Name = "空走状态框";
            this.空走状态框.Size = new System.Drawing.Size(100, 23);
            this.空走状态框.TabIndex = 7;
            this.空走状态框.SelectedIndex = 0;
            // 
            // 通讯组
            // 
            this.通讯组.Controls.Add(this.保存文件路径框);
            this.通讯组.Controls.Add(this.保存文件路径标签);
            this.通讯组.Controls.Add(this.字符格式框);
            this.通讯组.Controls.Add(this.记录类型框);
            this.通讯组.Controls.Add(this.记录类型标签);
            this.通讯组.Location = new System.Drawing.Point(20, 260);
            this.通讯组.Name = "通讯组";
            this.通讯组.Size = new System.Drawing.Size(500, 120);
            this.通讯组.TabIndex = 3;
            this.通讯组.TabStop = false;
            this.通讯组.Text = "通讯数据";
            // 
            // 记录类型标签
            // 
            this.记录类型标签.AutoSize = true;
            this.记录类型标签.Location = new System.Drawing.Point(20, 25);
            this.记录类型标签.Name = "记录类型标签";
            this.记录类型标签.Size = new System.Drawing.Size(68, 17);
            this.记录类型标签.TabIndex = 0;
            this.记录类型标签.Text = "记录类型：";
            // 
            // 记录类型框
            // 
            this.记录类型框.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.记录类型框.FormattingEnabled = true;
            this.记录类型框.Items.AddRange(new object[] {
            "不记录",
            "记录",
            "仅错误"});
            this.记录类型框.Location = new System.Drawing.Point(120, 22);
            this.记录类型框.Name = "记录类型框";
            this.记录类型框.Size = new System.Drawing.Size(100, 23);
            this.记录类型框.TabIndex = 1;
            this.记录类型框.SelectedIndex = 0;
            // 
            // 字符格式框
            // 
            this.字符格式框.AutoSize = true;
            this.字符格式框.Location = new System.Drawing.Point(250, 25);
            this.字符格式框.Name = "字符格式框";
            this.字符格式框.Size = new System.Drawing.Size(80, 21);
            this.字符格式框.TabIndex = 2;
            this.字符格式框.Text = "字符格式";
            this.字符格式框.UseVisualStyleBackColor = true;
            // 
            // 保存文件路径标签
            // 
            this.保存文件路径标签.AutoSize = true;
            this.保存文件路径标签.Location = new System.Drawing.Point(20, 55);
            this.保存文件路径标签.Name = "保存文件路径标签";
            this.保存文件路径标签.Size = new System.Drawing.Size(92, 17);
            this.保存文件路径标签.TabIndex = 3;
            this.保存文件路径标签.Text = "保存文件路径：";
            // 
            // 保存文件路径框
            // 
            this.保存文件路径框.Location = new System.Drawing.Point(120, 52);
            this.保存文件路径框.Name = "保存文件路径框";
            this.保存文件路径框.Size = new System.Drawing.Size(300, 23);
            this.保存文件路径框.TabIndex = 4;
            this.保存文件路径框.Text = "D:\\ComLog\\";
            // 
            // 其他设置控件
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.通讯组);
            this.Controls.Add(this.颜色组);
            this.Controls.Add(this.License组);
            this.Controls.Add(this.网络组);
            this.Name = "其他设置控件";
            this.Size = new System.Drawing.Size(1200, 500);
            ((System.ComponentModel.ISupportInitialize)(this.内存偏移框)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PLC端口框)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Days框)).EndInit();
            this.网络组.ResumeLayout(false);
            this.网络组.PerformLayout();
            this.License组.ResumeLayout(false);
            this.License组.PerformLayout();
            this.颜色组.ResumeLayout(false);
            this.颜色组.PerformLayout();
            this.通讯组.ResumeLayout(false);
            this.通讯组.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.GroupBox 网络组;
        private System.Windows.Forms.NumericUpDown 内存偏移框;
        private System.Windows.Forms.Label 内存偏移标签;
        private System.Windows.Forms.NumericUpDown PLC端口框;
        private System.Windows.Forms.Label PLC端口标签;
        private System.Windows.Forms.TextBox PLC地址框;
        private System.Windows.Forms.Label PLC地址标签;
        private System.Windows.Forms.GroupBox License组;
        private System.Windows.Forms.Label Days标签;
        private System.Windows.Forms.NumericUpDown Days框;
        private System.Windows.Forms.CheckBox LicensePrompt框;
        private System.Windows.Forms.CheckBox License框;
        private System.Windows.Forms.GroupBox 颜色组;
        private System.Windows.Forms.ComboBox 空走状态框;
        private System.Windows.Forms.Label 空走状态标签;
        private System.Windows.Forms.ComboBox 当前路径框;
        private System.Windows.Forms.Label 当前路径标签;
        private System.Windows.Forms.ComboBox 路径颜色框;
        private System.Windows.Forms.Label 路径颜色标签;
        private System.Windows.Forms.ComboBox 选择状态框;
        private System.Windows.Forms.Label 选择状态标签;
        private System.Windows.Forms.GroupBox 通讯组;
        private System.Windows.Forms.TextBox 保存文件路径框;
        private System.Windows.Forms.Label 保存文件路径标签;
        private System.Windows.Forms.CheckBox 字符格式框;
        private System.Windows.Forms.ComboBox 记录类型框;
        private System.Windows.Forms.Label 记录类型标签;
    }
}