using System;
using System.IO.Ports;

namespace 自动测试
{
    public class 永鹏电源控制 : IDisposable
    {
        public byte 站地址 = 1;
        private readonly SerialPort 串口 = new SerialPort();
        public bool 已连接 => 串口.IsOpen;

        public const ushort 寄存器工作状态 = 0x0000;
        public const ushort 寄存器输出频率 = 0x0001;
        public const ushort 寄存器输出电压 = 0x0002;
        public const ushort 寄存器输出电流高字 = 0x0003;
        public const ushort 寄存器输出有功功率高字 = 0x0005;
        public const ushort 寄存器设置频率 = 0x0009;
        public const ushort 寄存器设置电压 = 0x000A;
        public const ushort 寄存器控制命令 = 0x000B;

        public const ushort 控制命令停止输出 = 0x0000;
        public const ushort 控制命令启动输出 = 0x0001;

        public void 连接(string 端口名, int 波特率)
        {
            if (串口.IsOpen) 串口.Close();
            串口.PortName = 端口名;
            串口.BaudRate = 波特率 > 0 ? 波特率 : 9600;
            串口.DataBits = 8;
            串口.Parity = Parity.None;
            串口.StopBits = StopBits.One;
            串口.ReadTimeout = 1000;
            串口.WriteTimeout = 1000;
            串口.Open();
        }

        public void 断开()
        {
            if (串口.IsOpen) 串口.Close();
        }

        public void Dispose() => 断开();

        public ushort[] 读保持寄存器(ushort 地址, ushort 数量)
        {
            byte[] 帧 = new byte[8];
            帧[0] = 站地址;
            帧[1] = 0x03;
            帧[2] = (byte)(地址 >> 8);
            帧[3] = (byte)地址;
            帧[4] = (byte)(数量 >> 8);
            帧[5] = (byte)数量;
            byte[] 响应 = 执行事务(帧, 5 + 2 * 数量);
            if (响应[1] != 0x03) throw new InvalidOperationException($"永鹏电源读寄存器异常 功能码:{响应[1]:X2} 码:{响应[2]:X2}");

            var 结果 = new ushort[数量];
            for (int i = 0; i < 数量; i++)
            {
                结果[i] = (ushort)((响应[3 + 2 * i] << 8) | 响应[4 + 2 * i]);
            }
            return 结果;
        }

        public void 写单寄存器(ushort 地址, ushort 值)
        {
            byte[] 帧 = new byte[8];
            帧[0] = 站地址;
            帧[1] = 0x06;
            帧[2] = (byte)(地址 >> 8);
            帧[3] = (byte)地址;
            帧[4] = (byte)(值 >> 8);
            帧[5] = (byte)值;
            byte[] 响应 = 执行事务(帧, 8);
            if (响应[1] != 0x06) throw new InvalidOperationException($"永鹏电源写寄存器异常 功能码:{响应[1]:X2} 码:{响应[2]:X2}");
        }

        public void 启动电源() => 写单寄存器(寄存器控制命令, 控制命令启动输出);

        public void 停止电源() => 写单寄存器(寄存器控制命令, 控制命令停止输出);

        public void 设置频率(float 频率Hz)
        {
            ushort 值 = (ushort)Math.Clamp((int)Math.Round(频率Hz * 10.0f), 0, 65535);
            写单寄存器(寄存器设置频率, 值);
        }

        public void 设置电压(float 电压V)
        {
            ushort 值 = (ushort)Math.Clamp((int)Math.Round(电压V * 10.0f), 0, 65535);
            写单寄存器(寄存器设置电压, 值);
        }

        public ushort 读工作状态() => 读保持寄存器(寄存器工作状态, 1)[0];

        public float 读输出频率() => 读保持寄存器(寄存器输出频率, 1)[0] / 10.0f;

        public float 读输出电压() => 读保持寄存器(寄存器输出电压, 1)[0] / 10.0f;

        public float 读输出电流()
        {
            ushort[] 值 = 读保持寄存器(寄存器输出电流高字, 2);
            uint 原始 = ((uint)值[0] << 16) | 值[1];
            return 原始 / 1000.0f;
        }

        public float 读输出有功功率()
        {
            ushort[] 值 = 读保持寄存器(寄存器输出有功功率高字, 2);
            uint 原始 = ((uint)值[0] << 16) | 值[1];
            return 原始 / 10.0f;
        }

        private byte[] 执行事务(byte[] 帧未校验, int 最小响应长度)
        {
            if (!串口.IsOpen) throw new InvalidOperationException("串口未连接");

            byte[] 帧 = new byte[帧未校验.Length];
            Array.Copy(帧未校验, 帧, 帧未校验.Length);
            ushort crc = 计算CRC16(帧, 帧.Length - 2);
            帧[帧.Length - 2] = (byte)(crc & 0xFF);
            帧[帧.Length - 1] = (byte)(crc >> 8);

            串口.DiscardInBuffer();
            串口.DiscardOutBuffer();
            串口.Write(帧, 0, 帧.Length);

            byte[] 响应头 = 读取精确字节(3);
            int 数据长度;
            if ((响应头[1] & 0x80) != 0)
            {
                数据长度 = 2;
            }
            else if (响应头[1] == 0x03)
            {
                数据长度 = 响应头[2] + 2;
            }
            else
            {
                数据长度 = 5;
            }

            byte[] 剩余 = 读取精确字节(数据长度);
            byte[] 响应 = new byte[响应头.Length + 剩余.Length];
            Array.Copy(响应头, 0, 响应, 0, 响应头.Length);
            Array.Copy(剩余, 0, 响应, 响应头.Length, 剩余.Length);

            if (响应.Length < 最小响应长度)
                throw new InvalidOperationException($"永鹏电源响应长度不足 期望>={最小响应长度} 实际={响应.Length}");

            验证CRC(响应);
            return 响应;
        }

        private byte[] 读取精确字节(int 长度)
        {
            byte[] 缓冲 = new byte[长度];
            int 已读 = 0;
            while (已读 < 长度)
            {
                int n = 串口.Read(缓冲, 已读, 长度 - 已读);
                if (n <= 0) throw new TimeoutException("永鹏电源读取超时");
                已读 += n;
            }
            return 缓冲;
        }

        private static ushort 计算CRC16(byte[] 数据, int 长度)
        {
            ushort crc = 0xFFFF;
            for (int i = 0; i < 长度; i++)
            {
                crc ^= 数据[i];
                for (int j = 0; j < 8; j++)
                {
                    bool lsb = (crc & 0x0001) != 0;
                    crc >>= 1;
                    if (lsb) crc ^= 0xA001;
                }
            }
            return crc;
        }

        private static void 验证CRC(byte[] 响应)
        {
            if (响应.Length < 5) throw new InvalidOperationException("永鹏电源响应长度异常");
            ushort 接收crc = (ushort)(响应[^2] | (响应[^1] << 8));
            ushort 计算crc = 计算CRC16(响应, 响应.Length - 2);
            if (接收crc != 计算crc) throw new InvalidOperationException("永鹏电源CRC校验失败");
        }
    }
}
