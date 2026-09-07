namespace 自动测试
{
    partial class 端口测试页面
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
            顶部标题 = new Label();
            模块面板 = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // 顶部标题
            // 
            顶部标题.Dock = DockStyle.Top;
            顶部标题.Font = new Font("Microsoft YaHei UI", 14F, FontStyle.Bold);
            顶部标题.Location = new Point(0, 0);
            顶部标题.Name = "顶部标题";
            顶部标题.Size = new Size(1200, 40);
            顶部标题.TabIndex = 0;
            顶部标题.Text = "端口测试 - 硬件模块连接状态";
            顶部标题.TextAlign = ContentAlignment.MiddleLeft;
            顶部标题.Padding = new Padding(10, 0, 0, 0);
            // 
            // 模块面板
            // 
            模块面板.AutoScroll = true;
            模块面板.FlowDirection = FlowDirection.LeftToRight;
            模块面板.Location = new Point(10, 50);
            模块面板.Name = "模块面板";
            模块面板.Size = new Size(1180, 700);
            模块面板.TabIndex = 1;
            模块面板.WrapContents = true;
            // 
            // 端口测试页面
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 750);
            Controls.Add(模块面板);
            Controls.Add(顶部标题);
            Name = "端口测试页面";
            StartPosition = FormStartPosition.CenterParent;
            Text = "端口测试";
            ResumeLayout(false);
        }

        private Label 顶部标题;
        private FlowLayoutPanel 模块面板;
    }
}