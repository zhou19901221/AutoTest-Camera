using MvCamCtrl.NET;

namespace 自动测试
{
    public enum 触发模式枚举
    {
        关闭 = 0,
        开启 = 1
    }

    public enum 触发源枚举
    {
        软触发 = 0,
        硬触发Line0 = 1,
        硬触发Line1 = 2,
        硬触发Line2 = 3,
        硬触发Line3 = 4,
        计数器0结束 = 5,
        计数器1结束 = 6
    }

    public enum 像素格式枚举
    {
        Mono8 = 17301505,
        Mono10 = 17825793,
        Mono10_Packed = 17825794,
        Mono12 = 17825795,
        Mono12_Packed = 17825796,
        BayerGR8 = 17301512,
        BayerRG8 = 17301513,
        BayerGB8 = 17301514,
        BayerBG8 = 17301515,
        BayerGR10 = 17825798,
        BayerRG10 = 17825799,
        BayerGB10 = 17825800,
        BayerBG10 = 17825801,
        BayerGR12 = 17825802,
        BayerRG12 = 17825803,
        BayerGB12 = 17825804,
        BayerBG12 = 17825805,
        RGB8_Packed = 35127300,
        BGR8_Packed = 35127301
    }

    public enum 自动白平衡枚举
    {
        关闭 = 0,
        一次 = 1,
        连续 = 2
    }

    public enum 使能枚举
    {
        关闭 = 0,
        开启 = 1
    }

    public partial class 相机属性页面 : Form
    {
        private MyCamera? 相机对象;
        private 相机参数类 原始参数 = new 相机参数类();
        private 相机参数类 当前参数 = new 相机参数类();
        private bool 参数已修改 = false;

        public 相机属性页面(MyCamera? 相机)
        {
            InitializeComponent();
            相机对象 = 相机;
            读取相机参数();
            参数列表.SelectedObject = 当前参数;
            参数列表.PropertyValueChanged += 参数列表_PropertyValueChanged;
        }

