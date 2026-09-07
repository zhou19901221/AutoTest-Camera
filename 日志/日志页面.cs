using System;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace 自动测试
{
    public partial class 日志页面 : Form
    {
        public 日志页面()
        {
            InitializeComponent();
            初始化表格();
            起始时间框.Value = DateTime.Today.AddDays(-7);
            结束时间框.Value = DateTime.Today;
            执行查询();
        }

        private void 初始化表格()
        {
            日志表格.Columns.Clear();

            var 时间列 = new DataGridViewTextBoxColumn();
            时间列.HeaderText = "时间";
            时间列.Name = "时间列";
            时间列.Width = 160;

            var 类别列 = new DataGridViewTextBoxColumn();
            类别列.HeaderText = "类别";
            类别列.Name = "类别列";
            类别列.Width = 90;

            var 操作列 = new DataGridViewTextBoxColumn();
            操作列.HeaderText = "操作";
            操作列.Name = "操作列";
            操作列.Width = 200;

            var 详情列 = new DataGridViewTextBoxColumn();
            详情列.HeaderText = "详情";
            详情列.Name = "详情列";
            详情列.Width = 400;

            var 用户列 = new DataGridViewTextBoxColumn();
            用户列.HeaderText = "用户";
            用户列.Name = "用户列";
            用户列.Width = 100;

            var 权限列 = new DataGridViewTextBoxColumn();
            权限列.HeaderText = "可见权限";
            权限列.Name = "权限列";
            权限列.Width = 80;

            日志表格.Columns.AddRange(new DataGridViewColumn[] { 时间列, 类别列, 操作列, 详情列, 用户列, 权限列 });
        }

        private void 查询按钮_Click(object sender, EventArgs e)
        {
            执行查询();
        }

        private void 执行查询()
        {
            日志表格.Rows.Clear();

            string? 类别筛选 = 类别框.SelectedIndex == 0 ? null : 类别框.SelectedItem?.ToString();
            string? 关键词 = string.IsNullOrWhiteSpace(关键词框.Text) ? null : 关键词框.Text.Trim();

            DateTime? 起始 = 起始时间框.Checked ? 起始时间框.Value : (DateTime?)null;
            DateTime? 结束 = 结束时间框.Checked ? 结束时间框.Value.AddDays(1) : (DateTime?)null;

            var 记录列表 = 日志管理器.查询(日志管理器.当前用户权限, 类别筛选, 起始, 结束, 关键词);

            foreach (var 记录 in 记录列表)
            {
                int 行索引 = 日志表格.Rows.Add();
                var 行 = 日志表格.Rows[行索引];
                行.Cells["时间列"].Value = 记录.时间;
                行.Cells["类别列"].Value = 记录.类别;
                行.Cells["操作列"].Value = 记录.操作;
                行.Cells["详情列"].Value = 记录.详情;
                行.Cells["用户列"].Value = 记录.用户;
                行.Cells["权限列"].Value = 记录.权限要求;
            }
        }

        private void 导出按钮_Click(object sender, EventArgs e)
        {
            using var 对话框 = new SaveFileDialog();
            对话框.Filter = "JSON文件|*.json|CSV文件|*.csv";
            对话框.FileName = $"操作日志_{DateTime.Now:yyyyMMdd_HHmmss}";
            if (对话框.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string? 类别筛选 = 类别框.SelectedIndex == 0 ? null : 类别框.SelectedItem?.ToString();
                    string? 关键词 = string.IsNullOrWhiteSpace(关键词框.Text) ? null : 关键词框.Text.Trim();
                    DateTime? 起始 = 起始时间框.Checked ? 起始时间框.Value : (DateTime?)null;
                    DateTime? 结束 = 结束时间框.Checked ? 结束时间框.Value.AddDays(1) : (DateTime?)null;

                    var 记录列表 = 日志管理器.查询(日志管理器.当前用户权限, 类别筛选, 起始, 结束, 关键词, 100000);

                    if (对话框.FileName.EndsWith(".json"))
                    {
                        string json = JsonSerializer.Serialize(记录列表, new JsonSerializerOptions { WriteIndented = true });
                        File.WriteAllText(对话框.FileName, json);
                    }
                    else
                    {
                        using var 写入 = new StreamWriter(对话框.FileName, false, System.Text.Encoding.UTF8);
                        写入.WriteLine("时间,类别,操作,详情,用户,可见权限");
                        foreach (var 记录 in 记录列表)
                        {
                            写入.WriteLine($"\"{记录.时间}\",\"{记录.类别}\",\"{记录.操作}\",\"{记录.详情}\",\"{记录.用户}\",\"{记录.权限要求}\"");
                        }
                    }

                    MessageBox.Show($"已导出 {记录列表.Count} 条日志", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    日志管理器.记录(日志类别.数据操作, "导出日志", $"{记录列表.Count}条", 权限等级.厂家);
                }
                catch (Exception 异常)
                {
                    MessageBox.Show($"导出失败：{异常.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void 清空按钮_Click(object sender, EventArgs e)
        {
            var 结果 = MessageBox.Show("确定要清空所有日志吗？此操作不可恢复！", "确认",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (结果 == DialogResult.Yes)
            {
                日志管理器.记录(日志类别.数据操作, "清空日志", "", 权限等级.厂家);
                日志管理器.清空日志();
            执行查询();
            界面缩放器.等比例适配屏幕(this);
                MessageBox.Show("日志已清空", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}