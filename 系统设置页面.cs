using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace 自动测试
{
    public partial class 系统设置页面 : Form
    {
        private 系统配置数据 配置数据 = new 系统配置数据();
        private bool 配置已修改 = false;

        public 系统设置页面()
        {
            InitializeComponent();
            初始化所有标签页();
            加载配置数据();
        }

        private void 初始化所有标签页()
        {
            初始化运动控制页();
            初始化电压模块页();
            初始化电流模块页();
            初始化IO模块页();
            初始化PWM模块页();
            初始化其它模块页();
            初始化平台视觉页();

        }

        private void 初始化运动控制页()
        {
            var 页面 = 运动控制页;
            
            var 主运组 = 创建分组框("主运输入马达设置", 20, 20, 400, 280);
            var 主运控件 = 创建马达参数控件(配置数据.运动控制.主运一圈距离, 配置数据.运动控制.主运一圈脉冲);
            主运组.Controls.AddRange(主运控件);
            页面.Controls.Add(主运组);

            var 调宽组 = 创建分组框("调宽马达设置", 450, 20, 400, 350);
            var 调宽控件 = 创建调宽马达参数控件();
            调宽组.Controls.AddRange(调宽控件);
            页面.Controls.Add(调宽组);

            var 校正按钮 = new Button { Text = "调宽参数校正", Location = new Point(450, 380), Size = new Size(120, 30) };
            页面.Controls.Add(校正按钮);
        }

        private void 初始化电压模块页()
        {
            var 页面 = 电压模块页;
            
            var 基础组 = 创建分组框("电压模块基础设置", 20, 20, 700, 200);
            int y = 25;
            var 控件列表 = new List<Control>
            {
                创建标签("采样时间 - 普通状态：", 20, y), 创建数字框(200, 10000, 1, 150, y-3),
                创建标签("ms", 260, y), 创建标签("功能测试时：", 300, y), 创建数字框(50, 10000, 1, 400, y-3),
                创建标签("ms", 480, y), 创建标签("工作状态：", 520, y), 创建数字框(50, 10000, 1, 620, y-3), 创建标签("ms", 680, y)
            };
            y += 30;
            控件列表.AddRange(new Control[]
            {
                创建标签("输入通道数：", 20, y), 创建数字框(56, 200, 1, 120, y-3),
                创建标签("输出通道数：", 200, y), 创建数字框(48, 200, 1, 320, y-3),
                创建标签("电压通道数：", 400, y), 创建数字框(24, 200, 1, 520, y-3)
            });
            y += 30;
            控件列表.AddRange(new Control[]
            {
                创建标签("声音通道数：", 20, y), 创建数字框(16, 100, 1, 120, y-3),
                创建标签("最大拼版数：", 200, y), 创建数字框(30, 100, 1, 320, y-3),
                创建标签("电流通道数：", 400, y), 创建数字框(8, 100, 1, 520, y-3)
            });
            基础组.Controls.AddRange(控件列表.ToArray());
            页面.Controls.Add(基础组);

            var 采集组 = 创建分组框("电压采集 (NO:10)", 20, 230, 1140, 350);
            var 采集控件列表 = new List<Control>();
            for (int i = 0; i < 9; i++)
            {
                int 行Y = 25 + i * 30;
                采集控件列表.AddRange(new Control[]
                {
                    创建标签($"通道{i+1}：", 20, 行Y),
                    创建数字框(8, 100, 1, 100, 行Y-3),
                    创建标签("量程：", 180, 行Y),
                    创建文本框("0.0", 230, 行Y-3, 80),
                    创建标签("备注：", 340, 行Y),
                    创建文本框($"V{i+1}", 390, 行Y-3, 100),
                    创建标签("类型：", 520, 行Y),
                    创建数字框(0, 10, 1, 570, 行Y-3),
                    创建标签("地址：", 650, 行Y),
                    创建数字框(0, 100, 1, 700, 行Y-3)
                });
            }
            采集组.Controls.AddRange(采集控件列表.ToArray());
            页面.Controls.Add(采集组);

            var 输出组 = 创建分组框("电压输出 (NO:60)", 20, 590, 1140, 350);
            var 输出控件列表 = new List<Control>();
            for (int i = 0; i < 9; i++)
            {
                int 行Y = 25 + i * 30;
                输出控件列表.AddRange(new Control[]
                {
                    创建标签($"通道{i+1}：", 20, 行Y),
                    创建数字框(8, 100, 1, 100, 行Y-3),
                    创建标签("量程：", 180, 行Y),
                    创建文本框("0.0", 230, 行Y-3, 80),
                    创建标签("备注：", 340, 行Y),
                    创建文本框($"VO{i+1}", 390, 行Y-3, 100),
                    创建标签("类型：", 520, 行Y),
                    创建数字框(0, 10, 1, 570, 行Y-3),
                    创建标签("地址：", 650, 行Y),
                    创建数字框(0, 100, 1, 700, 行Y-3)
                });
            }
            输出组.Controls.AddRange(输出控件列表.ToArray());
            页面.Controls.Add(输出组);
        }

        private void 初始化电流模块页()
        {
            var 页面 = 电流模块页;
            
            var 采集组 = 创建分组框("电流采集 (NO:20)", 20, 20, 550, 550);
            var 采集表格 = 创建通道配置表格("电流采集", 9);
            采集组.Controls.Add(采集表格);
            页面.Controls.Add(采集组);

            var 输出组 = 创建分组框("电流输出 (NO:70)", 600, 20, 550, 550);
            var 输出表格 = 创建通道配置表格("电流输出", 9);
            输出组.Controls.Add(输出表格);
            页面.Controls.Add(输出组);
        }

        private void 初始化IO模块页()
        {
            var 页面 = IO模块页;
            
            var 输入组 = 创建分组框("IO输入 (NO:1)", 20, 20, 550, 550);
            var 输入表格 = 创建通道配置表格("IO输入", 9);
            输入组.Controls.Add(输入表格);
            页面.Controls.Add(输入组);

            var 输出组 = 创建分组框("IO输出 (NO:5)", 600, 20, 550, 550);
            var 输出表格 = 创建通道配置表格("IO输出", 9);
            输出组.Controls.Add(输出表格);
            页面.Controls.Add(输出组);
        }

        private void 初始化PWM模块页()
        {
            var 页面 = PWM模块页;
            
            var 采集组 = 创建分组框("PWM采集 (NO:40)", 20, 20, 550, 550);
            var 采集表格 = 创建PWM通道表格("PWM采集", 9);
            采集组.Controls.Add(采集表格);
            页面.Controls.Add(采集组);

            var 输出组 = 创建分组框("PWM输出 (NO:45)", 600, 20, 550, 550);
            var 输出表格 = 创建PWM通道表格("PWM输出", 9);
            输出组.Controls.Add(输出表格);
            页面.Controls.Add(输出组);
        }

        private void 初始化其它模块页()
        {
            var 页面 = 其它模块页;
            
            var 功率组 = 创建分组框("功率采集 (NO:30)", 20, 20, 550, 550);
            var 功率表格 = 创建功率通道表格(9);
            功率组.Controls.Add(功率表格);
            页面.Controls.Add(功率组);

            var 通讯组 = 创建分组框("通讯模块数", 600, 20, 300, 100);
            通讯组.Controls.AddRange(new Control[]
            {
                创建标签("串口数：", 20, 30), 创建数字框(9, 50, 1, 100, 27),
                创建标签("CAN模块数：", 20, 60), 创建数字框(1, 20, 1, 100, 57)
            });
            页面.Controls.Add(通讯组);
        }

        private void 初始化平台视觉页()
        {
            var 页面 = 平台视觉页;
            
            var X轴组 = 创建分组框("X轴马达设置", 20, 20, 300, 280);
            var X轴控件 = 创建轴马达控件("X");
            X轴组.Controls.AddRange(X轴控件);
            页面.Controls.Add(X轴组);

            var Y轴组 = 创建分组框("Y轴马达设置", 340, 20, 300, 280);
            var Y轴控件 = 创建轴马达控件("Y");
            Y轴组.Controls.AddRange(Y轴控件);
            页面.Controls.Add(Y轴组);

            var 相机组 = 创建分组框("工业相机分辨率设置", 660, 20, 500, 350);
            var 相机控件 = 创建相机设置控件();
            相机组.Controls.AddRange(相机控件);
            页面.Controls.Add(相机组);

            var 平台组 = 创建分组框("平台与工作点信息", 20, 320, 600, 120);
            平台组.Controls.AddRange(new Control[]
            {
                创建标签("平台最大宽度 X：", 20, 30), 创建数字框(170.645m, 1000, 0.001m, 150, 27), 创建标签("mm", 260, 30),
                创建标签("Y：", 300, 30), 创建数字框(160.082m, 1000, 0.001m, 350, 27), 创建标签("mm", 460, 30),
                创建标签("工作点 X：", 20, 60), 创建数字框(4.977m, 1000, 0.001m, 150, 57), 创建标签("mm", 260, 60),
                创建标签("Y：", 300, 60), 创建数字框(4.977m, 1000, 0.001m, 350, 57), 创建标签("mm", 460, 60),
                创建标签("XY运行速度：", 20, 90), 创建数字框(30, 1000, 0.1m, 150, 87), 创建标签("mm/s", 260, 90)
            });
            页面.Controls.Add(平台组);
        }


        private void 加载配置数据()
        {
        }

        private void 保存按钮_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("配置已保存", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void 取消按钮_Click(object? sender, EventArgs e)
        {
            if (配置已修改)
            {
                var 结果 = MessageBox.Show("配置已修改，是否保存？", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (结果 == DialogResult.Yes)
                {
                    保存按钮_Click(sender, e);
                }
                else if (结果 == DialogResult.No)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        #region 辅助方法
        private GroupBox 创建分组框(string 标题, int x, int y, int 宽度, int 高度)
        {
            return new GroupBox { Text = 标题, Location = new Point(x, y), Size = new Size(宽度, 高度) };
        }

        private Label 创建标签(string 文本, int x, int y)
        {
            return new Label { Text = 文本, Location = new Point(x, y), AutoSize = true };
        }

        private TextBox 创建文本框(string 默认值, int x, int y, int 宽度)
        {
            return new TextBox { Text = 默认值, Location = new Point(x, y), Size = new Size(宽度, 23) };
        }

        private NumericUpDown 创建数字框(decimal 默认值, decimal 最大值, decimal 步进, int x, int y)
        {
            var 控件 = new NumericUpDown { Maximum = 最大值, Increment = 步进, Location = new Point(x, y), Size = new Size(80, 23) };
            控件.Value = 默认值;
            return 控件;
        }

        private ComboBox 创建下拉框(string[] 选项, int x, int y, int 宽度)
        {
            var 框 = new ComboBox { Location = new Point(x, y), Size = new Size(宽度, 23), DropDownStyle = ComboBoxStyle.DropDownList };
            框.Items.AddRange(选项);
            if (选项.Length > 0) 框.SelectedIndex = 0;
            return 框;
        }

        private CheckBox 创建复选框(string 文本, int x, int y, bool 选中)
        {
            return new CheckBox { Text = 文本, Location = new Point(x, y), Checked = 选中, AutoSize = true };
        }

        private Control[] 创建马达参数控件(double 一圈距离, int 一圈脉冲)
        {
            int y = 25;
            return new Control[]
            {
                创建标签("一圈距离：", 20, y), 创建数字框((decimal)一圈距离, 10000, 0.001m, 120, y-3), 创建标签("mm", 220, y),
                创建标签("一圈脉冲：", 20, y+30), 创建数字框(一圈脉冲, 1000000, 1, 120, y+27),
                创建标签("最大脉冲：", 20, y+60), 创建数字框(100000, 10000000, 1, 120, y+57),
                创建标签("最小脉冲：", 20, y+90), 创建数字框(500, 10000, 1, 120, y+87),
                创建标签("归零脉冲：", 20, y+120), 创建数字框(20000, 1000000, 1, 120, y+117),
                创建标签("减速时间：", 20, y+150), 创建数字框(0.2m, 10, 0.01m, 120, y+147), 创建标签("s", 220, y+150),
                创建标签("计数时间：", 20, y+180), 创建数字框(0, 10000, 1, 120, y+177), 创建标签("ms", 220, y+180),
                创建标签("保留参数：", 20, y+210), 创建数字框(0m, 100, 0.01m, 120, y+207)
            };
        }

        private Control[] 创建调宽马达参数控件()
        {
            int y = 25;
            return new Control[]
            {
                创建标签("一圈距离：", 20, y), 创建数字框(16m, 1000, 0.001m, 120, y-3), 创建标签("mm", 220, y),
                创建标签("一圈脉冲数量：", 20, y+30), 创建数字框(10000, 1000000, 1, 120, y+27),
                创建标签("调宽脉冲速度：", 20, y+60), 创建数字框(15000, 100000, 1, 120, y+57),
                创建标签("最小脉冲速度：", 20, y+90), 创建数字框(500, 10000, 1, 120, y+87),
                创建标签("加减速时间：", 20, y+120), 创建数字框(0.1m, 10, 0.01m, 120, y+117), 创建标签("s", 220, y+120),
                创建标签("最小宽度：", 20, y+150), 创建数字框(48.91m, 1000, 0.01m, 120, y+147), 创建标签("mm", 220, y+150),
                创建标签("归零脉冲速度：", 20, y+180), 创建数字框(15000, 100000, 1, 120, y+177),
                创建标签("归零脱离速度：", 20, y+210), 创建数字框(4000, 100000, 1, 120, y+207),
                创建标签("归零前正移脉冲：", 20, y+240), 创建数字框(5000, 100000, 1, 120, y+237),
                创建标签("归零脱离脉冲：", 20, y+270), 创建数字框(3000, 100000, 1, 120, y+267),
                创建标签("最低运行脉冲：", 20, y+300), 创建数字框(1000, 100000, 1, 120, y+297)
            };
        }

        private Control[] 创建轴马达控件(string 轴名称)
        {
            int y = 25;
            return new Control[]
            {
                创建标签("一圈距离：", 20, y), 创建数字框(75.290m, 1000, 0.001m, 120, y-3), 创建标签("mm", 220, y),
                创建标签("一圈脉冲：", 20, y+30), 创建数字框(10000, 1000000, 1, 120, y+27),
                创建标签("运行脉冲：", 20, y+60), 创建数字框(6000, 100000, 1, 120, y+57),
                创建标签("最小脉冲：", 20, y+90), 创建数字框(500, 10000, 1, 120, y+87),
                创建标签("减速时间：", 20, y+120), 创建数字框(0.2m, 10, 0.01m, 120, y+117), 创建标签("s", 220, y+120),
                创建标签("归零脉冲：", 20, y+150), 创建数字框(3000, 100000, 1, 120, y+147),
                创建标签("归零最小脉冲：", 20, y+180), 创建数字框(500, 10000, 1, 120, y+177),
                创建标签("归零脱离脉冲：", 20, y+210), 创建数字框(2000, 100000, 1, 120, y+207),
                创建标签("归零减速时间：", 20, y+240), 创建数字框(0.2m, 10, 0.01m, 120, y+237), 创建标签("s", 220, y+240)
            };
        }

        private Control[] 创建相机设置控件()
        {
            int y = 25;
            return new Control[]
            {
                创建标签("相机类型：", 20, y), 创建下拉框(new[] { "DaHeng", "HikVision", "Other" }, 120, y-3, 100),
                创建标签("相机数量：", 250, y), 创建数字框(1, 10, 1, 350, y-3),
                创建标签("宽度：", 20, y+30), 创建数字框(2592, 10000, 1, 120, y+27), 创建标签("像素", 220, y+30),
                创建标签("高度：", 250, y+30), 创建数字框(1944, 10000, 1, 350, y+27), 创建标签("像素", 450, y+30),
                创建标签("显示宽度：", 20, y+60), 创建数字框(1150, 10000, 1, 120, y+57), 创建标签("像素", 220, y+60),
                创建标签("旋转角度：", 250, y+60), 创建数字框(0, 360, 1, 350, y+57), 创建标签("°", 450, y+60),
                创建标签("相机捕捉次数：", 20, y+90), 创建数字框(4, 100, 1, 120, y+87),
                创建标签("相机重连时间：", 250, y+90), 创建数字框(1, 10000, 1, 350, y+87), 创建标签("ms", 450, y+90),
                创建标签("相机捕捉间隔：", 20, y+120), 创建数字框(200, 10000, 1, 120, y+117), 创建标签("ms", 220, y+120),
                创建标签("相机尝试间隔：", 250, y+120), 创建数字框(1, 10000, 1, 350, y+117), 创建标签("ms", 450, y+120),
                创建标签("相机捕捉超时：", 20, y+150), 创建数字框(8, 10000, 1, 120, y+147), 创建标签("ms", 220, y+150),
                创建标签("相机网段起始：", 20, y+180), 创建文本框("0.0.0.0", 120, y+177, 150),
                创建标签("相机网段结束：", 20, y+210), 创建文本框("0.0.0.0", 120, y+207, 150),
                创建复选框("配置相机", 20, y+240, true),
                创建复选框("自动设置相机属性", 20, y+270, true)
            };
        }

        private DataGridView 创建通道配置表格(string 类型, int 行数)
        {
            var 表格 = new DataGridView { Location = new Point(20, 50), Size = new Size(500, 280), AllowUserToAddRows = false };
            表格.Columns.Add("路数", "路数");
            表格.Columns.Add("量程", "量程");
            表格.Columns.Add("备注", "备注");
            表格.Columns.Add("类型", "类型");
            表格.Columns.Add("地址", "地址");
            for (int i = 0; i < 行数; i++)
            {
                表格.Rows.Add(8, "0.0", $"{类型[0]}{i+1}", 0, 0);
            }
            return 表格;
        }

        private DataGridView 创建PWM通道表格(string 类型, int 行数)
        {
            var 表格 = new DataGridView { Location = new Point(20, 50), Size = new Size(500, 280), AllowUserToAddRows = false };
            表格.Columns.Add("模块数", "模块数");
            表格.Columns.Add("备注", "备注");
            表格.Columns.Add("类型", "类型");
            表格.Columns.Add("地址", "地址");
            for (int i = 0; i < 行数; i++)
            {
                表格.Rows.Add(1, $"{类型[0]}{i+1}", 0, 0);
            }
            return 表格;
        }

        private DataGridView 创建功率通道表格(int 行数)
        {
            var 表格 = new DataGridView { Location = new Point(20, 50), Size = new Size(500, 280), AllowUserToAddRows = false };
            表格.Columns.Add("路数", "路数");
            表格.Columns.Add("量程", "量程");
            表格.Columns.Add("备注", "备注");
            表格.Columns.Add("类型", "类型");
            表格.Columns.Add("地址", "地址");
            for (int i = 0; i < 行数; i++)
            {
                表格.Rows.Add(8, "0.0 w", $"W{i+1}", 0, 0);
            }
            return 表格;
        }
        #endregion
    }
}