using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Music.Extensions;
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
                     
                    var model = artist.GetProfile();
                    ViewBag.Artist = artist;
                    ViewBag.Songs = artist.GetSongs();
                    ViewBag.Albums = artist.GetAlbums();
                    ViewBag.Videos = artist.GetVideos();
                    //this.ReturnView(viewModel, category);
                    switch (category)
                    {
                        case "Song":
                            {
                                return View("Artist/Song", model);
                            }
                        case"Album":
                            {
                                return View("Artist/Album", model);
                            }
                        case "Video":
                            {
                                return View("Artist/Video", model);
                            }
                        default:
                            {
                                ViewBag.RecentSongs = artist.GetSongs()
                                    .OrderByDescending(song => song.Id).Take(10).ToList();
                                ViewBag.RecentAlbums = artist.GetAlbums()
                                    .OrderByDescending(album => album.SongIds).Take(3).ToList();
                                ViewBag.RecentVideos = artist.GetVideos()
                                    .OrderByDescending(video => video.SongId).Take(3).ToList();
                                ViewBag.RelatedArtist = DataProvider.Artists[
                                    new Random().Next(0, DataProvider.Artists.Count)];

                                return View("Artist/Detail", model);
                            }
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
