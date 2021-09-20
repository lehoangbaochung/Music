using Microsoft.AspNetCore.Mvc;
using Music.Extensions;
using Music.Models;
using System.Collections.Generic;

namespace Website.Controllers
{
    public class PlaylistController : Controller
    {
        public IActionResult Song(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            List<Song> songs;

            if (id.Split(',').Length > 0)
            {
                songs = DataHelper.GetSongs(id.Split(','));
            }    
            else
            {
                var album = DataProvider.Albums.Find(a => a.Id.Equals(id));
                var artist = DataProvider.Artists.Find(a => a.Id.Equals(id));
                songs = artist.GetSongs() ?? album.GetSongs(); 
            }
            return View(new Models.Playlist.Song(songs));
        }

        public IActionResult Video(string id)
        {
            return View();
        }
    }
}