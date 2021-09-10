using Music.Enumerables;
using Music.Models;
using System.Collections.Generic;

namespace Music.Utilities
{
    public class DataProvider
    {
        #region Fields
        private static readonly List<Song> songs = new();
        private static readonly List<Album> albums = new();
        private static readonly List<Artist> artists = new();
        private static readonly List<Video> videos = new();
        #endregion

        #region Properties
        public static List<Song> Songs
        {
            get
            {
                if (songs.Count == 0)
                {
                    foreach (var row in DataTable.GetValues(nameof(Song)))
                    {
                        songs.Add(new()
                        {
                            Id = row[(int)DataTable.Song.Id],
                            ArtistId = row[(int)DataTable.Song.ArtistId],
                            VietnameseName = row[(int)DataTable.Song.VietnameseName],
                            PinyinName = row[(int)DataTable.Song.PinyinName],
                            SimplifiedChineseName = row[(int)DataTable.Song.SimplifiedChineseName],
                            TraditionalChineseName = row[(int)DataTable.Song.TraditionalChineseName],
                        });
                    }
                }    
                return songs;
            }
        }

        public static List<Artist> Artists
        {
            get
            {
                if (artists.Count == 0)
                {
                    foreach (var row in DataTable.GetValues(nameof(Artist)))
                    {
                        artists.Add(new()
                        {
                            Id = row[(int)DataTable.Artist.Id],
                            //PlaylistId = row[(int)ArtistTable.PlaylistId],
                            VietnameseName = row[(int)DataTable.Artist.VietnameseName],
                            PinyinName = row[(int)DataTable.Artist.PinyinName],
                            SimplifiedChineseName = row[(int)DataTable.Artist.SimplifiedChineseName],
                            TraditionalChineseName = row[(int)DataTable.Artist.TraditionalChineseName]
                        });
                    }
                }
                return artists;
            }
        }

        public static List<Album> Albums
        {
            get
            {
                if (albums.Count == 0)
                {
                    foreach (var row in DataTable.GetValues(nameof(Album)))
                    {
                        albums.Add(new()
                        {
                            Id = row[(int)DataTable.Album.Id],
                            SongId = row[(int)DataTable.Album.SongId],
                            VietnameseName = row[(int)DataTable.Album.VietnameseName],
                            PinyinName = row[(int)DataTable.Album.PinyinName],
                            SimplifiedChineseName = row[(int)DataTable.Album.SimplifiedChineseName],
                            TraditionalChineseName = row[(int)DataTable.Album.TraditionalChineseName],
                            VietnameseDescription = row[(int)DataTable.Album.VietnameseDescription],
                            SimplifiedChineseDescription = row[(int)DataTable.Album.SimplifiedChineseDescription],
                            TraditionalChineseDescription = row[(int)DataTable.Album.TraditionalChineseDescription],
                            //ReleaseDate = row[(int)DataTable.Album.ReleaseDate],
                            //CategoryId = row[(int)DataTable.Album.CategoryId],
                        });
                    }
                }
                return albums;
            }
        }

        public static List<Video> Videos
        {
            get
            {
                if (videos.Count == 0)
                {
                    foreach (var row in DataTable.GetValues(nameof(Video)))
                    {
                        videos.Add(new()
                        {
                            Id = row[(int)DataTable.Video.Id],
                            SongId = row[(int)DataTable.Video.SongId]
                        });
                    }
                }
                return videos;
            }
        }
        #endregion
    }
}
