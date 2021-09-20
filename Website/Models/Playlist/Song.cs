using Music.Extensions;
using Music.Models;
using System.Collections.Generic;

namespace Website.Models.Playlist
{
    public class Song
    {
        public Song(List<Music.Models.Song> songs)
        {
            Songs = songs;
        }

        public string Id => Songs.GetEmbedId();

        public List<Music.Models.Song> Songs { get; }

        public List<Album> Albums => Songs.GetAlbums();

        public List<Artist> Artists => Songs.GetArtists();

        public List<Video> Videos => Songs.GetVideos();
    }
}
