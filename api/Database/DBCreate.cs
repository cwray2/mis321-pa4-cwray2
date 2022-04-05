using MySql.Data.MySqlClient;
using api.Interfaces;
using api.Models;

namespace api.Database
{
    public class DBCreate : ICreateSongs
    {
        public void DropTable(){
            DBConnection myConnection = new DBConnection();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"DROP TABLE IF EXISTS songs";

            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        public void CreateSongTable(){
            DBConnection myConnection = new DBConnection();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"CREATE TABLE songs
            (SongID int PRIMARY KEY AUTO_INCREMENT, 
            SongTitle text, 
            DateAdded datetime, 
            Deleted text
            Favorited text)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();

            con.Close();
        }

        public void Create(Song song)
        {
            DBConnection myConnection = new DBConnection();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO songs
            (SongTitle,
            DateAdded,
            Deleted,
            Favorited) VALUES(@SongTitle, 
                              @DateAdded, 
                              @Deleted, 
                              @Favorited)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@SongTitle", song.SongTitle);
            cmd.Parameters.AddWithValue("@DateAdded", song.DateAdded);
            cmd.Parameters.AddWithValue("@Deleted", song.Deleted);
            cmd.Parameters.AddWithValue("@Favorited", song.Favorited);

            //cmd.Prepare();

            cmd.ExecuteNonQuery();

            con.Close();
        }
    }
}