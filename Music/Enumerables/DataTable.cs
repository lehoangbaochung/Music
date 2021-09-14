using Newtonsoft.Json;
using System.Net;

namespace Music.Enumerables
{
    class DataTable
    {
        public enum Song
        {
            Id = 0,
            ArtistId = 1,
            VietnameseName = 2,
            PinyinName = 3,
            SimplifiedChineseName = 4,
            TraditionalChineseName = 5,
            VietnameseDescription = 6,
            SimplifiedChineseDescription = 7,
            TraditionalChineseDescription = 8,
            VietnameseLyric = 9,
            PinyinLyric = 10,
            SimplifiedChineseLyric = 11,
            TraditionalChineseLyric = 12,
            DownloadId = 13,
            CategoryId
        }

        public enum Artist
        {
            Id = 0,
            PlaylistId = 1,
            VietnameseName = 2,
            PinyinName = 3,
            SimplifiedChineseName = 4,
            TraditionalChineseName = 5,
            VietnameseDescription = 6,
            SimplifiedChineseDescription = 7,
            TraditionalChineseDescription = 8,
            CategoryId
        }

        public enum Album
        {
            Id = 0,
            SongId = 1,
            VietnameseName = 2,
            PinyinName = 3,
            SimplifiedChineseName = 4,
            TraditionalChineseName = 5,
            VietnameseDescription = 6,
            SimplifiedChineseDescription = 7,
            TraditionalChineseDescription = 8,
            ReleaseDate = 9,
            CategoryId
        }

        public enum Video
        {
            Id = 0,
            SongId = 1,
            Duration = 2,
            ReleaseDate = 3,
            CategoryId
        }

        public static dynamic GetValues(string tableName)
        {
            var address = $"https://sheets.googleapis.com/v4/spreadsheets/" +
                $"{ Resource.SpreadsheetId }/values/{ tableName }?key={ Resource.SheetApiKey }";
            var jsonString = new WebClient().DownloadString(address);
            dynamic json = JsonConvert.DeserializeObject(jsonString);
            return json.values;
        }

        public static dynamic GetView(Song song)
        {
            var address = $"https://www.googleapis.com/youtube/v3/videos?part=statistics&id=" +
                $"{ ((int)song) }&key={ Resource.YoutubeApiKey }";
            var jsonString = new WebClient().DownloadString(address);
            dynamic json = JsonConvert.DeserializeObject(jsonString);
            return json.items.statistics;
        }
    }
}
