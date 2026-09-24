using System;
using System.Drawing;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 自动测试
{
    public class 永鹏电源设置窗体 : Form
    {
        private readonly 永鹏电源控制 电源 = new 永鹏电源控制();
        private readonly System.Windows.Forms.Timer 刷新定时器 = new System.Windows.Forms.Timer();
        private int 刷新中 = 0;
        private CancellationTokenSource? 刷新取消源;

        private readonly ComboBox 端口框 = new ComboBox();
        private readonly ComboBox 波特率框 = new ComboBox();
        private readonly Label 通讯状态标签 = new Label();
        private readonly NumericUpDown 电压框 = new NumericUpDown();
        private readonly NumericUpDown 频率框 = new NumericUpDown();

        private readonly Label 工作状态值 = new Label();
        private readonly Label 输出电压值 = new Label();
        private readonly Label 输出频率值 = new Label();
        private readonly Label 输出电流值 = new Label();
        private readonly Label 输出功率值 = new Label();

        public 永鹏电源设置窗体()
        {
            Text = "永鹏程控电源调试";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = new Size(1936, 1048);

            初始化界面();
            初始化事件();

            端口框.Items.AddRange(SerialPort.GetPortNames());
            if (端口框.Items.Count > 0) 端口框.SelectedIndex = 0;
            波特率框.SelectedItem = "9600";

            刷新定时器.Interval = 1000;
            刷新定时器.Tick += async (_, _) => await 刷新状态();

            界面缩放器.等比例适配屏幕(this);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                刷新定时器.Stop();
                刷新定时器.Dispose();
                电源.Dispose();
            }
            base.Dispose(disposing);
        }

        private void 初始化界面()
        {
            var 通讯组 = new GroupBox
            {
                Text = "通讯连接",
                Location = new Point(15, 10),
                Size = new Size(730, 70)
            };

            var 端口标签 = new Label { Text = "端口：", Location = new Point(20, 30), AutoSize = true };
            端口框.DropDownStyle = ComboBoxStyle.DropDownList;
            端口框.Location = new Point(70, 26);
            端口框.Size = new Size(120, 25);

            var 波特率标签 = new Label { Text = "波特率：", Location = new Point(210, 30), AutoSize = true };
            波特率框.DropDownStyle = ComboBoxStyle.DropDownList;
            波特率框.Items.AddRange(new object[] { "9600", "19200", "38400", "57600", "115200" });
            波特率框.Location = new Point(270, 26);
            波特率框.Size = new Size(120, 25);

            var 连接按钮 = new Button { Text = "连接", Location = new Point(420, 24), Size = new Size(90, 30) };
            var 断开按钮 = new Button { Text = "断开", Location = new Point(525, 24), Size = new Size(90, 30) };

            通讯状态标签.Text = "未连接";
            通讯状态标签.ForeColor = Color.Red;
            通讯状态标签.Location = new Point(635, 31);
            通讯状态标签.AutoSize = true;

            通讯组.Controls.AddRange(new Control[] { 端口标签, 端口框, 波特率标签, 波特率框, 连接按钮, 断开按钮, 通讯状态标签 });
            Controls.Add(通讯组);

            var 输出设置组 = new GroupBox
            {
                Text = "输出设置",
                Location = new Point(15, 95),
                Size = new Size(730, 115)
            };

            var 电压标签 = new Label { Text = "设置电压：", Location = new Point(20, 35), AutoSize = true };
            电压框.DecimalPlaces = 1;
            电压框.Minimum = 0;
            电压框.Maximum = 300;
            电压框.Value = 220;
            电压框.Location = new Point(95, 31);
            电压框.Size = new Size(100, 25);

            var 频率标签 = new Label { Text = "设置频率：", Location = new Point(220, 35), AutoSize = true };
            频率框.DecimalPlaces = 1;
            频率框.Minimum = 0;
            频率框.Maximum = 400;
            频率框.Value = 50;
            频率框.Location = new Point(295, 31);
            频率框.Size = new Size(100, 25);

            var 应用按钮 = new Button { Text = "写入电压/频率", Location = new Point(430, 28), Size = new Size(120, 30) };
            var 启动按钮 = new Button { Text = "启动输出", Location = new Point(570, 28), Size = new Size(120, 30) };
            var 停止按钮 = new Button { Text = "停止输出", Location = new Point(570, 67), Size = new Size(120, 30) };

            var 提示标签 = new Label
            {
                Text = "说明：默认通讯参数 9600 / 8 / 1 / 无校验",
                Location = new Point(20, 75),
                AutoSize = true,
                ForeColor = Color.DimGray
            };

            输出设置组.Controls.AddRange(new Control[] { 电压标签, 电压框, 频率标签, 频率框, 应用按钮, 启动按钮, 停止按钮, 提示标签 });
            Controls.Add(输出设置组);

            var 状态组 = new GroupBox
            {
                Text = "实时状态",
                Location = new Point(15, 225),
                Size = new Size(730, 220)
            };

            创建状态行(状态组, "工作状态：", 工作状态值, 20);
            创建状态行(状态组, "输出电压：", 输出电压值, 55);
            创建状态行(状态组, "输出频率：", 输出频率值, 90);
            创建状态行(状态组, "输出电流：", 输出电流值, 125);
            创建状态行(状态组, "输出功率：", 输出功率值, 160);
            Controls.Add(状态组);

            连接按钮.Click += (_, _) => 连接电源();
            断开按钮.Click += (_, _) => 断开电源();
            应用按钮.Click += (_, _) => 写入输出参数();
            启动按钮.Click += (_, _) => 启动输出();
            停止按钮.Click += (_, _) => 停止输出();
        }

        private void 初始化事件()
        {
            FormClosed += (_, _) =>
            {
                刷新定时器.Stop();
                刷新取消源?.Cancel();
                电源.断开();
            };
        }

        private static void 创建状态行(Control 容器, string 名称, Label 值控件, int top)
        {
            var 名称标签 = new Label { Text = 名称, Location = new Point(20, top), AutoSize = true };
            值控件.Text = "----";
            值控件.Location = new Point(110, top);
            值控件.AutoSize = true;
            值控件.ForeColor = Color.DarkBlue;
            容器.Controls.Add(名称标签);
            容器.Controls.Add(值控件);
        }

        private void 连接电源()
        {
            try
            {
                if (端口框.SelectedItem == null)
                {
                    MessageBox.Show("请先选择串口端口。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                电源.连接((string)端口框.SelectedItem, int.Parse(波特率框.Text));
                通讯状态标签.Text = "已连接";
                通讯状态标签.ForeColor = Color.Green;
                刷新取消源?.Cancel();
                刷新取消源?.Dispose();
                刷新取消源 = new CancellationTokenSource();
                _ = 刷新状态();
                刷新定时器.Start();
            }
            catch (Exception ex)
            {
                通讯状态标签.Text = "未连接";
                通讯状态标签.ForeColor = Color.Red;
                MessageBox.Show($"连接失败：{ex.Message}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void 断开电源()
        {
            刷新定时器.Stop();
            电源.断开();
            通讯状态标签.Text = "未连接";
            通讯状态标签.ForeColor = Color.Red;
        }

        private void 写入输出参数()
        {
            try
            {
                if (!电源.已连接)
                {
                    MessageBox.Show("请先连接电源。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                电源.设置电压((float)电压框.Value);
                电源.设置频率((float)频率框.Value);
                _ = 刷新状态();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"写入失败：{ex.Message}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void 启动输出()
        {
            try
            {
                if (!电源.已连接)
                {
                    MessageBox.Show("请先连接电源。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                电源.设置电压((float)电压框.Value);
                电源.设置频率((float)频率框.Value);
                电源.启动电源();
                _ = 刷新状态();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"启动失败：{ex.Message}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void 停止输出()
        {
            try
            {
                if (!电源.已连接)
                {
                    MessageBox.Show("请先连接电源。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                电源.停止电源();
                _ = 刷新状态();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"停止失败：{ex.Message}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async Task 刷新状态()
        {
            if (!电源.已连接) return;

            try
            {
                ushort 工作状态 = 0;
                float 输出电压 = 0;
                float 输出频率 = 0;
                float 输出电流 = 0;
                float 输出功率 = 0;

                await Task.Run(() =>
                {
                    工作状态 = 电源.读工作状态();
                    输出电压 = 电源.读输出电压();
                    输出频率 = 电源.读输出频率();
                    输出电流 = 电源.读输出电流();
                    输出功率 = 电源.读输出有功功率();
                });

                工作状态值.Text = 工作状态 == 1 ? "高档" : "低档/停止";
                输出电压值.Text = $"{输出电压:F1} V";
                输出频率值.Text = $"{输出频率:F1} Hz";
                输出电流值.Text = $"{输出电流:F3} A";
                输出功率值.Text = $"{输出功率:F1} W";

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
    }
}
