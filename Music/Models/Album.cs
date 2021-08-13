namespace Music.Models
{
    public class Album : BaseModel
    {
        public string ReleaseDate { get; set; }

        public string Genre { get; set; }

        public string ImageUrl
            => Resource.ImageServerUrl + Resource.AlbumImageId
             + Resource.ImageCode + Id + Resource.ImageExtension;
    }
}
