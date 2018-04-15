using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlChatForms
{
    public class Login
    {
        public string username;
        public string userID;
        public bool Success;

        public DataRowCollection mail;

        public void AttemptLogin(string username, string password)
        {
            DataTable table = Program.ExecuteUSP("usp_Login", ("@Username", username), ("@Password", password));

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
                ConsoleAdditions.WriteLine($"Welcome §a{username}§7.");
                Success = true;
            }

            userID = table.Rows[0]["UserID"].ToString();
            this.username = username;
            Program.ExecuteUSP("usp_SetOnline", ("@UserID", userID), ("@Online", true));

            LoadMail();
            if(mail.Count == 0)
            {
                Console.WriteLine("You have no new mail");
            }
            else
            {
                ConsoleAdditions.WriteLine($"You have §d{mail.Count} §7new mail!\nEnter '.mail read' to view these messages.");
            }
        }

        bool usernameExists(string username)
        {
            DataTable table = Program.ExecuteUSP("usp_GetUser", ("@Username", username));

            return table.Rows.Count > 0;
        }

        public void createUser(string username, string password)
        {
            DataTable table = Program.ExecuteUSP("usp_CreateUser", ("@Username", username), ("@Password", password));

            userID = table.Rows[0]["UserID"].ToString();
            this.username = username;
            Success = true;
        }

        public int FindUserID(string input)
        {
            DataTable table = Program.ExecuteUSP("usp_GetUser", ("@Username", input));

            return table.Rows.Count > 0 ? (int)table.Rows[0][0] : -1;
        }

        public void LoadMail()
        {
            DataTable table = Program.ExecuteUSP("usp_GetMail", ("@UserID", userID));

            mail = table.Rows;
        }
    }
}
