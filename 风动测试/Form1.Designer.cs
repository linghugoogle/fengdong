namespace 风动测试
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timerCsv = new System.Windows.Forms.Timer(this.components);
            this.timerCure = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.label45 = new System.Windows.Forms.Label();
            this.lbDigitalMeter2 = new LBSoft.IndustrialCtrls.Meters.LBDigitalMeter();
            this.lbDigitalMeter1 = new LBSoft.IndustrialCtrls.Meters.LBDigitalMeter();
            this.lbAnalogMeter2 = new LBSoft.IndustrialCtrls.Meters.LBAnalogMeter();
            this.lbAnalogMeter1 = new LBSoft.IndustrialCtrls.Meters.LBAnalogMeter();
            this.label41 = new System.Windows.Forms.Label();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.checkBox12 = new System.Windows.Forms.CheckBox();
            this.checkBox13 = new System.Windows.Forms.CheckBox();
            this.checkBox14 = new System.Windows.Forms.CheckBox();
            this.checkBox15 = new System.Windows.Forms.CheckBox();
            this.checkBox16 = new System.Windows.Forms.CheckBox();
            this.checkBox17 = new System.Windows.Forms.CheckBox();
            this.checkBox18 = new System.Windows.Forms.CheckBox();
            this.checkBox19 = new System.Windows.Forms.CheckBox();
            this.checkBox20 = new System.Windows.Forms.CheckBox();
            this.checkBox21 = new System.Windows.Forms.CheckBox();
            this.checkBox22 = new System.Windows.Forms.CheckBox();
            this.checkBox23 = new System.Windows.Forms.CheckBox();
            this.checkBox24 = new System.Windows.Forms.CheckBox();
            this.checkBox25 = new System.Windows.Forms.CheckBox();
            this.checkBox26 = new System.Windows.Forms.CheckBox();
            this.checkBox27 = new System.Windows.Forms.CheckBox();
            this.checkBox32 = new System.Windows.Forms.CheckBox();
            this.checkBox31 = new System.Windows.Forms.CheckBox();
            this.checkBox30 = new System.Windows.Forms.CheckBox();
            this.checkBox29 = new System.Windows.Forms.CheckBox();
            this.checkBox28 = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更新AD配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.串口设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.曲线设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.label43 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbAnalogMeter3 = new LBSoft.IndustrialCtrls.Meters.LBAnalogMeter();
            this.serialPort5 = new System.IO.Ports.SerialPort(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.BtnMin = new System.Windows.Forms.PictureBox();
            this.BtnMax = new System.Windows.Forms.PictureBox();
            this.BtnClose = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnClose)).BeginInit();
            this.SuspendLayout();
            // 
            // timerCsv
            // 
            this.timerCsv.Interval = 1000;
            this.timerCsv.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timerCure
            // 
            this.timerCure.Interval = 500;
            this.timerCure.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(90, 94);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 119;
            this.pictureBox1.TabStop = false;
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.BackColor = System.Drawing.Color.Transparent;
            this.zedGraphControl1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.zedGraphControl1.Location = new System.Drawing.Point(371, 202);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 100D;
            this.zedGraphControl1.ScrollMaxY = 100D;
            this.zedGraphControl1.ScrollMaxY2 = 50D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(650, 432);
            this.zedGraphControl1.TabIndex = 128;
            this.zedGraphControl1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.zedGraphControl1_MouseDoubleClick);
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.BackColor = System.Drawing.Color.Transparent;
            this.label45.Font = new System.Drawing.Font("宋体", 35.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label45.ForeColor = System.Drawing.Color.SpringGreen;
            this.label45.Location = new System.Drawing.Point(544, 104);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(95, 47);
            this.label45.TabIndex = 155;
            this.label45.Text = "KPa";
            // 
            // lbDigitalMeter2
            // 
            this.lbDigitalMeter2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbDigitalMeter2.BackColor = System.Drawing.Color.Black;
            this.lbDigitalMeter2.Font = new System.Drawing.Font("宋体", 8F);
            this.lbDigitalMeter2.ForeColor = System.Drawing.Color.SpringGreen;
            this.lbDigitalMeter2.Format = "000.00";
            this.lbDigitalMeter2.Location = new System.Drawing.Point(390, 104);
            this.lbDigitalMeter2.Name = "lbDigitalMeter2";
            this.lbDigitalMeter2.Renderer = null;
            this.lbDigitalMeter2.Signed = false;
            this.lbDigitalMeter2.Size = new System.Drawing.Size(154, 47);
            this.lbDigitalMeter2.TabIndex = 149;
            this.lbDigitalMeter2.Value = 0D;
            // 
            // lbDigitalMeter1
            // 
            this.lbDigitalMeter1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbDigitalMeter1.BackColor = System.Drawing.Color.Black;
            this.lbDigitalMeter1.ForeColor = System.Drawing.Color.SkyBlue;
            this.lbDigitalMeter1.Format = "000.00";
            this.lbDigitalMeter1.Location = new System.Drawing.Point(390, 36);
            this.lbDigitalMeter1.Name = "lbDigitalMeter1";
            this.lbDigitalMeter1.Renderer = null;
            this.lbDigitalMeter1.Signed = false;
            this.lbDigitalMeter1.Size = new System.Drawing.Size(154, 47);
            this.lbDigitalMeter1.TabIndex = 148;
            this.lbDigitalMeter1.Value = 0D;
            // 
            // lbAnalogMeter2
            // 
            this.lbAnalogMeter2.BackColor = System.Drawing.Color.Transparent;
            this.lbAnalogMeter2.BodyColor = System.Drawing.Color.Transparent;
            this.lbAnalogMeter2.Font = new System.Drawing.Font("楷体", 13F);
            this.lbAnalogMeter2.ForeColor = System.Drawing.Color.DarkBlue;
            this.lbAnalogMeter2.Location = new System.Drawing.Point(234, 21);
            this.lbAnalogMeter2.MaxValue = 100D;
            this.lbAnalogMeter2.MeterStyle = LBSoft.IndustrialCtrls.Meters.LBAnalogMeter.AnalogMeterStyle.Circular;
            this.lbAnalogMeter2.MinValue = 0D;
            this.lbAnalogMeter2.Name = "lbAnalogMeter2";
            this.lbAnalogMeter2.NeedleColor = System.Drawing.SystemColors.ActiveBorder;
            this.lbAnalogMeter2.Renderer = null;
            this.lbAnalogMeter2.ScaleColor = System.Drawing.Color.Blue;
            this.lbAnalogMeter2.ScaleDivisions = 6;
            this.lbAnalogMeter2.ScaleSubDivisions = 5;
            this.lbAnalogMeter2.Size = new System.Drawing.Size(150, 150);
            this.lbAnalogMeter2.TabIndex = 147;
            this.lbAnalogMeter2.Value = 0D;
            this.lbAnalogMeter2.ViewGlass = false;
            // 
            // lbAnalogMeter1
            // 
            this.lbAnalogMeter1.BackColor = System.Drawing.Color.Transparent;
            this.lbAnalogMeter1.BodyColor = System.Drawing.Color.Transparent;
            this.lbAnalogMeter1.Font = new System.Drawing.Font("楷体", 13F);
            this.lbAnalogMeter1.ForeColor = System.Drawing.Color.DarkBlue;
            this.lbAnalogMeter1.Location = new System.Drawing.Point(98, 21);
            this.lbAnalogMeter1.MaxValue = 50D;
            this.lbAnalogMeter1.MeterStyle = LBSoft.IndustrialCtrls.Meters.LBAnalogMeter.AnalogMeterStyle.Circular;
            this.lbAnalogMeter1.MinValue = 0D;
            this.lbAnalogMeter1.Name = "lbAnalogMeter1";
            this.lbAnalogMeter1.NeedleColor = System.Drawing.Color.Yellow;
            this.lbAnalogMeter1.Renderer = null;
            this.lbAnalogMeter1.ScaleColor = System.Drawing.Color.Blue;
            this.lbAnalogMeter1.ScaleDivisions = 6;
            this.lbAnalogMeter1.ScaleSubDivisions = 5;
            this.lbAnalogMeter1.Size = new System.Drawing.Size(150, 150);
            this.lbAnalogMeter1.TabIndex = 146;
            this.lbAnalogMeter1.Value = 0D;
            this.lbAnalogMeter1.ViewGlass = false;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.BackColor = System.Drawing.Color.Transparent;
            this.label41.Font = new System.Drawing.Font("宋体", 15F);
            this.label41.Location = new System.Drawing.Point(1251, 699);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(0, 20);
            this.label41.TabIndex = 152;
            // 
            // timer3
            // 
            this.timer3.Enabled = true;
            this.timer3.Interval = 800;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column17,
            this.Column1,
            this.Column2,
            this.Column18});
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(9, 202);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 10;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(356, 520);
            this.dataGridView1.TabIndex = 154;
            // 
            // Column17
            // 
            this.Column17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column17.HeaderText = "前端传感器";
            this.Column17.MinimumWidth = 35;
            this.Column17.Name = "Column17";
            this.Column17.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "压力值";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "后端传感器";
            this.Column2.Name = "Column2";
            // 
            // Column18
            // 
            this.Column18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column18.HeaderText = "压力值";
            this.Column18.MinimumWidth = 35;
            this.Column18.Name = "Column18";
            this.Column18.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.ForeColor = System.Drawing.Color.Blue;
            this.checkBox1.Location = new System.Drawing.Point(387, 640);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 155;
            this.checkBox1.Text = "-Sensor1";
            this.checkBox1.UseVisualStyleBackColor = false;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.BackColor = System.Drawing.Color.Transparent;
            this.checkBox2.ForeColor = System.Drawing.Color.Blue;
            this.checkBox2.Location = new System.Drawing.Point(465, 640);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(72, 16);
            this.checkBox2.TabIndex = 156;
            this.checkBox2.Text = "-Sensor2";
            this.checkBox2.UseVisualStyleBackColor = false;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.BackColor = System.Drawing.Color.Transparent;
            this.checkBox3.ForeColor = System.Drawing.Color.Blue;
            this.checkBox3.Location = new System.Drawing.Point(543, 640);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(72, 16);
            this.checkBox3.TabIndex = 157;
            this.checkBox3.Text = "-Sensor3";
            this.checkBox3.UseVisualStyleBackColor = false;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.BackColor = System.Drawing.Color.Transparent;
            this.checkBox4.ForeColor = System.Drawing.Color.Blue;
            this.checkBox4.Location = new System.Drawing.Point(621, 640);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(72, 16);
            this.checkBox4.TabIndex = 160;
            this.checkBox4.Text = "-Sensor4";
            this.checkBox4.UseVisualStyleBackColor = false;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.BackColor = System.Drawing.Color.Transparent;
            this.checkBox5.ForeColor = System.Drawing.Color.Blue;
            this.checkBox5.Location = new System.Drawing.Point(699, 640);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(72, 16);
            this.checkBox5.TabIndex = 159;
            this.checkBox5.Text = "-Sensor5";
            this.checkBox5.UseVisualStyleBackColor = false;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.BackColor = System.Drawing.Color.Transparent;
            this.checkBox6.ForeColor = System.Drawing.Color.Blue;
            this.checkBox6.Location = new System.Drawing.Point(777, 640);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(72, 16);
            this.checkBox6.TabIndex = 158;
            this.checkBox6.Text = "-Sensor6";
            this.checkBox6.UseVisualStyleBackColor = false;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.BackColor = System.Drawing.Color.Transparent;
            this.checkBox7.ForeColor = System.Drawing.Color.Blue;
            this.checkBox7.Location = new System.Drawing.Point(855, 640);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(72, 16);
            this.checkBox7.TabIndex = 166;
            this.checkBox7.Text = "-Sensor7";
            this.checkBox7.UseVisualStyleBackColor = false;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.BackColor = System.Drawing.Color.Transparent;
            this.checkBox8.ForeColor = System.Drawing.Color.Blue;
            this.checkBox8.Location = new System.Drawing.Point(933, 640);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(72, 16);
            this.checkBox8.TabIndex = 165;
            this.checkBox8.Text = "-Sensor8";
            this.checkBox8.UseVisualStyleBackColor = false;
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.BackColor = System.Drawing.Color.Transparent;
            this.checkBox9.ForeColor = System.Drawing.Color.Blue;
            this.checkBox9.Location = new System.Drawing.Point(387, 662);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(72, 16);
            this.checkBox9.TabIndex = 164;
            this.checkBox9.Text = "-Sensor9";
            this.checkBox9.UseVisualStyleBackColor = false;
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.BackColor = System.Drawing.Color.Transparent;
            this.checkBox10.ForeColor = System.Drawing.Color.Blue;
            this.checkBox10.Location = new System.Drawing.Point(465, 662);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(78, 16);
            this.checkBox10.TabIndex = 163;
            this.checkBox10.Text = "-Sensor10";
            this.checkBox10.UseVisualStyleBackColor = false;
            // 
            // checkBox11
            // 
            this.checkBox11.AutoSize = true;
            this.checkBox11.BackColor = System.Drawing.Color.Transparent;
            this.checkBox11.ForeColor = System.Drawing.Color.Blue;
            this.checkBox11.Location = new System.Drawing.Point(543, 662);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(78, 16);
            this.checkBox11.TabIndex = 162;
            this.checkBox11.Text = "-Sensor11";
            this.checkBox11.UseVisualStyleBackColor = false;
            // 
            // checkBox12
            // 
            this.checkBox12.AutoSize = true;
            this.checkBox12.BackColor = System.Drawing.Color.Transparent;
            this.checkBox12.ForeColor = System.Drawing.Color.Blue;
            this.checkBox12.Location = new System.Drawing.Point(621, 662);
            this.checkBox12.Name = "checkBox12";
            this.checkBox12.Size = new System.Drawing.Size(78, 16);
            this.checkBox12.TabIndex = 161;
            this.checkBox12.Text = "-Sensor12";
            this.checkBox12.UseVisualStyleBackColor = false;
            // 
            // checkBox13
            // 
            this.checkBox13.AutoSize = true;
            this.checkBox13.BackColor = System.Drawing.Color.Transparent;
            this.checkBox13.ForeColor = System.Drawing.Color.Blue;
            this.checkBox13.Location = new System.Drawing.Point(699, 662);
            this.checkBox13.Name = "checkBox13";
            this.checkBox13.Size = new System.Drawing.Size(78, 16);
            this.checkBox13.TabIndex = 172;
            this.checkBox13.Text = "-Sensor13";
            this.checkBox13.UseVisualStyleBackColor = false;
            // 
            // checkBox14
            // 
            this.checkBox14.AutoSize = true;
            this.checkBox14.BackColor = System.Drawing.Color.Transparent;
            this.checkBox14.ForeColor = System.Drawing.Color.Blue;
            this.checkBox14.Location = new System.Drawing.Point(777, 662);
            this.checkBox14.Name = "checkBox14";
            this.checkBox14.Size = new System.Drawing.Size(78, 16);
            this.checkBox14.TabIndex = 171;
            this.checkBox14.Text = "-Sensor14";
            this.checkBox14.UseVisualStyleBackColor = false;
            // 
            // checkBox15
            // 
            this.checkBox15.AutoSize = true;
            this.checkBox15.BackColor = System.Drawing.Color.Transparent;
            this.checkBox15.ForeColor = System.Drawing.Color.Blue;
            this.checkBox15.Location = new System.Drawing.Point(855, 662);
            this.checkBox15.Name = "checkBox15";
            this.checkBox15.Size = new System.Drawing.Size(78, 16);
            this.checkBox15.TabIndex = 170;
            this.checkBox15.Text = "-Sensor15";
            this.checkBox15.UseVisualStyleBackColor = false;
            // 
            // checkBox16
            // 
            this.checkBox16.AutoSize = true;
            this.checkBox16.BackColor = System.Drawing.Color.Transparent;
            this.checkBox16.ForeColor = System.Drawing.Color.Blue;
            this.checkBox16.Location = new System.Drawing.Point(934, 662);
            this.checkBox16.Name = "checkBox16";
            this.checkBox16.Size = new System.Drawing.Size(78, 16);
            this.checkBox16.TabIndex = 169;
            this.checkBox16.Text = "-Sensor16";
            this.checkBox16.UseVisualStyleBackColor = false;
            // 
            // checkBox17
            // 
            this.checkBox17.AutoSize = true;
            this.checkBox17.BackColor = System.Drawing.Color.Transparent;
            this.checkBox17.ForeColor = System.Drawing.Color.Blue;
            this.checkBox17.Location = new System.Drawing.Point(387, 684);
            this.checkBox17.Name = "checkBox17";
            this.checkBox17.Size = new System.Drawing.Size(78, 16);
            this.checkBox17.TabIndex = 168;
            this.checkBox17.Text = "-Sensor17";
            this.checkBox17.UseVisualStyleBackColor = false;
            // 
            // checkBox18
            // 
            this.checkBox18.AutoSize = true;
            this.checkBox18.BackColor = System.Drawing.Color.Transparent;
            this.checkBox18.ForeColor = System.Drawing.Color.Blue;
            this.checkBox18.Location = new System.Drawing.Point(465, 684);
            this.checkBox18.Name = "checkBox18";
            this.checkBox18.Size = new System.Drawing.Size(78, 16);
            this.checkBox18.TabIndex = 167;
            this.checkBox18.Text = "-Sensor18";
            this.checkBox18.UseVisualStyleBackColor = false;
            // 
            // checkBox19
            // 
            this.checkBox19.AutoSize = true;
            this.checkBox19.BackColor = System.Drawing.Color.Transparent;
            this.checkBox19.ForeColor = System.Drawing.Color.Blue;
            this.checkBox19.Location = new System.Drawing.Point(543, 684);
            this.checkBox19.Name = "checkBox19";
            this.checkBox19.Size = new System.Drawing.Size(78, 16);
            this.checkBox19.TabIndex = 181;
            this.checkBox19.Text = "-Sensor19";
            this.checkBox19.UseVisualStyleBackColor = false;
            // 
            // checkBox20
            // 
            this.checkBox20.AutoSize = true;
            this.checkBox20.BackColor = System.Drawing.Color.Transparent;
            this.checkBox20.ForeColor = System.Drawing.Color.Blue;
            this.checkBox20.Location = new System.Drawing.Point(621, 684);
            this.checkBox20.Name = "checkBox20";
            this.checkBox20.Size = new System.Drawing.Size(78, 16);
            this.checkBox20.TabIndex = 180;
            this.checkBox20.Text = "-Sensor20";
            this.checkBox20.UseVisualStyleBackColor = false;
            // 
            // checkBox21
            // 
            this.checkBox21.AutoSize = true;
            this.checkBox21.BackColor = System.Drawing.Color.Transparent;
            this.checkBox21.ForeColor = System.Drawing.Color.Blue;
            this.checkBox21.Location = new System.Drawing.Point(700, 684);
            this.checkBox21.Name = "checkBox21";
            this.checkBox21.Size = new System.Drawing.Size(78, 16);
            this.checkBox21.TabIndex = 179;
            this.checkBox21.Text = "-Sensor21";
            this.checkBox21.UseVisualStyleBackColor = false;
            // 
            // checkBox22
            // 
            this.checkBox22.AutoSize = true;
            this.checkBox22.BackColor = System.Drawing.Color.Transparent;
            this.checkBox22.ForeColor = System.Drawing.Color.Blue;
            this.checkBox22.Location = new System.Drawing.Point(777, 684);
            this.checkBox22.Name = "checkBox22";
            this.checkBox22.Size = new System.Drawing.Size(78, 16);
            this.checkBox22.TabIndex = 178;
            this.checkBox22.Text = "-Sensor22";
            this.checkBox22.UseVisualStyleBackColor = false;
            // 
            // checkBox23
            // 
            this.checkBox23.AutoSize = true;
            this.checkBox23.BackColor = System.Drawing.Color.Transparent;
            this.checkBox23.ForeColor = System.Drawing.Color.Blue;
            this.checkBox23.Location = new System.Drawing.Point(855, 684);
            this.checkBox23.Name = "checkBox23";
            this.checkBox23.Size = new System.Drawing.Size(78, 16);
            this.checkBox23.TabIndex = 177;
            this.checkBox23.Text = "-Sensor23";
            this.checkBox23.UseVisualStyleBackColor = false;
            // 
            // checkBox24
            // 
            this.checkBox24.AutoSize = true;
            this.checkBox24.BackColor = System.Drawing.Color.Transparent;
            this.checkBox24.ForeColor = System.Drawing.Color.Blue;
            this.checkBox24.Location = new System.Drawing.Point(934, 684);
            this.checkBox24.Name = "checkBox24";
            this.checkBox24.Size = new System.Drawing.Size(78, 16);
            this.checkBox24.TabIndex = 176;
            this.checkBox24.Text = "-Sensor24";
            this.checkBox24.UseVisualStyleBackColor = false;
            // 
            // checkBox25
            // 
            this.checkBox25.AutoSize = true;
            this.checkBox25.BackColor = System.Drawing.Color.Transparent;
            this.checkBox25.ForeColor = System.Drawing.Color.Blue;
            this.checkBox25.Location = new System.Drawing.Point(387, 706);
            this.checkBox25.Name = "checkBox25";
            this.checkBox25.Size = new System.Drawing.Size(78, 16);
            this.checkBox25.TabIndex = 175;
            this.checkBox25.Text = "-Sensor25";
            this.checkBox25.UseVisualStyleBackColor = false;
            // 
            // checkBox26
            // 
            this.checkBox26.AutoSize = true;
            this.checkBox26.BackColor = System.Drawing.Color.Transparent;
            this.checkBox26.ForeColor = System.Drawing.Color.Blue;
            this.checkBox26.Location = new System.Drawing.Point(465, 706);
            this.checkBox26.Name = "checkBox26";
            this.checkBox26.Size = new System.Drawing.Size(78, 16);
            this.checkBox26.TabIndex = 174;
            this.checkBox26.Text = "-Sensor26";
            this.checkBox26.UseVisualStyleBackColor = false;
            // 
            // checkBox27
            // 
            this.checkBox27.AutoSize = true;
            this.checkBox27.BackColor = System.Drawing.Color.Transparent;
            this.checkBox27.ForeColor = System.Drawing.Color.Blue;
            this.checkBox27.Location = new System.Drawing.Point(543, 706);
            this.checkBox27.Name = "checkBox27";
            this.checkBox27.Size = new System.Drawing.Size(78, 16);
            this.checkBox27.TabIndex = 173;
            this.checkBox27.Text = "-Sensor27";
            this.checkBox27.UseVisualStyleBackColor = false;
            // 
            // checkBox32
            // 
            this.checkBox32.AutoSize = true;
            this.checkBox32.BackColor = System.Drawing.Color.Transparent;
            this.checkBox32.ForeColor = System.Drawing.Color.Blue;
            this.checkBox32.Location = new System.Drawing.Point(934, 706);
            this.checkBox32.Name = "checkBox32";
            this.checkBox32.Size = new System.Drawing.Size(78, 16);
            this.checkBox32.TabIndex = 186;
            this.checkBox32.Text = "-Sensor32";
            this.checkBox32.UseVisualStyleBackColor = false;
            // 
            // checkBox31
            // 
            this.checkBox31.AutoSize = true;
            this.checkBox31.BackColor = System.Drawing.Color.Transparent;
            this.checkBox31.ForeColor = System.Drawing.Color.Blue;
            this.checkBox31.Location = new System.Drawing.Point(855, 706);
            this.checkBox31.Name = "checkBox31";
            this.checkBox31.Size = new System.Drawing.Size(78, 16);
            this.checkBox31.TabIndex = 185;
            this.checkBox31.Text = "-Sensor31";
            this.checkBox31.UseVisualStyleBackColor = false;
            // 
            // checkBox30
            // 
            this.checkBox30.AutoSize = true;
            this.checkBox30.BackColor = System.Drawing.Color.Transparent;
            this.checkBox30.ForeColor = System.Drawing.Color.Blue;
            this.checkBox30.Location = new System.Drawing.Point(777, 706);
            this.checkBox30.Name = "checkBox30";
            this.checkBox30.Size = new System.Drawing.Size(78, 16);
            this.checkBox30.TabIndex = 184;
            this.checkBox30.Text = "-Sensor30";
            this.checkBox30.UseVisualStyleBackColor = false;
            // 
            // checkBox29
            // 
            this.checkBox29.AutoSize = true;
            this.checkBox29.BackColor = System.Drawing.Color.Transparent;
            this.checkBox29.ForeColor = System.Drawing.Color.Blue;
            this.checkBox29.Location = new System.Drawing.Point(700, 706);
            this.checkBox29.Name = "checkBox29";
            this.checkBox29.Size = new System.Drawing.Size(78, 16);
            this.checkBox29.TabIndex = 183;
            this.checkBox29.Text = "-Sensor29";
            this.checkBox29.UseVisualStyleBackColor = false;
            // 
            // checkBox28
            // 
            this.checkBox28.AutoSize = true;
            this.checkBox28.BackColor = System.Drawing.Color.Transparent;
            this.checkBox28.ForeColor = System.Drawing.Color.Blue;
            this.checkBox28.Location = new System.Drawing.Point(621, 706);
            this.checkBox28.Name = "checkBox28";
            this.checkBox28.Size = new System.Drawing.Size(78, 16);
            this.checkBox28.TabIndex = 182;
            this.checkBox28.Text = "-Sensor28";
            this.checkBox28.UseVisualStyleBackColor = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fILEToolStripMenuItem,
            this.设置ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(7, 3);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(106, 28);
            this.menuStrip1.TabIndex = 153;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fILEToolStripMenuItem
            // 
            this.fILEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.更新AD配置ToolStripMenuItem,
            this.toolStripSeparator1,
            this.退出ToolStripMenuItem});
            this.fILEToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fILEToolStripMenuItem.Name = "fILEToolStripMenuItem";
            this.fILEToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.fILEToolStripMenuItem.Text = "文件";
            // 
            // 更新AD配置ToolStripMenuItem
            // 
            this.更新AD配置ToolStripMenuItem.Name = "更新AD配置ToolStripMenuItem";
            this.更新AD配置ToolStripMenuItem.Size = new System.Drawing.Size(185, 24);
            this.更新AD配置ToolStripMenuItem.Text = "更新AD配置XML";
            this.更新AD配置ToolStripMenuItem.Click += new System.EventHandler(this.更新AD配置ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(182, 6);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(185, 24);
            this.退出ToolStripMenuItem.Text = "退出";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.串口设置ToolStripMenuItem,
            this.曲线设置ToolStripMenuItem});
            this.设置ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // 串口设置ToolStripMenuItem
            // 
            this.串口设置ToolStripMenuItem.Name = "串口设置ToolStripMenuItem";
            this.串口设置ToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.串口设置ToolStripMenuItem.Text = "串口设置";
            this.串口设置ToolStripMenuItem.Click += new System.EventHandler(this.串口设置ToolStripMenuItem_Click);
            // 
            // 曲线设置ToolStripMenuItem
            // 
            this.曲线设置ToolStripMenuItem.Name = "曲线设置ToolStripMenuItem";
            this.曲线设置ToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.曲线设置ToolStripMenuItem.Text = "曲线设置";
            this.曲线设置ToolStripMenuItem.Click += new System.EventHandler(this.曲线设置ToolStripMenuItem_Click);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(887, 21);
            this.vScrollBar1.Maximum = 6009;
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(31, 162);
            this.vScrollBar1.TabIndex = 187;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.BackColor = System.Drawing.Color.Transparent;
            this.label43.Font = new System.Drawing.Font("楷体", 12F);
            this.label43.Location = new System.Drawing.Point(152, 143);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(40, 16);
            this.label43.TabIndex = 144;
            this.label43.Text = "29℃";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.BackColor = System.Drawing.Color.Transparent;
            this.label42.Font = new System.Drawing.Font("楷体", 12F);
            this.label42.Location = new System.Drawing.Point(293, 143);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(32, 16);
            this.label42.TabIndex = 143;
            this.label42.Text = "86%";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("楷体", 12F);
            this.label1.Location = new System.Drawing.Point(697, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 188;
            this.label1.Text = "1450r/min";
            // 
            // lbAnalogMeter3
            // 
            this.lbAnalogMeter3.BackColor = System.Drawing.Color.Transparent;
            this.lbAnalogMeter3.BodyColor = System.Drawing.Color.Transparent;
            this.lbAnalogMeter3.Font = new System.Drawing.Font("楷体", 13F);
            this.lbAnalogMeter3.ForeColor = System.Drawing.Color.DarkBlue;
            this.lbAnalogMeter3.Location = new System.Drawing.Point(645, 3);
            this.lbAnalogMeter3.MaxValue = 1450D;
            this.lbAnalogMeter3.MeterStyle = LBSoft.IndustrialCtrls.Meters.LBAnalogMeter.AnalogMeterStyle.Circular;
            this.lbAnalogMeter3.MinValue = 0D;
            this.lbAnalogMeter3.Name = "lbAnalogMeter3";
            this.lbAnalogMeter3.NeedleColor = System.Drawing.Color.Coral;
            this.lbAnalogMeter3.Renderer = null;
            this.lbAnalogMeter3.ScaleColor = System.Drawing.Color.Blue;
            this.lbAnalogMeter3.ScaleDivisions = 6;
            this.lbAnalogMeter3.ScaleSubDivisions = 5;
            this.lbAnalogMeter3.Size = new System.Drawing.Size(176, 175);
            this.lbAnalogMeter3.TabIndex = 189;
            this.lbAnalogMeter3.Value = 0D;
            this.lbAnalogMeter3.ViewGlass = false;
            // 
            // serialPort5
            // 
            this.serialPort5.BaudRate = 115200;
            this.serialPort5.DataBits = 7;
            this.serialPort5.StopBits = System.IO.Ports.StopBits.Two;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 12F);
            this.button1.Location = new System.Drawing.Point(835, 107);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 78);
            this.button1.TabIndex = 190;
            this.button1.Text = "开启风机";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(835, 18);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(46, 34);
            this.button2.TabIndex = 191;
            this.button2.Text = "复位";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("宋体", 12F);
            this.button3.Location = new System.Drawing.Point(934, 32);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(61, 68);
            this.button3.TabIndex = 192;
            this.button3.Text = "开始采集";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Font = new System.Drawing.Font("宋体", 12F);
            this.button4.Location = new System.Drawing.Point(934, 117);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(61, 68);
            this.button4.TabIndex = 193;
            this.button4.Text = "停止采集";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // timer4
            // 
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 35.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.SkyBlue;
            this.label2.Location = new System.Drawing.Point(544, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 47);
            this.label2.TabIndex = 194;
            this.label2.Text = "KPa";
            // 
            // BtnMin
            // 
            this.BtnMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnMin.BackColor = System.Drawing.Color.Transparent;
            this.BtnMin.BackgroundImage = global::风动测试.Properties.Resources.btn_min;
            this.BtnMin.Location = new System.Drawing.Point(931, 3);
            this.BtnMin.Name = "BtnMin";
            this.BtnMin.Size = new System.Drawing.Size(26, 23);
            this.BtnMin.TabIndex = 136;
            this.BtnMin.TabStop = false;
            this.BtnMin.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BtnWnd_MouseClick);
            this.BtnMin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnWnd_MouseDown);
            this.BtnMin.MouseEnter += new System.EventHandler(this.BtnWnd_MouseEnter);
            this.BtnMin.MouseLeave += new System.EventHandler(this.BtnWnd_MouseLeave);
            this.BtnMin.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnWnd_MouseUp);
            // 
            // BtnMax
            // 
            this.BtnMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnMax.BackColor = System.Drawing.Color.Transparent;
            this.BtnMax.BackgroundImage = global::风动测试.Properties.Resources.btn_max;
            this.BtnMax.Location = new System.Drawing.Point(961, 3);
            this.BtnMax.Name = "BtnMax";
            this.BtnMax.Size = new System.Drawing.Size(26, 23);
            this.BtnMax.TabIndex = 137;
            this.BtnMax.TabStop = false;
            this.BtnMax.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BtnWnd_MouseClick);
            this.BtnMax.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnWnd_MouseDown);
            this.BtnMax.MouseEnter += new System.EventHandler(this.BtnWnd_MouseEnter);
            this.BtnMax.MouseLeave += new System.EventHandler(this.BtnWnd_MouseLeave);
            this.BtnMax.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnWnd_MouseUp);
            // 
            // BtnClose
            // 
            this.BtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnClose.BackColor = System.Drawing.Color.Transparent;
            this.BtnClose.BackgroundImage = global::风动测试.Properties.Resources.btn_close;
            this.BtnClose.Location = new System.Drawing.Point(991, 3);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(26, 23);
            this.BtnClose.TabIndex = 138;
            this.BtnClose.TabStop = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            this.BtnClose.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BtnWnd_MouseClick);
            this.BtnClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnWnd_MouseDown);
            this.BtnClose.MouseEnter += new System.EventHandler(this.BtnWnd_MouseEnter);
            this.BtnClose.MouseLeave += new System.EventHandler(this.BtnWnd_MouseLeave);
            this.BtnClose.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnWnd_MouseUp);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(418, 18);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(60, 160);
            this.textBox1.TabIndex = 195;
            this.textBox1.Visible = false;
            this.textBox1.DoubleClick += new System.EventHandler(this.textBox1_DoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1024, 732);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbAnalogMeter3);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnMax);
            this.Controls.Add(this.BtnMin);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.checkBox32);
            this.Controls.Add(this.checkBox31);
            this.Controls.Add(this.lbDigitalMeter2);
            this.Controls.Add(this.checkBox30);
            this.Controls.Add(this.lbDigitalMeter1);
            this.Controls.Add(this.checkBox29);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.checkBox28);
            this.Controls.Add(this.lbAnalogMeter2);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.checkBox19);
            this.Controls.Add(this.lbAnalogMeter1);
            this.Controls.Add(this.checkBox20);
            this.Controls.Add(this.checkBox21);
            this.Controls.Add(this.checkBox22);
            this.Controls.Add(this.checkBox23);
            this.Controls.Add(this.checkBox24);
            this.Controls.Add(this.checkBox25);
            this.Controls.Add(this.checkBox26);
            this.Controls.Add(this.checkBox27);
            this.Controls.Add(this.checkBox13);
            this.Controls.Add(this.checkBox14);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox15);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.checkBox16);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox17);
            this.Controls.Add(this.checkBox6);
            this.Controls.Add(this.checkBox18);
            this.Controls.Add(this.checkBox7);
            this.Controls.Add(this.checkBox10);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.checkBox11);
            this.Controls.Add(this.checkBox8);
            this.Controls.Add(this.checkBox12);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox9);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.label45);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private LBSoft.IndustrialCtrls.Meters.LBAnalogMeter lbAnalogMeter1;
        private LBSoft.IndustrialCtrls.Meters.LBAnalogMeter lbAnalogMeter2;
        private LBSoft.IndustrialCtrls.Meters.LBDigitalMeter lbDigitalMeter2;
        private LBSoft.IndustrialCtrls.Meters.LBDigitalMeter lbDigitalMeter1;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Timer timerCure;
        private System.Windows.Forms.Timer timerCsv;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.CheckBox checkBox10;
        private System.Windows.Forms.CheckBox checkBox11;
        private System.Windows.Forms.CheckBox checkBox12;
        private System.Windows.Forms.CheckBox checkBox13;
        private System.Windows.Forms.CheckBox checkBox14;
        private System.Windows.Forms.CheckBox checkBox15;
        private System.Windows.Forms.CheckBox checkBox16;
        private System.Windows.Forms.CheckBox checkBox17;
        private System.Windows.Forms.CheckBox checkBox18;
        private System.Windows.Forms.CheckBox checkBox19;
        private System.Windows.Forms.CheckBox checkBox20;
        private System.Windows.Forms.CheckBox checkBox21;
        private System.Windows.Forms.CheckBox checkBox22;
        private System.Windows.Forms.CheckBox checkBox23;
        private System.Windows.Forms.CheckBox checkBox24;
        private System.Windows.Forms.CheckBox checkBox25;
        private System.Windows.Forms.CheckBox checkBox26;
        private System.Windows.Forms.CheckBox checkBox27;
        private System.Windows.Forms.CheckBox checkBox32;
        private System.Windows.Forms.CheckBox checkBox31;
        private System.Windows.Forms.CheckBox checkBox30;
        private System.Windows.Forms.CheckBox checkBox29;
        private System.Windows.Forms.CheckBox checkBox28;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fILEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 更新AD配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 串口设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 曲线设置ToolStripMenuItem;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label1;
        private LBSoft.IndustrialCtrls.Meters.LBAnalogMeter lbAnalogMeter3;
        private System.IO.Ports.SerialPort serialPort5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox BtnMin;
        private System.Windows.Forms.PictureBox BtnMax;
        private System.Windows.Forms.PictureBox BtnClose;
        private System.Windows.Forms.TextBox textBox1;
    }
}

