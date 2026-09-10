using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace 自动测试
{
    public partial class 基础参数控件 : UserControl
    {
        private 系统配置数据 配置数据;

        public 基础参数控件()
        {
            InitializeComponent();
            初始化波特率选项();
            端口框.Items.AddRange(SerialPort.GetPortNames());
            if (端口框.Items.Count > 0) 端口框.SelectedIndex = 0;
            串口波特率.SelectedItem = "115200";
            串口数据位.SelectedItem = "8";
            串口校验.SelectedItem = "None";
            串口停止位.SelectedItem = "1";
        }

        private void 初始化波特率选项()
        {
            object[] 选项 = { "110", "300", "600", "1200", "2400", "4800", "9600", "14400", "19200", "38400", "57600", "115200", "128000", "230400", "256000", "460800", "500000", "576000", "921600", "1000000", "1152000", "1500000", "2000000" };
            波特率框.Items.Clear();
            串口波特率.Items.Clear();
            波特率框.Items.AddRange(选项);
            串口波特率.Items.AddRange(选项);
        }

        public void 设置配置数据(系统配置数据 数据)
        {
            配置数据 = 数据;
            加载配置();
        }

        public void 加载配置()
        {
            if (配置数据 == null) return;
            
            int 索引 = 测试类型框.Items.IndexOf(配置数据.基础参数.测试类型);
            if (索引 >= 0) 测试类型框.SelectedIndex = 索引;
            
            端口框.SelectedItem = 配置数据.基础参数.串口端口;
            
            索引 = 波特率框.Items.IndexOf(配置数据.基础参数.串口波特率.ToString());
            if (索引 >= 0) 波特率框.SelectedIndex = 索引;
            else 波特率框.Text = 配置数据.基础参数.串口波特率.ToString();
            
            索引 = 无程控框.Items.IndexOf(配置数据.基础参数.程控电源类型);
            if (索引 >= 0) 无程控框.SelectedIndex = 索引;

            索引 = 串口波特率.Items.IndexOf(配置数据.基础参数.串口通讯板波特率.ToString());
            if (索引 >= 0) 串口波特率.SelectedIndex = 索引;
            else 串口波特率.Text = 配置数据.基础参数.串口通讯板波特率.ToString();

            索引 = 串口数据位.Items.IndexOf(配置数据.基础参数.串口通讯板数据位.ToString());
            if (索引 >= 0) 串口数据位.SelectedIndex = 索引;

            索引 = 串口校验.Items.IndexOf(配置数据.基础参数.串口通讯板校验);
            if (索引 >= 0) 串口校验.SelectedIndex = 索引;

            索引 = 串口停止位.Items.IndexOf(配置数据.基础参数.串口通讯板停止位);
            if (索引 >= 0) 串口停止位.SelectedIndex = 索引;
            
            
            
            平台下降光幕保护框.Checked = 配置数据.基础参数.平台下降光幕保护;
            平台上升光幕保护框.Checked = 配置数据.基础参数.平台上升光幕保护;
            测试界面显示机器电压框.Checked = 配置数据.基础参数.测试界面显示机器电压;
            安全门框.Checked = 配置数据.基础参数.安全门;
            显示环境温度湿度框.Checked = 配置数据.基础参数.显示环境温度湿度;
            开机自动运行框.Checked = 配置数据.基础参数.开机自动运行;
            全局量程框.Checked = 配置数据.基础参数.全局量程;
            伺服框.Checked = 配置数据.基础参数.伺服;
        }

        public void 保存配置()
        {
            if (配置数据 == null) return;
            
            配置数据.基础参数.测试类型 = 测试类型框.Text;
            配置数据.基础参数.串口端口 = (string?)端口框.SelectedItem ?? "COM1";
            if (int.TryParse(波特率框.Text, out int 波特率) && 波特率 >= 110 && 波特率 <= 2000000)
                配置数据.基础参数.串口波特率 = 波特率;
            
            配置数据.基础参数.程控电源类型 = 无程控框.Text;

            if (int.TryParse(串口波特率.Text, out int 通讯板波特率) && 通讯板波特率 >= 110 && 通讯板波特率 <= 2000000)
                配置数据.基础参数.串口通讯板波特率 = 通讯板波特率;

            if (int.TryParse(串口数据位.Text, out int 通讯板数据位))
                配置数据.基础参数.串口通讯板数据位 = 通讯板数据位;

            配置数据.基础参数.串口通讯板校验 = 串口校验.Text;
            配置数据.基础参数.串口通讯板停止位 = 串口停止位.Text;
            
            
            配置数据.基础参数.平台下降光幕保护 = 平台下降光幕保护框.Checked;
            配置数据.基础参数.平台上升光幕保护 = 平台上升光幕保护框.Checked;
            配置数据.基础参数.测试界面显示机器电压 = 测试界面显示机器电压框.Checked;
            配置数据.基础参数.安全门 = 安全门框.Checked;
            配置数据.基础参数.显示环境温度湿度 = 显示环境温度湿度框.Checked;
            配置数据.基础参数.开机自动运行 = 开机自动运行框.Checked;
            配置数据.基础参数.全局量程 = 全局量程框.Checked;
            配置数据.基础参数.伺服 = 伺服框.Checked;
        }

        private void 电源设置按钮_Click(object? sender, EventArgs e)
        {
            if (无程控框.Text == "一迈YM600-Y60-L15")
            {
                new 一迈电源设置窗体().Show(this);
                return;
            }
            MessageBox.Show("未选择对应的程控电源", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}