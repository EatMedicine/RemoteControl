using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RemoteControl.Command
{
    public class Invoker
    {
        private List<Command> cmdList;

        public Invoker()
        {
            cmdList = new List<Command>();
        }

        public void AddCommand(Command cmd)
        {
            cmdList.Add(cmd);
        }

        public void ExecuteAll()
        {
            foreach(Command cmd in cmdList)
            {
                cmd.Execute();
            }
        }
    }
}
