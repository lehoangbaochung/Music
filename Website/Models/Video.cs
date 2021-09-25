using Music.Extensions;
using Music.Models;
using System.Collections.Generic;

namespace Website.Models.Playlist
{
    public class Video
    {
        public Video(Music.Models.Artist artist)
        {
            Songs = artist.GetSongs();
        }

        public string Id => Songs.GetEmbedId();

        public List<Music.Models.Song> Songs { get; }

        public List<Music.Models.Album> Albums => Songs.GetAlbums();

        public List<Music.Models.Artist> Artists => Songs.GetArtists();

        public List<Music.Models.Video> Videos => Songs.GetVideos();
    }
}
