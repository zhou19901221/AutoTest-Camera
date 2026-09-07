using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;

namespace 自动测试
{
    public partial class 端口测试页面 : Form
    {
        private static readonly Color 未连接色 = Color.FromArgb(200, 200, 200);
        private static readonly Color 已连接色 = Color.FromArgb(0, 176, 80);
        private static readonly Color 错误色 = Color.FromArgb(255, 0, 0);
        private static readonly Color 开启色 = Color.FromArgb(0, 176, 80);
        private static readonly Color 关闭色 = Color.FromArgb(200, 200, 200);

        private readonly Dictionary<string, bool> 通道状态 = new();
        private SerialPort? modbus串口;
        private readonly System.Windows.Forms.Timer 输入轮询定时器 = new System.Windows.Forms.Timer();
        private readonly HashSet<Panel> 输入轮询卡片 = new HashSet<Panel>();

        private class 模块卡片信息
        {
            public string 板名称 { get; set; } = "";
            public string 模块类型 { get; set; } = "";
            public int 从站地址 { get; set; }
            public int 配置索引 { get; set; } = -1;
            public bool 已连接 { get; set; }
        }

        public 端口测试页面()
        {
            InitializeComponent();
            生成模块按钮();
            界面缩放器.等比例适配屏幕(this);
            输入轮询定时器.Interval = 200;
            输入轮询定时器.Tick += 输入轮询定时器_Tick;
        }

        private void 生成模块按钮()
        {
            模块面板.Controls.Clear();

            AddSerialCard();

            var 配置 = 系统配置管理.实例;
            int 地址起始 = 模块寄存器管理.配置.从站地址起始;
            int 功能板数 = Math.Min(8, 配置.电压模块.模块列表.Count);
            int 电源板数 = Math.Min(3, 配置.电压模块.模块列表.Count - 8);

            for (int i = 0; i < 功能板数; i++)
            {
                string 模块类型 = 配置.电压模块.模块列表[i].模块类型;
                int 从站地址 = 地址起始 + i;
                AddModuleCard($"功能板{i + 1}", 模块类型, 从站地址, i);
            }

            for (int i = 0; i < 电源板数; i++)
            {
                int 偏移 = 8 + i;
                if (偏移 >= 配置.电压模块.模块列表.Count) break;
                string 模块类型 = 配置.电压模块.模块列表[偏移].模块类型;
                int 从站地址 = 地址起始 + 功能板数 + i;
                AddModuleCard($"电源板{i + 1}", 模块类型, 从站地址, 偏移);
            }
        }

        private void AddSerialCard()
        {
            var 卡片 = new Panel();
            卡片.Size = new Size(560, 50);
            卡片.Tag = "串口通讯板";
            卡片.BackColor = Color.White;
            卡片.Margin = new Padding(3);

            var 标题行 = new Panel();
            标题行.Size = new Size(554, 44);
            标题行.Dock = DockStyle.Top;
            标题行.BackColor = Color.FromArgb(245, 245, 245);

            var 名称标签 = new Label();
            名称标签.Text = "串口通讯板 [RS485]";
            名称标签.Location = new Point(8, 12);
            名称标签.Size = new Size(200, 22);
            名称标签.Font = new Font("Microsoft YaHei UI", 9.5F, FontStyle.Bold);
            标题行.Controls.Add(名称标签);

            var 状态指示 = new Panel();
            状态指示.Location = new Point(210, 12);
            状态指示.Size = new Size(18, 18);
            状态指示.BackColor = 未连接色;
            状态指示.Name = "状态指示";
            标题行.Controls.Add(状态指示);

            var 状态标签 = new Label();
            状态标签.Text = "未连接";
            状态标签.Location = new Point(232, 12);
            状态标签.Size = new Size(60, 18);
            状态标签.Font = new Font("Microsoft YaHei UI", 9F);
            状态标签.Name = "状态标签";
            标题行.Controls.Add(状态标签);

            var 连接按钮 = new Button();
            连接按钮.Text = "连接";
            连接按钮.Location = new Point(380, 8);
            连接按钮.Size = new Size(55, 28);
            连接按钮.FlatStyle = FlatStyle.Flat;
            连接按钮.BackColor = Color.FromArgb(91, 155, 213);
            连接按钮.ForeColor = Color.White;
            连接按钮.Font = new Font("Microsoft YaHei UI", 9F);
            连接按钮.Name = "连接按钮";
            连接按钮.Tag = 卡片;
            连接按钮.Click += 串口连接按钮_Click;
            标题行.Controls.Add(连接按钮);

            var 断开按钮 = new Button();
            断开按钮.Text = "断开";
            断开按钮.Location = new Point(440, 8);
            断开按钮.Size = new Size(55, 28);
            断开按钮.FlatStyle = FlatStyle.Flat;
            断开按钮.BackColor = Color.FromArgb(220, 80, 60);
            断开按钮.ForeColor = Color.White;
            断开按钮.Font = new Font("Microsoft YaHei UI", 9F);
            断开按钮.Name = "断开按钮";
            断开按钮.Tag = 卡片;
            断开按钮.Click += 串口断开按钮_Click;
            标题行.Controls.Add(断开按钮);

            卡片.Controls.Add(标题行);
            模块面板.Controls.Add(卡片);
        }

