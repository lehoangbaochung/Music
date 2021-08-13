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
            // Get detail of this artist by id
            var artist = DataProvider.Artists.Find(artist => artist.Id.Equals(id));

            if (artist == null)
            {
                return NotFound();
            }

            var songArtists = DataProvider.SongArtists.Where(
                songArtist => songArtist.ArtistId.Equals(id));

            // Get all songs of this artist
            var songs = DataProvider.Songs.Join(songArtists, 
                song => song.Id, 
                songArtist => songArtist.SongId,
                (song, songArtist) => song);

            // Get all albums of this artist
            var albums = DataProvider.Albums.Join(songs,
                album => album.Id,
                song => song.AlbumId,
                (album, song) => album);

            // Pass data to view
            ViewBag.Artist = artist;
            ViewBag.Songs = songs;
            ViewBag.Albums = albums;

            ViewBag.TopSongs = songs.Take(10);
            ViewBag.TopAlbums = albums.Take(5);

            return View();
        }
    }
}
