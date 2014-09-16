using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO.Ports;
using System.IO;
using PIS.API;

namespace Packet
{
    #region Moved to PIS.API
    //public class SerialPortConnetion
    //{
    //    public string comportname;
    //    private int BaudRate { get; set; }
    //    int ParityBits;
    //    int StopBits;
    //    //public string data { get; set; }

    //    public SerialPortConnetion()
    //    {
    //    }

    //    public SerialPortConnetion(string comportname, int BaudRate, int ParityBits, int StopBits) /*string data*/
    //    {
    //        this.comportname = comportname;
    //        this.BaudRate = BaudRate;
    //        this.ParityBits = ParityBits;
    //        this.StopBits = StopBits;
    //        // this.data = data;
    //    }
    //}

    ///// <Command Packet>
    ///// Command_Packet
    ///// <Command_Packet>

    //public class Command_Packet
    //{
    //    public int Length;
    //    public int ControlField;
    //    public int SA, DA, SN;
    //    public int FunctionCode;
    //    public byte[] bData;
    //    private byte[] bCRC;
    //    public byte[] Complete_Packet { get; private set; }

    //    public Command_Packet()
    //    {
    //    }

    //    public Command_Packet(int SA, int DA, int SN, int FunctionCode, byte[] Data)
    //    {
    //        this.Length = 6 + Data.Length;
    //        this.SA = SA;
    //        this.DA = DA;
    //        this.SN = SN;
    //        this.FunctionCode = FunctionCode;
    //        this.bData = Data;
    //    }

    //    public byte[] GetPackeBytes()
    //    {
    //        // Declare all the variables her
    //        byte[] TotalPacket;
    //        byte[] bStart = new byte[] { 0XAA, 0XCC };
    //        //byte[] bLength = new byte[] {0X00, Convert.ToByte(this.Length) };
    //        byte[] bLength = BitConverter.GetBytes(this.Length);
    //        byte bSA, bDA, bSN;
    //        byte bfunctioncode;
    //        byte[] pcrc;

    //        // Get/Convert to hex values here            
    //        bSA = Convert.ToByte(this.SA);
    //        bDA = Convert.ToByte(this.DA);
    //        bSN = Convert.ToByte(this.SN);
    //        bfunctioncode = Convert.ToByte(this.FunctionCode);


    //        // Append to List here
    //        List<byte> P = new List<byte>();

    //        P.Add(bStart[0]);
    //        P.Add(bStart[1]);
    //        P.Add(bLength[1]);
    //        P.Add(bLength[0]);
    //        P.Add(bSA);
    //        P.Add(bDA);
    //        P.Add(bSN);
    //        P.Add(bfunctioncode);
    //        foreach (var b in this.bData)
    //        {
    //            P.Add(b);
    //        }

    //        //Form packet upto CRC
    //        byte[] PreCRC = P.ToArray();
    //        pcrc = ComputeCRC(PreCRC);

    //        // Add them to the Packet
    //        P.Add(pcrc[0]);
    //        P.Add(pcrc[1]);

    //        // Find the total packet
    //        TotalPacket = P.ToArray();

    //        return TotalPacket;
    //    }

    //    private byte[] ComputeCRC(byte[] PreCRC)
    //    {
    //        byte[] bCRC = new byte[2];

    //        Crc16Ccitt B = new Crc16Ccitt(InitialCrcValue.Zeros);
    //        bCRC = B.ComputeChecksumBytes(PreCRC);

    //        return bCRC;
    //    }
    //}

    ///// <Datasegments>
    ///// Datasegments
    ///// <datasegments>

    //public class DataSegment
    //{
    //    public int DisplayModeId { get; set; }
    //    public int LanguageID { get; set; }
    //    public string TrainNumber { get; set; }
    //    public int DisplayStartTime { get; set; }
    //    public int DisplayHoldTime { get; set; }
    //    public int DisplayRepeatCount { get; set; }
    //    public int BrightnessLevel { get; set; }
    //    public int RFU { get; set; }
    //    public byte[] Block2;
    //    public byte[] Block1;
    //    public int DD, MM, YY, hh, mm, ss;


