using System;
using System.Windows.Forms;

namespace 自动测试
{
    public partial class 测试记录页面 : Form
    {
        public 测试记录页面()
        {
            InitializeComponent();
            初始化筛选();
            初始化表格();
            执行查询();
        }

        private void 初始化筛选()
        {
            起始时间框.Value = DateTime.Today;
            结束时间框.Value = DateTime.Today;

            配置框.Items.Clear();
            配置框.Items.Add("全部");
            foreach (var 名称 in 配置数据库.实例.获取测试结果配置列表())
            {
                配置框.Items.Add(名称);
            }
            配置框.SelectedIndex = 0;

            结果框.Items.Clear();
            结果框.Items.Add("全部");
            结果框.Items.Add("PASS");
            结果框.Items.Add("FAIL");
            结果框.SelectedIndex = 0;
        }

        private void 初始化表格()
        {
            记录表格.Columns.Clear();

            var 时间列 = new DataGridViewTextBoxColumn { Name = "时间列", HeaderText = "测试时间", Width = 160 };
            var 配置列 = new DataGridViewTextBoxColumn { Name = "配置列", HeaderText = "测试配置", Width = 150 };
            var 结果列 = new DataGridViewTextBoxColumn { Name = "结果列", HeaderText = "测试结果", Width = 80 };
            var sn列 = new DataGridViewTextBoxColumn { Name = "SN列", HeaderText = "SN", Width = 180 };
            var 拼版列 = new DataGridViewTextBoxColumn { Name = "拼版列", HeaderText = "拼版", Width = 70 };
            var 失败列 = new DataGridViewTextBoxColumn { Name = "FAIL列", HeaderText = "FAIL结果", Width = 500 };

            记录表格.Columns.AddRange(new DataGridViewColumn[] { 时间列, 配置列, 结果列, sn列, 拼版列, 失败列 });
        }

        private void 查询按钮_Click(object? sender, EventArgs e)
        {
            执行查询();
        }

        private void 执行查询()
        {
            string? 配置 = 配置框.SelectedIndex <= 0 ? null : 配置框.SelectedItem?.ToString();
            string? 结果 = 结果框.SelectedIndex <= 0 ? null : 结果框.SelectedItem?.ToString();
            string? sn = string.IsNullOrWhiteSpace(SN框.Text) ? null : SN框.Text.Trim();
            DateTime 起始 = 起始时间框.Value.Date;
            DateTime 结束 = 结束时间框.Value.Date.AddDays(1);

            var 列表 = 配置数据库.实例.查询测试结果(起始, 结束, 配置, 结果, sn);
            记录表格.Rows.Clear();

            foreach (var 记录 in 列表)
            {
                int idx = 记录表格.Rows.Add();
                var 行 = 记录表格.Rows[idx];
                行.Cells["时间列"].Value = 记录.测试时间.ToString("yyyy-MM-dd HH:mm:ss");
                行.Cells["配置列"].Value = 记录.测试配置;
                行.Cells["结果列"].Value = 记录.测试结果;
                行.Cells["SN列"].Value = 记录.SN;
                行.Cells["拼版列"].Value = 记录.拼版号;
                行.Cells["FAIL列"].Value = 记录.FAIL结果;
            }
        }
    }
}
