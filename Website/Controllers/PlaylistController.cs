using Microsoft.AspNetCore.Mvc;
using Website.Models;

namespace Website.Controllers
{
    public class PlaylistController : Controller
    {
        public IActionResult Audio(string id, bool shuffle = false)
        {
            var audio = new PlaylistViewModel.Audio(id, shuffle);
            return audio.Songs.Count == 0 ? NotFound() : View(audio);
        }
    }
}