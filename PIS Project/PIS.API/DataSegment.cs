using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.API
{
    // Class for Data Segment
    public class DataSegment
    {
        public int DisplayModeId { get; set; }
        public int LanguageID { get; set; }
        public string TrainNumber { get; set; }
        public int DisplayStartTime { get; set; }
        public int DisplayHoldTime { get; set; }
        public int DisplayRepeatCount { get; set; }
        public int BrightnessLevel { get; set; }
        public int RFU { get; set; }
        public byte[] Block2;
        public byte[] Block1;
        public int DD, MM, YY, hh, mm, ss;


        public DataSegment()
        {
        }

        public DataSegment(int DisplayModeID, int LanguageID, string TrainNumber, int DisplayStartTime, int DisplayHoldTime, int DisplayRepeatCount, int BrightnessLevel, int RFU, int DD, int MM, int YY, int hh, int mm, int ss)
        {
            this.DisplayModeId = DisplayModeID;
            this.LanguageID = LanguageID;
            this.TrainNumber = TrainNumber;
            this.DisplayStartTime = DisplayStartTime;
            this.DisplayHoldTime = DisplayHoldTime;
            this.DisplayRepeatCount = DisplayRepeatCount;
            this.BrightnessLevel = BrightnessLevel;
            this.RFU = RFU;
            this.DD = DD;
            this.MM = MM;
            this.YY = YY;
            this.hh = hh;
            this.mm = mm;
            this.ss = ss;

            // GenerateBlock1 here itself
            this.GenerateBlock1();
        }

        public byte[] GenerateDataSegment()
        {
            List<byte> DataSegment = new List<byte>(20 + this.Block2.Length);

            foreach (var b in this.Block1)
            {
                DataSegment.Add(b);
            }

            foreach (var b in this.Block2)
            {
                DataSegment.Add(b);
            }

            return DataSegment.ToArray();
        }

        public void GenerateBlock1()
        {
            byte bdisplaymodeid;
            byte blanguageid;
            byte[] bdate;
            byte[] btime;
            byte bDD, bMM, bYY, bhh, bmm, bss;
            byte[] bRFU = new byte[] { 0x00, 0X00 };
            byte[] bTrainNumber;
            byte bDisplayStartTime, bDisplayHoldTime, bDisplayRepaetCount, bBrightnessLevel;

            bTrainNumber = Encoding.ASCII.GetBytes(TrainNumber);
            bDD = Convert.ToByte(this.DD);
            bMM = Convert.ToByte(this.MM);
            bYY = Convert.ToByte(this.YY);
            bhh = Convert.ToByte(this.hh);
            bmm = Convert.ToByte(this.mm);
            bss = Convert.ToByte(this.ss);
            bdate = new byte[] { bDD, bMM, bYY };
            btime = new byte[] { bhh, bmm, bss };

            blanguageid = Convert.ToByte(this.LanguageID);
            bdisplaymodeid = Convert.ToByte(this.DisplayModeId);
            bDisplayStartTime = Convert.ToByte(this.DisplayStartTime);
            bDisplayHoldTime = Convert.ToByte(this.DisplayHoldTime);
            bDisplayRepaetCount = Convert.ToByte(this.DisplayRepeatCount);
            bBrightnessLevel = Convert.ToByte(this.BrightnessLevel);

            //Block1 = new byte[] { bdisplaymodeid, blanguageid, bTrainNumber, bdate, btime, bDisplayStartTime, bDisplayHoldTime, bDisplayStartTime, bBrightnessLevel, bRFU };
            List<byte> B1 = new List<byte>(20);

            B1.Add(bdisplaymodeid);
            B1.Add(blanguageid);
            foreach (byte b in bTrainNumber)
            {
                B1.Add(b);
            }
            foreach (byte b in bdate)
            {
                B1.Add(b);
            }
            foreach (byte b in btime)
            {
                B1.Add(b);
            }
            B1.Add(bDisplayStartTime);
            B1.Add(bDisplayHoldTime);
            B1.Add(bDisplayRepaetCount);
            B1.Add(bBrightnessLevel);
            foreach (byte b in bRFU)
            {
                B1.Add(b);
            }

            this.Block1 = B1.ToArray();
        }

        public byte[] GenerateBlock2for_0x02(string TrainName)
        {
            byte[] bTrainName;
            byte bTrainLength;

            ushort TNLen = (ushort)TrainName.Length;

            bTrainName = Encoding.ASCII.GetBytes(TrainName);
            bTrainLength = Convert.ToByte(bTrainName.Length);

            List<byte> Block2 = new List<byte>(1 + TNLen); // one name because it is in one length

            Block2.Add(bTrainLength);
            foreach (var b in bTrainName)
            {
                Block2.Add(b);
            }

            this.Block2 = Block2.ToArray();
            return Block2.ToArray();

        }

        public byte[] GenerateBlock2for_0x03(string Src, string Dst)
        {
            byte[] bSrcName;
            byte[] bDstname;
            byte bSrcLength;
            byte bDstLength;

            bSrcName = Encoding.ASCII.GetBytes(Src);
            bSrcLength = Convert.ToByte(Src.Length);

            bDstname = Encoding.ASCII.GetBytes(Dst);
            bDstLength = Convert.ToByte(Dst.Length);

            List<byte> Block2 = new List<byte>(2 + Src.Length + Dst.Length);

            Block2.Add(bSrcLength);
            foreach (var b in bSrcName)
            {
                Block2.Add(b);
            }

            Block2.Add(bDstLength);
            foreach (var b in bDstname)
            {
                Block2.Add(b);
            }

            this.Block2 = Block2.ToArray();
            return Block2.ToArray();
        }

        public byte[] GenerateBlock2for_0x43(string PSName)
        {
            byte[] bPSName;
            byte bPSNameLength;

            bPSName = Encoding.ASCII.GetBytes(PSName);
            bPSNameLength = Convert.ToByte(PSName.Length);

            List<byte> Block2 = new List<byte>(1 + PSName.Length);

            Block2.Add(bPSNameLength);
            foreach (var b in bPSName)
            {
                Block2.Add(b);
            }

            this.Block2 = Block2.ToArray();
            return Block2.ToArray();
        }

        public byte[] GenerateBlock2for_0x44(string NSName)
        {
            byte[] bNSName;
            byte bNSNameLength;

            bNSName = Encoding.ASCII.GetBytes(NSName);
            bNSNameLength = Convert.ToByte(NSName.Length);

            List<byte> Block2 = new List<byte>(1 + NSName.Length);

            Block2.Add(bNSNameLength);
            foreach (var b in bNSName)
            {
                Block2.Add(b);
            }
            this.Block2 = Block2.ToArray();
            return Block2.ToArray();
        }

        public byte[] GenerateBlock2for_0x45(int Distance, string NS)
        {
            ushort D = (ushort)Distance;
            byte[] bDist = BitConverter.GetBytes(D);
            byte[] bNS;
            byte NSLength;

            bNS = Encoding.ASCII.GetBytes(NS);
            NSLength = Convert.ToByte(NS.Length);

            List<byte> Block2 = new List<byte>(3 + NS.Length);

            foreach (var b in bDist)
            {
                Block2.Add(b);
            }

            Block2.Add(NSLength);
            foreach (var b in bNS)
            {
                Block2.Add(b);
            }
            this.Block2 = Block2.ToArray();
            return Block2.ToArray();
        }

        public byte[] GenerateBlock2for_0x46(int Distance)
        {
            byte[] Dist = BitConverter.GetBytes(Distance);
            List<byte> Block2 = new List<byte>(2);

            Block2.Add(Dist[1]);
            Block2.Add(Dist[0]);
            this.Block2 = Block2.ToArray();
            return Block2.ToArray();
        }

        public byte[] GenerateBlock2for_0x47(int ETA_h, int ETA_m, string NSName)
        {
            ushort E = (ushort)ETA_h;
            byte bETA_h = Convert.ToByte(E);

            ushort E1 = (ushort)ETA_m;
            byte bETA_m = Convert.ToByte(E1);

            byte[] bNSName;
            byte bNSNameLength;

            bNSName = Encoding.ASCII.GetBytes(NSName);
            bNSNameLength = Convert.ToByte(NSName.Length);

            List<byte> Block2 = new List<byte>(2 + NSName.Length);

            

            Block2.Add(bNSNameLength);
            foreach (var b in bNSName)
            {
                Block2.Add(b);
            }
            this.Block2 = Block2.ToArray();
            return Block2.ToArray();
        }

        public byte[] GenerateBlock2for_0x48(int ETA_h, int ETA_m)
        {
            ushort E1 = (ushort)ETA_h;
            byte bETA_h = Convert.ToByte(E1);

            ushort E2 = (ushort)ETA_m;
            byte bETA_m = Convert.ToByte(E2);

            List<byte> Block2 = new List<byte>();

            
            this.Block2 = Block2.ToArray();
            return Block2.ToArray();
        }

        public byte[] GenerateBlock2for_0x49(int Sch_h, int Sch_m)
        {
            ushort S = (ushort)Sch_h;
            byte bSch_h = Convert.ToByte(Sch_h);

            ushort T = (ushort)Sch_m;
            byte bSch_m = Convert.ToByte(Sch_m);

            List<byte> Block2 = new List<byte>();

            this.Block2 = Block2.ToArray();
            return Block2.ToArray();
        }

        public byte[] GenerateBlock2for_0x4A(int LRT_h, int LRT_m)
        {
            ushort L = (ushort)LRT_h;
            byte bLRT_h = Convert.ToByte(LRT_h);

            ushort U = (ushort)LRT_m;
            byte bLRT_m = Convert.ToByte(LRT_m);

            List<byte> Block2 = new List<byte>();

           
            this.Block2 = Block2.ToArray();
            return Block2.ToArray();
        }

        public byte[] GenerateBlock2for_0x4B(int Speed)
        {

            byte[] TrainSpeed = BitConverter.GetBytes(Speed);

            List<byte> Block2 = new List<byte>(2);

            // Shift the MSB
            Block2.Add(TrainSpeed[1]);
            Block2.Add(TrainSpeed[0]);

            this.Block2 = Block2.ToArray();
            return Block2.ToArray();
        }

    }
}
