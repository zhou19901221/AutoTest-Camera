using System;
using System.Windows.Forms;

namespace 自动测试
{
    public partial class 基础参数控件 : UserControl
    {
        private 系统配置数据 配置数据;

        public 基础参数控件()
        {
            InitializeComponent();
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
            
            端口框.Value = 配置数据.基础参数.串口端口;
            
            索引 = 波特率框.Items.IndexOf(配置数据.基础参数.串口波特率.ToString());
            if (索引 >= 0) 波特率框.SelectedIndex = 索引;
            
            索引 = 无程控框.Items.IndexOf(配置数据.基础参数.程控电源类型);
            if (索引 >= 0) 无程控框.SelectedIndex = 索引;
            
            索引 = 类型框.Items.IndexOf(配置数据.基础参数.程控电源品牌);
            if (索引 >= 0) 类型框.SelectedIndex = 索引;
            
            索引 = 校验位框.Items.IndexOf(配置数据.基础参数.程控校验位);
            if (索引 >= 0) 校验位框.SelectedIndex = 索引;
            
            程控波特率框.Value = 配置数据.基础参数.程控波特率;
            电压框.Value = (decimal)配置数据.基础参数.程控电压;
            频率框.Value = 配置数据.基础参数.程控频率;
            电流框.Value = (decimal)配置数据.基础参数.程控电流;
            
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
            配置数据.基础参数.串口端口 = (int)端口框.Value;
            if (int.TryParse(波特率框.Text, out int 波特率))
                配置数据.基础参数.串口波特率 = 波特率;
            
            配置数据.基础参数.程控电源类型 = 无程控框.Text;
            配置数据.基础参数.程控电源品牌 = 类型框.Text;
            配置数据.基础参数.程控校验位 = 校验位框.Text;
            配置数据.基础参数.程控波特率 = (int)程控波特率框.Value;
            配置数据.基础参数.程控电压 = (double)电压框.Value;
            配置数据.基础参数.程控频率 = (int)频率框.Value;
            配置数据.基础参数.程控电流 = (double)电流框.Value;
            
            配置数据.基础参数.平台下降光幕保护 = 平台下降光幕保护框.Checked;
            配置数据.基础参数.平台上升光幕保护 = 平台上升光幕保护框.Checked;
            配置数据.基础参数.测试界面显示机器电压 = 测试界面显示机器电压框.Checked;
            配置数据.基础参数.安全门 = 安全门框.Checked;
            配置数据.基础参数.显示环境温度湿度 = 显示环境温度湿度框.Checked;
            配置数据.基础参数.开机自动运行 = 开机自动运行框.Checked;
            配置数据.基础参数.全局量程 = 全局量程框.Checked;
            配置数据.基础参数.伺服 = 伺服框.Checked;
        }
    }
}