using Microsoft.AspNetCore.Mvc;
using Music.Extensions;
using Website.Models;

namespace Website.Controllers
{
    public class SongController : Controller
    {
        public IActionResult Index(string id)
        {
            if (id == null)
            {
                return View();
            }    

            var song = DataProvider.Songs.Find(s => s.Id.Equals(id));
            return song == null ? NotFound() :
                    View("Detail", new SongViewModel.Detail(song));
        }
    }
}