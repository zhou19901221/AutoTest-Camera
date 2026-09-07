using System;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Threading;
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
        private readonly Dictionary<int, bool> 拼版通过状态 = new();
        private readonly Dictionary<int, string> 拼版失败原因 = new();
        private readonly List<测试结果记录> 临时统计记录 = new();
        private DateTime 本次测试开始时间;

        private void 写入自动测试日志(string 内容)
        {
            string 行文本 = $"****{DateTime.Now:HH:mm:ss} {内容}{Environment.NewLine}";

            if (日志文本框.InvokeRequired)
            {
                日志文本框.Invoke(new Action(() =>
                {
                    日志文本框.AppendText(行文本);
                    日志文本框.SelectionStart = 日志文本框.TextLength;
                    日志文本框.ScrollToCaret();
                }));
            }
            else
            {
                日志文本框.AppendText(行文本);
                日志文本框.SelectionStart = 日志文本框.TextLength;
                日志文本框.ScrollToCaret();
            }
        }

        private void 更新统计显示()
        {
            int 总数 = 当前拼板数;
            int 失败 = 拼版通过状态.Count(x => !x.Value);
            int 通过 = Math.Max(0, 总数 - 失败);
            double 通过率 = 总数 > 0 ? (double)通过 * 100.0 / 总数 : 0;

            void 更新()
            {
                总数值标签.Text = 总数.ToString();
                OK值标签.Text = 通过.ToString();
                失败值标签.Text = 失败.ToString();
                通过率值标签.Text = $"{通过率:F1}%";
            }

            if (InvokeRequired) Invoke((Action)更新);
            else 更新();
        }

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
            日志文本框.Clear();
            拼版通过状态.Clear();
            拼版失败原因.Clear();
            for (int i = 1; i <= 当前拼板数; i++) 拼版通过状态[i] = true;
            更新统计显示();
            本次测试开始时间 = DateTime.Now;
            写入自动测试日志($"开始测试，配置：{当前配置.配置名称}");
            日志管理器.记录(日志类别.测试操作, "开始测试", 当前配置.配置名称, 权限等级.员工);

            try
            {
                await Task.Run(() => 执行测试流程(取消源.Token));
            }
            catch (Exception 异常)
            {
                写入自动测试日志($"测试执行异常：{异常.Message}");
                MessageBox.Show($"测试执行异常：{异常.Message}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                写入自动测试日志("测试结束");
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
                    写入自动测试日志($"执行测试项：{项.排序} {项.名称} [{项.类型}] 设定值={项.设定值}");
                    执行检测项(项);
                    写入自动测试日志($"完成测试项：{项.排序} {项.名称}");
                }
                catch (Exception 异常)
                {
                    写入自动测试日志($"测试项失败：{项.排序} {项.名称}，错误：{异常.Message}");
                    日志管理器.记录(日志类别.测试操作, $"执行[{项.类型}] {项.名称}失败", 异常.Message, 权限等级.员工);
                }

                if (项.延时 > 0)
                {
                    写入自动测试日志($"延时等待：{项.延时}ms");
                    Thread.Sleep(项.延时);
                }
            }

            for (int i = 1; i <= 当前拼板数; i++)
            {
                bool 通过 = !拼版通过状态.TryGetValue(i, out bool 状态) || 状态;
                int 板序号 = i - 1;
                Invoke(() => 设置板状态(板序号, 通过 ? "PASS" : "FAIL"));
            }
            更新统计显示();
            保存本次测试结果();
        }

        private void 执行检测项(编辑配置窗体.检测项数据 项)
        {
            switch (项.类型)
            {
                case "继电器输出":
                    执行继电器输出(项);
                    break;
                case "直流电压":
                    执行电压电流检测(项, "VD", "直流电压");
                    break;
                case "交流电压":
                    执行电压电流检测(项, "VA", "交流电压");
                    break;
                case "直流电流":
                    执行电压电流检测(项, "CD", "直流电流");
                    break;
                case "交流电流":
                    执行电压电流检测(项, "CA", "交流电流");
                    break;
                case "程控电源":
                    执行程控电源(项);
                    break;
                default:
                    日志管理器.记录(日志类别.测试操作, $"执行[{项.类型}] {项.名称}", "暂未接入硬件，跳过", 权限等级.员工);
                    break;
            }
        }

        private void 执行电压电流检测(编辑配置窗体.检测项数据 项, string 前缀, string 类型名)
        {
            var 拼版地址映射 = 获取检测项拼版地址映射(项, 前缀);
            if (拼版地址映射.Count == 0)
            {
                写入自动测试日志($"{类型名} 跳过：未配置{前缀}地址");
                return;
            }

            double 最大值 = double.TryParse(项.最大值, out double max) ? max : double.MaxValue;
            double 最小值 = double.TryParse(项.最小值, out double min) ? min : double.MinValue;
            var 失败拼版 = new HashSet<int>();

            foreach (var kv in 拼版地址映射.OrderBy(x => x.Key))
            {
                int 拼版号 = kv.Key;
                bool 当前拼版通过 = true;

                var 分组 = new Dictionary<string, List<(string 地址, int 通道号, int 模块索引, byte 从站地址)>>();
                foreach (string 地址 in kv.Value)
                {
                    if (!解析通道地址(地址, out string 地址前缀, out int 逻辑板号, out int 通道号))
                        throw new InvalidOperationException($"地址格式错误：{地址}");

                    if (!TryResolve逻辑地址到从站(地址前缀, 逻辑板号, 通道号, out byte 从站地址, out int 模块索引))
                        throw new InvalidOperationException($"地址无法映射到硬件：{地址}");

                    string key = $"{模块索引}_{从站地址}";
                    if (!分组.TryGetValue(key, out var 列表))
                    {
                        列表 = new List<(string 地址, int 通道号, int 模块索引, byte 从站地址)>();
                        分组[key] = 列表;
                    }
                    列表.Add((地址, 通道号, 模块索引, 从站地址));
                }

                foreach (var 分组项 in 分组.Values)
                {
                    int 起始通道 = 分组项.Min(x => x.通道号);
                    int 结束通道 = 分组项.Max(x => x.通道号);
                    ushort 数量 = (ushort)(结束通道 - 起始通道 + 1);
                    byte 从站地址 = 分组项[0].从站地址;
                    int 模块索引 = 分组项[0].模块索引;

                    short[] 批量数据 = 读取保持寄存器Int16(从站地址, (ushort)(0x0018 + 起始通道), 数量);

                    foreach (var 地址项 in 分组项.OrderBy(x => x.通道号))
                    {
                        short data = 批量数据[地址项.通道号 - 起始通道];
                        (double 量程, string 单位) = 获取模块量程单位(模块索引);
                        double 实际值 = data * 量程 / 10000.0;
                        bool 通过 = 实际值 >= 最小值 && 实际值 <= 最大值;
                        当前拼版通过 &= 通过;

                        string 日志文本 = $"拼版{拼版号}{类型名} {地址项.地址} DATA={data} 值={实际值:F2}{(string.IsNullOrWhiteSpace(单位) ? "" : " " + 单位)} 范围[{最小值},{最大值}] => {(通过 ? "PASS" : "FAIL")}";
                        写入自动测试日志(日志文本);
                        日志管理器.记录(日志类别.测试操作, $"执行[{类型名}] {项.名称}", 日志文本, 权限等级.员工);
                    }
                }

                if (!当前拼版通过)
                {
                    失败拼版.Add(拼版号);
                    设置拼版失败(拼版号, $"{类型名}检测未通过");
                }
            }

            if (失败拼版.Count > 0)
            {
                string 失败列表 = string.Join(",", 失败拼版.OrderBy(x => x).Select(x => $"拼版{x}"));
                throw new InvalidOperationException($"{失败列表}测试FAIL");
            }
        }

        private void 设置拼版失败(int 拼版号, string 原因)
        {
            if (拼版号 <= 0 || 拼版号 > 当前拼板数) return;
            拼版通过状态[拼版号] = false;
            if (拼版失败原因.TryGetValue(拼版号, out string? 旧原因) && !string.IsNullOrWhiteSpace(旧原因))
                拼版失败原因[拼版号] = 旧原因 + " | " + 原因;
            else
                拼版失败原因[拼版号] = 原因;
            int 板序号 = 拼版号 - 1;
            Invoke(() => 设置板状态(板序号, "FAIL"));
            写入自动测试日志($"拼版{拼版号}测试FAIL：{原因}");
            更新统计显示();
        }

        private void 保存本次测试结果()
        {
            string 配置名 = 当前配置?.配置名称 ?? "";
            string sn = SN输入框.Text.Trim();
            DateTime 时间 = 本次测试开始时间 == default ? DateTime.Now : 本次测试开始时间;

            for (int 拼版号 = 1; 拼版号 <= 当前拼板数; 拼版号++)
            {
                bool 通过 = !拼版通过状态.TryGetValue(拼版号, out bool 状态) || 状态;
                string 结果 = 通过 ? "PASS" : "FAIL";
                string fail详情 = 拼版失败原因.TryGetValue(拼版号, out string? 原因) ? 原因 : "";

                var 记录 = new 测试结果记录
                {
                    测试时间 = 时间,
                    测试配置 = 配置名,
                    测试结果 = 结果,
                    SN = sn,
                    FAIL结果 = fail详情,
                    拼版号 = 拼版号
                };

                配置数据库.实例.保存测试结果(记录);
                临时统计记录.Add(记录);
            }
        }

        private void 测试记录按钮_Click(object? sender, EventArgs e)
        {
            var 窗体 = new 测试记录页面();
            窗体.ShowDialog(this);
        }

        private void 临时统计按钮_Click(object? sender, EventArgs e)
        {
            if (临时统计记录.Count == 0)
            {
                MessageBox.Show("当前自动测试页面暂无统计数据。", "临时统计", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int 总数 = 临时统计记录.Count;
            int pass = 临时统计记录.Count(x => x.测试结果 == "PASS");
            int fail = 总数 - pass;
            double passRate = 总数 > 0 ? pass * 100.0 / 总数 : 0;
            MessageBox.Show($"总数: {总数}\nPASS: {pass}\nFAIL: {fail}\n通过率: {passRate:F1}%", "临时统计", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                写入自动测试日志($"继电器读取：从站{kv.Key} 通道[{通道文本}] 当前位图={位图转Hex(当前状态)}");
                日志管理器.记录(日志类别.测试操作, "继电器读取当前状态", $"从站:{kv.Key} 通道:{通道文本} 位图:{位图转Hex(当前状态)}", 权限等级.员工);
                foreach (int 通道 in kv.Value)
                {
                    当前状态[通道] = 目标状态;
                }

                写入多个线圈((byte)kv.Key, 0, 当前状态);
                写入自动测试日志($"继电器写入：从站{kv.Key} 通道[{通道文本}] 目标={(目标状态 ? "ON" : "OFF")} 位图={位图转Hex(当前状态)}");
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

        private Dictionary<int, List<string>> 获取检测项拼版地址映射(编辑配置窗体.检测项数据 项, string 前缀)
        {
            var 结果 = new Dictionary<int, List<string>>();
            int 拼板数 = Math.Max(1, Math.Min(当前拼板数, 32));

            for (int p = 1; p <= 拼板数; p++)
            {
                var 列表 = new List<string>();
                var 去重 = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

                string 主字段 = $"拼版{p}地址";
                string 地址1 = typeof(编辑配置窗体.检测项数据).GetProperty(主字段)?.GetValue(项)?.ToString() ?? "";
                if (!string.IsNullOrWhiteSpace(地址1) && 地址1 != "无" && 地址1.StartsWith(前缀, StringComparison.OrdinalIgnoreCase) && 去重.Add(地址1.Trim()))
                    列表.Add(地址1.Trim());

                for (int s = 2; s <= 4; s++)
                {
                    string 扩展字段 = $"拼版{p}地址_{s}";
                    if (项.扩展地址.TryGetValue(扩展字段, out string? 扩展地址)
                        && !string.IsNullOrWhiteSpace(扩展地址)
                        && 扩展地址 != "无"
                        && 扩展地址.StartsWith(前缀, StringComparison.OrdinalIgnoreCase)
                        && 去重.Add(扩展地址.Trim()))
                    {
                        列表.Add(扩展地址.Trim());
                    }
                }

                if (列表.Count > 0) 结果[p] = 列表;
            }

            return 结果;
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

        private bool 解析通道地址(string 地址, out string 前缀, out int 板号, out int 通道)
        {
            前缀 = "";
            板号 = 0;
            通道 = 0;
            if (string.IsNullOrWhiteSpace(地址)) return false;

            string txt = 地址.Trim().ToUpperInvariant();
            int 点位 = txt.IndexOf('.');
            if (点位 < 0 || 点位 >= txt.Length - 1) return false;

            string 前半 = txt.Substring(0, 点位);
            int idx = 0;
            while (idx < 前半.Length && !char.IsDigit(前半[idx])) idx++;
            if (idx == 0 || idx >= 前半.Length) return false;

            前缀 = 前半.Substring(0, idx);
            return int.TryParse(前半.Substring(idx), out 板号)
                && int.TryParse(txt.Substring(点位 + 1), out 通道)
                && 板号 > 0
                && 通道 >= 0;
        }

        private bool TryResolve逻辑地址到从站(string 前缀, int 逻辑板号, int 通道号, out byte 从站地址, out int 模块索引)
        {
            从站地址 = 0;
            模块索引 = -1;
            var 列表 = 系统配置管理.实例.电压模块.模块列表;
            int 功能板数 = Math.Min(8, 列表.Count);
            int 逻辑序号 = 0;

            for (int i = 0; i < 功能板数; i++)
            {
                string 模块类型 = 列表[i].模块类型;
                if (!模块类型匹配前缀(模块类型, 前缀)) continue;

                var 从站列表 = 模块寄存器管理.获取模块从站地址列表(i, 模块类型);
                if (从站列表.Count == 0) 从站列表.Add(模块寄存器管理.配置.从站地址起始 + i);

                int 每从站通道数 = 前缀 == "VD" || 前缀 == "VA" ? 24 : 8;
                foreach (int slave in 从站列表)
                {
                    逻辑序号++;
                    if (逻辑序号 != 逻辑板号) continue;
                    if (通道号 >= 每从站通道数) return false;

                    从站地址 = (byte)slave;
                    模块索引 = i;
                    return true;
                }
            }

            return false;
        }

        private static bool 模块类型匹配前缀(string 模块类型, string 前缀)
        {
            return 前缀 switch
            {
                "DO" => 模块类型.StartsWith("输出模块") || 模块类型.StartsWith("继电器模块"),
                "VD" => 模块类型 == "直流电压模块（24）",
                "VA" => 模块类型 == "交流电压模块（24）",
                "CD" => 模块类型.StartsWith("交直流电流模块"),
                "CA" => 模块类型.StartsWith("交直流电流模块"),
                _ => false
            };
        }

        private (double 量程, string 单位) 获取模块量程单位(int 模块索引)
        {
            var 列表 = 系统配置管理.实例.电压模块.模块列表;
            if (模块索引 >= 0 && 模块索引 < 列表.Count)
                return (列表[模块索引].量程, 列表[模块索引].单位);
            return (0, "");
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

        private short[] 读取保持寄存器Int16(byte 从站地址, ushort 起始地址, ushort 数量)
        {
            byte[] 请求 = new byte[]
            {
                从站地址, 0x03,
                (byte)(起始地址 >> 8), (byte)(起始地址 & 0xFF),
                (byte)(数量 >> 8), (byte)(数量 & 0xFF)
            };

            int 数据字节数 = 数量 * 2;
            byte[] 响应 = 发送Modbus请求(请求, 5 + 数据字节数, $"读保持寄存器 从站:{从站地址} 起始:{起始地址} 数量:{数量}");
            if (响应[1] != 0x03) throw new InvalidOperationException("读取保持寄存器返回功能码异常");

            short[] 结果 = new short[数量];
            for (int i = 0; i < 数量; i++)
            {
                int 基址 = 3 + i * 2;
                结果[i] = (short)((响应[基址] << 8) | 响应[基址 + 1]);
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
            拼版通过状态.Clear();
            for (int i = 1; i <= 当前拼板数; i++) 拼版通过状态[i] = true;
            更新统计显示();
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