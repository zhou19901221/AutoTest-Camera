using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using Microsoft.Data.Sqlite;

namespace 自动测试
{
    public class 用户信息
    {
        public int Id { get; set; }
        public string 用户名 { get; set; } = "";
        public 权限等级 权限 { get; set; } = 权限等级.员工;
        public bool 启用 { get; set; } = true;
        public DateTime 创建时间 { get; set; }
        public DateTime 更新时间 { get; set; }
    }

    public static class 用户管理器
    {
        private static readonly string 数据库路径 = Path.Combine(Application.StartupPath, "用户管理.db");

        public static void 初始化()
        {
            using var 连接 = new SqliteConnection($"Data Source={数据库路径}");
            连接.Open();

            var 命令 = 连接.CreateCommand();
            命令.CommandText = @"
                CREATE TABLE IF NOT EXISTS 用户表 (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    用户名 TEXT NOT NULL UNIQUE,
                    密码哈希 TEXT NOT NULL,
                    密码盐值 TEXT NOT NULL,
                    权限 INTEGER NOT NULL,
                    启用 INTEGER NOT NULL DEFAULT 1,
                    创建时间 TEXT NOT NULL,
                    更新时间 TEXT NOT NULL
                );
                CREATE INDEX IF NOT EXISTS idx_用户名 ON 用户表(用户名);
            ";
            命令.ExecuteNonQuery();

            确保默认管理员();
        }

        private static void 确保默认管理员()
        {
            using var 连接 = new SqliteConnection($"Data Source={数据库路径}");
            连接.Open();

            var 查询 = 连接.CreateCommand();
            查询.CommandText = "SELECT COUNT(1) FROM 用户表";
            long 数量 = (long)(查询.ExecuteScalar() ?? 0L);
            if (数量 > 0) return;

            _ = 新增用户("admin", "admin123", 权限等级.厂家, out _);
        }

        public static bool 验证登录(string 用户名, string 密码, out 用户信息? 用户)
        {
            用户 = null;
            if (string.IsNullOrWhiteSpace(用户名) || string.IsNullOrWhiteSpace(密码)) return false;

            using var 连接 = new SqliteConnection($"Data Source={数据库路径}");
            连接.Open();

            var 命令 = 连接.CreateCommand();
            命令.CommandText = @"SELECT Id, 用户名, 密码哈希, 密码盐值, 权限, 启用, 创建时间, 更新时间
                               FROM 用户表 WHERE 用户名 = $用户名 COLLATE NOCASE LIMIT 1";
            命令.Parameters.AddWithValue("$用户名", 用户名.Trim());

            using var 读取器 = 命令.ExecuteReader();
            if (!读取器.Read()) return false;

            bool 启用 = 读取器.GetInt32(5) == 1;
            if (!启用) return false;

            string 哈希 = 读取器.GetString(2);
            string 盐值 = 读取器.GetString(3);
            if (!验证密码(密码, 哈希, 盐值)) return false;

            用户 = new 用户信息
            {
                Id = 读取器.GetInt32(0),
                用户名 = 读取器.GetString(1),
                权限 = (权限等级)读取器.GetInt32(4),
                启用 = 启用,
                创建时间 = DateTime.TryParse(读取器.GetString(6), out var ct) ? ct : DateTime.MinValue,
                更新时间 = DateTime.TryParse(读取器.GetString(7), out var ut) ? ut : DateTime.MinValue
            };

            return true;
        }

        public static List<用户信息> 获取用户列表()
        {
            var 列表 = new List<用户信息>();

            using var 连接 = new SqliteConnection($"Data Source={数据库路径}");
            连接.Open();

            var 命令 = 连接.CreateCommand();
            命令.CommandText = "SELECT Id, 用户名, 权限, 启用, 创建时间, 更新时间 FROM 用户表 ORDER BY Id";

            using var 读取器 = 命令.ExecuteReader();
            while (读取器.Read())
            {
                列表.Add(new 用户信息
                {
                    Id = 读取器.GetInt32(0),
                    用户名 = 读取器.GetString(1),
                    权限 = (权限等级)读取器.GetInt32(2),
                    启用 = 读取器.GetInt32(3) == 1,
                    创建时间 = DateTime.TryParse(读取器.GetString(4), out var ct) ? ct : DateTime.MinValue,
                    更新时间 = DateTime.TryParse(读取器.GetString(5), out var ut) ? ut : DateTime.MinValue
                });
            }

            return 列表;
        }

