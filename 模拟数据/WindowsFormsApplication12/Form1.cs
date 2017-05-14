using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }     

        private void Form1_Load(object sender, EventArgs e)
        {
            SearchAndAddSerialToComboBox(comboBox1);
            SearchAndAddSerialToComboBox(comboBox2);
            SearchAndAddSerialToComboBox(comboBox3);
            SearchAndAddSerialToComboBox(comboBox4);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "开始")
            {
                timer1.Enabled = true;
                button2.Text = "停止";
            }
            else
            {
                timer1.Enabled = false;
                button2.Text = "开始";
            }
        }


        double[] mean_value = new double[8] { 2.5, 2.5, 2.5, 2.5, 2.5, 2.5, 2.5, 2.5 };
        Random ran = new Random();

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                serialPort1.Write("CH");
                serialPort1.Write((i + 1).ToString("00"));
                serialPort1.Write(" ");
                serialPort1.Write((mean_value[i] + (double)(ran.Next(Convert.ToInt16(textBox3.Text))) / 100).ToString("0.000000"));
                //serialPort1.Write(mean_value[i].ToString("0.000000"));
                serialPort1.Write("\r\n");
            }


            for (int i = 0; i < 8; i++)
            {
                serialPort2.Write("CH");
                serialPort2.Write((i + 1).ToString("00"));
                serialPort2.Write(" ");
                serialPort2.Write((mean_value[i] + (double)(ran.Next(Convert.ToInt16(textBox4.Text))) / 100).ToString("0.000000"));
                //serialPort1.Write(mean_value[i].ToString("0.000000"));
                serialPort2.Write("\r\n");
            }


            for (int i = 0; i < 8; i++)
            {
                serialPort3.Write("CH");
                serialPort3.Write((i + 1).ToString("00"));
                serialPort3.Write(" ");
                serialPort3.Write((mean_value[i] + (double)(ran.Next(Convert.ToInt16(textBox6.Text))) / 100).ToString("0.000000"));
                //serialPort1.Write(mean_value[i].ToString("0.000000"));
                serialPort3.Write("\r\n");
            }


            for (int i = 0; i < 8; i++)
            {
                serialPort4.Write("CH");
                serialPort4.Write((i + 1).ToString("00"));
                serialPort4.Write(" ");
                serialPort4.Write((mean_value[i] + (double)(ran.Next(Convert.ToInt16(textBox8.Text))) / 100).ToString("0.000000"));
                //serialPort1.Write(mean_value[i].ToString("0.000000"));
                serialPort4.Write("\r\n");
            }
        }

        /*串口端口扫描功能*/
        private void SearchAndAddSerialToComboBox(ComboBox Mybox)
        {
            Mybox.Items.Clear();
            String[] Portname = SerialPort.GetPortNames();
            foreach (string str in Portname)
            {
                Mybox.Items.Add(str);
            }
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            SearchAndAddSerialToComboBox(comboBox1);
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            SearchAndAddSerialToComboBox(comboBox2);
        }

        private void comboBox3_Click(object sender, EventArgs e)
        {
            SearchAndAddSerialToComboBox(comboBox3);
        }

        private void comboBox4_Click(object sender, EventArgs e)
        {
            SearchAndAddSerialToComboBox(comboBox4);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "开启")
            {
                try
                {
                    button1.Text = "关闭";
                    serialPort1.PortName = comboBox1.Text;
                    serialPort1.BaudRate = 115200;
                    serialPort1.Open();
                }
                catch
                {
                    MessageBox.Show("串口开启错误，请检查！");
                }
            }
            else
            {
                button1.Text = "开启";
                serialPort1.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "开启")
            {
                try
                {
                    button3.Text = "关闭";
                    serialPort2.PortName = comboBox2.Text;
                    serialPort2.BaudRate = 115200;
                    serialPort2.Open();
                }
                catch
                {
                    MessageBox.Show("串口开启错误，请检查！");
                }
            }
            else
            {
                button3.Text = "开启";
                serialPort2.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text == "开启")
            {
                try
                {
                    button5.Text = "关闭";
                    serialPort3.PortName = comboBox3.Text;
                    serialPort3.BaudRate = 115200;
                    serialPort3.Open();
                }
                catch
                {
                    MessageBox.Show("串口开启错误，请检查！");
                }
            }
            else
            {
                button5.Text = "开启";
                serialPort3.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.Text == "开启")
            {
                try
                {
                    button7.Text = "关闭";
                    serialPort4.PortName = comboBox4.Text;
                    serialPort4.BaudRate = 115200;
                    serialPort4.Open();
                }
                catch
                {
                    MessageBox.Show("串口开启错误，请检查！");
                }
            }
            else
            {
                button7.Text = "开启";
                serialPort4.Close();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black, 2);
            pen.DashStyle = DashStyle.Solid;
            e.Graphics.DrawRectangle(pen, panel2.DisplayRectangle);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black, 2);
            pen.DashStyle = DashStyle.Solid;
            e.Graphics.DrawRectangle(pen, panel1.DisplayRectangle);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black, 2);
            pen.DashStyle = DashStyle.Solid;
            e.Graphics.DrawRectangle(pen, panel3.DisplayRectangle);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black, 2);
            pen.DashStyle = DashStyle.Solid;
            e.Graphics.DrawRectangle(pen, panel4.DisplayRectangle);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "总开启")
            {
                try
                {
                    button4.Text = "总关闭";
                    serialPort1.PortName = "COM31";
                    serialPort2.PortName = "COM32";
                    serialPort3.PortName = "COM33";
                    serialPort4.PortName = "COM34";

                    serialPort1.Open();
                    serialPort2.Open();
                    serialPort3.Open();
                    serialPort4.Open();
                }
                catch
                {
                    MessageBox.Show("串口开启错误，请检查！");
                }
            }
            else
            {
                button4.Text = "总关闭";
                serialPort1.Close();
                serialPort2.Close();
                serialPort3.Close();
                serialPort4.Close();
            }
        }
    }
}
