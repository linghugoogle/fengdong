using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

namespace 风动测试
{
    /// <summary>
    /// 控件状态
    /// </summary>
    public enum ControlState
    {
        Normal = 1,//控件默认时
        MouseOver = 2,//鼠标移上控件时
        MouseDown = 3,//鼠标按下控件时
        Disable = 4 //当控件不可用时
    }
    /// <summary>
    /// 资源辅助类
    /// </summary>
    class ResUtils
    {
        /// <summary>
        /// 根据资源名称获取图像
        /// </summary>
        /// <param name="name">资源名称</param>
        /// <returns>图像</returns>
        public static Bitmap GetResAsImage(string name)
        {
            if (name == null || name == "")
            {
                return null;
            }
            return (Bitmap)Properties.Resources.ResourceManager.GetObject(name);
        }

        /// <summary>
        /// 图片按钮的背景图是4个,根据状态获取其中背景图
        /// </summary>
        /// <param name="name">图片名称</param>
        /// <param name="state">状态</param>
        /// <returns></returns>
        public static Bitmap GetResWithState(String name, ControlState state)
        {
            Bitmap bitmap = (Bitmap)GetResAsImage(name);
            if (bitmap == null)
            {
                return null;
            }
            int block = 0;
            switch (state)
            {
                case ControlState.Normal: block = 0; break;
                case ControlState.MouseOver: block = 1; break;
                case ControlState.MouseDown: block = 2; break;
                case ControlState.Disable: block = 3; break;
            }
            int width = bitmap.Width / 4;
            Rectangle rect = new Rectangle(block * width, 0, width, bitmap.Height);
            return bitmap.Clone(rect, bitmap.PixelFormat);
        }
    }
    /// <summary>
    /// FormMain_DrawTitleBar
    /// </summary>
    public partial class Form1
    {
        public const String IMG_MIN = "btn_min";
        public const String IMG_MAX = "btn_max";
        public const String IMG_RESTORE = "btn_restore";
        public const String IMG_CLOSE = "btn_close";
        public const String IMG_BG = "img_bg";

        // 图片缓存
        private Bitmap closeBmp = null;
        private Bitmap minBmp = null;
        private Bitmap maxBmp = null;
        private Bitmap restoreBmp = null;

