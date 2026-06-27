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

        public static Form1? 主窗体实例 = null;

        public Form1()
        {
            InitializeComponent();
            主窗体实例 = this;
            this.Load += Form1_Load;
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            配置管理器.获取实例().加载配置();
            初始化相机();
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
            }
            catch (Exception 异常)
            {
                添加操作日志($"相机连接失败：{异常.Message}");
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
            Close();
        }

        private void 视觉测试_Click(object sender, EventArgs e)
        {
            // 打开视觉调试页面（非模态）
            var visualDebug = new 视觉调试页面();
            visualDebug.Show();
        }

        private void 编辑配置_Click(object sender, EventArgs e)
        {
            var 配置窗体 = new 编辑配置窗体();
            配置窗体.ShowDialog();
        }

        private void 端口测试_Click(object sender, EventArgs e)
        {
            var visualDebug = new 系统设置页面();
            visualDebug.Show();
        }
    }
}
