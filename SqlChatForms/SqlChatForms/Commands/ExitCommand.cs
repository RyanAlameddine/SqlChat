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
            description = "Leave Ch@room or exit program.\nUsage: .exit";
        }

        public override void Execute(string[] arguments)
        {
            base.Execute(arguments);

            if (Program.rooms.roomID == -1)
            {
                Program.running = false;
            }
            else
            {
                Program.rooms.roomID = -1;
                Program.chatViewer.Invoke(new Action(() => { Program.chatViewer.label.Text = ""; }));
            }
        }
    }
}
