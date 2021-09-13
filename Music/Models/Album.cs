using Music.Enumerables;
using Music.Extensions;
using System;
using System.Collections.Generic;

namespace Music.Models
{
    public class Album : Base
    {
        private readonly List<Song> songs = new();
        private readonly List<Artist> artists = new();
        private readonly List<Video> videos = new();

        public string SongId { get; set; }

        public string ReleaseDate { get; set; }

        public string ImageUrl
            => GetImageUrl(ImageResolution.Small, ALBUM_IMAGE_ID);

        public List<Song> GetSongs()
        {
            if (songs.Count == 0)
            {
                foreach (var songId in SongId.Split(SPLIT_CHARACTER))
                {
                    var song = DataProvider.Songs.Find(s => s.Id.Equals(songId));
                    if (song == null)
                    {
                        throw new NullReferenceException("Song is not found");
                    }    
                    songs.Add(song);
                }
            }
            return songs;
        }

        public List<Artist> GetArtists()
        {
            if (artists.Count == 0)
            {
                foreach (var song in GetSongs())
                {
                    foreach (var artistId in song.ArtistId.Split(SPLIT_CHARACTER))
                    {
                        var artist = DataProvider.Artists
                            .Find(a => a.Id.Equals(artistId));
                        if (artist == null)
                        {
                            throw new NullReferenceException("Artist is not found");
                        }
                        if (!artists.Contains(artist))
                        {
                            artists.Add(artist);
                        }
                    }
                }
            }
            return artists;
        }

        public List<Video> GetVideos()
        {
            if (videos.Count == 0)
            {
                foreach (var song in GetSongs())
                {
                    videos.AddRange(song.GetVideos());
                }
            }
            return videos;
        }
    }
}
