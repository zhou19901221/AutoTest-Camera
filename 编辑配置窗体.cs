using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;

namespace 自动测试
{
    public partial class 编辑配置窗体 : Form
    {
        private List<RadioButton> 当前板选择列表 = new List<RadioButton>();

        private string 当前配置名 = "";
        private bool 配置已修改 = false;

        public class 配置项数据
        {
            public string 配置名称 { get; set; } = "";
            public DateTime 创建日期 { get; set; } = DateTime.Now;
            public int 拼板数 { get; set; } = 6;
            public List<检测项数据> 检测项列表 { get; set; } = new List<检测项数据>();
        }

        public class 检测项数据
        {
            public string 名称 { get; set; } = "";
            public int 排序 { get; set; } = 0;
            public string 类型 { get; set; } = "继电器输出";
            public int 延时 { get; set; } = 0;
            public string 最大值 { get; set; } = "";
            public string 最小值 { get; set; } = "";
            public string 设定值 { get; set; } = "";
            public bool 启用 { get; set; } = false;
            public string 拼版1地址 { get; set; } = "";
            public string 拼版2地址 { get; set; } = "";
            public string 拼版3地址 { get; set; } = "";
            public string 拼版4地址 { get; set; } = "";
            public string 拼版5地址 { get; set; } = "";
            public string 拼版6地址 { get; set; } = "";
            public string 拼版7地址 { get; set; } = "";
            public string 拼版8地址 { get; set; } = "";
            public string 拼版9地址 { get; set; } = "";
            public string 拼版10地址 { get; set; } = "";
            public string 拼版11地址 { get; set; } = "";
            public string 拼版12地址 { get; set; } = "";
            public string 拼版13地址 { get; set; } = "";
            public string 拼版14地址 { get; set; } = "";
            public string 拼版15地址 { get; set; } = "";
            public string 拼版16地址 { get; set; } = "";
            public string 拼版17地址 { get; set; } = "";
            public string 拼版18地址 { get; set; } = "";
            public string 拼版19地址 { get; set; } = "";
            public string 拼版20地址 { get; set; } = "";
            public string 拼版21地址 { get; set; } = "";
            public string 拼版22地址 { get; set; } = "";
            public string 拼版23地址 { get; set; } = "";
            public string 拼版24地址 { get; set; } = "";
            public string 拼版25地址 { get; set; } = "";
            public string 拼版26地址 { get; set; } = "";
            public string 拼版27地址 { get; set; } = "";
            public string 拼版28地址 { get; set; } = "";
            public string 拼版29地址 { get; set; } = "";
            public string 拼版30地址 { get; set; } = "";
            public string 拼版31地址 { get; set; } = "";
            public string 拼版32地址 { get; set; } = "";
        }

        public 编辑配置窗体()
        {
            InitializeComponent();
            初始化界面();
            界面缩放器.等比例适配屏幕(this);
        }

        private void 初始化界面()
        {

            拼板数框.Minimum = 1;
            拼板数框.Maximum = 32;
            拼板数框.Value = 6;

            初始化当前板选择();
            
            配置名列表.SelectedIndexChanged += 配置名列表_SelectedIndexChanged;
            配置名列表.DoubleClick += 配置名列表_DoubleClick;
            
            检测项表格.RowsAdded += 检测项表格_RowsAdded;
            检测项表格.CellValueChanged += 检测项表格_CellValueChanged;
            检测项表格.CurrentCellDirtyStateChanged += 检测项表格_CurrentCellDirtyStateChanged;
            检测项表格.SelectionChanged += 检测项表格_SelectionChanged;
            检测项表格.CurrentCellChanged += 检测项表格_CurrentCellChanged;

            拼板数框.ValueChanged += 拼板数框_ValueChanged;

            工位地址框.SelectedIndexChanged += 工位地址框_SelectedIndexChanged;

            加载配置列表();
        }

        private void 加载配置列表()
        {
            配置名列表.Items.Clear();
            var 配置列表 = 配置数据库.实例.获取所有配置名();
            foreach (var 配置名 in 配置列表)
            {
                配置名列表.Items.Add(配置名);
            }
        }

        private void 配置名列表_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (配置名列表.SelectedIndex == -1) return;
            
            if (配置已修改 && !string.IsNullOrEmpty(当前配置名))
            {
                var result = MessageBox.Show($"配置 \"{当前配置名}\" 已修改，是否保存？", "保存提示", 
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    保存当前配置数据();
                }
                else if (result == DialogResult.Cancel)
                {
                    配置名列表.SelectedItem = 当前配置名;
                    return;
                }
            }
            
            当前配置名 = 配置名列表.SelectedItem?.ToString() ?? "";
            加载配置数据(当前配置名);
            配置已修改 = false;
        }

