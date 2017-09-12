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

            Properties.Settings.Default.csv_time = textBox1.Text;
            Properties.Settings.Default.zedGraph_time = textBox2.Text;
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
