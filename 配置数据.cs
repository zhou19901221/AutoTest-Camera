using System;
using System.Collections.Generic;

namespace 自动测试
{
    public class 配置数据
    {
        public 基础参数配置 基础参数 { get; set; } = new 基础参数配置();
        public 检测设置配置 检测设置 { get; set; } = new 检测设置配置();
        public 运动控制配置 运动控制 { get; set; } = new 运动控制配置();
        public 电压模块配置 电压模块 { get; set; } = new 电压模块配置();
        public MESS设置配置 MESS设置 { get; set; } = new MESS设置配置();
        public 其他设置配置 其他设置 { get; set; } = new 其他设置配置();
    }

    public class 基础参数配置
    {
        public string 设备名称 { get; set; } = "自动测试设备";
        public string 设备编号 { get; set; } = "DEV-001";
        public string 操作员 { get; set; } = "";
        public DateTime 最后更新时间 { get; set; } = DateTime.Now;
    }

    public class 检测设置配置
    {
        public int 检测次数 { get; set; } = 1;
        public int 检测间隔 { get; set; } = 100;
        public int 通讯异常检测次数 { get; set; } = 1;
        public int 通讯异常检测间隔 { get; set; } = 100;
    }

    public class 运动控制配置
    {
        public decimal Z轴导程 { get; set; } = 50;
        public decimal Z轴最大行程 { get; set; } = 50;
        public decimal Z轴最小行程 { get; set; } = 50;
        public decimal Z轴回零快速 { get; set; } = 50;
        public decimal Z轴回零慢速 { get; set; } = 50;
        public decimal Z轴自动速度 { get; set; } = 50;
        public decimal Z轴手动速度 { get; set; } = 50;
        public decimal Z轴加减速时间 { get; set; } = 50;

        public decimal Y轴导程 { get; set; } = 50;
        public decimal Y轴最大行程 { get; set; } = 50;
        public decimal Y轴最小行程 { get; set; } = 50;
        public decimal Y轴回零快速 { get; set; } = 50;
        public decimal Y轴回零慢速 { get; set; } = 50;
        public decimal Y轴自动速度 { get; set; } = 50;
        public decimal Y轴手动速度 { get; set; } = 50;
        public decimal Y轴加减速时间 { get; set; } = 50;
    }

    public class 电压模块配置
    {
        public string 波特率 { get; set; } = "9600";
        public string PLC地址 { get; set; } = "192.168.1.1";
        public decimal 量程 { get; set; } = 220;
        public List<电压模块项> 模块列表 { get; set; } = new List<电压模块项>();
    }

    public class 电压模块项
    {
        public string 类型 { get; set; } = "";
        public string 备注 { get; set; } = "";
        public decimal 量程 { get; set; } = 220;
        public string 单位 { get; set; } = "";
    }

    public class MESS设置配置
    {
        public string 服务器地址 { get; set; } = "";
        public int 端口 { get; set; } = 8080;
        public bool 启用MESS { get; set; } = false;
    }

    public class 其他设置配置
    {
        public string 日志路径 { get; set; } = "";
        public bool 自动保存日志 { get; set; } = true;
        public int 日志保留天数 { get; set; } = 30;
    }
}