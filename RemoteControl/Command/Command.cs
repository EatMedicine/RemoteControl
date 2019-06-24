using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RemoteControl.Command
{
    public abstract class Command
    {
        public int CommandId;
        /// <summary>
        /// 执行命令
        /// </summary>
        public abstract void Execute();
    }
}
