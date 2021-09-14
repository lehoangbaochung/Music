using Microsoft.AspNetCore.Mvc;
using Music.Extensions;
using Website.Models;

namespace Website.Controllers
{
    public class DownloadController : Controller
    {
        public IActionResult Song(string id)
        {
            var song = DataProvider.Songs.Find(s => s.Id.Equals(id));
            return song == null ? NotFound() : View(song);
        }
    }
}