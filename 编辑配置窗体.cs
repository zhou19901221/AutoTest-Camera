using System;
using System.Windows.Forms;

namespace 自动测试
{
    public partial class 编辑配置窗体 : Form
    {
        private 配置管理器 配置管理;

        public 编辑配置窗体()
        {
            InitializeComponent();
            配置管理 = 配置管理器.获取实例();
            加载配置到界面();
        }

        private void 加载配置到界面()
        {
            var config = 配置管理.当前配置;
            
            设备名称框.Text = config.基础参数.设备名称;
            设备编号框.Text = config.基础参数.设备编号;
            操作员框.Text = config.基础参数.操作员;
            
            检测次数框.Value = config.检测设置.检测次数;
            检测间隔框.Value = config.检测设置.检测间隔;
            通讯次数框.Value = config.检测设置.通讯异常检测次数;
            通讯间隔框.Value = config.检测设置.通讯异常检测间隔;
            
            启用MESS框.Checked = config.MESS设置.启用MESS;
            服务器地址框.Text = config.MESS设置.服务器地址;
            端口框.Value = config.MESS设置.端口;
            
            日志路径框.Text = config.其他设置.日志路径;
            自动保存日志框.Checked = config.其他设置.自动保存日志;
            日志保留天数框.Value = config.其他设置.日志保留天数;
        }

        private void 保存配置从界面()
        {
            var config = 配置管理.当前配置;
            
            config.基础参数.设备名称 = 设备名称框.Text;
            config.基础参数.设备编号 = 设备编号框.Text;
            config.基础参数.操作员 = 操作员框.Text;
            config.基础参数.最后更新时间 = DateTime.Now;
            
            config.检测设置.检测次数 = (int)检测次数框.Value;
            config.检测设置.检测间隔 = (int)检测间隔框.Value;
            config.检测设置.通讯异常检测次数 = (int)通讯次数框.Value;
            config.检测设置.通讯异常检测间隔 = (int)通讯间隔框.Value;
            
            config.MESS设置.启用MESS = 启用MESS框.Checked;
            config.MESS设置.服务器地址 = 服务器地址框.Text;
            config.MESS设置.端口 = (int)端口框.Value;
            
            config.其他设置.日志路径 = 日志路径框.Text;
            config.其他设置.自动保存日志 = 自动保存日志框.Checked;
            config.其他设置.日志保留天数 = (int)日志保留天数框.Value;
        }

        private void 保存按钮_Click(object sender, EventArgs e)
        {
            保存配置从界面();
            
            if (配置管理.保存配置())
            {
                MessageBox.Show("配置保存成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void 取消按钮_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void 重置按钮_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("确定要重置为默认配置吗？", "确认", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                配置管理.重置为默认值();
                加载配置到界面();
                MessageBox.Show("已重置为默认配置", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void 浏览按钮_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "选择日志保存路径";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    日志路径框.Text = dialog.SelectedPath;
                }
            }
        }
    }
}