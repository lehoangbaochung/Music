using Microsoft.AspNetCore.Mvc;
using Music.Extensions;
using Website.Models;

namespace Website.Controllers
{
    public class AlbumController : Controller
    {
        public IActionResult Index()
        {
            System.Collections.Generic.List<Music.Models.Album> albums = new();
            for (int i = 0; i < 12; i++)
            {
                albums.Add(DataProvider.Albums.GetRandomItem());
            }
            return View(albums);
        }

        public IActionResult Detail(string id)
        {
            var album = DataProvider.Albums.Find(a => a.Id.Equals(id));
            return album == null ? NotFound() : View(new AlbumViewModel.Detail(album));
        }
    }
}
