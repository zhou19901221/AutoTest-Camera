using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

namespace 自动测试
{
    public class 模块寄存器配置表
    {
        public int 从站地址起始 { get; set; } = 2;
        public Dictionary<string, 模块寄存器信息> 模块配置 { get; set; } = new();
    }

    public class 模块寄存器信息
    {
        public string 模块类型 { get; set; } = "";
        public int 通道数 { get; set; } = 0;
        public int 占用从站数 { get; set; } = 1;
        public string 地址前缀 { get; set; } = "";
        public string 功率前缀 { get; set; } = "";
        public int 功率通道数 { get; set; } = 0;
        public Dictionary<string, 寄存器区域> 寄存器映射 { get; set; } = new();
    }

    public class 寄存器区域
    {
        public string 功能码 { get; set; } = "";
        public int 从站偏移 { get; set; } = 0;
        public int 起始地址 { get; set; } = 0;
        public List<通道地址项> 通道列表 { get; set; } = new();
    }

    public class 通道地址项
    {
        public int 通道号 { get; set; } = 0;
        public int 地址 { get; set; } = 0;
        public string 说明 { get; set; } = "";
    }

    public static class 模块寄存器管理
    {
        private static 模块寄存器配置表? _配置;
        private static readonly string 配置文件路径 = Path.Combine(Application.StartupPath, "模块寄存器配置.json");
        private static readonly JsonSerializerOptions 序列化选项 = new JsonSerializerOptions
        {
            WriteIndented = true,
            IncludeFields = true
        };

        public static 模块寄存器配置表 配置
        {
            get
            {
                _配置 ??= 加载();
                return _配置;
            }
        }

        public static 模块寄存器配置表 加载()
        {
            if (File.Exists(配置文件路径))
            {
                try
                {
                    string json = File.ReadAllText(配置文件路径);
                    return JsonSerializer.Deserialize<模块寄存器配置表>(json, 序列化选项) ?? new 模块寄存器配置表();
                }
                catch { }
            }
            return new 模块寄存器配置表();
        }

        public static void 保存(模块寄存器配置表 数据)
        {
            try
            {
                string json = JsonSerializer.Serialize(数据, 序列化选项);
                File.WriteAllText(配置文件路径, json);
                _配置 = 数据;
            }
            catch { }
        }

        public static 模块寄存器信息? 获取模块信息(string 模块类型)
        {
            if (配置.模块配置.TryGetValue(模块类型, out var 信息))
                return 信息;
            return null;
        }

        public static int 获取模块占用从站数(string 模块类型)
        {
            var 信息 = 获取模块信息(模块类型);
            return 信息?.占用从站数 ?? 1;
        }

        public static List<int> 获取模块从站地址列表(int 模块序号, string 模块类型)
        {
            var 列表 = new List<int>();
            int 占用数 = 获取模块占用从站数(模块类型);
            int 基地址 = 配置.从站地址起始 + 模块序号;
            for (int i = 0; i < 占用数; i++)
            {
                列表.Add(基地址 + i);
            }
            return 列表;
        }

        public static 寄存器区域? 获取寄存器区域(string 模块类型, string 区域名称)
        {
            var 信息 = 获取模块信息(模块类型);
            if (信息 != null && 信息.寄存器映射.TryGetValue(区域名称, out var 区域))
                return 区域;
            return null;
        }
    }
}
