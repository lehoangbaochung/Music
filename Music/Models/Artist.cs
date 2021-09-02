using Music.Enumerables;
using Music.Extensions;
using Music.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace Music.Models
{
    public class Artist : User
    {
        private readonly List<Song> songs = new();
        private readonly List<Album> albums = new();
        private readonly List<Video> videos = new();

        public string PlaylistId { get; set; }

        public new string ImageUrl
            => ImageResolution.Medium.GetImageUrl(Id, Extension.ARTIST_IMAGE_ID);

        public List<Song> GetSongs()
        {
            if (songs.Count == 0)
            {
                songs.AddRange(DataProvider.Songs.FindAll(
                    song => song.ArtistIds.Contains(Id)));
            }    
            return songs;
        }

        public List<Album> GetAlbums()
        {
            if (albums.Count == 0)
            {
                // With each a song of this artist
                foreach (var song in GetSongs())
                {
                    // Find an album containing it (include exceptions about songid number)
                    var album = DataProvider.Albums.Find(
                        album => album.SongIds.Contains(song.Id));

                    // If there is an album containing it
                    if (album != null)
                    {
                        // With songs of this album
                        foreach (var songId in album.SongIds)
                        {
                            // Correct check
                            if (songId.Equals(song.Id))
                            {
                                // Check duplicate
                                if (!albums.Contains(album))
                                {
                                    albums.Add(album);
                                }
                            }
                        }
                    }
                }
            }    
            return albums;
        }

        public List<Video> GetVideos()
        {
            if (videos.Count == 0)
            {
                foreach (var song in GetSongs())
                {
                    videos.AddRange(DataProvider.Videos.FindAll(
                        video => video.SongId.Equals(song.Id)));
                }
            }    
            return videos;
        }
    }
}
