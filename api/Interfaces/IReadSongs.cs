using System.Collections.Generic;
using api.Models;

namespace api.Interfaces
{
    public interface IReadSongs
    {
         public List<Song> GetAll();
         public Song GetOne(int id);
    }
}