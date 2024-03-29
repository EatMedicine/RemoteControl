﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace RemoteControl.Command.CommandProduct
{
    /// <summary>
    /// 杀死进程命令
    /// </summary>
    public class KillProcessCommand : Command
    {
        /// <summary>
        /// 进程名字
        /// </summary>
        public string ProcessName { get; set; }


        public KillProcessCommand(JToken obj)
        {
            if (obj == null)
            {
                ProcessName = null;
            }
            else
            {
                ProcessName = obj.ToString();
            }
            //指令ID
            CommandId = 1;
        }

        public KillProcessCommand(string processName)
        {
            if(processName == null)
            {
                ProcessName = null;
            }
            ProcessName = processName;
            //指令ID
            CommandId = 1;
        }

        public override void Execute()
        {
            if (ProcessName == null || ProcessName == "")
                return;
            Process[] list = Process.GetProcessesByName(ProcessName);
            if(list == null || list.Length == 0)
            {
                return;
            }
            foreach(Process item in list)
            {
                try
                {
                    item.Kill();
                }
                catch
                {
                    continue;
                }
            }
            return;
        }
    }
}
