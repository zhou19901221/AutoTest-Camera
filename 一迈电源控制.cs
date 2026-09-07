using System;
using System.IO.Ports;

namespace 自动测试
{
    public class 一迈电源控制 : IDisposable
    {
        public byte 站地址 = 20;
        private readonly SerialPort 串口 = new SerialPort();
        public bool 已连接 => 串口.IsOpen;

        public const ushort 寄存器状态字1 = 0x0000;
        public const ushort 寄存器状态字2 = 0x0001;
        public const ushort 寄存器内部温度 = 0x0002;
        public const ushort 寄存器实际输出电压 = 0x0004;
        public const ushort 寄存器实际输出电流 = 0x0006;
        public const ushort 寄存器控制字 = 0x0009;
        public const ushort 寄存器设置输出电压 = 0x000A;
        public const ushort 寄存器设置输出电流 = 0x000C;
        public const ushort 寄存器设置限制功率PWM周期 = 0x000E;
        public const ushort 寄存器设置PWM开通1 = 0x0010;
        public const ushort 寄存器设置PWM开通2 = 0x0012;
        public const ushort 寄存器通信地址 = 0x0100;
        public const ushort 寄存器通信速率 = 0x0101;
        public const ushort 寄存器设置过压保护 = 0x0102;
        public const ushort 寄存器设置过流保护 = 0x0104;
        public const ushort 寄存器默认输出限压 = 0x0108;
        public const ushort 寄存器默认输出限流 = 0x010A;
        public const ushort 寄存器默认PWM周期 = 0x010C;
        public const ushort 寄存器默认PWM开通1 = 0x010E;
        public const ushort 寄存器默认PWM开通2 = 0x0110;
        public const ushort 寄存器电源额定电压 = 0x0112;
        public const ushort 寄存器电源额定电流 = 0x0114;

        public const ushort 状态1启动 = 1 << 0;
        public const ushort 状态1远程控制 = 1 << 1;
        public const ushort 状态1模拟控制 = 1 << 2;
        public const ushort 状态1允许输出 = 1 << 4;
        public const ushort 状态1恒流状态 = 1 << 5;
        public const ushort 状态1短路 = 1 << 6;
        public const ushort 状态1多段运行 = 1 << 7;
        public const ushort 状态1欠压 = 1 << 8;
        public const ushort 状态1过压 = 1 << 9;
        public const ushort 状态1过流 = 1 << 10;
        public const ushort 状态1过温 = 1 << 11;
        public const ushort 状态1按键短路故障 = 1 << 12;

        public const ushort 控制位启动电源 = 1 << 0;
        public const ushort 控制位远程控制 = 1 << 1;
        public const ushort 控制位蜂鸣器 = 1 << 6;
        public const ushort 控制位P1 = 1 << 8;
        public const ushort 控制位P2 = 1 << 9;
        public const ushort 控制位P3 = 1 << 10;
        public const ushort 控制位P4 = 1 << 11;

        public void 连接(string 端口名, int 波特率)
        {
            if (串口.IsOpen) 串口.Close();
            串口.PortName = 端口名;
            串口.BaudRate = 波特率;
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
            if (响应[1] != 0x03) throw new InvalidOperationException($"电源读寄存器异常 功能码:{响应[1]:X2} 码:{响应[2]:X2}");
            var 结果 = new ushort[数量];
            for (int i = 0; i < 数量; i++)
                结果[i] = (ushort)((响应[3 + 2 * i] << 8) | 响应[4 + 2 * i]);
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
            if (响应[1] != 0x06) throw new InvalidOperationException($"电源写寄存器异常 功能码:{响应[1]:X2} 码:{响应[2]:X2}");
        }

        public void 写多寄存器(ushort 地址, ushort[] 值)
        {
            int 字节数 = 值.Length * 2;
            byte[] 帧 = new byte[9 + 字节数];
            帧[0] = 站地址;
            帧[1] = 0x10;
            帧[2] = (byte)(地址 >> 8);
            帧[3] = (byte)地址;
            帧[4] = (byte)(值.Length >> 8);
            帧[5] = (byte)值.Length;
            帧[6] = (byte)字节数;
            for (int i = 0; i < 值.Length; i++)
            {
                帧[7 + 2 * i] = (byte)(值[i] >> 8);
                帧[8 + 2 * i] = (byte)值[i];
            }
            byte[] 响应 = 执行事务(帧, 8);
            if (响应[1] != 0x10) throw new InvalidOperationException($"电源写多寄存器异常 功能码:{响应[1]:X2} 码:{响应[2]:X2}");
        }

        public ushort 读状态字1() => 读保持寄存器(寄存器状态字1, 1)[0];

        public ushort 读状态字2() => 读保持寄存器(寄存器状态字2, 1)[0];

        public float 读内部温度() => 读浮点值(寄存器内部温度);

        public float 读实际输出电压() => 读浮点值(寄存器实际输出电压);

        public float 读实际输出电流() => 读浮点值(寄存器实际输出电流);

        public float 读电源额定电压() => 读浮点值(寄存器电源额定电压);

        public float 读电源额定电流() => 读浮点值(寄存器电源额定电流);

        public float 读输出电压设置() => 读浮点值(寄存器设置输出电压);

        public float 读输出电流设置() => 读浮点值(寄存器设置输出电流);

        public float 读过压保护() => 读浮点值(寄存器设置过压保护);

        public float 读过流保护() => 读浮点值(寄存器设置过流保护);

        public float 读默认输出限压() => 读浮点值(寄存器默认输出限压);

        public float 读默认输出限流() => 读浮点值(寄存器默认输出限流);

        public uint 读PWM周期() => 读整型值(寄存器设置限制功率PWM周期);

