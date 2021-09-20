using Music.Extensions;
using Music.Models;
using System;
using System.Collections.Generic;

namespace Website.Models.Song
{
    public class Detail
    {
        public Detail(Music.Models.Song song)
        {
            Song = song ?? throw new ArgumentNullException(nameof(song));
        }

        public Music.Models.Song Song { get; }

        public List<Music.Models.Song> RelatedSongs => Song.GetRelatedSongs();

        public List<Album> Albums => Song.GetAlbums();

        public List<Music.Models.Artist> Artists => Song.GetArtists();

        public List<Video> Videos => Song.GetVideos();
    }
}
