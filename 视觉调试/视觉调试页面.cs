﻿using MvCamCtrl.NET;
using System.Drawing;
using System.Runtime.InteropServices;

namespace 自动测试
{
    public partial class 视觉调试页面 : Form
    {
        private nint 图像数据指针 = nint.Zero;
        private int 图像缓冲大小 = 0;
        private float 缩放比例 = 1.0f;
        private int 原始宽度 = 0;
        private int 原始高度 = 0;
        private System.Windows.Forms.Timer 实时显示定时器 = new System.Windows.Forms.Timer();
        private bool 正在实时显示 = false;
        private MyCamera? 相机对象 = null;

        public 视觉调试页面()
        {
            InitializeComponent();
            实时显示定时器.Interval = 50;
            实时显示定时器.Tick += 实时显示定时器_Tick;
            图像源选择.SelectedIndex = 0;
            更新图像源界面();
            界面缩放器.等比例适配屏幕(this);
        }

        private void 更新图像源界面()
        {
            bool 是相机 = 图像源选择.SelectedIndex == 0;
            图片目录标签.Enabled = !是相机;
            图片目录路径.Enabled = !是相机;
            选择目录按钮.Enabled = !是相机;
            图片列表.Enabled = !是相机;

            if (是相机 && 正在实时显示)
            {
                实时显示定时器.Stop();
                if (相机对象 != null)
                {
                    相机对象.MV_CC_StopGrabbing_NET();
                }
                正在实时显示 = false;
                加载图像.Text = "加载图像";
            }
        }

        private void 图像源选择_SelectedIndexChanged(object? sender, EventArgs e)
        {
            更新图像源界面();
        }

        private void 选择目录按钮_Click(object? sender, EventArgs e)
        {
            using (FolderBrowserDialog 文件夹对话框 = new FolderBrowserDialog())
            {
                文件夹对话框.Description = "选择图片目录";
                if (文件夹对话框.ShowDialog() == DialogResult.OK)
                {
                    图片目录路径.Text = 文件夹对话框.SelectedPath;
                    加载图片列表();
                }
            }
        }

        private void 加载图片列表()
        {
            图片列表.Items.Clear();
            
            if (string.IsNullOrEmpty(图片目录路径.Text) || !System.IO.Directory.Exists(图片目录路径.Text))
            {
                return;
            }

            string[] 图片扩展名 = { "*.bmp", "*.jpg", "*.jpeg", "*.png", "*.tif", "*.tiff" };
            foreach (string 扩展名 in 图片扩展名)
            {
                string[] 文件列表 = System.IO.Directory.GetFiles(图片目录路径.Text, 扩展名);
                foreach (string 文件 in 文件列表)
                {
                    图片列表.Items.Add(System.IO.Path.GetFileName(文件));
                }
            }
        }

        private void 图片列表_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (图片列表.SelectedIndex < 0) return;

            string 图片文件名 = 图片列表.SelectedItem.ToString();
            string 图片完整路径 = System.IO.Path.Combine(图片目录路径.Text, 图片文件名);

            try
            {
                using (Bitmap 位图 = new Bitmap(图片完整路径))
                {
                    原始宽度 = 位图.Width;
                    原始高度 = 位图.Height;
                    视觉显示图像.Image = new Bitmap(位图);
                }
            }
            catch (Exception 异常)
            {
                MessageBox.Show($"加载图片失败：{异常.Message}");
            }
        }

