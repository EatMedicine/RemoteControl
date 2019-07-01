using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace RemoteControl.Command.CommandProduct
{
    /// <summary>
    /// CommandId=5 打开文件命令
    /// </summary>
    class OpenFileCommand : Command
    {

        public string FileName { get; set; }

        public OpenFileCommand(string fileName)
        {
            FileName = @"D:\"+fileName;
            CommandId = 5;
        }

        public OpenFileCommand(JToken obj)
        {
            if (obj == null)
                FileName = null;
            else
                FileName = @"D:\" + obj.ToString();
            CommandId = 5;
        }

        public override void Execute()
        {
            if (FileName == null)
                return;
            if (File.Exists(FileName) == false)
                return;
            Process process1 = new Process();
            process1.StartInfo.FileName = FileName;
            process1.Start();
        }
    }
}
