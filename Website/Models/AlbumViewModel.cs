using Music.Extensions;
using Music.Models;
using System.Collections.Generic;

namespace Website.Models
{
    public static class AlbumViewModel 
    {
        public const string INDEX_VIEW_NAME = "Album/Index";
        public const string DETAIL_VIEW_NAME = "Album/Detail";

        public class Detail
        {
            public Detail(Album album)
            {
                Album = album;
            }

            public Album Album { get; set; }

            public List<Album> RelatedAlbums => Album.GetRelatedAlbums();

            public List<Song> Songs => Album.GetSongs();

            public List<Artist> Artists => Album.GetArtists();

            public List<Video> Videos => Album.GetVideos();
        }
    }
}
