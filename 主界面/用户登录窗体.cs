using System;
using System.Drawing;
using System.Windows.Forms;

namespace 自动测试
{
    public class 用户登录窗体 : Form
    {
        private readonly TextBox 用户名框;
        private readonly TextBox 密码框;
        private readonly Button 登录按钮;
        private readonly Button 取消按钮;

        public 用户信息? 登录用户 { get; private set; }

        public 用户登录窗体()
        {
            Text = "用户登录";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = new Size(1936, 1048);

            var 用户名标签 = new Label { Text = "用户名：", Location = new Point(30, 30), Size = new Size(70, 25) };
            用户名框 = new TextBox { Location = new Point(100, 30), Size = new Size(170, 25) };

            var 密码标签 = new Label { Text = "密码：", Location = new Point(30, 70), Size = new Size(70, 25) };
            密码框 = new TextBox { Location = new Point(100, 70), Size = new Size(170, 25), UseSystemPasswordChar = true };

            登录按钮 = new Button { Text = "登录", Location = new Point(100, 115), Size = new Size(80, 30) };
            取消按钮 = new Button { Text = "取消", Location = new Point(190, 115), Size = new Size(80, 30) };

            登录按钮.Click += 登录按钮_Click;
            取消按钮.Click += (_, __) => DialogResult = DialogResult.Cancel;

            AcceptButton = 登录按钮;
            CancelButton = 取消按钮;

            Controls.AddRange(new Control[] { 用户名标签, 用户名框, 密码标签, 密码框, 登录按钮, 取消按钮 });
        }

        private void 登录按钮_Click(object? sender, EventArgs e)
        {
            if (用户管理器.验证登录(用户名框.Text, 密码框.Text, out var 用户) && 用户 != null)
            {
                登录用户 = 用户;
                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            MessageBox.Show("用户名或密码错误，或账号已禁用", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
