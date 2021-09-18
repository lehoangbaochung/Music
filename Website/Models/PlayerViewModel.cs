using Music.Extensions;
using Music.Models;
using System.Collections.Generic;

namespace Website.Models
{
    public class PlayerViewModel
    {
        public class Song
        {
            private readonly List<Music.Models.Song> songs;

            public Song(List<Music.Models.Song> songs)
            {
                this.songs = songs;
            }

            public string Id 
                => songs.Count == 0 ? null : 
                $"{songs[0].Id}?playlist={songs.GetSongIds()}";

            public List<Music.Models.Song> Songs => songs;

            public List<Album> Albums => songs.GetAlbums();

            public List<Artist> Artists => songs.GetArtists();

            public List<Video> Videos => songs.GetVideos();
        }
    }
}