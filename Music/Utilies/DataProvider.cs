using Music.Enumerables;
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
        private static readonly List<SongArtist> songArtists = new();
        private static readonly List<AlbumArtist> albumArtists = new();
        #endregion

        #region Properties
        public static IList<Song> Songs
        {
            get
            {
                if (songs.Count == 0)
                {
                    GetSongs();
                }
                return songs;
            }
        }

        public static IList<Album> Albums
        {
            get
            {
                if (albums.Count == 0)
                {
                    GetAlbums();
                }
                return albums;
            }
        }

        public static IList<Artist> Artists
        {
            get
            {
                if (artists.Count == 0)
                {
                    GetArtists();
                }
                return artists;
            }
        }

        public static List<Video> Videos
        {
            get
            {
                if (videos.Count == 0)
                {
                    GetVideos();
                }
                return videos;
            }
        }

        public static List<SongArtist> SongArtists
        {
            get
            {
                if (songArtists.Count == 0)
                {
                    GetSongArtists();
                }
                return songArtists;
            }
        }

        public static List<AlbumArtist> AlbumArtists
        {
            get
            {
                if (albumArtists.Count == 0)
                {
                    //
                }
                return albumArtists;
            }
        }

        #endregion

        #region ColumnNames
        private const string KEY = "gsx$";
        private const string VALUE = "$t";

        // ids
        private const string ID = "id";
        private const string SONG_ID = "songid";
        private const string ALBUM_ID = "albumid";
        private const string ARTIST_ID = "artistid";
        private const string PLAYLIST_ID = "playlistid";

        // names
        private const string VN_NAME = "vnname";
        private const string PY_NAME = "pyname";
        private const string SC_NAME = "scname";
        private const string TC_NAME = "tcname";

        // titles
        private const string VN_TITLE = "vntitle";
        private const string PY_TITLE = "pytitle";
        private const string SC_TITLE = "sctitle";
        private const string TC_TITLE = "tctitle";

        // lyrics
        private const string VN_LYRIC = "vnlyric";
        private const string PY_LYRIC = "pylyric";
        private const string SC_LYRIC = "sclyric";
        private const string TC_LYRIC = "tclyric";

        // descriptions
        private const string VN_DESC = "vndesc";
        private const string PY_DESC = "pydesc";
        private const string SC_DESC = "scdesc";
        private const string TC_DESC = "tcdesc";

        // others
        private const string DURATION = "duration";
        private const string GENRE = "genre";
        private const string RELEASE_DATE = "releasedate";
        #endregion

        #region TableNames
        private static readonly string[] songColumns =
        {
            Parse(ID),
            Parse(ALBUM_ID),
            Parse(RELEASE_DATE),
            Parse(VN_TITLE),
            Parse(PY_TITLE),
            Parse(SC_TITLE),
            Parse(TC_TITLE),
            Parse(VN_LYRIC),
            Parse(PY_LYRIC),
            Parse(SC_LYRIC),
            Parse(TC_LYRIC),
            Parse(GENRE)
        };

        private static readonly string[] albumColumns =
        {
            Parse(ALBUM_ID),
            Parse(RELEASE_DATE),
            Parse(VN_TITLE),
            Parse(PY_TITLE),
            Parse(SC_TITLE),
            Parse(TC_TITLE),
            Parse(VN_DESC),
            Parse(SC_DESC),
            Parse(TC_DESC),
        };

        private static readonly string[] artistColumns =
        {
            Parse(ID),
            Parse(PLAYLIST_ID),
            Parse(VN_NAME),
            Parse(PY_NAME),
            Parse(SC_NAME),
            Parse(TC_NAME),
            Parse(VN_DESC),
            Parse(SC_DESC),
            Parse(TC_DESC),
        };

        private static readonly string[] videoColumns =
        {
            Parse(ID),
            Parse(SONG_ID), 
            Parse(RELEASE_DATE),
            Parse(DURATION)
        };

        private static readonly string[] songArtistColumns =
        {
            Parse(ID), 
            Parse(SONG_ID), 
            Parse(ARTIST_ID)
        };

        private static readonly string[] albumArtistColumns =
        {
            Parse(ID), 
            Parse(ALBUM_ID), 
            Parse(ARTIST_ID)
        };
        #endregion

        #region PARSE methods
        private static string Parse(string columnName)
        {
            return KEY + columnName;
        }

        private static dynamic Parse(Spreadsheet spreadsheet)
        {
            var address = $"https://spreadsheets.google.com/feeds/list/" +
                $"{ Resource.SpreadsheetId }/{ (int)spreadsheet }/public/values?alt=json";
            var jsonString = new WebClient().DownloadString(new System.Uri(address));
            dynamic json = JsonConvert.DeserializeObject(jsonString);
            return json.feed.entry;
        }
        #endregion

        #region GET methods
        private static void GetSongs()
        {
            foreach (var row in Parse(Spreadsheet.Song))
            {
                songs.Add(new()
                {
                    Id = row[songColumns[0]][VALUE],
                    AlbumId = row[songColumns[1]][VALUE],
                    ReleaseDate = row[songColumns[2]][VALUE],
                    VietnameseTitle = row[songColumns[3]][VALUE],
                    PinyinTitle = row[songColumns[4]][VALUE],
                    SimplifiedChineseTitle = row[songColumns[5]][VALUE],
                    TraditionalChineseTitle = row[songColumns[6]][VALUE],
                    VietnameseLyric = row[songColumns[7]][VALUE],
                    PinyinLyric = row[songColumns[8]][VALUE],
                    SimplifiedChineseLyric = row[songColumns[9]][VALUE],
                    TraditionalChineseLyric = row[songColumns[10]][VALUE],
                    Genre = row[songColumns[11]][VALUE],
                });
            }
        }    

        private static void GetAlbums()
        {
            foreach (var row in Parse(Spreadsheet.Album))
            {
                albums.Add(new()
                {
                    Id = row[albumColumns[0]][VALUE],
                    ReleaseDate = row[albumColumns[1]][VALUE],
                    VietnameseTitle = row[albumColumns[2]][VALUE],
                    PinyinTitle = row[albumColumns[3]][VALUE],
                    SimplifiedChineseTitle = row[albumColumns[4]][VALUE],
                    TraditionalChineseTitle = row[albumColumns[5]][VALUE],
                    VietnameseDescription = row[albumColumns[6]][VALUE],
                    SimplifiedChineseDescription = row[albumColumns[7]][VALUE],
                    TraditionalChineseDescription = row[albumColumns[8]][VALUE],
                });
            }
        }

        private static void GetArtists()
        {
            foreach (var row in Parse(Spreadsheet.Artist))
            {
                artists.Add(new()
                {
                    Id = row[artistColumns[0]][VALUE],
                    PlaylistId = row[artistColumns[1]][VALUE],
                    VietnameseName = row[artistColumns[2]][VALUE],
                    PinyinName = row[artistColumns[3]][VALUE],
                    SimplifiedChineseName = row[artistColumns[4]][VALUE],
                    TraditionalChineseName = row[artistColumns[5]][VALUE],
                    VietnameseDescription = row[artistColumns[6]][VALUE],
                    SimplifiedChineseDescription = row[artistColumns[7]][VALUE],
                    TraditionalChineseDescription = row[artistColumns[8]][VALUE],
                });
            }
        }

        private static void GetVideos()
        {
            foreach (var row in Parse(Spreadsheet.Video))
            {
                videos.Add(new()
                {
                    Id = row[videoColumns[0]][VALUE],
                    SongId = row[videoColumns[1]][VALUE],
                    ReleaseDate = row[videoColumns[2]][VALUE],
                    Duration = row[videoColumns[3]][VALUE]
                });
            }
        }

        private static void GetSongArtists()
        {
            foreach (var row in Parse(Spreadsheet.SongArtist))
            {
                songArtists.Add(new()
                {
                    Id = row[songArtistColumns[0]][VALUE],
                    SongId = row[songArtistColumns[1]][VALUE],
                    ArtistId = row[songArtistColumns[2]][VALUE]
                });
            }
        }
        #endregion
    }
}
