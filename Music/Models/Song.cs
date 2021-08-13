using Music.Interfaces;

namespace Music.Models
{
    public class Song : BaseModel, ILyric
    {
        public new int Id { get; set; }

        public string AlbumId { get; set; }

        public string VietnameseLyric { get; set; }

        public string PinyinLyric { get; set; }

        public string SimplifiedChineseLyric { get; set; }

        public string TraditionalChineseLyric { get; set; }

        public string ReleaseDate { get; set; }

        public string Genre { get; set; }
    }
}
