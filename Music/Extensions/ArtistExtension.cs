using Music.Models;
using Music.Extensions;
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

        public static List<Artist> GetRelatedArtists(this Artist artist)
        {
            List<Artist> artists = new();

            var artistIds = artist.GetSongs().GroupBy(s => s.ArtistId)
                .Select(group => new { ArtistId = group.Key, Count = group.Count() })
                .OrderByDescending(x => x.Count).ToList();

            artistIds.ForEach(a => artists.InsertRange(0, artist.GetSongs()
                .Find(s => s.ArtistId.Equals(a.ArtistId)).GetArtists()));

            artists.RemoveAll(a => a.Id.Equals(artist.Id));

            return artists;
        }
    }
}
