using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlChat.Commands
{
    public class CreateRoomCommand : Command
    {
        public CreateRoomCommand()
            : base()
        {
            label = "createroom";
            description = "Create a chat room.\nUsage: createroom <name>";
            aliases.Add("cr");
        }

        public override void Execute(string[] arguments)
        {
            base.Execute(arguments);
            if (arguments.Count() != 1)
            {
                Fail();
                return;
            }

            Program.rooms.Createroom(Program.login.userID, arguments[0]);
        }
    }
}
