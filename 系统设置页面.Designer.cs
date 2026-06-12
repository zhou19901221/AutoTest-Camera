namespace 自动测试
{
    partial class 系统设置页面
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
            标签导航 = new TabControl();
            基础参数页 = new TabPage();
            检测设置页 = new TabPage();
            运动控制页 = new TabPage();
            电压模块页 = new TabPage();
            电流模块页 = new TabPage();
            IO模块页 = new TabPage();
            PWM模块页 = new TabPage();
            其它模块页 = new TabPage();
            平台视觉页 = new TabPage();
            MESS设置页 = new TabPage();
            其他设置页 = new TabPage();
            保存按钮 = new Button();
            取消按钮 = new Button();

            SuspendLayout();
            // 
            // 标签导航
            // 
            标签导航.Controls.Add(基础参数页);
            标签导航.Controls.Add(检测设置页);
            标签导航.Controls.Add(运动控制页);
            标签导航.Controls.Add(电压模块页);
            标签导航.Controls.Add(电流模块页);
            标签导航.Controls.Add(IO模块页);
            标签导航.Controls.Add(PWM模块页);
            标签导航.Controls.Add(其它模块页);
            标签导航.Controls.Add(平台视觉页);
            标签导航.Controls.Add(MESS设置页);
            标签导航.Controls.Add(其他设置页);
            标签导航.Dock = DockStyle.Top;
            标签导航.Location = new Point(0, 0);
            标签导航.Name = "标签导航";
            标签导航.SelectedIndex = 0;
            标签导航.Size = new Size(1200, 650);
            标签导航.TabIndex = 0;
            // 
            // 基础参数页
            // 
            基础参数页.Location = new Point(4, 24);
            基础参数页.Name = "基础参数页";
            基础参数页.Padding = new Padding(3);
            基础参数页.Size = new Size(1192, 622);
            基础参数页.TabIndex = 0;
            基础参数页.Text = "基础参数";
            基础参数页.UseVisualStyleBackColor = true;
            基础参数页.AutoScroll = true;
            // 
            // 运动控制页
            // 
            运动控制页.Location = new Point(4, 24);
            运动控制页.Name = "运动控制页";
            运动控制页.Size = new Size(1192, 622);
            运动控制页.TabIndex = 1;
            运动控制页.Text = "运动控制";
            运动控制页.UseVisualStyleBackColor = true;
            运动控制页.AutoScroll = true;
            // 
            // 检测设置页
            // 
            检测设置页.Location = new Point(4, 24);
            检测设置页.Name = "检测设置页";
            检测设置页.Size = new Size(1192, 622);
            检测设置页.TabIndex = 2;
            检测设置页.Text = "检测设置";
            检测设置页.UseVisualStyleBackColor = true;
            检测设置页.AutoScroll = true;
            // 
            // 电压模块页
            // 
            电压模块页.Location = new Point(4, 24);
            电压模块页.Name = "电压模块页";
            电压模块页.Size = new Size(1192, 622);
            电压模块页.TabIndex = 3;
            电压模块页.Text = "电压模块";
            电压模块页.UseVisualStyleBackColor = true;
            电压模块页.AutoScroll = true;
            // 
            // 电流模块页
            // 
            电流模块页.Location = new Point(4, 24);
            电流模块页.Name = "电流模块页";
            电流模块页.Size = new Size(1192, 622);
            电流模块页.TabIndex = 4;
            电流模块页.Text = "电流模块";
            电流模块页.UseVisualStyleBackColor = true;
            电流模块页.AutoScroll = true;
            // 
            // IO模块页
            // 
            IO模块页.Location = new Point(4, 24);
            IO模块页.Name = "IO模块页";
            IO模块页.Size = new Size(1192, 622);
            IO模块页.TabIndex = 5;
            IO模块页.Text = "IO模块参数";
            IO模块页.UseVisualStyleBackColor = true;
            IO模块页.AutoScroll = true;
            // 
            // PWM模块页
            // 
            PWM模块页.Location = new Point(4, 24);
            PWM模块页.Name = "PWM模块页";
            PWM模块页.Size = new Size(1192, 622);
            PWM模块页.TabIndex = 6;
            PWM模块页.Text = "PWM模块";
            PWM模块页.UseVisualStyleBackColor = true;
            PWM模块页.AutoScroll = true;
            // 
            // 其它模块页
            // 
            其它模块页.Location = new Point(4, 24);
            其它模块页.Name = "其它模块页";
            其它模块页.Size = new Size(1192, 622);
            其它模块页.TabIndex = 7;
            其它模块页.Text = "其它模块参数";
            其它模块页.UseVisualStyleBackColor = true;
            其它模块页.AutoScroll = true;
            // 
            // 平台视觉页
            // 
            平台视觉页.Location = new Point(4, 24);
            平台视觉页.Name = "平台视觉页";
            平台视觉页.Size = new Size(1192, 622);
            平台视觉页.TabIndex = 8;
            平台视觉页.Text = "平台视觉参数";
            平台视觉页.UseVisualStyleBackColor = true;
            平台视觉页.AutoScroll = true;
            // 
            // MESS设置页
            // 
            MESS设置页.Location = new Point(4, 24);
            MESS设置页.Name = "MESS设置页";
            MESS设置页.Size = new Size(1192, 622);
            MESS设置页.TabIndex = 9;
            MESS设置页.Text = "MESS设置";
            MESS设置页.UseVisualStyleBackColor = true;
            MESS设置页.AutoScroll = true;
            // 
            // 其他设置页
            // 
            其他设置页.Location = new Point(4, 24);
            其他设置页.Name = "其他设置页";
            其他设置页.Size = new Size(1192, 622);
            其他设置页.TabIndex = 10;
            其他设置页.Text = "其他设置";
            其他设置页.UseVisualStyleBackColor = true;
            其他设置页.AutoScroll = true;
            // 
            // 保存按钮
            // 
            保存按钮.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            保存按钮.Location = new Point(1000, 670);
            保存按钮.Name = "保存按钮";
            保存按钮.Size = new Size(80, 30);
            保存按钮.TabIndex = 1;
            保存按钮.Text = "保存";
            保存按钮.UseVisualStyleBackColor = true;
            保存按钮.Click += 保存按钮_Click;
            // 
            // 取消按钮
            // 
            取消按钮.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            取消按钮.Location = new Point(1100, 670);
            取消按钮.Name = "取消按钮";
            取消按钮.Size = new Size(80, 30);
            取消按钮.TabIndex = 2;
            取消按钮.Text = "取消";
            取消按钮.UseVisualStyleBackColor = true;
            取消按钮.Click += 取消按钮_Click;
            // 
            // 系统设置页面
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 720);
            Controls.Add(取消按钮);
            Controls.Add(保存按钮);
            Controls.Add(标签导航);
            Name = "系统设置页面";
            Text = "高级系统设置";

            ResumeLayout(false);
        }

        private TabControl 标签导航;
        private TabPage 基础参数页;
        private TabPage 检测设置页;
        private TabPage 运动控制页;
        private TabPage 电压模块页;
        private TabPage 电流模块页;
        private TabPage IO模块页;
        private TabPage PWM模块页;
        private TabPage 其它模块页;
        private TabPage 平台视觉页;
        private TabPage MESS设置页;
        private TabPage 其他设置页;
        private Button 保存按钮;
        private Button 取消按钮;
    }
}