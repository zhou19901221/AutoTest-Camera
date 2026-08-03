using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace 自动测试
{
    public partial class 电压模块控件 : UserControl
    {
        private List<ComboBox> 类型下拉框列表 = new List<ComboBox>();
        private List<ComboBox> 电源类型框列表 = new List<ComboBox>();
        private List<ComboBox> 单位下拉框列表 = new List<ComboBox>();
        private List<NumericUpDown> 量程框列表 = new List<NumericUpDown>();
        private List<TextBox> 功能板备注列表 = new List<TextBox>();
        private List<TextBox> 电源备注列表 = new List<TextBox>();
        private 系统配置数据 配置数据;

        public 电压模块控件()
        {
            InitializeComponent();
            初始化控件列表();
        }

        public void 设置配置数据(系统配置数据 数据)
        {
            配置数据 = 数据;
            加载配置();
        }

        private void 初始化控件列表()
        {
            类型下拉框列表.Add(功能板1类型框);
            类型下拉框列表.Add(功能板2类型框);
            类型下拉框列表.Add(功能板3类型框);
            类型下拉框列表.Add(功能板4类型框);
            类型下拉框列表.Add(功能板5类型框);
            类型下拉框列表.Add(功能板6类型框);
            类型下拉框列表.Add(功能板7类型框);
            类型下拉框列表.Add(功能板8类型框);

            电源类型框列表.Add(电源1类型框);
            电源类型框列表.Add(电源2类型框);
            电源类型框列表.Add(电源3类型框);

            单位下拉框列表.Add(功能板1单位框);
            单位下拉框列表.Add(功能板2单位框);
            单位下拉框列表.Add(功能板3单位框);
            单位下拉框列表.Add(功能板4单位框);
            单位下拉框列表.Add(功能板5单位框);
            单位下拉框列表.Add(功能板6单位框);
            单位下拉框列表.Add(功能板7单位框);
            单位下拉框列表.Add(功能板8单位框);

            量程框列表.Add(功能板1量程框);
            量程框列表.Add(功能板2量程框);
            量程框列表.Add(功能板3量程框);
            量程框列表.Add(功能板4量程框);
            量程框列表.Add(功能板5量程框);
            量程框列表.Add(功能板6量程框);
            量程框列表.Add(功能板7量程框);
            量程框列表.Add(功能板8量程框);

            功能板备注列表.Add(功能板1备注框);
            功能板备注列表.Add(功能板2备注框);
            功能板备注列表.Add(功能板3备注框);
            功能板备注列表.Add(功能板4备注框);
            功能板备注列表.Add(功能板5备注框);
            功能板备注列表.Add(功能板6备注框);
            功能板备注列表.Add(功能板7备注框);
            功能板备注列表.Add(功能板8备注框);

            电源备注列表.Add(继电器1备注框);
            电源备注列表.Add(继电器2备注框);
            电源备注列表.Add(继电器3备注框);
        }

        public void 加载配置()
        {
            if (配置数据 == null) return;

            for (int i = 0; i < 类型下拉框列表.Count; i++)
            {
                if (i < 配置数据.电压模块.模块列表.Count)
                {
                    int 索引 = 类型下拉框列表[i].Items.IndexOf(配置数据.电压模块.模块列表[i].模块类型);
                    if (索引 >= 0) 类型下拉框列表[i].SelectedIndex = 索引;

                    if (i < 配置数据.电压模块.备注列表.Count)
                        功能板备注列表[i].Text = 配置数据.电压模块.备注列表[i];
                }
            }

            for (int i = 0; i < 电源类型框列表.Count; i++)
            {
                int 电源偏移 = 类型下拉框列表.Count + i;
                if (电源偏移 < 配置数据.电压模块.模块列表.Count)
                {
                    int 索引 = 电源类型框列表[i].Items.IndexOf(配置数据.电压模块.模块列表[电源偏移].模块类型);
                    if (索引 >= 0) 电源类型框列表[i].SelectedIndex = 索引;

                    if (电源偏移 < 配置数据.电压模块.备注列表.Count)
                        电源备注列表[i].Text = 配置数据.电压模块.备注列表[电源偏移];
                }
            }
        }

        public void 保存配置()
        {
            if (配置数据 == null) return;

            配置数据.电压模块.模块列表.Clear();
            配置数据.电压模块.备注列表.Clear();

            for (int i = 0; i < 类型下拉框列表.Count; i++)
            {
                配置数据.电压模块.模块列表.Add(new 模块通道配置
                {
                    模块类型 = 类型下拉框列表[i].SelectedItem?.ToString() ?? "无",
                    通道数量 = 0
                });
                配置数据.电压模块.备注列表.Add(功能板备注列表[i].Text);
            }

            for (int i = 0; i < 电源类型框列表.Count; i++)
            {
                配置数据.电压模块.模块列表.Add(new 模块通道配置
                {
                    模块类型 = 电源类型框列表[i].SelectedItem?.ToString() ?? "无",
                    通道数量 = 0
                });
                配置数据.电压模块.备注列表.Add(电源备注列表[i].Text);
            }
        }

        private void 采集组_Enter(object sender, EventArgs e)
        {
        }

        private void 电压模块控件_Load(object sender, EventArgs e)
        {
            加载配置();
        }
    }
}