using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteControl
{
    public class TcpListener
    {

        private static string _listenHost = "0.0.0.0";
        private static int _listenPort = 54545;

        private bool isListening = false;
        private Task listenTask = null;
        private CancellationTokenSource tokenSource = null;
        private Socket mSocket = null;

        public TcpListener()
        {
            StartListen();
        }

        public void StartListen()
        {
            //如果正在监听则不创建新线程了
            if (isListening)
            {
                return;
            }
            //创建Socket
            IPAddress ip = IPAddress.Parse(_listenHost);
            IPEndPoint ipe = new IPEndPoint(ip,_listenPort);
            mSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            mSocket.Bind(ipe);

            tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            listenTask = Task.Factory.StartNew(() =>
            {
                mSocket.Listen(5);
                while (true)
                {
                    if (token.IsCancellationRequested)
                    {
                        break;
                    }
                    Socket newSocket = mSocket.Accept();
                    new SocketHandler(newSocket);
                    Thread.Sleep(1000);
                }
            }, token);
            isListening = true;
        }

        public void StopListen()
        {
            if (mSocket == null)
            {
                return;
            }
            mSocket.Close();
            mSocket = null;
            isListening = false;
            tokenSource.Cancel();
        }

    }
}
