using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.IO.Ports;
using System.IO;
using PIS.API;

namespace Packet
{
    // Keep your code clean man.... I had to clean up everything
    // Maintian your braces and space....that was where your error was.!!!!
    // Make sure you dont give ';' at end when you are defining a function.!!!
    // Take a look now how clean the two classes are
    // Take an effort to have a presentable code
    // Comment on what you are doing there in case some one reads it should understand it..

    public class Command_Packet
    {
        public string Start;
        public string Length;
        public string ControlField;
        public string FunctionCode;
        public string Data;
        private string CRC;
        public string Packet { get; private set; }

        public Command_Packet()
        {
        }

        public Command_Packet(string Start, string Length, string ControlField, string FunctionCode, string Data, string CRC)
        {
            this.Start = Start;
            this.Length = Length;
            this.ControlField = ControlField;
            this.FunctionCode = FunctionCode;
            this.Data = Data;
            this.CRC = "  ";
        }
    }
   
    /// <Datasegments>
    /// Datasegments
    /// <datasegments>
    public class DataSegments
    {
        public int DisplayModeId { get; set; }
        public int LanguageID { get; set; }
        public string TrainNumber { get; set; }        
        public int DisplayStartTime { get; set; }
        public int DisplayHoldTime { get; set; }    
        public int DisplayRepeatCount { get; set; }
        public int BrightnessLevel { get; set; }
        public int RFU { get; set; }
        public int TrainNameLength { get; set; }
        public string TrainName { get; set; }
        int  bDD, bMM,bYY, bHH, bmm, bss;
	    public DataSegments()
        {
        }  

        public DataSegments(int DisplayModeID, int LanguageID, string TrainNumber,int DisplayStartTime, int DisplayHoldTime, int DisplayRepeatCount, int BrightnessLevel, int RFU, string TrainName, int bDD, int bMM, int bYY, int bhh, int bmm, int bss)
        {
            this.DisplayModeId = DisplayModeID;
            this.LanguageID = LanguageID;
            this.TrainNumber = TrainNumber;
            this.DisplayStartTime = DisplayStartTime;
            this.DisplayHoldTime = DisplayHoldTime;
            this.DisplayRepeatCount = DisplayRepeatCount;
            this.BrightnessLevel = BrightnessLevel;
            this.RFU = RFU;
            this.TrainNameLength = TrainName.Length;
            this.TrainName = TrainName;
            this.bDD = 
               this.
            //byte[] bDD = new byte[]{};
            
        }

        public byte[] GenerateDataSegment()
        {
            byte[] Block1 = new byte[20];
            byte displaymodeid;
            displaymodeid = Convert.ToByte(DisplayModeId);
            byte languageid;
            languageid = Convert.ToByte (LanguageID);
            /*byte[] trainnumber =new byte[]{ };
            trainnumber = Convert.ToByte(TrainNumber);*/
            
            const string TrainNumber = "22106 ";
            byte[] train =Encoding.ASCII.GetBytes(TrainNumber);
            foreach (byte element  in train)
            {
                Console.WriteLine("{0} = {1}", element, (char)element);
            }

            const string TrainName = "Indrayani Express";
            byte[] trainname = Encoding.ASCII.GetBytes(TrainName);
            foreach (byte element in trainname)
            {
                Console.WriteLine("{0:x} = {1}", element, (char)element);
                
            byte bDD, bMM, bYY;
            byte bhh, bmm, bss;
            bDD = Convert.ToByte(19);
            bMM = Convert.ToByte(08);
            bYY = Convert.ToByte(90);

            bhh = Convert.ToByte(22);
            bmm = Convert.ToByte(45);
            bss = Convert.ToByte(58);

            byte[] bDate = new byte[] { bDD, bMM, bYY };
            byte[] bTime = new byte[] { bhh, bmm, bss };

            Console.WriteLine("Date in Hex: \n");
            foreach (byte b in bDate)
            Console.WriteLine("{0:x}", b);

            Console.WriteLine("Time in Hex: \n");
            foreach (byte b in bTime)
            Console.WriteLine("{0:x}", b);

            Console.WriteLine(bDate.Length);
 

            return DataSegment;
        }
    }
    /*
     
    /// <CRC Calculation>
     //CRC Calculation 
    /// <CRC Calculation>
    
    public class CRC
    {

        public byte[] CRC_MSB = new byte[] {};
        public byte[] CRC_LSB = new byte[] {};

        public CRC()
        {
    
    
    
    
    
        }

        public CRC(byte CRC_MSB, byte CRC_LSB)
        {
            this.CRC_MSB = CRC_MSB;
            this.CRC_LSB = CRC_LSB;

    
    
        }







    }*/




    /// <summary>
    /// 16 BIT CRC
    /// </summary>
    //public enum InitialCrcValue { Zeros, NonZero1 = 0xffff, NonZero2 = 0x1D0F }
    //public class Crc16Ccitt
    //{
    //    const ushort poly = 4129;
    //    ushort[] table = new ushort[256];
    //    ushort initialValue = 0;

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

