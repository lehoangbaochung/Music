using Microsoft.AspNetCore.Mvc;
using Music.Extensions;
using Website.Models;

namespace Website.Controllers
{
    public class PlaylistController : Controller
    {
        public IActionResult Song(string id)
        {
            return id == null ? NotFound() : 
                View(new PlaylistViewModel.Audio(id.Split(',')));
        }

        public IActionResult Album(string id)
        {
            var album = DataProvider.Albums
                .Find(a => a.Id.Equals(id));
            return album == null ? NotFound() : 
                View(new PlaylistViewModel.Audio(album));
        }

        public IActionResult Artist(string id)
        {
            var artist = DataProvider.Artists
                .Find(a => a.Id.Equals(id));
            return artist == null ? NotFound() : 
                View(new PlaylistViewModel.Audio(artist));
        }

        public IActionResult Video(string id)
        {
            return View();
        }
    }
}