using Music.Enumerables;
using Music.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

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
                    foreach (var row in Parse(nameof(Song)))
                    {
                        songs.Add(new()
                        {
                            Id = row[(int)DataTable.PrimaryKey],
                            ArtistId = row[(int)DataTable.ReferenceKey],
                            VietnameseName = row[(int)DataTable.VietnameseName],
                            PinyinName = row[(int)DataTable.PinyinName],
                            SimplifiedChineseName = row[(int)DataTable.SimplifiedChineseName],
                            TraditionalChineseName = row[(int)DataTable.TraditionalChineseName],
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
                            Id = row[(int)DataTable.PrimaryKey],
                            //PlaylistId = row[(int)ArtistTable.PlaylistId],
                            VietnameseName = row[(int)DataTable.VietnameseName],
                            PinyinName = row[(int)DataTable.PinyinName],
                            SimplifiedChineseName = row[(int)DataTable.SimplifiedChineseName],
                            TraditionalChineseName = row[(int)DataTable.TraditionalChineseName]
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
                            Id = row[(int)DataTable.PrimaryKey],
                            SongId = row[(int)DataTable.ReferenceKey],
                            VietnameseName = row[(int)DataTable.VietnameseName],
                            PinyinName = row[(int)DataTable.PinyinName],
                            SimplifiedChineseName = row[(int)DataTable.SimplifiedChineseName],
                            TraditionalChineseName = row[(int)DataTable.TraditionalChineseName]
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
                            Id = row[(int)DataTable.PrimaryKey],
                            SongId = row[(int)DataTable.ReferenceKey]
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
