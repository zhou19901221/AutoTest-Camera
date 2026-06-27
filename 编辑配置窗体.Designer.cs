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
            标签导航 = new TabControl();
            基础参数页 = new TabPage();
            检测设置页 = new TabPage();
            运动控制页 = new TabPage();
            电压模块页 = new TabPage();
            MESS设置页 = new TabPage();
            其他设置页 = new TabPage();
            保存按钮 = new Button();
            取消按钮 = new Button();
            重置按钮 = new Button();
            
            基础参数组 = new GroupBox();
            设备名称标签 = new Label();
            设备名称框 = new TextBox();
            设备编号标签 = new Label();
            设备编号框 = new TextBox();
            操作员标签 = new Label();
            操作员框 = new TextBox();
            
            检测设置组 = new GroupBox();
            检测次数标签 = new Label();
            检测次数框 = new NumericUpDown();
            检测间隔标签 = new Label();
            检测间隔框 = new NumericUpDown();
            通讯异常组 = new GroupBox();
            通讯次数标签 = new Label();
            通讯次数框 = new NumericUpDown();
            通讯间隔标签 = new Label();
            通讯间隔框 = new NumericUpDown();
            
            MESS设置组 = new GroupBox();
            启用MESS框 = new CheckBox();
            服务器地址标签 = new Label();
            服务器地址框 = new TextBox();
            端口标签 = new Label();
            端口框 = new NumericUpDown();
            
            其他设置组 = new GroupBox();
            日志路径标签 = new Label();
            日志路径框 = new TextBox();
            浏览按钮 = new Button();
            自动保存日志框 = new CheckBox();
            日志保留天数标签 = new Label();
            日志保留天数框 = new NumericUpDown();

            标签导航.SuspendLayout();
            基础参数页.SuspendLayout();
            检测设置页.SuspendLayout();
            MESS设置页.SuspendLayout();
            其他设置页.SuspendLayout();
            基础参数组.SuspendLayout();
            检测设置组.SuspendLayout();
            通讯异常组.SuspendLayout();
            MESS设置组.SuspendLayout();
            其他设置组.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)检测次数框).BeginInit();
            ((System.ComponentModel.ISupportInitialize)检测间隔框).BeginInit();
            ((System.ComponentModel.ISupportInitialize)通讯次数框).BeginInit();
            ((System.ComponentModel.ISupportInitialize)通讯间隔框).BeginInit();
            ((System.ComponentModel.ISupportInitialize)端口框).BeginInit();
            ((System.ComponentModel.ISupportInitialize)日志保留天数框).BeginInit();
            SuspendLayout();

            标签导航.Controls.Add(基础参数页);
            标签导航.Controls.Add(检测设置页);
            标签导航.Controls.Add(运动控制页);
            标签导航.Controls.Add(电压模块页);
            标签导航.Controls.Add(MESS设置页);
            标签导航.Controls.Add(其他设置页);
            标签导航.Location = new Point(20, 20);
            标签导航.Name = "标签导航";
            标签导航.SelectedIndex = 0;
            标签导航.Size = new Size(760, 450);
            标签导航.TabIndex = 0;

            基础参数页.Controls.Add(基础参数组);
            基础参数页.Location = new Point(4, 26);
            基础参数页.Name = "基础参数页";
            基础参数页.Size = new Size(752, 420);
            基础参数页.TabIndex = 0;
            基础参数页.Text = "基础参数";
            基础参数页.UseVisualStyleBackColor = true;

            基础参数组.Controls.Add(设备名称标签);
            基础参数组.Controls.Add(设备名称框);
            基础参数组.Controls.Add(设备编号标签);
            基础参数组.Controls.Add(设备编号框);
            基础参数组.Controls.Add(操作员标签);
            基础参数组.Controls.Add(操作员框);
            基础参数组.Location = new Point(20, 20);
            基础参数组.Name = "基础参数组";
            基础参数组.Size = new Size(700, 180);
            基础参数组.TabIndex = 0;
            基础参数组.TabStop = false;
            基础参数组.Text = "设备信息";

            设备名称标签.Location = new Point(20, 30);
            设备名称标签.Name = "设备名称标签";
            设备名称标签.Size = new Size(80, 23);
            设备名称标签.TabIndex = 0;
            设备名称标签.Text = "设备名称：";
            设备名称标签.TextAlign = ContentAlignment.MiddleRight;

            设备名称框.Location = new Point(110, 30);
            设备名称框.Name = "设备名称框";
            设备名称框.Size = new Size(200, 23);
            设备名称框.TabIndex = 1;

            设备编号标签.Location = new Point(20, 70);
            设备编号标签.Name = "设备编号标签";
            设备编号标签.Size = new Size(80, 23);
            设备编号标签.TabIndex = 2;
            设备编号标签.Text = "设备编号：";
            设备编号标签.TextAlign = ContentAlignment.MiddleRight;

            设备编号框.Location = new Point(110, 70);
            设备编号框.Name = "设备编号框";
            设备编号框.Size = new Size(200, 23);
            设备编号框.TabIndex = 3;

            操作员标签.Location = new Point(20, 110);
            操作员标签.Name = "操作员标签";
            操作员标签.Size = new Size(80, 23);
            操作员标签.TabIndex = 4;
            操作员标签.Text = "操作员：";
            操作员标签.TextAlign = ContentAlignment.MiddleRight;

            操作员框.Location = new Point(110, 110);
            操作员框.Name = "操作员框";
            操作员框.Size = new Size(200, 23);
            操作员框.TabIndex = 5;

            检测设置页.Controls.Add(检测设置组);
            检测设置页.Controls.Add(通讯异常组);
            检测设置页.Location = new Point(4, 26);
            检测设置页.Name = "检测设置页";
            检测设置页.Size = new Size(752, 420);
            检测设置页.TabIndex = 1;
            检测设置页.Text = "检测设置";
            检测设置页.UseVisualStyleBackColor = true;

            检测设置组.Controls.Add(检测次数标签);
            检测设置组.Controls.Add(检测次数框);
            检测设置组.Controls.Add(检测间隔标签);
            检测设置组.Controls.Add(检测间隔框);
            检测设置组.Location = new Point(20, 20);
            检测设置组.Name = "检测设置组";
            检测设置组.Size = new Size(350, 150);
            检测设置组.TabIndex = 0;
            检测设置组.TabStop = false;
            检测设置组.Text = "采样时间";

            检测次数标签.Location = new Point(20, 30);
            检测次数标签.Name = "检测次数标签";
            检测次数标签.Size = new Size(80, 23);
            检测次数标签.TabIndex = 0;
            检测次数标签.Text = "检测次数：";
            检测次数标签.TextAlign = ContentAlignment.MiddleRight;

            检测次数框.Location = new Point(110, 30);
            检测次数框.Name = "检测次数框";
            检测次数框.Size = new Size(100, 23);
            检测次数框.TabIndex = 1;

            检测间隔标签.Location = new Point(20, 70);
            检测间隔标签.Name = "检测间隔标签";
            检测间隔标签.Size = new Size(80, 23);
            检测间隔标签.TabIndex = 2;
            检测间隔标签.Text = "检测间隔：";
            检测间隔标签.TextAlign = ContentAlignment.MiddleRight;

            检测间隔框.Location = new Point(110, 70);
            检测间隔框.Name = "检测间隔框";
            检测间隔框.Size = new Size(100, 23);
            检测间隔框.TabIndex = 3;

            通讯异常组.Controls.Add(通讯次数标签);
            通讯异常组.Controls.Add(通讯次数框);
            通讯异常组.Controls.Add(通讯间隔标签);
            通讯异常组.Controls.Add(通讯间隔框);
            通讯异常组.Location = new Point(20, 190);
            通讯异常组.Name = "通讯异常组";
            通讯异常组.Size = new Size(350, 150);
            通讯异常组.TabIndex = 1;
            通讯异常组.TabStop = false;
            通讯异常组.Text = "模块通讯异常设置";

            通讯次数标签.Location = new Point(20, 30);
            通讯次数标签.Name = "通讯次数标签";
            通讯次数标签.Size = new Size(80, 23);
            通讯次数标签.TabIndex = 0;
            通讯次数标签.Text = "检测次数：";
            通讯次数标签.TextAlign = ContentAlignment.MiddleRight;

            通讯次数框.Location = new Point(110, 30);
            通讯次数框.Name = "通讯次数框";
            通讯次数框.Size = new Size(100, 23);
            通讯次数框.TabIndex = 1;

            通讯间隔标签.Location = new Point(20, 70);
            通讯间隔标签.Name = "通讯间隔标签";
            通讯间隔标签.Size = new Size(80, 23);
            通讯间隔标签.TabIndex = 2;
            通讯间隔标签.Text = "检测间隔：";
            通讯间隔标签.TextAlign = ContentAlignment.MiddleRight;

            通讯间隔框.Location = new Point(110, 70);
            通讯间隔框.Name = "通讯间隔框";
            通讯间隔框.Size = new Size(100, 23);
            通讯间隔框.TabIndex = 3;

            运动控制页.Location = new Point(4, 26);
            运动控制页.Name = "运动控制页";
            运动控制页.Size = new Size(752, 420);
            运动控制页.TabIndex = 2;
            运动控制页.Text = "运动控制";
            运动控制页.UseVisualStyleBackColor = true;

            电压模块页.Location = new Point(4, 26);
            电压模块页.Name = "电压模块页";
            电压模块页.Size = new Size(752, 420);
            电压模块页.TabIndex = 3;
            电压模块页.Text = "电压模块";
            电压模块页.UseVisualStyleBackColor = true;

            MESS设置页.Controls.Add(MESS设置组);
            MESS设置页.Location = new Point(4, 26);
            MESS设置页.Name = "MESS设置页";
            MESS设置页.Size = new Size(752, 420);
            MESS设置页.TabIndex = 4;
            MESS设置页.Text = "MESS设置";
            MESS设置页.UseVisualStyleBackColor = true;

            MESS设置组.Controls.Add(启用MESS框);
            MESS设置组.Controls.Add(服务器地址标签);
            MESS设置组.Controls.Add(服务器地址框);
            MESS设置组.Controls.Add(端口标签);
            MESS设置组.Controls.Add(端口框);
            MESS设置组.Location = new Point(20, 20);
            MESS设置组.Name = "MESS设置组";
            MESS设置组.Size = new Size(350, 180);
            MESS设置组.TabIndex = 0;
            MESS设置组.TabStop = false;
            MESS设置组.Text = "MESS配置";

            启用MESS框.Location = new Point(20, 30);
            启用MESS框.Name = "启用MESS框";
            启用MESS框.Size = new Size(100, 24);
            启用MESS框.TabIndex = 0;
            启用MESS框.Text = "启用MESS";

            服务器地址标签.Location = new Point(20, 70);
            服务器地址标签.Name = "服务器地址标签";
            服务器地址标签.Size = new Size(80, 23);
            服务器地址标签.TabIndex = 1;
            服务器地址标签.Text = "服务器：";
            服务器地址标签.TextAlign = ContentAlignment.MiddleRight;

            服务器地址框.Location = new Point(110, 70);
            服务器地址框.Name = "服务器地址框";
            服务器地址框.Size = new Size(200, 23);
            服务器地址框.TabIndex = 2;

            端口标签.Location = new Point(20, 110);
            端口标签.Name = "端口标签";
            端口标签.Size = new Size(80, 23);
            端口标签.TabIndex = 3;
            端口标签.Text = "端口：";
            端口标签.TextAlign = ContentAlignment.MiddleRight;

            端口框.Location = new Point(110, 110);
            端口框.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            端口框.Name = "端口框";
            端口框.Size = new Size(100, 23);
            端口框.TabIndex = 4;
            端口框.Value = new decimal(new int[] { 8080, 0, 0, 0 });

            其他设置页.Controls.Add(其他设置组);
            其他设置页.Location = new Point(4, 26);
            其他设置页.Name = "其他设置页";
            其他设置页.Size = new Size(752, 420);
            其他设置页.TabIndex = 5;
            其他设置页.Text = "其他设置";
            其他设置页.UseVisualStyleBackColor = true;

            其他设置组.Controls.Add(日志路径标签);
            其他设置组.Controls.Add(日志路径框);
            其他设置组.Controls.Add(浏览按钮);
            其他设置组.Controls.Add(自动保存日志框);
            其他设置组.Controls.Add(日志保留天数标签);
            其他设置组.Controls.Add(日志保留天数框);
            其他设置组.Location = new Point(20, 20);
            其他设置组.Name = "其他设置组";
            其他设置组.Size = new Size(700, 180);
            其他设置组.TabIndex = 0;
            其他设置组.TabStop = false;
            其他设置组.Text = "日志设置";

            日志路径标签.Location = new Point(20, 30);
            日志路径标签.Name = "日志路径标签";
            日志路径标签.Size = new Size(80, 23);
            日志路径标签.TabIndex = 0;
            日志路径标签.Text = "日志路径：";
            日志路径标签.TextAlign = ContentAlignment.MiddleRight;

            日志路径框.Location = new Point(110, 30);
            日志路径框.Name = "日志路径框";
            日志路径框.Size = new Size(400, 23);
            日志路径框.TabIndex = 1;

            浏览按钮.Location = new Point(520, 30);
            浏览按钮.Name = "浏览按钮";
            浏览按钮.Size = new Size(80, 23);
            浏览按钮.TabIndex = 2;
            浏览按钮.Text = "浏览...";
            浏览按钮.UseVisualStyleBackColor = true;
            浏览按钮.Click += 浏览按钮_Click;

            自动保存日志框.Location = new Point(110, 70);
            自动保存日志框.Name = "自动保存日志框";
            自动保存日志框.Size = new Size(120, 24);
            自动保存日志框.TabIndex = 3;
            自动保存日志框.Text = "自动保存日志";

            日志保留天数标签.Location = new Point(20, 110);
            日志保留天数标签.Name = "日志保留天数标签";
            日志保留天数标签.Size = new Size(80, 23);
            日志保留天数标签.TabIndex = 4;
            日志保留天数标签.Text = "保留天数：";
            日志保留天数标签.TextAlign = ContentAlignment.MiddleRight;

            日志保留天数框.Location = new Point(110, 110);
            日志保留天数框.Name = "日志保留天数框";
            日志保留天数框.Size = new Size(100, 23);
            日志保留天数框.TabIndex = 5;
            日志保留天数框.Value = new decimal(new int[] { 30, 0, 0, 0 });

            保存按钮.Location = new Point(480, 490);
            保存按钮.Name = "保存按钮";
            保存按钮.Size = new Size(100, 35);
            保存按钮.TabIndex = 1;
            保存按钮.Text = "保存";
            保存按钮.UseVisualStyleBackColor = true;
            保存按钮.Click += 保存按钮_Click;

            取消按钮.Location = new Point(600, 490);
            取消按钮.Name = "取消按钮";
            取消按钮.Size = new Size(100, 35);
            取消按钮.TabIndex = 2;
            取消按钮.Text = "取消";
            取消按钮.UseVisualStyleBackColor = true;
            取消按钮.Click += 取消按钮_Click;

            重置按钮.Location = new Point(360, 490);
            重置按钮.Name = "重置按钮";
            重置按钮.Size = new Size(100, 35);
            重置按钮.TabIndex = 3;
            重置按钮.Text = "重置默认";
            重置按钮.UseVisualStyleBackColor = true;
            重置按钮.Click += 重置按钮_Click;

            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 550);
            Controls.Add(重置按钮);
            Controls.Add(取消按钮);
            Controls.Add(保存按钮);
            Controls.Add(标签导航);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "编辑配置窗体";
            StartPosition = FormStartPosition.CenterParent;
            Text = "编辑配置";
            标签导航.ResumeLayout(false);
            基础参数页.ResumeLayout(false);
            检测设置页.ResumeLayout(false);
            MESS设置页.ResumeLayout(false);
            其他设置页.ResumeLayout(false);
            基础参数组.ResumeLayout(false);
            基础参数组.PerformLayout();
            检测设置组.ResumeLayout(false);
            检测设置组.PerformLayout();
            通讯异常组.ResumeLayout(false);
            通讯异常组.PerformLayout();
            MESS设置组.ResumeLayout(false);
            MESS设置组.PerformLayout();
            其他设置组.ResumeLayout(false);
            其他设置组.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)检测次数框).EndInit();
            ((System.ComponentModel.ISupportInitialize)检测间隔框).EndInit();
            ((System.ComponentModel.ISupportInitialize)通讯次数框).EndInit();
            ((System.ComponentModel.ISupportInitialize)通讯间隔框).EndInit();
            ((System.ComponentModel.ISupportInitialize)端口框).EndInit();
            ((System.ComponentModel.ISupportInitialize)日志保留天数框).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl 标签导航;
        private System.Windows.Forms.TabPage 基础参数页;
        private System.Windows.Forms.TabPage 检测设置页;
        private System.Windows.Forms.TabPage 运动控制页;
        private System.Windows.Forms.TabPage 电压模块页;
        private System.Windows.Forms.TabPage MESS设置页;
        private System.Windows.Forms.TabPage 其他设置页;
        private System.Windows.Forms.Button 保存按钮;
        private System.Windows.Forms.Button 取消按钮;
        private System.Windows.Forms.Button 重置按钮;
        
        private GroupBox 基础参数组;
        private Label 设备名称标签;
        private TextBox 设备名称框;
        private Label 设备编号标签;
        private TextBox 设备编号框;
        private Label 操作员标签;
        private TextBox 操作员框;
        
        private GroupBox 检测设置组;
        private Label 检测次数标签;
        private NumericUpDown 检测次数框;
        private Label 检测间隔标签;
        private NumericUpDown 检测间隔框;
        private GroupBox 通讯异常组;
        private Label 通讯次数标签;
        private NumericUpDown 通讯次数框;
        private Label 通讯间隔标签;
        private NumericUpDown 通讯间隔框;
        
        private GroupBox MESS设置组;
        private CheckBox 启用MESS框;
        private Label 服务器地址标签;
        private TextBox 服务器地址框;
        private Label 端口标签;
        private NumericUpDown 端口框;
        
        private GroupBox 其他设置组;
        private Label 日志路径标签;
        private TextBox 日志路径框;
        private Button 浏览按钮;
        private CheckBox 自动保存日志框;
        private Label 日志保留天数标签;
        private NumericUpDown 日志保留天数框;
    }
}