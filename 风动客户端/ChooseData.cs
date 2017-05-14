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
        string choose_flag_front;     //用于判断曲线显示选择，字符串第几位对应第几个传感器，1代表显示、0不显示
        string choose_flag_back;      //后端 
        char[] buf_front = new char[32];
        char[] buf_back = new char[32];
        //List<CheckBox> checkbox_item1 = new List<CheckBox>();


        /// <summary>
        /// 通过check选择判断flag数据，flag数据记录到properties里用来记录曲线选择
        /// </summary>
        private void data_judge()
        {
            CheckBox[] checkbox_item_front = new CheckBox[32] { check1, check2, check3, check4, check5, check6, check7, check8,
                                                        checkBox9, check10, check11, check12, check13, check14, check15, check16,
                                                        check17, check18, check19, check20, check21, check22, check23, check24,
                                                        check25, check26, check27, check28, check29, check30, check31, check32 };

            CheckBox[] checkbox_item_back = new CheckBox[32] { checkBox64, checkBox63, checkBox62, checkBox61, checkBox60, checkBox59, checkBox58, checkBox57,
                                                        checkBox56, checkBox55, checkBox54, checkBox53, checkBox52, checkBox51, checkBox50, checkBox49,
                                                        checkBox48, checkBox47, checkBox46, checkBox45, checkBox44, checkBox43, checkBox42, checkBox41,
                                                        checkBox40, checkBox39, checkBox38, checkBox37, checkBox36, checkBox35, checkBox34, checkBox33 };

            if (tabControl1.SelectedIndex == 0)
            {
                for (int i = 0; i < 32; i++)
                {
                    if (checkbox_item_front[i].Checked == true)
                    {
                        checkbox_item_back[i].Checked = false;
                    }
                }
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                for (int i = 0; i < 32; i++)
                {
                    if (checkbox_item_back[i].Checked == true)
                    {
                        checkbox_item_front[i].Checked = false;
                    }
                }
            }
            for (int i = 0; i < 32; i++)
            {
                if (checkbox_item_front[i].Checked == true)
                {
                    buf_front[i] = '1';
                }
                else
                {
                    buf_front[i] = '0';
                }
            }

            for (int i = 0; i < 32; i++)
            {
                if (checkbox_item_back[i].Checked == true)
                {
                    buf_back[i] = '1';
                }
                else
                {
                    buf_back[i] = '0';
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            data_judge();
            choose_flag_front = new string(buf_front);      //将数组转换成字符串
            choose_flag_back = new string(buf_back);

            Properties.Settings.Default.choosedata_front = choose_flag_front;
            Properties.Settings.Default.choosedata_back = choose_flag_back;
            Properties.Settings.Default.Save();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void ChooseData_Load(object sender, EventArgs e)
        {
            CheckBox[] checkbox_item_front = new CheckBox[32] { check1, check2, check3, check4, check5, check6, check7, check8,
                                                        checkBox9, check10, check11, check12, check13, check14, check15, check16,
                                                        check17, check18, check19, check20, check21, check22, check23, check24,
                                                        check25, check26, check27, check28, check29, check30, check31, check32 };

            CheckBox[] checkbox_item_back = new CheckBox[32] { checkBox64, checkBox63, checkBox62, checkBox61, checkBox60, checkBox59, checkBox58, checkBox57,
                                                        checkBox56, checkBox55, checkBox54, checkBox53, checkBox52, checkBox51, checkBox50, checkBox49,
                                                        checkBox48, checkBox47, checkBox46, checkBox45, checkBox44, checkBox43, checkBox42, checkBox41,
                                                        checkBox40, checkBox39, checkBox38, checkBox37, checkBox36, checkBox35, checkBox34, checkBox33 };
        
            choose_flag_front = Properties.Settings.Default.choosedata_front;
            choose_flag_back = Properties.Settings.Default.choosedata_back;
            char[] chars = choose_flag_front.ToCharArray();
            for (int i = 0; i < 32; i++)
            {
                if (chars[i] == '1')
                {
                    checkbox_item_front[i].Checked = true;
                }
                else
                {
                    checkbox_item_front[i].Checked = false;
                }
            }
           
            chars = choose_flag_back.ToCharArray();
            for (int i = 0; i < 32; i++)
            {
                if (chars[i] == '1')
                {
                    checkbox_item_back[i].Checked = true;
                }
                else
                {
                    checkbox_item_back[i].Checked = false;
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
            CheckBox[] checkbox_item_front = new CheckBox[32] { check1, check2, check3, check4, check5, check6, check7, check8,
                                                        checkBox9, check10, check11, check12, check13, check14, check15, check16,
                                                        check17, check18, check19, check20, check21, check22, check23, check24,
                                                        check25, check26, check27, check28, check29, check30, check31, check32 };

            CheckBox[] checkbox_item_back = new CheckBox[32] { checkBox64, checkBox63, checkBox62, checkBox61, checkBox60, checkBox59, checkBox58, checkBox57,
                                                        checkBox56, checkBox55, checkBox54, checkBox53, checkBox52, checkBox51, checkBox50, checkBox49,
                                                        checkBox48, checkBox47, checkBox46, checkBox45, checkBox44, checkBox43, checkBox42, checkBox41,
                                                        checkBox40, checkBox39, checkBox38, checkBox37, checkBox36, checkBox35, checkBox34, checkBox33 };

            if (tabControl1.SelectedIndex == 0)
            {
                for (int i = 0; i < 32; i++)
                {
                    checkbox_item_front[i].Checked = true;
                    checkbox_item_back[i].Checked = false;
                }
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                for (int i = 0; i < 32; i++)
                {
                    checkbox_item_back[i].Checked = true;
                    checkbox_item_front[i].Checked = false;
                }
            }
        }

        /// <summary>
        /// 反选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            CheckBox[] checkbox_item_front = new CheckBox[32] { check1, check2, check3, check4, check5, check6, check7, check8,
                                                        checkBox9, check10, check11, check12, check13, check14, check15, check16,
                                                        check17, check18, check19, check20, check21, check22, check23, check24,
                                                        check25, check26, check27, check28, check29, check30, check31, check32 };

            CheckBox[] checkbox_item_back = new CheckBox[32] { checkBox64, checkBox63, checkBox62, checkBox61, checkBox60, checkBox59, checkBox58, checkBox57,
                                                        checkBox56, checkBox55, checkBox54, checkBox53, checkBox52, checkBox51, checkBox50, checkBox49,
                                                        checkBox48, checkBox47, checkBox46, checkBox45, checkBox44, checkBox43, checkBox42, checkBox41,
                                                        checkBox40, checkBox39, checkBox38, checkBox37, checkBox36, checkBox35, checkBox34, checkBox33 };

            if (tabControl1.SelectedIndex == 0)
            {
                for (int i = 0; i < 32; i++)
                {
                    if (checkbox_item_front[i].Checked == false)
                    {
                        checkbox_item_front[i].Checked = true;
                        checkbox_item_back[i].Checked = false;
                    }
                    else
                    {
                        checkbox_item_front[i].Checked = false;
                    }
                }
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                for (int i = 0; i < 32; i++)
                {
                    if (checkbox_item_back[i].Checked == false)
                    {
                        checkbox_item_back[i].Checked = true;
                        checkbox_item_front[i].Checked = false;
                    }
                    else
                    {
                        checkbox_item_back[i].Checked = false;
                    }
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
            CheckBox[] checkbox_item_front = new CheckBox[32] { check1, check2, check3, check4, check5, check6, check7, check8,
                                                        checkBox9, check10, check11, check12, check13, check14, check15, check16,
                                                        check17, check18, check19, check20, check21, check22, check23, check24,
                                                        check25, check26, check27, check28, check29, check30, check31, check32 };

            CheckBox[] checkbox_item_back = new CheckBox[32] { checkBox64, checkBox63, checkBox62, checkBox61, checkBox60, checkBox59, checkBox58, checkBox57,
                                                        checkBox56, checkBox55, checkBox54, checkBox53, checkBox52, checkBox51, checkBox50, checkBox49,
                                                        checkBox48, checkBox47, checkBox46, checkBox45, checkBox44, checkBox43, checkBox42, checkBox41,
                                                        checkBox40, checkBox39, checkBox38, checkBox37, checkBox36, checkBox35, checkBox34, checkBox33 };

            if (tabControl1.SelectedIndex == 0)
            {
                for (int i = 0; i < 32; i++)
                {
                    checkbox_item_front[i].Checked = false;
                }
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                for (int i = 0; i < 32; i++)
                {
                    checkbox_item_back[i].Checked = false;
                }
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            CheckBox[] checkbox_item_front = new CheckBox[32] { check1, check2, check3, check4, check5, check6, check7, check8,
                                                        checkBox9, check10, check11, check12, check13, check14, check15, check16,
                                                        check17, check18, check19, check20, check21, check22, check23, check24,
                                                        check25, check26, check27, check28, check29, check30, check31, check32 };

            CheckBox[] checkbox_item_back = new CheckBox[32] { checkBox64, checkBox63, checkBox62, checkBox61, checkBox60, checkBox59, checkBox58, checkBox57,
                                                        checkBox56, checkBox55, checkBox54, checkBox53, checkBox52, checkBox51, checkBox50, checkBox49,
                                                        checkBox48, checkBox47, checkBox46, checkBox45, checkBox44, checkBox43, checkBox42, checkBox41,
                                                        checkBox40, checkBox39, checkBox38, checkBox37, checkBox36, checkBox35, checkBox34, checkBox33 };

            if (tabControl1.SelectedIndex == 0)
            {
                for (int i = 0; i < 32; i++)
                {
                    if (checkbox_item_back[i].Checked == true)
                    {
                        checkbox_item_front[i].Checked = false;
                    }
                }
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                for (int i = 0; i < 32; i++)
                {
                    if (checkbox_item_front[i].Checked == true)
                    {
                        checkbox_item_back[i].Checked = false;
                    }
                }
            }
        }
    }
}
