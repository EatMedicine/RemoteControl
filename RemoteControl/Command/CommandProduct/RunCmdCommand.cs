using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RemoteControl.Command.CommandProduct
{
    class RunCmdCommand : Command
    {
        public string Msg { get; set; }

        public RunCmdCommand(JToken obj)
        {
            if (obj == null)
            {
                Msg = "";
            }
            Msg = obj.ToString();
            //指令ID
            CommandId = 6;
        }

        public RunCmdCommand(string msg)
        {
            Msg = msg;
            //指令ID
            CommandId = 6;
        }

        public override void Execute()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process()
            {
                StartInfo = {
                      FileName = "cmd.exe",
                UseShellExecute = false,    //是否使用操作系统shell启动
                RedirectStandardInput = true,//接受来自调用程序的输入信息
                RedirectStandardOutput = true,//由调用程序获取输出信息
                RedirectStandardError = true,//重定向标准错误输出
                CreateNoWindow = true,//不显示程序窗口
                }

            };
            p.Start();//启动程序
            p.StandardInput.WriteLine(Msg);
            Thread.Sleep(1000);
            p.Close();
        }
    }
}
