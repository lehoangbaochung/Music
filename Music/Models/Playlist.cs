using Music.Extensions;
using System;
using System.Collections.Generic;

namespace Music.Models
{
    public class Playlist
    {
        private static readonly List<Song> songs = new();
        private static readonly List<Video> videos = new();

        public static List<Song> Songs => songs;
        public static List<Video> Videos => videos;

        public Playlist(string id)
        {
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
        }
    }
}
