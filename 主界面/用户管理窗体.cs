using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace 自动测试
{
    public class 用户管理窗体 : Form
    {
        private readonly DataGridView 用户表格;
        private readonly Button 刷新按钮;
        private readonly Button 新增按钮;
        private readonly Button 修改权限按钮;
        private readonly Button 重置密码按钮;
        private readonly Button 启用禁用按钮;
        private readonly Button 删除按钮;

        public 用户管理窗体()
        {
            Text = "用户管理";
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(1936, 1048);

            用户表格 = new DataGridView
            {
                Location = new Point(12, 12),
                Size = new Size(836, 390),
                ReadOnly = true,
                MultiSelect = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                RowHeadersVisible = false,
                AutoGenerateColumns = false
            };

            用户表格.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id列", HeaderText = "ID", DataPropertyName = "Id", Width = 60 });
            用户表格.Columns.Add(new DataGridViewTextBoxColumn { Name = "用户名列", HeaderText = "用户名", DataPropertyName = "用户名", Width = 180 });
            用户表格.Columns.Add(new DataGridViewTextBoxColumn { Name = "权限列", HeaderText = "权限", DataPropertyName = "权限", Width = 120 });
            用户表格.Columns.Add(new DataGridViewCheckBoxColumn { Name = "启用列", HeaderText = "启用", DataPropertyName = "启用", Width = 80 });
            用户表格.Columns.Add(new DataGridViewTextBoxColumn { Name = "创建时间列", HeaderText = "创建时间", DataPropertyName = "创建时间", Width = 180 });
            用户表格.Columns.Add(new DataGridViewTextBoxColumn { Name = "更新时间列", HeaderText = "更新时间", DataPropertyName = "更新时间", Width = 180 });

            刷新按钮 = new Button { Text = "刷新", Location = new Point(12, 418), Size = new Size(80, 32) };
            新增按钮 = new Button { Text = "新增用户", Location = new Point(104, 418), Size = new Size(100, 32) };
            修改权限按钮 = new Button { Text = "修改权限", Location = new Point(216, 418), Size = new Size(100, 32) };
            重置密码按钮 = new Button { Text = "重置密码", Location = new Point(328, 418), Size = new Size(100, 32) };
            启用禁用按钮 = new Button { Text = "启用/禁用", Location = new Point(440, 418), Size = new Size(100, 32) };
            删除按钮 = new Button { Text = "删除用户", Location = new Point(552, 418), Size = new Size(100, 32) };

            刷新按钮.Click += (_, __) => 刷新用户列表();
            新增按钮.Click += 新增按钮_Click;
            修改权限按钮.Click += 修改权限按钮_Click;
            重置密码按钮.Click += 重置密码按钮_Click;
            启用禁用按钮.Click += 启用禁用按钮_Click;
            删除按钮.Click += 删除按钮_Click;

            Controls.Add(用户表格);
            Controls.AddRange(new Control[] { 刷新按钮, 新增按钮, 修改权限按钮, 重置密码按钮, 启用禁用按钮, 删除按钮 });

            Load += (_, __) => 刷新用户列表();
        }

        private void 刷新用户列表()
        {
            var 数据 = 用户管理器.获取用户列表()
                .Select(x => new
                {
                    x.Id,
                    x.用户名,
                    权限 = x.权限.ToString(),
                    x.启用,
                    创建时间 = x.创建时间.ToString("yyyy-MM-dd HH:mm:ss"),
                    更新时间 = x.更新时间.ToString("yyyy-MM-dd HH:mm:ss")
                })
                .ToList();

            用户表格.DataSource = 数据;
        }

        private int? 获取当前用户Id()
        {
            if (用户表格.CurrentRow == null) return null;

            if (用户表格.Columns.Contains("Id列")
                && int.TryParse(用户表格.CurrentRow.Cells["Id列"]?.Value?.ToString(), out int id))
            {
                return id;
            }

            if (int.TryParse(用户表格.CurrentRow.Cells[0].Value?.ToString(), out id)) return id;
            return null;
        }

        private void 新增按钮_Click(object? sender, EventArgs e)
        {
            using var 窗口 = new 用户编辑窗体();
            if (窗口.ShowDialog(this) != DialogResult.OK) return;

            if (!用户管理器.新增用户(窗口.用户名, 窗口.密码, 窗口.权限, out var 错误))
            {
                MessageBox.Show($"新增失败：{错误}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            刷新用户列表();
        }

        private void 修改权限按钮_Click(object? sender, EventArgs e)
        {
            int? 用户Id = 获取当前用户Id();
            if (用户Id == null) return;

            string 当前权限 = 用户表格.CurrentRow?.Cells["权限列"].Value?.ToString() ?? 权限等级.员工.ToString();
            if (!Enum.TryParse<权限等级>(当前权限, out var 权限值)) 权限值 = 权限等级.员工;

            using var 对话框 = new 权限选择窗体(权限值);
            if (对话框.ShowDialog(this) != DialogResult.OK) return;

            if (!用户管理器.更新用户权限(用户Id.Value, 对话框.选择权限, out var 错误))
            {
                MessageBox.Show($"修改失败：{错误}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            刷新用户列表();
        }

        private void 重置密码按钮_Click(object? sender, EventArgs e)
        {
            int? 用户Id = 获取当前用户Id();
            if (用户Id == null) return;

            using var 窗口 = new 密码输入窗体("重置密码");
            if (窗口.ShowDialog(this) != DialogResult.OK) return;

            if (!用户管理器.重置密码(用户Id.Value, 窗口.密码, out var 错误))
            {
                MessageBox.Show($"重置失败：{错误}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("密码已重置", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void 启用禁用按钮_Click(object? sender, EventArgs e)
        {
            int? 用户Id = 获取当前用户Id();
            if (用户Id == null) return;

            bool 当前启用 = false;
            bool.TryParse(用户表格.CurrentRow?.Cells["启用列"].Value?.ToString(), out 当前启用);

            if (!用户管理器.设置启用状态(用户Id.Value, !当前启用, out var 错误))
            {
                MessageBox.Show($"更新失败：{错误}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            刷新用户列表();
        }

        private void 删除按钮_Click(object? sender, EventArgs e)
        {
            int? 用户Id = 获取当前用户Id();
            if (用户Id == null) return;

            if (MessageBox.Show("确认删除该用户？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            if (!用户管理器.删除用户(用户Id.Value, out var 错误))
            {
                MessageBox.Show($"删除失败：{错误}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            刷新用户列表();
        }
    }

    internal class 用户编辑窗体 : Form
    {
        private readonly TextBox 用户名框;
        private readonly TextBox 密码框;
        private readonly ComboBox 权限框;

        public string 用户名 => 用户名框.Text.Trim();
        public string 密码 => 密码框.Text;
        public 权限等级 权限 => Enum.TryParse<权限等级>(权限框.Text, out var r) ? r : 权限等级.员工;

        public 用户编辑窗体()
        {
            Text = "新增用户";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = new Size(1936, 1048);

            Controls.Add(new Label { Text = "用户名：", Location = new Point(20, 25), Size = new Size(70, 25) });
            用户名框 = new TextBox { Location = new Point(95, 25), Size = new Size(190, 25) };
            Controls.Add(用户名框);

            Controls.Add(new Label { Text = "密码：", Location = new Point(20, 65), Size = new Size(70, 25) });
            密码框 = new TextBox { Location = new Point(95, 65), Size = new Size(190, 25), UseSystemPasswordChar = true };
            Controls.Add(密码框);

            Controls.Add(new Label { Text = "权限：", Location = new Point(20, 105), Size = new Size(70, 25) });
            权限框 = new ComboBox { Location = new Point(95, 105), Size = new Size(190, 25), DropDownStyle = ComboBoxStyle.DropDownList };
            权限框.Items.AddRange(Enum.GetNames(typeof(权限等级)));
            权限框.SelectedIndex = 0;
            Controls.Add(权限框);

            var 确认按钮 = new Button { Text = "确定", Location = new Point(125, 155), Size = new Size(75, 30) };
            var 取消按钮 = new Button { Text = "取消", Location = new Point(210, 155), Size = new Size(75, 30), DialogResult = DialogResult.Cancel };
            确认按钮.Click += (_, __) =>
            {
                if (string.IsNullOrWhiteSpace(用户名) || string.IsNullOrWhiteSpace(密码))
                {
                    MessageBox.Show("用户名和密码不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult = DialogResult.OK;
                Close();
            };

            AcceptButton = 确认按钮;
            CancelButton = 取消按钮;
            Controls.Add(确认按钮);
            Controls.Add(取消按钮);
        }
    }

    internal class 权限选择窗体 : Form
    {
        private readonly ComboBox 权限框;
        public 权限等级 选择权限 => Enum.TryParse<权限等级>(权限框.Text, out var r) ? r : 权限等级.员工;

        public 权限选择窗体(权限等级 当前权限)
        {
            Text = "修改权限";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = new Size(1936, 1048);

            Controls.Add(new Label { Text = "权限：", Location = new Point(20, 30), Size = new Size(70, 25) });
            权限框 = new ComboBox { Location = new Point(85, 30), Size = new Size(170, 25), DropDownStyle = ComboBoxStyle.DropDownList };
            权限框.Items.AddRange(Enum.GetNames(typeof(权限等级)));
            权限框.SelectedItem = 当前权限.ToString();
            Controls.Add(权限框);

            var 确认按钮 = new Button { Text = "确定", Location = new Point(100, 80), Size = new Size(75, 30) };
            var 取消按钮 = new Button { Text = "取消", Location = new Point(180, 80), Size = new Size(75, 30), DialogResult = DialogResult.Cancel };
            确认按钮.Click += (_, __) => { DialogResult = DialogResult.OK; Close(); };
            AcceptButton = 确认按钮;
            CancelButton = 取消按钮;
            Controls.Add(确认按钮);
            Controls.Add(取消按钮);
        }
    }

    internal class 密码输入窗体 : Form
    {
        private readonly TextBox 密码框;
        public string 密码 => 密码框.Text;

        public 密码输入窗体(string 标题)
        {
            Text = 标题;
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = new Size(1936, 1048);

            Controls.Add(new Label { Text = "新密码：", Location = new Point(20, 30), Size = new Size(70, 25) });
            密码框 = new TextBox { Location = new Point(95, 30), Size = new Size(190, 25), UseSystemPasswordChar = true };
            Controls.Add(密码框);

            var 确认按钮 = new Button { Text = "确定", Location = new Point(130, 80), Size = new Size(75, 30) };
            var 取消按钮 = new Button { Text = "取消", Location = new Point(210, 80), Size = new Size(75, 30), DialogResult = DialogResult.Cancel };
            确认按钮.Click += (_, __) =>
            {
                if (string.IsNullOrWhiteSpace(密码) || 密码.Length < 6)
                {
                    MessageBox.Show("密码至少6位", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DialogResult = DialogResult.OK;
                Close();
            };

            AcceptButton = 确认按钮;
            CancelButton = 取消按钮;
            Controls.Add(确认按钮);
            Controls.Add(取消按钮);
        }
    }
}
