using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlChatForms
{
    public class Rooms
    {
        int ownerID;
        public int roomID = -1;
        string roomName;

        public void Createroom(string UserID, string Name)
        {
            DataTable table = Program.ExecuteUSP("usp_Createroom", ("@UserID", UserID), ("@Name", Name));

            Invite(int.Parse(UserID), int.Parse(table.Rows[0][0].ToString()));
        }

        public void Invite(int id)
        {
            Program.ExecuteUSP("usp_Invite", ("@UserID", id), ("@RoomID", roomID));
        }

        public void Invite(int UserId, int roomID)
        {
            DataTable table = Program.ExecuteUSP("usp_Invite", ("@UserID", UserId), ("@RoomID", roomID));
        }

        public DataTable JoinRoom(string UserID, string ChatRoomName)
        {

            DataTable table = Program.ExecuteUSP("usp_JoinRoom", ("@ChatRoomName", ChatRoomName), ("@UserID", UserID));

            if (table.Rows.Count == 0) { return null; }

            roomName = table.Rows[0][0].ToString();
            roomID = (int)table.Rows[0][1];
            ownerID = (int)table.Rows[0][2];

            return table;
        }

        public DataRow[] ReadMessages()
        {
            DataTable table = Program.ExecuteUSP("usp_GetMessages", ("@RoomID", roomID));

            DataRow[] newTable = new DataRow[table.Rows.Count];
            for(int i = 0; i < newTable.Length; i++)
            {
                newTable[i] = table.Rows[newTable.Length - i - 1];
            }

            return newTable;
        }

        public void SendMessage(string input)
        {
            if(roomID == -1)
            {
                ConsoleAdditions.WriteLine(input);
            }
            else
            {
                Program.ExecuteUSP("usp_SendMessage", ("@Message", input), ("@Date", DateTime.Now), ("@UserID", Program.login.userID), ("@UserName", Program.login.username), ("@RoomID", roomID));

                Console.Clear();

                DataRow[] messages = Program.rooms.ReadMessages();

                StringBuilder stringBuilder = new StringBuilder();
                foreach (DataRow row in messages)
                {
                    stringBuilder.Append(row[1]);
                    stringBuilder.Append(": ");
                    stringBuilder.AppendLine(row[0].ToString());
                }
                Program.chatViewer.Invoke(new Action(() => { Program.chatViewer.label.Text = stringBuilder.ToString(); }));
            }
        }

        public DataTable GetRooms()
        {
            DataTable table = Program.ExecuteUSP("usp_GetRooms", ("@USerID", Program.login.userID));

            return table;
        }
    }
}
