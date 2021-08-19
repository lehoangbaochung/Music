namespace Music.Models
{
    public class Album : Base
    {
        public string ReleaseDate { get; set; }

        public string Genre { get; set; }

        public string ImageUrl
            => GetImageUrl(Id);
    }
}
