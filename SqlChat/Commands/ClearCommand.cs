using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlChat.Commands
{
    public class ClearCommand : Command
    {
        public ClearCommand()
            : base()
        {
            label = "clear";
            description = "Clear console.\nUsage: clear";
        }

        public override void Execute(string[] arguments)
        {
            base.Execute(arguments);

            Console.Clear();
        }
    }
}