        private void 串口连接按钮_Click(object sender, EventArgs e)
        {
            var 按钮 = sender as Button;
            if (按钮?.Tag is not Panel 卡片) return;
            SetCardStatus(卡片, 已连接色, "已连接");
            展开串口通道(卡片);
            日志管理器.记录(日志类别.硬件操作, "串口连接", "串口通讯板", 权限等级.管理员);
        }

        private void 串口断开按钮_Click(object sender, EventArgs e)
        {
            var 按钮 = sender as Button;
            if (按钮?.Tag is not Panel 卡片) return;
            SetCardStatus(卡片, 未连接色, "未连接");
            收起串口通道(卡片);
            日志管理器.记录(日志类别.硬件操作, "串口断开", "串口通讯板", 权限等级.管理员);
        }

        private void 展开串口通道(Panel 卡片)
        {
            收起串口通道(卡片);

            var 通道面板 = new Panel();
            通道面板.Name = "通道面板";
            通道面板.Location = new Point(0, 48);
            通道面板.Width = 554;
            通道面板.Height = 90;
            卡片.Height = 50 + 通道面板.Height;

            var 通道选择标签 = new Label();
            通道选择标签.Text = "通道：";
            通道选择标签.Location = new Point(8, 7);
            通道选择标签.Size = new Size(45, 20);
            通道选择标签.Font = new Font("Microsoft YaHei UI", 9F);
            通道面板.Controls.Add(通道选择标签);

            var 通道选择框 = new ComboBox();
            通道选择框.DropDownStyle = ComboBoxStyle.DropDownList;
            通道选择框.Items.AddRange(new object[] { "通道1", "通道2", "通道3", "通道4" });
            通道选择框.SelectedIndex = 0;
            通道选择框.Location = new Point(53, 5);
            通道选择框.Size = new Size(70, 25);
            通道选择框.Font = new Font("Microsoft YaHei UI", 9F);
            通道选择框.Name = "通道选择框";
            通道面板.Controls.Add(通道选择框);

            var 发送标签 = new Label();
            发送标签.Text = "发送：";
            发送标签.Location = new Point(130, 7);
            发送标签.Size = new Size(45, 20);
            发送标签.Font = new Font("Microsoft YaHei UI", 9F);
            通道面板.Controls.Add(发送标签);

            var 发送框 = new TextBox();
            发送框.Location = new Point(175, 5);
            发送框.Size = new Size(240, 26);
            发送框.Font = new Font("Consolas", 9F);
            发送框.Name = "发送框";
            通道面板.Controls.Add(发送框);

            var 发送按钮 = new Button();
            发送按钮.Text = "发送";
            发送按钮.Location = new Point(420, 3);
            发送按钮.Size = new Size(55, 28);
            发送按钮.FlatStyle = FlatStyle.Flat;
            发送按钮.BackColor = Color.FromArgb(91, 155, 213);
            发送按钮.ForeColor = Color.White;
            发送按钮.Font = new Font("Microsoft YaHei UI", 9F);
            发送按钮.Name = "发送按钮";
            发送按钮.Tag = 卡片;
            发送按钮.Click += 串口发送按钮_Click;
            通道面板.Controls.Add(发送按钮);

            var 清空按钮 = new Button();
            清空按钮.Text = "清空";
            清空按钮.Location = new Point(480, 3);
            清空按钮.Size = new Size(55, 28);
            清空按钮.FlatStyle = FlatStyle.Flat;
            清空按钮.Font = new Font("Microsoft YaHei UI", 9F);
            清空按钮.Name = "清空按钮";
            清空按钮.Tag = 卡片;
            清空按钮.Click += 串口清空按钮_Click;
            通道面板.Controls.Add(清空按钮);

            var 接收标签 = new Label();
            接收标签.Text = "接收：";
            接收标签.Location = new Point(60, 40);
            接收标签.Size = new Size(45, 20);
            接收标签.Font = new Font("Microsoft YaHei UI", 9F);
            通道面板.Controls.Add(接收标签);

            var 接收框 = new TextBox();
            接收框.Location = new Point(105, 38);
            接收框.Size = new Size(430, 46);
            接收框.Multiline = true;
            接收框.ReadOnly = true;
            接收框.Font = new Font("Consolas", 9F);
            接收框.BackColor = Color.FromArgb(248, 248, 248);
            接收框.Name = "接收框";
            接收框.ScrollBars = ScrollBars.Vertical;
            通道面板.Controls.Add(接收框);

            卡片.Controls.Add(通道面板);
        }

        private void 收起串口通道(Panel 卡片)
        {
            foreach (Control c in 卡片.Controls)
            {
                if (c is Panel p && p.Name == "通道面板")
                {
                    卡片.Controls.Remove(p);
                    p.Dispose();
                    break;
                }
            }
            卡片.Height = 50;
        }

