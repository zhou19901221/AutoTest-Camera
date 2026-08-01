using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace 自动测试
{
    public partial class 电压模块控件 : UserControl
    {
        private List<ComboBox> 类型下拉框列表 = new List<ComboBox>();
        private List<ComboBox> 波特率下拉框列表 = new List<ComboBox>();
        private List<NumericUpDown> 通道数量列表 = new List<NumericUpDown>();
        private List<NumericUpDown> 继电器列表 = new List<NumericUpDown>();
        private List<TextBox> 备注列表 = new List<TextBox>();
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
            类型下拉框列表.Add(comboBox1);
            类型下拉框列表.Add(comboBox2);
            类型下拉框列表.Add(comboBox3);
            类型下拉框列表.Add(comboBox4);
            类型下拉框列表.Add(comboBox5);
            类型下拉框列表.Add(comboBox6);
            类型下拉框列表.Add(comboBox7);
            类型下拉框列表.Add(comboBox8);

            波特率下拉框列表.Add(comboBox9);
            波特率下拉框列表.Add(comboBox10);
            波特率下拉框列表.Add(comboBox11);
            波特率下拉框列表.Add(comboBox12);
            波特率下拉框列表.Add(comboBox13);
            波特率下拉框列表.Add(comboBox14);
            波特率下拉框列表.Add(comboBox15);
            波特率下拉框列表.Add(comboBox16);

            通道数量列表.Add(numericUpDown1);
            通道数量列表.Add(numericUpDown2);
            通道数量列表.Add(numericUpDown3);
            通道数量列表.Add(numericUpDown4);
            通道数量列表.Add(numericUpDown5);
            通道数量列表.Add(numericUpDown6);
            通道数量列表.Add(numericUpDown7);
            通道数量列表.Add(numericUpDown8);

            继电器列表.Add(numericUpDown17);
            继电器列表.Add(numericUpDown18);
            继电器列表.Add(numericUpDown19);

            备注列表.Add(textBox1);
            备注列表.Add(textBox2);
            备注列表.Add(textBox3);
            备注列表.Add(textBox4);
            备注列表.Add(textBox5);
            备注列表.Add(textBox6);
            备注列表.Add(textBox7);
            备注列表.Add(textBox8);
            备注列表.Add(textBox9);
            备注列表.Add(textBox10);
            备注列表.Add(textBox11);
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
                }
            }
            
            for (int i = 0; i < 通道数量列表.Count; i++)
            {
                if (i < 配置数据.电压模块.模块列表.Count)
                {
                    通道数量列表[i].Value = 配置数据.电压模块.模块列表[i].通道数量;
                }
            }
            
            for (int i = 0; i < 继电器列表.Count; i++)
            {
                if (i < 配置数据.电压模块.继电器通道数.Count)
                {
                    继电器列表[i].Value = 配置数据.电压模块.继电器通道数[i];
                }
            }
            
            for (int i = 0; i < 波特率下拉框列表.Count && i < 配置数据.电压模块.波特率列表.Count; i++)
            {
                int 索引 = 波特率下拉框列表[i].Items.IndexOf(配置数据.电压模块.波特率列表[i]);
                if (索引 >= 0) 波特率下拉框列表[i].SelectedIndex = 索引;
            }
            
            for (int i = 0; i < 备注列表.Count && i < 配置数据.电压模块.备注列表.Count; i++)
            {
                备注列表[i].Text = 配置数据.电压模块.备注列表[i];
            }
        }

        public void 保存配置()
        {
            if (配置数据 == null) return;
            
            配置数据.电压模块.模块列表.Clear();
            for (int i = 0; i < 类型下拉框列表.Count; i++)
            {
                配置数据.电压模块.模块列表.Add(new 模块通道配置
                {
                    模块类型 = 类型下拉框列表[i].SelectedItem?.ToString() ?? "输入模块",
                    通道数量 = (int)通道数量列表[i].Value
                });
            }
            
            配置数据.电压模块.继电器通道数.Clear();
            for (int i = 0; i < 继电器列表.Count; i++)
            {
                配置数据.电压模块.继电器通道数.Add((int)继电器列表[i].Value);
            }
            
            配置数据.电压模块.波特率列表.Clear();
            for (int i = 0; i < 波特率下拉框列表.Count; i++)
            {
                配置数据.电压模块.波特率列表.Add(波特率下拉框列表[i].Text);
            }
            
            配置数据.电压模块.备注列表.Clear();
            for (int i = 0; i < 备注列表.Count; i++)
            {
                配置数据.电压模块.备注列表.Add(备注列表[i].Text);
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