        public static bool 新增用户(string 用户名, string 密码, 权限等级 权限, out string 错误)
        {
            错误 = "";
            if (string.IsNullOrWhiteSpace(用户名))
            {
                错误 = "用户名不能为空";
                return false;
            }
            if (string.IsNullOrWhiteSpace(密码) || 密码.Length < 6)
            {
                错误 = "密码至少6位";
                return false;
            }

            string 用户名规范 = 用户名.Trim();
            if (用户名规范.Equals("admin", StringComparison.OrdinalIgnoreCase) && 权限 != 权限等级.厂家)
            {
                错误 = "admin 用户必须为厂家权限";
                return false;
            }

            var (哈希, 盐值) = 生成密码哈希(密码);
            string 现在 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            try
            {
                using var 连接 = new SqliteConnection($"Data Source={数据库路径}");
                连接.Open();

                var 命令 = 连接.CreateCommand();
                命令.CommandText = @"INSERT INTO 用户表 (用户名, 密码哈希, 密码盐值, 权限, 启用, 创建时间, 更新时间)
                                   VALUES ($用户名, $哈希, $盐值, $权限, 1, $创建时间, $更新时间)";
                命令.Parameters.AddWithValue("$用户名", 用户名规范);
                命令.Parameters.AddWithValue("$哈希", 哈希);
                命令.Parameters.AddWithValue("$盐值", 盐值);
                命令.Parameters.AddWithValue("$权限", (int)权限);
                命令.Parameters.AddWithValue("$创建时间", 现在);
                命令.Parameters.AddWithValue("$更新时间", 现在);
                命令.ExecuteNonQuery();

                return true;
            }
            catch (SqliteException ex) when (ex.SqliteErrorCode == 19)
            {
                错误 = "用户名已存在";
                return false;
            }
            catch (Exception ex)
            {
                错误 = ex.Message;
                return false;
            }
        }

