using System.ComponentModel.DataAnnotations;

namespace Music.Models
{
    public class Video
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int SongId { get; set; }

        [Required]
        [Display(Name = "Thời lượng")]
        public int Duration { get; set; }

        [Required]
        [Display(Name = "Ngày đăng")]
        public string ReleaseDate { get; set; }
    }
}
