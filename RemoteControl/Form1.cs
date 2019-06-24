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


    }
}
