using System;
using System.IO;
using System.Text.Json;

namespace 自动测试
{
    public class 系统配置数据
    {
        public 基础参数类 基础参数 = new 基础参数类();
        public 运动控制类 运动控制 = new 运动控制类();
        public 电压模块类 电压模块 = new 电压模块类();
        public 电流模块类 电流模块 = new 电流模块类();
        public IO模块类 IO模块 = new IO模块类();
        public PWM模块类 PWM模块 = new PWM模块类();
        public 其它模块类 其它模块 = new 其它模块类();
        public 平台视觉类 平台视觉 = new 平台视觉类();
        public MESS设置类 MESS设置 = new MESS设置类();
        public 其他设置类 其他设置 = new 其他设置类();
    }

    public static class 系统配置管理
    {
        private static 系统配置数据? _实例;
        private static readonly string 配置文件路径 = Path.Combine(Application.StartupPath, "系统配置.json");
        private static readonly JsonSerializerOptions 序列化选项 = new JsonSerializerOptions 
        { 
            WriteIndented = true, 
            IncludeFields = true 
        };

        public static 系统配置数据 实例
        {
            get
            {
                _实例 ??= 加载();
                return _实例;
            }
        }

        public static 系统配置数据 加载()
        {
            if (File.Exists(配置文件路径))
            {
                try
                {
                    string json = File.ReadAllText(配置文件路径);
                    return JsonSerializer.Deserialize<系统配置数据>(json, 序列化选项) ?? new 系统配置数据();
                }
                catch { }
            }
            return new 系统配置数据();
        }

        public static void 保存(系统配置数据 数据)
        {
            try
            {
                string json = JsonSerializer.Serialize(数据, 序列化选项);
                File.WriteAllText(配置文件路径, json);
            }
            catch { }
        }

        public static List<string> 获取可用地址列表(string 类型)
        {
            var 列表 = new List<string>();
            var 配置 = 实例;

            switch (类型)
            {
                case "输入检测":
                {
                    int 编号 = 1;
                    foreach (var 模块 in 配置.电压模块.模块列表)
                    {
                        if (模块.模块类型 == "输入模块")
                        {
                            for (int i = 0; i < 模块.通道数量; i++)
                                列表.Add($"I{编号}.{i}");
                            编号++;
                        }
                    }
                    break;
                }
                case "继电器输出":
                {
                    int 编号 = 1;
                    foreach (var 模块 in 配置.电压模块.模块列表)
                    {
                        if (模块.模块类型 == "输出模块")
                        {
                            for (int i = 0; i < 模块.通道数量; i++)
                                列表.Add($"Q{编号}.{i}");
                            编号++;
                        }
                    }
                    break;
                }
                case "电源输出":
                {
                    int 编号 = 1;
                    foreach (var 通道数 in 配置.电压模块.继电器通道数)
                    {
                        if (通道数 > 0)
                        {
                            for (int i = 0; i < 通道数; i++)
                                列表.Add($"R{编号}.{i}");
                            编号++;
                        }
                    }
                    break;
                }
                case "直流电压":
                case "交流电压":
                {
                    int 编号 = 1;
                    foreach (var 模块 in 配置.电压模块.模块列表)
                    {
                        if (模块.模块类型 == "直流电压模块")
                        {
                            for (int i = 0; i < 模块.通道数量; i++)
                                列表.Add($"AI{编号}.{i}");
                            编号++;
                        }
                    }
                    break;
                }
                case "直流电流":
                case "交流电流":
                {
                    int 编号 = 1;
                    foreach (var 模块 in 配置.电压模块.模块列表)
                    {
                        if (模块.模块类型 == "直流电流模块")
                        {
                            for (int i = 0; i < 模块.通道数量; i++)
                                列表.Add($"AI{编号}.{i}");
                            编号++;
                        }
                    }
                    break;
                }
                case "声音采集":
                {
                    int 编号 = 1;
                    foreach (var 模块 in 配置.电压模块.模块列表)
                    {
                        if (模块.模块类型 == "声音模块")
                        {
                            for (int i = 0; i < 模块.通道数量; i++)
                                列表.Add($"S{编号}.{i}");
                            编号++;
                        }
                    }
                    break;
                }
            }

            return 列表;
        }
    }

