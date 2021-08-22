using Music.Enumerables;
using Music.Utilities;
using System.ComponentModel.DataAnnotations;

namespace Music.Models
{
    public class Video : Base
    {
        [Required]
        public string SongId { get; set; }

        [Required]
        [Display(Name = "Thời lượng")]
        public int Duration { get; set; }

        [Required]
        [Display(Name = "Ngày đăng")]
        public string ReleaseDate { get; set; }

        public string ImageUrl
            => ImageResolution.MQDefault.GetImageUrl(Id);
    }
}