        private int WM_SYSCOMMAND = 0x112;
        private long SC_MAXIMIZE = 0xF030;
        private long SC_MINIMIZE = 0xF020;
        private long SC_RESTORE = 0xF120;
        private long SC_CLOSE = 0xF060;
        private FormWindowState CurrentWindowState = 0;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SYSCOMMAND)
            {
                if (m.WParam.ToInt64() == SC_MAXIMIZE)
                {
                    return;
                }
                if (m.WParam.ToInt64() == SC_MINIMIZE)
                {
                    CurrentWindowState = this.WindowState;
                    this.WindowState = FormWindowState.Minimized;
                    return;
                }
                if (m.WParam.ToInt64() == SC_CLOSE)
                {
                    return;
                }
                if (m.WParam.ToInt64() == SC_RESTORE)
                {
                    //this.FormBorderStyle = FormBorderStyle.Sizable;
                    if (CurrentWindowState != FormWindowState.Maximized)
                    {
                        //SetWindowLong(this.Handle, GWL_STYLE, (uint)(GetWindowLong(this.Handle, GWL_STYLE) & ~WS_CAPTION));
                        this.WindowState = FormWindowState.Normal;
                    }
                    else
                    {
                        //this.WindowState = FormWindowState.Normal;
                        //SetWindowLong(this.Handle, GWL_STYLE, (uint)(GetWindowLong(this.Handle, GWL_STYLE) & ~WS_CAPTION));
                        this.WindowState = FormWindowState.Maximized;
                    }


                    return;
                }
            }
            base.WndProc(ref m);
        }

        private void LoadTitleBarImage()
        {
            // 获取最大化、最小化、关闭的背景图片
            this.minBmp = ResUtils.GetResAsImage(IMG_MIN);
            this.maxBmp = ResUtils.GetResAsImage(IMG_MAX);
            this.closeBmp = ResUtils.GetResAsImage(IMG_CLOSE);
            this.restoreBmp = ResUtils.GetResAsImage(IMG_RESTORE);

            if (this.WindowState == FormWindowState.Maximized)
            {
                this.BtnMax.BackgroundImage = this.restoreBmp;
                this.BtnMax.Invalidate();
            }
        }
        private void BtnWnd_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (sender == this.BtnClose)
                {
                    this.Close();
                }
                else if (sender == this.BtnMax)
                {
                    if (this.WindowState == FormWindowState.Normal)
                    {
                        //this.FormBorderStyle = FormBorderStyle.Sizable;
                        //SetWindowLong(this.Handle, GWL_STYLE, (uint)(GetWindowLong(this.Handle, GWL_STYLE) & ~WS_CAPTION));
                        this.WindowState = FormWindowState.Maximized;
                        this.BtnMax.BackgroundImage = this.restoreBmp;
                        this.BtnMax.Invalidate();
                    }
                    else
                    {
                        this.WindowState = FormWindowState.Normal;
                        this.BtnMax.BackgroundImage = this.maxBmp;
                    }
                }
                else if (sender == this.BtnMin)
                {
                    if (!this.ShowInTaskbar)
                    {
                        this.Hide();
                    }
                    else
                    {
                        this.WindowState = FormWindowState.Minimized;
                    }
                }
            }
        }

        // 鼠标进入
        private void BtnWnd_MouseEnter(object sender, EventArgs e)
        {
            Bitmap backImage = null;
            if (sender == this.BtnClose)
            {
                backImage = ResUtils.GetResWithState(IMG_CLOSE, ControlState.MouseOver);
            }
            else if (sender == this.BtnMin)
            {
                backImage = ResUtils.GetResWithState(IMG_MIN, ControlState.MouseOver);
            }
            else if (sender == this.BtnMax)
            {
                if (this.WindowState == FormWindowState.Normal)
                {
                    backImage = ResUtils.GetResWithState(IMG_MAX, ControlState.MouseOver);
                }
                else
                {
                    backImage = ResUtils.GetResWithState(IMG_RESTORE, ControlState.MouseOver);
                }
            }
            else
            {
                return;
            }
            Control control = (Control)sender;
            control.BackgroundImage = backImage;
            control.Invalidate();
        }

        // 鼠标移开
        private void BtnWnd_MouseLeave(object sender, EventArgs e)
        {
            Bitmap backImage = null;
            if (sender == this.BtnClose)
            {
                backImage = closeBmp;
            }
            else if (sender == this.BtnMin)
            {
                backImage = minBmp;
            }
            else if (sender == this.BtnMax)
            {
                if (this.WindowState == FormWindowState.Normal)
                {
                    backImage = maxBmp;
                }
                else
                {
                    backImage = restoreBmp;
                }
            }
            else
            {
                return;
            }
            Control control = (Control)sender;
            control.BackgroundImage = backImage;
            control.Invalidate();
        }

        // 鼠标按下
        private void BtnWnd_MouseDown(object sender, MouseEventArgs e)
        {
            Bitmap backImage = null;
            if (sender == this.BtnClose)
            {
                backImage = ResUtils.GetResWithState(IMG_CLOSE, ControlState.MouseDown);
            }
            else if (sender == this.BtnMin)
            {
                backImage = ResUtils.GetResWithState(IMG_MIN, ControlState.MouseDown);
            }
            else if (sender == this.BtnMax)
            {
                if (this.WindowState == FormWindowState.Normal)
                {
                    backImage = ResUtils.GetResWithState(IMG_MAX, ControlState.MouseDown);
                }
                else
                {
                    backImage = ResUtils.GetResWithState(IMG_RESTORE, ControlState.MouseDown);
                }
            }
            else
            {
                return;
            }
            Control control = (Control)sender;
            control.BackgroundImage = backImage;
            control.Invalidate();
        }

        // 鼠标弹起
        private void BtnWnd_MouseUp(object sender, MouseEventArgs e)
        {
            Bitmap backImage = null;
            if (sender == this.BtnClose)
            {
                backImage = closeBmp;
            }
            else if (sender == this.BtnMin)
            {
                backImage = minBmp;
            }
            else if (sender == this.BtnMax)
            {
                if (this.WindowState == FormWindowState.Normal)
                {
                    backImage = maxBmp;
                }
                else
                {
                    backImage = restoreBmp;
                }
            }
            else
            {
                return;
            }
            Control control = (Control)sender;
            control.BackgroundImage = backImage;
            control.Invalidate();
        }

        bool formMove = false;//窗体是否移动
        Point formPoint;//记录窗体的位置
        private void FormMain_MouseDown(object sender, MouseEventArgs e)//鼠标按下
        {
            formPoint = new Point();
            int xOffset;
            int yOffset;
            if (e.Button == MouseButtons.Left)
            {
                xOffset = -e.X - SystemInformation.FrameBorderSize.Width;
                yOffset = -e.Y - SystemInformation.CaptionHeight - SystemInformation.FrameBorderSize.Height;
                formPoint = new Point(xOffset, yOffset);
                formMove = true;//开始移动
            }
        }

        private void FormMain_MouseMove(object sender, MouseEventArgs e)//鼠标移动
        {
            if (formMove == true)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(formPoint.X, formPoint.Y);
                Location = mousePos;
            }
        }

        private void FormMain_MouseUp(object sender, MouseEventArgs e)//鼠标松开
        {
            if (e.Button == MouseButtons.Left)//按下的是鼠标左键
            {
                formMove = false;//停止移动
            }
        }
    }
}
