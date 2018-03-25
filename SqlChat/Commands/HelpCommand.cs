using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlChat.Commands
{
    public class HelpCommand : Command
    {
        List<Command> activeCommands = new List<Command>();

        public HelpCommand(List<Command> activeCommands)
            : base()
        {
            label = ".help";
            description = "Shows description of all commands or a specified command.\nUsage: .help (command) | .help colors";
            this.activeCommands = activeCommands;
        }
        public override void Execute(string[] arguments)
        {
            base.Execute(arguments);
            if (arguments.Count() == 0)
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach(Command command in activeCommands)
                {
                    stringBuilder.Append(command.label);
                    stringBuilder.Append(" - ");
                    stringBuilder.AppendLine(command.description);
                    stringBuilder.AppendLine();
                }
                Console.Write(stringBuilder.ToString());
            }
            else
            {
                if(arguments[0].ToLower() == "colors")
                {
                    Console.WriteLine("§0 - Black       §1 - Dark Blue\n§2 - Dark Green  §3 - Dark Cyan\n§4 - Dark Red    §5 - Dark Magenta\n§6 - Dark Yellow §7 - White\n§8 - Gray        §9 - Blue\n§a - Green       §b - Cyan\n§c - Red         §d - Magenta\n§e - Yellow      §f - Bright White");
                    return;
                }

                foreach (Command command in activeCommands)
                {
                    if(command.label == arguments[0].ToLower())
                    {
                        Console.WriteLine($"{command.label} - {command.description}");
                    }
                }
            }
        }
    }
}
