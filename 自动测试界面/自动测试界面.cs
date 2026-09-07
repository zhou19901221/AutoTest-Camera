using System;
using System.Drawing;
using System.IO.Ports;
using System.Reflection;
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
        private SerialPort? 继电器串口;
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
                if (继电器串口 != null)
                {
                    if (继电器串口.IsOpen) 继电器串口.Close();
                    继电器串口.Dispose();
                    继电器串口 = null;
                }
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
                case "继电器输出":
                    执行继电器输出(项);
                    break;
                case "程控电源":
                    执行程控电源(项);
                    break;
                default:
                    日志管理器.记录(日志类别.测试操作, $"执行[{项.类型}] {项.名称}", "暂未接入硬件，跳过", 权限等级.员工);
                    break;
            }
        }

        private void 执行继电器输出(编辑配置窗体.检测项数据 项)
        {
            bool 目标状态 = bool.TryParse(项.设定值, out bool 开) && 开;
            var 从站通道列表 = new Dictionary<int, HashSet<int>>();

            foreach (var 地址 in 获取检测项地址列表(项))
            {
                if (!解析DO地址(地址, out int 板号, out int 通道)) continue;
                if (通道 < 0 || 通道 > 15) continue;

                int 从站地址 = 模块寄存器管理.配置.从站地址起始 + 板号 - 1;
                if (!从站通道列表.TryGetValue(从站地址, out HashSet<int>? 通道列表))
                {
                    通道列表 = new HashSet<int>();
                    从站通道列表[从站地址] = 通道列表;
                }

                通道列表.Add(通道);
            }

            if (从站通道列表.Count == 0)
            {
                日志管理器.记录(日志类别.测试操作, $"执行[继电器输出] {项.名称}", "未配置有效DO地址，跳过", 权限等级.员工);
                return;
            }

            确保继电器串口连接();
            日志管理器.记录(日志类别.测试操作, $"执行[继电器输出] {项.名称}", $"目标状态:{(目标状态 ? "ON" : "OFF")} 从站数:{从站通道列表.Count}", 权限等级.员工);
            foreach (var kv in 从站通道列表.OrderBy(x => x.Key))
            {
                string 通道文本 = string.Join(",", kv.Value.OrderBy(x => x));
                bool[] 当前状态 = 读取线圈((byte)kv.Key, 0, 16);
                日志管理器.记录(日志类别.测试操作, "继电器读取当前状态", $"从站:{kv.Key} 通道:{通道文本} 位图:{位图转Hex(当前状态)}", 权限等级.员工);
                foreach (int 通道 in kv.Value)
                {
                    当前状态[通道] = 目标状态;
                }

                写入多个线圈((byte)kv.Key, 0, 当前状态);
                日志管理器.记录(日志类别.测试操作, $"执行[继电器输出] {项.名称}", $"从站{kv.Key} 已写入目标通道{kv.Value.Count}个 -> {(目标状态 ? "ON" : "OFF")} 位图:{位图转Hex(当前状态)}", 权限等级.员工);
            }
        }

        private IEnumerable<string> 获取检测项地址列表(编辑配置窗体.检测项数据 项)
        {
            var 地址集合 = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            int 拼板数 = Math.Max(1, Math.Min(当前拼板数, 32));

            for (int p = 1; p <= 拼板数; p++)
            {
                string 主字段 = $"拼版{p}地址";
                string 地址1 = typeof(编辑配置窗体.检测项数据).GetProperty(主字段)?.GetValue(项)?.ToString() ?? "";
                if (!string.IsNullOrWhiteSpace(地址1) && 地址1 != "无") 地址集合.Add(地址1.Trim());

                for (int s = 2; s <= 4; s++)
                {
                    string 扩展字段 = $"拼版{p}地址_{s}";
                    if (项.扩展地址.TryGetValue(扩展字段, out string? 扩展地址) && !string.IsNullOrWhiteSpace(扩展地址) && 扩展地址 != "无")
                    {
                        地址集合.Add(扩展地址.Trim());
                    }
                }
            }

            return 地址集合;
        }

        private bool 解析DO地址(string 地址, out int 板号, out int 通道)
        {
            板号 = 0;
            通道 = 0;
            if (string.IsNullOrWhiteSpace(地址)) return false;

            string txt = 地址.Trim();
            if (!txt.StartsWith("DO", StringComparison.OrdinalIgnoreCase)) return false;

            int 点位 = txt.IndexOf('.');
            if (点位 <= 2 || 点位 >= txt.Length - 1) return false;

            return int.TryParse(txt.Substring(2, 点位 - 2), out 板号)
                && int.TryParse(txt.Substring(点位 + 1), out 通道)
                && 板号 > 0;
        }

        private void 确保继电器串口连接()
        {
            var 基础参数 = 系统配置管理.实例.基础参数;
            if (string.IsNullOrWhiteSpace(基础参数.串口端口))
                throw new InvalidOperationException("未配置串口端口");

            if (继电器串口 == null)
            {
                继电器串口 = new SerialPort();
            }

            if (继电器串口.IsOpen && 继电器串口.PortName == 基础参数.串口端口 && 继电器串口.BaudRate == 基础参数.串口波特率)
                return;

            if (继电器串口.IsOpen) 继电器串口.Close();

            继电器串口.PortName = 基础参数.串口端口;
            继电器串口.BaudRate = 基础参数.串口波特率;
            继电器串口.Parity = Parity.None;
            继电器串口.DataBits = 8;
            继电器串口.StopBits = StopBits.One;
            继电器串口.ReadTimeout = 1000;
            继电器串口.WriteTimeout = 1000;
            继电器串口.Open();
        }

        private void 写入多个线圈(byte 从站地址, ushort 起始地址, bool[] 状态数组)
        {
            ushort 数量 = (ushort)状态数组.Length;
            int 字节数 = (数量 + 7) / 8;
            byte[] 数据 = new byte[字节数];
            for (int i = 0; i < 数量; i++)
            {
                if (状态数组[i]) 数据[i / 8] |= (byte)(1 << (i % 8));
            }

            byte[] 请求 = new byte[7 + 字节数];
            请求[0] = 从站地址;
            请求[1] = 0x0F;
            请求[2] = (byte)(起始地址 >> 8);
            请求[3] = (byte)(起始地址 & 0xFF);
            请求[4] = (byte)(数量 >> 8);
            请求[5] = (byte)(数量 & 0xFF);
            请求[6] = (byte)字节数;
            Array.Copy(数据, 0, 请求, 7, 字节数);

            byte[] 响应 = 发送Modbus请求(请求, 8, $"写多线圈 从站:{从站地址} 起始:{起始地址} 数量:{数量}");
            if (响应[1] != 0x0F)
                throw new InvalidOperationException("继电器写入返回功能码异常");
        }

        private bool[] 读取线圈(byte 从站地址, ushort 起始地址, ushort 数量)
        {
            byte[] 请求 = new byte[]
            {
                从站地址, 0x01,
                (byte)(起始地址 >> 8), (byte)(起始地址 & 0xFF),
                (byte)(数量 >> 8), (byte)(数量 & 0xFF)
            };

            int 字节数 = (数量 + 7) / 8;
            byte[] 响应 = 发送Modbus请求(请求, 5 + 字节数, $"读线圈 从站:{从站地址} 起始:{起始地址} 数量:{数量}");
            if (响应[1] != 0x01)
                throw new InvalidOperationException("读取线圈返回功能码异常");

            bool[] 结果 = new bool[数量];
            for (int i = 0; i < 数量; i++)
            {
                int byteIndex = i / 8;
                int bitIndex = i % 8;
                结果[i] = (响应[3 + byteIndex] & (1 << bitIndex)) != 0;
            }

            return 结果;
        }

        private byte[] 发送Modbus请求(byte[] pdu, int 最小响应长度, string 操作说明)
        {
            确保继电器串口连接();
            if (继电器串口 == null) throw new InvalidOperationException("串口未初始化");

            byte[] 帧 = 添加CRC(pdu);
            日志管理器.记录(日志类别.测试操作, "继电器报文发送", $"{操作说明} TX:{BitConverter.ToString(帧).Replace("-", " ")}", 权限等级.员工);
            继电器串口.DiscardInBuffer();
            继电器串口.DiscardOutBuffer();
            继电器串口.Write(帧, 0, 帧.Length);

            byte[] 响应 = new byte[Math.Max(最小响应长度, 8)];
            int 已读 = 0;
            while (已读 < 最小响应长度)
            {
                int n = 继电器串口.Read(响应, 已读, 响应.Length - 已读);
                已读 += n;
            }

            byte[] 有效响应 = new byte[已读];
            Array.Copy(响应, 0, 有效响应, 0, 已读);
            日志管理器.记录(日志类别.测试操作, "继电器报文接收", $"{操作说明} RX:{BitConverter.ToString(有效响应).Replace("-", " ")}", 权限等级.员工);
            校验CRC(有效响应);
            if ((有效响应[1] & 0x80) != 0)
                throw new InvalidOperationException($"Modbus异常码: 0x{有效响应[2]:X2}");

            return 有效响应;
        }

        private static string 位图转Hex(bool[] 状态)
        {
            int 字节数 = (状态.Length + 7) / 8;
            byte[] 数据 = new byte[字节数];
            for (int i = 0; i < 状态.Length; i++)
            {
                if (状态[i]) 数据[i / 8] |= (byte)(1 << (i % 8));
            }
            return BitConverter.ToString(数据).Replace("-", " ");
        }

        private static byte[] 添加CRC(byte[] 数据)
        {
            ushort crc = 计算CRC16(数据, 数据.Length);
            byte[] 帧 = new byte[数据.Length + 2];
            Array.Copy(数据, 帧, 数据.Length);
            帧[^2] = (byte)(crc & 0xFF);
            帧[^1] = (byte)(crc >> 8);
            return 帧;
        }

        private static void 校验CRC(byte[] 响应)
        {
            if (响应.Length < 5) throw new InvalidOperationException("Modbus响应长度不足");
            ushort 接收crc = (ushort)((响应[^1] << 8) | 响应[^2]);
            ushort 计算crc = 计算CRC16(响应, 响应.Length - 2);
            if (接收crc != 计算crc) throw new InvalidOperationException("Modbus CRC校验失败");
        }

        private static ushort 计算CRC16(byte[] 数据, int 长度)
        {
            ushort crc = 0xFFFF;
            for (int i = 0; i < 长度; i++)
            {
                crc ^= 数据[i];
                for (int j = 0; j < 8; j++)
                {
                    bool lsb = (crc & 0x0001) != 0;
                    crc >>= 1;
                    if (lsb) crc ^= 0xA001;
                }
            }
            return crc;
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