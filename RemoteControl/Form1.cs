using RemoteControl.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RemoteControl
{
    public partial class Form1 : Form
    {
        delegate void deg(object obj);
        public static Form1 form;
        private bool isHide;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //string tmp = @"{ ""CommandId"":1 }";
            //JsonFactory factory = new JsonFactory();
            //factory.CreateCommand(tmp);
            TcpListener listener = new TcpListener();
            listener.StartListen();
            form = this;
            HideAll();
        }

        private void SetTextBoxValue(object str)
        {
            rtxtLog.AppendText(str.ToString() + "");
        }

        public void Log(object obj)
        {
            if(rtxtLog.InvokeRequired)
            {
                deg d = new deg(SetTextBoxValue);
                rtxtLog.Invoke(d, obj);
            }
            else
            {
                Log(obj.ToString());
            }
        }

        public void ShowBalloonTip(string tipTitle,string tipText)
        {
            nico1.ShowBalloonTip(1000, tipTitle, tipText, ToolTipIcon.None);
        }

        private void nico1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (isHide == true)
                ShowAll();
            else
                HideAll();
        }

        private void ShowAll()
        {
            this.Show();
            this.Activate();
            this.ShowInTaskbar = true;
            isHide = false;
        }

        private void HideAll()
        {
            isHide = true;
            this.Hide();
            this.ShowInTaskbar = false;
        }
    }
}
