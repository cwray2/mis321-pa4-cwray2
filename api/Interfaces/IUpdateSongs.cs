using api.Models;

namespace api.Interfaces
{
    public interface IUpdateSongs
    {
         public void Update(int id, Song sendSong);
    }
}