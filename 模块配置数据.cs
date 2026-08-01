using System;
using System.Collections.Generic;

namespace 自动测试
{
    public class 模块配置数据
    {
        public string 模块名称 { get; set; } = "";
        public string 模块类型 { get; set; } = "输入模块";
        public int 通道数量 { get; set; } = 16;
        public string 备注 { get; set; } = "";
        public string 单位 { get; set; } = "";
    }

    public class 模块配置管理
    {
        private static 模块配置管理? _实例;
        private readonly string 配置文件路径;

        public List<模块配置数据> 模块列表 { get; private set; } = new List<模块配置数据>();

        public static 模块配置管理 实例
        {
            get
            {
                _实例 ??= new 模块配置管理();
                return _实例;
            }
        }

        private 模块配置管理()
        {
            配置文件路径 = Path.Combine(Application.StartupPath, "模块配置.json");
            加载配置();
        }

        private void 加载配置()
        {
            if (!File.Exists(配置文件路径))
            {
                初始化默认配置();
                return;
            }

            try
            {
                string json = File.ReadAllText(配置文件路径);
                var 数据 = System.Text.Json.JsonSerializer.Deserialize<List<模块配置数据>>(json);
                if (数据 != null)
                {
                    模块列表 = 数据;
                }
            }
            catch
            {
                初始化默认配置();
            }
        }

        private void 初始化默认配置()
        {
            模块列表.Clear();
            for (int i = 0; i < 11; i++)
            {
                模块列表.Add(new 模块配置数据
                {
                    模块名称 = $"模块{i + 1}",
                    模块类型 = i < 8 ? "输入模块" : "继电器模块",
                    通道数量 = i < 8 ? 16 : 8,
                    备注 = "",
                    单位 = ""
                });
            }
        }

        public void 保存配置()
        {
            try
            {
                string json = System.Text.Json.JsonSerializer.Serialize(模块列表, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(配置文件路径, json);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"保存模块配置失败：{ex.Message}", "错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        public List<模块配置数据> 获取指定类型模块(string 类型)
        {
            return 模块列表.FindAll(m => m.模块类型 == 类型);
        }
    }
}