using Music.Extensions;
using Music.Models;
using System.Collections.Generic;

namespace Website.Models
{
    public class PlaylistViewModel
    {
        public class Audio
        {
            public Audio(string[] songIds)
            {
                Songs = DataHelper.GetSongs(songIds);
            }

            public Audio(Album album)
            {
                Songs = album.GetSongs();
            }

            public Audio(Artist artist)
            {
                Songs = artist.GetSongs();
            }

            public string Id => Songs.GetEmbedId();

            public List<Song> Songs { get; } = new();

            public List<Album> Albums => Songs.GetAlbums();

            public List<Artist> Artists => Songs.GetArtists();

            public List<Video> Videos => Songs.GetVideos();
        }

        public class Detail
        {
            private readonly List<Song> songs;

            public Detail(List<Song> songs)
            {
                this.songs = songs;
            }

            public string Id => songs.GetEmbedId();

            public List<Song> Songs => songs;

            public List<Album> Albums => songs.GetAlbums();

            public List<Artist> Artists => songs.GetArtists();

            public List<Video> Videos => songs.GetVideos();
        }
    }
}