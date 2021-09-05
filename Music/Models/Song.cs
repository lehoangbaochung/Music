using Music.Interfaces;
using Music.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Music.Models
{
    public class Song : Base, ILyric
    {
        private readonly List<Album> albums = new();
        private readonly List<Artist> artists = new();
        private readonly List<Video> videos = new();

        public string VietnameseLyric { get; set; }

        public string PinyinLyric { get; set; }

        public string SimplifiedChineseLyric { get; set; }

        public string TraditionalChineseLyric { get; set; }

        public string ArtistId { get; set; }

        public string DownloadId { get; set; }

        public List<Album> GetAlbums()
        {
            if (albums.Count == 0)
            {
                foreach (var album in DataProvider.Albums)
                {
                    if (album.SongId.Contains(Id))
                    {
                        albums.Add(album);
                    }    
                }    
            }
            return albums;
        }

        public List<Artist> GetArtists()
        {
            if (artists.Count == 0)
            {
                foreach (var artist in DataProvider.Artists)
                {
                    if (ArtistId.Contains(artist.Id))
                    {
                        artists.Add(artist);
                    }    
                }    
            }    
            return artists;
        }

        public List<Video> GetVideos()
        {
            if (videos.Count == 0)
            {
                foreach (var video in DataProvider.Videos)
                {
                    if (video.SongId.Equals(Id))
                    {
                        videos.Add(video);
                    }    
                }
            }
            return videos;
        }
    } 
}
