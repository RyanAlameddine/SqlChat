using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlChatForms.Commands
{
    public class ExitCommand : Command
    {
        public ExitCommand()
            : base()
        {
            label = ".exit";
            description = "Leave Ch@room.\nUsage: .exit";
        }

        public override void Execute(string[] arguments)
        {
            base.Execute(arguments);

            Program.running = false;
        }
    }
}
