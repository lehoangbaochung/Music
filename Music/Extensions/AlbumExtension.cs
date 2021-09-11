using Music.Models;
using Music.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Music.Extensions
{
    public static class AlbumExtension
    {
        public static List<Song> GetSongs(this Album album, int count = 10)
        {
            return album.GetSongs()
                .OrderByDescending(song => song.Id)
                .Take(count).ToList();
        }

        public static List<Artist> GetArtists(this Album album, int count = 4)
        {
            return album.GetArtists()
                .OrderByDescending(song => song.Id)
                .Take(count).ToList();
        }

        public static List<Album> GetRelatedAlbums(this Album album)
        {
            List<Album> albums = new();
            foreach (var artist in album.GetArtists())
            {
                albums.AddRange(artist.GetAlbums());
            }
            return albums;
        }
    }
}
