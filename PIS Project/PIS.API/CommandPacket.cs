using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.API
{
    // Class for the main command packet
    public class Command_Packet
    {
        public int Length;
        public int ControlField;
        public int SA, DA, SN;
        public int FunctionCode;
        public byte[] bData;        
        public byte[] Complete_Packet { get; private set; }

        public Command_Packet()
        {
        }

        public Command_Packet(int SA, int DA, int SN, int FunctionCode, byte[] Data)
        {
            this.Length = 8 + Data.Length;
            this.SA = SA;
            this.DA = DA;
            this.SN = SN;
            this.FunctionCode = FunctionCode;
            this.bData = Data;
        }

        public byte[] GetPackeBytes()
        {
            // Declare all the variables her
            byte[] TotalPacket;
            byte[] bStart = new byte[] { 0XAA, 0XCC };
            //byte[] bLength = new byte[] {0X00, Convert.ToByte(this.Length) };
            byte[] bLength = BitConverter.GetBytes(this.Length);
            byte bSA, bDA, bSN;
            byte bfunctioncode;
            byte[] pcrc;

            // Get/Convert to hex values here            
            bSA = Convert.ToByte(this.SA);
            bDA = Convert.ToByte(this.DA);
            bSN = Convert.ToByte(this.SN);
            bfunctioncode = Convert.ToByte(this.FunctionCode);


            // Append to List here
            List<byte> P = new List<byte>();

            P.Add(bStart[0]);
            P.Add(bStart[1]);
            P.Add(bLength[1]);
            P.Add(bLength[0]);
            P.Add(bSA);
            P.Add(bDA);
            P.Add(bSN);
            P.Add(bfunctioncode);
            foreach (var b in this.bData)
            {
                P.Add(b);
            }

            //Form packet upto CRC
            byte[] PreCRC = P.ToArray();
            pcrc = ComputeCRC(PreCRC);

            // Add them to the Packet
            P.Add(pcrc[0]);
            P.Add(pcrc[1]);

            // Find the total packet
            TotalPacket = P.ToArray();

            return TotalPacket;
        }

        private byte[] ComputeCRC(byte[] PreCRC)
        {
            byte[] bCRC = new byte[2];

            Crc16Ccitt B = new Crc16Ccitt(InitialCrcValue.Zeros);
            bCRC = B.ComputeChecksumBytes(PreCRC);

            return bCRC;
        }
    }

    public enum InitialCrcValue { Zeros, NonZero1 = 0xffff, NonZero2 = 0x1D0F }
    public class Crc16Ccitt
    {
        const ushort poly = 4129;
        ushort[] table = new ushort[256];
        ushort initialValue = 0;

        public Crc16Ccitt(InitialCrcValue mode)
        {
            this.initialValue = (ushort)mode;
            ushort value;
            ushort temp;
            for (ushort i = 0; i < table.Length; ++i)
            {
                value = 0;
                temp = i;
                for (byte j = 0; j < 8; ++j)
                {
                    if (((value ^ temp) & 0x0001) != 0)
                    {
                        value = (ushort)((value >> 1) ^ poly);
                    }
                    else
                    {
                        value >>= 1;
                    }
                    temp >>= 1;
                }
                table[i] = value;
            }
        }

        public ushort ComputeChecksum(byte[] bytes)
        {
            ushort crc = this.initialValue;
            for (int i = 0; i < bytes.Length; ++i)
            {
                crc = (ushort)((crc << 8) ^ table[((crc >> 8) ^ (0xff & bytes[i]))]);
            }
            return crc;
        }

        public byte[] ComputeChecksumBytes(byte[] bytes)
        {
            ushort crc = ComputeChecksum(bytes);
            return BitConverter.GetBytes(crc);
        }
    }
}
