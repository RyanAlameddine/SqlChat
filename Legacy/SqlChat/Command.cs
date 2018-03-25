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
        public List<string> aliases = new List<string>();
        
        public virtual void Execute(string[] arguments)
        {

        }

        public void Fail()
        {
            ConsoleAdditions.WriteLine($"§4Command execution failed. Please view the following information on {label}§4.");
            Program.commandHandler.Execute($".help {label}");
        }
    }
}
