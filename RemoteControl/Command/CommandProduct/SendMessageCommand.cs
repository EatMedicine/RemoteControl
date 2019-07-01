using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RemoteControl.Command.CommandProduct
{
    class SendMessageCommand : Command
    {

        public string Msg { get; set; }

        public SendMessageCommand(JToken obj)
        {
            if(obj==null)
            {
                Msg = "";
            }
            Msg = obj.ToString();
            //指令ID
            CommandId = 3;
        }

        public SendMessageCommand(string msg)
        {
            Msg = msg;
            //指令ID
            CommandId = 3;
        }

        public override void Execute()
        {
            if (Msg == "")
                return;
            Form1.form.ShowBalloonTip("RemoteControl", Msg);
        }
    }
}
