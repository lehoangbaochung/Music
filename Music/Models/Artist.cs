using Music.Enumerables;
using Music.Utilities;
using System.Collections.Generic;

namespace Music.Models
{
    public class Artist : User
    {
        private readonly List<Song> songs = new();
        private readonly List<Album> albums = new();
        private readonly List<Video> videos = new();

        public List<Song> Songs
        {
            get
            {
                if (songs.Count == 0)
                {
                    songs.AddRange(DataProvider.Songs
                        .FindAll(song => song.ArtistId.Contains(Id)));
                }
                return songs;
            }
        }

        public List<Album> Albums
        {
            get
            {
                if (albums.Count == 0)
                {
                    // With each a song of this artist
                    foreach (var song in Songs)
                    {
                        // Find an album containing it (include exceptions about songid number)
                        var album = DataProvider.Albums.Find(
                            album => album.SongId.Contains(song.Id.ToString()));

                        // If there is an album containing it
                        if (album != null)
                        {
                            // With songs of this album
                            foreach (var songId in album.SongId.Split(JOIN_CHARACTER))
                            {
                                // Correct check
                                if (songId.Equals(song.Id.ToString()))
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
        }

        public List<Video> Videos
        {
            get
            {
                if (videos.Count == 0)
                {
                    foreach (var song in Songs)
                    {
                        videos.AddRange(DataProvider.Videos.FindAll(
                            video => video.SongId.Equals(song.Id)));
                    }    
                }    
                return videos;
            }
        }

        public string PlaylistId { get; set; }

        public new string ImageUrl
            => ImageResolution.Medium.GetImageUrl(Id, Resource.ArtistImageId);
    }
}
