using Music.Enumerables;
using Music.Utilities;
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
                            song => song.Id.ToString().Equals(songId)));
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
                        foreach (var artistId in song.ArtistId.Split(JOIN_CHARACTER))
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

        public string SongId { get; set; }

        public string Genre { get; set; }

        public string ImageUrl
            => ImageResolution.Medium.GetImageUrl(Id, Resource.AlbumImageId);
    }
}
