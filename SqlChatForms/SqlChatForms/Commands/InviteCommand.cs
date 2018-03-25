using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlChatForms.Commands
{
    public class InviteCommand : Command
    {
        public InviteCommand()
            : base()
        {
            label = ".invite";
            description = "Invite someone to the current chatroom.\nUsage: .invite <username>";
        }

        public override void Execute(string[] arguments)
        {
            base.Execute(arguments);

            if (arguments.Count() != 1)
            {
                Fail();
                return;
            }

            int id = Program.login.FindUserID(arguments[0]);
            if(id == -1)
            {
                Fail();
                return;
            }

            Program.rooms.Invite(id);
        }
    }
}
