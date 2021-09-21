using Music.Extensions;
using System.Collections.Generic;

namespace Website.Models.Playlist
{
    public class Audio
    {
        public Audio(List<Music.Models.Song> songs)
        {
            Songs = songs;
        }

        public Audio(Music.Models.Album album)
        {
            Songs = album.GetSongs();
        }

        public Audio(Music.Models.Artist artist)
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
