using Music.Interfaces;

namespace Music.Models
{
    public class Song : Base, ILyric
    {
        public string ArtistId { get; set; }

        public string VietnameseLyric { get; set; }

        public string PinyinLyric { get; set; }

        public string SimplifiedChineseLyric { get; set; }

        public string TraditionalChineseLyric { get; set; }

        public string Genre { get; set; }
    } 
}
