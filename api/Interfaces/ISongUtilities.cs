using System.Collections.Generic;
using api.Models;

namespace api.Interfaces
{
    public interface ISongUtilities
    {
         public List<Song> playlist { get; set; }
         public void AddSong();
         public void DeleteSong();
         public void EditSong();
         public void PrintPlaylist();
    }
}