        private void 读取相机参数()
        {
            if (相机对象 == null) return;

            MyCamera.MVCC_FLOATVALUE 浮点值 = new MyCamera.MVCC_FLOATVALUE();
            MyCamera.MVCC_INTVALUE_EX 整数值 = new MyCamera.MVCC_INTVALUE_EX();

            相机对象.MV_CC_GetFloatValue_NET("ExposureTime", ref 浮点值);
            当前参数.曝光时间 = 浮点值.fCurValue;
            原始参数.曝光时间 = 浮点值.fCurValue;

            相机对象.MV_CC_GetFloatValue_NET("Gain", ref 浮点值);
            当前参数.增益 = 浮点值.fCurValue;
            原始参数.增益 = 浮点值.fCurValue;

            相机对象.MV_CC_GetIntValueEx_NET("Width", ref 整数值);
            当前参数.图像宽度 = (int)整数值.nCurValue;
            原始参数.图像宽度 = (int)整数值.nCurValue;

            相机对象.MV_CC_GetIntValueEx_NET("Height", ref 整数值);
            当前参数.图像高度 = (int)整数值.nCurValue;
            原始参数.图像高度 = (int)整数值.nCurValue;

            相机对象.MV_CC_GetIntValueEx_NET("OffsetX", ref 整数值);
            当前参数.X偏移 = (int)整数值.nCurValue;
            原始参数.X偏移 = (int)整数值.nCurValue;

            相机对象.MV_CC_GetIntValueEx_NET("OffsetY", ref 整数值);
            当前参数.Y偏移 = (int)整数值.nCurValue;
            原始参数.Y偏移 = (int)整数值.nCurValue;

            相机对象.MV_CC_GetFloatValue_NET("AcquisitionFrameRate", ref 浮点值);
            当前参数.帧率 = 浮点值.fCurValue;
            原始参数.帧率 = 浮点值.fCurValue;

            MyCamera.MVCC_ENUMVALUE 枚举值 = new MyCamera.MVCC_ENUMVALUE();
            相机对象.MV_CC_GetEnumValue_NET("TriggerMode", ref 枚举值);
            当前参数.触发模式 = (触发模式枚举)枚举值.nCurValue;
            原始参数.触发模式 = (触发模式枚举)枚举值.nCurValue;

            相机对象.MV_CC_GetEnumValue_NET("TriggerSource", ref 枚举值);
            当前参数.触发源 = (触发源枚举)枚举值.nCurValue;
            原始参数.触发源 = (触发源枚举)枚举值.nCurValue;

            相机对象.MV_CC_GetFloatValue_NET("TriggerDelay", ref 浮点值);
            当前参数.触发延迟 = 浮点值.fCurValue;
            原始参数.触发延迟 = 浮点值.fCurValue;

            相机对象.MV_CC_GetEnumValue_NET("PixelFormat", ref 枚举值);
            当前参数.像素格式 = (像素格式枚举)枚举值.nCurValue;
            原始参数.像素格式 = (像素格式枚举)枚举值.nCurValue;

            相机对象.MV_CC_GetEnumValue_NET("BalanceWhiteAuto", ref 枚举值);
            当前参数.自动白平衡 = (自动白平衡枚举)枚举值.nCurValue;
            原始参数.自动白平衡 = (自动白平衡枚举)枚举值.nCurValue;

            相机对象.MV_CC_GetFloatValue_NET("BalanceRatio", ref 浮点值);
            当前参数.白平衡系数 = 浮点值.fCurValue;
            原始参数.白平衡系数 = 浮点值.fCurValue;

            相机对象.MV_CC_GetFloatValue_NET("BlackLevel", ref 浮点值);
            当前参数.黑电平 = 浮点值.fCurValue;
            原始参数.黑电平 = 浮点值.fCurValue;

            相机对象.MV_CC_GetEnumValue_NET("GammaEnable", ref 枚举值);
            当前参数.Gamma使能 = (使能枚举)枚举值.nCurValue;
            原始参数.Gamma使能 = (使能枚举)枚举值.nCurValue;

            相机对象.MV_CC_GetFloatValue_NET("Gamma", ref 浮点值);
            当前参数.Gamma值 = 浮点值.fCurValue;
            原始参数.Gamma值 = 浮点值.fCurValue;

            相机对象.MV_CC_GetEnumValue_NET("SharpnessEnable", ref 枚举值);
            当前参数.锐化使能 = (使能枚举)枚举值.nCurValue;
            原始参数.锐化使能 = (使能枚举)枚举值.nCurValue;

            相机对象.MV_CC_GetIntValueEx_NET("Sharpness", ref 整数值);
            当前参数.锐化强度 = (int)整数值.nCurValue;
            原始参数.锐化强度 = (int)整数值.nCurValue;
        }

        private void 参数列表_PropertyValueChanged(object s, System.Windows.Forms.PropertyValueChangedEventArgs e)
        {
            参数已修改 = true;
        }

        private void 保存相机参数()
        {
            if (相机对象 == null) return;

            相机对象.MV_CC_SetFloatValue_NET("ExposureTime", 当前参数.曝光时间);
            相机对象.MV_CC_SetFloatValue_NET("Gain", 当前参数.增益);
            相机对象.MV_CC_SetIntValueEx_NET("Width", 当前参数.图像宽度);
            相机对象.MV_CC_SetIntValueEx_NET("Height", 当前参数.图像高度);
            相机对象.MV_CC_SetIntValueEx_NET("OffsetX", 当前参数.X偏移);
            相机对象.MV_CC_SetIntValueEx_NET("OffsetY", 当前参数.Y偏移);
            相机对象.MV_CC_SetFloatValue_NET("AcquisitionFrameRate", 当前参数.帧率);
            相机对象.MV_CC_SetEnumValue_NET("TriggerMode", (uint)当前参数.触发模式);
            相机对象.MV_CC_SetEnumValue_NET("TriggerSource", (uint)当前参数.触发源);
            相机对象.MV_CC_SetFloatValue_NET("TriggerDelay", 当前参数.触发延迟);
            相机对象.MV_CC_SetEnumValue_NET("PixelFormat", (uint)当前参数.像素格式);
            相机对象.MV_CC_SetEnumValue_NET("BalanceWhiteAuto", (uint)当前参数.自动白平衡);
            相机对象.MV_CC_SetFloatValue_NET("BalanceRatio", 当前参数.白平衡系数);
            相机对象.MV_CC_SetFloatValue_NET("BlackLevel", 当前参数.黑电平);
            相机对象.MV_CC_SetEnumValue_NET("GammaEnable", (uint)当前参数.Gamma使能);
            相机对象.MV_CC_SetFloatValue_NET("Gamma", 当前参数.Gamma值);
            相机对象.MV_CC_SetEnumValue_NET("SharpnessEnable", (uint)当前参数.锐化使能);
            相机对象.MV_CC_SetIntValueEx_NET("Sharpness", 当前参数.锐化强度);
        }

