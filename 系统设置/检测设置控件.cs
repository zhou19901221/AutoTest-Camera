using System;
using System.Windows.Forms;

namespace 自动测试
{
    public partial class 检测设置控件 : UserControl
    {
        private 系统配置数据 配置数据;

        public 检测设置控件()
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
            
            检测次数框.Value = 配置数据.电压模块.采样普通状态;
            检测间隔框.Value = 配置数据.电压模块.采样功能测试时;
            numericUpDown3.Value = 配置数据.电压模块.采样工作状态;
            
            numericUpDown7.Value = 配置数据.电压模块.通讯重试次数;
            numericUpDown4.Value = 配置数据.电压模块.通讯单次超时;
        }

        public void 保存配置()
        {
            if (配置数据 == null) return;
            
            配置数据.电压模块.采样普通状态 = (int)检测次数框.Value;
            配置数据.电压模块.采样功能测试时 = (int)检测间隔框.Value;
            配置数据.电压模块.采样工作状态 = (int)numericUpDown3.Value;
            
            配置数据.电压模块.通讯重试次数 = (int)numericUpDown7.Value;
            配置数据.电压模块.通讯单次超时 = (int)numericUpDown4.Value;
        }
    }
}