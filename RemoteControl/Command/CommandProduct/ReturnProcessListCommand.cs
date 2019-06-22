using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace RemoteControl.Command.CommandProduct
{
    class ReturnProcessListCommand : Command
    {
        public Socket mSocket = null;
        public ReturnProcessListCommand(Socket socket)
        {
            mSocket = socket;
        }

        public override void Execute()
        {
            Process[] list = Process.GetProcesses();
            List<string> nameList = new List<string>();
            foreach(Process item in list)
            {
                if (nameList.Contains(item.ProcessName))
                    continue;
                nameList.Add(item.ProcessName);
            }
            string[] names = nameList.ToArray();
            JObject jobj = new JObject();
            jobj["data"] = new JArray(names);
            string json = jobj.ToString();
            try
            {
                mSocket.Send(Encoding.UTF8.GetBytes(json));
            }
            catch
            {
                return;
            }


        }
    }
}
