using Music.Extensions;
using Music.Models;
using System.Collections.Generic;

namespace Website.Models
{
    public class SongViewModel 
    {
        public class Detail
        {
            public Detail(Song song)
            {
                Song = song;
            }

            public Song Song { get; set; }

            public Song SecondarySong => Music.Utilities.DataProvider.Songs.GetRandomItem();

            public List<Album> Albums => Song.GetAlbums();

            public List<Artist> Artists => Song.GetArtists();

            public List<Video> Videos => Song.GetVideos();
        }
    }
}
