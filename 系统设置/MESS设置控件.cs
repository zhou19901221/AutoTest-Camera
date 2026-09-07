using System;
using System.Windows.Forms;

namespace 自动测试
{
    public partial class MESS设置控件 : UserControl
    {
        private 系统配置数据 配置数据;

        public MESS设置控件()
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
            
            MESS功能开启框.Checked = 配置数据.MESS设置.MESS功能开启;
            IP地址框.Text = 配置数据.MESS设置.服务器IP;
            端口框.Value = 配置数据.MESS设置.服务器端口;
            
            int 索引 = 条码枪类型框.Items.IndexOf(配置数据.MESS设置.条码枪类型);
            if (索引 >= 0) 条码枪类型框.SelectedIndex = 索引;
            
            条码枪数量框.Value = 配置数据.MESS设置.条码枪数量;
            波特率框.Value = 配置数据.MESS设置.条码枪波特率;
            
            端口1框.Value = 配置数据.MESS设置.端口映射[0];
            端口2框.Value = 配置数据.MESS设置.端口映射[1];
            端口3框.Value = 配置数据.MESS设置.端口映射[2];
            端口4框.Value = 配置数据.MESS设置.端口映射[3];
            端口5框.Value = 配置数据.MESS设置.端口映射[4];
            端口6框.Value = 配置数据.MESS设置.端口映射[5];
            端口7框.Value = 配置数据.MESS设置.端口映射[6];
            端口8框.Value = 配置数据.MESS设置.端口映射[7];
        }

        public void 保存配置()
        {
            if (配置数据 == null) return;
            
            配置数据.MESS设置.MESS功能开启 = MESS功能开启框.Checked;
            配置数据.MESS设置.服务器IP = IP地址框.Text;
            配置数据.MESS设置.服务器端口 = (int)端口框.Value;
            
            配置数据.MESS设置.条码枪类型 = 条码枪类型框.Text;
            配置数据.MESS设置.条码枪数量 = (int)条码枪数量框.Value;
            配置数据.MESS设置.条码枪波特率 = (int)波特率框.Value;
            
            配置数据.MESS设置.端口映射[0] = (int)端口1框.Value;
            配置数据.MESS设置.端口映射[1] = (int)端口2框.Value;
            配置数据.MESS设置.端口映射[2] = (int)端口3框.Value;
            配置数据.MESS设置.端口映射[3] = (int)端口4框.Value;
            配置数据.MESS设置.端口映射[4] = (int)端口5框.Value;
            配置数据.MESS设置.端口映射[5] = (int)端口6框.Value;
            配置数据.MESS设置.端口映射[6] = (int)端口7框.Value;
            配置数据.MESS设置.端口映射[7] = (int)端口8框.Value;
        }
    }
}