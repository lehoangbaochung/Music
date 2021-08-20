using Music.Enumerables;
using Music.Utilies;
using System.Collections.Generic;

namespace Music.Models
{
    public class Album : Base
    {
        private readonly List<Song> songs = new();
        private readonly List<Artist> artists = new();

        public List<Song> Songs
        {
            get
            {
                if (songs.Count == 0)
                {
                    foreach (var songId in SongId.Split(JOIN_CHARACTER))
                    {
                        songs.Add(DataProvider.Songs.Find(
                            song => song.Id.Equals(songId)));
                    }
                }
                return songs;
            }
        }

        public List<Artist> Artists
        {
            get
            {
                if (artists.Count == 0)
                {
                    foreach (var song in Songs)
                    {
                        artists.AddRange(DataProvider.Artists.FindAll(
                                artist => artist.Id.Contains(song.ArtistId)));
                    }    
                }    
                return artists;
            }
        }

        public string SongId { get; set; }

        public string Genre { get; set; }

        public string ImageUrl
            => ImageResolution.Small.GetImageUrl(Id, Resource.AlbumImageId);
    }
}
