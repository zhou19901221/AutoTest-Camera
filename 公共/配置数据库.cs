using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace 自动测试
{
    public class 配置数据库
    {
        private static 配置数据库? _实例;
        private readonly string 数据库路径;

        public static 配置数据库 实例
        {
            get
            {
                _实例 ??= new 配置数据库();
                return _实例;
            }
        }

        private 配置数据库()
        {
            数据库路径 = Path.Combine(Application.StartupPath, "配置数据库.db");
            初始化数据库();
        }

        private void 初始化数据库()
        {
            using var 连接 = new SqliteConnection($"Data Source={数据库路径}");
            连接.Open();

            var 命令 = 连接.CreateCommand();
            命令.CommandText = @"
                CREATE TABLE IF NOT EXISTS 配置表 (
                    配置名 TEXT PRIMARY KEY,
                    创建日期 TEXT NOT NULL,
                    拼板数 INTEGER NOT NULL
                );

                CREATE TABLE IF NOT EXISTS 检测项表 (
                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                    配置名 TEXT NOT NULL,
                    排序 INTEGER NOT NULL,
                    名称 TEXT NOT NULL,
                    类型 TEXT NOT NULL,
                    延时 INTEGER NOT NULL,
                    最大值 TEXT,
                    最小值 TEXT,
                    设定值 TEXT,
                    启用 INTEGER NOT NULL,
                    拼版1地址 TEXT,
                    拼版2地址 TEXT,
                    拼版3地址 TEXT,
                    拼版4地址 TEXT,
                    拼版5地址 TEXT,
                    拼版6地址 TEXT,
                    拼版7地址 TEXT,
                    拼版8地址 TEXT,
                    拼版9地址 TEXT,
                    拼版10地址 TEXT,
                    拼版11地址 TEXT,
                    拼版12地址 TEXT,
                    拼版13地址 TEXT,
                    拼版14地址 TEXT,
                    拼版15地址 TEXT,
                    拼版16地址 TEXT,
                    拼版17地址 TEXT,
                    拼版18地址 TEXT,
                    拼版19地址 TEXT,
                    拼版20地址 TEXT,
                    拼版21地址 TEXT,
                    拼版22地址 TEXT,
                    拼版23地址 TEXT,
                    拼版24地址 TEXT,
                    拼版25地址 TEXT,
                    拼版26地址 TEXT,
                    拼版27地址 TEXT,
                    拼版28地址 TEXT,
                    拼版29地址 TEXT,
                    拼版30地址 TEXT,
                    拼版31地址 TEXT,
                    拼版32地址 TEXT,
                    FOREIGN KEY (配置名) REFERENCES 配置表(配置名)
                );
            ";
            命令.ExecuteNonQuery();
            
            for (int p = 1; p <= 32; p++)
            {
                try
                {
                    var 添加列命令 = 连接.CreateCommand();
                    添加列命令.CommandText = $"ALTER TABLE 检测项表 ADD COLUMN 拼版{p}地址 TEXT";
                    添加列命令.ExecuteNonQuery();
                }
                catch { }
            }
        }

        public List<string> 获取所有配置名()
        {
            var 列表 = new List<string>();
            using var 连接 = new SqliteConnection($"Data Source={数据库路径}");
            连接.Open();

            var 命令 = 连接.CreateCommand();
            命令.CommandText = "SELECT 配置名 FROM 配置表 ORDER BY 创建日期 DESC";

            using var 读取器 = 命令.ExecuteReader();
            while (读取器.Read())
            {
                列表.Add(读取器.GetString(0));
            }

            return 列表;
        }

        public 编辑配置窗体.配置项数据? 加载配置(string 配置名)
        {
            using var 连接 = new SqliteConnection($"Data Source={数据库路径}");
            连接.Open();

            var 命令 = 连接.CreateCommand();
            命令.CommandText = "SELECT 创建日期, 拼板数 FROM 配置表 WHERE 配置名 = $配置名";
            命令.Parameters.AddWithValue("$配置名", 配置名);

            using var 读取器 = 命令.ExecuteReader();
            if (!读取器.Read())
            {
                return null;
            }

            var 数据 = new 编辑配置窗体.配置项数据
            {
                配置名称 = 配置名,
                创建日期 = DateTime.Parse(读取器.GetString(0)),
                拼板数 = 读取器.GetInt32(1),
                检测项列表 = new List<编辑配置窗体.检测项数据>()
            };

            var 检测项命令 = 连接.CreateCommand();
            检测项命令.CommandText = "SELECT 排序, 名称, 类型, 延时, 最大值, 最小值, 设定值, 启用, 拼版1地址, 拼版2地址, 拼版3地址, 拼版4地址, 拼版5地址, 拼版6地址, 拼版7地址, 拼版8地址, 拼版9地址, 拼版10地址, 拼版11地址, 拼版12地址, 拼版13地址, 拼版14地址, 拼版15地址, 拼版16地址, 拼版17地址, 拼版18地址, 拼版19地址, 拼版20地址, 拼版21地址, 拼版22地址, 拼版23地址, 拼版24地址, 拼版25地址, 拼版26地址, 拼版27地址, 拼版28地址, 拼版29地址, 拼版30地址, 拼版31地址, 拼版32地址 FROM 检测项表 WHERE 配置名 = $配置名 ORDER BY 排序";
            检测项命令.Parameters.AddWithValue("$配置名", 配置名);

            using var 检测项读取器 = 检测项命令.ExecuteReader();
            while (检测项读取器.Read())
            {
                var 项 = new 编辑配置窗体.检测项数据
                {
                    排序 = 检测项读取器.GetInt32(0),
                    名称 = 检测项读取器.GetString(1),
                    类型 = 检测项读取器.GetString(2),
                    延时 = 检测项读取器.GetInt32(3),
                    最大值 = 检测项读取器.IsDBNull(4) ? "" : 检测项读取器.GetString(4),
                    最小值 = 检测项读取器.IsDBNull(5) ? "" : 检测项读取器.GetString(5),
                    设定值 = 检测项读取器.IsDBNull(6) ? "" : 检测项读取器.GetString(6),
                    启用 = 检测项读取器.GetInt32(7) == 1
                };
                
                for (int p = 1; p <= 32; p++)
                {
                    var 属性 = typeof(编辑配置窗体.检测项数据).GetProperty($"拼版{p}地址");
                    if (属性 != null && !检测项读取器.IsDBNull(7 + p))
                    {
                        属性.SetValue(项, 检测项读取器.GetString(7 + p));
                    }
                }
                
                数据.检测项列表.Add(项);
            }

            return 数据;
        }

        public void 保存配置(编辑配置窗体.配置项数据 数据)
        {
            using var 连接 = new SqliteConnection($"Data Source={数据库路径}");
            连接.Open();

            using var 事务 = 连接.BeginTransaction();

            try
            {
                var 删除检测项命令 = 连接.CreateCommand();
                删除检测项命令.CommandText = "DELETE FROM 检测项表 WHERE 配置名 = $配置名";
                删除检测项命令.Parameters.AddWithValue("$配置名", 数据.配置名称);
                删除检测项命令.ExecuteNonQuery();

                var 删除配置命令 = 连接.CreateCommand();
                删除配置命令.CommandText = "DELETE FROM 配置表 WHERE 配置名 = $配置名";
                删除配置命令.Parameters.AddWithValue("$配置名", 数据.配置名称);
                删除配置命令.ExecuteNonQuery();

                var 插入配置命令 = 连接.CreateCommand();
                插入配置命令.CommandText = "INSERT INTO 配置表 (配置名, 创建日期, 拼板数) VALUES ($配置名, $创建日期, $拼板数)";
                插入配置命令.Parameters.AddWithValue("$配置名", 数据.配置名称);
                插入配置命令.Parameters.AddWithValue("$创建日期", 数据.创建日期.ToString("yyyy-MM-dd HH:mm:ss"));
                插入配置命令.Parameters.AddWithValue("$拼板数", 数据.拼板数);
                插入配置命令.ExecuteNonQuery();

                foreach (var 项 in 数据.检测项列表)
                {
                    var 插入检测项命令 = 连接.CreateCommand();
                    插入检测项命令.CommandText = @"INSERT INTO 检测项表 (配置名, 排序, 名称, 类型, 延时, 最大值, 最小值, 设定值, 启用, 
                        拼版1地址, 拼版2地址, 拼版3地址, 拼版4地址, 拼版5地址, 拼版6地址, 拼版7地址, 拼版8地址, 
                        拼版9地址, 拼版10地址, 拼版11地址, 拼版12地址, 拼版13地址, 拼版14地址, 拼版15地址, 拼版16地址, 
                        拼版17地址, 拼版18地址, 拼版19地址, 拼版20地址, 拼版21地址, 拼版22地址, 拼版23地址, 拼版24地址, 
                        拼版25地址, 拼版26地址, 拼版27地址, 拼版28地址, 拼版29地址, 拼版30地址, 拼版31地址, 拼版32地址) 
                        VALUES ($配置名, $排序, $名称, $类型, $延时, $最大值, $最小值, $设定值, $启用, 
                        $拼版1地址, $拼版2地址, $拼版3地址, $拼版4地址, $拼版5地址, $拼版6地址, $拼版7地址, $拼版8地址, 
                        $拼版9地址, $拼版10地址, $拼版11地址, $拼版12地址, $拼版13地址, $拼版14地址, $拼版15地址, $拼版16地址, 
                        $拼版17地址, $拼版18地址, $拼版19地址, $拼版20地址, $拼版21地址, $拼版22地址, $拼版23地址, $拼版24地址, 
                        $拼版25地址, $拼版26地址, $拼版27地址, $拼版28地址, $拼版29地址, $拼版30地址, $拼版31地址, $拼版32地址)";
                    插入检测项命令.Parameters.AddWithValue("$配置名", 数据.配置名称);
                    插入检测项命令.Parameters.AddWithValue("$排序", 项.排序);
                    插入检测项命令.Parameters.AddWithValue("$名称", 项.名称);
                    插入检测项命令.Parameters.AddWithValue("$类型", 项.类型);
                    插入检测项命令.Parameters.AddWithValue("$延时", 项.延时);
                    插入检测项命令.Parameters.AddWithValue("$最大值", 项.最大值 ?? "");
                    插入检测项命令.Parameters.AddWithValue("$最小值", 项.最小值 ?? "");
                    插入检测项命令.Parameters.AddWithValue("$设定值", 项.设定值 ?? "");
                    插入检测项命令.Parameters.AddWithValue("$启用", 项.启用 ? 1 : 0);
                    
                    for (int p = 1; p <= 32; p++)
                    {
                        var 属性 = typeof(编辑配置窗体.检测项数据).GetProperty($"拼版{p}地址");
                        string 地址 = 属性?.GetValue(项)?.ToString() ?? "";
                        插入检测项命令.Parameters.AddWithValue($"$拼版{p}地址", 地址);
                    }
                    
                    插入检测项命令.ExecuteNonQuery();
                }

                事务.Commit();
            }
            catch
            {
                事务.Rollback();
                throw;
            }
        }

        public void 删除配置(string 配置名)
        {
            using var 连接 = new SqliteConnection($"Data Source={数据库路径}");
            连接.Open();

            using var 事务 = 连接.BeginTransaction();

            try
            {
                var 删除检测项命令 = 连接.CreateCommand();
                删除检测项命令.CommandText = "DELETE FROM 检测项表 WHERE 配置名 = $配置名";
                删除检测项命令.Parameters.AddWithValue("$配置名", 配置名);
                删除检测项命令.ExecuteNonQuery();

                var 删除配置命令 = 连接.CreateCommand();
                删除配置命令.CommandText = "DELETE FROM 配置表 WHERE 配置名 = $配置名";
                删除配置命令.Parameters.AddWithValue("$配置名", 配置名);
                删除配置命令.ExecuteNonQuery();

                事务.Commit();
            }
            catch
            {
                事务.Rollback();
                throw;
            }
        }

        public bool 配置是否存在(string 配置名)
        {
            using var 连接 = new SqliteConnection($"Data Source={数据库路径}");
            连接.Open();

            var 命令 = 连接.CreateCommand();
            命令.CommandText = "SELECT COUNT(*) FROM 配置表 WHERE 配置名 = $配置名";
            命令.Parameters.AddWithValue("$配置名", 配置名);

            var 结果 = 命令.ExecuteScalar();
            return Convert.ToInt32(结果) > 0;
        }
    }
}