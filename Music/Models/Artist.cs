using Music.Enumerables;
using Music.Extensions;
using System.Collections.Generic;

namespace Music.Models
{
    public class Artist : Base
    {
        private readonly List<Song> songs = new();
        private readonly List<Album> albums = new();
        private readonly List<Video> videos = new();

        public string PlaylistId { get; set; }

        public string ImageUrl
            => GetImageUrl(ImageResolution.Medium, ARTIST_IMAGE_ID);

        public List<Song> GetSongs()
        {
            if (songs.Count == 0)
            {
                songs.AddRange(DataProvider.Songs.FindAll(
                    song => song.ArtistId.Contains(Id)));
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
                        album => album.SongId.Contains(song.Id));

                    // If there is an album containing it
                    if (album != null)
                    {
                        // With songs of this album
                        foreach (var songId in album.SongId.Split(SPLIT_CHARACTER))
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
                    videos.AddRange(song.GetVideos());
                }
            }    
            return videos;
        }

        public Dictionary<string, string> GetInformationDict()
        {
            Dictionary<string, string> infos = new();
            foreach (var information in Description.Vietnamese.Split("\n"))
            {
                var value = information.Split(':');
                infos.Add(value[0], value[1]);
            }
            return infos;
        }
    }
}
