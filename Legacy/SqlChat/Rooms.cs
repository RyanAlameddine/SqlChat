using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlChat
{
    public class Rooms
    {
        SqlConnection connection;

        int ownerID;
        int roomID = -1;
        string roomName;

        public Rooms(SqlConnection connection)
        {
            this.connection = connection;
        }

        public void Createroom(string UserID, string Name)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "usp_Createroom";

            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@Name", Name);

            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
        }

        public void Invite(int id)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "usp_Invite";

            command.Parameters.AddWithValue("@UserID", id);
            command.Parameters.AddWithValue("@RoomID", roomID);

            command.ExecuteNonQuery();
        }

        public DataTable JoinRoom(string UserID, string ChatRoomName)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "usp_JoinRoom";

            command.Parameters.AddWithValue("@ChatRoomName", ChatRoomName);
            command.Parameters.AddWithValue("@UserID", UserID);

            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(table);

            if (table.Rows.Count == 0) { return null; }

            roomName = table.Rows[0][0].ToString();
            roomID = (int)table.Rows[0][1];
            ownerID = (int)table.Rows[0][2];

            return table;
        }

        public DataTable ReadMessages()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = $"SELECT * FROM Messages WHERE RoomID = {roomID}";

            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(table);

            return table;
        }

        public void SendMessage(string input)
        {
            if(roomID == -1)
            {
                ConsoleAdditions.WriteLine(input);
            }
            else
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_SendMessage";

                command.Parameters.AddWithValue("@Message" , input);
                command.Parameters.AddWithValue("@Date"    , DateTime.Now);
                command.Parameters.AddWithValue("@UserID"  , Program.login.userID);
                command.Parameters.AddWithValue("@UserName", Program.login.username);
                command.Parameters.AddWithValue("@RoomID"  , roomID);

                command.ExecuteNonQuery();
            }
        }

        public void GetMessages(int RoomID)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "usp_GetMessages";

            command.Parameters.AddWithValue("@RoomID", RoomID);

            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
        }

    }
}
