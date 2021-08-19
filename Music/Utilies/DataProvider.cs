using Music.Enumerables.Tables;
using Music.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

namespace Music.Utilies
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
                    foreach (var row in Parse(nameof(Song)))
                    {
                        songs.Add(new()
                        {
                            Id = row[(int)SongTable.Id],
                            ArtistId = row[(int)SongTable.ArtistId],
                            VietnameseName = row[(int)SongTable.VietnameseName],
                            PinyinName = row[(int)SongTable.PinyinName],
                            SimplifiedChineseName = row[(int)SongTable.SimplifiedChineseName],
                            TraditionalChineseName = row[(int)SongTable.TraditionalChineseName],
                            //VietnameseLyric = row[SongTable.VietnameseLyric],
                            //PinyinLyric = row[SongTable.PinyinLyric],
                            //SimplifiedChineseLyric = row[SongTable.SimplifiedChineseLyric],
                            //TraditionalChineseLyric = row[SongTable.TraditionalChineseLyric],
                            //Genre = row[SongTable.Genre]
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
                    foreach (var row in Parse(nameof(Artist)))
                    {
                        artists.Add(new()
                        {
                            Id = row[(int)ArtistTable.Id],
                            //PlaylistId = row[(int)ArtistTable.PlaylistId],
                            VietnameseName = row[(int)ArtistTable.VietnameseName],
                            PinyinName = row[(int)ArtistTable.PinyinName],
                            SimplifiedChineseName = row[(int)ArtistTable.SimplifiedChineseName],
                            TraditionalChineseName = row[(int)ArtistTable.TraditionalChineseName]
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
                    foreach (var row in Parse(nameof(Album)))
                    {
                        albums.Add(new()
                        {
                            Id = row[AlbumTable.Id],
                            ReleaseDate = row[AlbumTable.Id],
                            VietnameseName = row[AlbumTable.Id],
                            PinyinName = row[AlbumTable.Id],
                            SimplifiedChineseName = row[AlbumTable.Id],
                            TraditionalChineseName = row[AlbumTable.Id],
                            VietnameseDescription = row[AlbumTable.Id],
                            SimplifiedChineseDescription = row[AlbumTable.Id],
                            TraditionalChineseDescription = row[AlbumTable.Id],
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
                    foreach (var row in Parse(nameof(Video)))
                    {
                        videos.Add(new()
                        {
                            Id = row[(int)VideoTable.Id],
                            SongId = row[(int)VideoTable.SongId],
                            Duration = row[(int)VideoTable.Duration],
                            //ReleaseDate = row[(int)VideoTable.ReleaseDate]
                        });
                    }
                }
                return videos;
            }
        }
        #endregion

        private static dynamic Parse(string tableName)
        {
            var address = $"https://sheets.googleapis.com/v4/spreadsheets/" +
                $"{ Resource.SpreadsheetId }/values/{ tableName }?key={ Resource.ApiKey }";
            var jsonString = new WebClient().DownloadString(address);
            dynamic json = JsonConvert.DeserializeObject(jsonString);
            return json.values;
        }
    }
}
