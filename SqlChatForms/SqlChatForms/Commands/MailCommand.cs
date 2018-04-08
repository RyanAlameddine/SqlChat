using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlChatForms.Commands
{
    public class MailCommand : Command
    {
        public MailCommand()
            : base()
        {
            label = ".mail";
            description = "Send or Recieve mail.\nUsage: .mail send <username> <message>...\n       .mail read";
        }

        public override void Execute(string[] arguments)
        {
            base.Execute(arguments);
            if (arguments.Count() >= 3) {
                if (arguments[0] == "send")
                {
                    int recieverID = Program.login.FindUserID(arguments[1]);

                    if(recieverID == -1)
                    {
                        Fail("User not found.");
                        return;
                    }

                    StringBuilder builder = new StringBuilder(Program.login.username);
                    builder.Append(": ");
                    for(int i = 2; i < arguments.Length; i++)
                    {
                        builder.Append(arguments[i]);
                        builder.Append(' ');
                    }

                    Program.ExecuteUSP("usp_sendMail", ("@SenderID", Program.login.userID), ("@RecieverID", recieverID), ("@Message", builder.ToString()), ("@MessageRead", false), ("@Date", DateTime.Now));
                }
            }
            else
            {
                Fail();
            }
        }
    }
}
