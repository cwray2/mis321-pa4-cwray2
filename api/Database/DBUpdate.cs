using MySql.Data.MySqlClient;
using api.Interfaces;
using api.Models;

namespace api.Database
{
    public class DBUpdate : IUpdateSongs
    {
        public void Update(int id, Song sendSong)
        {
            DBConnection myConnection = new DBConnection();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"UPDATE songs SET SongTitle = @SongTitle WHERE SongID = @SongID";
            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@SongTitle", sendSong.SongTitle);
            cmd.Parameters.AddWithValue("@SongID", sendSong.SongID);

            cmd.ExecuteNonQuery();

            con.Close();
        }
    }
}