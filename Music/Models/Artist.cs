namespace Music.Models
{
    public class Artist
    {
        public string Id { get; set; }

        public string PlaylistId { get; set; }

        public string VietnameseName { get; set; }

        public string PinyinName { get; set; }

        public string SimplifiedChineseName { get; set; }

        public string TraditionalChineseName { get; set; }

        public string VietnameseDescription { get; set; }

        public string SimplifiedChineseDescription { get; set; }
        
        public string TraditionalChineseDescription { get; set; }

        public bool? Gender { get; set; }

        public string ImageUrl
        {
            get
            {
                return Resource.ImageServerUrl + Resource.ArtistImageId 
                    + Resource.ImageCode + Id + Resource.ImageExtension;
            }
        }
    }
}
