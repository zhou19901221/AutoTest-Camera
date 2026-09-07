using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;

namespace 自动测试
{
    public partial class 一迈电源设置窗体 : Form
    {
        private readonly 一迈电源控制 电源 = new 一迈电源控制();
        private readonly Dictionary<string, Label> 状态值标签 = new Dictionary<string, Label>();
        private readonly System.Windows.Forms.Timer 状态刷新定时器 = new System.Windows.Forms.Timer();

        public 一迈电源设置窗体()
        {
            InitializeComponent();
            创建状态显示();
            端口框.Items.AddRange(SerialPort.GetPortNames());
            if (端口框.Items.Count > 0) 端口框.SelectedIndex = 0;
            状态刷新定时器.Interval = 1000;
            状态刷新定时器.Tick += 状态刷新定时器_Tick;
            界面缩放器.等比例适配屏幕(this);
        }

        private void 创建状态显示()
        {
            string[] 名称s =
            {
                "启动状态", "控制模式", "输出允许", "工作模式", "模拟控制", "多段运行",
                "P1输出", "P2输出", "P3输出", "P4输出", "恒功率", "从机模式",
                "内部温度", "实际电压", "实际电流", "额定电压", "额定电流", "短路",
                "欠压状态", "过压状态", "过流状态", "过温状态", "过载状态", "按键短路"
            };
            for (int i = 0; i < 名称s.Length; i++)
            {
                int 列 = i / 12;
                int 行 = i % 12;
                var 名称标签 = new Label
                {
                    Text = 名称s[i] + "：",
                    Location = new Point(20 + 列 * 280, 32 + 行 * 40),
                    AutoSize = true
                };
                var 值标签 = new Label
                {
                    Text = "----",
                    Location = new Point(130 + 列 * 280, 32 + 行 * 40),
                    AutoSize = true,
                    ForeColor = Color.DarkBlue
                };
                电源状态组.Controls.Add(名称标签);
                电源状态组.Controls.Add(值标签);
                状态值标签[名称s[i]] = 值标签;
            }
        }

