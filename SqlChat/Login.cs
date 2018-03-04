using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlChat
{
    public class Login
    {
        string username;
        public string userID;
        public bool Success;
        SqlConnection connection;

        public Login(SqlConnection connection)
        {
            this.connection = connection;
        }

        public void AttemptLogin(string username, string password)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "usp_Login";

            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Password", password);

            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(table);

            Console.Clear();

            if (table.Rows.Count == 0)
            {
                if (!usernameExists(username))
                {
                    Console.WriteLine("Username does not exist. Please try again");
                    return;
                }
                else
                {
                    Console.WriteLine("Incorrect password. Please try again");
                    return;
                }
            }
            else
            {
                Console.Write("Welcome ");
                ConsoleAdditions.ColoredWrite(ConsoleColor.Green, username);
                Console.WriteLine(".");
                Success = true;
            }

            userID = table.Rows[0]["UserID"].ToString();
            this.username = username;
        }

        bool usernameExists(string username)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "usp_GetUser";

            command.Parameters.AddWithValue("@Username", username);

            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(table);

            return table.Rows.Count > 0;
        }

        public void createUser(string username, string password)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "usp_CreateUser";

            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Password", password);

            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(table);

            userID = table.Rows[0]["UserID"].ToString();
            this.username = username;
            Success = true;
        }
    }
}
