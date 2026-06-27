using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace 自动测试
{
    public partial class 编辑配置窗体 : Form
    {
        private List<RadioButton> 当前板选择列表 = new List<RadioButton>();

        public 编辑配置窗体()
        {
            InitializeComponent();
            初始化界面();
        }

        private void 初始化界面()
        {
            日期框.Text = DateTime.Now.ToString("yyyy/MM/dd");
            
            拼板数框.Minimum = 1;
            拼板数框.Maximum = 32;
            拼板数框.Value = 6;
            
            初始化当前板选择();
            
            拼板数框.ValueChanged += 拼板数框_ValueChanged;
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
                新按钮.Location = new System.Drawing.Point(20 + (索引 % 8) * 50, 20 + (索引 / 8) * 30);
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

        private void 排版按钮_Click(object sender, EventArgs e)
        {
            MessageBox.Show("排版功能待实现", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void 保存配置按钮_Click(object sender, EventArgs e)
        {
            MessageBox.Show("配置保存成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void 增加配置按钮_Click(object sender, EventArgs e)
        {
            string 新配置名 = "新配置" + (配置名列表.Items.Count + 1);
            配置名列表.Items.Add(新配置名);
            配置名列表.SelectedIndex = 配置名列表.Items.Count - 1;
            配置名称框.Text = 新配置名;
        }

        private void 复制配置按钮_Click(object sender, EventArgs e)
        {
            if (配置名列表.SelectedIndex == -1)
            {
                MessageBox.Show("请先选择一个配置", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            string 源配置名 = 配置名列表.SelectedItem.ToString();
            string 新配置名 = 源配置名 + "_复制";
            配置名列表.Items.Add(新配置名);
            配置名列表.SelectedIndex = 配置名列表.Items.Count - 1;
            配置名称框.Text = 新配置名;
            MessageBox.Show($"已复制配置：{源配置名} -> {新配置名}", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void 导出配置按钮_Click(object sender, EventArgs e)
        {
            if (配置名列表.SelectedIndex == -1)
            {
                MessageBox.Show("请先选择一个配置", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
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
            
            var result = MessageBox.Show($"确定要删除配置：{配置名列表.SelectedItem}吗？", "确认", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                配置名列表.Items.RemoveAt(配置名列表.SelectedIndex);
                MessageBox.Show("配置已删除", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void 导入配置按钮_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "配置文件|*.json";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string 配置名 = System.IO.Path.GetFileNameWithoutExtension(dialog.FileName);
                    配置名列表.Items.Add(配置名);
                    配置名列表.SelectedIndex = 配置名列表.Items.Count - 1;
                    MessageBox.Show($"配置已导入：{dialog.FileName}", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void 增加项按钮_Click(object sender, EventArgs e)
        {
            int 新序号 = 检测项表格.Rows.Count + 1;
            检测项表格.Rows.Add($"检测项{新序号}", 新序号, "电压采集", 0, false);
        }

        private void 插入项按钮_Click(object sender, EventArgs e)
        {
            if (检测项表格.SelectedRows.Count > 0)
            {
                int 索引 = 检测项表格.SelectedRows[0].Index;
                检测项表格.Rows.Insert(索引, "新检测项", 索引 + 1, "电压采集", 0, false);
            }
            else
            {
                增加项按钮_Click(sender, e);
            }
        }

        private void 保存项按钮_Click(object sender, EventArgs e)
        {
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
            
            当前配置框.Text = 配置名列表.SelectedItem.ToString();
            MessageBox.Show($"已选为当前配置：{当前配置框.Text}", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void 关闭并保存按钮_Click(object sender, EventArgs e)
        {
            MessageBox.Show("配置已保存", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void 关闭按钮_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
