using Music.Enumerables;
using Music.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

namespace Music.Utilies
{
    public class DataProvider
    {
        #region Properties
        public List<Song> Songs { get; } = new();
        public List<Album> Albums { get; } = new();
        public List<Artist> Artists { get; } = new();
        public List<SongVideo> SongVideos { get; } = new();
        public List<SongArtist> SongArtists { get; } = new();
        public List<AlbumArtist> AlbumArtists { get; } = new();
        #endregion

        #region Singleton
        private static DataProvider instance;

        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new();
                }
                return instance;
            }
        }
        #endregion

        #region ColumnNames
        private const string KEY = "gsx$";
        private const string VALUE = "$t";

        // ids
        private const string ID = "id";
        private const string SONG_ID = "songid";
        private const string VIDEO_ID = "videoid";
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

        private static readonly string[] songVideoColumns =
        {
            Parse(ID),
            Parse(SONG_ID), 
            Parse(VIDEO_ID), 
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

        private DataProvider()
        {
            // Song
            foreach (var row in Parse(Spreadsheet.Song))
            {
                Songs.Add(new()
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

            // Album
            foreach (var row in Parse(Spreadsheet.Album))
            {
                Albums.Add(new()
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

            // Artist
            foreach (var row in Parse(Spreadsheet.Artist))
            {
                Artists.Add(new()
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

            // SongVideo
            foreach (var row in Parse(Spreadsheet.SongVideo))
            {
                SongVideos.Add(new()
                {
                    Id = row[songVideoColumns[0]][VALUE],
                    SongId = row[songVideoColumns[1]][VALUE],
                    VideoId = row[songVideoColumns[2]][VALUE],
                    ReleaseDate = row[songVideoColumns[3]][VALUE],
                    Duration = row[songVideoColumns[4]][VALUE]
                });
            }

            // SongArtist
            foreach (var row in Parse(Spreadsheet.SongArtist))
            {
                SongArtists.Add(new()
                {
                    Id = row[songArtistColumns[0]][VALUE],
                    SongId = row[songArtistColumns[1]][VALUE],
                    ArtistId = row[songArtistColumns[2]][VALUE]
                });
            } 
        }

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
    }
}
