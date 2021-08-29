﻿using Music.Models;
using Music.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace Music.Extensions
{
    public static class AlbumExtension
    {
        public static List<Song> GetSongs(this Album album, int count = 10)
        {
            return album.GetSongs()
                .OrderByDescending(song => song.Id)
                .Take(count).ToList();
        }

        public static List<Artist> GetArtists(this Album album, int count = 4)
        {
            return album.GetArtists()
                .OrderByDescending(song => song.Id)
                .Take(count).ToList();
        }

        public static List<Video> GetVideos(this Album album, int count = 6)
        {
            return album.GetVideos()
                .OrderByDescending(video => video.Id)
                .Take(count).ToList();
        }

        public static Album GetRelatedAlbum(this Album album)
        {
            return DataProvider.Albums.GetRandomItem();
        }
    }
}