    //    public DataSegment()
    //    {
    //    }

    //    public DataSegment(int DisplayModeID, int LanguageID, string TrainNumber, int DisplayStartTime, int DisplayHoldTime, int DisplayRepeatCount, int BrightnessLevel, int RFU, int DD, int MM, int YY, int hh, int mm, int ss)
    //    {
    //        this.DisplayModeId = DisplayModeID;
    //        this.LanguageID = LanguageID;
    //        this.TrainNumber = TrainNumber;
    //        this.DisplayStartTime = DisplayStartTime;
    //        this.DisplayHoldTime = DisplayHoldTime;
    //        this.DisplayRepeatCount = DisplayRepeatCount;
    //        this.BrightnessLevel = BrightnessLevel;
    //        this.RFU = RFU;
    //        this.DD = DD;
    //        this.MM = MM;
    //        this.YY = YY;
    //        this.hh = hh;
    //        this.mm = mm;
    //        this.ss = ss;

    //        this.GenerateBlock1();
    //    }

    //    /// <Packet Generate>
    //    /// Packet Generate
    //    /// <Packet Generate>

    //    public byte[] GenerateDataSegment()
    //    {
    //        List<byte> DataSegment = new List<byte>(20 + this.Block2.Length);

    //        foreach (var b in this.Block1)
    //        {
    //            DataSegment.Add(b);
    //        }

    //        foreach (var b in this.Block2)
    //        {
    //            DataSegment.Add(b);
    //        }

    //        return DataSegment.ToArray();
    //    }

    //    /// <summary>
    //    /// Pa
    //    /// </summary>
    //    /// <returns></returns>

    //    public void GenerateBlock1()
    //    {
    //        byte bdisplaymodeid;
    //        byte blanguageid;
    //        byte[] bdate;
    //        byte[] btime;
    //        byte bDD, bMM, bYY, bhh, bmm, bss;
    //        byte[] bRFU = new byte[] { 0x00, 0X00 };
    //        byte[] bTrainNumber;
    //        byte bDisplayStartTime, bDisplayHoldTime, bDisplayRepaetCount, bBrightnessLevel;

    //        bTrainNumber = Encoding.ASCII.GetBytes(TrainNumber);
    //        bDD = Convert.ToByte(this.DD);
    //        bMM = Convert.ToByte(this.MM);
    //        bYY = Convert.ToByte(this.YY);
    //        bhh = Convert.ToByte(this.hh);
    //        bmm = Convert.ToByte(this.mm);
    //        bss = Convert.ToByte(this.ss);
    //        bdate = new byte[] { bDD, bMM, bYY };
    //        btime = new byte[] { bhh, bmm, bss };

    //        blanguageid = Convert.ToByte(this.LanguageID);
    //        bdisplaymodeid = Convert.ToByte(this.DisplayModeId);
    //        bDisplayStartTime = Convert.ToByte(this.DisplayStartTime);
    //        bDisplayHoldTime = Convert.ToByte(this.DisplayHoldTime);
    //        bDisplayRepaetCount = Convert.ToByte(this.DisplayRepeatCount);
    //        bBrightnessLevel = Convert.ToByte(this.BrightnessLevel);

    //        //Block1 = new byte[] { bdisplaymodeid, blanguageid, bTrainNumber, bdate, btime, bDisplayStartTime, bDisplayHoldTime, bDisplayStartTime, bBrightnessLevel, bRFU };
    //        List<byte> B1 = new List<byte>(20);

    //        B1.Add(bdisplaymodeid);
    //        B1.Add(blanguageid);
    //        foreach (byte b in bTrainNumber)
    //        {
    //            B1.Add(b);
    //        }
    //        foreach (byte b in bdate)
    //        {
    //            B1.Add(b);
    //        }
    //        foreach (byte b in btime)
    //        {
    //            B1.Add(b);
    //        }
    //        B1.Add(bDisplayStartTime);
    //        B1.Add(bDisplayHoldTime);
    //        B1.Add(bDisplayRepaetCount);
    //        B1.Add(bBrightnessLevel);
    //        foreach (byte b in bRFU)
    //        {
    //            B1.Add(b);
    //        }

