using Microsoft.AspNetCore.Mvc;
using Music.Extensions;
using Website.Models;

namespace Website.Controllers
{
    public class ArtistController : Controller
    {
        public IActionResult Index()
        {
            return View(DataProvider.Artists);
        }

        public IActionResult Detail(string id)
        {
            var artist = DataProvider.Artists.Find(a => a.Id.Equals(id));
            return artist == null ? NotFound() : View(new ArtistViewModel.Detail(artist));
        }
    }
}