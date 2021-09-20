using Music.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Website.Models.Song
{
    public class Index 
    {
        private static readonly Random random = new();

        public List<Music.Models.Song> RecentSongs
                => DataProvider.Songs.Take(15).ToList();

        public List<Music.Models.Song> RecommendSongs
            => DataProvider.Songs.OrderBy(s => random.Next()).Take(15).ToList();
    }
}
