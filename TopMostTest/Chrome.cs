﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MouseKeyboardActivityMonitor;
using MouseKeyboardActivityMonitor.WinApi;
using System.Security.Principal;
using System.Collections;
using System.IO;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Chrome;
using Patagames.Ocr;
using Patagames.Ocr.Enums;
using System.Threading;

namespace TopMostTest
{
    public partial class Chrome : Form
    {
        MouseHookListener mouseHookListener;
        Point mousePos, firstPos, endPos;
        int imageCount=1;
        Bitmap bQuest;
        bool isEnable = false;
        string pathKey="", pathAns="";
        List<string> keys, founds;
        IEnumerable<string> results;
        int resultsCount = 0;
        double opacity = 1;
        bool isHide = true;
        bool isSelected = false;
		bool isEnableCapture = false;
        bool language = false;
        Thread showForm;
        bool isShow = true;
        TextBox txtSelected = new TextBox();
        int mode = 0;
        ManualResetEvent _event = new ManualResetEvent(true);

        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(int hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out Point lpPoint);
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);
        public Chrome()
        {
            InitializeComponent();
            txtQuestion.BackColor = Color.FromArgb(241, 241, 241);
            txtResult.BackColor = Color.FromArgb(241, 241, 241);
            txtSupport.BackColor = Color.FromArgb(241, 241, 241);
            this.ShowInTaskbar = false;
            txtSelected.TextChanged += TxtSelected_TextChanged;
        }

        private void TxtSelected_TextChanged(object sender, EventArgs e)
        {
            if (pathKey != null && !pathKey.Equals(""))
            {
                resultsCount = 0;
                var match = founds.Where(x => x.Contains(txtSelected.Text.ToLower())
                                            || x.Contains(convertToANSI(txtSelected.Text.ToLower())));
                if (match != null && match.Count() != 0)
                {
                    try
                    {
                        txtResult.Text = match.ElementAt(0).Split('|')[1] + " (" + match.Count() + ")";
                    }
                    catch (Exception ex)
                    {
                    }
                    if (match.Count() > 1)
                        results = match;
                }
                else txtResult.Text = "No result";
            }
            else
            {
                txtResult.Text = "select File key first";
            }
            isSelected = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SizeF scale = new SizeF { Width = Screen.PrimaryScreen.Bounds.Width / 1920f, Height = Screen.PrimaryScreen.Bounds.Height / 1080f };
            Scale(scale);
            //Point location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - this.Width / 2, SystemInformation.VirtualScreen.Height - this.Height);
            Point location = new Point((int)Math.Floor(286 * scale.Width), (int) Math.Floor(226 * scale.Height));
            Location = location;
            this.mouseHookListener = new MouseHookListener(new GlobalHooker());
            this.mouseHookListener.Enabled = true;
            this.mouseHookListener.MouseDoubleClick += MouseHookListener_MouseDoubleClick;
            this.mouseHookListener.MouseClick += MouseHookListener_MouseClick;
            this.mouseHookListener.MouseDown += MouseHookListener_MouseDown;
            this.mouseHookListener.MouseUp += MouseHookListener_MouseUp;
            this.mouseHookListener.MouseWheel += MouseHookListener_MouseWheel;
            showForm = new Thread(new ThreadStart(showForm_run));
            showForm.Priority = ThreadPriority.Highest;
            Opacity = 0;
            try
            {
                showForm.Start();
            }
            catch (Exception ex) { }
        }

        private void MouseHookListener_MouseClick(object sender, MouseEventArgs e)
        {
            int middle = Screen.PrimaryScreen.Bounds.Width / 2;
            GetCursorPos(out mousePos);
            if (mousePos.X > middle-100 && mousePos.X < middle + 100 && mousePos.Y == 0)
            {
                if(e.Button == MouseButtons.Left)
                {
                    if (isHide)
                    {
                        this.Hide();
                        _event.Reset();
                    }
                    else
                    {
                        _event.Set();
                        this.Show();
                        opacity = 0.1;
                        this.Opacity = opacity;
                    }
                    isHide = !isHide;
                }                
            }
        }

        private void MouseHookListener_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                opacity+=0.1;
            else opacity-=0.1; 

