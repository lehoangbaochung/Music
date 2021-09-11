using Music.Enumerables;
using Music.Extensions;
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

        public Video() { }

        public Video(string songId)
        {
            var song = DataProvider.Songs.Find(s => s.Id.Equals(songId));

            if (song == null) return;

            VietnameseName = song.VietnameseName;
            PinyinName = song.PinyinName;
            SimplifiedChineseName = song.SimplifiedChineseName;
            TraditionalChineseName = song.TraditionalChineseName;
        }
    }
}
