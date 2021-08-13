namespace Music.Models
{
    public class Artist : BaseModel
    {
        public string PlaylistId { get; set; }

        public bool? Gender { get; set; }

        public string ImageUrl
            => Resource.ImageServerUrl + Resource.ArtistImageId
             + Resource.ImageCode + Id + Resource.ImageExtension;


    }
}
