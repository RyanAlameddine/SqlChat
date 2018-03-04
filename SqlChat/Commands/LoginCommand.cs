using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlChat.Commands
{
    public class LoginCommand : Command
    {
        public LoginCommand()
            : base()
        {
            label = "login";
            description = "Log into Ch@room.\nUsage: login {username} {password}";
        }

        public override void Execute(string[] arguments)
        {
            base.Execute(arguments);
            if(arguments.Count() != 2) {
                Fail();
                return;
            }

            Program.login.AttemptLogin(arguments[0], arguments[1]);
        }
    }
}
