using MySql.Data.MySqlClient;
using api.Interfaces;
using api.Models;
using System.Collections.Generic;

namespace api.Database
{
    public class DBRead : IReadSongs
    {
        public List<Song> GetAll()
        {
            DBConnection myConnection = new DBConnection();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"SELECT * FROM songs  WHERE songTitle IS NOT NULL AND Deleted = 'n' ORDER BY -DateAdded";
            using var cmd = new MySqlCommand(stm, con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            List<Song> songs = new List<Song>();
            while (rdr.Read())
            {
                songs.Add(new Song(){
                    SongID = rdr.GetInt32(0),
                    SongTitle = rdr.GetString(1),
                    DateAdded = rdr.GetDateTime(2),
                    Deleted = rdr.GetString(3),
                    Favorited = rdr.GetString(4)});
            }

            con.Close();

            return songs;

            //throw new System.NotImplementedException();
        }

        public Song GetOne(int id)
        {
            DBConnection myConnection = new DBConnection();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"SELECT * FROM songs WHERE SongID =" + id;
            using var cmd = new MySqlCommand(stm, con);

            MySqlDataReader rdr = cmd.ExecuteReader();

            List<Song> songs = new List<Song>();
            while (rdr.Read())
            {
                songs.Add(new Song(){
                    SongID = rdr.GetInt32(0),
                    SongTitle = rdr.GetString(1),
                    DateAdded = rdr.GetDateTime(2),
                    Deleted = rdr.GetString(3),
                    Favorited = rdr.GetString(4)});
            }

            con.Close();

            return songs.Find(x => x.SongID == id);  //your arrow function is mine!!!!
        }
    }
}