    //    public Crc16Ccitt(InitialCrcValue initialValue)
    //    {
    //        this.initialValue = (ushort)initialValue;
    //        ushort temp, a;
    //        for (int i = 0; i < table.Length; ++i)
    //        {
    //            temp = 0;
    //            a = (ushort)(i << 8);
    //            for (int j = 0; j < 8; ++j)
    //            {
    //                if (((temp ^ a) & 0x8000) != 0)
    //                {
    //                    temp = (ushort)((temp << 1) ^ poly);
    //                }
    //                else
    //                {
    //                    temp <<= 1;
    //                }
    //                a <<= 1;
    //            }
    //            table[i] = temp;
    //        }
    //    }
    //}
     /// <Serial BaudRate>
    /// Set BaudRate
    /// <Serial BaudRate>
    /*
     public partial class Form1 : Form
        {
            SerialPort myserial = new SerialPort(); //create of serial port
 
            public Form1()
            { 
                InitializeComponent();
                getportnames();                   //load all port names in this computer
                comboBoxBaudR.SelectedIndex = 6;  //default  set for baudrate-9600
                comboBoxDataB.SelectedIndex = 1;  //default  set for data bits-8
                comboBoxParity.SelectedIndex = 0; //default  set for parity -none
                comboBoxStopB.SelectedIndex = 0;  //default  set for stop bits -one
           
            }
 
       
            public void Init()
            {
               if (myserial.IsOpen )  //if port is  open 
                { myserial.Close();  //close port
                }
              myserial.PortName = comboBoxPort.Text;                                           //selected name of port
              myserial.Parity     = (Parity)Enum.Parse(typeof(Parity), comboBoxParity.Text);   //selected parity 
              myserial.StopBits   = (StopBits)Enum.Parse(typeof(StopBits), comboBoxStopB.Text);//selected stopbits
              myserial.DataBits   =   int.Parse(comboBoxDataB.Text);                           //selected data bits
              myserial.BaudRate   = int.Parse(comboBoxBaudR.Text);                             //selected baudrate
              myserial.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);//received even handler
            }
            public void getportnames()         
            {
                string[] portnames = SerialPort.GetPortNames(); //load all names of  com ports to string 
                comboBoxPort.Items.Clear();                     //delete previous names in combobox items 
             
                foreach (string s in portnames)                 //add this names to comboboxPort items
                { comboBoxPort.Items.Add(s);
                }
 
               if (comboBoxPort.Items.Count > 0)   //if there are some com ports ,select first 
                { comboBoxPort.SelectedIndex = 0;
                }
               else
                { comboBoxPort.Text = "No COM Port "; //if there are no com ports ,write No Com Port
                }
            }
            public  void  transmit()    
            {
                Init();                 //init parameters of serial comunication before every touch button "send"
                try
                {
                    myserial.Open();        //open serial port
                    myserial.Write(richTextBoxSend.Text); //write string  to serial port from rich text box 
                }
                catch
                {
                    MessageBox.Show("com port is not available"); //if there are not is any COM port in PC show message
                }
            }
 
            public void DataReceivedHandler( object sender,SerialDataReceivedEventArgs e)
            {
              string indata=  myserial.ReadExisting();  //read data to string 
            Invoke(new Action(() => richTextBoxReceive.Text += indata));//invoke is use for write receive data to richtext
            }
            private void buttonSend_Click(object sender, EventArgs e) // send button  event
            { transmit();     //transmit data
            }
            private void buttonReload_Click(object sender, EventArgs e)//reload button event 
            { getportnames(); //get all port names connected to this computer
            }
 
        
        }
    }    


      */

    /*public static string ByteArrayToString(byte[] ba)
    {
      string hex = BitConverter.ToString(ba);
      return hex.Replace("-","");
    }*/



    /// <Main Program>
    /// Main Program
    /// <Main Program>
    class Program
    {
        static void Main(string[] args)
        {
          /*  int B = 20;
            Byte b = Convert.ToByte(B);
            Console.WriteLine(Convert.ToString(b));
            
            Shreyansh's Code
	    byte b = 0x16;
            string S = "Shreyansh";
            byte[] bytes = Encoding.ASCII.GetBytes(S);

            StringBuilder str = new StringBuilder();

            str.AppendFormat("{0:x2}", b);
            foreach(byte e in bytes)
                Console.WriteLine(e);    
            */
            /*const string input = "Do not disturb me";
            byte[] array = Encoding.ASCII.GetBytes(input);
            foreach(byte element in array)
            {
            Console.WriteLine("{0} = {1}", element, (char)element);
            }*/
            //byte[] bytes = { 104, 105, 109, 97, 110, 115, 104, 117};
            //Console.WriteLine( BitConverter.ToString( bytes ) );

            //int TrainNumber = 22106 ;
            //string hexValue = decValue.ToString("X");

            //const string TrainNumber = "22106 ";
            //byte[] train = Encoding.ASCII.GetBytes(TrainNumber);
            //foreach (byte element in train)
            //{
            //    Console.WriteLine("{0:x} = {1}", element, (char)element);
            //}

            //const string TrainName = "Indrayani Express";
            //byte[] trainname = Encoding.ASCII.GetBytes(TrainName);
            //foreach (byte element in trainname)
            //{
            //    Console.WriteLine("{0:x} = {1}", element, (char)element);
            //}

      
        }
    }
}
