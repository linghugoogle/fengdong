using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 风动测试
{
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();            
        }
       
        public string PortName1;
        public string PortName2;
        public string PortName3;
        public string PortName4;
        public string PortName5;

        public double zedGraph_time;
        public double csv_time;       

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

        private void Setting_Load(object sender, EventArgs e)
        {
            SearchAndAddSerialToComboBox(comboBox1);
            SearchAndAddSerialToComboBox(comboBox2);
            SearchAndAddSerialToComboBox(comboBox3);
            SearchAndAddSerialToComboBox(comboBox4);
            SearchAndAddSerialToComboBox(comboBox5);

            comboBox1.Items.Add(Properties.Settings.Default.PortName1);
            comboBox1.Text = Properties.Settings.Default.PortName1;
            comboBox2.Items.Add(Properties.Settings.Default.PortName2);
            comboBox2.Text = Properties.Settings.Default.PortName2;
            comboBox3.Items.Add(Properties.Settings.Default.PortName3);
            comboBox3.Text = Properties.Settings.Default.PortName3;
            comboBox4.Items.Add(Properties.Settings.Default.PortName4);
            comboBox4.Text = Properties.Settings.Default.PortName4;
            comboBox5.Items.Add(Properties.Settings.Default.PortName5);
            comboBox5.Text = Properties.Settings.Default.PortName5;

            textBox1.Text = Properties.Settings.Default.csv_time;
            textBox2.Text = Properties.Settings.Default.zedGraph_time;          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if ((Convert.ToDouble(textBox1.Text) > 0) && (Convert.ToDouble(textBox2.Text) > 0))
                {
                    csv_time = Convert.ToDouble(textBox1.Text);
                    zedGraph_time = Convert.ToDouble(textBox2.Text);
                }
                else
                {
                    MessageBox.Show("请输入数字！");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("请不要输入非数字字符！");
                return;
            }
            PortName1 = comboBox1.Text;
            PortName2 = comboBox2.Text;
            PortName3 = comboBox3.Text;
            PortName4 = comboBox4.Text;
            PortName5 = comboBox5.Text;

            if ((PortName1.Length == 0) || (PortName2.Length == 0) || (PortName3.Length == 0) || (PortName4.Length == 0) || (PortName5.Length == 0))
            {
                MessageBox.Show("请选择串口！");
                return;
            }

            Properties.Settings.Default.csv_time = textBox1.Text;
            Properties.Settings.Default.zedGraph_time = textBox2.Text;
            Properties.Settings.Default.PortName1 = PortName1;
            Properties.Settings.Default.PortName2 = PortName2;
            Properties.Settings.Default.PortName3 = PortName3;
            Properties.Settings.Default.PortName4 = PortName4;
            Properties.Settings.Default.PortName5 = PortName5;
            Properties.Settings.Default.Save();
            DialogResult = System.Windows.Forms.DialogResult.OK;
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

        private void comboBox5_Click(object sender, EventArgs e)
        {
            SearchAndAddSerialToComboBox(comboBox5);
        }
    }
}
