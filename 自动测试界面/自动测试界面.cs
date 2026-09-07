using System;
using System.Drawing;
using System.Windows.Forms;

namespace 自动测试
{
    public partial class 自动测试界面 : Form
    {
        private static readonly Color 默认色 = Color.FromArgb(192, 192, 192);
        private static readonly Color 通过色 = Color.FromArgb(0, 176, 80);
        private static readonly Color 失败色 = Color.FromArgb(255, 0, 0);

        private int 当前拼板数;
        private 编辑配置窗体.配置项数据? 当前配置;
        private 一迈电源控制? 电源;
        private CancellationTokenSource? 取消源;
        private bool 测试中;

        public 自动测试界面()
        {
            InitializeComponent();
            界面缩放器.等比例适配屏幕(this);
        }

        public void 同步板状态(int 拼板数)
        {
            当前拼板数 = 拼板数;
            板状态容器.Controls.Clear();
            板状态容器.ColumnStyles.Clear();
            板状态容器.RowStyles.Clear();
            板状态容器.ColumnCount = 8;
            板状态容器.RowCount = (拼板数 + 7) / 8;

            for (int c = 0; c < 板状态容器.ColumnCount; c++)
                板状态容器.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / 板状态容器.ColumnCount));

            for (int r = 0; r < 板状态容器.RowCount; r++)
                板状态容器.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / 板状态容器.RowCount));

            for (int i = 0; i < 拼板数; i++)
            {
                var 方块 = new Panel();
                方块.BackColor = 默认色;
                方块.Dock = DockStyle.Fill;
                方块.Margin = new Padding(1);
                方块.Tag = i;
                int 行 = i / 8;
                int 列 = i % 8;
                板状态容器.Controls.Add(方块, 列, 行);
            }
        }

        public void 设置板状态(int 板序号, string 状态)
        {
            if (板序号 < 0 || 板序号 >= 当前拼板数) return;
            foreach (Control 控件 in 板状态容器.Controls)
            {
                if (控件.Tag is int 索引 && 索引 == 板序号)
                {
                    控件.BackColor = 状态 == "PASS" ? 通过色 : 状态 == "FAIL" ? 失败色 : 默认色;
                    日志管理器.记录(日志类别.测试操作, $"板{板序号+1}{状态}", "", 权限等级.员工);
                    return;
                }
            }
        }

        public void 重置板状态()
        {
            foreach (Control 控件 in 板状态容器.Controls)
                控件.BackColor = 默认色;
        }
        private void 返回按钮_Click(object sender, EventArgs e)
        {
            取消源?.Cancel();
            日志管理器.记录(日志类别.测试操作, "退出自动测试", "", 权限等级.员工);
            Form1.主窗体实例?.Show();
            Close();
        }

        private async void 开始测试按钮_Click(object? sender, EventArgs e)
        {
            if (当前配置 == null)
            {
                MessageBox.Show("未加载配置，无法开始测试。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (测试中)
            {
                取消源?.Cancel();
                return;
            }

            测试中 = true;
            取消源 = new CancellationTokenSource();
            开始测试按钮.Text = "停止测试";
            重置板状态();
            日志管理器.记录(日志类别.测试操作, "开始测试", 当前配置.配置名称, 权限等级.员工);

            try
            {
                await Task.Run(() => 执行测试流程(取消源.Token));
            }
            catch (Exception 异常)
            {
                MessageBox.Show($"测试执行异常：{异常.Message}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                测试中 = false;
                取消源.Dispose();
                取消源 = null;
                电源?.断开();
                电源 = null;
                开始测试按钮.Text = "开始测试";
            }
        }

        private void 执行测试流程(CancellationToken token)
        {
            var 配置 = 当前配置;
            if (配置 == null) return;
            var 检测项 = 配置.检测项列表.Where(项 => 项.启用).OrderBy(项 => 项.排序);

            foreach (var 项 in 检测项)
            {
                if (token.IsCancellationRequested) break;

                try
                {
                    执行检测项(项);
                }
                catch (Exception 异常)
                {
                    日志管理器.记录(日志类别.测试操作, $"执行[{项.类型}] {项.名称}失败", 异常.Message, 权限等级.员工);
                }

                if (项.延时 > 0) Thread.Sleep(项.延时);
            }

            for (int i = 0; i < 当前拼板数; i++)
                Invoke(() => 设置板状态(i, "PASS"));
        }

        private void 执行检测项(编辑配置窗体.检测项数据 项)
        {
            switch (项.类型)
            {
                case "程控电源":
                    执行程控电源(项);
                    break;
                default:
                    日志管理器.记录(日志类别.测试操作, $"执行[{项.类型}] {项.名称}", "暂未接入硬件，跳过", 权限等级.员工);
                    break;
            }
        }

        private void 执行程控电源(编辑配置窗体.检测项数据 项)
        {
            电源 ??= new 一迈电源控制();
            if (!电源.已连接)
            {
                var 基础参数 = 系统配置管理.实例.基础参数;
                电源.连接(基础参数.串口端口, 基础参数.程控波特率);
            }

            float 电压 = float.TryParse(项.最大值, out float v) ? v : 0;
            float 电流 = float.TryParse(项.最小值, out float c) ? c : 0;

            if (电压 > 0) 电源.设置输出电压(电压);
            if (电流 > 0) 电源.设置输出电流(电流);

            bool 打开 = bool.TryParse(项.设定值, out bool 开) && 开;
            if (打开) 电源.启动电源();
            else 电源.停止电源();

            日志管理器.记录(日志类别.测试操作, $"执行[程控电源] {项.名称}", $"电压:{电压}V 电流:{电流}A {(打开 ? "打开" : "关闭")}", 权限等级.员工);
        }

        public void 加载配置(编辑配置窗体.配置项数据 数据)
        {
            当前配置 = 数据;
            当前配置标签.Text = $"当前配置: {数据.配置名称}";
            同步板状态(数据.拼板数);
            检测项表格.Columns.Clear();

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

            检测项表格.Columns.AddRange(new DataGridViewColumn[] { 序号列, 名称列, 类型列, 延时列, 启用列 });

            检测项表格.Rows.Clear();
            foreach (var 项 in 数据.检测项列表)
            {
                int 行索引 = 检测项表格.Rows.Add();
                var 行 = 检测项表格.Rows[行索引];
                行.Cells["序号列"].Value = 项.排序;
                行.Cells["名称列"].Value = 项.名称;
                行.Cells["类型列"].Value = 项.类型;
                行.Cells["延时列"].Value = 项.延时;
                行.Cells["启用列"].Value = 项.启用;
            }
        }
    }
}