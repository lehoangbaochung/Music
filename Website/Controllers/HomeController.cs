using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Music.Extensions;
using Music.Utilities;
using System;
using System.Linq;
using Website.Models;
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
                    View("Artist/Detail", new ArtistViewModel.Detail(artist));
        }

        public IActionResult Album(string id)
        {
            if (id == null)
            {
                System.Collections.Generic.List<Music.Models.Album> albums = new();
                for (int i = 0; i < 9; i++)
                {
                    albums.Add(DataProvider.Albums.GetRandomItem());
                }
                
                return View(albums);
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

        public IActionResult Download(string id)
        {
            var song = DataProvider.Songs
                .Find(s => s.Id.Equals(id));

            return song == null ? NotFound() : View(song);
        }

        public IActionResult Search(string id)
        {
            var artist = DataProvider.Artists
                .Find(a => a.VietnameseName.Equals(id));

            var song = DataProvider.Songs
                .Find(s => s.Id.Equals(id));

            return song == null ? NotFound() : View(song);
        }
    }
}