        private void 关闭按钮_Click(object? sender, EventArgs e)
        {
            if (参数已修改)
            {
                DialogResult 结果 = MessageBox.Show("属性已修改，是否保存？", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                
                if (结果 == DialogResult.Yes)
                {
                    保存相机参数();
                    this.Close();
                }
                else if (结果 == DialogResult.No)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }
    }

    public class 相机参数类
    {
        [System.ComponentModel.Category("图像尺寸")]
        [System.ComponentModel.Description("图像宽度")]
        public int 图像宽度 { get; set; }

        [System.ComponentModel.Category("图像尺寸")]
        [System.ComponentModel.Description("图像高度")]
        public int 图像高度 { get; set; }

        [System.ComponentModel.Category("图像尺寸")]
        [System.ComponentModel.Description("X方向偏移")]
        public int X偏移 { get; set; }

        [System.ComponentModel.Category("图像尺寸")]
        [System.ComponentModel.Description("Y方向偏移")]
        public int Y偏移 { get; set; }

        [System.ComponentModel.Category("曝光控制")]
        [System.ComponentModel.Description("曝光时间(微秒)")]
        public float 曝光时间 { get; set; }

        [System.ComponentModel.Category("曝光控制")]
        [System.ComponentModel.Description("增益值")]
        public float 增益 { get; set; }

        [System.ComponentModel.Category("采集控制")]
        [System.ComponentModel.Description("帧率")]
        public float 帧率 { get; set; }

        [System.ComponentModel.Category("采集控制")]
        [System.ComponentModel.Description("触发模式")]
        public 触发模式枚举 触发模式 { get; set; }

        [System.ComponentModel.Category("采集控制")]
        [System.ComponentModel.Description("触发源")]
        public 触发源枚举 触发源 { get; set; }

        [System.ComponentModel.Category("采集控制")]
        [System.ComponentModel.Description("触发延迟(微秒)")]
        public float 触发延迟 { get; set; }

        [System.ComponentModel.Category("图像格式")]
        [System.ComponentModel.Description("像素格式")]
        public 像素格式枚举 像素格式 { get; set; }

        [System.ComponentModel.Category("颜色控制")]
        [System.ComponentModel.Description("自动白平衡")]
        public 自动白平衡枚举 自动白平衡 { get; set; }

        [System.ComponentModel.Category("颜色控制")]
        [System.ComponentModel.Description("白平衡系数")]
        public float 白平衡系数 { get; set; }

        [System.ComponentModel.Category("颜色控制")]
        [System.ComponentModel.Description("黑电平")]
        public float 黑电平 { get; set; }

        [System.ComponentModel.Category("图像处理")]
        [System.ComponentModel.Description("Gamma使能")]
        public 使能枚举 Gamma使能 { get; set; }

        [System.ComponentModel.Category("图像处理")]
        [System.ComponentModel.Description("Gamma值")]
        public float Gamma值 { get; set; }

        [System.ComponentModel.Category("图像处理")]
        [System.ComponentModel.Description("锐化使能")]
        public 使能枚举 锐化使能 { get; set; }

        [System.ComponentModel.Category("图像处理")]
        [System.ComponentModel.Description("锐化强度")]
        public int 锐化强度 { get; set; }
    }
}
