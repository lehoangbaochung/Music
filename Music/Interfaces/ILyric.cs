namespace Music.Interfaces
{
    interface ILyric
    {
        string VietnameseLyric { get; set; }

        string PinyinLyric { get; set; }

        string SimplifiedChineseLyric { get; set; }

        string TraditionalChineseLyric { get; set; }
    }
}
