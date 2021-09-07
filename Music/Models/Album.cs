using Music.Enumerables;
using Music.Utilities;
using System.Collections.Generic;

namespace Music.Models
{
    public class Album : Base
    {
        private readonly List<Song> songs = new();
        private readonly List<Artist> artists = new();
        private readonly List<Video> videos = new();

        public string SongId { get; set; } 

        public string ImageUrl
            => GetImageUrl(ImageResolution.Small, ALBUM_IMAGE_ID);

        public List<Song> GetSongs()
        {
            if (songs.Count == 0)
            {
                foreach (var songId in SongId.Split(SPLIT_CHARACTER))
                {
                    songs.Add(DataProvider.Songs.Find(
                        song => song.Id.Equals(songId)));
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
