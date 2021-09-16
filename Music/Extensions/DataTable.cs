using Newtonsoft.Json;
using System.Net;

namespace Music.Extensions
{
    class DataTable 
    {
        public const int PrimaryId = 0;
        public const int ReferenceId = 1;

        public class Name
        {
            public const int Vietnamese = 2;
            public const int Pinyin = 3;
            public const int SimplifiedChinese = 4;
            public const int TraditionalChinese = 5;
        }

        public class Description
        {
            public const int Vietnamese = 6;
            public const int SimplifiedChinese = 7;
            public const int TraditionalChinese = 8;
        }

        public class Lyric
        {
            public const int Vietnamese = 9;
            public const int Pinyin = 10;
            public const int SimplifiedChinese = 11;
            public const int TraditionalChinese = 12;
        }

        // Song
        public const int DownloadId = 13;

        // Album
        public const int ReleaseDate = 9;

        public static dynamic GetValues(string tableName)
        {
            var address = $"https://sheets.googleapis.com/v4/spreadsheets/" +
                $"{ Resource.SpreadsheetId }/values/{ tableName }?key={ Resource.SheetApiKey }";
            var jsonString = new WebClient().DownloadString(address);
            dynamic json = JsonConvert.DeserializeObject(jsonString);
            return json.values;
        }

        public static dynamic GetView()
        {
            var address = $"https://www.googleapis.com/youtube/v3/videos?part=statistics&id=" +
                $"{ 2 }&key={ Resource.YoutubeApiKey }";
            var jsonString = new WebClient().DownloadString(address);
            dynamic json = JsonConvert.DeserializeObject(jsonString);
            return json.items.statistics;
        }
    }
}
