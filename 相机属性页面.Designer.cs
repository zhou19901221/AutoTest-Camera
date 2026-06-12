namespace 自动测试
{
    partial class 相机属性页面
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
            参数列表 = new PropertyGrid();
            关闭按钮 = new Button();
            SuspendLayout();
            // 
            // 参数列表
            // 
            参数列表.Dock = DockStyle.Top;
            参数列表.Location = new Point(0, 0);
            参数列表.Name = "参数列表";
            参数列表.Size = new Size(800, 500);
            参数列表.TabIndex = 0;
            // 
            // 关闭按钮
            // 
            关闭按钮.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            关闭按钮.Location = new Point(700, 520);
            关闭按钮.Name = "关闭按钮";
            关闭按钮.Size = new Size(80, 30);
            关闭按钮.TabIndex = 1;
            关闭按钮.Text = "关闭";
            关闭按钮.UseVisualStyleBackColor = true;
            关闭按钮.Click += 关闭按钮_Click;
            // 
            // 相机属性页面
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 570);
            Controls.Add(关闭按钮);
            Controls.Add(参数列表);
            Name = "相机属性页面";
            Text = "相机属性";
            ResumeLayout(false);
        }

        private PropertyGrid 参数列表;
        private Button 关闭按钮;
    }
}