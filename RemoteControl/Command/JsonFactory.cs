using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RemoteControl.Command.CommandProduct;
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
            JObject obj;
            try
            {
                obj = JObject.Parse(str);
            }
            catch(Exception ex)
            {
                return null;
            }

            if (obj == null || obj["CommandId"] == null)
            {
                return null;
            }
            int commandId = (int)obj["CommandId"];
            switch (commandId)
            {
                //KillProcess Command
                case 1:
                    if (obj["ProcessName"] == null)
                        return null;
                    else
                        return new KillProcessCommand(obj["ProcessName"].ToString());
                default:break;
            }
            return null;
        }
    }
}
