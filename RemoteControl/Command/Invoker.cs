using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            if (cmd == null)
                return;
            cmdList.Add(cmd);
        }

        public void ExecuteAll()
        {
            
            //异步执行
            Task task = Task.Factory.StartNew(() =>
            {
                foreach (Command cmd in cmdList)
                {
                    cmd.Execute();
                    cmdList.Remove(cmd);
                }
            });

        }
    }
}
