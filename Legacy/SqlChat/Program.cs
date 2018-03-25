using SqlChat.Commands;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlChat
{
    class Program
    {
        public static CommandHandler commandHandler;
        public static Login login;
        public static Rooms rooms;
        public static bool running = true;

        public static string[] messages = new string[20];

        static void Main(string[] args)
        {
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
            commandHandler.Register  (new ExitCommand(), new CreateRoomCommand(), new JoinCommand());

            while (running)
            {
                commandHandler.InputCommand();
            }

            connection.Close();
        }
    }
}
