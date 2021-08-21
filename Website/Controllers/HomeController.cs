using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Music.Utilies;
using System;
using System.Diagnostics;
using System.Linq;
using Website.Models;

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

        public IActionResult Artist(string id = null)
        {
            if (id == null)
            {
                var artists = DataProvider.Artists;

                ViewBag.Artists = artists;// DataHelper.Where(artists, id.ToCharArray()[0]);
                ViewBag.NewArtist = artists[0];
                ViewBag.HotArtist = artists[new Random().Next(0, artists.Count)];

                return View("Artist");
            }   
            else
            {
                var artist = DataProvider.Artists
                .Find(artist => artist.Id.Equals(id));

                if (artist == null)
                {
                    return NotFound();
                }

                ViewBag.Artist = artist;
                ViewBag.Songs = artist.Songs;
                ViewBag.Albums = artist.Albums;
                ViewBag.Videos = artist.Videos;

                ViewBag.RecentSongs = artist.Songs.OrderByDescending(song => song.Id).Take(10);
                ViewBag.RecentAlbums = artist.Albums.OrderByDescending(album => album.SongId).Take(3);
                ViewBag.RecentVideos = artist.Videos.OrderByDescending(video => video.SongId).Take(3);

                ViewBag.RelatedArtist = DataProvider.Artists[new Random().Next(0, DataProvider.Artists.Count)];

                return View("ArtistDetail");
            }    
        }

        public IActionResult Album()
        {
            System.Collections.Generic.List<Music.Models.Album> albums = new();
            for (int i = 0; i < 3; i++)
            {
                albums.Add(DataProvider.Albums[new System.Random().Next(0, DataProvider.Albums.Count)]);
            }
            ViewBag.RecentAlbums = albums;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