    //        this.Block1 = B1.ToArray();
    //    }

    //    public byte[] GenerateBlock2for_0x02(string TrainName)
    //    {
    //        byte[] bTrainName;
    //        byte bTrainLength;

    //        ushort TNLen = (ushort)TrainName.Length;

    //        bTrainName = Encoding.ASCII.GetBytes(TrainName);
    //        bTrainLength = Convert.ToByte(bTrainName.Length);

    //        List<byte> Block2 = new List<byte>(1 + TNLen); // one name because it is in one length

    //        Block2.Add(bTrainLength);
    //        foreach (var b in bTrainName)
    //        {
    //            Block2.Add(b);
    //        }

    //        this.Block2 = Block2.ToArray();
    //        return Block2.ToArray();

    //    }

    //    public byte[] GenerateBlock2for_0x03(string Src, string Dst)
    //    {
    //        byte[] bSrcName;
    //        byte[] bDstname;
    //        byte bsrcLength;
    //        byte bDstLength;

    //        bSrcName = Encoding.ASCII.GetBytes(Src);
    //        bsrcLength = Convert.ToByte(Src.Length);

    //        bDstname = Encoding.ASCII.GetBytes(Dst);
    //        bDstLength = Convert.ToByte(Dst.Length);

    //        List<byte> Block2 = new List<byte>(2 + Src.Length + Dst.Length);

    //        Block2.Add(bsrcLength);
    //        foreach (var b in bSrcName)
    //        {
    //            Block2.Add(b);
    //        }

    //        Block2.Add(bDstLength);
    //        foreach (var b in bDstname)
    //        {
    //            Block2.Add(b);
    //        }

    //        this.Block2 = Block2.ToArray();
    //        return Block2.ToArray();
    //    }

    //    public byte[] GenerateBlock2for_0x43(string PSName)
    //    {
    //        byte[] bPSName;
    //        byte bPSNameLength;

    //        bPSName = Encoding.ASCII.GetBytes(PSName);
    //        bPSNameLength = Convert.ToByte(PSName.Length);

    //        List<byte> Block2 = new List<byte>(1 + PSName.Length);

    //        Block2.Add(bPSNameLength);
    //        foreach (var b in bPSName)
    //        {
    //            Block2.Add(b);
    //        }

    //        this.Block2 = Block2.ToArray();
    //        return Block2.ToArray();
    //    }

    //    public byte[] GenerateBlock2for_0x44(string NSName)
    //    {
    //        byte[] bNSName;
    //        byte bNSNameLength;

    //        bNSName = Encoding.ASCII.GetBytes(NSName);
    //        bNSNameLength = Convert.ToByte(NSName.Length);

    //        List<byte> Block2 = new List<byte>(1 + NSName.Length);

    //        Block2.Add(bNSNameLength);
    //        foreach (var b in bNSName)
    //        {
    //            Block2.Add(b);
    //        }
    //        this.Block2 = Block2.ToArray();
    //        return Block2.ToArray();
    //    }

    //    public byte[] GenerateBlock2for_0x45(int Distance, string NS)
    //    {
    //        ushort D = (ushort)Distance;
    //        byte[] bDist = BitConverter.GetBytes(D);
    //        byte[] bNS;
    //        byte NSLength;

    //        bNS = Encoding.ASCII.GetBytes(NS);
    //        NSLength = Convert.ToByte(NS.Length);

    //        List<byte> Block2 = new List<byte>(3 + NS.Length);

    //        foreach (var b in bDist)
    //        {
    //            Block2.Add(b);
    //        }

    //        Block2.Add(NSLength);
    //        foreach (var b in bNS)
    //        {
    //            Block2.Add(b);
    //        }
    //        this.Block2 = Block2.ToArray();
    //        return Block2.ToArray();
    //    }

    //    public byte[] GenerateBlock2for_0x46(int Distance)
    //    {
    //        byte[] Dist = BitConverter.GetBytes(Distance);
    //        List<byte> Block2 = new List<byte>(2);

