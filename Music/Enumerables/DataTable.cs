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
            TraditionalChineseName = 5
        }

        public enum Artist
        {
            Id = 0,
            PlaylistId = 1,
            VietnameseName = 2,
            PinyinName = 3,
            SimplifiedChineseName = 4,
            TraditionalChineseName = 5
        }

        public enum Album
        {
            Id = 0,
            SongId = 1,
            VietnameseName = 2,
            PinyinName = 3,
            SimplifiedChineseName = 4,
            TraditionalChineseName = 5
        }

        public enum Video
        {
            Id = 0,
            SongId = 1,
            Duration = 2
        }

        public static dynamic GetValue(string tableName)
        {
            var address = $"https://sheets.googleapis.com/v4/spreadsheets/" +
                $"{ Resource.SpreadsheetId }/values/{ tableName }?key={ Resource.ApiKey }";
            var jsonString = new WebClient().DownloadString(address);
            dynamic json = JsonConvert.DeserializeObject(jsonString);
            return json.values;
        }
    }
}