        private void 连接按钮_Click(object? sender, EventArgs e)
        {
            try
            {
                if (端口框.SelectedItem == null)
                {
                    MessageBox.Show("请先选择串口端口。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                电源.连接((string)端口框.SelectedItem, int.Parse(波特率框.Text));
            }
            catch (Exception 异常)
            {
                通讯状态标签.Text = "未连接";
                通讯状态标签.ForeColor = Color.Red;
                MessageBox.Show($"串口打开失败：{异常.Message}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                读取基础参数();
            }
            catch (Exception 异常)
            {
                状态刷新定时器.Stop();
                电源.断开();
                通讯状态标签.Text = "未连接";
                通讯状态标签.ForeColor = Color.Red;
                MessageBox.Show($"已连接，但读取电源参数失败：{异常.Message}\n请检查通讯地址、波特率及接线是否正确。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            通讯状态标签.Text = "已连接";
            通讯状态标签.ForeColor = Color.Green;
            状态刷新定时器.Start();
        }

        private void 断开按钮_Click(object? sender, EventArgs e)
        {
            状态刷新定时器.Stop();
            电源.断开();
            通讯状态标签.Text = "未连接";
            通讯状态标签.ForeColor = Color.Red;
        }

        private void 状态刷新定时器_Tick(object? sender, EventArgs e)
        {
            try
            {
                ushort 字1 = 电源.读状态字1();
                ushort 字2 = 电源.读状态字2();
                float 温度 = 电源.读内部温度();
                float 电压 = 电源.读实际输出电压();
                float 电流 = 电源.读实际输出电流();
                ushort 控制字 = 电源.读保持寄存器(一迈电源控制.寄存器控制字, 1)[0];
                更新状态(字1, 字2, 温度, 电压, 电流);
                控制字标签.Text = $"控制字:0x{控制字:X4}";
                if (通讯状态标签.Text != "已连接")
                {
                    通讯状态标签.Text = "已连接";
                    通讯状态标签.ForeColor = Color.Green;
                }
            }
            catch
            {
                通讯状态标签.Text = "通讯异常";
                通讯状态标签.ForeColor = Color.Red;
            }
        }

        private void 更新状态(ushort 字1, ushort 字2, float 温度, float 电压, float 电流)
        {
            设置状态("启动状态", (字1 & 1) != 0 ? "启动" : "停止", (字1 & 1) != 0);
            设置状态("控制模式", (字1 & 2) != 0 ? "远程" : "本地", true);
            设置状态("模拟控制", (字1 & 4) != 0 ? "模拟" : "正常", true);
            设置状态("输出允许", (字1 & 16) != 0 ? "允许" : "禁止", (字1 & 16) != 0);
            设置状态("工作模式", (字1 & 32) != 0 ? "恒流" : "恒压", true);
            设置状态("多段运行", (字1 & 128) != 0 ? "多段" : "正常", true);
            设置状态("P1输出", (字2 & 1) != 0 ? "输出中" : "关闭", (字2 & 1) != 0);
            设置状态("P2输出", (字2 & 2) != 0 ? "输出中" : "关闭", (字2 & 2) != 0);
            设置状态("P3输出", (字2 & 4) != 0 ? "输出中" : "关闭", (字2 & 4) != 0);
            设置状态("P4输出", (字2 & 8) != 0 ? "输出中" : "关闭", (字2 & 8) != 0);
            设置状态("恒功率", (字2 & (1 << 11)) != 0 ? "恒功率" : "正常", true);
            设置状态("从机模式", (字2 & (1 << 9)) != 0 ? "从机" : "常规", true);
            设置状态("内部温度", $"{温度:F1} ℃", true);
            设置状态("实际电压", $"{电压:F2} V", true);
            设置状态("实际电流", $"{电流:F3} A", true);
            设置状态("短路", (字1 & 64) != 0 ? "短路!" : "正常", (字1 & 64) == 0);
            设置状态("欠压状态", (字1 & 256) != 0 ? "欠压!" : "正常", (字1 & 256) == 0);
            设置状态("过压状态", (字1 & 512) != 0 ? "过压!" : "正常", (字1 & 512) == 0);
            设置状态("过流状态", (字1 & 1024) != 0 ? "过流!" : "正常", (字1 & 1024) == 0);
            设置状态("过温状态", (字1 & 2048) != 0 ? "过温!" : "正常", (字1 & 2048) == 0);
            设置状态("过载状态", (字2 & 64) != 0 ? "过载!" : "正常", (字2 & 64) == 0);
            设置状态("按键短路", (字1 & 4096) != 0 ? "故障!" : "正常", (字1 & 4096) == 0);
        }

        private void 设置状态(string 名称, string 值, bool 正常)
        {
            if (状态值标签.TryGetValue(名称, out var 标签))
            {
                标签.Text = 值;
                标签.ForeColor = 正常 ? Color.DarkBlue : Color.Red;
            }
        }

        private void 读取基础参数()
        {
            设置状态("额定电压", $"{电源.读电源额定电压():F2} V", true);
            设置状态("额定电流", $"{电源.读电源额定电流():F3} A", true);

            电压设置框.Value = (decimal)Math.Min(电源.读输出电压设置(), (float)电压设置框.Maximum);
            电流设置框.Value = (decimal)Math.Min(电源.读输出电流设置(), (float)电流设置框.Maximum);
            过压保护框.Value = (decimal)Math.Min(电源.读过压保护(), (float)过压保护框.Maximum);
            过流保护框.Value = (decimal)Math.Min(电源.读过压保护(), (float)过流保护框.Maximum);
            默认限压框.Value = (decimal)Math.Min(电源.读默认输出限压(), (float)默认限压框.Maximum);
            默认限流框.Value = (decimal)Math.Min(电源.读默认输出限流(), (float)默认限流框.Maximum);
            PWM周期框.Value = Math.Min(电源.读PWM周期(), PWM周期框.Maximum);
            开通1框.Value = Math.Min(电源.读PWM开通1(), 开通1框.Maximum);
            开通2框.Value = Math.Min(电源.读PWM开通2(), 开通2框.Maximum);

        }

        private void 执行通讯(Action 操作, string 失败提示)
        {
            try
            {
                操作();
            }
            catch (Exception 异常)
            {
                MessageBox.Show($"{失败提示}：{异常.Message}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void 启动电源按钮_Click(object? sender, EventArgs e) => 执行通讯(() => 电源.启动电源(), "启动失败");

        private void 停止电源按钮_Click(object? sender, EventArgs e) => 执行通讯(() => 电源.停止电源(), "停止失败");

        private void 远程控制按钮_Click(object? sender, EventArgs e) => 执行通讯(() => 电源.切换远程控制(), "切换远程失败");

        private void 本地控制按钮_Click(object? sender, EventArgs e) => 执行通讯(() => 电源.切换本地控制(), "切换本地失败");

        private void 应用控制按钮_Click(object? sender, EventArgs e) => 执行通讯(() =>
        {
            电源.设置蜂鸣器(蜂鸣器勾选.Checked);
            电源.设置P1输出(P1勾选.Checked);
            电源.设置P2输出(P2勾选.Checked);
            电源.设置P3输出(P3勾选.Checked);
            电源.设置P4输出(P4勾选.Checked);
        }, "应用控制失败");

        private void 写入输出按钮_Click(object? sender, EventArgs e) => 执行通讯(() =>
        {
            电源.设置输出电压((float)电压设置框.Value);
            电源.设置输出电流((float)电流设置框.Value);
            电源.设置输出限制功率((float)功率设置框.Value);
        }, "写入输出设置失败");

        private void 写入PWM按钮_Click(object? sender, EventArgs e) => 执行通讯(() =>
        {
            电源.设置PWM周期((uint)PWM周期框.Value);
            电源.设置PWM开通1((uint)开通1框.Value);
            电源.设置PWM开通2((uint)开通2框.Value);
        }, "写入PWM失败");

        private void 读取参数按钮_Click(object? sender, EventArgs e) => 执行通讯(读取基础参数, "读取参数失败");

        private void 写入通信保护按钮_Click(object? sender, EventArgs e) => 执行通讯(() =>
        {

            电源.设置过压保护((float)过压保护框.Value);
            电源.设置过流保护((float)过流保护框.Value);
            电源.设置默认输出限压((float)默认限压框.Value);
            电源.设置默认输出限流((float)默认限流框.Value);
        }, "写入通信保护失败");

        private void 一迈电源设置窗体_FormClosing(object? sender, FormClosingEventArgs e)
        {
            状态刷新定时器.Stop();
            电源.断开();

        }
    }
}