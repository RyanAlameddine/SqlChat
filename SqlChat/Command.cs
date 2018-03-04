using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlChat
{
    public abstract class Command
    {
        public string label;
        public string description;
        
        public virtual void Execute(string[] arguments)
        {

        }

        public void Fail()
        {
            ConsoleAdditions.ColoredWriteLine(ConsoleColor.Red, $"Command execution failed. Please view the following information on {label}.");
            Program.commandHandler.Execute($"help {label}");
        }
    }
}
