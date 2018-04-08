using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlChatForms.Commands
{
    public class FriendCommand : Command
    {
        public FriendCommand()
            : base()
        {
            label = ".friend";
            description = "Access friend information.\nUsage: .friend add <username>\n       .friend list";
            aliases.Add(".friend");
            aliases.Add(".friend add");
            aliases.Add(".friend list");
        }

        public override void Execute(string[] arguments)
        {
            base.Execute(arguments);
            if (arguments.Count() == 2) {


                if (arguments[0] == "add")
                {
                    int TargetID = Program.login.FindUserID(arguments[1]);

                    if (TargetID == -1)
                    {
                        Fail("Could not find User with the name " + arguments[1]);
                        return;
                    }
                    if (TargetID == int.Parse(Program.login.userID))
                    {
                        Fail("You can't friend yourself!");
                        return;
                    }

                    Program.ExecuteUSP("usp_AddFriend", ("@UserID", Program.login.userID), ("@TargetID", TargetID));
                    Respond("Friend added successfully!");
                }
            }else if(arguments.Count() == 1)
            {
                if (arguments[0] == "list")
                {
                    DataTable dataTable = Program.ExecuteUSP("usp_GetFriends", ("@UserID", Program.login.userID));

                    if(dataTable.Rows.Count == 0)
                    {
                        Console.WriteLine("You have no friends.");
                        return;
                    }

                    StringBuilder builder = new StringBuilder("Friends: ");
                    foreach(DataRow row in dataTable.Rows)
                    {
                        builder.Append(Program.ExecuteUSP("usp_GetUserFromID", ("@UserID", row[0])).Rows[0][0]);
                        builder.Append(", ");
                    }
                    builder.Remove(builder.Length - 2, 2);
                    Console.WriteLine(builder.ToString());
                }
            }
            else
            {
                Fail();
            }
        }
    }
}
