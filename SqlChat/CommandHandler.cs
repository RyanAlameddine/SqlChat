using SqlChat.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlChat
{
    public class CommandHandler
    {
        List<Command> activeCommands = new List<Command>();

        public CommandHandler()
        {
            activeCommands.Add(new HelpCommand    (activeCommands));
            activeCommands.Add(new LoginCommand   ());
            activeCommands.Add(new RegisterCommand());
            activeCommands.Add(new ClearCommand   ());
        }

        public void InputCommand()
        {
            Console.Write("> ");
            string input = "";
            int inputLengthAtTab = 0;
            int commandEndingsIndex = 0;

            List<string> intendedCommandEndings = new List<string>();
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    intendedCommandEndings.Clear();
                    Console.WriteLine();
                    break;
                }
                else if (key.Key == ConsoleKey.Tab)
                {
                    if (intendedCommandEndings.Count > 0)
                    {
                        commandEndingsIndex++;
                        if (commandEndingsIndex >= intendedCommandEndings.Count) { commandEndingsIndex = 0; }

                        int inputLength = input.Length;

                        for (int i = inputLength; i > inputLengthAtTab; i--)
                        {
                            Console.Write('\x08');
                        }
                        for (int i = inputLength; i > inputLengthAtTab; i--)
                        {
                            Console.Write(' ');
                        }
                        for (int i = inputLength; i > inputLengthAtTab; i--)
                        {
                            Console.Write('\x08');
                        }
                        input = input.Substring(0, input.Length - (inputLength - inputLengthAtTab));

                        Console.Write(intendedCommandEndings[commandEndingsIndex]);
                        input += intendedCommandEndings[commandEndingsIndex];
                        continue;
                    }

                    string[] split = input.Split(' ');

                    inputLengthAtTab = input.Length;

                    if (split.Count() == 1)
                    {
                        foreach(Command command in activeCommands)
                        {
                            if(command.label.Length < split[0].Length)
                            {
                                continue;
                            }
                            else if(command.label.Substring(0, split[0].Length) == split[0].ToLower())
                            {
                                intendedCommandEndings.Add(command.label.Substring(split[0].Length));
                            }
                        }
                    }

                    if(intendedCommandEndings.Count != 0)
                    {
                        Console.Write(intendedCommandEndings[0]);
                        input += intendedCommandEndings[0];
                    }
                } 
                else if (key.Key == ConsoleKey.Backspace)
                {
                    intendedCommandEndings.Clear();
                    if (input.Length == 0) continue;
                    Console.Write('\x08');
                    Console.Write(' ');
                    Console.Write('\x08');
                    input = input.Substring(0, input.Length - 1);
                }
                else
                {
                    intendedCommandEndings.Clear();
                    Console.Write(key.KeyChar);
                    input += key.KeyChar;
                }
            }

            Execute(input);
        }

        public void Execute(string input)
        {
            string[] split = input.Split(' ');

            if (split.Count() == 0) return;

            string[] args = new string[split.Count() - 1];
            for (int i = 0; i < args.Count(); i++)
            {
                args[i] = split[i + 1];
            }
            string label = split[0];

            foreach (Command command in activeCommands)
            {
                if (command.label.ToLower() == label)
                {
                    command.Execute(args);
                    return;
                }
            }
            Console.WriteLine($"Command {label} does not exist. Enter 'help' to see available commands.");
        }

        public void Deregister(params string[] labels)
        {
            for (int c = 0; c < activeCommands.Count; c++)
            {
                foreach (string label in labels)
                {
                    if (label == activeCommands[c].label)
                    {
                        activeCommands.RemoveAt(c);
                        c--;
                    }
                }
            }
        }

        public void Register(params Command[] commands)
        {
            foreach(Command command in commands)
            {
                activeCommands.Add(command);
            }
        }
    }
}
