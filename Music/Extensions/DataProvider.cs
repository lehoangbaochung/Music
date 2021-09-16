using Music.Models;
using System.Collections.Generic;

namespace Music.Extensions
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
                            Id = row[DataTable.PrimaryId],
                            ArtistId = row[DataTable.ReferenceId],
                            Name = new()
                            {
                                Vietnamese = row[DataTable.Name.Vietnamese],
                                Pinyin = row[DataTable.Name.Pinyin],
                                SimplifiedChinese = row[DataTable.Name.SimplifiedChinese],
                                TraditionalChinese = row[DataTable.Name.TraditionalChinese]
                            },
                            Description = new()
                            {
                                Vietnamese = row[DataTable.Description.Vietnamese],
                                SimplifiedChinese = row[DataTable.Description.SimplifiedChinese],
                                TraditionalChinese = row[DataTable.Description.TraditionalChinese]
                            },
                            Lyric = new()
                            {
                                Vietnamese = row[DataTable.Lyric.Vietnamese],
                                Pinyin = row[DataTable.Lyric.Pinyin],
                                SimplifiedChinese = row[DataTable.Lyric.SimplifiedChinese],
                                TraditionalChinese = row[DataTable.Lyric.TraditionalChinese]
                            }
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
                            Id = row[DataTable.PrimaryId],
                            Name = new()
                            {
                                Vietnamese = row[DataTable.Name.Vietnamese],
                                Pinyin = row[DataTable.Name.Pinyin],
                                SimplifiedChinese = row[DataTable.Name.SimplifiedChinese],
                                TraditionalChinese = row[DataTable.Name.TraditionalChinese] 
                            },
                            Description = new()
                            {
                                Vietnamese = row[DataTable.Description.Vietnamese],
                                SimplifiedChinese = row[DataTable.Description.SimplifiedChinese],
                                TraditionalChinese = row[DataTable.Description.TraditionalChinese]
                            }
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
                            Id = row[DataTable.PrimaryId],
                            SongId = row[DataTable.ReferenceId],
                            Name = new()
                            {
                                Vietnamese = row[DataTable.Name.Vietnamese],
                                Pinyin = row[DataTable.Name.Pinyin],
                                SimplifiedChinese = row[DataTable.Name.SimplifiedChinese],
                                TraditionalChinese = row[DataTable.Name.TraditionalChinese]
                            },
                            Description = new()
                            {
                                Vietnamese = row[DataTable.Description.Vietnamese],
                                SimplifiedChinese = row[DataTable.Description.SimplifiedChinese],
                                TraditionalChinese = row[DataTable.Description.TraditionalChinese]
                            }
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
                            Id = row[DataTable.PrimaryId],
                            SongId = row[DataTable.ReferenceId]
                        });
                    }
                }
                return videos;
            }
        }
        #endregion
    }
}
