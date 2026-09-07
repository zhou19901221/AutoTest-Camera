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
            端口框.Items.AddRange(SerialPort.GetPortNames());
            if (端口框.Items.Count > 0) 端口框.SelectedIndex = 0;
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
            
            索引 = 无程控框.Items.IndexOf(配置数据.基础参数.程控电源类型);
            if (索引 >= 0) 无程控框.SelectedIndex = 索引;
            
            
            
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
            if (int.TryParse(波特率框.Text, out int 波特率))
                配置数据.基础参数.串口波特率 = 波特率;
            
            配置数据.基础参数.程控电源类型 = 无程控框.Text;
            
            
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