    //        Block2.Add(Dist[1]);
    //        Block2.Add(Dist[0]);
    //        this.Block2 = Block2.ToArray();
    //        return Block2.ToArray();
    //    }

    //    public byte[] GenerateBlock2for_0x47(int ETA_h, int ETA_m, string NSName)
    //    {
    //        ushort E = (ushort)ETA_h;
    //        byte[] bETA_h = BitConverter.GetBytes(E);

    //        ushort E1 = (ushort)ETA_m;
    //        byte[] bETA_m = BitConverter.GetBytes(E1);

    //        byte[] bNSName;
    //        byte bNSNameLength;

    //        bNSName = Encoding.ASCII.GetBytes(NSName);
    //        bNSNameLength = Convert.ToByte(NSName.Length);

    //        List<byte> Block2 = new List<byte>(2 + NSName.Length);

    //        foreach (var b in bETA_h)
    //        {
    //            Block2.Add(b);
    //        }
    //        foreach (var b in bETA_m)
    //        {
    //            Block2.Add(b);
    //        }

    //        Block2.Add(bNSNameLength);
    //        foreach (var b in bNSName)
    //        {
    //            Block2.Add(b);
    //        }
    //        this.Block2 = Block2.ToArray();
    //        return Block2.ToArray();
    //    }

    //    public byte[] GenerateBlock2for_0x48(int ETA_h, int ETA_m)
    //    {
    //        ushort E1 = (ushort)ETA_h;
    //        byte[] bETA_h = BitConverter.GetBytes(E1);

    //        ushort E2 = (ushort)ETA_m;
    //        byte[] bETA_m = BitConverter.GetBytes(E2);

    //        List<byte> Block2 = new List<byte>();

    //        foreach (var b in bETA_h)
    //        {
    //            Block2.Add(b);
    //        }
    //        foreach (var b in bETA_m)
    //        {
    //            Block2.Add(b);
    //        }
    //        this.Block2 = Block2.ToArray();
    //        return Block2.ToArray();
    //    }

    //    public byte[] GenerateBlock2for_0x49(int Sch_h, int Sch_m)
    //    {
    //        ushort S = (ushort)Sch_h;
    //        byte[] bSch_h = BitConverter.GetBytes(Sch_h);

    //        ushort T = (ushort)Sch_m;
    //        byte[] bSch_m = BitConverter.GetBytes(Sch_m);

    //        List<byte> Block2 = new List<byte>();

    //        foreach (var b in bSch_h)
    //        {
    //            Block2.Add(b);
    //        }

    //        foreach (var b in bSch_m)
    //        {
    //            Block2.Add(b);
    //        }
    //        this.Block2 = Block2.ToArray();
    //        return Block2.ToArray();
    //    }

    //    public byte[] GenerateBlock2for_0x4A(int LRT_h, int LRT_m)
    //    {
    //        ushort L = (ushort)LRT_h;
    //        byte[] bLRT_S = BitConverter.GetBytes(LRT_h);

    //        ushort U = (ushort)LRT_m;
    //        byte[] bLRT = BitConverter.GetBytes(LRT_m);

    //        List<byte> Block2 = new List<byte>();

    //        foreach (var b in bLRT_S)
    //        {
    //            Block2.Add(b);
    //        }
    //        foreach (var b in bLRT)
    //        {
    //            Block2.Add(b);
    //        }
    //        this.Block2 = Block2.ToArray();
    //        return Block2.ToArray();
    //    }

    //    public byte[] GenerateBlock2for_0x4B(int Speed)
    //    {

    //        byte[] TrainSpeed = BitConverter.GetBytes(Speed);

    //        List<byte> Block2 = new List<byte>(2);

    //        // Shift the MSB
    //        Block2.Add(TrainSpeed[1]);
    //        Block2.Add(TrainSpeed[0]);

    //        this.Block2 = Block2.ToArray();
    //        return Block2.ToArray();
    //    }

    //}

    //public enum InitialCrcValue { Zeros, NonZero1 = 0xffff, NonZero2 = 0x1D0F }
    //public class Crc16Ccitt
    //{
    //    const ushort poly = 4129;
    //    ushort[] table = new ushort[256];
    //    ushort initialValue = 0;

