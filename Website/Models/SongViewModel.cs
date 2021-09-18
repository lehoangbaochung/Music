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
                => DataProvider.Songs.OrderBy(s => random.Next()).Take(15).ToList();
        }

        public class Detail
        {
            private readonly Song song;

            public Detail(Song song)
            {
                this.song = song;
            }

            public Song Song => song;

            public List<Song> RelatedSongs => song.GetRelatedSongs();

            public List<Album> Albums => song.GetAlbums();

            public List<Artist> Artists => song.GetArtists();

            public List<Video> Videos => song.GetVideos();
        }
    }
}
