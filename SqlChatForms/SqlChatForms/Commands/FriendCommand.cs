using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlChatForms.Commands
{
    public class FriendCommand : Command
    {
        public FriendCommand()
            : base()
        {
            label = ".friend";
            description = "Access friend information.\nUsage: .friend add <username>";
        }

        public override void Execute(string[] arguments)
        {
            base.Execute(arguments);
            if(arguments.Count() != 2) {
                Fail();
                return;
            }


        }
    }
}