            if (opacity > 1) opacity = 1;
            if (opacity < 0) opacity = 0;
            this.Opacity = opacity;
        }

        private void MouseHookListener_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            GetCursorPos(out endPos);
            if (firstPos.X >= 0 && firstPos.Y >= 0 && Math.Abs(endPos.X - firstPos.X)>0 && Math.Abs(endPos.Y - firstPos.Y)>0 && e.Button==MouseButtons.Left && !isSelected) {
                bQuest = ScreenCapture.CaptureActiveWindow(firstPos.X, firstPos.Y, endPos.X, endPos.Y);
                if (bQuest != null)
                {
                    txtQuestion.Text = extractImageToText(bQuest);
                }
            }
        }

        private void MouseHookListener_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                GetCursorPos(out firstPos);
            }
        }

        private void MouseHookListener_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            GetCursorPos(out mousePos);
			if(mousePos.X == Screen.PrimaryScreen.Bounds.Width - 1 && mousePos.Y == 0){
				isEnableCapture = !isEnableCapture;
			}
            if (isEnableCapture)
            {
                ScreenCapture.saveImage(AppDomain.CurrentDomain.BaseDirectory + imageCount);
                imageCount++;
            }
        }


        private void txtQuestion_TextChanged(object sender, EventArgs e)
        {
            if(pathKey != null && !pathKey.Equals(""))
            {
                resultsCount = 0;
                var match = founds.Where(x => x.Contains(txtQuestion.Text.ToLower()) 
                                            || x.Contains(convertToANSI(txtQuestion.Text.ToLower())));
                if (match != null && match.Count() != 0)
                {
                    try
                    {
                        txtResult.Text = match.ElementAt(0).Split('|')[1] + " (" + match.Count() + ")";
                        if (match.Count() == 1) txtResult.Text = match.ElementAt(0).Split('|')[0];
                    }
                    catch(Exception ex)
                    {

                    }
                    if (match.Count() > 1)
                        results = match;
                }
                else txtResult.Text = "No result";
            }
            else
            {
                txtResult.Text = "select File key first";
            }
        }

        private void txtResult_MouseClick(object sender, MouseEventArgs e)
        {
            txtSupport.Show();
            if (pathKey == null || pathKey.Equals("")){
                openFileDialog1.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.InitialDirectory = AppDomain.CurrentDomain.DynamicDirectory;
                if (DialogResult.OK == openFileDialog1.ShowDialog())
                {
                    pathKey = openFileDialog1.FileName;
                    founds = ReadTextFromFile.readFile(pathKey);
                }
            }
            if (results != null && results.Count() > 1)
            {
                try
                {
					txtSupport.Text = results.ElementAt(resultsCount).Split('|')[0];
                    txtResult.Text = results.ElementAt(resultsCount++).Split('|')[1] + " (" + resultsCount + " of " + results.Count() + ")";
                    if (resultsCount == results.Count()) resultsCount = 0;
                }
                catch(Exception ex) { }
            }
        }

        private void txtSupport_MouseClick(object sender, MouseEventArgs e)
        {
            ((TextBox)sender).Hide();
        }

        private void txtQuestion_MouseDown(object sender, MouseEventArgs e)
        {
            isSelected = true;
        }

        private void txtQuestion_MouseUp(object sender, MouseEventArgs e)
        {
            isSelected = false;
        }

        private void btnLanguage_Click(object sender, EventArgs e)
        {
            if (language)
            {
                btnLanguage.Text = "E";
                language = !language;
            }
            else
            {
                btnLanguage.Text = "V";
                language = !language;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            showForm.Abort();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showForm.Abort();
            Application.Exit();
        }
        private string extractImageToText(Bitmap bmp)
        {
            string resultString = "";
            try
            {
                using (var api = OcrApi.Create())
                {
                    if (btnLanguage.Text.Equals("E"))
                        api.Init(Languages.English);
                    else api.Init(Languages.Vietnamese);
                    Thread.Sleep(20);
                    resultString = api.GetTextFromImage(bmp);
                }
            }
            catch(Exception ex)
            {
                resultString = "Try select more area";
            }
            return resultString;
        }
        private String convertToANSI(String encode)
        {
            return Encoding.Default.GetString(Encoding.Default.GetBytes(encode));
        }
        public void showForm_run() {
            while (true)
            {
                Thread.Sleep(1);
                _event.WaitOne();
                this.Invoke(new MethodInvoker(delegate {
                    if (isHide)
                    {
                        ShowWindow(this.Handle, 4);
                        SetWindowPos(this.Handle.ToInt32(), -1, this.Left, this.Top, this.Width, this.Height, 16u);
                        SetForegroundWindow(this.Handle);
                        HideCaret(txtQuestion.Handle);
                        HideCaret(txtResult.Handle);
                        HideCaret(txtSupport.Handle);
                    }
                    if (isSelected)
                        txtSelected.Text = txtQuestion.SelectedText;
                }));

            }
        }
    }
}
