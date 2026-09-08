using System;
using System.Drawing;
using System.IO.Ports;
using System.Text;
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
        private int 累计总数;
        private int 累计通过;
        private int 累计失败;
        private DateTime 本次测试开始时间;
        private readonly Dictionary<int, string> SN串口绑定 = new();
        private readonly Dictionary<string, SerialPort> 扫码串口池 = new(StringComparer.OrdinalIgnoreCase);
        private readonly Dictionary<int, Button> SN扫码按钮 = new();
        private readonly object 扫码串口锁 = new();
        private System.Windows.Forms.Timer? 自动扫码定时器;
        private System.Windows.Forms.Timer? 手动测试超时定时器;
        private Button? 自动扫码切换按钮;
        private bool 自动扫码已开启;
        private bool 手动测试执行中;
        private HashSet<int>? 手动测试目标拼版;

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
            int 总数 = 累计总数;
            int 通过 = 累计通过;
            int 失败 = 累计失败;
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

        private void 累计本次统计结果()
        {
            int 本次总数 = 当前拼板数;
            int 本次失败 = 拼版通过状态.Count(x => !x.Value);
            int 本次通过 = Math.Max(0, 本次总数 - 本次失败);

            累计总数 += 本次总数;
            累计通过 += 本次通过;
            累计失败 += 本次失败;
        }

        private List<(TextBox 输入框, Label 标签)> 获取SN控件列表()
        {
            return new List<(TextBox 输入框, Label 标签)>
            {
                (SN标签1, label2),
                (SN标签2, label1),
                (SN标签3, label3),
                (SN标签4, label4),
                (SN标签5, label5),
                (SN标签6, label6),
                (SN标签7, label7),
                (SN标签8, label8)
            };
        }

        private void 更新SN显示()
        {
            var 控件列表 = 获取SN控件列表();
            bool 单独SN = 当前配置?.单独SN记录 == true;
            int 显示数量 = 单独SN
                ? Math.Max(1, Math.Min(当前拼板数, 控件列表.Count))
                : 1;

            for (int i = 0; i < 控件列表.Count; i++)
            {
                bool 可见 = i < 显示数量;
                控件列表[i].输入框.Visible = 可见;
                控件列表[i].标签.Visible = 可见;
                控件列表[i].标签.Text = $"SN{i + 1}";
                if (SN扫码按钮.TryGetValue(i + 1, out var 按钮))
                {
                    按钮.Visible = 可见;
                }
                if (!可见) 控件列表[i].输入框.Text = "";
            }
        }

        public 自动测试界面()
        {
            InitializeComponent();
            初始化扫码功能控件();
            界面缩放器.等比例适配屏幕(this);
            FormClosing += 自动测试界面_FormClosing;
        }

        private void 自动测试界面_FormClosing(object? sender, FormClosingEventArgs e)
        {
            停止自动扫码();
            停止手动测试超时计时();
            手动测试超时定时器?.Dispose();
            手动测试超时定时器 = null;
            关闭所有扫码串口();
        }

        private void 初始化扫码功能控件()
        {
            var 控件列表 = 获取SN控件列表();
            for (int i = 0; i < 控件列表.Count; i++)
            {
                int sn序号 = i + 1;
                var 输入框 = 控件列表[i].输入框;
                var 按钮 = new Button
                {
                    Name = $"SN扫码按钮{sn序号}",
                    Text = "扫码",
                    Size = new Size(55, 输入框.Height + 2),
                    Location = new Point(输入框.Right + 6, 输入框.Top - 1),
                    Tag = sn序号
                };
                按钮.Click += SN扫码按钮_Click;
                中部面板.Controls.Add(按钮);
                按钮.BringToFront();
                SN扫码按钮[sn序号] = 按钮;
            }

            自动扫码切换按钮 = new Button
            {
                Name = "自动扫码切换按钮",
                Text = "自动扫码:关",
                Size = new Size(100, 35),
                Location = new Point(100, 5)
            };
            自动扫码切换按钮.Click += 自动扫码切换按钮_Click;
            测试控制面板.Controls.Add(自动扫码切换按钮);

            自动扫码定时器 = new System.Windows.Forms.Timer();
            自动扫码定时器.Interval = 800;
            自动扫码定时器.Tick += 自动扫码定时器_Tick;

            手动测试超时定时器 = new System.Windows.Forms.Timer();
            手动测试超时定时器.Tick += 手动测试超时定时器_Tick;
        }

        private void 自动扫码切换按钮_Click(object? sender, EventArgs e)
        {
            if (自动扫码已开启) 停止自动扫码();
            else 启动自动扫码();
        }

        private void SN扫码按钮_Click(object? sender, EventArgs e)
        {
            if (sender is not Button 按钮 || 按钮.Tag is not int sn序号) return;
            尝试扫码并填充SN(sn序号, true);
        }

        private void 自动扫码定时器_Tick(object? sender, EventArgs e)
        {
            if (当前配置 == null) return;
            if (当前配置.单独SN记录 != true) return;
            var 可见SN索引 = 获取可见SN序号();
            foreach (int sn序号 in 可见SN索引)
            {
                尝试扫码并填充SN(sn序号, false);
            }
        }

        private List<int> 获取可见SN序号()
        {
            var 结果 = new List<int>();
            var 列表 = 获取SN控件列表();
            for (int i = 0; i < 列表.Count; i++)
            {
                if (列表[i].输入框.Visible) 结果.Add(i + 1);
            }
            return 结果;
        }

        private void 启动自动扫码()
        {
            if (自动扫码定时器 == null || 自动扫码已开启) return;
            自动扫码已开启 = true;
            自动扫码定时器.Start();
            if (自动扫码切换按钮 != null) 自动扫码切换按钮.Text = "自动扫码:开";
            写入自动测试日志("自动扫码已开启");
        }

        private void 停止自动扫码()
        {
            if (自动扫码定时器 == null || !自动扫码已开启) return;
            自动扫码已开启 = false;
            自动扫码定时器.Stop();
            if (自动扫码切换按钮 != null) 自动扫码切换按钮.Text = "自动扫码:关";
            写入自动测试日志("自动扫码已关闭");
        }

        private void 应用扫码配置()
        {
            SN串口绑定.Clear();
            foreach (var kv in 当前配置?.SN串口绑定 ?? new Dictionary<string, string>())
            {
                if (!kv.Key.StartsWith("SN", StringComparison.OrdinalIgnoreCase)) continue;
                if (!int.TryParse(kv.Key.Substring(2), out int sn序号)) continue;
                if (string.IsNullOrWhiteSpace(kv.Value)) continue;
                SN串口绑定[sn序号] = kv.Value.Trim();
            }

            string 触发方式 = 当前配置?.扫码触发方式 ?? "手动+自动";
            bool 需要自动扫码 = string.Equals(触发方式, "自动", StringComparison.OrdinalIgnoreCase)
                || string.Equals(触发方式, "手动+自动", StringComparison.OrdinalIgnoreCase);
            bool 多SN模式 = 当前配置?.单独SN记录 == true;

            if (自动扫码切换按钮 != null)
            {
                自动扫码切换按钮.Enabled = 需要自动扫码 && 多SN模式;
                自动扫码切换按钮.Visible = 需要自动扫码 && 多SN模式;
            }

            停止自动扫码();
        }

        private bool 开始测试前单次自动扫码()
        {
            if (当前配置 == null || 当前配置.单独SN记录) return true;

            string 触发方式 = 当前配置.扫码触发方式 ?? "手动+自动";
            bool 需要自动扫码 = string.Equals(触发方式, "自动", StringComparison.OrdinalIgnoreCase)
                || string.Equals(触发方式, "手动+自动", StringComparison.OrdinalIgnoreCase);
            if (!需要自动扫码) return true;

            try
            {
                尝试扫码并填充SN(1, true);
                return !string.IsNullOrWhiteSpace(SN标签1.Text);
            }
            catch
            {
                return false;
            }
        }

        private void 尝试扫码并填充SN(int sn序号, bool 手动触发)
        {
            if (!SN串口绑定.TryGetValue(sn序号, out string? 串口名) || string.IsNullOrWhiteSpace(串口名))
            {
                if (手动触发)
                {
                    MessageBox.Show($"SN{sn序号}未绑定COM口", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return;
            }

            try
            {
                string sn = 发送扫码命令并读取SN(串口名);
                if (string.IsNullOrWhiteSpace(sn))
                {
                    if (手动触发)
                    {
                        MessageBox.Show($"SN{sn序号}未收到有效扫码数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    return;
                }

                填充SN文本(sn序号, sn);
                写入自动测试日志($"SN{sn序号}扫码成功：{sn}");
            }
            catch (Exception ex)
            {
                if (手动触发)
                {
                    MessageBox.Show($"SN{sn序号}扫码失败：{ex.Message}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void 填充SN文本(int sn序号, string sn)
        {
            void 设置()
            {
                var 列表 = 获取SN控件列表();
                int idx = sn序号 - 1;
                if (idx < 0 || idx >= 列表.Count) return;
                列表[idx].输入框.Text = sn;
            }

            if (InvokeRequired) Invoke((Action)设置);
            else 设置();
        }

        private string 发送扫码命令并读取SN(string 串口名)
        {
            lock (扫码串口锁)
            {
                var 串口 = 获取或打开扫码串口(串口名);
                byte[] 打开扫码命令 = new byte[] { 0x1B, 0x31 };

                串口.DiscardInBuffer();
                串口.Write(打开扫码命令, 0, 打开扫码命令.Length);

                var 超时 = DateTime.Now.AddSeconds(5);
                using var 缓冲流 = new System.IO.MemoryStream();
                while (DateTime.Now < 超时)
                {
                    int 可读 = 串口.BytesToRead;
                    if (可读 > 0)
                    {
                        byte[] 分段 = new byte[可读];
                        int 已读 = 串口.Read(分段, 0, 分段.Length);
                        if (已读 > 0)
                        {
                            缓冲流.Write(分段, 0, 已读);
                            byte[] 当前数据 = 缓冲流.ToArray();
                            if (是否已收到扫码结果(当前数据))
                            {
                                string sn = 解析扫码回复ASCII(当前数据);
                                if (!string.IsNullOrWhiteSpace(sn))
                                {
                                    return sn;
                                }
                            }
                        }
                    }

                    Thread.Sleep(20);
                }

                throw new TimeoutException("5秒内未收到扫码结果，请扫码一次");
            }
        }

        private static bool 是否已收到扫码结果(byte[] 数据)
        {
            if (数据.Length <= 1)
            {
                return false;
            }

            bool 有结束符 = 数据.Any(b => b == 0x0D || b == 0x0A);
            bool 有可打印字符 = 数据.Any(b => b >= 32 && b <= 126);
            if (有结束符 && 有可打印字符)
            {
                return true;
            }

            string 候选 = 解析扫码回复ASCII(数据);
            return !string.IsNullOrWhiteSpace(候选) && 候选.Length >= 6;
        }

        private SerialPort 获取或打开扫码串口(string 串口名)
        {
            if (!扫码串口池.TryGetValue(串口名, out SerialPort? 串口))
            {
                串口 = new SerialPort();
                扫码串口池[串口名] = 串口;
            }

            var 参数 = 系统配置管理.实例.基础参数;
            int 波特率 = 参数.串口波特率 > 0 ? 参数.串口波特率 : 9600;

            if (串口.IsOpen)
            {
                if (string.Equals(串口.PortName, 串口名, StringComparison.OrdinalIgnoreCase)
                    && 串口.BaudRate == 波特率)
                {
                    return 串口;
                }
                串口.Close();
            }

            串口.PortName = 串口名;
            串口.BaudRate = 波特率;
            串口.Parity = Parity.None;
            串口.DataBits = 8;
            串口.StopBits = StopBits.One;
            串口.ReadTimeout = 200;
            串口.WriteTimeout = 1000;
            串口.Open();
            return 串口;
        }

        private static string 解析扫码回复ASCII(byte[] 数据)
        {
            if (数据.Length == 0) return "";

            string 原始ASCII = Encoding.ASCII.GetString(数据)
                .Trim('\0', '\r', '\n', ' ');
            if (!string.IsNullOrWhiteSpace(原始ASCII))
            {
                string 过滤ASCII = new string(原始ASCII.Where(ch => ch >= 32 && ch <= 126).ToArray()).Trim();
                if (!string.IsNullOrWhiteSpace(过滤ASCII))
                {
                    return 过滤ASCII;
                }
            }

            var sb = new StringBuilder();
            for (int i = 0; i + 1 < 数据.Length; i += 2)
            {
                byte 高位 = 数据[i];
                byte 低位 = 数据[i + 1];
                if (高位 >= 32 && 高位 <= 126) sb.Append((char)高位);
                if (低位 >= 32 && 低位 <= 126) sb.Append((char)低位);
            }
            return sb.ToString().Trim();
        }

        private void 关闭所有扫码串口()
        {
            lock (扫码串口锁)
            {
                foreach (var 串口 in 扫码串口池.Values)
                {
                    try
                    {
                        if (串口.IsOpen) 串口.Close();
                    }
                    catch { }
                    串口.Dispose();
                }
                扫码串口池.Clear();
            }
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

            更新SN显示();
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
            停止自动扫码();
            关闭所有扫码串口();
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
                停止自动扫码();
                return;
            }

            if (!开始测试前单次自动扫码())
            {
                MessageBox.Show("开始前自动扫码失败，请扫码一次后重试。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            测试中 = true;
            手动测试目标拼版 = null;
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

            string 触发方式 = 当前配置?.扫码触发方式 ?? "手动+自动";
            bool 需要自动扫码 = string.Equals(触发方式, "自动", StringComparison.OrdinalIgnoreCase)
                || string.Equals(触发方式, "手动+自动", StringComparison.OrdinalIgnoreCase);
            if (需要自动扫码 && 当前配置?.单独SN记录 == true)
            {
                启动自动扫码();
            }

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
                停止自动扫码();
                关闭所有扫码串口();
                开始测试按钮.Text = "开始测试";
            }
        }

        private async void 手动测试按钮_Click(object? sender, EventArgs e)
        {
            if (手动测试执行中) return;

            if (当前配置 == null)
            {
                MessageBox.Show("未加载配置，无法执行手动测试。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (测试中)
            {
                MessageBox.Show("自动测试进行中，暂不支持手动测试。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!Try获取手动测试目标拼版(out HashSet<int>? 目标拼版, out string 错误信息))
            {
                MessageBox.Show(错误信息, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            手动测试目标拼版 = 目标拼版;

            停止手动测试超时计时();

            int 行索引 = 检测项表格.CurrentCell?.RowIndex ?? -1;
            if (行索引 < 0 || 行索引 >= 检测项表格.Rows.Count)
            {
                MessageBox.Show("请先在左侧列表中选择一个测试项。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int 目标排序 = 0;
            object? 序号值 = 检测项表格.Rows[行索引].Cells["序号列"].Value;
            if (序号值 != null) int.TryParse(序号值.ToString(), out 目标排序);

            var 项 = 当前配置.检测项列表.FirstOrDefault(x => x.排序 == 目标排序);
            if (项 == null && 行索引 < 当前配置.检测项列表.Count)
            {
                项 = 当前配置.检测项列表[行索引];
            }

            if (项 == null)
            {
                MessageBox.Show("未找到对应测试项，请刷新配置后重试。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool 系统异常 = false;
            手动测试执行中 = true;

            try
            {
                写入自动测试日志($"开始手动测试：{项.排序} {项.名称} [{项.类型}] 设定值={项.设定值}");
                拼版通过状态.Clear();
                拼版失败原因.Clear();

                var 本次拼版 = 获取本次测试拼版列表();
                foreach (int 拼版号 in 本次拼版) 拼版通过状态[拼版号] = true;
                重置板状态();

                await Task.Run(() => 执行检测项(项));

                foreach (int i in 本次拼版)
                {
                    bool 通过 = !拼版通过状态.TryGetValue(i, out bool 状态) || 状态;
                    int 板序号 = i - 1;
                    Invoke(() => 设置板状态(板序号, 通过 ? "PASS" : "FAIL"));
                }

                写入自动测试日志($"手动测试完成：{项.排序} {项.名称}");
            }
            catch (Exception 异常)
            {
                bool 是业务FAIL = 异常 is InvalidOperationException
                    && 异常.Message.Contains("测试FAIL", StringComparison.OrdinalIgnoreCase);

                if (是业务FAIL)
                {
                    写入自动测试日志($"手动测试判定FAIL：{异常.Message}");
                }
                else
                {
                    系统异常 = true;
                    写入自动测试日志($"手动测试执行异常：{异常.Message}");
                    MessageBox.Show($"手动测试执行异常：{异常.Message}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            finally
            {
                手动测试执行中 = false;
                电源?.断开();
                电源 = null;
                if (继电器串口 != null)
                {
                    if (继电器串口.IsOpen) 继电器串口.Close();
                    继电器串口.Dispose();
                    继电器串口 = null;
                }

                if (自动选择下一测试项(行索引, out int 下一行索引))
                {
                    写入自动测试日志($"已自动选中下一测试项：第{下一行索引 + 1}行");
                    if (!系统异常) 安排手动测试超时自动执行下一项();
                }
                else
                {
                    停止手动测试超时计时();
                }

                手动测试目标拼版 = null;
            }
        }

        private bool Try获取手动测试目标拼版(out HashSet<int>? 目标拼版, out string 错误信息)
        {
            目标拼版 = null;
            错误信息 = "";
            if (!手动拼版勾选框.Checked) return true;

            if (!Try解析拼版范围文本(手动拼版输入框.Text, out HashSet<int> 解析结果, out 错误信息))
            {
                return false;
            }

            目标拼版 = 解析结果;
            return true;
        }

        private bool Try解析拼版范围文本(string 文本, out HashSet<int> 拼版集合, out string 错误信息)
        {
            拼版集合 = new HashSet<int>();
            错误信息 = "";
            string 内容 = (文本 ?? "").Trim();
            if (string.IsNullOrWhiteSpace(内容))
            {
                错误信息 = "请填写要测试的拼版，例如：1 或 1,3,5 或 2-4";
                return false;
            }

            int 最大拼板 = Math.Max(1, Math.Min(当前拼板数, 32));
            string[] 片段 = 内容.Split(new[] { ',', '，', ';', '；', '、', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string 原片段 in 片段)
            {
                string 片段文本 = 原片段.Trim();
                if (片段文本.Contains('-'))
                {
                    string[] 范围 = 片段文本.Split('-', StringSplitOptions.RemoveEmptyEntries);
                    if (范围.Length != 2
                        || !int.TryParse(范围[0], out int 起始)
                        || !int.TryParse(范围[1], out int 结束))
                    {
                        错误信息 = $"拼版范围格式无效：{片段文本}";
                        return false;
                    }

                    if (起始 > 结束) (起始, 结束) = (结束, 起始);
                    if (起始 < 1 || 结束 > 最大拼板)
                    {
                        错误信息 = $"拼版范围超出有效区间1-{最大拼板}：{片段文本}";
                        return false;
                    }

                    for (int i = 起始; i <= 结束; i++) 拼版集合.Add(i);
                }
                else
                {
                    if (!int.TryParse(片段文本, out int 拼版号))
                    {
                        错误信息 = $"拼版编号格式无效：{片段文本}";
                        return false;
                    }

                    if (拼版号 < 1 || 拼版号 > 最大拼板)
                    {
                        错误信息 = $"拼版编号超出有效区间1-{最大拼板}：{片段文本}";
                        return false;
                    }

                    拼版集合.Add(拼版号);
                }
            }

            if (拼版集合.Count == 0)
            {
                错误信息 = "未解析到有效拼版编号。";
                return false;
            }
            return true;
        }

        private List<int> 获取本次测试拼版列表()
        {
            int 拼板数 = Math.Max(1, Math.Min(当前拼板数, 32));
            IEnumerable<int> 拼版序号 = Enumerable.Range(1, 拼板数);

            if (手动测试目标拼版 != null && 手动测试目标拼版.Count > 0)
            {
                拼版序号 = 拼版序号.Where(x => 手动测试目标拼版.Contains(x));
            }

            return 拼版序号.OrderBy(x => x).ToList();
        }

        private bool 自动选择下一测试项(int 当前行索引, out int 下一行索引)
        {
            下一行索引 = 当前行索引 + 1;
            if (下一行索引 < 0 || 下一行索引 >= 检测项表格.Rows.Count) return false;

            var 首列 = 检测项表格.Columns.GetFirstColumn(DataGridViewElementStates.Visible);
            int 列索引 = 首列?.Index ?? 0;
            检测项表格.CurrentCell = 检测项表格.Rows[下一行索引].Cells[列索引];
            检测项表格.Rows[下一行索引].Selected = true;
            return true;
        }

        private bool Try获取手动测试超时秒(out int 秒)
        {
            秒 = 0;
            return int.TryParse(超时时间输入框.Text.Trim(), out 秒) && 秒 > 0;
        }

        private void 安排手动测试超时自动执行下一项()
        {
            if (!超时勾选框.Checked || 手动测试超时定时器 == null) return;
            if (!Try获取手动测试超时秒(out int 秒))
            {
                写入自动测试日志("手动测试超时设置无效：请输入大于0的秒数");
                return;
            }

            手动测试超时定时器.Stop();
            手动测试超时定时器.Interval = 秒 * 1000;
            手动测试超时定时器.Start();
            写入自动测试日志($"已启动手动测试超时计时：{秒}秒后自动执行下一项");
        }

        private void 停止手动测试超时计时()
        {
            手动测试超时定时器?.Stop();
        }

        private void 超时勾选框_CheckedChanged(object? sender, EventArgs e)
        {
            if (!超时勾选框.Checked)
            {
                停止手动测试超时计时();
                return;
            }

            if (检测项表格.CurrentCell != null) 安排手动测试超时自动执行下一项();
        }

        private void 手动测试超时定时器_Tick(object? sender, EventArgs e)
        {
            停止手动测试超时计时();
            if (测试中 || 手动测试执行中) return;
            if (当前配置 == null || 检测项表格.CurrentCell == null) return;

            写入自动测试日志("手动测试超时触发：自动执行下一测试项");
            手动测试按钮_Click(手动测试按钮, EventArgs.Empty);
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

                    // 产品判定FAIL（业务结果）不作为软件异常中断流程
                    bool 是业务FAIL = 异常 is InvalidOperationException
                        && 异常.Message.Contains("测试FAIL", StringComparison.OrdinalIgnoreCase);

                    if (是业务FAIL)
                    {
                        写入自动测试日志($"测试项{项.排序}判定FAIL，继续执行后续测试项");
                        continue;
                    }

                    // 通讯/配置/执行故障：作为软件异常中断
                    throw new InvalidOperationException($"测试项失败：{项.排序} {项.名称}，错误：{异常.Message}", 异常);
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
            累计本次统计结果();
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
            string 设定值文本 = string.IsNullOrWhiteSpace(项.设定值) ? "无" : 项.设定值.Trim();

            foreach (var kv in 拼版地址映射.OrderBy(x => x.Key))
            {
                int 拼版号 = kv.Key;
                bool 当前拼版通过 = true;
                var 当前拼版失败详情 = new List<string>();

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

                        string 日志文本 = $"拼版{拼版号}{类型名} {地址项.地址} DATA={data} 值={ 实际值:F2}{(string.IsNullOrWhiteSpace(单位) ? "" : " " + 单位)} 范围[{最小值},{最大值}] => {(通过 ? "PASS" : "FAIL")}";
                        写入自动测试日志(日志文本);
                        日志管理器.记录(日志类别.测试操作, $"执行[{类型名}] {项.名称}", 日志文本, 权限等级.员工);

                        if (!通过)
                        {
                            当前拼版失败详情.Add($"拼版{拼版号}FAIL {类型名} {地址项.地址} 设定值={设定值文本} 实际值={ 实际值:F2}{(string.IsNullOrWhiteSpace(单位) ? "" : 单位)} 范围=[{最小值},{最大值}]");
                        }
                    }
                }

                if (!当前拼版通过)
                {
                    失败拼版.Add(拼版号);
                    string 失败原因 = 当前拼版失败详情.Count > 0
                        ? string.Join(" | ", 当前拼版失败详情)
                        : $"拼版{拼版号}FAIL {类型名} 设定值={设定值文本} 实际值=无";
                    设置拼版失败(拼版号, 失败原因);
                }
            }

            if (失败拼版.Count > 0)
            {
                string 失败列表 = string.Join(",", 失败拼版.OrderBy(x => x).Select(x => $"拼版{x}"));
                写入自动测试日志($"{失败列表}测试FAIL");
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
            string sn = SN标签1.Text.Trim();
            DateTime 时间 = 本次测试开始时间 == default ? DateTime.Now : 本次测试开始时间;

            bool 单独SN记录 = 当前配置?.单独SN记录 == true;
            if (!单独SN记录)
            {
                int fail数量 = 拼版通过状态.Count(x => !x.Value);
                string 汇总结果 = fail数量 == 0 ? "PASS" : "FAIL";
                string 汇总失败详情 = string.Join(" | ",
                    拼版失败原因
                        .OrderBy(x => x.Key)
                        .Select(x => $"拼版{x.Key}:{x.Value}"));

                var 汇总记录 = new 测试结果记录
                {
                    测试时间 = 时间,
                    测试配置 = 配置名,
                    测试结果 = 汇总结果,
                    SN = sn,
                    FAIL结果 = 汇总失败详情,
                    拼版号 = 0
                };

                配置数据库.实例.保存测试结果(汇总记录);
                return;
            }

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
            }
        }

        private void 测试记录按钮_Click(object? sender, EventArgs e)
        {
            var 窗体 = new 测试记录页面();
            窗体.ShowDialog(this);
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

            foreach (int p in 获取本次测试拼版列表())
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

            foreach (int p in 获取本次测试拼版列表())
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
            更新SN显示();
            应用扫码配置();
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