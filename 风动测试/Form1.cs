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


        [DllImport("user32.dll", SetLastError = true)]
        static extern UInt32 GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll", SetLastError = true)]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, UInt32 dwNewLong);

        private const int GWL_STYLE = (-16);
        private const long WS_CAPTION = 0x00C00000L;

        private GraphPane mGraphPane;
        //目前定义了32个颜色，如果不够请再添加，以防后续数组溢出。可根据自己的喜好再次修改颜色
        System.Drawing.Color[] color = new System.Drawing.Color[32] { System.Drawing.Color.Blue, System.Drawing.Color.Red ,System.Drawing.Color.Green,System.Drawing.Color.Gold,System.Drawing.Color.Gray,System.Drawing.Color.SkyBlue,System.Drawing.Color.Black,System.Drawing.Color.DarkBlue, 
                                            System.Drawing.Color.DarkGray, System.Drawing.Color.DarkGreen, System.Drawing.Color.DarkOrange, System.Drawing.Color.DarkRed ,System.Drawing.Color.LightGray,
                                            System.Drawing.Color.IndianRed,System.Drawing.Color.LightCoral,System.Drawing.Color.Turquoise,System.Drawing.Color.YellowGreen,System.Drawing.Color.Yellow,System.Drawing.Color.Olive,
                                            System.Drawing.Color.OliveDrab,System.Drawing.Color.PeachPuff,System.Drawing.Color.SeaShell,System.Drawing.Color.Cyan,System.Drawing.Color.Pink,System.Drawing.Color.Orchid,System.Drawing.Color.Plum,
                                            System.Drawing.Color.MediumPurple,System.Drawing.Color.SlateGray,System.Drawing.Color.SeaGreen,System.Drawing.Color.RoyalBlue,System.Drawing.Color.OliveDrab,System.Drawing.Color.Indigo};

        List<CheckBox> cbList = new List<CheckBox>();

        private readonly int chartPoint = 200;

        public Form1()
        {
            char[] buf = new char[32];
            InitializeComponent();
            //SetWindowLong(this.Handle, GWL_STYLE, (uint)(GetWindowLong(this.Handle, GWL_STYLE) & ~WS_CAPTION));

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

            //checkbox开启读取默认值
            buf = Properties.Settings.Default.CurveFlag.ToCharArray();         //读取曲线选择设置

            for (int i = 0; i < 30; i++)
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
            for(int i = 0; i < 30;i++)
            {
                cbList[i].ForeColor = color[i];
                cbList[i].CheckedChanged += new System.EventHandler(checkBox_CheckedChanged);
            }
        }

        //checkbox变化事件
        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            char[] buf = new char[30];
            for (int i = 0; i < 30; i++)
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
            Setting();
        }

        string[] str_buf_front = new string[32];  //存放读取的AD数值，前20个数据。        
        string[] str_buf_back = new string[32];   //存放读取的AD数值，后20个数据。     
        double[] numScale = new double[32];       //乘以一个系数减小误差

        char[] buf_front = new char[32];          //保存曲线选择的数据，32位每位对应一个传感器，1显示0不显示，front对应前端back对应后端
        char[] buf_back = new char[32];

        public static string[,] set_value = new string[2, 32];   //xml中所存储的所有参数，选择参数时进行调用，程序结束时再进行存储。


        //曲线初始化
        private void init_zedgragh()
        {                       
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

            try
            {
                mGraphPane.YAxis.Scale.Min = Convert.ToDouble(textBox4.Text);      //电压轴最小值0
                mGraphPane.YAxis.Scale.Max = Convert.ToDouble(textBox3.Text);    //电压最大值
                mGraphPane.YAxis.Scale.MajorStep = Convert.ToDouble(textBox2.Text);     //刻度线的距离
            }
            catch
            {
                MessageBox.Show("参数错误！");
            }

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

        //参数加载
        #region     
        private void Parameter_Init()
        {
            //properties值读取
            textBox4.Text = Properties.Settings.Default.MIN;
            textBox3.Text = Properties.Settings.Default.MAX;
            textBox2.Text = Properties.Settings.Default.YMajorStep;
            textBox6.Text = Properties.Settings.Default.csv_time;
            textBox5.Text = Properties.Settings.Default.zedGraph_time;

            buf_front = Properties.Settings.Default.choosedata_front.ToCharArray();         //读取曲线选择设置
            buf_back = Properties.Settings.Default.choosedata_back.ToCharArray();

            timerCsv.Interval = (int)(Convert.ToDouble(Properties.Settings.Default.csv_time) * 1000);
            timerCure.Interval = (int)(Convert.ToDouble(Properties.Settings.Default.zedGraph_time) * 1000);
            timer4.Interval = (int)(Convert.ToDouble(Properties.Settings.Default.zedGraph_time) * 1000);

            vScrollBar1.Value = Convert.ToInt16(Properties.Settings.Default.vScrollBarValue);
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            serial.Serial_Init();       //串口初始化
            Parameter_Init();       //参数初始化
            zedGraphControl1.Size = new Size(633, 520);     //曲线大小初始化
            
            //datagridview 格式设置          
            //行标题隐藏
            dataGridView1.RowHeadersVisible = false;
            
            dataGridView1.DefaultCellStyle.BackColor = Color.LightCyan;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Blue;
            dataGridView1.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 11F);
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
            LoadTitleBarImage();
            
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
            StartSever();
        }
      
        private void BtnClose_Click(object sender, EventArgs e)
        {         
            try
            {
                ServerSocket.Close();//关闭SOCKET
                ServerThread.Abort();//线程终止
            }
            catch { }
        }

        //定时存CSV格式的数据，文件名按照时间生成
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
            for (int i = 0; i < 30; i++)
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

        private void timer3_Tick(object sender, EventArgs e)
        {
            label41.Text = DateTime.Now.ToString("hh:mm:ss");        
        }


        //socket部分
        //声明将要用到的类
        private IPEndPoint ServerInfo;//存放服务器的IP和端口信息
        private Socket ServerSocket;//服务端运行的SOCKET
        private Thread ServerThread;//服务端运行的线程
        private Socket[] ClientSocket;//为客户端建立的SOCKET连接
        private int ClientNumb;//存放客户端数量
        private byte[] MsgBuffer;//存放消息数据
        //启动服务器
        private void StartSever()
        {
            ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ServerInfo = new IPEndPoint(IPAddress.Any, 6600);
            ServerSocket.Bind(ServerInfo);//将SOCKET接口和IP端口绑定
            ServerSocket.Listen(10);//开始监听，并且挂起数为10

            ClientSocket = new Socket[65535];//为客户端提供连接个数
            MsgBuffer = new byte[65535];//消息数据大小
            ClientNumb = 0;//数量从0开始统计

            ServerThread = new Thread(RecieveAccept);//将接受客户端连接的方法委托给线程
            ServerThread.Start();//线程开始运行

            CheckForIllegalCrossThreadCalls = false;//不捕获对错误线程的调用

            //this.ClientList.Items.Add("服务于 " + DateTime.Now.ToString() + " 开始运行.");             
        }

        //接受客户端连接的方法
        private void RecieveAccept()
        {
            while (true)
            {
                try
                {
                    ClientSocket[ClientNumb] = ServerSocket.Accept();
                    ClientSocket[ClientNumb].BeginReceive(MsgBuffer, 0, MsgBuffer.Length, 0, new AsyncCallback(RecieveCallBack), ClientSocket[ClientNumb]);
                    //this.ClientList.Items.Add(ClientSocket[ClientNumb].RemoteEndPoint.ToString() + " 成功连接服务器.");
                    ClientNumb++;
                }
                catch
                { }
            }
        }

        //数据接收完成后
        private void RecieveCallBack(IAsyncResult AR)
        {
            char[] buf = new char[32];
            try
            {
                Socket RSocket = (Socket)AR.AsyncState;
                int REnd = RSocket.EndReceive(AR);
                string msg = Encoding.UTF8.GetString(MsgBuffer, 0, REnd);
                //MessageList.Items.Add(msg);
                textBox1.AppendText(msg);
                if (msg == "start") //接收到客户端的启动命令，则置位发送标志
                {
                    SendFlag = true;
                }
                else if (msg == "connection")
                {
                    Setting();
                }
                else if (msg.Contains("Parameter"))
                {
                    //停止所有采集
                    timerCsv.Enabled = false;
                    timerCure.Enabled = false;
                    button3.Enabled = true;
                    button4.Enabled = false;
                    serial.serialPort1.Close();
                    serial.serialPort2.Close();
                    serial.serialPort3.Close();
                    serial.serialPort4.Close();

                    Properties.Settings.Default.csv_time = msg.Substring(msg.IndexOf("Parameter") + 9, msg.IndexOf("!") - 9);
                    Properties.Settings.Default.zedGraph_time = msg.Substring(msg.IndexOf("!") + 1, msg.IndexOf("@") - msg.IndexOf("!") - 1);
                    Properties.Settings.Default.choosedata_front = msg.Substring(msg.IndexOf("@") + 1, msg.IndexOf("#") - msg.IndexOf("@") - 1);
                    Properties.Settings.Default.choosedata_back = msg.Substring(msg.IndexOf("#") + 1, msg.IndexOf("$") - msg.IndexOf("#") - 1);
                    Properties.Settings.Default.CurveFlag = msg.Substring(msg.IndexOf("$") + 1, msg.IndexOf("%") - msg.IndexOf("$") - 1);
                    Properties.Settings.Default.vScrollBarValue = msg.Substring(msg.IndexOf("%") + 1, msg.IndexOf("^") - msg.IndexOf("%") - 1);
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
                }

                for (int i = 0; i < ClientNumb; i++)
                {
                    RSocket.BeginReceive(MsgBuffer, 0, MsgBuffer.Length, 0, new AsyncCallback(RecieveCallBack), RSocket);
                }
            }
            catch { }

        }

        /// <summary>
        /// 发送设置的参数到客户端
        /// </summary>
        private void Setting()
        {
            string str = "Parameter";
            str += Properties.Settings.Default.csv_time + "!";
            str += Properties.Settings.Default.zedGraph_time + "@";
            str += Properties.Settings.Default.choosedata_front + "#";
            str += Properties.Settings.Default.choosedata_back + "$";
            str += Properties.Settings.Default.CurveFlag + "%";
            str += Properties.Settings.Default.vScrollBarValue + "^";

            try
            {
                for (int i = 0; i < ClientNumb; i++)
                {
                    if (ClientSocket[i].Connected)
                    {
                        ClientSocket[i].Send(Encoding.Default.GetBytes(str), 0, str.Length, 0);
                    }
                }
            }
            catch { }
        }
        //end socket

        private void 曲线设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChooseData choosedata = new ChooseData();
            timerCsv.Enabled = false;
            timerCure.Enabled = false;
            timer4.Enabled = false;
            if (serial.serialPort1.IsOpen)
            {
                serial.serialPort1.Close();               
            }
            if (serial.serialPort2.IsOpen)
            {
                serial.serialPort2.Close();
            }
            if (serial.serialPort3.IsOpen)
            {
                serial.serialPort3.Close();
            }
            if (serial.serialPort4.IsOpen)
            {
                serial.serialPort4.Close();
            }

            if (choosedata.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    serial.serialPort1.Open();
                    serial.serialPort2.Open();
                    serial.serialPort3.Open();
                    serial.serialPort4.Open();
                    buf_front = Properties.Settings.Default.choosedata_front.ToCharArray();
                    buf_back = Properties.Settings.Default.choosedata_back.ToCharArray();
                }
                catch
                {
                    MessageBox.Show("串口开启错误，请检查！");
                }
            }
            button3.Enabled = true;
            Setting();
        }

        private bool MouseDoubleClickFlag = true;
        private void zedGraphControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MouseDoubleClickFlag = !MouseDoubleClickFlag;
            if (MouseDoubleClickFlag == true)
            {
                zedGraphControl1.Size = new Size(633, 520);
                groupBox1.Visible = false;
            }
            else
            {
                zedGraphControl1.Size = new Size(633, 432);
                groupBox1.Visible = true;
            }
        }

        //风机设置
        //
        // 设置变频器部分
        //
        private void button1_Click(object sender, EventArgs e)
        {
            if (!serialPort5.IsOpen)
            {
                serialPort5.Open();
            }
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
            if (!serialPort5.IsOpen)
            {
                serialPort5.Open();
            }
            serialPort5.Write(":FF0620020002D7" + "\r\n");
        }
        // end 风机

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (!serial.serialPort1.IsOpen)
                {
                    serial.serialPort1.Open();
                }
                if (!serial.serialPort2.IsOpen)
                {
                    serial.serialPort2.Open();
                }
                if (!serial.serialPort3.IsOpen)
                {
                    serial.serialPort3.Open();
                }
                if (!serial.serialPort4.IsOpen)
                {
                    serial.serialPort4.Open();
                }
                button3.Enabled = false;
            }
            catch
            {
                MessageBox.Show("串口开启错误！");
            }
            timerCsv.Enabled = true;
            timerCure.Enabled = true;
            timer4.Enabled = true;
            button3.Enabled = false;
            button4.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timerCsv.Enabled = false;
            timerCure.Enabled = false;
            button3.Enabled = true;
            button4.Enabled = false;
            try
            {
                serial.serialPort1.Close();
                serial.serialPort2.Close();
                serial.serialPort3.Close();
                serial.serialPort4.Close();
                serialPort5.Close();
                button3.Enabled = true;
            }
            catch
            {
                MessageBox.Show("串口开启错误！");
            }
        }

        string[] SerialDataReceived = new string[32];   //串口接收数组
        string[] dataChange1 = new string[32];
          
        bool SendFlag = false;  //是否给客户端发送数据的标志

        private void timer4_Tick(object sender, EventArgs e)
        {
            int j = 8;
            int k = 5;
            int m = 0;
            int n = 0;
            string[] dataChange = new string[32];     //存放转换后的数据。     
            double average_value_front = 0;
            double average_value_back = 0;
            string temperature = serial.DhtTemp.ToString();
            string humidity = serial.DhtHumi.ToString();

            lbAnalogMeter1.Value = Convert.ToInt16(temperature);
            lbAnalogMeter2.Value = Convert.ToInt16(humidity);
            label43.Text = temperature + "℃";
            label42.Text = humidity + "%";

            //
            //数据处理，乘以保存的基数
            //
            for (int i = 0; i < 32; i++)
            {
                //dataChange[i] = ((Convert.ToDouble(serial.SerialDataReceived[i]) / 5 + 0.095) / 0.009).ToString("000.00");
                dataChange[i] = ((Convert.ToDouble(serial.SerialDataReceived[i]) * numScale[i] * 3.3 * 2 / 4096 / 5 + 0.095) / 0.009).ToString("000.00");
            }           
            //
            dataChange1 = dataChange;

            //根据曲线选择，将不需要显示的数据清零
            for (int i = 0; i < 32; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = "";
                dataGridView1.Rows[i].Cells[1].Value = "";
                dataGridView1.Rows[i].Cells[2].Value = "";
                dataGridView1.Rows[i].Cells[3].Value = "";
            }

            for (int i = 0; i < 32; i++)
            {
                if (buf_front[i] == '1')
                {
                    str_buf_front[i] = dataChange[i];
                    dataGridView1.Rows[m].Cells[0].Value = "传感器" + (i + 1).ToString();
                    dataGridView1.Rows[m].Cells[1].Value = str_buf_front[i] + "KPa";
                    m++;
                }
            }

            for (int i = 0; i < 32; i++)
            {
                if (buf_back[i] == '1')
                {
                    str_buf_back[i] = dataChange[i];
                    dataGridView1.Rows[n].Cells[2].Value = "传感器" + (i + 1).ToString();
                    dataGridView1.Rows[n].Cells[3].Value = str_buf_back[i] + "KPa";
                    n++;
                }
            }

            //平均值
            for (int i = 0; i < 30; i++)
            {
                if (buf_front[i] == '1')
                {
                    average_value_front += Convert.ToDouble(str_buf_front[i]);
                }
            }
            for (int i = 0; i < 30; i++)
            {
                if (buf_back[i] == '1')
                {
                    average_value_back += Convert.ToDouble(str_buf_back[i]);
                }
            }

            average_value_front = average_value_front / m;
            average_value_back = average_value_back / n;

            //平均值
            //if (average_value_front > 0)
            //{
            //    lbDigitalMeter1.Value = average_value_front;
            //}
            //if (average_value_back > 0)
            //{
            //    lbDigitalMeter2.Value = average_value_back;
            //}

            lbDigitalMeter1.Value = average_value_front;
            lbDigitalMeter2.Value = average_value_front;
            //
            //将串口接收的数据发送到socket客户端
            //
            if (SendFlag == true)
            {
                string str;
                str = "front";
                for (int i = 0; i < 32; i++)
                {
                    if (buf_front[i] == '1')
                    {
                        str_buf_front[i] = dataChange[i];
                        str = str + (i + 1).ToString("00") + ",";
                        str = str + str_buf_front[i].PadLeft(6, '0') + ",";
                    }
                }
                str = str + "back";
                for (int i = 0; i < 32; i++)
                {
                    if (buf_back[i] == '1')
                    {
                        str_buf_back[i] = dataChange[i];
                        str = str + (i + 1).ToString("00") + ",";
                        str = str + str_buf_back[i].PadLeft(6, '0') + ",";
                    }
                }
                str = str + "DHT11:";
                str = str + temperature.ToString() + ",";
                str = str + humidity.ToString();

                try
                {
                    for (int i = 0; i < ClientNumb; i++)
                    {
                        if (ClientSocket[i].Connected)
                        {
                            ClientSocket[i].Send(Encoding.Default.GetBytes(str), 0, str.Length, 0);
                        }
                    }
                }
                catch { }//end
            }           
        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            timerCsv.Enabled = false;
            timerCure.Enabled = false;
            timer4.Enabled = false;
            try
            {
                if (Convert.ToDouble(textBox4.Text) >= Convert.ToDouble(textBox3.Text))
                {
                    MessageBox.Show("参数设置错误！");
                    return;
                }
                if ((Convert.ToDouble(textBox6.Text) < 0) && (Convert.ToDouble(textBox5.Text) < 0))
                {
                    MessageBox.Show("参数设置错误！");
                    return;
                }

                timerCsv.Interval = (int)(Convert.ToDouble(textBox6.Text) * 1000);
                timerCure.Interval = (int)(Convert.ToDouble(textBox5.Text) * 1000);
                timer4.Interval = (int)(Convert.ToDouble(textBox5.Text) * 1000);
                mGraphPane.YAxis.Scale.Min = Convert.ToDouble(textBox4.Text);      //电压轴最小值0
                mGraphPane.YAxis.Scale.Max = Convert.ToDouble(textBox3.Text);      //电压最大值
                mGraphPane.YAxis.Scale.MajorStep = Convert.ToDouble(textBox2.Text);     //刻度线的距离
            }
            catch
            {
                MessageBox.Show("请填写正确参数！");
                return;
            }
            Properties.Settings.Default.YMajorStep = textBox2.Text;
            Properties.Settings.Default.csv_time = textBox6.Text;
            Properties.Settings.Default.zedGraph_time = textBox5.Text;
            Properties.Settings.Default.Save();
            zedGraphControl1.Size = new Size(633, 520);
            groupBox1.Visible = false;
            MouseDoubleClickFlag = true;
            button3.Enabled = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.MAX = textBox3.Text;
            Properties.Settings.Default.Save();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.MIN = textBox4.Text;
            Properties.Settings.Default.Save();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 30; i++)
            {
                cbList[i].Checked = true;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 30; i++)
            {
                cbList[i].Checked = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 30; i++)
            {
                if (cbList[i].Checked == false)
                {
                    cbList[i].Checked = true;
                }
                else
                {
                    cbList[i].Checked = false;
                }
            }           
        }
    }
}
