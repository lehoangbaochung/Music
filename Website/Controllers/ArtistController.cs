using Microsoft.AspNetCore.Mvc;
using Music.Extensions;
using Website.Models;

namespace Website.Controllers
{
    public class ArtistController : Controller
    {
        public IActionResult Index(string id)
        {
            if (id == null)
            {
                return View("Index", DataProvider.Artists);
            }    

            var artist = DataProvider.Artists.Find(a => a.Id.Equals(id));
            return artist == null ? NotFound() :
                    View("Detail", new ArtistViewModel.Detail(artist));
        }
    }
}