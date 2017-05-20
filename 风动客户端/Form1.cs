using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using ZedGraph;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace 风动测试
{
    public partial class Form1 : Form
    {
        XML MyXml = new XML();
        Serial serial = new Serial();

       
        public Form1()
        {
            InitializeComponent();
            //SetWindowLong(this.Handle, GWL_STYLE, (uint)(GetWindowLong(this.Handle, GWL_STYLE) & ~WS_CAPTION));        
        }

        string[] str_buf_front = new string[32];  //存放读取的AD数值，前20个数据。        
        string[] str_buf_back = new string[32];  //存放读取的AD数值，后20个数据。     
        double[] numScale = new double[32];    //乘以一个系数减小误差

        char[] buf_front = new char[32];        //保存曲线选择的数据，32位每位对应一个传感器，1显示0不显示，front对应前端back对应后端
        char[] buf_back = new char[32];

        public static string[,] set_value = new string[2, 32];   //xml中所存储的所有参数，选择参数时进行调用，程序结束时再进行存储。

        bool CaijiFlag = false;     //开始采集标志位

        //曲线初始化
        #region
        private readonly int chartPoint = 200;

        private void init_zedgragh()
        {
            GraphPane mGraphPane;
            
            zedGraphControl1.PanModifierKeys = Keys.None;//曲线可以左键拖拽
            zedGraphControl1.ZoomStepFraction = 0.1;//（这是鼠标滚轮缩放的比例大小，值越大缩放就越灵敏）

            zedGraphControl1.IsShowHScrollBar = true;
            mGraphPane = zedGraphControl1.GraphPane;
            mGraphPane.Title.Text = "压力数据";
            //添加两个Y轴，分别显示电压、电流
            mGraphPane.XAxis.Title.Text = "时间";
            mGraphPane.YAxis.Title.Text = "压力值";


            mGraphPane.Y2Axis.IsVisible = false;
            mGraphPane.YAxis.Scale.FontSpec.FontColor = Color.Blue;
            mGraphPane.YAxis.Title.FontSpec.FontColor = Color.Blue;

            mGraphPane.XAxis.Scale.Min = 0;      //X轴最小值0
            mGraphPane.XAxis.Scale.Max = 50;     //时间最大值30分钟
            mGraphPane.XAxis.Scale.MinorStep = 1;//X轴小步长1,也就是小间隔
            mGraphPane.XAxis.Scale.MajorStep = 10;//X轴大步长为5，也就是显示文字的大间隔

            mGraphPane.YAxis.Scale.MinorStep = 1;//X轴小步长1,也就是小间隔
            mGraphPane.YAxis.Scale.MajorStep = 5;//X轴大步长为5，也就是显示文字的大间隔

            mGraphPane.YAxis.Scale.Min = 90;      //电压轴最小值0
            mGraphPane.YAxis.Scale.Max = 110;    //电压最大值

            // Display the Y axis grid lines
            mGraphPane.YAxis.MajorGrid.IsVisible = true;
            mGraphPane.YAxis.MinorGrid.IsVisible = true;

            // Fill the axis background with a color gradient
            mGraphPane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245), Color.FromArgb(255, 255, 190), 90F);
            mGraphPane.Fill = new Fill(Color.White, Color.FromArgb(220, 255, 255), 45.0f);
            mGraphPane.CurveList.Clear();

            RollingPointPairList[] lists = new RollingPointPairList[32];
            mGraphPane.CurveList.Clear();
            for (int i = 0; i < 32; i++)
            {
                lists[i] = new RollingPointPairList(chartPoint);
                LineItem myCurve = mGraphPane.AddCurve("", lists[i], color[i], SymbolType.None);              
            }
        }
        #endregion

        //Check添加list
        #region
        //目前定义了32个颜色，如果不够请再添加，以防后续数组溢出。可根据自己的喜好再次修改颜色
        System.Drawing.Color[] color = new System.Drawing.Color[32] { System.Drawing.Color.Blue, System.Drawing.Color.Red ,System.Drawing.Color.Green,System.Drawing.Color.Gold,System.Drawing.Color.Gray,System.Drawing.Color.SkyBlue,System.Drawing.Color.Black,System.Drawing.Color.DarkBlue,
                                            System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkRed ,System.Drawing.Color.LightGray,
                                            System.Drawing.Color.IndianRed,System.Drawing.Color.LightCoral,System.Drawing.Color.Turquoise,System.Drawing.Color.YellowGreen,System.Drawing.Color.Yellow,System.Drawing.Color.Olive,
                                            System.Drawing.Color.OliveDrab,System.Drawing.Color.PeachPuff,System.Drawing.Color.SeaShell,System.Drawing.Color.Cyan,System.Drawing.Color.Pink,System.Drawing.Color.Orchid,System.Drawing.Color.Plum,
                                            System.Drawing.Color.MediumPurple,System.Drawing.Color.SlateGray,System.Drawing.Color.SeaGreen,System.Drawing.Color.RoyalBlue,System.Drawing.Color.OliveDrab,System.Drawing.Color.Indigo};

        List<CheckBox> cbList = new List<CheckBox>();
     
        private void Check_List_Add()
        {
            char[] buf = new char[32];
            //把checkbox关联到list里面
            cbList.Add(checkBox1);
            cbList.Add(checkBox2);
            cbList.Add(checkBox3);
            cbList.Add(checkBox4);
            cbList.Add(checkBox5);
            cbList.Add(checkBox6);
            cbList.Add(checkBox7);
            cbList.Add(checkBox8);
            cbList.Add(checkBox9);
            cbList.Add(checkBox10);
            cbList.Add(checkBox11);
            cbList.Add(checkBox12);
            cbList.Add(checkBox13);
            cbList.Add(checkBox14);
            cbList.Add(checkBox15);
            cbList.Add(checkBox16);
            cbList.Add(checkBox17);
            cbList.Add(checkBox18);
            cbList.Add(checkBox19);
            cbList.Add(checkBox20);
            cbList.Add(checkBox21);
            cbList.Add(checkBox22);
            cbList.Add(checkBox23);
            cbList.Add(checkBox24);
            cbList.Add(checkBox25);
            cbList.Add(checkBox26);
            cbList.Add(checkBox27);
            cbList.Add(checkBox28);
            cbList.Add(checkBox29);
            cbList.Add(checkBox30);
            cbList.Add(checkBox31);
            cbList.Add(checkBox32);

            //checkbox开启读取默认值
            buf = Properties.Settings.Default.CurveFlag.ToCharArray();         //读取曲线选择设置

            for (int i = 0; i < 32; i++)
            {
                if (buf[i] == '1')
                {
                    cbList[i].Checked = true;
                }
                else
                {
                    cbList[i].Checked = false;
                }
            }
            //依据color[]数组设置checkbox的颜色，并通过该数组与曲线的颜色关联
            for (int i = 0; i < 32; i++)
            {
                cbList[i].ForeColor = color[i];
                cbList[i].CheckedChanged += new System.EventHandler(checkBox_CheckedChanged);
            }
        }

        //checkbox变化事件
        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            char[] buf = new char[32];
            for (int i = 0; i < 32; i++)
            {
                if (cbList[i].Checked == true)
                {
                    buf[i] = '1';
                }
                else
                {
                    buf[i] = '0';
                }
            }
            string CurveFlag = new string(buf);
            Properties.Settings.Default.CurveFlag = CurveFlag;
            Properties.Settings.Default.Save();
        }
        #endregion

        private void Parameter_Init()
        {
            //properties值读取
            //buf_front = Properties.Settings.Default.choosedata_front.ToCharArray();         //读取曲线选择设置
            //buf_back = Properties.Settings.Default.choosedata_back.ToCharArray();

            //timer1.Interval = (int)(Convert.ToDouble(Properties.Settings.Default.csv_time) * 1000);
            //timer2.Interval = (int)(Convert.ToDouble(Properties.Settings.Default.zedGraph_time) * 1000);
            //timer4.Interval = (int)(Convert.ToDouble(Properties.Settings.Default.zedGraph_time) * 1000);

            //vScrollBar1.Value = Convert.ToInt16(Properties.Settings.Default.vScrollBarValue);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Check_List_Add();
            zedGraphControl1.Size = new Size(776, 577);     //曲线大小初始化
            
            //datagridview 格式设置          
            //行标题隐藏
            dataGridView1.RowHeadersVisible = false;
            
            dataGridView1.DefaultCellStyle.BackColor = Color.LightCyan;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Blue;
            dataGridView1.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 13F);
            //列标题隐藏
            //dataGridView1.ColumnHeadersVisible = false;
            // 禁止用户改变DataGridView1的所有列的列宽
            dataGridView1.AllowUserToResizeColumns = false;
            //禁止用户改变DataGridView1所有行的行高
            dataGridView1.AllowUserToResizeRows = false;
            //dataGridView1添加50行
            for (int i = 0; i < 32; i++)
            {
                int index = this.dataGridView1.Rows.Add();
            }
            //datagridview 格式设置结束

            init_zedgragh();        //曲线初始化设置
            
            MyXml.Create_Xml();      //创建xml 
            MyXml.Read_Xml();     //读取xml      

            //label1.Text = ((double)vScrollBar1.Value / 100).ToString("00.00") + "HZ";

            int FenjiSpeed = (int)(1450 * ((double)vScrollBar1.Value / 6000));
            lbAnalogMeter3.Value = (double)FenjiSpeed;
            label1.Text = FenjiSpeed.ToString() + "r/min";

            for (int i=0;i<32;i++)
            {
                numScale[i] = Convert.ToDouble(set_value[0, i]);
            }

            Control.CheckForIllegalCrossThreadCalls = false;
            Client_Connect();
        }     

        //定时存CSV格式的数据，文件名按照时间生成
        #region
        private void timer1_Tick(object sender, EventArgs e)
        {
            char[] buf = new char[32];
            for (int n = 0; n < 32; n++)
            {
                buf[n] = (char)(buf_front[n] | buf_back[n]);
            }

            string filePathName = DateTime.Now.ToString("yyyyMd") + ".csv";
            StreamWriter fileWriter = null;
            filePathName = Application.StartupPath + "\\DATA\\" + filePathName;

            //判断根目录是否存在DATA
            if (!Directory.Exists(Application.StartupPath + "\\DATA"))
            {
                Directory.CreateDirectory(Application.StartupPath + "\\DATA");
            }

            try
            {
                //创建文件，如果不存在。
                if (!File.Exists(filePathName))
                {
                    fileWriter = new StreamWriter(filePathName, true, Encoding.Default);
                    fileWriter.Write("时间");
                    fileWriter.Write(",");
                    fileWriter.Write("前端压力平均值(kPa)");
                    fileWriter.Write(",");
                    fileWriter.Write("后端压力平均值(kPa)");
                    for (int i = 0; i < 32; i++)
                    {
                        fileWriter.Write(",");
                        fileWriter.Write("传感器{0}(kPa)", i + 1);
                    }
                    fileWriter.Write("\r\n");
                    fileWriter.Flush();
                    fileWriter.Close();
                }

                //数据存储
                fileWriter = new StreamWriter(filePathName, true, Encoding.Default);
                fileWriter.Write(DateTime.Now.ToString("hh:mm:ss"));
                fileWriter.Write(",");
                fileWriter.Write(Math.Round(lbDigitalMeter1.Value, 2));
                fileWriter.Write(",");
                fileWriter.Write(Math.Round(lbDigitalMeter2.Value, 2));
                for (int i = 0; i < 32; i++)
                {
                    fileWriter.Write(",");
                    if (buf[i] == '1')
                    {
                        fileWriter.Write(dataChange1[i]);
                    }
                }
                fileWriter.Write("\r\n");
                fileWriter.Flush();
                fileWriter.Close();
            }
            catch
            {              
                timerCsv.Enabled = false;
                DialogResult dr = MessageBox.Show("文件存储出错，请关闭！");
                if (dr == DialogResult.OK)
                {
                    timerCsv.Enabled = true;
                }
            }
        }
        #endregion

        double time;
        private void timer2_Tick(object sender, EventArgs e)
        {
            time++;
            
            LineItem[] curve = new LineItem[32];
            IPointListEdit[] pLists = new IPointListEdit[32];
            char[] buf = new char[32];
            for (int n = 0; n < 32; n++)
            {
                buf[n] = (char)(buf_front[n] | buf_back[n]);
            }
            for (int i = 0; i < 32; i++)
            {
                if (cbList[i].Checked && buf[i] == '1')
                {
                    //取Graph第一个曲线，也就是第一步:在GraphPane.CurveList集合中查找CurveItem
                    curve[i] = zedGraphControl1.GraphPane.CurveList[i] as LineItem;
                    if (curve[i] == null)
                    {
                        return;
                    }
                    //第二步:在CurveItem中访问PointPairList(或者其它的IPointList)，根据自己的需要增加新数据或修改已存在的数据
                    pLists[i] = curve[i].Points as IPointListEdit;
                    if (pLists[i] == null)
                    {
                        return;
                    }

                    pLists[i].Add(time, Convert.ToDouble(dataChange1[i]));
                }

            }
            
            Scale xScale = zedGraphControl1.GraphPane.XAxis.Scale;
            if (time > xScale.Max - xScale.MajorStep)
            {
                xScale.Max = time + xScale.MajorStep;
                xScale.Min = xScale.Max - 60.0;
                zedGraphControl1.ScrollMaxX = xScale.Max;
                //前面设置点的数目，大于则重现开始从0开始
                if (xScale.Max >= 400)
                {
                    zedGraphControl1.ScrollMinX = 0;
                    zedGraphControl1.ScrollMaxX = 100;
                    zedGraphControl1.GraphPane.XAxis.Scale.Max = 60;
                    zedGraphControl1.GraphPane.XAxis.Scale.Min = 0;
                    for (int i = 0; i < 32; i++)
                    {
                        if (pLists[i] != null)
                            pLists[i].Clear();
                    }
                    time = 0;
                }
            }
            this.zedGraphControl1.Refresh();
        }

        private void 更新AD配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //标准大气压下电压4.3V对应的AD值2668,算出对应的系数。
            for (int i = 0; i < 32; i++)
            {              
                numScale[i] = 2507 / Convert.ToDouble(serial.SerialDataReceived[i]);
                set_value[0, i] = (2507 / Convert.ToDouble(serial.SerialDataReceived[i])).ToString("0.00000");
            }
            MyXml.Set_Xml();
        }

        private void 串口设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setting set = new Setting();
            timerCsv.Enabled = false;
            timerCure.Enabled = false;

            if (set.ShowDialog() == DialogResult.OK)
            {                                         
                try
                {
                    timerCsv.Interval = (int)(set.csv_time * 1000);
                    timerCure.Interval = (int)(set.zedGraph_time * 1000);
                }
                catch
                {
                    MessageBox.Show("参数设置错误");
                }              
            }
            button3.Enabled = true;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            label41.Text = DateTime.Now.ToString("hh:mm:ss");        
        }


        private void 曲线设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChooseData choosedata = new ChooseData();
            timerCsv.Enabled = false;
            timerCure.Enabled = false;
            if (choosedata.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    buf_front = Properties.Settings.Default.choosedata_front.ToCharArray();
                    buf_back = Properties.Settings.Default.choosedata_back.ToCharArray();
                }
                catch
                {
                    MessageBox.Show("串口开启错误，请检查！");
                }
            }
            button3.Enabled = true;
        }

        private bool MouseDoubleClickFlag = true;
        private void zedGraphControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MouseDoubleClickFlag = !MouseDoubleClickFlag;
            if (MouseDoubleClickFlag == true)
            {
                zedGraphControl1.Size = new Size(776, 577);
            }
            else
            {
                zedGraphControl1.Size = new Size(776, 489);
            }
        }

        //
        // 设置变频器部分
        //
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "开启风机")
            {
                //风机开启
                button1.Text = "关闭风机";             
                //serialPort2.Write(":FF0620000010CB" + "\r\n");          //反转
                serialPort5.Write(":FF0620000002D9" + "\r\n");
            }
            else
            {
                //风机关闭
                button1.Text = "开启风机";
                serialPort5.Write(":FF0620000001DA" + "\r\n");
            }
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            int hi = (vScrollBar1.Value & 0xff00) >> 8;
            int low = vScrollBar1.Value & 0xff;
            byte sum;
            sum = (byte)(0xFF + 0x06 + 0x20 + 0x01 + hi + low);
            sum = (byte)(~sum + 1);

            string a = Convert.ToString(hi, 16);
            string b = Convert.ToString(low, 16);
            string c = Convert.ToString(sum, 16);

            if (a.Length == 1)
            {
                a = "0" + a;
            }
            if (b.Length == 1)
            {
                b = "0" + b;
            }
            if (c.Length == 1)
            {
                c = "0" + c;
            }

            string str = ":FF062001" + a + b + c;
            if (button1.Text == "关闭风机")
            {                
                int FenjiSpeed = (int)(1450 * ((double)vScrollBar1.Value / 6000));
                lbAnalogMeter3.Value = (double)FenjiSpeed;
                label1.Text = FenjiSpeed.ToString() + "r/min";
                serialPort5.Write(str + "\r\n");
                Properties.Settings.Default.vScrollBarValue = vScrollBar1.Value.ToString();
                Properties.Settings.Default.Save();
            }              
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort5.Write(":FF0620020002D7" + "\r\n");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MsgSend = Encoding.Default.GetBytes("start");
            try
            {
                if (ClientSocket.Connected)
                {
                    ClientSocket.Send(MsgSend);
                }
            }
            catch
            {
                MessageBox.Show("当前与服务器断开连接，请重新连接！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            button3.Enabled = false;
            button4.Enabled = true;
            timerCsv.Enabled = true;
            timerCure.Enabled = true;
            CaijiFlag = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timerCsv.Enabled = false;
            timerCure.Enabled = false;
            CaijiFlag = false;
            try
            {
                button3.Enabled = true;
                button4.Enabled = false;
            }
            catch
            {
                MessageBox.Show("串口开启错误！");
            }
        }

        string[] dataChange1 = new string[32];
        string[] dataChange = new string[32];     //存放转换后的数据。       
        //
        //socket部分
        //
        private IPEndPoint ServerInfo;

        private Socket ClientSocket;

        private Byte[] MsgBuffer;

        private Byte[] MsgSend;

        private void Connection()
        {
            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            MsgBuffer = new Byte[65535];
            MsgSend = new Byte[65535];
            CheckForIllegalCrossThreadCalls = false;
        }

        //private void CmdExit_Click(object sender, EventArgs e)
        //{
        //    if (ClientSocket.Connected)
        //    {
        //        string msg = "离开了房间！\n";
        //        ClientSocket.Send(Encoding.Default.GetBytes(msg));
        //        ClientSocket.Shutdown(SocketShutdown.Both);
        //        ClientSocket.Disconnect(false);
        //    }
        //    ClientSocket.Close();

        //    this.CmdEnter.Enabled = true;
        //    this.CmdExit.Enabled = false;
        //}

        /// <summary>
        /// socket接收到的数据进行处理显示到界面上
        /// </summary>
        /// <param name="AR"></param>
        private void ReceiveCallBack(IAsyncResult AR)
        {
            string str;
            int m = 0;
            int n = 0;
            double average_value_front = 0;
            double average_value_back = 0;
            string temperature;
            string humidity;
            string[] num_buf_front = new string[32];
            string[] num_buf_back = new string[32];
            char[] buf = new char[32];

            try
            {
                //接收socket数据
                int REnd = ClientSocket.EndReceive(AR);
                str = Encoding.Default.GetString(MsgBuffer, 0, REnd);
                ClientSocket.BeginReceive(MsgBuffer, 0, MsgBuffer.Length, 0, new AsyncCallback(ReceiveCallBack), null);

                if (str.Contains("Parameter"))
                {
                    timerCsv.Enabled = false;
                    timerCure.Enabled = false;
                    button3.Enabled = true;
                    button4.Enabled = false;
                    CaijiFlag = false;

                    Properties.Settings.Default.csv_time = str.Substring(str.IndexOf("Parameter") + 9, str.IndexOf("!") - 9);
                    Properties.Settings.Default.zedGraph_time = str.Substring(str.IndexOf("!") + 1, str.IndexOf("@") - str.IndexOf("!") - 1);
                    Properties.Settings.Default.choosedata_front = str.Substring(str.IndexOf("@") + 1, str.IndexOf("#") - str.IndexOf("@") - 1);
                    Properties.Settings.Default.choosedata_back = str.Substring(str.IndexOf("#") + 1, str.IndexOf("$") - str.IndexOf("#") - 1);
                    Properties.Settings.Default.CurveFlag = str.Substring(str.IndexOf("$") + 1, str.IndexOf("%") - str.IndexOf("$") - 1);
                    Properties.Settings.Default.vScrollBarValue = str.Substring(str.IndexOf("%") + 1, str.IndexOf("^") - str.IndexOf("%") - 1);
                    Properties.Settings.Default.Save();

                    buf_front = Properties.Settings.Default.choosedata_front.ToCharArray();         //读取曲线选择设置
                    buf_back = Properties.Settings.Default.choosedata_back.ToCharArray();

                    timerCsv.Interval = (int)(Convert.ToDouble(Properties.Settings.Default.csv_time) * 1000);
                    timerCure.Interval = (int)(Convert.ToDouble(Properties.Settings.Default.zedGraph_time) * 1000);

                    //checkbox开启读取默认值
                    buf = Properties.Settings.Default.CurveFlag.ToCharArray();         //读取曲线选择设置

                    for (int i = 0; i < 32; i++)
                    {
                        if (buf[i] == '1')
                        {
                            cbList[i].Checked = true;
                        }
                        else
                        {
                            cbList[i].Checked = false;
                        }
                    }

                    vScrollBar1.Value = Convert.ToInt16(Properties.Settings.Default.vScrollBarValue);

                    return;
                }
                if (CaijiFlag == false)
                {
                    return;
                }
                //处理字符串并显示              
                try
                {
                    string[] buf_front = new string[20];
                    string[] buf_back = new string[20];

                    //根据曲线选择，将不需要显示的数据清零
                    for (int i = 0; i < 32; i++)
                    {
                        dataGridView1.Rows[i].Cells[0].Value = "";
                        dataGridView1.Rows[i].Cells[1].Value = "";
                        dataGridView1.Rows[i].Cells[2].Value = "";
                        dataGridView1.Rows[i].Cells[3].Value = "";
                    }

                    //数据处理部分
                    int start = str.IndexOf("front") + 5;
                    int end = str.IndexOf("back");
                    for (int i = 0; i < (end - start) / 10; i++)
                    {
                        num_buf_front[i] = str.Substring(start + i * 10, 2);
                        str_buf_front[i] = str.Substring(start + 3 + i * 10, 6);
                        dataGridView1.Rows[m].Cells[0].Value = "传感器" + num_buf_front[i];
                        dataGridView1.Rows[m].Cells[1].Value = str_buf_front[i] + "KPa";
                        dataChange1[Convert.ToInt16(num_buf_front[i]) - 1] = str_buf_front[i];
                        m++;
                    }

                    start = str.IndexOf("back") + 4;
                    end = str.IndexOf("DHT11:");
                    for (int i = 0; i < (end - start) / 10; i++)
                    {
                        num_buf_back[i] = str.Substring(start + i * 10, 2);
                        str_buf_back[i] = str.Substring(start + 3 + i * 10, 6);
                        dataGridView1.Rows[n].Cells[2].Value = "传感器" + num_buf_back[i];
                        dataGridView1.Rows[n].Cells[3].Value = str_buf_back[i] + "KPa";
                        dataChange1[Convert.ToInt16(num_buf_back[i]) - 1] = str_buf_back[i];
                        n++;
                    }

                    temperature = str.Substring(str.IndexOf("DHT11:") + 6, 2);
                    humidity = str.Substring(str.IndexOf("DHT11:") + 9, 2);

                    lbAnalogMeter1.Value = Convert.ToInt16(temperature);
                    lbAnalogMeter2.Value = Convert.ToInt16(humidity);
                    label43.Text = temperature + "℃";
                    label42.Text = humidity + "%";
                    //数据处理结束

                    //平均值
                    for (int i = 0; i < 32; i++)
                    {
                        average_value_front += Convert.ToDouble(str_buf_front[i]);
                    }
                    for (int i = 0; i < 32; i++)
                    {
                        average_value_back += Convert.ToDouble(str_buf_back[i]);
                    }

                    average_value_front = average_value_front / m;
                    average_value_back = average_value_back / n;

                    if (average_value_front > 0)
                    {
                        lbDigitalMeter1.Value = average_value_front;
                    }
                    if (average_value_back > 0)
                    {
                        lbDigitalMeter2.Value = average_value_back;
                    }
                }
                catch (Exception err)
                {
                    //MessageBox.Show(err.Message);
                }

            }
            catch
            {
                MessageBox.Show("已经与服务器断开连接！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Client_Connect()
        {
            if (ClientSocket == null || !ClientSocket.Connected)
            {
                Connection();
            }
            ServerInfo = new IPEndPoint(IPAddress.Parse("10.0.2.10"), Convert.ToInt32("6600"));
            
            try
            {
                ClientSocket.Connect(ServerInfo);
                ClientSocket.Send(Encoding.Default.GetBytes("connection"));
                ClientSocket.BeginReceive(MsgBuffer, 0, MsgBuffer.Length, 0, new AsyncCallback(ReceiveCallBack), null);
            }
            catch
            {
                try
                {
                    ServerInfo = new IPEndPoint(IPAddress.Parse("192.168.191.1"), Convert.ToInt32("6600"));
                    ClientSocket.Connect(ServerInfo);
                    ClientSocket.Send(Encoding.Default.GetBytes("connection"));
                    ClientSocket.BeginReceive(MsgBuffer, 0, MsgBuffer.Length, 0, new AsyncCallback(ReceiveCallBack), null);
                }
                catch
                {
                    MessageBox.Show("登录服务器失败，请确认服务器是否正常工作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }               
            }
        }

        //参数设置
        private void button5_Click(object sender, EventArgs e)
        {
            MsgSend = Encoding.Default.GetBytes(Setting());
            try
            {
                if (ClientSocket.Connected)
                {
                    ClientSocket.Send(MsgSend);
                }
            }
            catch
            {
                MessageBox.Show("当前与服务器断开连接，请重新连接！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 发送设置的参数到服务器端
        /// </summary>
        private string Setting()
        {
            string str = "Parameter";
            str += Properties.Settings.Default.csv_time + "!";
            str += Properties.Settings.Default.zedGraph_time + "@";
            str += Properties.Settings.Default.choosedata_front + "#";
            str += Properties.Settings.Default.choosedata_back + "$";
            str += Properties.Settings.Default.CurveFlag + "%";
            str += Properties.Settings.Default.vScrollBarValue + "^";
            return str;
        }
    }
}
