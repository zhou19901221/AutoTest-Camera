using MvCamCtrl.NET;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace 自动测试
{
    public partial class Form1 : Form
    {
        private MyCamera? 相机对象 = null;
        private MyCamera.MV_CC_DEVICE_INFO_LIST 设备列表 = new MyCamera.MV_CC_DEVICE_INFO_LIST();
        private bool 相机已连接 = false;
        private string 操作日志内容 = "";
        private 编辑配置窗体.配置项数据? 当前配置 = null;
        private Button? 当前导航选中按钮;

        public static Form1? 主窗体实例 = null;

        public Form1()
        {
            InitializeComponent();
            主窗体实例 = this;
            this.Load += Form1_Load;
            pictureBox1.Paint += 顶栏面板_Paint;
        }

        private void 顶栏面板_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is not PictureBox 顶栏容器) return;
            var 顶栏区域 = 顶栏容器.ClientRectangle;
            using var 顶部渐变刷 = new System.Drawing.Drawing2D.LinearGradientBrush(
                顶栏区域,
                ColorTranslator.FromHtml("#FEFEFF"),
                ColorTranslator.FromHtml("#E6EAEE"),
                90f);
            e.Graphics.FillRectangle(顶部渐变刷, 顶栏区域);

            using var 边框笔 = new Pen(ColorTranslator.FromHtml("#E2E7EE"), 1f);
            var rect = 顶栏区域;
            rect.Width -= 1;
            rect.Height -= 1;
            e.Graphics.DrawRectangle(边框笔, rect);
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            日志管理器.初始化();
            用户管理器.初始化();
            日志管理器.设置当前用户("临时管理员", 权限等级.管理员);
            日志管理器.记录(日志类别.系统操作, "软件启动", $"版本: {Application.ProductVersion}", 权限等级.厂家);
            配置管理器.获取实例().加载配置();
            初始化主界面样式();
            更新权限显示();
            初始化相机();
            尝试恢复上次配置();
        }

        private void 初始化主界面样式()
        {
            当前配置显示.EnableHeadersVisualStyles = false;
            当前配置显示.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            当前配置显示.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(51, 51, 51);
            当前配置显示.ColumnHeadersDefaultCellStyle.Font = new Font("宋体", 18F, FontStyle.Bold);
            当前配置显示.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            当前配置显示.DefaultCellStyle.BackColor = Color.White;
            当前配置显示.DefaultCellStyle.ForeColor = Color.FromArgb(51, 51, 51);
            当前配置显示.DefaultCellStyle.Font = new Font("宋体", 14F, FontStyle.Regular);
            当前配置显示.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            当前配置显示.DefaultCellStyle.SelectionBackColor = Color.FromArgb(227, 244, 255);
            当前配置显示.DefaultCellStyle.SelectionForeColor = Color.FromArgb(51, 51, 51);
            当前配置显示.RowTemplate.Height = 44;

            当前操作日志.Padding = new Padding(4, 0, 4, 4);
            操作日志文本框.BorderStyle = BorderStyle.None;
            操作日志文本框.BackColor = Color.White;
            操作日志文本框.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular);

            当前配置信息.Padding = new Padding(10, 10, 10, 10);
            当前配置信息.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold);
            当前操作日志.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold);

            进入自动测试.FlatAppearance.BorderSize = 0;
            进入自动测试.FlatAppearance.MouseOverBackColor = Color.FromArgb(98, 188, 255);
            进入自动测试.FlatAppearance.MouseDownBackColor = Color.FromArgb(72, 167, 245);

            初始化导航按钮样式();
        }

        private void 初始化导航按钮样式()
        {
            var 导航按钮 = new[] { 编辑配置, 视觉测试, 端口测试, 日志, 设置按钮, 用户 };
            foreach (var 按钮 in 导航按钮)
            {
                按钮.FlatAppearance.BorderSize = 0;
                按钮.FlatAppearance.MouseOverBackColor = Color.Transparent;
                按钮.FlatAppearance.MouseDownBackColor = Color.Transparent;
                按钮.ForeColor = Color.FromArgb(51, 51, 51);
                按钮.BackgroundImage = null;
                按钮.BackgroundImageLayout = ImageLayout.Stretch;
                按钮.MouseEnter -= 导航按钮_MouseEnter;
                按钮.MouseLeave -= 导航按钮_MouseLeave;
                按钮.MouseEnter += 导航按钮_MouseEnter;
                按钮.MouseLeave += 导航按钮_MouseLeave;
            }

            当前导航选中按钮 = null;
        }

        private static Bitmap 创建导航悬停背景(Size 尺寸)
        {
            var 位图 = new Bitmap(Math.Max(1, 尺寸.Width), Math.Max(1, 尺寸.Height));
            using var g = Graphics.FromImage(位图);
            using var 渐变刷 = new LinearGradientBrush(
                new Rectangle(0, 0, 位图.Width, 位图.Height),
                ColorTranslator.FromHtml("#86C8FF"),
                ColorTranslator.FromHtml("#6CB8FF"),
                90f);
            g.FillRectangle(渐变刷, 0, 0, 位图.Width, 位图.Height);
            return 位图;
        }

        private static Bitmap 创建导航选中背景(Size 尺寸)
        {
            var 位图 = new Bitmap(Math.Max(1, 尺寸.Width), Math.Max(1, 尺寸.Height));
            using var g = Graphics.FromImage(位图);
            using var 渐变刷 = new LinearGradientBrush(
                new Rectangle(0, 0, 位图.Width, 位图.Height),
                ColorTranslator.FromHtml("#6CB8FF"),
                ColorTranslator.FromHtml("#4FA0EE"),
                90f);
            g.FillRectangle(渐变刷, 0, 0, 位图.Width, 位图.Height);
            return 位图;
        }

        private void 设置导航按钮选中(Button 按钮)
        {
            if (当前导航选中按钮 == 按钮) return;

            var 导航按钮 = new[] { 编辑配置, 视觉测试, 端口测试, 日志, 设置按钮, 用户 };
            foreach (var b in 导航按钮)
            {
                if (!ReferenceEquals(b, 按钮))
                {
                    b.BackgroundImage = null;
                    b.ForeColor = Color.FromArgb(51, 51, 51);
                }
            }

            按钮.BackgroundImage?.Dispose();
            按钮.BackgroundImage = 创建导航选中背景(按钮.ClientSize);
            按钮.ForeColor = Color.White;
            当前导航选中按钮 = 按钮;
        }

        private void 导航按钮_MouseEnter(object? sender, EventArgs e)
        {
            if (sender is not Button 按钮 || ReferenceEquals(按钮, 当前导航选中按钮)) return;
            按钮.BackgroundImage?.Dispose();
            按钮.BackgroundImage = 创建导航悬停背景(按钮.ClientSize);
            按钮.ForeColor = Color.White;
        }

        private void 导航按钮_MouseLeave(object? sender, EventArgs e)
        {
            if (sender is not Button 按钮 || ReferenceEquals(按钮, 当前导航选中按钮)) return;
            按钮.BackgroundImage?.Dispose();
            按钮.BackgroundImage = null;
            按钮.ForeColor = Color.FromArgb(51, 51, 51);
        }

        private void 尝试恢复上次配置()
        {
            string 配置名 = 系统配置管理.实例.其他设置.上次加载配置名;
            if (string.IsNullOrWhiteSpace(配置名)) return;

            var 数据 = 配置数据库.实例.加载配置(配置名);
            if (数据 == null) return;

            当前配置 = 数据;
            显示当前配置(数据);
            添加操作日志($"已自动恢复配置：{配置名}");
        }

        private void 更新权限显示()
        {
            日志.Visible = 日志管理器.当前用户权限 != 权限等级.员工;
            用户.Text = 日志管理器.当前用户权限 == 权限等级.员工
                ? "用户登录"
                : $"用户:{日志管理器.当前登录用户}";
        }

        private void 初始化相机()
        {
            try
            {
                MyCamera.MV_CC_Initialize_NET();

                int 结果 = MyCamera.MV_CC_EnumDevices_NET(MyCamera.MV_GIGE_DEVICE | MyCamera.MV_USB_DEVICE, ref 设备列表);
                if (结果 != MyCamera.MV_OK || 设备列表.nDeviceNum == 0)
                {
                    添加操作日志("相机连接失败：未找到相机设备");
                    return;
                }

                相机对象 = new MyCamera();
                MyCamera.MV_CC_DEVICE_INFO 设备信息 = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(设备列表.pDeviceInfo[0], typeof(MyCamera.MV_CC_DEVICE_INFO));

                结果 = 相机对象.MV_CC_CreateDevice_NET(ref 设备信息);
                if (结果 != MyCamera.MV_OK)
                {
                    添加操作日志("相机连接失败：创建设备失败");
                    return;
                }

                结果 = 相机对象.MV_CC_OpenDevice_NET();
                if (结果 != MyCamera.MV_OK)
                {
                    添加操作日志($"相机连接失败：打开设备失败，错误码：{结果}");
                    相机对象.MV_CC_DestroyDevice_NET();
                    相机对象 = null;
                    return;
                }

                if (设备信息.nTLayerType == MyCamera.MV_GIGE_DEVICE)
                {
                    int 包大小 = 相机对象.MV_CC_GetOptimalPacketSize_NET();
                    if (包大小 > 0)
                    {
                        相机对象.MV_CC_SetIntValueEx_NET("GevSCPSPacketSize", 包大小);
                    }
                }

                相机已连接 = true;
                添加操作日志("相机连接成功");
                日志管理器.记录(日志类别.硬件操作, "相机连接成功", "", 权限等级.员工);
            }
            catch (Exception 异常)
            {
                添加操作日志($"相机连接失败：{异常.Message}");
                日志管理器.记录(日志类别.硬件操作, "相机连接失败", 异常.Message, 权限等级.员工);
            }
        }

        public void 添加操作日志(string 日志文本)
        {
            string 时间戳 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            操作日志内容 += $"[{时间戳}] {日志文本}\r\n";

            if (当前操作日志 != null && 当前操作日志.IsHandleCreated)
            {
                当前操作日志.Invoke(new Action(() =>
                {
                    TextBox? 日志文本框 = 当前操作日志.Controls["操作日志文本框"] as TextBox;
                    if (日志文本框 != null)
                    {
                        日志文本框.AppendText($"[{时间戳}] {日志文本}\r\n");
                        日志文本框.ScrollToCaret();
                    }
                }));
            }
        }

        public MyCamera? 获取相机对象()
        {
            return 相机对象;
        }

        public bool 是否相机已连接()
        {
            return 相机已连接;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (相机对象 != null)
            {
                if (相机已连接)
                {
                    相机对象.MV_CC_CloseDevice_NET();
                }
                相机对象.MV_CC_DestroyDevice_NET();
                相机对象 = null;
            }

            MyCamera.MV_CC_Finalize_NET();

            base.OnFormClosing(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void 设置_Click(object sender, EventArgs e)
        {
            日志管理器.记录(日志类别.系统操作, "打开系统设置", "", 权限等级.厂家);
            var 设置页面 = new 系统设置页面();
            设置页面.Show();
        }

        private void 视觉测试_Click(object sender, EventArgs e)
        {
            设置导航按钮选中(视觉测试);
            日志管理器.记录(日志类别.调试操作, "打开视觉设置页面");
            var visualDebug = new 视觉调试页面();
            visualDebug.Show();
        }

        private void 编辑配置_Click(object sender, EventArgs e)
        {
            设置导航按钮选中(编辑配置);
            日志管理器.记录(日志类别.配置操作, "打开编辑配置", "", 权限等级.厂家);
            var 配置窗体 = new 编辑配置窗体();
            配置窗体.ShowDialog();
        }

        private void 端口测试_Click(object sender, EventArgs e)
        {
            设置导航按钮选中(端口测试);
            日志管理器.记录(日志类别.硬件操作, "打开端口测试", "", 权限等级.管理员);
            var 端口测试页 = new 端口测试页面();
            端口测试页.Show();
        }

        private void 日志_Click(object sender, EventArgs e)
        {
            设置导航按钮选中(日志);
            日志管理器.记录(日志类别.系统操作, "打开日志页面", "", 权限等级.厂家);
            var 日志窗体 = new 日志页面();
            日志窗体.Show();
        }

        private void 选着配置_Click(object sender, EventArgs e)
        {
            日志管理器.记录(日志类别.配置操作, "打开选择配置", "", 权限等级.厂家);
            var 配置列表 = 配置数据库.实例.获取所有配置名();
            if (配置列表.Count == 0)
            {
                MessageBox.Show("没有已保存的配置，请先编辑配置并保存", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var 对话框 = new Form();
            对话框.Text = "选择配置";
            对话框.StartPosition = FormStartPosition.CenterParent;
            对话框.FormBorderStyle = FormBorderStyle.FixedDialog;
            对话框.MaximizeBox = false;
            对话框.MinimizeBox = false;
            对话框.Size = new Size(400, 350);

            var 提示标签 = new Label();
            提示标签.Text = "请选择要加载的配置：";
            提示标签.Location = new Point(20, 15);
            提示标签.Size = new Size(340, 25);
            对话框.Controls.Add(提示标签);

            var 列表框 = new ListBox();
            列表框.Location = new Point(20, 45);
            列表框.Size = new Size(340, 220);
            foreach (var 名称 in 配置列表)
            {
                列表框.Items.Add(名称);
            }
            if (列表框.Items.Count > 0) 列表框.SelectedIndex = 0;
            对话框.Controls.Add(列表框);

            var 加载按钮 = new Button();
            加载按钮.Text = "加载";
            加载按钮.Location = new Point(120, 275);
            加载按钮.Size = new Size(80, 30);
            加载按钮.Enabled = false;
            对话框.Controls.Add(加载按钮);

            var 取消按钮 = new Button();
            取消按钮.Text = "取消";
            取消按钮.Location = new Point(220, 275);
            取消按钮.Size = new Size(80, 30);
            取消按钮.DialogResult = DialogResult.Cancel;
            对话框.Controls.Add(取消按钮);

            列表框.SelectedIndexChanged += (s, args) =>
            {
                加载按钮.Enabled = 列表框.SelectedIndex >= 0;
            };

            列表框.DoubleClick += (s, args) =>
            {
                if (列表框.SelectedIndex >= 0) 加载按钮.PerformClick();
            };

            加载按钮.Click += (s, args) =>
            {
                string 选中名称 = 列表框.SelectedItem?.ToString() ?? "";
                var 数据 = 配置数据库.实例.加载配置(选中名称);
                if (数据 != null)
                {
                    当前配置 = 数据;
                    显示当前配置(数据);
                    系统配置管理.实例.其他设置.上次加载配置名 = 选中名称;
                    系统配置管理.保存(系统配置管理.实例);
                    日志管理器.记录(日志类别.配置操作, "加载配置", $"配置名: {选中名称}", 权限等级.员工);
                    添加操作日志($"已加载配置：{选中名称}");
                    对话框.DialogResult = DialogResult.OK;
                    对话框.Close();
                }
                else
                {
                    MessageBox.Show($"加载配置 \"{选中名称}\" 失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            对话框.ShowDialog(this);
        }

        private void 显示当前配置(编辑配置窗体.配置项数据 数据)
        {
            配置信息.Text = 数据.配置名称;
            当前配置显示.Columns.Clear();

            var 序号列 = new DataGridViewTextBoxColumn();
            序号列.HeaderText = "序号";
            序号列.Name = "序号列";
            序号列.Width = 70;
            序号列.ReadOnly = true;
            序号列.SortMode = DataGridViewColumnSortMode.NotSortable;

            var 名称列 = new DataGridViewTextBoxColumn();
            名称列.HeaderText = "名称";
            名称列.Name = "名称列";
            名称列.Width = 170;
            名称列.ReadOnly = true;
            名称列.SortMode = DataGridViewColumnSortMode.NotSortable;

            var 类型列 = new DataGridViewTextBoxColumn();
            类型列.HeaderText = "类型";
            类型列.Name = "类型列";
            类型列.Width = 120;
            类型列.ReadOnly = true;
            类型列.SortMode = DataGridViewColumnSortMode.NotSortable;

            var 延时列 = new DataGridViewTextBoxColumn();
            延时列.HeaderText = "延时";
            延时列.Name = "延时列";
            延时列.Width = 70;
            延时列.ReadOnly = true;
            延时列.SortMode = DataGridViewColumnSortMode.NotSortable;

            var 启用列 = new DataGridViewCheckBoxColumn();
            启用列.HeaderText = "启用";
            启用列.Name = "启用列";
            启用列.Width = 70;
            启用列.ReadOnly = true;
            启用列.SortMode = DataGridViewColumnSortMode.NotSortable;

            当前配置显示.Columns.AddRange(new DataGridViewColumn[] { 序号列, 名称列, 类型列, 延时列, 启用列 });

            当前配置显示.Rows.Clear();
            foreach (var 项 in 数据.检测项列表)
            {
                int 行索引 = 当前配置显示.Rows.Add();
                var 行 = 当前配置显示.Rows[行索引];
                行.Cells["序号列"].Value = 项.排序;
                行.Cells["名称列"].Value = 项.名称;
                行.Cells["类型列"].Value = 项.类型;
                行.Cells["延时列"].Value = 项.延时;
                行.Cells["启用列"].Value = 项.启用;
            }
        }

        private void 进入自动测试_Click(object sender, EventArgs e)
        {
            日志管理器.记录(日志类别.测试操作, "进入自动测试", 当前配置?.配置名称 ?? "未加载配置", 权限等级.员工);
            var 测试界面 = new 自动测试界面();
            if (当前配置 != null)
                测试界面.加载配置(当前配置);
            测试界面.Show();
            Hide();
        }

        private void 设置按钮_Click(object sender, EventArgs e)
        {
            设置_Click(sender, e);
        }

        private void 用户_Click(object sender, EventArgs e)
        {
            if (日志管理器.当前用户权限 == 权限等级.员工)
            {
                using var 登录窗体 = new 用户登录窗体();
                if (登录窗体.ShowDialog(this) == DialogResult.OK && 登录窗体.登录用户 != null)
                {
                    日志管理器.设置当前用户(登录窗体.登录用户.用户名, 登录窗体.登录用户.权限);
                    更新权限显示();
                }
                return;
            }

            var 结果 = MessageBox.Show("是：退出登录\n否：进入用户管理", "用户操作", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (结果 == DialogResult.Yes)
            {
                日志管理器.退出登录();
                更新权限显示();
                return;
            }

            if (结果 == DialogResult.No)
            {
                if (日志管理器.当前用户权限 == 权限等级.员工)
                {
                    MessageBox.Show("当前用户无权限进入管理", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using var 管理窗体 = new 用户管理窗体();
                管理窗体.ShowDialog(this);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
