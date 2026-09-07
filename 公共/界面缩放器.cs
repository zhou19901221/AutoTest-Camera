using System;
using System.Drawing;
using System.Windows.Forms;

namespace 自动测试
{
    public static class 界面缩放器
    {
        public static float 当前比例 = 1f;

        public static void 等比例适配屏幕(Form 窗体)
        {
            Rectangle 工作区 = Screen.PrimaryScreen.WorkingArea;
            int 窗口宽 = 窗体.Width;
            int 窗口高 = 窗体.Height;
            float 比例 = Math.Min((float)工作区.Width / 窗口宽, (float)工作区.Height / 窗口高);
            if (比例 >= 1f && 窗口宽 <= 工作区.Width && 窗口高 <= 工作区.Height) return;
            if (比例 > 1f) 比例 = Math.Min((float)工作区.Width / 窗体.ClientSize.Width, (float)工作区.Height / 窗体.ClientSize.Height);
            当前比例 = 比例;

            缩放控件(窗体, 比例);
            窗体.Font = new Font(窗体.Font.FontFamily, 窗体.Font.Size * 比例, 窗体.Font.Style, 窗体.Font.Unit);
            窗体.ClientSize = new Size((int)(窗体.ClientSize.Width * 比例), (int)(窗体.ClientSize.Height * 比例));
            窗体.StartPosition = FormStartPosition.CenterScreen;
        }

        private static void 缩放控件(Control 容器, float 比例)
        {
            foreach (Control 控件 in 容器.Controls)
            {
                缩放控件(控件, 比例);
                bool 锚定右下 = (控件.Anchor & (AnchorStyles.Bottom | AnchorStyles.Right)) != 0;
                if (锚定右下)
                    控件.Size = new Size((int)(控件.Width * 比例), (int)(控件.Height * 比例));
                else
                    控件.Bounds = new Rectangle(
                        (int)(控件.Left * 比例), (int)(控件.Top * 比例),
                        (int)(控件.Width * 比例), (int)(控件.Height * 比例));
                控件.Font = new Font(控件.Font.FontFamily, 控件.Font.Size * 比例, 控件.Font.Style, 控件.Font.Unit);
                if (控件 is DataGridView 表格)
                {
                    foreach (DataGridViewColumn 列 in 表格.Columns)
                        列.Width = (int)(列.Width * 比例);
                    表格.ColumnHeadersHeight = (int)(表格.ColumnHeadersHeight * 比例);
                    表格.RowTemplate.Height = (int)(表格.RowTemplate.Height * 比例);
                }
            }
        }
    }
}