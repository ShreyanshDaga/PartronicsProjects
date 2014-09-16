using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.API
{
    /// <RESPONCE PACKET>
    /// RESPONCE PACKET
    /// <RESPONCE PACKET>

    public class Responce_Packet
    {
        public int Length;
        public int ControlField;
        public int Source_Add, Destination_Add, Serial_Num;
        public int FunctionCode;
        public byte[] bData;
        //public byte[] Responce_Packet;


        public Responce_Packet()
        {
        }
        
        public Responce_Packet(int Source_Add, int Destination_Add, int Serial_Num, int FunctionCode, byte[] Data)
        {
            this.Length = 8 + Data.Length;
            this.Source_Add = Source_Add;
            this.Destination_Add = Destination_Add;
            this.Serial_Num = Serial_Num;
            this.FunctionCode = FunctionCode;
            this.bData = Data;
        }

        public byte[] SetPacketBytes()
        { 
            byte[] Total_ResponcePacket;
            byte[] bStart = new byte[] { 0XAA, 0XCC };
            byte[] bLength = BitConverter.GetBytes(this.Length);
            byte bsource_add, bdestination_add, bserial_num;
            byte bfunctionfode;
            byte[] pcrc;


            bsource_add = Convert.ToByte(this.Source_Add);
            bdestination_add = Convert.ToByte(this.Destination_Add);
            bserial_num = Convert.ToByte(this.Serial_Num);
            bfunctionfode = Convert.ToByte(this.FunctionCode);

            List<byte> R = new List<byte>();

            R.Add(bStart[0]);
            R.Add(bStart[1]);
            R.Add(bLength[1]);
            R.Add(bLength[0]);
            R.Add(bsource_add);
            R.Add(bdestination_add);
            R.Add(bserial_num);
            R.Add(bfunctionfode);

            foreach (var b in bData)
            {
                R.Add(b);
            }
            byte[] PreCRC = R.ToArray();
            pcrc = ComputeCRC(PreCRC);

            R.Add(pcrc[0]);
            R.Add(pcrc[1]);

            Total_ResponcePacket = R.ToArray();

            return Total_ResponcePacket;
        }

        private byte[] ComputeCRC(byte[] PreCRC)
        {
            byte[] bCRC = new byte[2];

            Crc16Ccitt B = new Crc16Ccitt(InitialCrcValue.Zeros);
            bCRC = B.ComputeChecksumBytes(PreCRC);

            return bCRC;
        }
    }



}