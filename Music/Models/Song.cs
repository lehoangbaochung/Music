using Music.Extensions;
using System.Collections.Generic;
using Music.Enumerables;

namespace Music.Models
{
    public class Song : Base
    {
        private readonly List<Album> albums = new();
        private readonly List<Artist> artists = new();
        private readonly List<Video> videos = new();

        public Property Lyric { get; set; }

        public string ArtistId { get; set; }

        public string DownloadId { get; set; }

        public string VideoId { get; set; }

        public int Duration { get; set; }

        public string ImageUrl
            => GetAlbums().Count > 0 ? GetAlbums()[0].ImageUrl : GetArtists()[0].ImageUrl;

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

        public string ToString(Language language = Language.Vietnamese)
        {
            var artistNames = string.Empty;
            switch (language)
            {
                case Language.English:
                    GetArtists().ForEach(a => artistNames += a.Name.Pinyin + " & ");
                    artistNames = artistNames.Remove(artistNames.Length - 3);
                    return $"{ Name.Pinyin } - { artistNames }";
                case Language.SimplifiedChinese:
                    GetArtists().ForEach(a => artistNames += a.Name.SimplifiedChinese + " & ");
                    artistNames = artistNames.Remove(artistNames.Length - 3);
                    return $"{ Name.SimplifiedChinese } - { artistNames }";
                case Language.TraditionalChinese:
                    GetArtists().ForEach(a => artistNames += a.Name.TraditionalChinese + " & ");
                    artistNames = artistNames.Remove(artistNames.Length - 3);
                    return $"{ Name.TraditionalChinese } - { artistNames }";
                case Language.Vietnamese:
                default:
                    GetArtists().ForEach(a => artistNames += a.Name.Vietnamese + " & ");
                    artistNames = artistNames.Remove(artistNames.Length - 3);
                    return $"{ Name.Vietnamese } - { artistNames }";
            }  
        }
    } 
}
