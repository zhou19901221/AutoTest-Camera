using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Text.Json;
using System.Threading;
using System.Globalization;

namespace 自动测试
{
    internal static class MES上传服务
    {
        private static readonly Regex 安全标识符正则 = new Regex(@"^[A-Za-z_][A-Za-z0-9_]*$", RegexOptions.Compiled);
        private static readonly object 缓存锁 = new object();
        private static readonly string 缓存文件路径 = Path.Combine(AppContext.BaseDirectory, "mes_upload_cache.json");
        private static readonly JsonSerializerOptions 缓存序列化选项 = new JsonSerializerOptions { WriteIndented = false };
        private static System.Threading.Timer? 缓存重传定时器;
        private static Action<string>? 日志输出;
        private static int 正在重传缓存;

        private class 缓存记录
        {
            public string SerialNo { get; set; } = "";
            public string CheckStatus { get; set; } = "";
            public string CheckStation { get; set; } = "";
            public string PCBVer { get; set; } = "";
            public string Mac { get; set; } = "";
            public DateTime RecordTime { get; set; }
            public DateTime EndTime { get; set; }
            public DateTime CacheTime { get; set; }
        }

        private static bool Try构造安全表名(string 原始表名, out string 安全表名)
        {
            安全表名 = string.Empty;
            if (string.IsNullOrWhiteSpace(原始表名)) return false;

            string 表名文本 = 原始表名.Trim();
            string[] 片段 = 表名文本.Split('.');
            if (片段.Length is < 1 or > 2) return false;

            foreach (var 片段项 in 片段)
            {
                if (!安全标识符正则.IsMatch(片段项)) return false;
            }

            安全表名 = 片段.Length == 2
                ? $"[{片段[0]}].[{片段[1]}]"
                : $"[dbo].[{片段[0]}]";
            return true;
        }

        public static bool 尝试上传结果(
            string serialNo,
            string checkStatus,
            string checkStation,
            string pcbVer,
            string mac,
            DateTime? recordTime,
            DateTime? endTime,
            Action<string>? log)
        {
            日志输出 = log;
            启动缓存自动重传();

            DateTime 开始时间 = recordTime ?? DateTime.Now;
            DateTime 结束时间 = endTime ?? DateTime.Now;
            var 记录 = new 缓存记录
            {
                SerialNo = serialNo,
                CheckStatus = checkStatus,
                CheckStation = checkStation,
                PCBVer = pcbVer,
                Mac = mac,
                RecordTime = 开始时间,
                EndTime = 结束时间,
                CacheTime = DateTime.Now
            };

            try
            {
                var mes = 系统配置管理.实例.MESS设置;
                if (!mes.MESS功能开启)
                {
                    return false;
                }

                if (string.IsNullOrWhiteSpace(mes.SQL服务器地址)
                    || string.IsNullOrWhiteSpace(mes.SQL账号)
                    || string.IsNullOrWhiteSpace(mes.SQL数据库)
                    || string.IsNullOrWhiteSpace(mes.SQL数据表))
                {
                    log?.Invoke("MES上传跳过：SQL参数未完整配置。");
                    return false;
                }

                if (!Try上传到数据库(记录, mes, log))
                {
                    缓存上传记录(记录, log);
                    return false;
                }

                尝试重传缓存(log);
                return true;
            }
            catch (Exception ex)
            {
                缓存上传记录(记录, log);
                log?.Invoke($"MES上传异常：{ex.Message}");
                return false;
            }
        }

