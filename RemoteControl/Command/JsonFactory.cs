using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RemoteControl.Command
{
    public class JsonFactory : IFactory
    {
        public Command CreateCommand(string str)
        {
            var obj = JsonConvert.DeserializeObject<dynamic>(str);
            string tmp = (string)obj.CommandId;
            return null;
        }
    }
}
