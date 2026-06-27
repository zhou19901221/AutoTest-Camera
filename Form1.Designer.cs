namespace 自动测试
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Context menu and items for the 文件 label


        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            文件 = new Label();
            设置 = new Label();
            label1 = new Label();
            文件菜单 = new ContextMenuStrip(components);
            新建ToolStripMenuItem = new ToolStripMenuItem();
            打开ToolStripMenuItem = new ToolStripMenuItem();
            退出ToolStripMenuItem = new ToolStripMenuItem();
            flowLayoutPanel1 = new FlowLayoutPanel();
            编辑配置 = new Button();
            视觉测试 = new Button();
            端口测试 = new Button();
            日志 = new Button();
            状态提示 = new Label();
            当前配置信息 = new GroupBox();
            选着配置 = new Button();
            配置信息 = new Label();
            label2 = new Label();
            当前配置显示 = new ListBox();
            当前操作日志 = new GroupBox();
            操作日志文本框 = new TextBox();
            进入自动测试 = new Button();
            文件菜单.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            当前配置信息.SuspendLayout();
            当前操作日志.SuspendLayout();
            SuspendLayout();
            // 
            // 文件
            // 
            文件.AutoSize = true;
            文件.Font = new Font("Microsoft YaHei UI", 15F);
            文件.Location = new Point(12, 9);
            文件.Name = "文件";
            文件.Size = new Size(52, 27);
            文件.TabIndex = 1;
            文件.Text = "文件";
            文件.Click += 文件_Click;
            // 
            // 设置
            // 
            设置.AutoSize = true;
            设置.Font = new Font("Microsoft YaHei UI", 15F);
            设置.Location = new Point(83, 9);
            设置.Name = "设置";
            设置.Size = new Size(52, 27);
            设置.TabIndex = 1;
            设置.Text = "设置";
            设置.Click += label1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 15F);
            label1.Location = new Point(158, 9);
            label1.Name = "label1";
            label1.Size = new Size(52, 27);
            label1.TabIndex = 1;
            label1.Text = "操作";
            label1.Click += label1_Click;
            // 
            // 文件菜单
            // 
            文件菜单.Items.AddRange(new ToolStripItem[] { 新建ToolStripMenuItem, 打开ToolStripMenuItem, 退出ToolStripMenuItem });
            文件菜单.Name = "文件菜单";
            文件菜单.Size = new Size(101, 70);
            // 
            // 新建ToolStripMenuItem
            // 
            新建ToolStripMenuItem.Name = "新建ToolStripMenuItem";
            新建ToolStripMenuItem.Size = new Size(100, 22);
            新建ToolStripMenuItem.Text = "新建";
            新建ToolStripMenuItem.Click += 新建ToolStripMenuItem_Click;
            // 
            // 打开ToolStripMenuItem
            // 
            打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            打开ToolStripMenuItem.Size = new Size(100, 22);
            打开ToolStripMenuItem.Text = "打开";
            打开ToolStripMenuItem.Click += 打开ToolStripMenuItem_Click;
            // 
            // 退出ToolStripMenuItem
            // 
            退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            退出ToolStripMenuItem.Size = new Size(100, 22);
            退出ToolStripMenuItem.Text = "退出";
            退出ToolStripMenuItem.Click += 退出ToolStripMenuItem_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.FromArgb(91, 155, 213);
            flowLayoutPanel1.Controls.Add(编辑配置);
            flowLayoutPanel1.Controls.Add(视觉测试);
            flowLayoutPanel1.Controls.Add(端口测试);
            flowLayoutPanel1.Controls.Add(日志);
            flowLayoutPanel1.Location = new Point(20, 50);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(480, 80);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // 编辑配置
            // 
            编辑配置.Anchor = AnchorStyles.None;
            编辑配置.Location = new Point(0, 10);
            编辑配置.Margin = new Padding(0, 0, 50, 0);
            编辑配置.Name = "编辑配置";
            编辑配置.Size = new Size(99, 67);
            编辑配置.TabIndex = 0;
            编辑配置.Text = "编辑配置";
            编辑配置.UseVisualStyleBackColor = true;
            编辑配置.Click += 编辑配置_Click;
            // 
            // 视觉测试
            // 
            视觉测试.Anchor = AnchorStyles.None;
            视觉测试.Location = new Point(159, 10);
            视觉测试.Margin = new Padding(10, 10, 50, 10);
            视觉测试.Name = "视觉测试";
            视觉测试.Size = new Size(99, 67);
            视觉测试.TabIndex = 0;
            视觉测试.Text = "视觉设置";
            视觉测试.UseVisualStyleBackColor = true;
            视觉测试.Click += 视觉测试_Click;
            // 
            // 端口测试
            // 
            端口测试.Anchor = AnchorStyles.None;
            端口测试.Location = new Point(318, 10);
            端口测试.Margin = new Padding(10, 10, 50, 10);
            端口测试.Name = "端口测试";
            端口测试.Size = new Size(99, 67);
            端口测试.TabIndex = 0;
            端口测试.Text = "端口测试";
            端口测试.UseVisualStyleBackColor = true;
            端口测试.Click += 端口测试_Click;
            // 
            // 日志
            // 
            日志.Anchor = AnchorStyles.None;
            日志.Location = new Point(477, 10);
            日志.Margin = new Padding(10, 10, 50, 10);
            日志.Name = "日志";
            日志.Size = new Size(99, 67);
            日志.TabIndex = 0;
            日志.Text = "日志";
            日志.UseVisualStyleBackColor = true;
            // 
            // 状态提示
            // 
            状态提示.Anchor = AnchorStyles.None;
            状态提示.Location = new Point(626, 12);
            状态提示.Margin = new Padding(0);
            状态提示.Name = "状态提示";
            状态提示.Size = new Size(657, 62);
            状态提示.TabIndex = 1;
            状态提示.Text = "状态提示";
            状态提示.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // 当前配置信息
            // 
            当前配置信息.BackColor = Color.White;
            当前配置信息.Controls.Add(选着配置);
            当前配置信息.Controls.Add(配置信息);
            当前配置信息.Controls.Add(label2);
            当前配置信息.Location = new Point(20, 150);
            当前配置信息.Name = "当前配置信息";
            当前配置信息.Size = new Size(480, 130);
            当前配置信息.TabIndex = 3;
            当前配置信息.TabStop = false;
            当前配置信息.Text = "当前配置";
            // 
            // 选着配置
            // 
            选着配置.Location = new Point(368, 83);
            选着配置.Name = "选着配置";
            选着配置.Size = new Size(75, 23);
            选着配置.TabIndex = 1;
            选着配置.Text = "选择配置";
            选着配置.UseVisualStyleBackColor = true;
            // 
            // 配置信息
            // 
            配置信息.Location = new Point(115, 37);
            配置信息.Name = "配置信息";
            配置信息.Size = new Size(208, 34);
            配置信息.TabIndex = 0;
            配置信息.Text = "当前配置";
            配置信息.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Location = new Point(12, 37);
            label2.Name = "label2";
            label2.Size = new Size(93, 34);
            label2.TabIndex = 0;
            label2.Text = "当前加载配置";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // 当前配置显示
            // 
            当前配置显示.FormattingEnabled = true;
            当前配置显示.ItemHeight = 17;
            当前配置显示.Location = new Point(20, 300);
            当前配置显示.Name = "当前配置显示";
            当前配置显示.Size = new Size(480, 580);
            当前配置显示.TabIndex = 4;
            // 
            // 当前操作日志
            // 
            当前操作日志.BackColor = Color.White;
            当前操作日志.Controls.Add(操作日志文本框);
            当前操作日志.Location = new Point(1000, 50);
            当前操作日志.Name = "当前操作日志";
            当前操作日志.Size = new Size(420, 830);
            当前操作日志.TabIndex = 5;
            当前操作日志.TabStop = false;
            当前操作日志.Text = "当前操作日志";
            // 
            // 操作日志文本框
            // 
            操作日志文本框.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            操作日志文本框.Location = new Point(6, 22);
            操作日志文本框.Multiline = true;
            操作日志文本框.Name = "操作日志文本框";
            操作日志文本框.ReadOnly = true;
            操作日志文本框.ScrollBars = ScrollBars.Vertical;
            操作日志文本框.Size = new Size(408, 802);
            操作日志文本框.TabIndex = 0;
            // 
            // 进入自动测试
            // 
            进入自动测试.BackColor = Color.FromArgb(43, 87, 154);
            进入自动测试.FlatStyle = FlatStyle.Flat;
            进入自动测试.ForeColor = Color.White;
            进入自动测试.Font = new Font("Microsoft YaHei UI", 14F);
            进入自动测试.Location = new Point(540, 300);
            进入自动测试.Name = "进入自动测试";
            进入自动测试.Size = new Size(420, 200);
            进入自动测试.TabIndex = 6;
            进入自动测试.Text = "进入自动测试";
            进入自动测试.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 240, 240);
            ClientSize = new Size(1440, 900);
            Controls.Add(进入自动测试);
            Controls.Add(当前操作日志);
            Controls.Add(当前配置显示);
            Controls.Add(当前配置信息);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(label1);
            Controls.Add(设置);
            Controls.Add(文件);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "杭州诺斯科技有限公司";
            文件菜单.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            当前配置信息.ResumeLayout(false);
            当前操作日志.ResumeLayout(false);
            当前操作日志.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label 文件;
        private Label 设置;
        private Label label1;
        private ContextMenuStrip 文件菜单;
        private ToolStripMenuItem 新建ToolStripMenuItem;
        private ToolStripMenuItem 打开ToolStripMenuItem;
        private ToolStripMenuItem 退出ToolStripMenuItem;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button 编辑配置;
        private Button 视觉测试;
        private Button 端口测试;
        private Button 日志;
        private Label 状态提示;
        private GroupBox 当前配置信息;
        private Button 选着配置;
        private Label 配置信息;
        private Label label2;
        private ListBox 当前配置显示;
        private GroupBox 当前操作日志;
        private Button 进入自动测试;
        private TextBox 操作日志文本框;
    }
}
