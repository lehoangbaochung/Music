using Music.Extensions;
using Music.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Website.Models
{
    public class SongViewModel 
    {
        private readonly static Random random = new();

        public class Index
        {
            public List<Song> RecentSongs 
                => DataProvider.Songs.Take(15).ToList();

            public List<Song> RecommendSongs
                => DataProvider.Songs.OrderBy(s => random.Next()).ToList();
        }

        public class Detail
        {
            public Detail(Song song)
            {
                Song = song;
            }

            public Song Song { get; set; }

            public List<Song> RelatedSongs => Song.GetRelatedSongs();

            public List<Album> Albums => Song.GetAlbums();

            public List<Artist> Artists => Song.GetArtists();

            public List<Video> Videos => Song.GetVideos();
        }
    }
}
