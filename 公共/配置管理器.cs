using System;
using System.IO;
using System.Text.Json;

namespace 自动测试
{
    public class 配置管理器
    {
        private static 配置管理器 _实例;
        private static readonly object _锁 = new object();
        
        private readonly string 配置文件路径;
        public 配置数据 当前配置 { get; private set; }

        private 配置管理器()
        {
            配置文件路径 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");
            当前配置 = new 配置数据();
        }

        public static 配置管理器 获取实例()
        {
            if (_实例 == null)
            {
                lock (_锁)
                {
                    if (_实例 == null)
                    {
                        _实例 = new 配置管理器();
                    }
                }
            }
            return _实例;
        }

        public bool 加载配置()
        {
            try
            {
                if (File.Exists(配置文件路径))
                {
                    string json = File.ReadAllText(配置文件路径);
                    当前配置 = JsonSerializer.Deserialize<配置数据>(json);
                    return true;
                }
                else
                {
                    当前配置 = new 配置数据();
                    保存配置();
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"加载配置失败：{ex.Message}", "错误", 
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool 保存配置()
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };
                
                string json = JsonSerializer.Serialize(当前配置, options);
                File.WriteAllText(配置文件路径, json);
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"保存配置失败：{ex.Message}", "错误",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool 备份配置()
        {
            try
            {
                string 备份路径 = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory, 
                    $"config_backup_{DateTime.Now:yyyyMMdd_HHmmss}.json"
                );
                
                if (File.Exists(配置文件路径))
                {
                    File.Copy(配置文件路径, 备份路径);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public void 重置为默认值()
        {
            当前配置 = new 配置数据();
            保存配置();
        }
    }
}