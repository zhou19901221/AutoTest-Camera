using System;
using System.IO.Ports;
using System.Text;
using System.Threading;

namespace 自动测试
{
    // 简单的串口封装，提供打开/关闭/发送和接收事件
    public class 串口管理器 : IDisposable
    {
        private SerialPort _port;
        private readonly object _sync = new object();
        // 控制是否由管理器内部在 DataReceived 事件中读取并分发数据
        private bool _内部接收使能 = true;

        public event Action<byte[]> 数据接收;
        public event Action<Exception> 异常发生;

        public bool IsOpen => _port != null && _port.IsOpen;

        // 返回底层 SerialPort 供上层复用（可能为 null）
        public SerialPort 获取底层串口()
        {
            try
            {
                lock (_sync)
                {
                    return _port;
                }
            }
            catch { return null; }
        }

        // 启用或禁用管理器内部的 DataReceived 读取逻辑
        public void 设置内部接收使能(bool enabled)
        {
            try { lock (_sync) { _内部接收使能 = enabled; } } catch { }
        }

        public string[] 获取串口列表()
        {
            try
            {
                return SerialPort.GetPortNames();
            }
            catch (Exception ex)
            {
                异常发生?.Invoke(ex);
                return Array.Empty<string>();
            }
        }

        public bool 打开(string 端口名, int 波特率 = 115200, Parity 校验 = Parity.None, int 数据位 = 8, StopBits 停止位 = StopBits.One)
        {
            try
            {
                lock (_sync)
                {
                    if (_port != null && _port.IsOpen) _port.Close();

                    _port = new SerialPort(端口名, 波特率, 校验, 数据位, 停止位);
                    _port.Encoding = Encoding.UTF8;
                    _port.ReadTimeout = 500;
                    _port.WriteTimeout = 500;
                    _port.DataReceived += Port_DataReceived;
                    _port.Open();
                }
                return true;
            }
            catch (Exception ex)
            {
                异常发生?.Invoke(ex);
                return false;
            }
        }

        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                lock (_sync)
                {
                    if (!_内部接收使能) return;
                    if (_port == null || !_port.IsOpen) return;
                    int count = _port.BytesToRead;
                    if (count <= 0) return;
                    byte[] buffer = new byte[count];
                    int read = _port.Read(buffer, 0, count);
                    if (read > 0)
                    {
                        数据接收?.Invoke(buffer);
                    }
                }
            }
            catch (Exception ex)
            {
                异常发生?.Invoke(ex);
            }
        }

        public void 发送字节(byte[] 数据)
        {
            try
            {
                lock (_sync)
                {
                    if (_port == null || !_port.IsOpen) throw new InvalidOperationException("串口未打开");
                    _port.Write(数据, 0, 数据.Length);
                }
            }
            catch (Exception ex)
            {
                异常发生?.Invoke(ex);
            }
        }

        public void 发送文本(string 文本, Encoding 编码 = null)
        {
            try
            {
                if (编码 == null) 编码 = Encoding.UTF8;
                var bytes = 编码.GetBytes(文本);
                发送字节(bytes);
            }
            catch (Exception ex)
            {
                异常发生?.Invoke(ex);
            }
        }

        public void 关闭()
        {
            try
            {
                lock (_sync)
                {
                    if (_port != null)
                    {
                        try { _port.DataReceived -= Port_DataReceived; } catch { }
                        try { if (_port.IsOpen) _port.Close(); } catch { }
                        try { _port.Dispose(); } catch { }
                        _port = null;
                    }
                }
            }
            catch (Exception ex)
            {
                异常发生?.Invoke(ex);
            }
        }

        public void Dispose()
        {
            关闭();
            GC.SuppressFinalize(this);
        }
    }
}