        private void 串口发送按钮_Click(object sender, EventArgs e)
        {
            var 按钮 = sender as Button;
            if (按钮?.Tag is not Panel 卡片) return;

            string 发送内容 = "";
            string 接收内容 = "";
            foreach (Control c in 卡片.Controls)
            {
                if (c is Panel 通道面板 && 通道面板.Name == "通道面板")
                {
                    foreach (Control tc in 通道面板.Controls)
                    {
                        if (tc.Name == "发送框") 发送内容 = tc.Text;
                        if (tc.Name == "接收框") 接收内容 = tc.Text;
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(发送内容))
            {
                MessageBox.Show("请输入发送报文内容", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            日志管理器.记录(日志类别.硬件操作, "串口发送报文", 发送内容, 权限等级.厂家);

            接收内容 += $"[{DateTime.Now:HH:mm:ss.fff}] 发送: {发送内容}\r\n";
            接收内容 += $"[{DateTime.Now:HH:mm:ss.fff}] 接收: (待通讯实现)\r\n";

            foreach (Control c in 卡片.Controls)
            {
                if (c is Panel 通道面板 && 通道面板.Name == "通道面板")
                {
                    foreach (Control tc in 通道面板.Controls)
                    {
                        if (tc.Name == "接收框") tc.Text = 接收内容;
                    }
                }
            }
        }

        private void 输入轮询定时器_Tick(object? sender, EventArgs e)
        {
            if (输入轮询卡片.Count == 0) return;

            var 快照 = new List<Panel>(输入轮询卡片);
            foreach (var 卡片 in 快照)
            {
                if (!卡片已连接(卡片)) continue;

                try
                {
                    读取并刷新输入模块(卡片);
                    SetCardStatus(卡片, 已连接色, "已连接");
                }
                catch
                {
                    标记卡片连接状态(卡片, false);
                    输入轮询卡片.Remove(卡片);
                    SetCardStatus(卡片, 错误色, "错误");
                    MessageBox.Show("读取失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            if (输入轮询卡片.Count == 0)
            {
                输入轮询定时器.Stop();
            }
        }

        private void 读取并刷新输入模块(Panel 卡片)
        {
            string 模块类型 = 获取模块类型(卡片);
            int 通道数 = 获取模块通道数(模块类型);
            if (通道数 <= 0) return;

            short[] 原始值 = 读取保持寄存器Int16((byte)获取从站地址(卡片), 0x0018, (ushort)通道数);
            (double 量程, string 单位) = 获取模块量程单位(卡片);
            string 前缀 = 获取地址前缀(模块类型);

            foreach (Control c in 卡片.Controls)
            {
                if (c is not Panel 通道面板 || 通道面板.Name != "通道面板") continue;
                for (int ch = 0; ch < 通道数; ch++)
                {
                    string 控件名 = $"RD_{前缀}{ch}";
                    if (通道面板.Controls[控件名] is TextBox 读数框)
                    {
                        double 实际值 = 原始值[ch] * 量程 / 10000.0;
                        string 数值文本 = 实际值.ToString("F2");
                        读数框.Text = string.IsNullOrWhiteSpace(单位) ? 数值文本 : $"{数值文本} {单位}";
                    }
                }
            }
        }

        private (double 量程, string 单位) 获取模块量程单位(Panel 卡片)
        {
            int 索引 = 获取配置索引(卡片);
            var 列表 = 系统配置管理.实例.电压模块.模块列表;
            if (索引 >= 0 && 索引 < 列表.Count)
            {
                return (列表[索引].量程, 列表[索引].单位);
            }
            return (0, "");
        }

        private void 串口清空按钮_Click(object sender, EventArgs e)
        {
            var 按钮 = sender as Button;
            if (按钮?.Tag is not Panel 卡片) return;

            foreach (Control c in 卡片.Controls)
            {
                if (c is Panel 通道面板 && 通道面板.Name == "通道面板")
                {
                    foreach (Control tc in 通道面板.Controls)
                    {
                        if (tc.Name == "接收框") tc.Text = "";
                    }
                }
            }
        }

        private void AddModuleCard(string 板名称, string 模块类型, int 从站地址, int 配置索引)
        {
            var 卡片 = new Panel();
            卡片.Size = new Size(560, 50);
            卡片.Tag = new 模块卡片信息 { 板名称 = 板名称, 模块类型 = 模块类型, 从站地址 = 从站地址, 配置索引 = 配置索引, 已连接 = false };
            卡片.BackColor = Color.White;
            卡片.Margin = new Padding(3);

            var 标题行 = new Panel();
            标题行.Size = new Size(554, 44);
            标题行.Dock = DockStyle.Top;
            标题行.BackColor = Color.FromArgb(245, 245, 245);

            var 名称标签 = new Label();
            名称标签.Text = $"{板名称} [{模块类型}] 地址:{从站地址}";
            名称标签.Location = new Point(8, 12);
            名称标签.Size = new Size(280, 22);
            名称标签.Font = new Font("Microsoft YaHei UI", 9.5F, FontStyle.Bold);
            标题行.Controls.Add(名称标签);

            var 状态指示 = new Panel();
            状态指示.Location = new Point(290, 12);
            状态指示.Size = new Size(18, 18);
            状态指示.BackColor = 未连接色;
            状态指示.Name = "状态指示";
            标题行.Controls.Add(状态指示);

            var 状态标签 = new Label();
            状态标签.Text = "未连接";
            状态标签.Location = new Point(312, 12);
            状态标签.Size = new Size(60, 18);
            状态标签.Font = new Font("Microsoft YaHei UI", 9F);
            状态标签.Name = "状态标签";
            标题行.Controls.Add(状态标签);

            var 连接按钮 = new Button();
            连接按钮.Text = "连接";
            连接按钮.Location = new Point(380, 8);
            连接按钮.Size = new Size(55, 28);
            连接按钮.FlatStyle = FlatStyle.Flat;
            连接按钮.BackColor = Color.FromArgb(91, 155, 213);
            连接按钮.ForeColor = Color.White;
            连接按钮.Font = new Font("Microsoft YaHei UI", 9F);
            连接按钮.Name = "连接按钮";
            连接按钮.Tag = 卡片;
            连接按钮.Click += 连接按钮_Click;
            标题行.Controls.Add(连接按钮);

            var 断开按钮 = new Button();
            断开按钮.Text = "断开";
            断开按钮.Location = new Point(440, 8);
            断开按钮.Size = new Size(55, 28);
            断开按钮.FlatStyle = FlatStyle.Flat;
            断开按钮.BackColor = Color.FromArgb(220, 80, 60);
            断开按钮.ForeColor = Color.White;
            断开按钮.Font = new Font("Microsoft YaHei UI", 9F);
            断开按钮.Name = "断开按钮";
            断开按钮.Tag = 卡片;
            断开按钮.Click += 断开按钮_Click;
            标题行.Controls.Add(断开按钮);

            var 全开全关按钮 = new Button();
            全开全关按钮.Text = "全开";
            全开全关按钮.Location = new Point(500, 8);
            全开全关按钮.Size = new Size(45, 28);
            全开全关按钮.FlatStyle = FlatStyle.Flat;
            全开全关按钮.BackColor = Color.FromArgb(50, 150, 50);
            全开全关按钮.ForeColor = Color.White;
            全开全关按钮.Font = new Font("Microsoft YaHei UI", 9F);
            全开全关按钮.Name = "全开全关按钮";
            全开全关按钮.Tag = 卡片;
            全开全关按钮.Click += 全开全关按钮_Click;
            全开全关按钮.Visible = false;
            标题行.Controls.Add(全开全关按钮);

            卡片.Controls.Add(标题行);

            if (模块类型 == "无")
            {
                卡片.BackColor = Color.FromArgb(240, 240, 240);
                foreach (Control c in 标题行.Controls)
                {
                    if (c is Button btn) btn.Enabled = false;
                }
            }

            模块面板.Controls.Add(卡片);
        }

        private void 连接按钮_Click(object sender, EventArgs e)
        {
            var 按钮 = sender as Button;
            if (按钮?.Tag is not Panel 卡片) return;
            string 模块类型 = 获取模块类型(卡片);

            if (是输入模块(模块类型))
            {
                try
                {
                    确保Modbus串口连接();
                    展开通道面板(卡片);
                    标记卡片连接状态(卡片, true);
                    输入轮询卡片.Add(卡片);
                    if (!输入轮询定时器.Enabled) 输入轮询定时器.Start();
                    SetCardStatus(卡片, 已连接色, "已连接");
                    读取并刷新输入模块(卡片);
                    日志管理器.记录(日志类别.硬件操作, "输入模块连接并开始轮询", 获取卡片名称(卡片), 权限等级.管理员);
                }
                catch (Exception ex)
                {
                    标记卡片连接状态(卡片, false);
                    输入轮询卡片.Remove(卡片);
                    SetCardStatus(卡片, 错误色, "错误");
                    MessageBox.Show($"连接设备失败：{ex.Message}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    日志管理器.记录(日志类别.硬件操作, "输入模块连接失败", ex.Message, 权限等级.管理员);
                }
                return;
            }

            if (!是输出模块(模块类型))
            {
                SetCardStatus(卡片, 已连接色, "已连接");
                展开通道面板(卡片);
                标记卡片连接状态(卡片, true);
                日志管理器.记录(日志类别.硬件操作, "模块连接", 获取卡片名称(卡片), 权限等级.管理员);
                return;
            }

            try
            {
                确保Modbus串口连接();
                int 从站地址 = 获取从站地址(卡片);
                int 通道数 = 获取模块通道数(模块类型);
                bool[] 线圈状态 = 读取线圈((byte)从站地址, 0, (ushort)通道数);

                展开通道面板(卡片);
                应用输出通道状态到界面(卡片, 线圈状态);
                标记卡片连接状态(卡片, true);
                SetCardStatus(卡片, 已连接色, "已连接");
                日志管理器.记录(日志类别.硬件操作, "模块连接并读取线圈", $"{获取卡片名称(卡片)} 地址:{从站地址}", 权限等级.管理员);
            }
            catch (Exception ex)
            {
                标记卡片连接状态(卡片, false);
                SetCardStatus(卡片, 错误色, "错误");
                MessageBox.Show($"连接设备失败：{ex.Message}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                日志管理器.记录(日志类别.硬件操作, "模块连接失败", ex.Message, 权限等级.管理员);
            }
        }

        private void 断开按钮_Click(object sender, EventArgs e)
        {
            var 按钮 = sender as Button;
            if (按钮?.Tag is not Panel 卡片) return;
            SetCardStatus(卡片, 未连接色, "未连接");
            收起通道面板(卡片);
            标记卡片连接状态(卡片, false);
            输入轮询卡片.Remove(卡片);
            if (输入轮询卡片.Count == 0 && 输入轮询定时器.Enabled) 输入轮询定时器.Stop();
            日志管理器.记录(日志类别.硬件操作, "模块断开", 获取卡片名称(卡片), 权限等级.管理员);
        }

        private void 全开全关按钮_Click(object sender, EventArgs e)
        {
            var 按钮 = sender as Button;
            if (按钮?.Tag is not Panel 卡片) return;

            bool 当前全开 = 按钮.Text == "全关";
            string 模块类型 = 获取模块类型(卡片);

            if (是输出模块(模块类型))
            {
                if (!卡片已连接(卡片))
                {
                    MessageBox.Show("请先连接设备", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    int 从站地址 = 获取从站地址(卡片);
                    int 通道数 = 获取模块通道数(模块类型);
                    bool 目标状态 = !当前全开;
                    bool[] 状态数组 = new bool[通道数];
                    for (int i = 0; i < 通道数; i++) 状态数组[i] = 目标状态;
                    写入多个线圈((byte)从站地址, 0, 状态数组);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"批量写入失败：{ex.Message}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SetCardStatus(卡片, 错误色, "错误");
                    return;
                }
            }

            foreach (Control c in 卡片.Controls)
            {
                if (c is Panel 通道面板 && 通道面板.Name == "通道面板")
                {
                    foreach (Control 通道控件 in 通道面板.Controls)
                    {
                        if (通道控件 is Button 通道按钮 && 通道按钮.Name.StartsWith("CH_"))
                        {
                            通道按钮.BackColor = !当前全开 ? 开启色 : 关闭色;
                            通道按钮.Text = !当前全开 ? 通道按钮.Text.Replace("OFF", "ON") : 通道按钮.Text.Replace("ON", "OFF");
                            通道状态[获取通道状态Key(卡片, 通道按钮.Name)] = !当前全开;
                        }
                    }
                }
            }

            按钮.Text = !当前全开 ? "全关" : "全开";
            按钮.BackColor = !当前全开 ? Color.FromArgb(220, 80, 60) : Color.FromArgb(50, 150, 50);
            日志管理器.记录(日志类别.硬件操作, !当前全开 ? "全部通道开启" : "全部通道关闭", 获取卡片名称(卡片), 权限等级.厂家);
        }

        private void 展开通道面板(Panel 卡片)
        {
            收起通道面板(卡片);

            string 模块类型 = 获取模块类型(卡片);
            int 通道数 = 获取模块通道数(模块类型);
            bool 是输出型 = 是输出模块(模块类型);
            bool 是输入型 = 是输入模块(模块类型);
            bool 是电源型 = 是电源模块(模块类型);
            bool 是脉冲型 = 是脉冲模块(模块类型);

            var 通道面板 = new Panel();
            通道面板.Name = "通道面板";
            通道面板.Location = new Point(0, 48);
            通道面板.Width = 554;

            if (是电源型)
            {
                通道面板.Height = 通道数 * 32 + 30;
                卡片.Height = 50 + 通道面板.Height;
                卡片.Width = 560;

                var 表头 = new Label();
                表头.Text = "  通道      开关       电压(V)     电流(A)     功率(W)";
                表头.Location = new Point(5, 3);
                表头.Size = new Size(540, 22);
                表头.Font = new Font("Microsoft YaHei UI", 8.5F, FontStyle.Bold);
                通道面板.Controls.Add(表头);

                for (int ch = 0; ch < 通道数; ch++)
                {
                    int y = 26 + ch * 32;

                    var 通道标签 = new Label();
                    通道标签.Text = $"PS{ch}";
                    通道标签.Location = new Point(5, y + 3);
                    通道标签.Size = new Size(40, 22);
                    通道标签.Font = new Font("Microsoft YaHei UI", 9F);
                    通道面板.Controls.Add(通道标签);

                    var 开关按钮 = new Button();
                    开关按钮.Text = "OFF";
                    开关按钮.Size = new Size(50, 26);
                    开关按钮.Location = new Point(50, y);
                    开关按钮.FlatStyle = FlatStyle.Flat;
                    开关按钮.BackColor = 关闭色;
                    开关按钮.Font = new Font("Microsoft YaHei UI", 8F);
                    开关按钮.Name = $"CH_PS{ch}";
                    开关按钮.Tag = 卡片;
                    开关按钮.Click += 通道开关_Click;
                    通道面板.Controls.Add(开关按钮);

                    var 电压框 = new TextBox();
                    电压框.Text = "--";
                    电压框.Size = new Size(80, 26);
                    电压框.Location = new Point(110, y);
                    电压框.ReadOnly = true;
                    电压框.Font = new Font("Microsoft YaHei UI", 9F);
                    电压框.BackColor = Color.FromArgb(248, 248, 248);
                    电压框.Name = $"RD_PS{ch}_V";
                    通道面板.Controls.Add(电压框);

                    var 电流框 = new TextBox();
                    电流框.Text = "--";
                    电流框.Size = new Size(80, 26);
                    电流框.Location = new Point(200, y);
                    电流框.ReadOnly = true;
                    电流框.Font = new Font("Microsoft YaHei UI", 9F);
                    电流框.BackColor = Color.FromArgb(248, 248, 248);
                    电流框.Name = $"RD_PS{ch}_A";
                    通道面板.Controls.Add(电流框);

                    var 功率框 = new TextBox();
                    功率框.Text = "--";
                    功率框.Size = new Size(80, 26);
                    功率框.Location = new Point(290, y);
                    功率框.ReadOnly = true;
                    功率框.Font = new Font("Microsoft YaHei UI", 9F);
                    功率框.BackColor = Color.FromArgb(248, 248, 248);
                    功率框.Name = $"RD_PS{ch}_W";
                    通道面板.Controls.Add(功率框);

                    var 功率标签 = new Label();
                    功率标签.Text = $"PW{ch}: --";
                    功率标签.Location = new Point(380, y + 3);
                    功率标签.Size = new Size(80, 22);
                    功率标签.Font = new Font("Microsoft YaHei UI", 8.5F);
                    功率标签.Name = $"LB_PW{ch}";
                    通道面板.Controls.Add(功率标签);
                }
            }
            else if (是脉冲型)
            {
                通道面板.Height = 通道数 * 32 + 50;
                卡片.Height = 50 + 通道面板.Height;
                卡片.Width = 560;

                var PO表头 = new Label();
                PO表头.Text = "  PO通道    脉冲频率(Hz)          PI通道    声音大小(dB)";
                PO表头.Location = new Point(5, 3);
                PO表头.Size = new Size(540, 22);
                PO表头.Font = new Font("Microsoft YaHei UI", 8.5F, FontStyle.Bold);
                通道面板.Controls.Add(PO表头);

                for (int ch = 0; ch < 通道数; ch++)
                {
                    int y = 26 + ch * 32;

                    var PO标签 = new Label();
                    PO标签.Text = $"PO{ch}";
                    PO标签.Location = new Point(5, y + 3);
                    PO标签.Size = new Size(40, 22);
                    PO标签.Font = new Font("Microsoft YaHei UI", 9F);
                    通道面板.Controls.Add(PO标签);

                    var 频率框 = new TextBox();
                    频率框.Text = "--";
                    频率框.Size = new Size(100, 26);
                    频率框.Location = new Point(50, y);
                    频率框.ReadOnly = true;
                    频率框.Font = new Font("Microsoft YaHei UI", 9F);
                    频率框.BackColor = Color.FromArgb(248, 248, 248);
                    频率框.Name = $"RD_PO{ch}";
                    通道面板.Controls.Add(频率框);

                    var PI标签 = new Label();
                    PI标签.Text = $"PI{ch}";
                    PI标签.Location = new Point(280, y + 3);
                    PI标签.Size = new Size(40, 22);
                    PI标签.Font = new Font("Microsoft YaHei UI", 9F);
                    通道面板.Controls.Add(PI标签);

                    var 声音框 = new TextBox();
                    声音框.Text = "--";
                    声音框.Size = new Size(100, 26);
                    声音框.Location = new Point(325, y);
                    声音框.ReadOnly = true;
                    声音框.Font = new Font("Microsoft YaHei UI", 9F);
                    声音框.BackColor = Color.FromArgb(248, 248, 248);
                    声音框.Name = $"RD_PI{ch}";
                    通道面板.Controls.Add(声音框);
                }
            }
            else
            {
                int 行数 = (通道数 + 7) / 8;
                通道面板.Height = 行数 * 36 + 10;
                卡片.Height = 50 + 通道面板.Height;

                string 前缀 = 获取地址前缀(模块类型);

                for (int ch = 0; ch < 通道数; ch++)
                {
                    int 行 = ch / 8;
                    int 列 = ch % 8;
                    int x = 8 + 列 * 68;
                    int y = 5 + 行 * 36;

                    if (是输出型)
                    {
                        var 通道按钮 = new Button();
                        通道按钮.Text = $"{前缀}{ch}";
                        通道按钮.Size = new Size(62, 30);
                        通道按钮.Location = new Point(x, y);
                        通道按钮.FlatStyle = FlatStyle.Flat;
                        通道按钮.BackColor = 关闭色;
                        通道按钮.Font = new Font("Microsoft YaHei UI", 8F);
                        通道按钮.Name = $"CH_{前缀}{ch}";
                        通道按钮.Tag = 卡片;
                        通道按钮.Click += 通道开关_Click;
                        通道面板.Controls.Add(通道按钮);
                    }
                    else if (是输入型)
                    {
                        var 通道框 = new TextBox();
                        通道框.Text = $"{前缀}{ch}: --";
                        通道框.Size = new Size(62, 26);
                        通道框.Location = new Point(x, y);
                        通道框.ReadOnly = true;
                        通道框.Font = new Font("Microsoft YaHei UI", 8F);
                        通道框.BackColor = Color.FromArgb(248, 248, 248);
                        通道框.Name = $"RD_{前缀}{ch}";
                        通道面板.Controls.Add(通道框);
                    }
                }
            }

            if (是输出型 || 是电源型)
            {
                foreach (Control c in 卡片.Controls)
                {
                    if (c is Panel 标题行)
                    {
                        foreach (Control tc in 标题行.Controls)
                        {
                            if (tc.Name == "全开全关按钮") tc.Visible = true;
                        }
                    }
                }
            }

            卡片.Controls.Add(通道面板);
        }


        private void 通道开关_Click(object sender, EventArgs e)
        {
            var 按钮 = sender as Button;
            if (按钮 == null) return;

            if (按钮.Tag is not Panel 卡片) return;

            string 模块类型 = 获取模块类型(卡片);
            if (是输出模块(模块类型))
            {
                if (!卡片已连接(卡片))
                {
                    MessageBox.Show("请先连接设备", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int 通道号 = 解析通道号(按钮.Name);
                if (通道号 < 0) return;

                bool 当前状态输出 = 通道状态.TryGetValue(获取通道状态Key(卡片, 按钮.Name), out bool 值) && 值;
                bool 目标状态 = !当前状态输出;

                try
                {
                    写入单个线圈((byte)获取从站地址(卡片), (ushort)通道号, 目标状态);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"通道切换失败：{ex.Message}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SetCardStatus(卡片, 错误色, "错误");
                    return;
                }
            }

            string 通道名 = 按钮.Name.Substring(3);
            string 状态Key = 获取通道状态Key(卡片, 按钮.Name);
            bool 当前状态 = 通道状态.TryGetValue(状态Key, out bool 状态值) && 状态值;
            通道状态[状态Key] = !当前状态;

            按钮.BackColor = !当前状态 ? 开启色 : 关闭色;
            按钮.Text = !当前状态 ? $"{通道名} ON" : $"{通道名} OFF";

            string 卡片名 = 获取卡片名称(卡片);
            日志管理器.记录(日志类别.硬件操作, !当前状态 ? "通道开启" : "通道关闭", $"{卡片名} {通道名}", 权限等级.厂家);
        }

        private void 收起通道面板(Panel 卡片)
        {
            foreach (Control c in 卡片.Controls)
            {
                if (c is Panel p && p.Name == "通道面板")
                {
                    卡片.Controls.Remove(p);
                    p.Dispose();
                    break;
                }
            }

            卡片.Height = 50;

            foreach (Control c in 卡片.Controls)
            {
                if (c is Button btn && btn.Name == "全开全关按钮") btn.Visible = false;
            }
        }

        private bool 是输出模块(string 类型)
        {
            return 类型.StartsWith("输出模块") || 类型.StartsWith("继电器模块");
        }

        private bool 是脉冲模块(string 类型)
        {
            return 类型 == "脉冲声音模块";
        }

        private bool 是输入模块(string 类型)
        {
            return 类型 == "直流电压模块（24）" || 类型 == "交流电压模块（24）" ||
                   类型 == "交直流电流模块（8）" || 类型 == "交直流电流模块（16）";
        }

        private bool 是电源模块(string 类型)
        {
            return 类型.Contains("供电模块");
        }

        private string 获取地址前缀(string 类型)
        {
            if (类型 == "输出模块" || 类型 == "继电器模块") return "DO";
            if (类型 == "直流电压模块（24）") return "VD";
            if (类型 == "交流电压模块（24）") return "VA";
            if (类型.Contains("交直流电流")) return "CD";
            if (类型 == "脉冲声音模块") return "PO";
            if (类型.Contains("供电模块")) return "PS";
            return "CH";
        }

        private int 获取模块通道数(string 类型)
        {
            return 类型 switch
            {
                "输出模块" => 16,
                "继电器模块" => 16,
                "直流电压模块（24）" => 24,
                "交流电压模块（24）" => 24,
                "交直流电流模块（8）" => 8,
                "交直流电流模块（16）" => 16,
                "脉冲声音模块" => 16,
                _ when 类型.Contains("供电模块（8）") => 8,
                _ when 类型.Contains("供电模块（16）") => 16,
                _ when 类型.Contains("输出模块（16）") => 16,
                _ when 类型.Contains("继电器模块（16）") => 16,
                _ => 0
            };
        }

        private string 获取模块类型(Panel 卡片)
        {
            if (卡片.Tag is 模块卡片信息 信息) return 信息.模块类型;
            return 卡片.Tag?.ToString() ?? "";
        }

        private int 获取从站地址(Panel 卡片)
        {
            if (卡片.Tag is 模块卡片信息 信息) return 信息.从站地址;
            return 0;
        }

        private int 获取配置索引(Panel 卡片)
        {
            if (卡片.Tag is 模块卡片信息 信息) return 信息.配置索引;
            return -1;
        }

        private bool 卡片已连接(Panel 卡片)
        {
            return 卡片.Tag is 模块卡片信息 信息 && 信息.已连接;
        }

        private void 标记卡片连接状态(Panel 卡片, bool 已连接)
        {
            if (卡片.Tag is 模块卡片信息 信息)
            {
                信息.已连接 = 已连接;
            }
        }

        private string 获取通道状态Key(Panel 卡片, string 按钮名)
        {
            return $"{获取卡片名称(卡片)}|{按钮名}";
        }

        private int 解析通道号(string 按钮名)
        {
            int idx = 按钮名.Length - 1;
            while (idx >= 0 && char.IsDigit(按钮名[idx])) idx--;
            string 数字 = 按钮名[(idx + 1)..];
            return int.TryParse(数字, out int 通道号) ? 通道号 : -1;
        }

        private void 应用输出通道状态到界面(Panel 卡片, bool[] 线圈状态)
        {
            foreach (Control c in 卡片.Controls)
            {
                if (c is not Panel 通道面板 || 通道面板.Name != "通道面板") continue;
                foreach (Control 通道控件 in 通道面板.Controls)
                {
                    if (通道控件 is not Button 按钮 || !按钮.Name.StartsWith("CH_")) continue;
                    int ch = 解析通道号(按钮.Name);
                    if (ch < 0 || ch >= 线圈状态.Length) continue;
                    bool 开 = 线圈状态[ch];
                    按钮.BackColor = 开 ? 开启色 : 关闭色;
                    string 通道名 = 按钮.Name.Substring(3);
                    按钮.Text = 开 ? $"{通道名} ON" : $"{通道名} OFF";
                    通道状态[获取通道状态Key(卡片, 按钮.Name)] = 开;
                }
            }
        }

        private void 确保Modbus串口连接()
        {
            var 参数 = 系统配置管理.实例.基础参数;
            if (string.IsNullOrWhiteSpace(参数.串口端口))
            {
                throw new InvalidOperationException("未配置串口端口");
            }

            if (modbus串口 == null)
            {
                modbus串口 = new SerialPort();
            }

            if (modbus串口.IsOpen && modbus串口.PortName == 参数.串口端口 && modbus串口.BaudRate == 参数.串口波特率)
            {
                return;
            }

            if (modbus串口.IsOpen)
            {
                modbus串口.Close();
            }

            modbus串口.PortName = 参数.串口端口;
            modbus串口.BaudRate = 参数.串口波特率;
            modbus串口.Parity = Parity.None;
            modbus串口.DataBits = 8;
            modbus串口.StopBits = StopBits.One;
            modbus串口.ReadTimeout = 1000;
            modbus串口.WriteTimeout = 1000;
            modbus串口.Open();
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
            byte[] 响应 = 发送Modbus请求(请求, 5 + 字节数);
            if (响应[1] != 0x01)
            {
                throw new InvalidOperationException("读取线圈返回功能码异常");
            }

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
            byte[] 响应 = 发送Modbus请求(请求, 5 + 数据字节数);
            if (响应[1] != 0x03)
            {
                throw new InvalidOperationException("读取保持寄存器返回功能码异常");
            }

            short[] 结果 = new short[数量];
            for (int i = 0; i < 数量; i++)
            {
                int baseIndex = 3 + i * 2;
                结果[i] = (short)((响应[baseIndex] << 8) | 响应[baseIndex + 1]);
            }

            return 结果;
        }

        private void 写入单个线圈(byte 从站地址, ushort 地址, bool 状态)
        {
            byte[] 请求 = new byte[]
            {
                从站地址, 0x05,
                (byte)(地址 >> 8), (byte)(地址 & 0xFF),
                状态 ? (byte)0xFF : (byte)0x00,
                0x00
            };

            byte[] 响应 = 发送Modbus请求(请求, 8);
            if (响应[1] != 0x05)
            {
                throw new InvalidOperationException("写单线圈返回功能码异常");
            }
        }

        private void 写入多个线圈(byte 从站地址, ushort 起始地址, bool[] 状态数组)
        {
            ushort 数量 = (ushort)状态数组.Length;
            int 字节数 = (数量 + 7) / 8;
            byte[] 数据 = new byte[字节数];
            for (int i = 0; i < 数量; i++)
            {
                if (状态数组[i])
                {
                    数据[i / 8] |= (byte)(1 << (i % 8));
                }
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

            byte[] 响应 = 发送Modbus请求(请求, 8);
            if (响应[1] != 0x0F)
            {
                throw new InvalidOperationException("写多线圈返回功能码异常");
            }
        }

        private byte[] 发送Modbus请求(byte[] pdu, int 最小响应长度)
        {
            确保Modbus串口连接();
            if (modbus串口 == null) throw new InvalidOperationException("串口未初始化");

            byte[] 帧 = 添加CRC(pdu);
            modbus串口.DiscardInBuffer();
            modbus串口.DiscardOutBuffer();
            modbus串口.Write(帧, 0, 帧.Length);

            byte[] 响应 = new byte[Math.Max(最小响应长度, 8)];
            int 已读 = 0;
            while (已读 < 最小响应长度)
            {
                int n = modbus串口.Read(响应, 已读, 响应.Length - 已读);
                已读 += n;
            }

            byte[] 有效响应 = new byte[已读];
            Array.Copy(响应, 0, 有效响应, 0, 已读);
            校验CRC(有效响应);

            if ((有效响应[1] & 0x80) != 0)
            {
                throw new InvalidOperationException($"Modbus异常码: 0x{有效响应[2]:X2}");
            }

            return 有效响应;
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
            if (响应.Length < 5)
            {
                throw new InvalidOperationException("Modbus响应长度不足");
            }

            ushort 接收crc = (ushort)((响应[^1] << 8) | 响应[^2]);
            ushort 计算crc = 计算CRC16(响应, 响应.Length - 2);
            if (接收crc != 计算crc)
            {
                throw new InvalidOperationException("Modbus CRC校验失败");
            }
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

        private string 获取卡片名称(Panel 卡片)
        {
            foreach (Control c in 卡片.Controls)
            {
                if (c is Panel 标题行)
                {
                    foreach (Control tc in 标题行.Controls)
                    {
                        if (tc.Name == "" || tc.Font.Bold) return tc.Text?.Split('[')[0].Trim() ?? "";
                    }
                }
            }
            return "";
        }

        private void SetCardStatus(Panel 卡片, Color 颜色, string 文本)
        {
            foreach (Control 标题行 in 卡片.Controls)
            {
                if (标题行 is not Panel) continue;
                foreach (Control c in 标题行.Controls)
                {
                    if (c.Name == "状态指示") c.BackColor = 颜色;
                    if (c.Name == "状态标签") c.Text = 文本;
                }
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (输入轮询定时器.Enabled) 输入轮询定时器.Stop();
            输入轮询卡片.Clear();

            if (modbus串口 != null)
            {
                if (modbus串口.IsOpen) modbus串口.Close();
                modbus串口.Dispose();
                modbus串口 = null;
            }

            base.OnFormClosed(e);
        }
    }
}
