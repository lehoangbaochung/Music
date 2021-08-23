using Music.Enumerables;
using Music.Interfaces;
using Music.Utilities;

namespace Music.Models
{
    public class Base : IName, IDescription
    {
        protected const char JOIN_CHARACTER = '-';
        protected const string SPLIT_CHARACTER = "/";

        public string Id { get; set; }

        public string VietnameseName { get; set; }
        public string PinyinName { get; set; }
        public string SimplifiedChineseName { get; set; }
        public string TraditionalChineseName { get; set; }

        public string VietnameseDescription { get; set; }
        public string SimplifiedChineseDescription { get; set; }
        public string TraditionalChineseDescription { get; set; }

        public string Category { get; set; }

        protected string GetImageUrl(ImageResolution imageSize = ImageResolution.Medium)
        {
            return imageSize.GetImageUrl(Id);
        }
    }
}