    //    public Crc16Ccitt(InitialCrcValue mode)
    //    {
    //        this.initialValue = (ushort) mode;
    //        ushort value;
    //        ushort temp;
    //        for (ushort i = 0; i < table.Length; ++i)
    //        {
    //            value = 0;
    //            temp = i;
    //            for (byte j = 0; j < 8; ++j)
    //            {
    //                if (((value ^ temp) & 0x0001) != 0)
    //                {
    //                    value = (ushort)((value >> 1) ^ poly);
    //                }
    //                else
    //                {
    //                    value >>= 1;
    //                }
    //                temp >>= 1;
    //            }
    //            table[i] = value;
    //        }
    //    }

    //    public ushort ComputeChecksum(byte[] bytes)
    //    {
    //        ushort crc = this.initialValue;
    //        for (int i = 0; i < bytes.Length; ++i)
    //        {
    //            crc = (ushort)((crc << 8) ^ table[((crc >> 8) ^ (0xff & bytes[i]))]);
    //        }
    //        return crc;
    //    }

    //    public byte[] ComputeChecksumBytes(byte[] bytes)
    //    {
    //        ushort crc = ComputeChecksum(bytes);
    //        return BitConverter.GetBytes(crc);
    //    }
    //}
    #endregion

    class Program
    {
        static void Main(string[] args)
        {          
            int sample;

            Console.WriteLine("_____________________________________________________________________");
            Console.WriteLine("              MENU DRIVEN FOR VARIOUS PROTOCOL CHECK                 ");
            Console.WriteLine("_____________________________________________________________________");
            Console.WriteLine("1.For GenerateBlock2for_0X02");
            Console.WriteLine("2.For GenerateBlock2for_0X03");
            Console.WriteLine("3.For GenerateBlock2for_0X43");
            Console.WriteLine("4.For GenerateBlock2for_0X44");
            Console.WriteLine("5.For GenerateBlock2for_0X45");
            Console.WriteLine("6.For GenerateBlock2for_0X46");
            Console.WriteLine("7.For GenerateBlock2for_0X47");
            Console.WriteLine("8.For GenerateBlock2for_0X48");
            Console.WriteLine("9.For GenerateBlock2for_0X49");
            Console.WriteLine("10.For GenerateBlock2for_0X4A");
            Console.WriteLine("11.For GenerateBlock2for_0X4B");
            Console.WriteLine("12.Exit");
            Console.WriteLine("Enter Your Choise Here:  ");
            sample = Convert.ToInt32(Console.ReadLine());

            DataSegment D = new DataSegment(0X43, 0X00, "22693 ", 0X05, 0x10, 0X02, 0X16, 0X0000, 15, 08, 14, 10, 55, 00);

            switch (sample)
            {

                case 1:
                    D.GenerateBlock2for_0x02("SHATABGUNJ EXPRESS");
                    byte[] B = D.GenerateDataSegment();
                    string hex = BitConverter.ToString(B);
                    Console.WriteLine(hex);
                    Console.WriteLine("\n");
                    Console.WriteLine("DATAPACKET CREATED SUCCESSFULLY...");
                    break;

                case 2:
                    D.GenerateBlock2for_0x03("Daund JN","H NIZZAMAUDDIN JN");
                    byte[] B1 = D.GenerateDataSegment();
                    string hex1 = BitConverter.ToString(B1);
                    Console.WriteLine(hex1);
                    Console.WriteLine("\n");
                    Console.WriteLine("DATAPACKET CREATED SUCCESSFULLY...");
                    break;

                case 3:
                    D.GenerateBlock2for_0x43("MALKAPUR STATION");
                    byte[] B2 = D.GenerateDataSegment();
                    string hex2 = BitConverter.ToString(B2);
                    Console.WriteLine(hex2);
                    Console.WriteLine("\n");
                    Console.WriteLine("DATAPACKET CREATED SUCCESSFULLY...");
                    break;

                case 4:
                    D.GenerateBlock2for_0x44("DAUND");
                    byte[] B3 = D.GenerateDataSegment();
                    string hex3 = BitConverter.ToString(B3);
                    Console.WriteLine(hex3);
                    Console.WriteLine("\n");
                    Console.WriteLine("DATAPACKET CREATED SUCCESSFULLY...");
                    break;

                case 5:
                    D.GenerateBlock2for_0x45(100,"DAUND");
                    byte[] B4 = D.GenerateDataSegment();
                    string hex4 = BitConverter.ToString(B4);
                    Console.WriteLine(hex4);
                    Console.WriteLine("\n");
                    Console.WriteLine("DATAPACKET CREATED SUCCESSFULLY...");
                    break;

                case 6:
                    D.GenerateBlock2for_0x46(100);
                    byte[] B5 = D.GenerateDataSegment();
                    string hex5 = BitConverter.ToString(B5);
                    Console.WriteLine(hex5);
                    Console.WriteLine("\n");
                    Console.WriteLine("DATAPACKET CREATED SUCCESSFULLY...");
                    break;

                case 7:
                    D.GenerateBlock2for_0x47(12, 00, "DAUND");
                    byte[] B6 = D.GenerateDataSegment();
                    string hex6 = BitConverter.ToString(B6);
                    Console.WriteLine(hex6);
                    Console.WriteLine("\n");
                    Console.WriteLine("DATAPACKET CREATED SUCCESSFULLY...");
                    break;

                case 8:
                    D.GenerateBlock2for_0x48(12, 00);
                    byte[] B7 = D.GenerateDataSegment();
                    string hex7 = BitConverter.ToString(B7);
                    Console.WriteLine(hex7);
                    Console.WriteLine("\n");
                    Console.WriteLine("DATAPACKET CREATED SUCCESSFULLY...");
                    break;

                case 9:
                    D.GenerateBlock2for_0x49(15, 56);
                    byte[] B8 = D.GenerateDataSegment();
                    string hex8 = BitConverter.ToString(B8);
                    Console.WriteLine(hex8);
                    Console.WriteLine("\n");
                    Console.WriteLine("DATAPACKET CREATED SUCCESSFULLY...");
                    break;

                case 10:
                    //int minutes = 10;
                    D.GenerateBlock2for_0x4A(02, 15);
                    byte[] B9 = D.GenerateDataSegment();
                    string hex9 = BitConverter.ToString(B9);
                    Console.WriteLine(hex9);
                    //Thread.Sleep(minutes);
                    Console.WriteLine("\n");
                    Console.WriteLine("DATAPACKET CREATED SUCCESSFULLY...");
                    break;

                case 11:
                    D.GenerateBlock2for_0x4B(70);
                    byte[] B10 = D.GenerateDataSegment();
                    string hex10 = BitConverter.ToString(B10);
                    Console.WriteLine(hex10);
                    Console.WriteLine("\n");
                    Console.WriteLine("DATAPACKET CREATED SUCCESSFULLY...");
                    break;

                case 12:
                    break;


            }
            Command_Packet C = new Command_Packet(0X23, 0X13, 0X66, 0X81, D.GenerateDataSegment());
            byte[] Packet = C.GetPackeBytes();//new byte[] { 0x00, 0x0D, 0x0E, 0x03, 0x0D, 0x05, 0x06, 0x0E, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0xDD, 0xEE, 0x0F};//C.GetPackeBytes();
            //var value = System.Text.Encoding.ASCII.GetString(Packet);//BitConverter.ToString(Packet);
            string val = BitConverter.ToString(Packet);
            Console.WriteLine(val);

            // COM Port Communication

            SerialPort port = new SerialPort();

            Console.WriteLine("Enter Name of COM Port: ");
            var portName = Console.ReadLine();

            port.Parity = Parity.None;
            port.StopBits = StopBits.One;
            port.BaudRate = 9600;
            port.PortName = portName;
            port.DataBits = 8;
            port.Open();
            port.Write(Packet, 0, Packet.Length);
            port.Close();
            Console.WriteLine("DATAPACKET SENT TO PIS DISPLAY SUCCESSFULLY !!!");
        }        
    }
}

