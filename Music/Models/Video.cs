using Music.Enumerables;
using Music.Utilies;
using System.ComponentModel.DataAnnotations;

namespace Music.Models
{
    public class Video : Base
    {
        [Required]
        public new string Id { get; set; }

        [Required]
        public int SongId { get; set; }

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
