using Microsoft.AspNetCore.Mvc;
using Website.Models;

namespace Website.Controllers
{
    public class PlaylistController : Controller
    {
        public IActionResult Song(string id, bool shuffle = false)
        {
            var audio = new PlaylistViewModel.Song(id, shuffle);
            return audio.Songs.Count == 0 ? NotFound() : View(audio);
        }
    }
}