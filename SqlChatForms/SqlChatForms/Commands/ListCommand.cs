using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlChatForms.Commands
{
    public class ListRoomsCommand : Command
    {
        public ListRoomsCommand()
            : base()
        {
            label = ".listrooms";
            description = "List available chatrooms.\nUsage: .list";
            aliases.Add(".lr");
        }

        public override void Execute(string[] arguments)
        {
            base.Execute(arguments);

            DataTable table = Program.rooms.GetRooms();

            StringBuilder builder = new StringBuilder("Available Rooms: ");

            foreach(DataRow row in table.Rows)
            {
                builder.Append(row[0]);
                builder.Append(", ");
            }

            if(table.Rows.Count != 0)
            {
                builder.Remove(builder.Length - 2, 2);
                ConsoleAdditions.WriteLine(builder.ToString());
            }
            else
            {
                Console.WriteLine("You do not have access to any chatrooms! Try creating one with .creatroom.");
            }

        }
    }
}
