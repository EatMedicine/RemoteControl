using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace RemoteControl.Command.CommandProduct
{
    class ReturnFileListCommand : Command
    {
        public Socket mSocket = null;
        public string Path { get; set; }
        public ReturnFileListCommand(Socket socket,JToken obj)
        {
            mSocket = socket;
            if(obj == null)
            {
                Path = null;
            }
            else
            {
                Path = obj.ToString();
            }

            CommandId = 4;
        }

        public override void Execute()
        {
            string rootPath = @"D:\"+Path;
            DirectoryInfo info = new DirectoryInfo(rootPath);
            //获取文件信息
            FileInfo[] fileList = info.GetFiles();
            string[] fileNames = new string[fileList.Length];
            for(int count = 0; count < fileList.Length; count++)
            {
                fileNames[count] = fileList[count].Name;
            }
            //获取文件夹信息
            DirectoryInfo[] dirList = info.GetDirectories();
            string[] dirNames = new string[dirList.Length];
            for (int count = 0; count < dirList.Length; count++)
            {
                dirNames[count] = dirList[count].Name;
            }


            JObject jobj = new JObject();
            jobj["fileData"] = new JArray(fileNames);
            jobj["dirData"] = new JArray(dirNames);
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
