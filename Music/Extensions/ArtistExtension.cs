using Music.Models;
using System.Collections.Generic;
using System.Linq;

namespace Music.Extensions
{
    public static class ArtistExtension 
    {
        public static List<Song> GetRecentSongs(this Artist artist, int count)
        {
            return artist.GetSongs()
                .OrderByDescending(song => song.Id)
                .Take(count).ToList();
        }

        public static List<Album> GetRecentAlbums(this Artist artist, int count)
        {
            return artist.GetAlbums()
                .OrderByDescending(album => album.Id)
                .Take(count).ToList();
        }
    }
}
