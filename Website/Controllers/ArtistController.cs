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

            ViewBag.Artists = ArtistHelper.Where(artists, id);  

            ViewBag.NewArtist = artists[0];
            ViewBag.HotArtist = artists[new Random().Next(0, artists.Count)];

            return View();
        }

        public IActionResult Detail(string id)
        {
            ViewBag.Artist = DataProvider.Artists
                .Find(artist => artist.Id.Equals(id));

            if (ViewBag.Artist == null)
            {
                return NotFound();
            }

            //var songs = DataProvider.Songs.Join(songs, 
            //    song => song.Id, 
            //    songArtist => songArtist.SongId,
            //    (song, songArtist) => song).ToList();

            //var albums = DataProvider.Albums.Join(albums,
            //    album => album.Id,
            //    albumArtist => albumArtist.AlbumId,
            //    (album, albumArtist) => album).ToList();

            //// Pass data to view
            //ViewBag.Songs = songs;
            //ViewBag.Albums = albums;
            //ViewBag.TopSongs = songs.OrderByDescending(song => song.Id).Take(10);
            //ViewBag.TopAlbums = albums.OrderBy(album => album.Id).Take(6);

            return View();
        }
    }
}
