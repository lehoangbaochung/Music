using Music.Enumerables;
using Music.Extensions;
using Music.Utilities;
using System.Collections.Generic;

namespace Music.Models
{
    public class Album : Base
    {
        private readonly List<Song> songs = new();
        private readonly List<Video> videos = new();
        private readonly List<Artist> artists = new();

        public string SongIds { get; set; }

        public string ImageUrl
            => ImageResolution.Medium.GetImageUrl(Id, Extension.ALBUM_IMAGE_ID);

        public List<Song> GetSongs()
        {
            if (songs.Count == 0)
            {
                foreach (var songId in SongIds.Split(Extension.JOIN_CHARACTER))
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
                    foreach (var artistId in song.ArtistId.Split(Extension.JOIN_CHARACTER))
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
