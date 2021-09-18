using Microsoft.AspNetCore.Mvc;
using Music.Extensions;
using Music.Models;
using System;
using System.Collections.Generic;
using Website.Models;

namespace Website.Controllers
{
    public class PlayerController : Controller
    {
        public IActionResult Song(string id)
        {
            List<Song> songs = new();
            foreach (var songId in id.Split(','))
            {
                var song = DataProvider.Songs
                    .Find(s => s.Id.Equals(songId));
                if (song == null)
                {
                    throw new NullReferenceException(
                        "Not found the song with id " + songId);
                }
                songs.Add(song);
            }
            return View(new PlayerViewModel.Song(songs));
        }
    }
}