using Music.Interfaces;
using System;

namespace Music.Models
{
    public class Song : Base, ILyric
    {
        public string VietnameseLyric { get; set; }

        public string PinyinLyric { get; set; }

        public string SimplifiedChineseLyric { get; set; }

        public string TraditionalChineseLyric { get; set; }

        public string[] ArtistIds { get; set; } = Array.Empty<string>();

        public string[] DownloadIds { get; set; } = Array.Empty<string>();
    } 
}
