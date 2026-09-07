using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Microsoft.Data.Sqlite;

namespace 自动测试
{
    public enum 权限等级
    {
        员工 = 0,
        管理员 = 1,
        厂家 = 2
    }

    public enum 日志类别
    {
        配置操作,
        测试操作,
        系统操作,
        用户操作,
        硬件操作,
        数据操作,
        调试操作
    }

    public static class 日志管理器
    {
        private static readonly string 数据库路径 = Path.Combine(Application.StartupPath, "操作日志.db");
        private static 权限等级 当前权限 = 权限等级.管理员;

        public static 权限等级 当前用户权限
        {
            get => 当前权限;
            set
            {
                if (当前权限 != value)
                {
                    string 旧权限 = 当前权限.ToString();
                    当前权限 = value;
                    记录(日志类别.用户操作, "权限切换", $"{旧权限} → {value}", 权限等级.厂家);
                }
            }
        }

        public static void 初始化()
        {
            using var 连接 = new SqliteConnection($"Data Source={数据库路径}");
            连接.Open();

            var 命令 = 连接.CreateCommand();
            命令.CommandText = @"
                CREATE TABLE IF NOT EXISTS 操作日志表 (
                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                    时间 TEXT NOT NULL,
                    类别 TEXT NOT NULL,
                    操作 TEXT NOT NULL,
                    详情 TEXT,
                    用户 TEXT,
                    权限要求 TEXT NOT NULL
                );
                CREATE INDEX IF NOT EXISTS idx_时间 ON 操作日志表(时间);
                CREATE INDEX IF NOT EXISTS idx_类别 ON 操作日志表(类别);
            ";
            命令.ExecuteNonQuery();
        }

        public static void 记录(日志类别 类别, string 操作, string 详情 = "", 权限等级 最低可见权限 = 权限等级.管理员)
        {
            try
            {
                using var 连接 = new SqliteConnection($"Data Source={数据库路径}");
                连接.Open();

                var 命令 = 连接.CreateCommand();
                命令.CommandText = @"
                    INSERT INTO 操作日志表 (时间, 类别, 操作, 详情, 用户, 权限要求) 
                    VALUES ($时间, $类别, $操作, $详情, $用户, $权限要求)";
                命令.Parameters.AddWithValue("$时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                命令.Parameters.AddWithValue("$类别", 类别.ToString());
                命令.Parameters.AddWithValue("$操作", 操作);
                命令.Parameters.AddWithValue("$详情", 详情 ?? "");
                命令.Parameters.AddWithValue("$用户", Environment.UserName);
                命令.Parameters.AddWithValue("$权限要求", 最低可见权限.ToString());
                命令.ExecuteNonQuery();
            }
            catch { }
        }

        public static List<日志记录> 查询(权限等级 可见权限, string? 类别筛选 = null, DateTime? 起始时间 = null, DateTime? 结束时间 = null, string? 关键词 = null, int 限制条数 = 1000)
        {
            var 列表 = new List<日志记录>();

            try
            {
                using var 连接 = new SqliteConnection($"Data Source={数据库路径}");
                连接.Open();

                string 权限条件 = 可见权限 switch
                {
                    权限等级.厂家 => "",
                    权限等级.管理员 => "AND 权限要求 IN ('管理员', '员工')",
                    _ => "AND 权限要求 = '员工'"
                };

                string 条件 = $"WHERE 1=1 {权限条件}";
                if (!string.IsNullOrEmpty(类别筛选)) 条件 += $" AND 类别 = $类别";
                if (起始时间.HasValue) 条件 += $" AND 时间 >= $起始时间";
                if (结束时间.HasValue) 条件 += $" AND 时间 <= $结束时间";
                if (!string.IsNullOrEmpty(关键词)) 条件 += $" AND (操作 LIKE $关键词 OR 详情 LIKE $关键词)";

                var 命令 = 连接.CreateCommand();
                命令.CommandText = $"SELECT ID, 时间, 类别, 操作, 详情, 用户, 权限要求 FROM 操作日志表 {条件} ORDER BY ID DESC LIMIT $限制";
                命令.Parameters.AddWithValue("$限制", 限制条数);

                if (!string.IsNullOrEmpty(类别筛选)) 命令.Parameters.AddWithValue("$类别", 类别筛选);
                if (起始时间.HasValue) 命令.Parameters.AddWithValue("$起始时间", 起始时间.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                if (结束时间.HasValue) 命令.Parameters.AddWithValue("$结束时间", 结束时间.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                if (!string.IsNullOrEmpty(关键词)) 命令.Parameters.AddWithValue("$关键词", $"%{关键词}%");

                using var 读取器 = 命令.ExecuteReader();
                while (读取器.Read())
                {
                    列表.Add(new 日志记录
                    {
                        ID = 读取器.GetInt32(0),
                        时间 = 读取器.GetString(1),
                        类别 = 读取器.GetString(2),
                        操作 = 读取器.GetString(3),
                        详情 = 读取器.IsDBNull(4) ? "" : 读取器.GetString(4),
                        用户 = 读取器.IsDBNull(5) ? "" : 读取器.GetString(5),
                        权限要求 = 读取器.GetString(6)
                    });
                }
            }
            catch { }

            return 列表;
        }

        public static void 清空日志(DateTime? 之前 = null)
        {
            using var 连接 = new SqliteConnection($"Data Source={数据库路径}");
            连接.Open();

            var 命令 = 连接.CreateCommand();
            if (之前.HasValue)
            {
                命令.CommandText = "DELETE FROM 操作日志表 WHERE 时间 < $时间";
                命令.Parameters.AddWithValue("$时间", 之前.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else
            {
                命令.CommandText = "DELETE FROM 操作日志表";
            }
            命令.ExecuteNonQuery();
        }
    }

    public class 日志记录
    {
        public int ID { get; set; }
        public string 时间 { get; set; } = "";
        public string 类别 { get; set; } = "";
        public string 操作 { get; set; } = "";
        public string 详情 { get; set; } = "";
        public string 用户 { get; set; } = "";
        public string 权限要求 { get; set; } = "";
    }
}