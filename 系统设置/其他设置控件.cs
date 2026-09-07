using System;
using System.Windows.Forms;

namespace 自动测试
{
    public partial class 其他设置控件 : UserControl
    {
        private 系统配置数据 配置数据;

        public 其他设置控件()
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
            
            PLC地址框.Text = 配置数据.其他设置.PLC地址;
            PLC端口框.Value = 配置数据.其他设置.PLC端口;
            内存偏移框.Value = 配置数据.其他设置.内存偏移;
            
            License框.Checked = 配置数据.其他设置.License启用;
            LicensePrompt框.Checked = 配置数据.其他设置.License提示;
            Days框.Value = 配置数据.其他设置.License天数;
            
            int 索引 = 选择状态框.Items.IndexOf(配置数据.其他设置.选择状态颜色);
            if (索引 >= 0) 选择状态框.SelectedIndex = 索引;
            
            索引 = 路径颜色框.Items.IndexOf(配置数据.其他设置.路径颜色);
            if (索引 >= 0) 路径颜色框.SelectedIndex = 索引;
            
            索引 = 当前路径框.Items.IndexOf(配置数据.其他设置.当前路径颜色);
            if (索引 >= 0) 当前路径框.SelectedIndex = 索引;
            
            索引 = 空走状态框.Items.IndexOf(配置数据.其他设置.空走状态颜色);
            if (索引 >= 0) 空走状态框.SelectedIndex = 索引;
            
            索引 = 记录类型框.Items.IndexOf(配置数据.其他设置.记录类型);
            if (索引 >= 0) 记录类型框.SelectedIndex = 索引;
            
            字符格式框.Checked = 配置数据.其他设置.字符格式;
            保存文件路径框.Text = 配置数据.其他设置.保存文件路径;
        }

        public void 保存配置()
        {
            if (配置数据 == null) return;
            
            配置数据.其他设置.PLC地址 = PLC地址框.Text;
            配置数据.其他设置.PLC端口 = (int)PLC端口框.Value;
            配置数据.其他设置.内存偏移 = (int)内存偏移框.Value;
            
            配置数据.其他设置.License启用 = License框.Checked;
            配置数据.其他设置.License提示 = LicensePrompt框.Checked;
            配置数据.其他设置.License天数 = (int)Days框.Value;
            
            配置数据.其他设置.选择状态颜色 = 选择状态框.Text;
            配置数据.其他设置.路径颜色 = 路径颜色框.Text;
            配置数据.其他设置.当前路径颜色 = 当前路径框.Text;
            配置数据.其他设置.空走状态颜色 = 空走状态框.Text;
            
            配置数据.其他设置.记录类型 = 记录类型框.Text;
            配置数据.其他设置.字符格式 = 字符格式框.Checked;
            配置数据.其他设置.保存文件路径 = 保存文件路径框.Text;
        }
    }
}