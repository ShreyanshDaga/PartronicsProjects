using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using PIS.API;
using PIS.DB;
using System.IO;
using System.IO.Ports;


namespace PISDisplay
{
    public partial class Form1MainPage : Form
    {
        // Create a new instance of DB Context here
        MyContext dbContext = new MyContext();

        string TrainNo;
        string TrainName;
        int Speed;
        string Source_stn;
        string Destination_stn;
        string PresentStation;
        string NextStation;
        int Distance;

        public Form1MainPage()
        {
            string wanted_path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())));
            // Set the default path for database directory
            AppDomain.CurrentDomain.SetData("DataDirectory", wanted_path);
            
            InitializeComponent();

            // Uncomment only when u have changed the db
            //dbContext.SeedData();
        }

        private void ROUTE1_Click(object sender, EventArgs e)
        {            
            lblDBStatus.Text = "Fetching Database...";
            RouteStatus.Text = "Fetching Route 1 Database...";

            var Stations = this.dbContext.Stations.Where(s => s.StationRoute.Id == 1).ToList();
            var Trains = this.dbContext.Trains.Where(t => t.TrainRoute.Id == 1).ToList();

            Train_List.Items.Clear();
            Station_List.Items.Clear();

            foreach (var s in Stations)
            {
                Station_List.Items.Add(s.StationName);
            }
            foreach (var t in Trains)
            {
                Train_List.Items.Add(t.TrainNumber + " : " + t.TrainName);
            }
            RouteStatus.Text = "Route 1: " +  Stations[0].StationRoute.RouteName;
            lblDBStatus.Text = "";
        }

        private void ROUTE2_Click(object sender, EventArgs e)
        {           
            RouteStatus.Text = "Fetching Route 2 Database...";

            var Stations = this.dbContext.Stations.Where(s => s.StationRoute.Id == 2).ToList();
            var Trains = this.dbContext.Trains.Where(t => t.TrainRoute.Id == 2).ToList();

            Train_List.Items.Clear();
            Station_List.Items.Clear();

            foreach (var s in Stations)
            {
                Station_List.Items.Add(s.StationName);
            }
            foreach (var t in Trains)
            {
                Train_List.Items.Add(t.TrainNumber + " : " + t.TrainName);
            }
            RouteStatus.Text = "Route 2: " + Stations[0].StationRoute.RouteName;
        }

        private void ROUTE3_Click(object sender, EventArgs e)
        {            
            RouteStatus.Text = "Fetching Route 3 Database...";

            var Stations = this.dbContext.Stations.Where(s => s.StationRoute.Id == 3).ToList();
            var Trains = this.dbContext.Trains.Where(t => t.TrainRoute.Id == 3).ToList();

            Train_List.Items.Clear();
            Station_List.Items.Clear();

            foreach (var s in Stations)
            {
                Station_List.Items.Add(s.StationName);
            }
            foreach (var t in Trains)
            {
                Train_List.Items.Add(t.TrainNumber + " : " + t.TrainName);
            }
            RouteStatus.Text = "Route 3: " + Stations[0].StationRoute.RouteName;
        }

        private void ROUTE4_Click(object sender, EventArgs e)
        { 
            RouteStatus.Text = "Fetching Route 4 Database...";

            var Stations = this.dbContext.Stations.Where(s => s.StationRoute.Id == 4).ToList();
            var Trains = this.dbContext.Trains.Where(t => t.TrainRoute.Id == 4).ToList();

            Train_List.Items.Clear();
            Station_List.Items.Clear();

            foreach (var s in Stations)
            {
                Station_List.Items.Add(s.StationName);
            }
            foreach (var t in Trains)
            {
                Train_List.Items.Add(t.TrainNumber + " : " + t.TrainName);
            }
            RouteStatus.Text = "Route 4: " + Stations[0].StationRoute.RouteName;
        }

        private void ROUTE5_Click(object sender, EventArgs e)
        {
            RouteStatus.Text = "Fetching Route 5 Database...";

            var Stations = this.dbContext.Stations.Where(s => s.StationRoute.Id == 5).ToList();
            var Trains = this.dbContext.Trains.Where(t => t.TrainRoute.Id == 5).ToList();

            Train_List.Items.Clear();
            Station_List.Items.Clear();
            
            foreach (var s in Stations)
            {
                Station_List.Items.Add(s.StationName);
            }
            foreach (var t in Trains)
            {
                Train_List.Items.Add(t.TrainNumber + " : " + t.TrainName);
            }

            RouteStatus.Text = "Route 5: " + Stations[0].StationRoute.RouteName;            
        }

        private void btn0X00_Click(object sender, EventArgs e)
        {
            DefaultMsg_Status.Text = "DefaultMsg_Status:Selected";
            SafetySlogansMsg_Status.Text = "SafetySlogansMsg_Status:Not Select";
            WelcomMsg_Status.Text = "WelcomMsg_Status:Not Selected";
            FarewellMsg_Status.Text = "FarewellMsg_Status:Not Selected";
            TrainDetailMsg_Status.Text = "TrainDetailMsg_Status:Not Selected";
            PacketStatus.Text = "PacketStatus:Packet is being sent";

            if (EngLang_Select.Checked)
            {

                DataSegment D = new DataSegment(0X00, 0X00, this.TrainName, 0X05, 0X10, 0X05, 0X32, 0X0000, 19, 08, 14, 04, 44, 00);

                byte[] b = D.Block1;

                Command_Packet P = new Command_Packet(0X02, 0X01, 0X00, 0X81, b);
                byte[] p = P.GetPackeBytes();

                SerialPort port = new SerialPort();

                port.Parity = Parity.None;
                port.StopBits = StopBits.One;
                port.BaudRate = 9600;
                port.DataBits = 8;
                port.PortName = "COM6";
                port.Open();
                port.Write(p, 0, p.Length);
                port.Close();
                PacketStatus.Text = "PacketStatus: Packet has been sent successfully";
            }

            else if (HindiLang_Select.Checked)
            {
                DataSegment D = new DataSegment(0X00, 0X01, this.TrainName, 0X05, 0X10, 0X05, 0X32, 0X0000, 19, 08, 14, 04, 44, 00);

                byte[] b = D.Block1;

                Command_Packet P = new Command_Packet(0X02, 0X01, 0X00, 0X81, b);
                byte[] p = P.GetPackeBytes();

                SerialPort port = new SerialPort();

                port.Parity = Parity.None;
                port.StopBits = StopBits.One;
                port.BaudRate = 9600;
                port.DataBits = 8;
                port.PortName = "COM6";
                port.Open();
                port.Write(p, 0, p.Length);
                port.Close();
                PacketStatus.Text = "PacketStatus: Packet has been sent successfully";
            }
            else if (MarathiLang_Select.Checked)
            {
                DataSegment D = new DataSegment(0X00, 0X03, this.TrainName, 0X05, 0X10, 0X05, 0X32, 0X0000, 19, 08, 14, 04, 44, 00);

                byte[] b = D.Block1;

                Command_Packet P = new Command_Packet(0X02, 0X01, 0X00, 0X81, b);
                byte[] p = P.GetPackeBytes();

                SerialPort port = new SerialPort();

                port.Parity = Parity.None;
                port.StopBits = StopBits.One;
                port.BaudRate = 9600;
                port.DataBits = 8;
                port.PortName = "COM6";
                port.Open();
                port.Write(p, 0, p.Length);
                port.Close();
                PacketStatus.Text = "PacketStatus: Packet has been sent successfully";
            }
            else 
            {
                MessageBox.Show("Please Select Any One Language");
            }
        }

        private void btn0X01_Click(object sender, EventArgs e)
        {
            DefaultMsg_Status.Text = "DefaultMsg_Status:Selected";
            SafetySlogansMsg_Status.Text = "SafetySlogansMsg_Status:Not Select";
            WelcomMsg_Status.Text = "WelcomMsg_Status:Not Selected";
            FarewellMsg_Status.Text = "FarewellMsg_Status:Not Selected";
            TrainDetailMsg_Status.Text = "TrainDetailMsg_Status:Not Selected";
            PacketStatus.Text = "PacketStatus:Packet is being sent";

            if (EngLang_Select.Checked)
            {
                DataSegment D = new DataSegment(0X01, 0X00, this.TrainName, 0X05, 0X10, 0X05, 0X32, 0X0000, 19, 08, 14, 04, 44, 00);
                // D.GenerateBlock2for_0x02(this.TrainName);
                byte[] b = D.Block1;
                Command_Packet P = new Command_Packet(0X02, 0X01, 0X00, 0X81, b);

                byte[] p = P.GetPackeBytes();

                SerialPort port = new SerialPort();
                port.Parity = Parity.None;
                port.StopBits = StopBits.One;
                port.BaudRate = 9600;
                port.DataBits = 8;
                port.PortName = "COM6";
                port.Open();
                port.Write(p, 0, p.Length);
                port.Close();
                PacketStatus.Text = "PacketStatus: Packet has been sent successfully";
            }
            else if (HindiLang_Select.Checked)
            {
                DataSegment D = new DataSegment(0X01, 0X01, this.TrainName, 0X05, 0X10, 0X05, 0X32, 0X0000, 19, 08, 14, 04, 44, 00);
                // D.GenerateBlock2for_0x02(this.TrainName);
                byte[] b = D.Block1;
                Command_Packet P = new Command_Packet(0X02, 0X01, 0X00, 0X81, b);

                byte[] p = P.GetPackeBytes();

                SerialPort port = new SerialPort();
                port.Parity = Parity.None;
                port.StopBits = StopBits.One;
                port.BaudRate = 9600;
                port.DataBits = 8;
                port.PortName = "COM6";
                port.Open();
                port.Write(p, 0, p.Length);
                port.Close();
                PacketStatus.Text = "PacketStatus: Packet has been sent successfully";
            }

            else if (MarathiLang_Select.Checked)
            {
                DataSegment D = new DataSegment(0X01, 0X03, this.TrainName, 0X05, 0X10, 0X05, 0X32, 0X0000, 19, 08, 14, 04, 44, 00);

                // D.GenerateBlock2for_0x02(this.TrainName);
                byte[] b = D.Block1;
                Command_Packet P = new Command_Packet(0X02, 0X01, 0X00, 0X81, b);

                byte[] p = P.GetPackeBytes();

                SerialPort port = new SerialPort();
                port.Parity = Parity.None;
                port.StopBits = StopBits.One;
                port.BaudRate = 9600;
                port.DataBits = 8;
                port.PortName = "COM6";
                port.Open();
                port.Write(p, 0, p.Length);
                port.Close();
                PacketStatus.Text = "PacketStatus: Packet has been sent successfully";
            }

            else
            {
                MessageBox.Show("Please Select Any One Language");
            }
        }

        private void btn0X02_Click(object sender, EventArgs e)
        {
            WelcomMsg_Status.Text = "WelcomMsg_Status:Selected";
            DefaultMsg_Status.Text = "DefaultMsg_Status:Not Selected";
            SafetySlogansMsg_Status.Text = "SafetySlogansMsg_Status:Not Select";
            FarewellMsg_Status.Text = "FarewellMsg_Status:Not Selected";
            TrainDetailMsg_Status.Text = "TrainDetailMsg_Status:Not Selected";
            PacketStatus.Text = "PacketStatus:Packet is being sent";

            DataSegment D = new DataSegment(0X02, 0X00, this.TrainName, 0X05, 0X10, 0X05, 0X32, 0X0000, 19, 08, 14, 04, 44, 00);
            //D.GenerateBlock2for_0x02(this.TrainName);
            byte[] b = D.GenerateDataSegment();
            Command_Packet P = new Command_Packet(0X02, 0X01, 0X00, 0X81, b);
            byte[] p = P.GetPackeBytes();

            SerialPort port = new SerialPort();
            port.Parity = Parity.None;
                port.StopBits = StopBits.One;
                port.BaudRate = 9600;
                port.DataBits = 8;
                port.PortName = "COM6";
                port.Open();
                port.Write(p, 0, p.Length);
                port.Close();
                PacketStatus.Text = "PacketStatus: Packet has been sent successfully";
            }

            

       private void btn0X03_Click(object sender, EventArgs e)
        {
            WelcomMsg_Status.Text = "WelcomMsg_Status:Selected";
            DefaultMsg_Status.Text = "DefaultMsg_Status:Not Selected";
            SafetySlogansMsg_Status.Text = "SafetySlogansMsg_Status:Not Select";
            FarewellMsg_Status.Text = "FarewellMsg_Status:Not Selected";
            TrainDetailMsg_Status.Text = "TrainDetailMsg_Status:Not Selected";
            PacketStatus.Text = "PacketStatus: Packet is being Sent";

                DataSegment D = new DataSegment(0X03, 0X00, this.TrainNo, 0X05, 0X10, 0X05, 0X32, 0X0000, 19, 08, 14, 04, 44, 00);
                D.GenerateBlock2for_0x03(this.Source_stn, this.Destination_stn);
                byte[] b = D.GenerateDataSegment();
                Command_Packet P = new Command_Packet(0X02, 0X01, 0X00, 0X81, b);
                byte[] p = P.GetPackeBytes();

                SerialPort port = new SerialPort();

                port.PortName = "COM6";
                port.BaudRate = 9600;
                port.Parity = Parity.None;
                port.DataBits = 8;
                port.StopBits = StopBits.One;
                port.Open();
                port.Write(p, 0, P.Length);
                port.Close();
                PacketStatus.Text = "PacketStatus: Packet has been sent successfully ";
            }

            
        private void btn0X04_Click(object sender, EventArgs e)
        {
            WelcomMsg_Status.Text = "WelcomMsg_Status:Selected";
            DefaultMsg_Status.Text = "DefaultMsg_Status:Not Selected";
            SafetySlogansMsg_Status.Text = "SafetySlogansMsg_Status:Not Select";
            FarewellMsg_Status.Text = "FarewellMsg_Status:Not Selected";
            TrainDetailMsg_Status.Text = "TrainDetailMsg_Status:Not Selected";
            PacketStatus.Text = "PacketStatus:Packet is being sent";

            
                DataSegment D = new DataSegment(0X04, 0X00, this.TrainName, 0X05, 0X10, 0X05, 0X32, 0X0000, 19, 08, 14, 04, 44, 00);

                //D.GenerateBlock2for_0x4B(this.Speed);
                byte[] b = D.Block1;
                Command_Packet P = new Command_Packet(0X02, 0X01, 0X00, 0X81, b);
                byte[] p = P.GetPackeBytes();

                SerialPort port = new SerialPort();

                port.Parity = Parity.None;
                port.StopBits = StopBits.One;
                port.BaudRate = 9600;
                port.DataBits = 8;
                port.PortName = "COM6";
                port.Open();
                port.Write(p, 0, p.Length);
                port.Close();
                PacketStatus.Text = "PacketStatus: Packet has been sent successfully";
            }

            

        private void btn0X10_Click(object sender, EventArgs e)
        {
            FarewellMsg_Status.Text = "FarewellMsg_Status:Selected";
            WelcomMsg_Status.Text = "WelcomMsg_Status:Not Selected";
            DefaultMsg_Status.Text = "DefaultMsg_Status:Not Selected";
            SafetySlogansMsg_Status.Text = "SafetySlogansMsg_Status:Not Select";
            TrainDetailMsg_Status.Text = "TrainDetailMsg_Status:Not Selected";
            PacketStatus.Text = "PacketStatus:Packet is being sent";

            
            DataSegment D = new DataSegment(0X10, 0X00, this.TrainName, 0X05, 0X10, 0X05, 0X32, 0X0000, 19, 08, 14, 04, 44, 00);

                //D.GenerateBlock2for_0x4B(this.Speed);
                byte[] b = D.Block1;
                Command_Packet P = new Command_Packet(0X02, 0X01, 0X00, 0X81, b);
                byte[] p = P.GetPackeBytes();

                SerialPort port = new SerialPort();

                port.Parity = Parity.None;
                port.StopBits = StopBits.One;
                port.BaudRate = 9600;
                port.DataBits = 8;
                port.PortName = "COM6";
                port.Open();
                port.Write(p, 0, p.Length);
                port.Close();
                PacketStatus.Text = "PacketStatus: Packet has been sent successfully";
            }

            
        private void btn0X11_Click(object sender, EventArgs e)
        {
            FarewellMsg_Status.Text = "FarewellMsg_Status:Selected";
            WelcomMsg_Status.Text = "WelcomMsg_Status:Not Selected";
            DefaultMsg_Status.Text = "DefaultMsg_Status:Not Selected";
            SafetySlogansMsg_Status.Text = "SafetySlogansMsg_Status:Not Select";
            TrainDetailMsg_Status.Text = "TrainDetailMsg_Status:Not Selected";

            
                PacketStatus.Text = "PacketStatus:Packet is being sent";
                DataSegment D = new DataSegment(0X11, 0X00, this.TrainName, 0X05, 0X10, 0X05, 0X32, 0X0000, 19, 08, 14, 04, 44, 00);

                //D.GenerateBlock2for_0x4B(this.Speed);
                byte[] b = D.Block1;
                Command_Packet P = new Command_Packet(0X02, 0X01, 0X00, 0X81, b);
                byte[] p = P.GetPackeBytes();

                SerialPort port = new SerialPort();

                port.Parity = Parity.None;
                port.StopBits = StopBits.One;
                port.BaudRate = 9600;
                port.DataBits = 8;
                port.PortName = "COM6";
                port.Open();
                port.Write(p, 0, p.Length);
                port.Close();
                PacketStatus.Text = "PacketStatus: Packet has been sent successfully";
            }
             
        private void btn0X12_Click(object sender, EventArgs e)
        {
            FarewellMsg_Status.Text = "FarewellMsg_Status:Selected";
            WelcomMsg_Status.Text = "WelcomMsg_Status:Not Selected";
            DefaultMsg_Status.Text = "DefaultMsg_Status:Not Selected";
            SafetySlogansMsg_Status.Text = "SafetySlogansMsg_Status:Not Select";
            TrainDetailMsg_Status.Text = "TrainDetailMsg_Status:Not Selected";

            PacketStatus.Text = "PacketStatus:Packet is being sent";
            DataSegment D = new DataSegment(0X12, 0X00, this.TrainName, 0X05, 0X10, 0X05, 0X32, 0X0000, 19, 08, 14, 04, 44, 00);

            //D.GenerateBlock2for_0x4B(this.Speed);
            byte[] b = D.Block1;
            Command_Packet P = new Command_Packet(0X02, 0X01, 0X00, 0X81, b);
            byte[] p = P.GetPackeBytes();

            SerialPort port = new SerialPort();

            port.Parity = Parity.None;
            port.StopBits = StopBits.One;
            port.BaudRate = 9600;
            port.DataBits = 8;
            port.PortName = "COM6";
            port.Open();
            port.Write(p, 0, p.Length);
            port.Close();
            PacketStatus.Text = "PacketStatus: Packet has been sent successfully";
        }

        private void btn0X13_Click(object sender, EventArgs e)
        {
            FarewellMsg_Status.Text = "FarewellMsg_Status:Selected";
            WelcomMsg_Status.Text = "WelcomMsg_Status:Not Selected";
            DefaultMsg_Status.Text = "DefaultMsg_Status:Not Selected";
            SafetySlogansMsg_Status.Text = "SafetySlogansMsg_Status:Not Select";
            TrainDetailMsg_Status.Text = "TrainDetailMsg_Status:Not Selected";

            PacketStatus.Text = "PacketStatus:Packet is being sent";
            DataSegment D = new DataSegment(0X13, 0X00, this.TrainName, 0X05, 0X10, 0X05, 0X32, 0X0000, 19, 08, 14, 04, 44, 00);

            //D.GenerateBlock2for_0x4B(this.Speed);
            byte[] b = D.Block1;
            Command_Packet P = new Command_Packet(0X02, 0X01, 0X00, 0X81, b);
            byte[] p = P.GetPackeBytes();

            SerialPort port = new SerialPort();

            port.Parity = Parity.None;
            port.StopBits = StopBits.One;
            port.BaudRate = 9600;
            port.DataBits = 8;
            port.PortName = "COM6";
            port.Open();
            port.Write(p, 0, p.Length);
            port.Close();
            PacketStatus.Text = "PacketStatus: Packet has been sent successfully";
        }

        private void btn0X20_Click(object sender, EventArgs e)
        {
            SafetySlogansMsg_Status.Text = "SafetySlogansMsg_Status:Select";
            DefaultMsg_Status.Text = "DefaultMsg_Status:Not Selected";
            WelcomMsg_Status.Text = "WelcomMsg_Status:Not Selected";
            FarewellMsg_Status.Text = "FarewellMsg_Status:Not Selected";
            TrainDetailMsg_Status.Text = "TrainDetailMsg_Status:Not Selected";
            PacketStatus.Text = "PacketStatus:Packet is being sent";
            DataSegment D = new DataSegment(0X20, 0X00, this.TrainName, 0X05, 0X10, 0X05, 0X32, 0X0000, 19, 08, 14, 04, 44, 00);

            //D.GenerateBlock2for_0x4B(this.Speed);
            byte[] b = D.Block1;
            Command_Packet P = new Command_Packet(0X02, 0X01, 0X00, 0X81, b);
            byte[] p = P.GetPackeBytes();

            SerialPort port = new SerialPort();

            port.Parity = Parity.None;
            port.StopBits = StopBits.One;
            port.BaudRate = 9600;
            port.DataBits = 8;
            port.PortName = "COM6";
            port.Open();
            port.Write(p, 0, p.Length);
            port.Close();
            PacketStatus.Text = "PacketStatus: Packet has been sent successfully";
        }

        private void btn0X21_Click(object sender, EventArgs e)
        {
            SafetySlogansMsg_Status.Text = "SafetySlogansMsg_Status:Select";
            DefaultMsg_Status.Text = "DefaultMsg_Status:Not Selected";
            WelcomMsg_Status.Text = "WelcomMsg_Status:Not Selected";
            FarewellMsg_Status.Text = "FarewellMsg_Status:Not Selected";
            TrainDetailMsg_Status.Text = "TrainDetailMsg_Status:Not Selected";
            PacketStatus.Text = "PacketStatus:Packet is being sent";
            DataSegment D = new DataSegment(0X21, 0X00, this.TrainName, 0X05, 0X10, 0X05, 0X32, 0X0000, 19, 08, 14, 04, 44, 00);

            //D.GenerateBlock2for_0x4B(this.Speed);
            byte[] b = D.Block1;
            Command_Packet P = new Command_Packet(0X02, 0X01, 0X00, 0X81, b);
            byte[] p = P.GetPackeBytes();

            SerialPort port = new SerialPort();

            port.Parity = Parity.None;
            port.StopBits = StopBits.One;
            port.BaudRate = 9600;
            port.DataBits = 8;
            port.PortName = "COM6";
            port.Open();
            port.Write(p, 0, p.Length);
            port.Close();
            PacketStatus.Text = "PacketStatus: Packet has been sent successfully";
        }

        private void btn0X22_Click(object sender, EventArgs e)
        {
            SafetySlogansMsg_Status.Text = "SafetySlogansMsg_Status:Select";
            DefaultMsg_Status.Text = "DefaultMsg_Status:Not Selected";
            WelcomMsg_Status.Text = "WelcomMsg_Status:Not Selected";
            FarewellMsg_Status.Text = "FarewellMsg_Status:Not Selected";
            TrainDetailMsg_Status.Text = "TrainDetailMsg_Status:Not Selected";
            PacketStatus.Text = "PacketStatus:Packet is being sent";
            DataSegment D = new DataSegment(0X22, 0X00, this.TrainName, 0X05, 0X10, 0X05, 0X32, 0X0000, 19, 08, 14, 04, 44, 00);

            //D.GenerateBlock2for_0x4B(this.Speed);
            byte[] b = D.Block1;
            Command_Packet P = new Command_Packet(0X02, 0X01, 0X00, 0X81, b);
            byte[] p = P.GetPackeBytes();

            SerialPort port = new SerialPort();

            port.Parity = Parity.None;
            port.StopBits = StopBits.One;
            port.BaudRate = 9600;
            port.DataBits = 8;
            port.PortName = "COM6";
            port.Open();
            port.Write(p, 0, p.Length);
            port.Close();
            PacketStatus.Text = "PacketStatus: Packet has been sent successfully";
        }

        private void btn0X23_Click(object sender, EventArgs e)
        {
            SafetySlogansMsg_Status.Text = "SafetySlogansMsg_Status:Select";
            DefaultMsg_Status.Text = "DefaultMsg_Status:Not Selected";
            WelcomMsg_Status.Text = "WelcomMsg_Status:Not Selected";
            FarewellMsg_Status.Text = "FarewellMsg_Status:Not Selected";
            TrainDetailMsg_Status.Text = "TrainDetailMsg_Status:Not Selected";
            PacketStatus.Text = "PacketStatus:Packet is being sent";
            DataSegment D = new DataSegment(0X23, 0X00, this.TrainName, 0X05, 0X10, 0X05, 0X32, 0X0000, 19, 08, 14, 04, 44, 00);

            //D.GenerateBlock2for_0x4B(this.Speed);
            byte[] b = D.Block1;
            Command_Packet P = new Command_Packet(0X02, 0X01, 0X00, 0X81, b);
            byte[] p = P.GetPackeBytes();

            SerialPort port = new SerialPort();

            port.Parity = Parity.None;
            port.StopBits = StopBits.One;
            port.BaudRate = 9600;
            port.DataBits = 8;
            port.PortName = "COM6";
            port.Open();
            port.Write(p, 0, p.Length);
            port.Close();
            PacketStatus.Text = "PacketStatus: Packet has been sent successfully";
        }

        private void btn0X24_Click(object sender, EventArgs e)
        {
            SafetySlogansMsg_Status.Text = "SafetySlogansMsg_Status:Select";
            DefaultMsg_Status.Text = "DefaultMsg_Status:Not Selected";
            WelcomMsg_Status.Text = "WelcomMsg_Status:Not Selected";
            FarewellMsg_Status.Text = "FarewellMsg_Status:Not Selected";
            TrainDetailMsg_Status.Text = "TrainDetailMsg_Status:Not Selected";
            PacketStatus.Text = "PacketStatus:Packet is being sent";
            DataSegment D = new DataSegment(0X24, 0X00, this.TrainName, 0X05, 0X10, 0X05, 0X32, 0X0000, 19, 08, 14, 04, 44, 00);

            //D.GenerateBlock2for_0x4B(this.Speed);
            byte[] b = D.Block1;
            Command_Packet P = new Command_Packet(0X02, 0X01, 0X00, 0X81, b);
            byte[] p = P.GetPackeBytes();

            SerialPort port = new SerialPort();

            port.Parity = Parity.None;
            port.StopBits = StopBits.One;
            port.BaudRate = 9600;
            port.DataBits = 8;
            port.PortName = "COM6";
            port.Open();
            port.Write(p, 0, p.Length);
            port.Close();
            PacketStatus.Text = "PacketStatus: Packet has been sent successfully";
        }

        private void btn0X25_Click(object sender, EventArgs e)
        {
            SafetySlogansMsg_Status.Text = "SafetySlogansMsg_Status:Select";
            DefaultMsg_Status.Text = "DefaultMsg_Status:Not Selected";
            WelcomMsg_Status.Text = "WelcomMsg_Status:Not Selected";
            FarewellMsg_Status.Text = "FarewellMsg_Status:Not Selected";
            TrainDetailMsg_Status.Text = "TrainDetailMsg_Status:Not Selected";
            PacketStatus.Text = "PacketStatus:Packet is being sent";
            DataSegment D = new DataSegment(0X25, 0X00, this.TrainName, 0X05, 0X10, 0X05, 0X32, 0X0000, 19, 08, 14, 04, 44, 00);

            //D.GenerateBlock2for_0x4B(this.Speed);
            byte[] b = D.Block1;
            Command_Packet P = new Command_Packet(0X02, 0X01, 0X00, 0X81, b);
            byte[] p = P.GetPackeBytes();

            SerialPort port = new SerialPort();

            port.Parity = Parity.None;
            port.StopBits = StopBits.One;
            port.BaudRate = 9600;
            port.DataBits = 8;
            port.PortName = "COM6";
            port.Open();
            port.Write(p, 0, p.Length);
            port.Close();
            PacketStatus.Text = "PacketStatus: Packet has been sent successfully";
        }

        private void btn0X26_Click(object sender, EventArgs e)
        {
            SafetySlogansMsg_Status.Text = "SafetySlogansMsg_Status:Select";
            DefaultMsg_Status.Text = "DefaultMsg_Status:Not Selected";
            WelcomMsg_Status.Text = "WelcomMsg_Status:Not Selected";
            FarewellMsg_Status.Text = "FarewellMsg_Status:Not Selected";
            TrainDetailMsg_Status.Text = "TrainDetailMsg_Status:Not Selected";
            PacketStatus.Text = "PacketStatus:Packet is being sent";
            DataSegment D = new DataSegment(0X26, 0X00, this.TrainName, 0X05, 0X10, 0X05, 0X32, 0X0000, 19, 08, 14, 04, 44, 00);

            //D.GenerateBlock2for_0x4B(this.Speed);
            byte[] b = D.Block1;
            Command_Packet P = new Command_Packet(0X02, 0X01, 0X00, 0X81, b);
            byte[] p = P.GetPackeBytes();

            SerialPort port = new SerialPort();

            port.Parity = Parity.None;
            port.StopBits = StopBits.One;
            port.BaudRate = 9600;
            port.DataBits = 8;
            port.PortName = "COM6";
            port.Open();
            port.Write(p, 0, p.Length);
            port.Close();
            PacketStatus.Text = "PacketStatus: Packet has been sent successfully";
        }

        private void btn0X27_Click(object sender, EventArgs e)
        {
            SafetySlogansMsg_Status.Text = "SafetySlogansMsg_Status:Select";
            DefaultMsg_Status.Text = "DefaultMsg_Status:Not Selected";
            WelcomMsg_Status.Text = "WelcomMsg_Status:Not Selected";
            FarewellMsg_Status.Text = "FarewellMsg_Status:Not Selected";
            TrainDetailMsg_Status.Text = "TrainDetailMsg_Status:Not Selected";
            PacketStatus.Text = "PacketStatus:Packet is being sent";
            DataSegment D = new DataSegment(0X27, 0X00, this.TrainName, 0X05, 0X10, 0X05, 0X32, 0X0000, 19, 08, 14, 04, 44, 00);

            //D.GenerateBlock2for_0x4B(this.Speed);
            byte[] b = D.Block1;
            Command_Packet P = new Command_Packet(0X02, 0X01, 0X00, 0X81, b);
            byte[] p = P.GetPackeBytes();

            SerialPort port = new SerialPort();

            port.Parity = Parity.None;
            port.StopBits = StopBits.One;
            port.BaudRate = 9600;
            port.DataBits = 8;
            port.PortName = "COM6";
            port.Open();
            port.Write(p, 0, p.Length);
            port.Close();
            PacketStatus.Text = "PacketStatus: Packet has been sent successfully";
        }

        private void btn0X28_Click(object sender, EventArgs e)
        {
            SafetySlogansMsg_Status.Text = "SafetySlogansMsg_Status:Select";
            DefaultMsg_Status.Text = "DefaultMsg_Status:Not Selected";
            WelcomMsg_Status.Text = "WelcomMsg_Status:Not Selected";
            FarewellMsg_Status.Text = "FarewellMsg_Status:Not Selected";
            TrainDetailMsg_Status.Text = "TrainDetailMsg_Status:Not Selected";
            PacketStatus.Text = "PacketStatus:Packet is being sent";
            DataSegment D = new DataSegment(0X28, 0X00, this.TrainName, 0X05, 0X10, 0X05, 0X32, 0X0000, 19, 08, 14, 04, 44, 00);

            //D.GenerateBlock2for_0x4B(this.Speed);
            byte[] b = D.Block1;
            Command_Packet P = new Command_Packet(0X02, 0X01, 0X00, 0X81, b);
            byte[] p = P.GetPackeBytes();

            SerialPort port = new SerialPort();

            port.Parity = Parity.None;
            port.StopBits = StopBits.One;
            port.BaudRate = 9600;
            port.DataBits = 8;
            port.PortName = "COM6";
            port.Open();
            port.Write(p, 0, p.Length);
            port.Close();
            PacketStatus.Text = "PacketStatus: Packet has been sent successfully";
        }

        private void btn0X29_Click(object sender, EventArgs e)
        {
            SafetySlogansMsg_Status.Text = "SafetySlogansMsg_Status:Select";
            DefaultMsg_Status.Text = "DefaultMsg_Status:Not Selected";
            WelcomMsg_Status.Text = "WelcomMsg_Status:Not Selected";
            FarewellMsg_Status.Text = "FarewellMsg_Status:Not Selected";
            TrainDetailMsg_Status.Text = "TrainDetailMsg_Status:Not Selected";
            PacketStatus.Text = "PacketStatus:Packet is being sent";
            DataSegment D = new DataSegment(0X29, 0X00, this.TrainName, 0X05, 0X10, 0X05, 0X32, 0X0000, 19, 08, 14, 04, 44, 00);

            //D.GenerateBlock2for_0x4B(this.Speed);
            byte[] b = D.Block1;
            Command_Packet P = new Command_Packet(0X02, 0X01, 0X00, 0X81, b);
            byte[] p = P.GetPackeBytes();

            SerialPort port = new SerialPort();

            port.Parity = Parity.None;
            port.StopBits = StopBits.One;
            port.BaudRate = 9600;
            port.DataBits = 8;
            port.PortName = "COM6";
            port.Open();
            port.Write(p, 0, p.Length);
            port.Close();
            PacketStatus.Text = "PacketStatus: Packet has been sent successfully";
        }

        private void btn0X2A_Click(object sender, EventArgs e)
        {
            SafetySlogansMsg_Status.Text = "SafetySlogansMsg_Status:Select";
            DefaultMsg_Status.Text = "DefaultMsg_Status:Not Selected";
            WelcomMsg_Status.Text = "WelcomMsg_Status:Not Selected";
            FarewellMsg_Status.Text = "FarewellMsg_Status:Not Selected";
            TrainDetailMsg_Status.Text = "TrainDetailMsg_Status:Not Selected";
            PacketStatus.Text = "PacketStatus:Packet is being sent";
            DataSegment D = new DataSegment(0X02A, 0X00, this.TrainName, 0X05, 0X10, 0X05, 0X32, 0X0000, 19, 08, 14, 04, 44, 00);

            //D.GenerateBlock2for_0x4B(this.Speed);
            byte[] b = D.Block1;
            Command_Packet P = new Command_Packet(0X02, 0X01, 0X00, 0X81, b);
            byte[] p = P.GetPackeBytes();

            SerialPort port = new SerialPort();

            port.Parity = Parity.None;
            port.StopBits = StopBits.One;
            port.BaudRate = 9600;
            port.DataBits = 8;
            port.PortName = "COM6";
            port.Open();
            port.Write(p, 0, p.Length);
            port.Close();
            PacketStatus.Text = "PacketStatus: Packet has been sent successfully";
        }

        private void btn0X2B_Click(object sender, EventArgs e)
        {
            SafetySlogansMsg_Status.Text = "SafetySlogansMsg_Status:Select";
            DefaultMsg_Status.Text = "DefaultMsg_Status:Not Selected";
            WelcomMsg_Status.Text = "WelcomMsg_Status:Not Selected";
            FarewellMsg_Status.Text = "FarewellMsg_Status:Not Selected";
            TrainDetailMsg_Status.Text = "TrainDetailMsg_Status:Not Selected";
            PacketStatus.Text = "PacketStatus:Packet is being sent";
            DataSegment D = new DataSegment(0X2B, 0X00, this.TrainName, 0X05, 0X10, 0X05, 0X32, 0X0000, 19, 08, 14, 04, 44, 00);

            //D.GenerateBlock2for_0x4B(this.Speed);
            byte[] b = D.Block1;
            Command_Packet P = new Command_Packet(0X02, 0X01, 0X00, 0X81, b);
            byte[] p = P.GetPackeBytes();

            SerialPort port = new SerialPort();

            port.Parity = Parity.None;
            port.StopBits = StopBits.One;
            port.BaudRate = 9600;
            port.DataBits = 8;
            port.PortName = "COM6";
            port.Open();
            port.Write(p, 0, p.Length);
            port.Close();
            PacketStatus.Text = "PacketStatus: Packet has been sent successfully";
        }

        private void btn0X2C_Click(object sender, EventArgs e)
        {
            SafetySlogansMsg_Status.Text = "SafetySlogansMsg_Status:Select";
            DefaultMsg_Status.Text = "DefaultMsg_Status:Not Selected";
            WelcomMsg_Status.Text = "WelcomMsg_Status:Not Selected";
            FarewellMsg_Status.Text = "FarewellMsg_Status:Not Selected";
            TrainDetailMsg_Status.Text = "TrainDetailMsg_Status:Not Selected";
            PacketStatus.Text = "PacketStatus:Packet is being sent";
            DataSegment D = new DataSegment(0X2C, 0X00, this.TrainName, 0X05, 0X10, 0X05, 0X32, 0X0000, 19, 08, 14, 04, 44, 00);

            //D.GenerateBlock2for_0x4B(this.Speed);
            byte[] b = D.Block1;
            Command_Packet P = new Command_Packet(0X02, 0X01, 0X00, 0X81, b);
            byte[] p = P.GetPackeBytes();

            SerialPort port = new SerialPort();

            port.Parity = Parity.None;
            port.StopBits = StopBits.One;
            port.BaudRate = 9600;
            port.DataBits = 8;
            port.PortName = "COM6";
            port.Open();
            port.Write(p, 0, p.Length);
            port.Close();
            PacketStatus.Text = "PacketStatus: Packet has been sent successfully";
        }

        private void btn0X2D_Click(object sender, EventArgs e)
        {
            SafetySlogansMsg_Status.Text = "SafetySlogansMsg_Status:Select";
            DefaultMsg_Status.Text = "DefaultMsg_Status:Not Selected";
            WelcomMsg_Status.Text = "WelcomMsg_Status:Not Selected";
            FarewellMsg_Status.Text = "FarewellMsg_Status:Not Selected";
            TrainDetailMsg_Status.Text = "TrainDetailMsg_Status:Not Selected";
            PacketStatus.Text = "PacketStatus:Packet is being sent";
            DataSegment D = new DataSegment(0X2D, 0X00, this.TrainName, 0X05, 0X10, 0X05, 0X32, 0X0000, 19, 08, 14, 04, 44, 00);

            //D.GenerateBlock2for_0x4B(this.Speed);
            byte[] b = D.Block1;
            Command_Packet P = new Command_Packet(0X02, 0X01, 0X00, 0X81, b);
            byte[] p = P.GetPackeBytes();

            SerialPort port = new SerialPort();

            port.Parity = Parity.None;
            port.StopBits = StopBits.One;
            port.BaudRate = 9600;
            port.DataBits = 8;
            port.PortName = "COM6";
            port.Open();
            port.Write(p, 0, p.Length);
            port.Close();
            PacketStatus.Text = "PacketStatus: Packet has been sent successfully";
        }

        private void btn0X2E_Click(object sender, EventArgs e)
        {
            SafetySlogansMsg_Status.Text = "SafetySlogansMsg_Status:Select";
            DefaultMsg_Status.Text = "DefaultMsg_Status:Not Selected";
            WelcomMsg_Status.Text = "WelcomMsg_Status:Not Selected";
            FarewellMsg_Status.Text = "FarewellMsg_Status:Not Selected";
            TrainDetailMsg_Status.Text = "TrainDetailMsg_Status:Not Selected";
            PacketStatus.Text = "PacketStatus:Packet is being sent";
            DataSegment D = new DataSegment(0X2E, 0X00, this.TrainName, 0X05, 0X10, 0X05, 0X32, 0X0000, 19, 08, 14, 04, 44, 00);

            //D.GenerateBlock2for_0x4B(this.Speed);
            byte[] b = D.Block1;
            Command_Packet P = new Command_Packet(0X02, 0X01, 0X00, 0X81, b);
            byte[] p = P.GetPackeBytes();

            SerialPort port = new SerialPort();

            port.Parity = Parity.None;
            port.StopBits = StopBits.One;
            port.BaudRate = 9600;
            port.DataBits = 8;
            port.PortName = "COM6";
            port.Open();
            port.Write(p, 0, p.Length);
            port.Close();
            PacketStatus.Text = "PacketStatus: Packet has been sent successfully";
        }

        private void btn0X2F_Click(object sender, EventArgs e)
        {
            SafetySlogansMsg_Status.Text = "SafetySlogansMsg_Status:Select";
            DefaultMsg_Status.Text = "DefaultMsg_Status:Not Selected";
            WelcomMsg_Status.Text = "WelcomMsg_Status:Not Selected";
            FarewellMsg_Status.Text = "FarewellMsg_Status:Not Selected";
            TrainDetailMsg_Status.Text = "TrainDetailMsg_Status:Not Selected";
            PacketStatus.Text = "PacketStatus:Packet is being sent";
            DataSegment D = new DataSegment(0X2F, 0X00, this.TrainName, 0X05, 0X10, 0X05, 0X32, 0X0000, 19, 08, 14, 04, 44, 00);

            //D.GenerateBlock2for_0x4B(this.Speed);
            byte[] b = D.Block1;
            Command_Packet P = new Command_Packet(0X02, 0X01, 0X00, 0X81, b);
            byte[] p = P.GetPackeBytes();

            SerialPort port = new SerialPort();

            port.Parity = Parity.None;
            port.StopBits = StopBits.One;
            port.BaudRate = 9600;
            port.DataBits = 8;
            port.PortName = "COM6";
            port.Open();
            port.Write(p, 0, p.Length);
            port.Close();
            PacketStatus.Text = "PacketStatus: Packet has been sent successfully";
        }

        private void btn0X30_Click(object sender, EventArgs e)
        {
            SafetySlogansMsg_Status.Text = "SafetySlogansMsg_Status:Select";
            DefaultMsg_Status.Text = "DefaultMsg_Status:Not Selected";
            WelcomMsg_Status.Text = "WelcomMsg_Status:Not Selected";
            FarewellMsg_Status.Text = "FarewellMsg_Status:Not Selected";
            TrainDetailMsg_Status.Text = "TrainDetailMsg_Status:Not Selected";
            PacketStatus.Text = "PacketStatus:Packet is being sent";
            DataSegment D = new DataSegment(0X30, 0X00, this.TrainName, 0X05, 0X10, 0X05, 0X32, 0X0000, 19, 08, 14, 04, 44, 00);

            //D.GenerateBlock2for_0x4B(this.Speed);
            byte[] b = D.Block1;
            Command_Packet P = new Command_Packet(0X02, 0X01, 0X00, 0X81, b);
            byte[] p = P.GetPackeBytes();

            SerialPort port = new SerialPort();

            port.Parity = Parity.None;
            port.StopBits = StopBits.One;
            port.BaudRate = 9600;
            port.DataBits = 8;
            port.PortName = "COM6";
            port.Open();
            port.Write(p, 0, p.Length);
            port.Close();
            PacketStatus.Text = "PacketStatus: Packet has been sent successfully";
        }

        private void btn0X40_Click(object sender, EventArgs e)
        {
            WelcomMsg_Status.Text = "WelcomMsg_Status:Not Selected";
            DefaultMsg_Status.Text = "DefaultMsg_Status:Not Selected";
            SafetySlogansMsg_Status.Text = "SafetySlogansMsg_Status:Not Select";
            FarewellMsg_Status.Text = "FarewellMsg_Status:Not Selected";
            TrainDetailMsg_Status.Text = "TrainDetailMsg_Status:Selected";
            PacketStatus.Text = "PacketStatus:Packet is being sent";
            DataSegment D = new DataSegment(0X40, 0X00, this.TrainName, 0X05, 0X10, 0X05, 0X32, 0X0000, 19, 08, 14, 04, 44, 00);

            //D.GenerateBlock2for_0x4B(this.Speed);
            byte[] b = D.GenerateDataSegment();
            Command_Packet P = new Command_Packet(0X02, 0X01, 0X00, 0X81, b);
            byte[] p = P.GetPackeBytes();

            SerialPort port = new SerialPort();

            port.Parity = Parity.None;
            port.StopBits = StopBits.One;
            port.BaudRate = 9600;
            port.DataBits = 8;
            port.PortName = "COM6";
            port.Open();
            port.Write(p, 0, p.Length);
            port.Close();
            PacketStatus.Text = "PacketStatus: Packet has been sent successfully";
        }
        
        private void btn0X41_Click(object sender, EventArgs e)
        {
            WelcomMsg_Status.Text = "WelcomMsg_Status:Not Selected";
            DefaultMsg_Status.Text = "DefaultMsg_Status:Not Selected";
            SafetySlogansMsg_Status.Text = "SafetySlogansMsg_Status:Not Select";
            FarewellMsg_Status.Text = "FarewellMsg_Status:Not Selected";
            TrainDetailMsg_Status.Text = "TrainDetailMsg_Status:Selected";
            PacketStatus.Text = "PacketStatus:Packet is being sent";
            DataSegment D = new DataSegment(0X41, 0X00, this.TrainName, 0X05, 0X10, 0X05, 0X32, 0X0000, 19, 08, 14, 04, 44, 00);

            //D.GenerateBlock2for_0x4B(this.Speed);
            byte[] b = D.GenerateDataSegment();
            Command_Packet P = new Command_Packet(0X02, 0X01, 0X00, 0X81, b);
            byte[] p = P.GetPackeBytes();

            SerialPort port = new SerialPort();

            port.Parity = Parity.None;
            port.StopBits = StopBits.One;
            port.BaudRate = 9600;
            port.DataBits = 8;
            port.PortName = "COM6";
            port.Open();
            port.Write(p, 0, p.Length);
            port.Close();
            PacketStatus.Text = "PacketStatus: Packet has been sent successfully";
        }

        private void btn0X42_Click(object sender, EventArgs e)
        {
            WelcomMsg_Status.Text = "WelcomMsg_Status:Not Selected";
            DefaultMsg_Status.Text = "DefaultMsg_Status:Not Selected";
            SafetySlogansMsg_Status.Text = "SafetySlogansMsg_Status:Not Select";
            FarewellMsg_Status.Text = "FarewellMsg_Status:Not Selected";
            TrainDetailMsg_Status.Text = "TrainDetailMsg_Status:Selected";
            PacketStatus.Text = "PacketStatus:Packet is being sent";
            DataSegment D = new DataSegment(0X42, 0X00, this.TrainName, 0X05, 0X10, 0X05, 0X32, 0X0000, 19, 08, 14, 04, 44, 00);

            //D.GenerateBlock2for_0x4B(this.Speed);
            
            byte[] b = D.GenerateDataSegment();
            Command_Packet P = new Command_Packet(0X02, 0X01, 0X00, 0X81, b);
            byte[] p = P.GetPackeBytes();

            SerialPort port = new SerialPort();

            port.Parity = Parity.None;
            port.StopBits = StopBits.One;
            port.BaudRate = 9600;
            port.DataBits = 8;
            port.PortName = "COM6";
            port.Open();
            port.Write(p, 0, p.Length);
            port.Close();
            PacketStatus.Text = "PacketStatus: Packet has been sent successfully";
        }
        
        
        private void btn0X43_Click(object sender, EventArgs e)
        {
            WelcomMsg_Status.Text = "WelcomMsg_Status:Not Selected";
            DefaultMsg_Status.Text = "DefaultMsg_Status:Not Selected";
            SafetySlogansMsg_Status.Text = "SafetySlogansMsg_Status:Not Select";
            FarewellMsg_Status.Text = "FarewellMsg_Status:Not Selected";
            TrainDetailMsg_Status.Text = "TrainDetailMsg_Status:Selected";
            PacketStatus.Text = "PacketStatus: Packet is being sent";
            DataSegment D = new DataSegment(0X43, 0X00, this.TrainNo, 0X05, 0X10, 0X05, 0X32, 0X0000, 19, 08, 14, 04, 44, 00);
           
            D.GenerateBlock2for_0x43(this.PresentStation);
            byte[] b = D.GenerateDataSegment();
            Command_Packet P = new Command_Packet(0X02, 0X01, 0X00, 0X81, b);
            byte[] p = P.GetPackeBytes();
            
            SerialPort port = new SerialPort();
            port.PortName = "COM6";
            port.BaudRate = 9600;
            port.Parity = Parity.None;
            port.DataBits = 8;
            port.StopBits = StopBits.One;
            port.Open();
            port.Write(p, 0, P.Length);
            port.Close();
            PacketStatus.Text = "PacketStatus: Packet has been sent successfully ";
        }       

        private void btn0X44_Click(object sender, EventArgs e)
        {
            WelcomMsg_Status.Text = "WelcomMsg_Status:Not Selected";
            DefaultMsg_Status.Text = "DefaultMsg_Status:Not Selected";
            SafetySlogansMsg_Status.Text = "SafetySlogansMsg_Status:Not Select";
            FarewellMsg_Status.Text = "FarewellMsg_Status:Not Selected";
            TrainDetailMsg_Status.Text = "TrainDetailMsg_Status:Selected";
            PacketStatus.Text = "PacketStatus: Packet is being sent";
            DataSegment D = new DataSegment(0X44, 0X00, this.TrainNo, 0X05, 0X10, 0X05, 0X32, 0X0000, 19, 08, 14, 04, 44, 00);
            
            D.GenerateBlock2for_0x44(this.NextStation);
            
            byte[] b = D.GenerateDataSegment();
            Command_Packet P = new Command_Packet(0X02, 0X01, 0X00, 0X81, b);
            byte[] p = P.GetPackeBytes();
            
            SerialPort port = new SerialPort();
            port.PortName = "COM6";
            port.BaudRate = 9600;
            port.Parity = Parity.None;
            port.DataBits = 8;
            port.StopBits = StopBits.One;
            port.Open();
            port.Write(p, 0, P.Length);
            port.Close();
            PacketStatus.Text = "PacketStatus: Packet has been sent successfully ";

        }

        private void btn0X45_Click(object sender, EventArgs e)
        {
            WelcomMsg_Status.Text = "WelcomMsg_Status:Not Selected";
            DefaultMsg_Status.Text = "DefaultMsg_Status:Not Selected";
            SafetySlogansMsg_Status.Text = "SafetySlogansMsg_Status:Not Select";
            FarewellMsg_Status.Text = "FarewellMsg_Status:Not Selected";
            TrainDetailMsg_Status.Text = "TrainDetailMsg_Status:Selected";
            PacketStatus.Text = "PacketStatus: Packet is being sent";
            DataSegment D = new DataSegment(0X45, 0X00, this.TrainNo, 0X05, 0X10, 0X05, 0X32, 0X0000, 19, 08, 14, 12, 38, 00);
            
            D.GenerateBlock2for_0x45(20,this.NextStation);
            
            byte[] b = D.GenerateDataSegment();
            Command_Packet P = new Command_Packet(0X02, 0X01, 0X00, 0X81, b);
            byte[] p = P.GetPackeBytes();
            
            SerialPort port = new SerialPort();
            port.PortName = "COM6";
            port.BaudRate = 9600;
            port.Parity = Parity.None;
            port.DataBits = 8;
            port.StopBits = StopBits.One;
            port.Open();
            port.Write(p, 0, P.Length);
            port.Close();
            PacketStatus.Text = "PacketStatus: Packet has been sent successfully ";
            
        }

        private void btn0X46_Click(object sender, EventArgs e)
        {
            WelcomMsg_Status.Text = "WelcomMsg_Status:Not Selected";
            DefaultMsg_Status.Text = "DefaultMsg_Status:Not Selected";
            SafetySlogansMsg_Status.Text = "SafetySlogansMsg_Status:Not Select";
            FarewellMsg_Status.Text = "FarewellMsg_Status:Not Selected";
            TrainDetailMsg_Status.Text = "TrainDetailMsg_Status:Selected";
            PacketStatus.Text = "PacketStatus: Packet is being sent";
            DataSegment D = new DataSegment(0X46, 0X00, this.TrainNo, 0X05, 0X10, 0X05, 0X32, 0X0000, 19, 08, 14, 12, 23, 00);
            
            D.GenerateBlock2for_0x46(20);
            
            byte[] b = D.GenerateDataSegment();
            Command_Packet P = new Command_Packet(0X02, 0X01, 0X00, 0X81, b);
            byte[] p = P.GetPackeBytes();
            
            SerialPort port = new SerialPort();
            port.PortName = "COM6";
            port.BaudRate = 9600;
            port.Parity = Parity.None;
            port.DataBits = 8;
            port.StopBits = StopBits.One;
            port.Open();
            port.Write(p, 0, P.Length);
            port.Close();
            PacketStatus.Text = "PacketStatus: Packet has been sent successfully ";
        }

        private void btn0X47_Click(object sender, EventArgs e)
        {
            WelcomMsg_Status.Text = "WelcomMsg_Status:Not Selected";
            DefaultMsg_Status.Text = "DefaultMsg_Status:Not Selected";
            SafetySlogansMsg_Status.Text = "SafetySlogansMsg_Status:Not Select";
            FarewellMsg_Status.Text = "FarewellMsg_Status:Not Selected";
            TrainDetailMsg_Status.Text = "TrainDetailMsg_Status:Selected";
            PacketStatus.Text = "PacketStatus: Packet is being sent";
            DataSegment D = new DataSegment(0X47, 0X00, this.TrainNo, 0X05, 0X10, 0X05, 0X32, 0X0000, 19, 08, 14, 12, 23, 00);
             D.GenerateBlock2for_0x47(01,00,this.NextStation);
            byte[] b = D.GenerateDataSegment();
            Command_Packet P = new Command_Packet(0X02, 0X01, 0X00, 0X81, b);
            byte[] p = P.GetPackeBytes();
            SerialPort port = new SerialPort();
            port.PortName = "COM6";
            port.BaudRate = 9600;
            port.Parity = Parity.None;
            port.DataBits = 8;
            port.StopBits = StopBits.One;
            port.Open();
            port.Write(p, 0, P.Length);
            port.Close();
            PacketStatus.Text = "PacketStatus: Packet has been sent successfully ";
        }

        private void btn0X48_Click(object sender, EventArgs e)
        {
            WelcomMsg_Status.Text = "WelcomMsg_Status:Not Selected";
            DefaultMsg_Status.Text = "DefaultMsg_Status:Not Selected";
            SafetySlogansMsg_Status.Text = "SafetySlogansMsg_Status:Not Select";
            FarewellMsg_Status.Text = "FarewellMsg_Status:Not Selected";
            TrainDetailMsg_Status.Text = "TrainDetailMsg_Status:Selected";
            PacketStatus.Text = "PacketStatus: Packet is being sent";
            DataSegment D = new DataSegment(0X48, 0X00, this.TrainNo, 0X05, 0X10, 0X05, 0X32, 0X0000, 19, 08, 14, 12, 23, 00);
           
            D.GenerateBlock2for_0x48(01, 00);
            byte[] b = D.GenerateDataSegment();
            Command_Packet P = new Command_Packet(0X02, 0X01, 0X00, 0X81, b);
            byte[] p = P.GetPackeBytes();
            
            SerialPort port = new SerialPort();
            port.PortName = "COM6";
            port.BaudRate = 9600;
            port.Parity = Parity.None;
            port.DataBits = 8;
            port.StopBits = StopBits.One;
            port.Open();
            port.Write(p, 0, P.Length);
            port.Close();
            PacketStatus.Text = "PacketStatus: Packet has been sent successfully ";
        
        }

        private void btn0X49_Click(object sender, EventArgs e)
        {
            WelcomMsg_Status.Text = "WelcomMsg_Status:Not Selected";
            DefaultMsg_Status.Text = "DefaultMsg_Status:Not Selected";
            SafetySlogansMsg_Status.Text = "SafetySlogansMsg_Status:Not Select";
            FarewellMsg_Status.Text = "FarewellMsg_Status:Not Selected";
            TrainDetailMsg_Status.Text = "TrainDetailMsg_Status:Selected";
            PacketStatus.Text = "PacketStatus: Packet is being sent";
            DataSegment D = new DataSegment(0X49, 0X00, this.TrainNo, 0X05, 0X10, 0X05, 0X32, 0X0000, 19, 08, 14, 12, 23, 00);
            
            D.GenerateBlock2for_0x49(12, 15);
           
            byte[] b = D.GenerateDataSegment();
            Command_Packet P = new Command_Packet(0X02, 0X01, 0X00, 0X81, b);
            byte[] p = P.GetPackeBytes();
            
            SerialPort port = new SerialPort();
            port.PortName = "COM6";
            port.BaudRate = 9600;
            port.Parity = Parity.None;
            port.DataBits = 8;
            port.StopBits = StopBits.One;
            port.Open();
            port.Write(p, 0, P.Length);
            port.Close();
            PacketStatus.Text = "PacketStatus: Packet has been sent successfully ";
        }

        private void btn0X4A_Click(object sender, EventArgs e)
        {
            WelcomMsg_Status.Text = "WelcomMsg_Status:Not Selected";
            DefaultMsg_Status.Text = "DefaultMsg_Status:Not Selected";
            SafetySlogansMsg_Status.Text = "SafetySlogansMsg_Status:Not Select";
            FarewellMsg_Status.Text = "FarewellMsg_Status:Not Selected";
            TrainDetailMsg_Status.Text = "TrainDetailMsg_Status:Selected";
            PacketStatus.Text = "PacketStatus: Packet is being sent";
            DataSegment D = new DataSegment(0X4A, 0X00, this.TrainNo, 0X05, 0X10, 0X05, 0X32, 0X0000, 19, 08, 14, 12, 23, 00);
            
            D.GenerateBlock2for_0x4A(01, 30);
            
            byte[] b = D.GenerateDataSegment();
            Command_Packet P = new Command_Packet(0X02, 0X01, 0X00, 0X81, b);
            byte[] p = P.GetPackeBytes();
            SerialPort port = new SerialPort();
            port.PortName = "COM6";
            port.BaudRate = 9600;
            port.Parity = Parity.None;
            port.DataBits = 8;
            port.StopBits = StopBits.One;
            port.Open();
            port.Write(p, 0, P.Length);
            port.Close();
            PacketStatus.Text = "PacketStatus: Packet has been sent successfully ";
        }

        private void btn0X4B_Click(object sender, EventArgs e)
        {
            WelcomMsg_Status.Text = "WelcomMsg_Status:Not Selected";
            DefaultMsg_Status.Text = "DefaultMsg_Status:Not Selected";
            SafetySlogansMsg_Status.Text = "SafetySlogansMsg_Status:Not Select";
            FarewellMsg_Status.Text = "FarewellMsg_Status:Not Selected";
            TrainDetailMsg_Status.Text = "TrainDetailMsg_Status:Selected";
            PacketStatus.Text = "PacketStatus:Packet is being sent";
            DataSegment D = new DataSegment(0X4B, 0X00, this.TrainName, 0X05, 0X10, 0X05, 0X32, 0X0000, 19, 08, 14, 04, 44, 00);

            D.GenerateBlock2for_0x4B(this.Speed);
            
            byte[] b = D.GenerateDataSegment();
            Command_Packet P = new Command_Packet(0X02, 0X01, 0X00, 0X81, b);
            byte[] p = P.GetPackeBytes();

            SerialPort port = new SerialPort();

            port.Parity = Parity.None;
            port.StopBits = StopBits.One;
            port.BaudRate = 9600;
            port.DataBits = 8;
            port.PortName = "COM6";
            port.Open();
            port.Write(p, 0, p.Length);
            port.Close();
            PacketStatus.Text = "PacketStatus: Packet has been sent successfully";
        }

        
        

        private void Station_List_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Station_List.SelectedItem != null)
            {
                this.PresentStation = Station_List.SelectedItem.ToString();

                if (Station_List.SelectedIndex < Station_List.Items.Count - 1)
                    this.NextStation = Station_List.Items[Station_List.SelectedIndex + 1].ToString();
                else
                    this.NextStation = "";

                this.Source_stn = Station_List.Items[0].ToString();
                this.Destination_stn = Station_List.Items[Station_List.Items.Count - 1].ToString();

                this.NextHaltingStation.Text = "Next Station: " + this.NextStation;
                this.lblPresentStation.Text = "Present Station: " + this.PresentStation;
            }                        
        }

        private void Train_List_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Train_List.SelectedItem != null)
            {
                this.TrainName = Train_List.SelectedItem.ToString();
                this.lblSelectedTrain.Text = "Train: " + this.TrainName;

                char[] delim = { ':' };
                string[] words = this.TrainName.Split(delim);

                this.TrainNo = words[0] + " ";
                this.TrainName = words[1].Substring(1);
            }            
        }

        private void RouteStatus_Click(object sender, EventArgs e)
        {
           
        }
        
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        

    }
}
