using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Music.Extensions;
using Music.Extensions;
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

        public IActionResult Song(string id)
        {
            if (id == null)
            {
                return View("Song/Index");
            }

            var song = DataProvider.Songs.Find(s => s.Id.Equals(id));

            return song == null ? NotFound() :
                    View("Song/Detail", new SongViewModel.Detail(song));
        }

        public IActionResult Artist(string id)
        {
            if (id == null)
            {                
                return View("Artist/Index", DataProvider.Artists);
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
                
                return View("Album/Index", albums);
            }    
            else
            {
                var album = DataProvider.Albums.Find(a => a.Id.Equals(id));

                return album == null ? NotFound() : 
                    View(AlbumViewModel.DETAIL_VIEW_NAME, new AlbumViewModel.Detail(album));
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
