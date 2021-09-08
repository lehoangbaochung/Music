﻿using Music.Extensions;
using Music.Models;
using System.Collections.Generic;

namespace Website.Models
{
    public static class AlbumViewModel 
    {
        public const string DETAIL_VIEW_NAME = "Album/Detail";

        public class Detail
        {
            public Detail(Album album)
            {
                Album = album;
            }

            public Album Album { get; set; }

            public Album SecondaryAlbum => Music.Utilities.DataProvider.Albums.GetRandomItem();

            public List<Song> Songs => Album.GetSongs();

            public List<Artist> Artists => Album.GetArtists();

            public List<Video> Videos => Album.GetVideos();
        }
    }
}