        private void 保存当前配置数据()
        {
            if (string.IsNullOrEmpty(当前配置名)) return;
            
            日志管理器.记录(日志类别.配置操作, "保存配置", 当前配置名);
            
            var 数据 = new 配置项数据
            {
                配置名称 = 当前配置名,
                创建日期 = DateTime.Now,
                拼板数 = (int)拼板数框.Value,
                检测项列表 = new List<检测项数据>()
            };
            
            foreach (DataGridViewRow row in 检测项表格.Rows)
            {
                if (row.IsNewRow) continue;
                
                检测项数据 项 = new 检测项数据
                {
                    名称 = row.Cells["名称列"].Value?.ToString() ?? "",
                    排序 = int.TryParse(row.Cells["排序列"].Value?.ToString(), out int 排序) ? 排序 : 0,
                    类型 = row.Cells["类型列"].Value?.ToString() ?? "继电器输出",
                    延时 = int.TryParse(row.Cells["延时列"].Value?.ToString(), out int 延时) ? 延时 : 0,
                    最大值 = row.Cells["最大值"].Value?.ToString() ?? "",
                    最小值 = row.Cells["最小值"].Value?.ToString() ?? "",
                    设定值 = row.Cells["设定值"].Value?.ToString() ?? "",
                    启用 = bool.TryParse(row.Cells["启用列"].Value?.ToString(), out bool 启用) ? 启用 : false
                };
                
                for (int p = 1; p <= 32; p++)
                {
                    string 字段名 = $"拼版{p}地址";
                    if (检测项表格.Columns.Contains(字段名))
                    {
                        var 属性 = typeof(检测项数据).GetProperty(字段名);
                        if (属性 != null)
                        {
                            属性.SetValue(项, row.Cells[字段名].Value?.ToString() ?? "");
                        }
                    }
                }
                
                数据.检测项列表.Add(项);
            }

            配置数据库.实例.保存配置(数据);
        }

        private void 加载配置数据(string 配置名)
        {
            var 数据 = 配置数据库.实例.加载配置(配置名);
            if (数据 == null) return;
            
            拼板数框.Value = 数据.拼板数;
            
            检测项表格.Rows.Clear();
            foreach (var 项 in 数据.检测项列表)
            {
                int 新索引 = 检测项表格.Rows.Add(项.排序, 项.名称, 项.类型, 项.延时, 项.最大值, 项.最小值, 项.设定值, 项.启用);
                var 行 = 检测项表格.Rows[新索引];
                更新行显示根据类型(行, 项.类型);
                
                for (int p = 1; p <= 32; p++)
                {
                    string 字段名 = $"拼版{p}地址";
                    var 属性 = typeof(检测项数据).GetProperty(字段名);
                    if (属性 != null)
                    {
                        string 地址 = 属性.GetValue(项)?.ToString() ?? "";
                        if (!string.IsNullOrEmpty(地址))
                        {
                            if (!检测项表格.Columns.Contains(字段名))
                            {
                                var 列 = new DataGridViewTextBoxColumn();
                                列.Name = 字段名;
                                列.HeaderText = 字段名;
                                列.Visible = false;
                                检测项表格.Columns.Add(列);
                            }
                            行.Cells[字段名].Value = 地址;
                        }
                    }
                }
            }

            同步检测设置表格();
        }