        public static bool 更新用户权限(int 用户Id, 权限等级 权限, out string 错误)
        {
            错误 = "";
            using var 连接 = new SqliteConnection($"Data Source={数据库路径}");
            连接.Open();

            var 查询 = 连接.CreateCommand();
            查询.CommandText = "SELECT 用户名 FROM 用户表 WHERE Id = $Id";
            查询.Parameters.AddWithValue("$Id", 用户Id);
            var 用户名 = 查询.ExecuteScalar()?.ToString() ?? "";

            if (string.IsNullOrEmpty(用户名))
            {
                错误 = "用户不存在";
                return false;
            }
            if (用户名.Equals("admin", StringComparison.OrdinalIgnoreCase) && 权限 != 权限等级.厂家)
            {
                错误 = "admin 用户权限不可降级";
                return false;
            }

            var 命令 = 连接.CreateCommand();
            命令.CommandText = "UPDATE 用户表 SET 权限 = $权限, 更新时间 = $更新时间 WHERE Id = $Id";
            命令.Parameters.AddWithValue("$权限", (int)权限);
            命令.Parameters.AddWithValue("$更新时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            命令.Parameters.AddWithValue("$Id", 用户Id);
            return 命令.ExecuteNonQuery() > 0;
        }

        public static bool 重置密码(int 用户Id, string 新密码, out string 错误)
        {
            错误 = "";
            if (string.IsNullOrWhiteSpace(新密码) || 新密码.Length < 6)
            {
                错误 = "密码至少6位";
                return false;
            }

            var (哈希, 盐值) = 生成密码哈希(新密码);

            using var 连接 = new SqliteConnection($"Data Source={数据库路径}");
            连接.Open();

            var 命令 = 连接.CreateCommand();
            命令.CommandText = "UPDATE 用户表 SET 密码哈希 = $哈希, 密码盐值 = $盐值, 更新时间 = $更新时间 WHERE Id = $Id";
            命令.Parameters.AddWithValue("$哈希", 哈希);
            命令.Parameters.AddWithValue("$盐值", 盐值);
            命令.Parameters.AddWithValue("$更新时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            命令.Parameters.AddWithValue("$Id", 用户Id);

            if (命令.ExecuteNonQuery() <= 0)
            {
                错误 = "用户不存在";
                return false;
            }

            return true;
        }

        public static bool 设置启用状态(int 用户Id, bool 启用, out string 错误)
        {
            错误 = "";
            using var 连接 = new SqliteConnection($"Data Source={数据库路径}");
            连接.Open();

            var 查询 = 连接.CreateCommand();
            查询.CommandText = "SELECT 用户名 FROM 用户表 WHERE Id = $Id";
            查询.Parameters.AddWithValue("$Id", 用户Id);
            var 用户名 = 查询.ExecuteScalar()?.ToString() ?? "";

            if (string.IsNullOrEmpty(用户名))
            {
                错误 = "用户不存在";
                return false;
            }
            if (用户名.Equals("admin", StringComparison.OrdinalIgnoreCase) && !启用)
            {
                错误 = "admin 用户不可禁用";
                return false;
            }

            var 命令 = 连接.CreateCommand();
            命令.CommandText = "UPDATE 用户表 SET 启用 = $启用, 更新时间 = $更新时间 WHERE Id = $Id";
            命令.Parameters.AddWithValue("$启用", 启用 ? 1 : 0);
            命令.Parameters.AddWithValue("$更新时间", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            命令.Parameters.AddWithValue("$Id", 用户Id);
            return 命令.ExecuteNonQuery() > 0;
        }

        public static bool 删除用户(int 用户Id, out string 错误)
        {
            错误 = "";
            using var 连接 = new SqliteConnection($"Data Source={数据库路径}");
            连接.Open();

            var 查询 = 连接.CreateCommand();
            查询.CommandText = "SELECT 用户名 FROM 用户表 WHERE Id = $Id";
            查询.Parameters.AddWithValue("$Id", 用户Id);
            var 用户名 = 查询.ExecuteScalar()?.ToString() ?? "";

            if (string.IsNullOrEmpty(用户名))
            {
                错误 = "用户不存在";
                return false;
            }
            if (用户名.Equals("admin", StringComparison.OrdinalIgnoreCase))
            {
                错误 = "admin 用户不可删除";
                return false;
            }

            var 命令 = 连接.CreateCommand();
            命令.CommandText = "DELETE FROM 用户表 WHERE Id = $Id";
            命令.Parameters.AddWithValue("$Id", 用户Id);
            return 命令.ExecuteNonQuery() > 0;
        }

        private static (string 哈希, string 盐值) 生成密码哈希(string 明文密码)
        {
            byte[] 盐值字节 = RandomNumberGenerator.GetBytes(16);
            byte[] 哈希字节 = Rfc2898DeriveBytes.Pbkdf2(明文密码, 盐值字节, 100_000, HashAlgorithmName.SHA256, 32);
            return (Convert.ToBase64String(哈希字节), Convert.ToBase64String(盐值字节));
        }

        private static bool 验证密码(string 明文密码, string 存储哈希, string 存储盐值)
        {
            try
            {
                byte[] 盐值字节 = Convert.FromBase64String(存储盐值);
                byte[] 计算哈希 = Rfc2898DeriveBytes.Pbkdf2(明文密码, 盐值字节, 100_000, HashAlgorithmName.SHA256, 32);
                byte[] 存储哈希字节 = Convert.FromBase64String(存储哈希);
                return CryptographicOperations.FixedTimeEquals(计算哈希, 存储哈希字节);
            }
            catch
            {
                return false;
            }
        }
    }
}
