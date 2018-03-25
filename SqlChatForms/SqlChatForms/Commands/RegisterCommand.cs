using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlChatForms.Commands
{
    public class RegisterCommand : Command
    {
        public RegisterCommand()
            : base()
        {
            label = ".register";
            description = "Register for Ch@room.\nUsage: .register <username> <password>";
        }

        public override void Execute(string[] arguments)
        {
            base.Execute(arguments);
            if(arguments.Count() != 2) {
                Fail();
                return;
            }

            Program.login.createUser(arguments[0], arguments[1]);
        }
    }
}
