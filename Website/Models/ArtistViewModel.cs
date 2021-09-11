using Music.Enumerables;
using Music.Extensions;
using Music.Models;
using System.Collections.Generic;
using System.Linq;

namespace Website.Models
{
    public static class ArtistViewModel 
    {
        public static string GetBorderColor(this Artist artist)
        {
            return artist.CategoryId.Equals(Category.Gender.Male) ? "blue" : "pink";
        }

        public class Detail
        {
            public Detail(Artist artist)
            {
                Artist = artist;
            }

            public Artist Artist { get; set; }

            public List<Artist> RelatedArtists 
                => DataProvider.Artists.Take(5).ToList();

            public List<Song> Songs => Artist.GetSongs();

            public List<Album> Albums => Artist.GetAlbums();

            public List<Video> Videos => Artist.GetVideos();
        }
    }
}