    public class 基础参数类
    {
        public string 测试类型 = "半自动FCT";
        public int 串口端口 = 1;
        public int 串口波特率 = 115200;
        public string 程控电源类型 = "无程控";
        public string 程控电源品牌 = "安姆泰克";
        public string 程控校验位 = "NONE";
        public int 程控波特率 = 115200;
        public double 程控电压 = 220.0;
        public int 程控频率 = 50;
        public double 程控电流 = 2.0;
        public bool 平台下降光幕保护 = true;
        public bool 平台上升光幕保护 = false;
        public bool 测试界面显示机器电压 = true;
        public bool NG授权管理 = false;
        public bool 安全门 = false;
        public bool 显示环境温度湿度 = false;
        public bool 开机自动运行 = false;
        public bool 全局量程 = false;
        public bool 伺服 = false;
    }

    public class 运动控制类
    {
        public double 主运一圈距离 = 141.372;
        public int 主运一圈脉冲 = 10000;
        public int 主运最大脉冲 = 100000;
        public int 主运最小脉冲 = 500;
        public int 主运归零脉冲 = 20000;
        public double 主运减速时间 = 0.2;
        public int 主运计数时间 = 0;
        public double 主运保留参数 = 0.0;
        
        public double Z轴导程 = 0.0;
        public int Z轴最大行程 = 0;
        public int Z轴最小行程 = 0;
        public int Z轴回零快速 = 0;
        public int Z轴回零慢速 = 0;
        public double Z轴加减速时间 = 0.0;
        public int Z轴自动速度 = 0;
        public int Z轴手动速度 = 0;
        
        public double Y轴导程 = 0.0;
        public int Y轴最大行程 = 0;
        public int Y轴最小行程 = 0;
        public int Y轴回零快速 = 0;
        public int Y轴回零慢速 = 0;
        public double Y轴加减速时间 = 0.0;
        public int Y轴自动速度 = 0;
        public int Y轴手动速度 = 0;
        
        public double 调宽一圈距离 = 16.0;
        public int 调宽一圈脉冲 = 10000;
        public int 调宽脉冲速度 = 15000;
        public int 调宽最小脉冲速度 = 500;
        public double 调宽加减速时间 = 0.1;
        public double 调宽最小宽度 = 48.91;
        public int 调宽归零脉冲速度 = 15000;
        public int 调宽归零脱离速度 = 4000;
        public int 调宽归零前正移脉冲 = 5000;
        public int 调宽归零脱离脉冲 = 3000;
        public int 调宽最低运行脉冲 = 1000;
    }

    public class 电压模块类
    {
        public int 采样普通状态 = 200;
        public int 采样功能测试时 = 50;
        public int 采样工作状态 = 50;
        public int 通讯重试次数 = 0;
        public int 通讯单次超时 = 0;
        public int 最大拼版数 = 30;
        public int 测试NG数 = 0;
        
        public List<模块通道配置> 模块列表 = new List<模块通道配置>();
        public List<int> 继电器通道数 = new List<int>();
        
        public List<string> 波特率列表 = new List<string>();
        public List<string> 备注列表 = new List<string>();
    }

    public class 模块通道配置
    {
        public string 模块类型 = "输入模块";
        public int 通道数量 = 16;
    }

    public class 电流模块类
    {
        public int 电流采集模块数 = 5;
        public List<通道配置项> 电流采集通道 = new List<通道配置项>();
        public int 电流输出模块数 = 0;
        public List<通道配置项> 电流输出通道 = new List<通道配置项>();
    }

    public class IO模块类
    {
        public int IO输入模块数 = 0;
        public List<通道配置项> IO输入通道 = new List<通道配置项>();
        public int IO输出模块数 = 2;
        public List<通道配置项> IO输出通道 = new List<通道配置项>();
    }

