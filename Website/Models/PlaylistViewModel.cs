using Music.Extensions;
using Music.Models;
using System.Collections.Generic;

namespace Website.Models
{
    public class PlaylistViewModel
    {
        public class Song
        {
            private readonly List<Music.Models.Song> songs;

            public Song(List<Music.Models.Song> songs)
            {
                this.songs = songs;
            }

            public string Id => songs.GetEmbedId();

            public List<Music.Models.Song> Songs => songs;

            public List<Album> Albums => songs.GetAlbums();

            public List<Artist> Artists => songs.GetArtists();

            public List<Video> Videos => songs.GetVideos();
        }

        public class Detail
        {
            private readonly List<Music.Models.Song> songs;

            public Detail(List<Music.Models.Song> songs)
            {
                this.songs = songs;
            }

            public string Id => songs.GetEmbedId();

            public List<Music.Models.Song> Songs => songs;

            public List<Album> Albums => songs.GetAlbums();

            public List<Artist> Artists => songs.GetArtists();

            public List<Video> Videos => songs.GetVideos();
        }
    }
}