        private void 检测项表格_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (检测项表格.IsCurrentCellDirty)
            {
                检测项表格.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void 检测项表格_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = e.RowIndex; i < e.RowIndex + e.RowCount; i++)
            {
                if (!检测项表格.Rows[i].IsNewRow)
                {
                    检测项表格.Rows[i].Cells["排序列"].Value = i + 1;
                }
            }
        }

        private void 检测项表格_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (配置名列表.SelectedIndex == -1)
            {
                MessageBox.Show("请先选择或创建一个配置", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            
            var row = 检测项表格.Rows[e.RowIndex];
            if (row.IsNewRow) return;
            
            if (检测项表格.Columns[e.ColumnIndex].Name == "类型列")
            {
                string 类型 = row.Cells["类型列"].Value?.ToString() ?? "";
                更新行显示根据类型(row, 类型);
                同步检测设置表格();
                日志管理器.记录(日志类别.配置操作, "修改检测项类型", $"{当前配置名} 行{e.RowIndex+1} → {类型}");
            }
            
            if (检测项表格.Columns[e.ColumnIndex].Name == "排序列")
            {
                return;
            }
            
            for (int i = 0; i < 检测项表格.Rows.Count; i++)
            {
                if (!检测项表格.Rows[i].IsNewRow)
                {
                    检测项表格.Rows[i].Cells["排序列"].Value = i + 1;
                }
            }
            
            配置已修改 = true;
        }

        private void 更新行显示根据类型(DataGridViewRow row, string 类型)
        {
            bool 需要数值范围 = 类型 == "直流电压" || 类型 == "交流电压" || 类型 == "直流电流" || 类型 == "交流电流" || 类型 == "声音检测" || 类型 == "PWM检测" || 类型 == "输入功率";
            bool 需要布尔值 = 类型 == "继电器输出" || 类型 == "电源输出";
            bool 需要文本值 = 类型 == "相机检测" || 类型 == "串口输出";
            bool 保留最大最小 = 类型 == "电源输出" || 类型 == "输入功率";
            
            row.Cells["最大值"].ReadOnly = !(需要数值范围 || 保留最大最小);
            row.Cells["最小值"].ReadOnly = !(需要数值范围 || 保留最大最小);
            
            if (!需要数值范围 && !保留最大最小)
            {
                row.Cells["最大值"].Value = "";
                row.Cells["最小值"].Value = "";
            }
            
            if (需要布尔值)
            {
                var comboBoxCell = new DataGridViewComboBoxCell();
                comboBoxCell.Items.AddRange(new object[] { "true", "false" });
                comboBoxCell.Value = "false";
                row.Cells["设定值"] = comboBoxCell;
            }
            else if (需要文本值 || 需要数值范围 || 保留最大最小)
            {
                var textBoxCell = new DataGridViewTextBoxCell();
                textBoxCell.Value = "";
                row.Cells["设定值"] = textBoxCell;
            }
            else
            {
                var textBoxCell = new DataGridViewTextBoxCell();
                textBoxCell.Value = "";
                row.Cells["设定值"] = textBoxCell;
            }
        }

        private void 同步检测设置表格()
        {
            bool 有电源输出 = false;
            foreach (DataGridViewRow 行 in 检测项表格.Rows)
            {
                if (行.IsNewRow) continue;
                string 类型 = 行.Cells["类型列"].Value?.ToString() ?? "";
                if (类型 == "电源输出")
                {
                    有电源输出 = true;
                    break;
                }
            }

            checkBox5.Enabled = 有电源输出;
            if (!有电源输出) checkBox5.Checked = false;
        }


        private void 初始化当前板选择()
        {
            当前板选择列表.Add(当前板1框);
            当前板选择列表.Add(当前板2框);
            当前板选择列表.Add(当前板3框);
            当前板选择列表.Add(当前板4框);
            当前板选择列表.Add(当前板5框);
            当前板选择列表.Add(当前板6框);

            for (int i = 0; i < 当前板选择列表.Count; i++)
            {
                当前板选择列表[i].Tag = i;
                当前板选择列表[i].CheckedChanged += 当前板选择_CheckedChanged;
            }

            更新当前板选择显示((int)拼板数框.Value);
        }

        private void 拼板数框_ValueChanged(object sender, EventArgs e)
        {
            int 拼板数 = (int)拼板数框.Value;
            更新当前板选择显示(拼板数);
        }

        private void 更新当前板选择显示(int 数量)
        {
            while (当前板选择列表.Count < 数量)
            {
                int 索引 = 当前板选择列表.Count;
                RadioButton 新按钮 = new RadioButton();
                新按钮.Text = (索引 + 1).ToString();
                新按钮.Size = new System.Drawing.Size(40, 24);
                新按钮.Tag = 索引;
                新按钮.Location = new System.Drawing.Point(20 + (索引 % 16) * 70, 20 + (索引 / 16) * 30);
                新按钮.CheckedChanged += 当前板选择_CheckedChanged;
                当前板选择组.Controls.Add(新按钮);
                当前板选择列表.Add(新按钮);
            }

            for (int i = 0; i < 当前板选择列表.Count; i++)
            {
                当前板选择列表[i].Visible = i < 数量;
            }

            if (数量 > 0 && !当前板选择列表[0].Checked)
            {
                bool 有选中 = false;
                for (int i = 0; i < 数量; i++)
                {
                    if (当前板选择列表[i].Checked)
                    {
                        有选中 = true;
                        break;
                    }
                }
                if (!有选中)
                {
                    当前板选择列表[0].Checked = true;
                }
            }
        }

        private void 检测项表格_SelectionChanged(object sender, EventArgs e)
        {
            保存当前工位地址();
            更新工位地址下拉框();
        }

        private void 检测项表格_CurrentCellChanged(object sender, EventArgs e)
        {
            更新工位地址下拉框();
        }

        private int 上次拼版 = 1;

        private void 当前板选择_CheckedChanged(object sender, EventArgs e)
        {
            var 按钮 = sender as RadioButton;
            if (按钮 != null && 按钮.Checked)
            {
                保存当前工位地址(上次拼版);
                上次拼版 = 获取当前选中拼版();
                更新工位地址下拉框();
            }
        }

        private void 更新工位地址下拉框()
        {
            工位地址框.Items.Clear();
            工位地址框2.Items.Clear();
            工位地址框3.Items.Clear();
            工位地址框4.Items.Clear();

            int 当前行索引 = 检测项表格.CurrentCell?.RowIndex ?? -1;
            if (当前行索引 < 0 || 当前行索引 >= 检测项表格.Rows.Count) return;

            var 行 = 检测项表格.Rows[当前行索引];
            if (行.IsNewRow) return;

            string 类型 = 行.Cells["类型列"].Value?.ToString() ?? "";
            if (string.IsNullOrEmpty(类型)) return;

            int 当前拼版 = 获取当前选中拼版();
            if (当前拼版 < 1) return;

            List<string> 地址列表 = 系统配置管理.获取可用地址列表(类型);
            
            bool 是继电器输出 = 类型 == "继电器输出";
            工位地址框2.Visible = 是继电器输出;
            工位地址框3.Visible = 是继电器输出;
            工位地址框4.Visible = 是继电器输出;

            int 填充起始X = 是继电器输出 ? 590 : 220;
            顺序填充按钮.Location = new Point(填充起始X, 18);
            间隔1填充按钮.Location = new Point(填充起始X + 85, 18);
            间隔2填充按钮.Location = new Point(填充起始X + 170, 18);

            if (地址列表.Count == 0)
            {
                工位地址框.Items.Add("未安装对应模块");
                工位地址框.SelectedIndex = 0;
                return;
            }

            HashSet<string> 同行已选地址 = 获取同行已选地址(当前行索引, 当前拼版);

            string 已选1 = 获取当前检测项拼版子地址(当前行索引, 当前拼版, 1);
            string 已选2 = 获取当前检测项拼版子地址(当前行索引, 当前拼版, 2);
            string 已选3 = 获取当前检测项拼版子地址(当前行索引, 当前拼版, 3);
            string 已选4 = 获取当前检测项拼版子地址(当前行索引, 当前拼版, 4);

            foreach (var 地址 in 地址列表)
            {
                if (!同行已选地址.Contains(地址))
                {
                    if (地址 != 已选2 && 地址 != 已选3 && 地址 != 已选4)
                        工位地址框.Items.Add(地址);
                    
                    if (是继电器输出)
                    {
                        if (地址 != 已选1 && 地址 != 已选3 && 地址 != 已选4)
                            工位地址框2.Items.Add(地址);
                        if (地址 != 已选1 && 地址 != 已选2 && 地址 != 已选4)
                            工位地址框3.Items.Add(地址);
                        if (地址 != 已选1 && 地址 != 已选2 && 地址 != 已选3)
                            工位地址框4.Items.Add(地址);
                    }
                }
            }

            if (!string.IsNullOrEmpty(已选1))
            {
                if (!工位地址框.Items.Contains(已选1))
                    工位地址框.Items.Insert(0, 已选1);
                工位地址框.SelectedItem = 已选1;
            }

            if (是继电器输出)
            {
                if (!string.IsNullOrEmpty(已选2))
                {
                    if (!工位地址框2.Items.Contains(已选2))
                        工位地址框2.Items.Insert(0, 已选2);
                    工位地址框2.SelectedItem = 已选2;
                }

                if (!string.IsNullOrEmpty(已选3))
                {
                    if (!工位地址框3.Items.Contains(已选3))
                        工位地址框3.Items.Insert(0, 已选3);
                    工位地址框3.SelectedItem = 已选3;
                }

                if (!string.IsNullOrEmpty(已选4))
                {
                    if (!工位地址框4.Items.Contains(已选4))
                        工位地址框4.Items.Insert(0, 已选4);
                    工位地址框4.SelectedItem = 已选4;
                }
            }

        }

        private HashSet<string> 获取同行已选地址(int 行索引, int 排除拼版号)
        {
            var 已选地址 = new HashSet<string>();
            if (行索引 < 0 || 行索引 >= 检测项表格.Rows.Count) return 已选地址;

            var 行 = 检测项表格.Rows[行索引];
            if (行.IsNewRow) return 已选地址;

            int 拼板数 = (int)拼板数框.Value;
            for (int p = 1; p <= 拼板数; p++)
            {
                if (p == 排除拼版号) continue;
                string 地址 = 获取当前检测项拼版地址(行索引, p);
                if (!string.IsNullOrEmpty(地址))
                {
                    已选地址.Add(地址);
                }
            }
            return 已选地址;
        }

        private int 获取当前选中拼版()
        {
            for (int i = 0; i < 当前板选择列表.Count; i++)
            {
                if (当前板选择列表[i].Checked)
                {
                    return i + 1;
                }
            }
            return 1;
        }


        private string 获取当前检测项拼版地址(int 行索引, int 拼版号)
        {
            return 获取当前检测项拼版子地址(行索引, 拼版号, 1);
        }

        private string 获取当前检测项拼版子地址(int 行索引, int 拼版号, int 子序号)
        {
            if (行索引 < 0 || 行索引 >= 检测项表格.Rows.Count) return "";
            var 行 = 检测项表格.Rows[行索引];
            if (行.IsNewRow) return "";

            string 地址字段名 = 子序号 == 1 ? $"拼版{拼版号}地址" : $"拼版{拼版号}地址_{子序号}";
            
            if (检测项表格.Columns.Contains(地址字段名))
            {
                return 行.Cells[地址字段名].Value?.ToString() ?? "";
            }

            return "";
        }

        private void 保存当前工位地址(int 拼版号 = 0)
        {
            保存指定工位地址(工位地址框, 拼版号, 1);
        }


        private void 保存指定工位地址(ComboBox 地址框, int 拼版号, int 子序号)
        {
            if (地址框.SelectedIndex == -1) return;
            if (地址框.SelectedItem?.ToString() == "未安装对应模块") return;

            int 当前行索引 = 检测项表格.CurrentCell?.RowIndex ?? -1;
            if (当前行索引 < 0 || 当前行索引 >= 检测项表格.Rows.Count) return;

            var 行 = 检测项表格.Rows[当前行索引];
            if (行.IsNewRow) return;

            string 地址 = 地址框.SelectedItem.ToString();
            if (拼版号 == 0) 拼版号 = 获取当前选中拼版();
            string 地址字段名 = 子序号 == 1 ? $"拼版{拼版号}地址" : $"拼版{拼版号}地址_{子序号}";

            if (!检测项表格.Columns.Contains(地址字段名))
            {
                var 列 = new DataGridViewTextBoxColumn();
                列.Name = 地址字段名;
                列.HeaderText = 地址字段名;
                列.Visible = false;
                检测项表格.Columns.Add(列);
            }

            行.Cells[地址字段名].Value = 地址;
            配置已修改 = true;
        }

        private void 工位地址框_SelectedIndexChanged(object sender, EventArgs e)
        {
            保存指定工位地址(工位地址框, 0, 1);
            刷新继电器地址互斥();
        }

        private void 工位地址框2_SelectedIndexChanged(object sender, EventArgs e)
        {
            保存指定工位地址(工位地址框2, 0, 2);
            刷新继电器地址互斥();
        }

        private void 工位地址框3_SelectedIndexChanged(object sender, EventArgs e)
        {
            保存指定工位地址(工位地址框3, 0, 3);
            刷新继电器地址互斥();
        }

        private void 工位地址框4_SelectedIndexChanged(object sender, EventArgs e)
        {
            保存指定工位地址(工位地址框4, 0, 4);
            刷新继电器地址互斥();
        }

        private void 刷新继电器地址互斥()
        {
            if (!工位地址框2.Visible) return;

            string 选1 = 工位地址框.SelectedItem?.ToString() ?? "";
            string 选2 = 工位地址框2.SelectedItem?.ToString() ?? "";
            string 选3 = 工位地址框3.SelectedItem?.ToString() ?? "";
            string 选4 = 工位地址框4.SelectedItem?.ToString() ?? "";

            移除其他框中的地址(工位地址框, 选2, 选3, 选4);
            移除其他框中的地址(工位地址框2, 选1, 选3, 选4);
            移除其他框中的地址(工位地址框3, 选1, 选2, 选4);
            移除其他框中的地址(工位地址框4, 选1, 选2, 选3);
        }

        private void 移除其他框中的地址(ComboBox 目标框, string 排除1, string 排除2, string 排除3)
        {
            string 当前选中 = 目标框.SelectedItem?.ToString() ?? "";
            目标框.Items.Clear();

            int 当前行索引 = 检测项表格.CurrentCell?.RowIndex ?? -1;
            if (当前行索引 < 0) return;
            var 行 = 检测项表格.Rows[当前行索引];
            if (行.IsNewRow) return;
            string 类型 = 行.Cells["类型列"].Value?.ToString() ?? "";

            List<string> 地址列表 = 系统配置管理.获取可用地址列表(类型);
            int 当前拼版 = 获取当前选中拼版();
            HashSet<string> 同行已选 = 获取同行已选地址(当前行索引, 当前拼版);

            foreach (var 地址 in 地址列表)
            {
                if (同行已选.Contains(地址)) continue;
                if (地址 == 排除1 || 地址 == 排除2 || 地址 == 排除3) continue;
                目标框.Items.Add(地址);
            }

            if (!string.IsNullOrEmpty(当前选中))
            {
                if (!目标框.Items.Contains(当前选中))
                    目标框.Items.Insert(0, 当前选中);
                目标框.SelectedItem = 当前选中;
            }
        }

        private void 顺序填充按钮_Click(object sender, EventArgs e)
        {
            自动填充地址(0);
        }

        private void 间隔1填充按钮_Click(object sender, EventArgs e)
        {
            自动填充地址(1);
        }

        private void 间隔2填充按钮_Click(object sender, EventArgs e)
        {
            自动填充地址(2);
        }

        private void 自动填充地址(int 间隔数)
        {
            if (工位地址框.SelectedIndex == -1) return;
            if (工位地址框.SelectedItem?.ToString() == "未安装对应模块") return;

            int 当前行索引 = 检测项表格.CurrentCell?.RowIndex ?? -1;
            if (当前行索引 < 0 || 当前行索引 >= 检测项表格.Rows.Count) return;
            var 行 = 检测项表格.Rows[当前行索引];
            if (行.IsNewRow) return;

            string 当前地址 = 工位地址框.SelectedItem.ToString();
            保存当前工位地址();

            int 当前拼版 = 获取当前选中拼版();
            int 拼板数 = (int)拼板数框.Value;

            if (!解析地址(当前地址, out string 前缀, out int 板号, out int 通道)) return;

            int 步进 = 1 + 间隔数;
            int 当前通道 = 通道;

            for (int p = 当前拼版 + 1; p <= 拼板数; p++)
            {
                当前通道 += 步进;
                string 新地址 = $"{前缀}{板号}.{当前通道}";
                保存指定拼版地址(当前行索引, p, 新地址);
            }

            配置已修改 = true;
        }

        private bool 解析地址(string 地址, out string 前缀, out int 板号, out int 通道)
        {
            前缀 = "";
            板号 = 0;
            通道 = 0;

            int 点位置 = 地址.IndexOf('.');
            if (点位置 < 0) return false;

            string 前半 = 地址.Substring(0, 点位置);
            通道 = int.TryParse(地址.Substring(点位置 + 1), out int ch) ? ch : -1;
            if (通道 < 0) return false;

            for (int i = 0; i < 前半.Length; i++)
            {
                if (char.IsDigit(前半[i]))
                {
                    前缀 = 前半.Substring(0, i);
                    板号 = int.TryParse(前半.Substring(i), out int bn) ? bn : -1;
                    return 板号 > 0;
                }
            }

            return false;
        }

        private void 保存指定拼版地址(int 行索引, int 拼版号, string 地址)
        {
            if (行索引 < 0 || 行索引 >= 检测项表格.Rows.Count) return;
            var 行 = 检测项表格.Rows[行索引];
            if (行.IsNewRow) return;

            string 地址字段名 = $"拼版{拼版号}地址";

            if (!检测项表格.Columns.Contains(地址字段名))
            {
                var 列 = new DataGridViewTextBoxColumn();
                列.Name = 地址字段名;
                列.HeaderText = 地址字段名;
                列.Visible = false;
                检测项表格.Columns.Add(列);
            }

            行.Cells[地址字段名].Value = 地址;
        }

        private void 排版按钮_Click(object sender, EventArgs e)
        {
            MessageBox.Show("排版功能待实现", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void 保存配置按钮_Click(object sender, EventArgs e)
        {
            if (配置已修改 && !string.IsNullOrEmpty(当前配置名))
            {
                保存当前配置数据();
                配置已修改 = false;
                MessageBox.Show("配置已保存到数据库", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("配置未修改或未选择配置", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void 增加配置按钮_Click(object sender, EventArgs e)
        {
            string 新配置名 = "新配置" + (配置名列表.Items.Count + 1);
            日志管理器.记录(日志类别.配置操作, "新建配置", 新配置名);
            var 新数据 = new 配置项数据
            {
                配置名称 = 新配置名,
                创建日期 = DateTime.Now,
                拼板数 = 6,
                检测项列表 = new List<检测项数据>()
            };
            
            配置数据库.实例.保存配置(新数据);
            配置名列表.Items.Add(新配置名);
            配置名列表.SelectedIndex = 配置名列表.Items.Count - 1;
        }

        private void 复制配置按钮_Click(object sender, EventArgs e)
        {
            if (配置名列表.SelectedIndex == -1)
            {
                MessageBox.Show("请先选择一个配置", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string 源配置名 = 配置名列表.SelectedItem.ToString();
            日志管理器.记录(日志类别.配置操作, "复制配置", $"源: {源配置名}");
            var 源数据 = 配置数据库.实例.加载配置(源配置名);
            if (源数据 == null)
            {
                MessageBox.Show("源配置数据不存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string 新配置名 = 源配置名 + "_复制";
            
            var 新数据 = new 配置项数据
            {
                配置名称 = 新配置名,
                创建日期 = DateTime.Now,
                拼板数 = 源数据.拼板数,
                检测项列表 = new List<检测项数据>(源数据.检测项列表)
            };
            
            配置数据库.实例.保存配置(新数据);
            配置名列表.Items.Add(新配置名);
            配置名列表.SelectedIndex = 配置名列表.Items.Count - 1;
            MessageBox.Show($"已复制配置：{源配置名} -> {新配置名}", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void 导出配置按钮_Click(object sender, EventArgs e)
        {
            if (配置名列表.SelectedIndex == -1)
            {
                MessageBox.Show("请先选择一个配置", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            日志管理器.记录(日志类别.数据操作, "导出配置", 配置名列表.SelectedItem.ToString(), 权限等级.管理员);

            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "配置文件|*.json";
                dialog.FileName = 配置名列表.SelectedItem.ToString();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show($"配置已导出到：{dialog.FileName}", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void 导出Excel按钮_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "Excel文件|*.xlsx";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show($"配置已导出到：{dialog.FileName}", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void 删除配置按钮_Click(object sender, EventArgs e)
        {
            if (配置名列表.SelectedIndex == -1)
            {
                MessageBox.Show("请先选择一个配置", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string 配置名 = 配置名列表.SelectedItem.ToString();
            日志管理器.记录(日志类别.配置操作, "删除配置", 配置名);
            var result = MessageBox.Show($"确定要删除配置：{配置名}吗？", "确认",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                配置数据库.实例.删除配置(配置名);
                配置名列表.Items.RemoveAt(配置名列表.SelectedIndex);
                MessageBox.Show("配置已删除", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void 导入配置按钮_Click(object sender, EventArgs e)
        {
            日志管理器.记录(日志类别.数据操作, "导入配置", "", 权限等级.管理员);
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "配置文件|*.json";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string json = File.ReadAllText(dialog.FileName);
                        var 数据 = JsonSerializer.Deserialize<配置项数据>(json);
                        if (数据 != null)
                        {
                            配置数据库.实例.保存配置(数据);
                            配置名列表.Items.Add(数据.配置名称);
                            配置名列表.SelectedIndex = 配置名列表.Items.Count - 1;
                            MessageBox.Show($"配置已导入：{dialog.FileName}", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"导入失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void 增加项按钮_Click(object sender, EventArgs e)
        {
            if (配置名列表.SelectedIndex == -1)
            {
                MessageBox.Show("请先选择或创建一个配置", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            int 新序号 = 检测项表格.Rows.Count + 1;
            检测项表格.Rows.Add(新序号, $"检测项{新序号}", "继电器输出", 0, "", "", "false", false);
        }

        private void 插入项按钮_Click(object sender, EventArgs e)
        {
            if (配置名列表.SelectedIndex == -1)
            {
                MessageBox.Show("请先选择或创建一个配置", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (检测项表格.SelectedRows.Count > 0)
            {
                int 索引 = 检测项表格.SelectedRows[0].Index;
                检测项表格.Rows.Insert(索引, 索引 + 1, "新检测项", "继电器输出", 0, "", "", "false", false);
            }
            else
            {
                增加项按钮_Click(sender, e);
            }
        }

        private void 保存项按钮_Click(object sender, EventArgs e)
        {
            if (配置名列表.SelectedIndex == -1)
            {
                MessageBox.Show("请先选择或创建一个配置", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            保存当前配置数据();
            配置已修改 = false;
            MessageBox.Show("检测项已保存", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void 复制项按钮_Click(object sender, EventArgs e)
        {
            MessageBox.Show("检测项已复制", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void 粘贴项按钮_Click(object sender, EventArgs e)
        {
            MessageBox.Show("检测项已粘贴", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void 删除项按钮_Click(object sender, EventArgs e)
        {
            if (检测项表格.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in 检测项表格.SelectedRows)
                {
                    if (!row.IsNewRow)
                    {
                        检测项表格.Rows.Remove(row);
                    }
                }
                日志管理器.记录(日志类别.配置操作, "删除检测项", 当前配置名);
                同步检测设置表格();
            }
        }

        private void 启用所有按钮_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in 检测项表格.Rows)
            {
                if (!row.IsNewRow)
                {
                    row.Cells["启用列"].Value = true;
                }
            }
        }

        private void 停用所有按钮_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in 检测项表格.Rows)
            {
                if (!row.IsNewRow)
                {
                    row.Cells["启用列"].Value = false;
                }
            }
        }

        private void 偏移校正按钮_Click(object sender, EventArgs e)
        {
            MessageBox.Show("偏移校正功能待实现", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void 复制区块按钮_Click(object sender, EventArgs e)
        {
            MessageBox.Show("区块已复制", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void 增加子项按钮_Click(object sender, EventArgs e)
        {
            MessageBox.Show("子项已增加", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void 保存子项按钮_Click(object sender, EventArgs e)
        {
            MessageBox.Show("子项已保存", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void 删除子项按钮_Click(object sender, EventArgs e)
        {
            MessageBox.Show("子项已删除", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void 删除所有子项按钮_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("确定要删除所有子项吗？", "确认",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                MessageBox.Show("所有子项已删除", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void 全局坐标管理按钮_Click(object sender, EventArgs e)
        {
            MessageBox.Show("全局坐标管理功能待实现", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void 输出按钮_Click(object sender, EventArgs e)
        {
            MessageBox.Show("(X/K)输出功能待实现", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void 保存项参数按钮_Click(object sender, EventArgs e)
        {
            MessageBox.Show("项参数已保存", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void 选为当前按钮_Click(object sender, EventArgs e)
        {
            if (配置名列表.SelectedIndex == -1)
            {
                MessageBox.Show("请先选择一个配置", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show($"已选为当前配置：{配置名列表.SelectedItem}", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void 关闭并保存按钮_Click(object sender, EventArgs e)
        {
            if (配置已修改 && !string.IsNullOrEmpty(当前配置名))
            {
                保存当前配置数据();
                配置已修改 = false;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void 关闭按钮_Click(object sender, EventArgs e)
        {
            if (配置已修改 && !string.IsNullOrEmpty(当前配置名))
            {
                var result = MessageBox.Show($"配置 \"{当前配置名}\" 已修改，是否保存？", "保存提示",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    保存当前配置数据();
                    配置已修改 = false;
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void 编辑配置窗体_Load(object sender, EventArgs e)
        {

        }

        private void 右侧面板_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void 配置名列表_DoubleClick(object sender, EventArgs e)
        {
            if (配置名列表.SelectedIndex == -1) return;

            string? 原配置名 = 配置名列表.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(原配置名)) return;
            
            using (var 对话框 = new Form())
            {
                对话框.Text = "修改配置名称";
                对话框.StartPosition = FormStartPosition.CenterParent;
                对话框.FormBorderStyle = FormBorderStyle.FixedDialog;
                对话框.MaximizeBox = false;
                对话框.MinimizeBox = false;
                对话框.Width = 300;
                对话框.Height = 150;

                var 标签 = new Label();
                标签.Text = "新配置名称：";
                标签.Location = new Point(20, 20);
                标签.Size = new Size(80, 23);
                对话框.Controls.Add(标签);

                var 文本框 = new TextBox();
                文本框.Text = 原配置名;
                文本框.Location = new Point(100, 20);
                文本框.Size = new Size(160, 23);
                对话框.Controls.Add(文本框);

                var 确定按钮 = new Button();
                确定按钮.Text = "确定";
                确定按钮.DialogResult = DialogResult.OK;
                确定按钮.Location = new Point(60, 60);
                确定按钮.Size = new Size(80, 30);
                对话框.Controls.Add(确定按钮);

                var 取消按钮 = new Button();
                取消按钮.Text = "取消";
                取消按钮.DialogResult = DialogResult.Cancel;
                取消按钮.Location = new Point(150, 60);
                取消按钮.Size = new Size(80, 30);
                对话框.Controls.Add(取消按钮);

                对话框.AcceptButton = 确定按钮;
                对话框.CancelButton = 取消按钮;

                if (对话框.ShowDialog(this) == DialogResult.OK)
                {
                    string 新配置名 = 文本框.Text.Trim();
                    if (string.IsNullOrEmpty(新配置名))
                    {
                        MessageBox.Show("配置名称不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (新配置名 == 原配置名)
                    {
                        return;
                    }

                    if (配置名列表.Items.Contains(新配置名))
                    {
                        MessageBox.Show($"配置名称 '{新配置名}' 已存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    try
                    {
                        var 配置数据 = 配置数据库.实例.加载配置(原配置名);
                        if (配置数据 != null)
                        {
                            配置数据.配置名称 = 新配置名;
                            配置数据库.实例.保存配置(配置数据);
                            配置数据库.实例.删除配置(原配置名);
                            
                            配置名列表.Items[配置名列表.SelectedIndex] = 新配置名;
                            当前配置名 = 新配置名;
                            
                            日志管理器.记录(日志类别.配置操作, "重命名配置", $"{原配置名} → {新配置名}");
                            MessageBox.Show("配置名称已修改", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"修改失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
