using MvCamCtrl.NET;
using System.Runtime.InteropServices;

namespace 自动测试
{
    public partial class Form1 : Form
    {
        private MyCamera? 相机对象 = null;
        private MyCamera.MV_CC_DEVICE_INFO_LIST 设备列表 = new MyCamera.MV_CC_DEVICE_INFO_LIST();
        private bool 相机已连接 = false;
        private string 操作日志内容 = "";
        private 编辑配置窗体.配置项数据? 当前配置 = null;

        public static Form1? 主窗体实例 = null;

        public Form1()
        {
            InitializeComponent();
            主窗体实例 = this;
            this.Load += Form1_Load;
            界面缩放器.等比例适配屏幕(this);
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            日志管理器.初始化();
            日志管理器.记录(日志类别.系统操作, "软件启动", $"版本: {Application.ProductVersion}", 权限等级.厂家);
            配置管理器.获取实例().加载配置();
            更新权限显示();
            初始化相机();
        }

        private void 更新权限显示()
        {
            日志.Visible = 日志管理器.当前用户权限 != 权限等级.员工;
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
        private void 文件_Click(object sender, EventArgs e)
        {
            // 在标签下方显示上下文菜单
            文件菜单.Show(文件, new Point(0, 文件.Height));
        }

        private void 新建ToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("新建 被点击");
        }

        private void 打开ToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("打开 被点击");
        }

        private void 退出ToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            日志管理器.记录(日志类别.系统操作, "软件退出", "", 权限等级.厂家);
            Close();
        }

        private void 视觉测试_Click(object sender, EventArgs e)
        {
            日志管理器.记录(日志类别.调试操作, "打开视觉设置页面");
            var visualDebug = new 视觉调试页面();
            visualDebug.Show();
        }

        private void 编辑配置_Click(object sender, EventArgs e)
        {
            日志管理器.记录(日志类别.配置操作, "打开编辑配置", "", 权限等级.厂家);
            var 配置窗体 = new 编辑配置窗体();
            配置窗体.ShowDialog();
        }

        private void 端口测试_Click(object sender, EventArgs e)
        {
            日志管理器.记录(日志类别.硬件操作, "打开端口测试", "", 权限等级.管理员);
            var 端口测试页 = new 端口测试页面();
            端口测试页.Show();
        }

        private void 日志_Click(object sender, EventArgs e)
        {
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
            序号列.Width = 50;
            序号列.ReadOnly = true;

            var 名称列 = new DataGridViewTextBoxColumn();
            名称列.HeaderText = "名称";
            名称列.Name = "名称列";
            名称列.Width = 120;
            名称列.ReadOnly = true;

            var 类型列 = new DataGridViewTextBoxColumn();
            类型列.HeaderText = "类型";
            类型列.Name = "类型列";
            类型列.Width = 100;
            类型列.ReadOnly = true;

            var 延时列 = new DataGridViewTextBoxColumn();
            延时列.HeaderText = "延时";
            延时列.Name = "延时列";
            延时列.Width = 50;
            延时列.ReadOnly = true;

            var 启用列 = new DataGridViewCheckBoxColumn();
            启用列.HeaderText = "启用";
            启用列.Name = "启用列";
            启用列.Width = 45;
            启用列.ReadOnly = true;

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
    }
}