        private static bool Try上传到数据库(缓存记录 记录, MESS设置类 mes, Action<string>? log)
        {
            try
            {
                string 入库Mac = 记录.Mac ?? string.Empty;
                if (!Try规范化Mac(入库Mac, out string 规范Mac, out string 原因))
                {
                    if (!string.IsNullOrWhiteSpace(入库Mac))
                    {
                        log?.Invoke($"MES上传提示：MAC不符合规则（{原因}），已置空。原值={入库Mac}");
                    }
                    入库Mac = string.Empty;
                }
                else
                {
                    入库Mac = 规范Mac;
                }

                string server = mes.SQL端口 > 0
                    ? $"{mes.SQL服务器地址},{mes.SQL端口}"
                    : mes.SQL服务器地址;

                var csb = new SqlConnectionStringBuilder
                {
                    DataSource = server,
                    InitialCatalog = mes.SQL数据库,
                    UserID = mes.SQL账号,
                    Password = mes.SQL密码,
                    TrustServerCertificate = true,
                    Encrypt = false,
                    ConnectTimeout = 5,
                    IntegratedSecurity = false
                };

                if (!Try构造安全表名(mes.SQL数据表, out string 安全表名))
                {
                    log?.Invoke("MES上传跳过：SQL数据表名不合法。仅允许 schema.table 或 table。");
                    return false;
                }

                string sql = $@"INSERT INTO {安全表名}
([SerialNo],[RecordTime],[CheckStatus],[CheckStation],[PCBVer],[Mac],[itime])
VALUES
(@SerialNo,@RecordTime,@CheckStatus,@CheckStation,@PCBVer,@Mac,@itime);";

                using var conn = new SqlConnection(csb.ConnectionString);
                conn.Open();
                using var cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@SerialNo", (object?)记录.SerialNo ?? string.Empty);
                cmd.Parameters.AddWithValue("@RecordTime", 记录.RecordTime.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                cmd.Parameters.AddWithValue("@CheckStatus", (object?)记录.CheckStatus ?? string.Empty);
                cmd.Parameters.AddWithValue("@CheckStation", (object?)记录.CheckStation ?? string.Empty);
                cmd.Parameters.AddWithValue("@PCBVer", (object?)记录.PCBVer ?? string.Empty);
                cmd.Parameters.AddWithValue("@Mac", 入库Mac);
                cmd.Parameters.AddWithValue("@itime", 记录.EndTime);

                int rows = cmd.ExecuteNonQuery();
                bool ok = rows > 0;
                log?.Invoke(ok
                    ? $"MES上传成功：SN={记录.SerialNo} 状态={记录.CheckStatus}"
                    : $"MES上传失败：SN={记录.SerialNo} 状态={记录.CheckStatus}");
                return ok;
            }
            catch (Exception ex)
            {
                log?.Invoke($"MES上传异常：{ex.Message}");
                return false;
            }
        }

        private static bool Try规范化Mac(string mac原文, out string mac规范, out string 原因)
        {
            mac规范 = string.Empty;
            原因 = string.Empty;

            if (string.IsNullOrWhiteSpace(mac原文))
            {
                原因 = "空值";
                return false;
            }

            string 文本 = mac原文.Trim()
                .Replace('：', ':')
                .Replace('-', ':');

            string[] 段 = 文本.Split(':', StringSplitOptions.RemoveEmptyEntries);
            if (段.Length != 6)
            {
                原因 = "段数不是6";
                return false;
            }

            var 规范段 = new string[6];
            for (int i = 0; i < 段.Length; i++)
            {
                string s = 段[i].Trim();
                if (s.Length is < 1 or > 2)
                {
                    原因 = $"第{i + 1}段长度非法";
                    return false;
                }

                if (!byte.TryParse(s, NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture, out byte b))
                {
                    原因 = $"第{i + 1}段非十六进制";
                    return false;
                }

                规范段[i] = b.ToString("X2");
            }

            if (规范段.All(x => x == "00"))
            {
                原因 = "全0地址";
                return false;
            }

            if (规范段.All(x => x == "FF"))
            {
                原因 = "全F地址";
                return false;
            }

            byte 首字节 = byte.Parse(规范段[0], NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture);
            if ((首字节 & 0x01) == 0x01)
            {
                原因 = "组播地址";
                return false;
            }

            mac规范 = string.Join(":", 规范段);
            return true;
        }

        private static void 缓存上传记录(缓存记录 记录, Action<string>? log)
        {
            try
            {
                lock (缓存锁)
                {
                    var 列表 = 读取缓存列表_加锁内();
                    列表.Add(记录);
                    写入缓存列表_加锁内(列表);
                }

                log?.Invoke($"MES离线缓存成功：SN={记录.SerialNo} 状态={记录.CheckStatus}");
            }
            catch (Exception ex)
            {
                log?.Invoke($"MES离线缓存失败：{ex.Message}");
            }
        }

        private static void 启动缓存自动重传()
        {
            if (缓存重传定时器 != null) return;

            lock (缓存锁)
            {
                if (缓存重传定时器 != null) return;
                缓存重传定时器 = new System.Threading.Timer(_ => 尝试重传缓存(日志输出), null, TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(10));
            }
        }

        private static void 尝试重传缓存(Action<string>? log)
        {
            if (Interlocked.CompareExchange(ref 正在重传缓存, 1, 0) != 0)
                return;

            try
            {
                var mes = 系统配置管理.实例.MESS设置;
                if (!mes.MESS功能开启)
                    return;

                while (true)
                {
                    缓存记录? 首条 = null;
                    lock (缓存锁)
                    {
                        var 列表 = 读取缓存列表_加锁内();
                        if (列表.Count == 0)
                            break;
                        首条 = 列表[0];
                    }

                    if (首条 == null)
                        break;

                    if (!Try上传到数据库(首条, mes, log))
                        break;

                    lock (缓存锁)
                    {
                        var 列表 = 读取缓存列表_加锁内();
                        if (列表.Count > 0)
                        {
                            列表.RemoveAt(0);
                            写入缓存列表_加锁内(列表);
                        }
                    }

                    log?.Invoke($"MES缓存续传成功：SN={首条.SerialNo}");
                }
            }
            finally
            {
                Interlocked.Exchange(ref 正在重传缓存, 0);
            }
        }

        private static List<缓存记录> 读取缓存列表_加锁内()
        {
            if (!File.Exists(缓存文件路径))
                return new List<缓存记录>();

            try
            {
                string json = File.ReadAllText(缓存文件路径);
                return JsonSerializer.Deserialize<List<缓存记录>>(json, 缓存序列化选项) ?? new List<缓存记录>();
            }
            catch
            {
                return new List<缓存记录>();
            }
        }

        private static void 写入缓存列表_加锁内(List<缓存记录> 列表)
        {
            if (列表.Count == 0)
            {
                if (File.Exists(缓存文件路径))
                    File.Delete(缓存文件路径);
                return;
            }

            string json = JsonSerializer.Serialize(列表, 缓存序列化选项);
            File.WriteAllText(缓存文件路径, json);
        }
    }
}
