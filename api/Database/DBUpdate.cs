using MySql.Data.MySqlClient;
using api.Interfaces;
using api.Models;

namespace api.Database
{
    public class DBUpdate : IUpdateSongs
    {
        public void Update(Song sendSong)
        {
            DBConnection myConnection = new DBConnection();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"UPDATE songs SET Favorited = @Favorited WHERE SongID = @SongID";
            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@Favorited", sendSong.Favorited);
            cmd.Parameters.AddWithValue("@SongID", sendSong.SongID);

            cmd.ExecuteNonQuery();

            con.Close();
        }
    }
}