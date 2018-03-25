using SqlChatForms;
using SqlChatForms.Commands;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlChatForms
{
    static class Program
    {
        public static CommandHandler commandHandler;
        public static Login login;
        public static Rooms rooms;
        public static bool running = true;
        public static ChatViewer chatViewer;

        public static string[] messages = new string[20];

        [STAThread]
        static async Task Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            chatViewer = new ChatViewer();

            Task formTask = new Task(() => Application.Run(chatViewer));
            Task consoleTask = new Task(() =>
            {
                chatViewer.Invoke(new Action(() => { chatViewer.Width = 500; }));
                Console.WriteLine("Test");
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                SqlConnection connection = new SqlConnection("Server=GMRMLTV;Database=RyanAChatroomDB;User Id=sa;Password=GreatMinds110;");
                connection.Open();

                login = new Login(connection);
                rooms = new Rooms(connection);
                commandHandler = new CommandHandler();

                ConsoleAdditions.WriteLine("Welcome to the §aCh@room§7.\nPlease login or register");
                while (!login.Success)
                {
                    commandHandler.InputCommand();
                }

                commandHandler.Deregister("login", "register");
                commandHandler.Register(new ExitCommand(), new CreateRoomCommand(), new JoinCommand());

                while (running)
                {
                    commandHandler.InputCommand();
                }

                connection.Close();
            });
            formTask.Start();
            consoleTask.Start();
            Task.WaitAny(formTask, consoleTask);
        }
    }
}
