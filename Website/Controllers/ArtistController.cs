using Microsoft.AspNetCore.Mvc;
using Music.Utilies;
using System;
using System.Linq;

namespace Website.Controllers
{
    public class ArtistController : Controller
    {
        public IActionResult Index(char id = '/')
        {
            var artists = DataProvider.Artists;

            ViewBag.Artists = DataHelper.Where(artists, id);  

            ViewBag.NewArtist = artists[0];
            ViewBag.HotArtist = artists[new Random().Next(0, artists.Count)];

            return View();
        }

        public IActionResult Detail(string id, string type = null)
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

            if (type == null)
            {
                return View();
            }
            else
                return View();
        }
    }
}
