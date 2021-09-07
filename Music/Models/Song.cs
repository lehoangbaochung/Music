using Music.Enumerables;
using Music.Interfaces;
using Music.Utilities;
using System.Collections.Generic;

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

        public string VideoId { get; set; }

        public int Duration { get; set; }

        public string ImageUrl
            => GetImageUrl(ImageResolution.MQDefault);

        public List<Album> GetAlbums()
        {
            if (albums.Count == 0)
            {
                foreach (var album in DataProvider.Albums)
                {
                    if (album.SongId.Contains(Id))
                    {
                        if (!albums.Contains(album))
                        {
                            albums.Add(album);
                        }     
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
                videos.AddRange(DataProvider.Videos
                    .FindAll(v => v.SongId.Equals(Id)));
            }
            return videos;
        }
    } 
}