        private void 实时显示定时器_Tick(object? sender, EventArgs e)
        {
            if (相机对象 == null) return;

            MyCamera.MV_FRAME_OUT 图像输出 = new MyCamera.MV_FRAME_OUT();
            int 结果 = 相机对象.MV_CC_GetImageBuffer_NET(ref 图像输出, 100);

            if (结果 == MyCamera.MV_OK)
            {
                int 宽度 = (int)图像输出.stFrameInfo.nWidth;
                int 高度 = (int)图像输出.stFrameInfo.nHeight;
                原始宽度 = 宽度;
                原始高度 = 高度;
                int 图像大小 = 宽度 * 高度 * 3;

                if (图像大小 > 图像缓冲大小)
                {
                    if (图像数据指针 != nint.Zero)
                    {
                        Marshal.FreeHGlobal(图像数据指针);
                    }
                    图像数据指针 = Marshal.AllocHGlobal(图像大小);
                    图像缓冲大小 = 图像大小;
                }

                MyCamera.MV_PIXEL_CONVERT_PARAM 像素转换参数 = new MyCamera.MV_PIXEL_CONVERT_PARAM();
                像素转换参数.nWidth = (ushort)宽度;
                像素转换参数.nHeight = (ushort)高度;
                像素转换参数.pSrcData = 图像输出.pBufAddr;
                像素转换参数.nSrcDataLen = 图像输出.stFrameInfo.nFrameLen;
                像素转换参数.enSrcPixelType = 图像输出.stFrameInfo.enPixelType;
                像素转换参数.enDstPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed;
                像素转换参数.pDstBuffer = 图像数据指针;
                像素转换参数.nDstBufferSize = (uint)图像大小;

                结果 = 相机对象.MV_CC_ConvertPixelType_NET(ref 像素转换参数);
                if (结果 == MyCamera.MV_OK)
                {
                    byte[] 图像数据 = new byte[像素转换参数.nDstLen];
                    Marshal.Copy(图像数据指针, 图像数据, 0, (int)像素转换参数.nDstLen);

                    using (Bitmap 位图 = new Bitmap(宽度, 高度, System.Drawing.Imaging.PixelFormat.Format24bppRgb))
                    {
                        Rectangle 矩形 = new Rectangle(0, 0, 宽度, 高度);
                        System.Drawing.Imaging.BitmapData 位图数据 = 位图.LockBits(矩形, System.Drawing.Imaging.ImageLockMode.WriteOnly, 位图.PixelFormat);
                        Marshal.Copy(图像数据, 0, 位图数据.Scan0, (int)像素转换参数.nDstLen);
                        位图.UnlockBits(位图数据);
                        视觉显示图像.Image = new Bitmap(位图);
                    }
                }

                相机对象.MV_CC_FreeImageBuffer_NET(ref 图像输出);
            }
        }

        private void 视觉显示图像_MouseMove(object? sender, MouseEventArgs e)
        {
            if (视觉显示图像.Image == null)
            {
                图像坐标信息.Text = "坐标：X=0, Y=0";
                return;
            }

            int 显示宽度 = 视觉显示图像.ClientSize.Width;
            int 显示高度 = 视觉显示图像.ClientSize.Height;

            float 横向缩放 = (float)原始宽度 / 显示宽度;
            float 纵向缩放 = (float)原始高度 / 显示高度;

            int 实际X = (int)(e.X * 横向缩放);
            int 实际Y = (int)(e.Y * 纵向缩放);

            if (实际X >= 0 && 实际X < 原始宽度 && 实际Y >= 0 && 实际Y < 原始高度)
            {
                图像坐标信息.Text = $"坐标：X={实际X}, Y={实际Y}";
            }
            else
            {
                图像坐标信息.Text = "坐标：超出范围";
            }
        }

        private void 视觉显示图像_MouseWheel(object? sender, MouseEventArgs e)
        {
            if (视觉显示图像.Image == null) return;

            float 缩放因子 = e.Delta > 0 ? 1.1f : 0.9f;
            缩放比例 *= 缩放因子;

            if (缩放比例 < 0.1f) 缩放比例 = 0.1f;
            if (缩放比例 > 10.0f) 缩放比例 = 10.0f;

            int 新宽度 = (int)(原始宽度 * 缩放比例);
            int 新高度 = (int)(原始高度 * 缩放比例);

            视觉显示图像.Size = new Size(新宽度, 新高度);
        }

