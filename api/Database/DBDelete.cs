using MySql.Data.MySqlClient;
using api.Interfaces;
using api.Models;

namespace api.Database
{
    public class DBDelete : IDeleteSongs
    {
        public void Delete(int id)
        {
            DBConnection myConnection = new DBConnection();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"UPDATE songs SET Deleted = true WHERE SongID = @id";
            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            con.Close();
        }
    }
}