        public uint 读PWM开通1() => 读整型值(寄存器设置PWM开通1);

        public uint 读PWM开通2() => 读整型值(寄存器设置PWM开通2);

        public void 设置输出电压(float 电压) => 写浮点值(寄存器设置输出电压, 电压);

        public void 设置输出电流(float 电流) => 写浮点值(寄存器设置输出电流, 电流);

        public void 设置输出限制功率(float 功率) => 写浮点值(寄存器设置限制功率PWM周期, 功率);

        public void 设置PWM周期(uint 周期) => 写整型值(寄存器设置限制功率PWM周期, 周期);

        public void 设置PWM开通1(uint 值) => 写整型值(寄存器设置PWM开通1, 值);

        public void 设置PWM开通2(uint 值) => 写整型值(寄存器设置PWM开通2, 值);

        public void 启动电源() => 写控制字位(控制位启动电源, 控制位启动电源);

        public void 停止电源() => 写控制字位(控制位启动电源, 0);

        public void 切换远程控制() => 写控制字位(控制位远程控制, 控制位远程控制);

        public void 切换本地控制() => 写控制字位(控制位远程控制, 0);

        public void 设置蜂鸣器(bool 开启) => 写控制字位(控制位蜂鸣器, 开启 ? 控制位蜂鸣器 : (ushort)0);

        public void 设置P1输出(bool 打开) => 写控制字位(控制位P1, 打开 ? 控制位P1 : (ushort)0);

        public void 设置P2输出(bool 打开) => 写控制字位(控制位P2, 打开 ? 控制位P2 : (ushort)0);

        public void 设置P3输出(bool 打开) => 写控制字位(控制位P3, 打开 ? 控制位P3 : (ushort)0);

        public void 设置P4输出(bool 打开) => 写控制字位(控制位P4, 打开 ? 控制位P4 : (ushort)0);

        public ushort 读通信地址() => 读保持寄存器(寄存器通信地址, 1)[0];

        public void 设置通信地址(byte 新地址) => 写单寄存器(寄存器通信地址, 新地址);

        public ushort 读通信速率() => 读保持寄存器(寄存器通信速率, 1)[0];

        public void 设置通信速率(ushort 速率码) => 写单寄存器(寄存器通信速率, 速率码);

        public void 设置过压保护(float 电压) => 写浮点值(寄存器设置过压保护, 电压);

        public void 设置过流保护(float 电流) => 写浮点值(寄存器设置过流保护, 电流);

        public void 设置默认输出限压(float 电压) => 写浮点值(寄存器默认输出限压, 电压);

        public void 设置默认输出限流(float 电流) => 写浮点值(寄存器默认输出限流, 电流);

        public void 设置默认PWM周期(uint 周期) => 写整型值(寄存器默认PWM周期, 周期);

        public void 设置默认PWM开通1(uint 值) => 写整型值(寄存器默认PWM开通1, 值);

        public void 设置默认PWM开通2(uint 值) => 写整型值(寄存器默认PWM开通2, 值);

        private void 写控制字位(ushort 掩码, ushort 值)
        {
            ushort 当前 = 读保持寄存器(寄存器控制字, 1)[0];
            写单寄存器(寄存器控制字, (ushort)((当前 & ~掩码) | 值));
        }

        private float 读浮点值(ushort 地址)
        {
            ushort[] 寄存器 = 读保持寄存器(地址, 2);
            uint 原始 = ((uint)寄存器[1] << 16) | 寄存器[0];
            return BitConverter.ToSingle(BitConverter.GetBytes(原始), 0);
        }

        private void 写浮点值(ushort 地址, float 值)
        {
            uint 原始 = BitConverter.ToUInt32(BitConverter.GetBytes(值), 0);
            写多寄存器(地址, new ushort[] { (ushort)原始, (ushort)(原始 >> 16) });
        }

        private uint 读整型值(ushort 地址)
        {
            ushort[] 寄存器 = 读保持寄存器(地址, 2);
            return ((uint)寄存器[1] << 16) | 寄存器[0];
        }

        private void 写整型值(ushort 地址, uint 值)
        {
            写多寄存器(地址, new ushort[] { (ushort)值, (ushort)(值 >> 16) });
        }

        private byte[] 执行事务(byte[] 帧, int 响应长度)
        {
            追加CRC(帧);
            串口.DiscardInBuffer();
            串口.DiscardOutBuffer();
            串口.Write(帧, 0, 帧.Length);

            byte[] 响应 = new byte[响应长度];
            int 已读 = 0;
            while (已读 < 响应长度)
            {
                int n = 串口.Read(响应, 已读, 响应长度 - 已读);
                已读 += n;
            }

            ushort crc = 计算CRC(响应, 响应长度 - 2);
            if (crc != (ushort)(响应[响应长度 - 2] | (响应[响应长度 - 1] << 8)))
                throw new InvalidOperationException("电源通讯CRC校验失败");

            if ((响应[1] & 0x80) != 0)
                throw new InvalidOperationException($"电源返回异常码:{响应[2]:X2}");

            return 响应;
        }

        private static void 追加CRC(byte[] 帧)
        {
            ushort crc = 计算CRC(帧, 帧.Length - 2);
            帧[帧.Length - 2] = (byte)crc;
            帧[帧.Length - 1] = (byte)(crc >> 8);
        }

        private static ushort 计算CRC(byte[] 数据, int 长度)
        {
            ushort crc = 0xFFFF;
            for (int i = 0; i < 长度; i++)
            {
                crc ^= 数据[i];
                for (int j = 0; j < 8; j++)
                    crc = (crc & 1) != 0 ? (ushort)((crc >> 1) ^ 0xA001) : (ushort)(crc >> 1);
            }
            return crc;
        }
    }
}