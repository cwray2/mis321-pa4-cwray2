using System;

namespace api.Models
{
    public class Song
    {
        public int SongID { get; set; }
        public string SongTitle{ get; set; }
        public DateTime DateAdded{ get; set; }
        public string Deleted{ get; set; }
        public string Favorited{ get; set; }

        //public ISaveSong Save { get; set; }


        // public Song() {
        //     Save = new SaveSong();
        // }
        
        
        
        
    }
}