        private void 加载图像_Click(object? sender, EventArgs e)
        {
            if (图像源选择.SelectedIndex == 0)
            {
                if (Form1.主窗体实例 == null)
                {
                    MessageBox.Show("主窗体未初始化");
                    return;
                }

                if (!Form1.主窗体实例.是否相机已连接())
                {
                    MessageBox.Show("相机未连接");
                    return;
                }

                相机对象 = Form1.主窗体实例.获取相机对象();
                if (相机对象 == null)
                {
                    MessageBox.Show("相机对象无效");
                    return;
                }

                try
                {
                    if (!正在实时显示)
                    {
                        int 结果 = 相机对象.MV_CC_StartGrabbing_NET();
                        if (结果 != MyCamera.MV_OK)
                        {
                            MessageBox.Show($"开始取流失败，错误码：{结果}");
                            return;
                        }

                        正在实时显示 = true;
                        实时显示定时器.Start();
                        加载图像.Text = "停止显示";
                    }
                    else
                    {
                        实时显示定时器.Stop();
                        相机对象.MV_CC_StopGrabbing_NET();
                        正在实时显示 = false;
                        加载图像.Text = "加载图像";
                    }
                }
                catch (Exception 异常)
                {
                    MessageBox.Show($"加载图像异常：{异常.Message}");
                }
            }
            else
            {
                if (图片列表.SelectedIndex < 0)
                {
                    MessageBox.Show("请先选择一张图片");
                    return;
                }
                图片列表_SelectedIndexChanged(null, null);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (正在实时显示 && 相机对象 != null)
            {
                实时显示定时器.Stop();
                相机对象.MV_CC_StopGrabbing_NET();
                正在实时显示 = false;
            }

            if (图像数据指针 != nint.Zero)
            {
                Marshal.FreeHGlobal(图像数据指针);
                图像数据指针 = nint.Zero;
            }

            实时显示定时器.Dispose();
            base.OnFormClosing(e);
        }

        private void 抓取图像_Click(object sender, EventArgs e)
        {
            if (视觉显示图像.Image == null)
            {
                MessageBox.Show("请先加载图像");
                return;
            }

            using (SaveFileDialog 保存对话框 = new SaveFileDialog())
            {
                保存对话框.Filter = "BMP图像|*.bmp|JPEG图像|*.jpg|PNG图像|*.png";
                保存对话框.Title = "保存图像";
                保存对话框.FileName = $"图像_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}";
                
                if (保存对话框.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string 文件路径 = 保存对话框.FileName;
                        string 扩展名 = System.IO.Path.GetExtension(文件路径).ToLower();

                        System.Drawing.Imaging.ImageFormat 格式 = System.Drawing.Imaging.ImageFormat.Bmp;
                        if (扩展名 == ".jpg" || 扩展名 == ".jpeg")
                        {
                            格式 = System.Drawing.Imaging.ImageFormat.Jpeg;
                        }
                        else if (扩展名 == ".png")
                        {
                            格式 = System.Drawing.Imaging.ImageFormat.Png;
                        }

                        视觉显示图像.Image.Save(文件路径, 格式);
                        MessageBox.Show($"图像已保存到：{文件路径}", "保存成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception 异常)
                    {
                        MessageBox.Show($"保存图像失败：{异常.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void 相机设置_Click(object sender, EventArgs e)
        {
            if (Form1.主窗体实例 == null)
            {
                MessageBox.Show("主窗体未初始化");
                return;
            }

            if (!Form1.主窗体实例.是否相机已连接())
            {
                MessageBox.Show("相机未连接");
                return;
            }

            MyCamera? 相机 = Form1.主窗体实例.获取相机对象();
            if (相机 == null)
            {
                MessageBox.Show("相机对象无效");
                return;
            }

            var 属性页面 = new 相机属性页面(相机);
            属性页面.Show();
        }
    }
}
