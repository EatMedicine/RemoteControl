using RemoteControl.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControl
{
    public class SocketHandler
    {
        public Socket _socket;
        private IFactory factory;
        public Invoker invoker = null;

        public SocketHandler(Socket socket)
        {
            //init
            _socket = socket;
            invoker = new Invoker();
            factory = new JsonFactory();


            Task task = Task.Factory.StartNew(() =>
            {
                try
                {
                    while (true)
                    {
                        byte[] buffer = new byte[1024*16];
                        int length = _socket.Receive(buffer);
                        if (length == 0)
                            continue;
                        string msg = Encoding.UTF8.GetString(buffer, 0, length);
                        invoker.AddCommand(factory.CreateCommand(msg,this));
                        invoker.ExecuteAll();
                    }
                }
                catch (Exception ex)
                {
                    socket.Dispose();
                }
            });
        }

    }
}
