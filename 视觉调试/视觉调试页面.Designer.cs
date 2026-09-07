namespace 自动测试
{
    partial class 视觉调试页面
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            加载图像 = new Button();
            视觉显示图像 = new PictureBox();
            图像坐标信息 = new Label();
            相机数据 = new GroupBox();
            相机设置 = new Button();
            抓取图像 = new Button();
            图像源容器 = new GroupBox();
            图片列表 = new ListBox();
            选择目录按钮 = new Button();
            图片目录路径 = new TextBox();
            图片目录标签 = new Label();
            图像源选择 = new ComboBox();
            图像源标签 = new Label();
            ((System.ComponentModel.ISupportInitialize)视觉显示图像).BeginInit();
            相机数据.SuspendLayout();
            图像源容器.SuspendLayout();
            SuspendLayout();
            // 
            // 加载图像
            // 
            加载图像.Location = new Point(6, 52);
            加载图像.Name = "加载图像";
            加载图像.Size = new Size(100, 30);
            加载图像.TabIndex = 0;
            加载图像.Text = "加载图像";
            加载图像.UseVisualStyleBackColor = true;
            加载图像.Click += 加载图像_Click;
            // 
            // 视觉显示图像
            // 
            视觉显示图像.Location = new Point(12, 50);
            视觉显示图像.Name = "视觉显示图像";
            视觉显示图像.Size = new Size(800, 600);
            视觉显示图像.SizeMode = PictureBoxSizeMode.Zoom;
            视觉显示图像.TabIndex = 1;
            视觉显示图像.TabStop = false;
            视觉显示图像.MouseMove += 视觉显示图像_MouseMove;
            视觉显示图像.MouseWheel += 视觉显示图像_MouseWheel;
            // 
            // 图像坐标信息
            // 
            图像坐标信息.Location = new Point(6, 19);
            图像坐标信息.Name = "图像坐标信息";
            图像坐标信息.Size = new Size(188, 30);
            图像坐标信息.TabIndex = 2;
            图像坐标信息.Text = "坐标：X=0, Y=0";
            图像坐标信息.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // 相机数据
            // 
            相机数据.Controls.Add(图像坐标信息);
            相机数据.Controls.Add(相机设置);
            相机数据.Controls.Add(抓取图像);
            相机数据.Controls.Add(加载图像);
            相机数据.Location = new Point(847, 39);
            相机数据.Name = "相机数据";
            相机数据.Size = new Size(471, 110);
            相机数据.TabIndex = 3;
            相机数据.TabStop = false;
            相机数据.Text = "相机属性";
            // 
            // 相机设置
            // 
            相机设置.Location = new Point(239, 52);
            相机设置.Name = "相机设置";
            相机设置.Size = new Size(100, 30);
            相机设置.TabIndex = 0;
            相机设置.Text = "相机设置";
            相机设置.UseVisualStyleBackColor = true;
            相机设置.Click += 相机设置_Click;
            // 
            // 抓取图像
            // 
            抓取图像.Location = new Point(121, 52);
            抓取图像.Name = "抓取图像";
            抓取图像.Size = new Size(100, 30);
            抓取图像.TabIndex = 0;
            抓取图像.Text = "抓取图像";
            抓取图像.UseVisualStyleBackColor = true;
            抓取图像.Click += 抓取图像_Click;
            // 
            // 图像源容器
            // 
            图像源容器.Controls.Add(图片列表);
            图像源容器.Controls.Add(选择目录按钮);
            图像源容器.Controls.Add(图片目录路径);
            图像源容器.Controls.Add(图片目录标签);
            图像源容器.Controls.Add(图像源选择);
            图像源容器.Controls.Add(图像源标签);
            图像源容器.Location = new Point(847, 160);
            图像源容器.Name = "图像源容器";
            图像源容器.Size = new Size(471, 250);
            图像源容器.TabIndex = 4;
            图像源容器.TabStop = false;
            图像源容器.Text = "图像源";
            // 
            // 图片列表
            // 
            图片列表.FormattingEnabled = true;
            图片列表.Location = new Point(6, 81);
            图片列表.Name = "图片列表";
            图片列表.Size = new Size(459, 160);
            图片列表.TabIndex = 5;
            图片列表.SelectedIndexChanged += 图片列表_SelectedIndexChanged;
            // 
            // 选择目录按钮
            // 
            选择目录按钮.Location = new Point(366, 52);
            选择目录按钮.Name = "选择目录按钮";
            选择目录按钮.Size = new Size(75, 23);
            选择目录按钮.TabIndex = 4;
            选择目录按钮.Text = "选择目录";
            选择目录按钮.UseVisualStyleBackColor = true;
            选择目录按钮.Click += 选择目录按钮_Click;
            // 
            // 图片目录路径
            // 
            图片目录路径.Location = new Point(80, 52);
            图片目录路径.Name = "图片目录路径";
            图片目录路径.ReadOnly = true;
            图片目录路径.Size = new Size(280, 23);
            图片目录路径.TabIndex = 3;
            // 
            // 图片目录标签
            // 
            图片目录标签.AutoSize = true;
            图片目录标签.Location = new Point(6, 55);
            图片目录标签.Name = "图片目录标签";
            图片目录标签.Size = new Size(56, 17);
            图片目录标签.TabIndex = 2;
            图片目录标签.Text = "图片目录";
            // 
            // 图像源选择
            // 
            图像源选择.DropDownStyle = ComboBoxStyle.DropDownList;
            图像源选择.FormattingEnabled = true;
            图像源选择.Items.AddRange(new object[] { "相机", "照片" });
            图像源选择.Location = new Point(80, 22);
            图像源选择.Name = "图像源选择";
            图像源选择.Size = new Size(100, 23);
            图像源选择.TabIndex = 1;
            图像源选择.SelectedIndexChanged += 图像源选择_SelectedIndexChanged;
            // 
            // 图像源标签
            // 
            图像源标签.AutoSize = true;
            图像源标签.Location = new Point(6, 25);
            图像源标签.Name = "图像源标签";
            图像源标签.Size = new Size(44, 17);
            图像源标签.TabIndex = 0;
            图像源标签.Text = "图像源";
            // 
            // 视觉调试页面
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1350, 729);
            Controls.Add(图像源容器);
            Controls.Add(相机数据);
            Controls.Add(视觉显示图像);
            Name = "视觉调试页面";
            Text = "视觉调试页面";
            ((System.ComponentModel.ISupportInitialize)视觉显示图像).EndInit();
            相机数据.ResumeLayout(false);
            图像源容器.ResumeLayout(false);
            图像源容器.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button 加载图像;
        private PictureBox 视觉显示图像;
        private Label 图像坐标信息;
        private GroupBox 相机数据;
        private Button 抓取图像;
        private Button 相机设置;
        private GroupBox 图像源容器;
        private ListBox 图片列表;
        private Button 选择目录按钮;
        private TextBox 图片目录路径;
        private Label 图片目录标签;
        private ComboBox 图像源选择;
        private Label 图像源标签;
    }
}