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
    }
}