    public class PWM模块类
    {
        public int PWM采集模块数 = 1;
        public List<PWM通道配置项> PWM采集通道 = new List<PWM通道配置项>();
        public int PWM输出模块数 = 1;
        public List<PWM通道配置项> PWM输出通道 = new List<PWM通道配置项>();
    }

    public class 其它模块类
    {
        public int 功率采集模块数 = 1;
        public List<功率通道配置项> 功率采集通道 = new List<功率通道配置项>();
        public int 串口数 = 9;
        public int CAN模块数 = 1;
    }

    public class 平台视觉类
    {
        public double X轴一圈距离 = 75.290;
        public int X轴一圈脉冲 = 10000;
        public int X轴运行脉冲 = 6000;
        public int X轴最小脉冲 = 500;
        public double X轴减速时间 = 0.2;
        public int X轴归零脉冲 = 3000;
        public int X轴归零最小脉冲 = 500;
        public int X轴归零脱离脉冲 = 2000;
        public double X轴归零减速时间 = 0.2;
        
        public double Y轴一圈距离 = 75.290;
        public int Y轴一圈脉冲 = 10000;
        public int Y轴运行脉冲 = 6000;
        public int Y轴最小脉冲 = 500;
        public double Y轴减速时间 = 0.2;
        public int Y轴归零脉冲 = 3000;
        public int Y轴归零最小脉冲 = 500;
        public int Y轴归零脱离脉冲 = 2000;
        public double Y轴归零减速时间 = 0.2;
        
        public double 平台最大宽度X = 170.645;
        public double 平台最大宽度Y = 160.082;
        public double 工作点X = 4.977;
        public double 工作点Y = 4.977;
        public double XY运行速度 = 30.0;
        
        public string 相机类型 = "DaHeng";
        public int 相机数量 = 1;
        public int 相机宽度 = 2592;
        public int 相机高度 = 1944;
        public int 显示宽度 = 1150;
        public int 旋转角度 = 0;
        public int 相机捕捉次数 = 4;
        public int 相机重连时间 = 1;
        public int 相机捕捉间隔 = 200;
        public int 相机尝试间隔 = 1;
        public int 相机捕捉超时 = 8;
        public string 相机网段起始 = "0.0.0.0";
        public string 相机网段结束 = "0.0.0.0";
        public bool 配置相机 = true;
        public bool 自动设置相机属性 = true;
    }

    public class MESS设置类
    {
        public bool MESS功能开启 = false;
        public string 服务器IP = "192.168.2.100";
        public int 服务器端口 = 1000;
        public string 条码枪类型 = "USB";
        public int 条码枪数量 = 0;
        public int 条码枪波特率 = 115200;
        public int[] 端口映射 = new int[8] { 2, 3, 4, 5, 6, 7, 8, 9 };
    }

    public class 其他设置类
    {
        public string PLC地址 = "192.168.1.1";
        public int PLC端口 = 520;
        public int 内存偏移 = 0;
        public bool License启用 = false;
        public bool License提示 = true;
        public int License天数 = 0;
        public string 选择状态颜色 = "dLime";
        public string 路径颜色 = "dAqua";
        public string 当前路径颜色 = "dFuchsia";
        public string 空走状态颜色 = "dBlue";
        public string 记录类型 = "不记录";
        public bool 字符格式 = false;
        public string 保存文件路径 = @"D:\ComLog\";
    }

    public class 通道配置项
    {
        public int 路数 = 8;
        public double 量程 = 0.0;
        public string 备注 = "";
        public int 类型 = 0;
        public int 地址 = 0;
    }

    public class PWM通道配置项
    {
        public int 模块数 = 1;
        public string 备注 = "";
        public int 类型 = 0;
        public int 地址 = 0;
    }

    public class 功率通道配置项
    {
        public int 路数 = 8;
        public double 量程 = 0.0;
        public string 备注 = "";
        public int 类型 = 0;
        public int 地址 = 0;
    }
}