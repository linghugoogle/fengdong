using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 风动测试
{
    public partial class ChooseData : Form
    {
        public ChooseData()
        {
            InitializeComponent();
        }
        string choose_flag;     //用于判断曲线显示选择，字符串第几位对应第几个传感器，1代表显示、0不显示

        char[] buf_front = new char[32];
        char[] buf_back = new char[32];
        //List<CheckBox> checkbox_item1 = new List<CheckBox>();
        List<CheckBox> checkbox_item = new List<CheckBox>();

        /// <summary>
        /// 通过check选择判断flag数据，flag数据记录到properties里用来记录曲线选择
        /// </summary>
        private void data_judge()
        {           
            for (int i = 0; i < 30; i++)
            {
                if (checkbox_item[i].Checked == true)
                {
                    buf_front[i] = '1';
                }
                else
                {
                    buf_front[i] = '0';
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            data_judge();
            choose_flag = new string(buf_front);      //将数组转换成字符串

            Properties.Settings.Default.choose_flag = choose_flag;
            Properties.Settings.Default.Save();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void checkbox_Add()
        {
            checkbox_item.Add(check1);
            checkbox_item.Add(check2);
            checkbox_item.Add(check3);
            checkbox_item.Add(check4);
            checkbox_item.Add(check5);
            checkbox_item.Add(check6);
            checkbox_item.Add(check7);
            checkbox_item.Add(check8);
            checkbox_item.Add(check9);
            checkbox_item.Add(check10);
            checkbox_item.Add(check11);
            checkbox_item.Add(check12);
            checkbox_item.Add(check13);
            checkbox_item.Add(check14);
            checkbox_item.Add(check15);
            checkbox_item.Add(check16);
            checkbox_item.Add(check17);
            checkbox_item.Add(check18);
            checkbox_item.Add(check19);
            checkbox_item.Add(check20);
            checkbox_item.Add(check21);
            checkbox_item.Add(check22);
            checkbox_item.Add(check23);
            checkbox_item.Add(check24);
            checkbox_item.Add(check25);
            checkbox_item.Add(check26);
            checkbox_item.Add(check27);
            checkbox_item.Add(check28);
            checkbox_item.Add(check29);
            checkbox_item.Add(check30);
        }

        private void ChooseData_Load(object sender, EventArgs e)
        {
            checkbox_Add();

            choose_flag = Properties.Settings.Default.choose_flag;
            char[] chars = choose_flag.ToCharArray();

            for (int i = 0; i < 30; i++)
            {
                if (chars[i] == '1')
                {
                    checkbox_item[i].Checked = true;
                }
                else
                {
                    checkbox_item[i].Checked = false;
                }
            }
        }

        /// <summary>
        /// 全选功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 30; i++)
            {
                checkbox_item[i].Checked = true;
            }
        }

        /// <summary>
        /// 反选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 30; i++)
            {
                if (checkbox_item[i].Checked == false)
                {
                    checkbox_item[i].Checked = true;
                }
                else
                {
                    checkbox_item[i].Checked = false;
                }
            }
        }

        /// <summary>
        /// 清除所有选项，同时判断前后端有没有重复，前端选中后端就会取消。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 30; i++)
            {
                checkbox_item[i].Checked = false;
            }
        }
    }
}
