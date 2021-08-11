using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Website.Controllers
{
    public class ArtistController : Controller
    {
        public IActionResult Index(char? character = null)
        {
            var artists = Music.Utilies.DataProvider.Artists.OrderBy(a => a.VietnameseName);
            return View(artists.ToList());
        }
    }
}
