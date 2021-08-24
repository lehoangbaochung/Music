using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Music.Utilities;
using System;
using System.Diagnostics;
using System.Linq;
using Website.Helpers;
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

        public IActionResult Artist(string id = null, string category = null)
        {
            if (id == null)
            {
                var artists = DataProvider.Artists;

                ViewBag.Artists = artists.Take(12);
                ViewBag.NewArtist = artists[0];
                ViewBag.HotArtist = artists[new Random().Next(0, DataProvider.Artists.Count)];
                
                return View("Artist/Index");
            }   
            else
            {
                if (int.TryParse(id, out int index))
                {
                    var artists = DataProvider.Artists;
                    
                    ViewBag.Artists = artists.Where(index.ToString());
                    ViewBag.NewArtist = artists[0];
                    ViewBag.HotArtist = artists[new Random().Next(0, artists.Count)];
                    return View("Artist/Index");
                }    
                else
                {
                    var artist = DataProvider.Artists
                            .Find(artist => artist.Id.Equals(id));

                    if (artist == null)
                    {
                        return NotFound();
                    }

                    var viewModel = ViewHelper.GetProfile(artist);

                    if (category == null)
                    {                        
                        ViewBag.Artist = artist;
                        ViewBag.Songs = artist.Songs;
                        ViewBag.Albums = artist.Albums;
                        ViewBag.Videos = artist.Videos;

                        ViewBag.RecentSongs = artist.Songs.OrderByDescending(song => song.Id).Take(10).ToList();
                        ViewBag.RecentAlbums = artist.Albums.OrderByDescending(album => album.SongId).Take(3).ToList();
                        ViewBag.RecentVideos = artist.Videos.OrderByDescending(video => video.SongId).Take(3).ToList();

                        ViewBag.RelatedArtist = DataProvider.Artists[new Random().Next(0, DataProvider.Artists.Count)];

                        return View("Artist/Detail", viewModel);
                    }    
                    else 
                    {
                        ViewBag.Songs = artist.Songs;
                        return View("Artist/Song", viewModel);
                    }    
                }    
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
    }
}
