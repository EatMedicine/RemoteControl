using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RemoteControl.Command
{
    interface IFactory
    {
        Command CreateCommand(string str,SocketHandler socket);
    }
}
