using Music.Enumerables;
using Music.Interfaces;

namespace Music.Models
{
    public class Base : IName, IDescription
    {
        protected const string SPLIT_CHARACTER = "/";
        protected const string IMAGE_EXTENSION = ".jpg";
        protected const string ARTIST_IMAGE_ID = "T001";
        protected const string ALBUM_IMAGE_ID = "T002";

        public string Id { get; set; }
        public string CategoryId { get; set; } = "";

        public string VietnameseName { get; set; }
        public string PinyinName { get; set; }
        public string SimplifiedChineseName { get; set; }
        public string TraditionalChineseName { get; set; }

        public string VietnameseDescription { get; set; }
        public string SimplifiedChineseDescription { get; set; }
        public string TraditionalChineseDescription { get; set; }

        public string ImageUrl
            => GetImageUrl(ImageResolution.MQDefault);

        protected string GetImageUrl(ImageResolution imageResolution, string imageId = null)
        {
            if (imageId == null)
            {
                return Resource.VideoImageUrl + Id + SPLIT_CHARACTER
                        + imageResolution.ToString().ToLower()
                        + IMAGE_EXTENSION;
            }    
            else
            {
                return Resource.ImageServerUrl + imageId
                        + $"R{ (int)imageResolution }x{ (int)imageResolution }M000"
                        + Id + IMAGE_EXTENSION;
            }    
        }
    }
}
