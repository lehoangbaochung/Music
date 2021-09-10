using Music.Enumerables;
using Music.Models;
using System.Collections.Generic;

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
                PrimaryArtist = artist;
            }

            public Artist PrimaryArtist { get; set; }

            public Artist SecondaryArtist => PrimaryArtist.GetRelatedArtist();

            public List<Song> Songs => PrimaryArtist.GetSongs();

            public List<Album> Albums => PrimaryArtist.GetAlbums();

            public List<Video> Videos => PrimaryArtist.GetVideos();
        }
    }
}
