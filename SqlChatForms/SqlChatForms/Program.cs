using SqlChatForms;
using SqlChatForms.Commands;
using System;
using System.Collections.Generic;
using System.Data;
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

        private static SqlConnection connection;

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
                //chatViewer.Invoke(new Action(() => { chatViewer.Width = 500; }));
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                connection = new SqlConnection("Server=GMRMLTV;Database=RyanAChatroomDB;User Id=sa;Password=GreatMinds110;");
                connection.Open();

                login = new Login();
                rooms = new Rooms();
                commandHandler = new CommandHandler();

                ConsoleAdditions.WriteLine("Welcome to the §aCh@room§7.\nPlease login or register");
                while (!login.Success)
                {
                    commandHandler.InputCommand();
                }

                commandHandler.Deregister(".login", ".register");
                commandHandler.Register(new ExitCommand(), new CreateRoomCommand(), new JoinCommand(), new ListRoomsCommand());

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

        public static DataTable ExecuteUSP(string USPName, params (string, object)[] parameters)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = USPName;

            foreach ((string, object) param in parameters)
            {
                command.Parameters.AddWithValue(param.Item1, param.Item2);
            }

            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(table);

            return table;
        }
    }
}
