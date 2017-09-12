using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 风动测试
{
    class Serial
    {
        public SerialPort serialPort1 = new SerialPort();
        public SerialPort serialPort2 = new SerialPort();
        public SerialPort serialPort3 = new SerialPort();
        public SerialPort serialPort4 = new SerialPort();
      
        public void Serial_Init()
        {
            serialPort1.PortName = "COM9";
            serialPort2.PortName = "COM10";
            serialPort3.PortName = "COM11";
            serialPort4.PortName = "COM12";
            
            serialPort1.BaudRate = 115200;
            serialPort2.BaudRate = 115200;
            serialPort3.BaudRate = 115200;
            serialPort4.BaudRate = 115200;

            //try
            //{
            //    serialPort3.Open();
            //}
            //catch
            //{
            //    MessageBox.Show("串口打开错误!");
            //}
            serialPort1.DataReceived += serialPort1_DataReceived;
            serialPort2.DataReceived += serialPort2_DataReceived;
            serialPort3.DataReceived += serialPort3_DataReceived;
            serialPort4.DataReceived += serialPort4_DataReceived;          
        }

        public string[] SerialDataReceived = new string[32];   //串口接收数组

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string str = null;
            try
            {
                str = serialPort1.ReadTo("\r\n");
                if (str.Contains("DHT"))
                {
                    DhtTemp = Convert.ToInt16(str.Substring(str.IndexOf("DHT") + 3, str.IndexOf(",") - str.IndexOf("T") - 1));
                    DhtHumi = Convert.ToInt16(str.Substring(str.IndexOf(",") + 1, str.Length - str.IndexOf(",") - 1));
                }
                int ch;
                ch = Convert.ToInt16(str.Substring(str.IndexOf("CH") + 2, 2));

                SerialDataReceived[ch - 1] = str.Substring(5, 8);
            }
            catch
            { }           
        }

        private void serialPort2_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string str = null;
            try
            {
                str = serialPort2.ReadTo("\r\n");
                if (str.Contains("DHT"))
                {
                    DhtTemp = Convert.ToInt16(str.Substring(str.IndexOf("DHT") + 3, str.IndexOf(",") - str.IndexOf("T") - 1));
                    DhtHumi = Convert.ToInt16(str.Substring(str.IndexOf(",") + 1, str.Length - str.IndexOf(",") - 1));
                }
                int ch;
                ch = Convert.ToInt16(str.Substring(str.IndexOf("CH") + 2, 2));

                SerialDataReceived[ch + 7] = str.Substring(5, 8);
            }
            catch
            { }           
        }

        private void serialPort3_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string str = null;
            try
            {
                str = serialPort3.ReadTo("\r\n");
                if (str.Contains("DHT"))
                {
                    DhtTemp = Convert.ToInt16(str.Substring(str.IndexOf("DHT") + 3, str.IndexOf(",") - str.IndexOf("T") - 1));
                    DhtHumi = Convert.ToInt16(str.Substring(str.IndexOf(",") + 1, str.Length - str.IndexOf(",") - 1));
                }
                int ch;
                ch = Convert.ToInt16(str.Substring(str.IndexOf("CH") + 2, 2));

                SerialDataReceived[ch + 15] = str.Substring(5, 8);
            }
            catch
            { }      
        }

        public int DhtTemp;
        public int DhtHumi;
        private void serialPort4_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string str = null;
            try
            {
                str = serialPort4.ReadTo("\r\n");
                if (str.Contains("DHT"))
                {
                    DhtTemp = Convert.ToInt16(str.Substring(str.IndexOf("DHT") + 3, str.IndexOf(",") - str.IndexOf("T") - 1));
                    DhtHumi = Convert.ToInt16(str.Substring(str.IndexOf(",") + 1, str.Length - str.IndexOf(",") - 1));
                }
                int ch;
                ch = Convert.ToInt16(str.Substring(str.IndexOf("CH") + 2, 2));

                SerialDataReceived[ch + 23] = str.Substring(5, 8);
            }
            catch
            { }            
        }
    }
}
