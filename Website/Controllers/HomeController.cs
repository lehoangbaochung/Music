using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Music.Utilities;
using System;
using System.Linq;
using Website.Utilities;

namespace Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;

        public HomeController(ILogger<HomeController> logger)
        {
            this.logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Artist(string id)
        {
            if (id == null)
            {
                var artists = DataProvider.Artists;

                ViewBag.Artists = artists.Take(12);
                ViewBag.NewArtist = artists[0];
                ViewBag.HotArtist = artists[new Random()
                    .Next(0, DataProvider.Artists.Count)];
                
                return View("Artist/Index");
            }

            var artist = DataProvider.Artists.Find(a => a.Id.Equals(id));

            return artist == null ? NotFound() :
                    View(ViewExtension.PROFILE_VIEW_PATH, artist.GetProfile());
        }

        public IActionResult Album(string id)
        {
            if (id == null)
            {
                System.Collections.Generic.List<Music.Models.Album> albums = new();
                for (int i = 0; i < 3; i++)
                {
                    albums.Add(DataProvider.Albums[new Random().Next(0, DataProvider.Albums.Count)]);
                }
                ViewBag.RecentAlbums = albums;
                
                return View("Album/Index");
            }    
            else
            {
                var album = DataProvider.Albums.Find(a => a.Id.Equals(id));
                return album == null ? NotFound() : 
                    View(ViewExtension.PROFILE_VIEW_PATH, album.GetProfile());
            }    
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
