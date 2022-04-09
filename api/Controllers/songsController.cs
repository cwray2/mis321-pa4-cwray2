using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Database;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class songsController : ControllerBase
    {
        // GET: api/songs
        [EnableCors("OpenPolicy")]
        [HttpGet]
        public List<Song> Get()
        {
            // List<Song> mySongs = new List<Song>();
            // mySongs.Add(new Song(){SongTitle = "Mistborn"});
            // mySongs.Add(new Song(){SongTitle = "Mistborn 2 Electric Boogaloo"});
            DBRead readObject = new DBRead();
            //List<Song> mySongs = readObject.GetAll();
            return readObject.GetAll();
        }

        // GET: api/songs/5
        [EnableCors("OpenPolicy")]
        [HttpGet("{id}", Name = "Get")]
        public Song Get(int id)
        {
            DBRead readObject = new DBRead();
            return readObject.GetOne(id);
        }

        // POST: api/songs
        [EnableCors("OpenPolicy")]
        [HttpPost]
        public void Post([FromBody] Song value)
        {
            Song test = new Song(){SongTitle = value.SongTitle, 
                                   DateAdded = DateTime.Now, 
                                   Deleted = "n", 
                                   Favorited = "n"};

            DBCreate creationObject = new DBCreate();
            creationObject.Create(test);
        }

        // PUT: api/songs/5
        [EnableCors("OpenPolicy")]
        [HttpPut("{id}")]
        public void Put(int id)
        {
            //DBRead readObject = new DBRead();
            DBRead readObject = new DBRead();
            Song song = readObject.GetOne(id);
            if(song.Favorited == "y")
            {
                song.Favorited = "n";
            }
            else
            {
                song.Favorited = "y";
            }

            DBUpdate updateObject = new DBUpdate();

            //Song song = readObject.GetOne(id);

            updateObject.Update(song);
        }

        // DELETE: api/songs/5
        [EnableCors("OpenPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            DBDelete deleteObject = new DBDelete();
            deleteObject.Delete(id);
        }
    }
}
