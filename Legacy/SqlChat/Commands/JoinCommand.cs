﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlChat.Commands
{
    public class JoinCommand : Command
    {
        public JoinCommand()
            : base()
        {
            label = ".join";
            description = "Join a chatroom.\nUsage: .join <room name>";
        }

        public override void Execute(string[] arguments)
        {
            base.Execute(arguments);

            if (arguments.Count() != 1)
            {
                Fail();
                return;
            }

            DataTable table = Program.rooms.JoinRoom(Program.login.userID, arguments[0]);

            if (table == null)
            {
                ConsoleAdditions.WriteLine($"§4Unable to find Chatroom with the name §7{arguments[0]}§4. Please try again or use the .help command for more information.");
                return;
            }

            Console.Clear();
            Console.Title = table.Rows[0][0].ToString();

            DataTable messages = Program.rooms.ReadMessages();

            StringBuilder stringBuilder = new StringBuilder();
            foreach(DataRow row in messages.Rows)
            {
                stringBuilder.Append(row[3]);
                stringBuilder.Append(": ");
                stringBuilder.AppendLine(row[0].ToString());
            }
            ConsoleAdditions.WriteLine(stringBuilder.ToString());
            Program.commandHandler.Register(new InviteCommand());
            
            
        }
    }
}
