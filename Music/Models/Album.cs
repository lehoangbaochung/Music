using Music.Enumerables;
using Music.Extensions;
using Music.Utilities;
using System;
using System.Collections.Generic;

namespace Music.Models
{
    public class Album : Base
    {
        private readonly List<Song> songs = new();
        private readonly List<Video> videos = new();
        private readonly List<Artist> artists = new();

        public string[] SongIds { get; set; } 
            = Array.Empty<string>();

        public string ImageUrl
            => GetImageUrl(ImageResolution.Medium, ALBUM_IMAGE_ID);

        public List<Song> GetSongs()
        {
            if (songs.Count == 0)
            {
                foreach (var songId in SongIds)
                {
                    songs.Add(DataProvider.Songs.Find(
                        song => song.Id.Equals(songId)));
                }
            }
            return songs;
        }

        public List<Video> GetVideos()
        {
            if (videos.Count == 0)
            {
                foreach (var song in GetSongs())
                {
                    videos.Add(DataProvider.Videos.Find(
                        video => video.SongId.Equals(song.Id)));
                }
            }
            return videos;
        }

        public List<Artist> GetArtists()
        {
            if (artists.Count == 0)
            {
                foreach (var song in GetSongs())
                {
                    foreach (var artistId in song.ArtistIds)
                    {
                        var artist = DataProvider.Artists.Find(
                            artist => artist.Id.Equals(artistId));

                        if (!artists.Contains(artist))
                        {
                            artists.Add(artist);
                        }
                    }
                }
            }
            return artists;
        }
    }
}
