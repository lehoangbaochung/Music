using Music.Enumerables;

namespace Music.Models
{
    public class Album
    {
        public string Id { get; set; }

        public string VietnameseTitle { get; set; }

        public string PinyinTitle { get; set; }

        public string SimplifiedChineseTitle { get; set; }

        public string TraditionalChineseTitle { get; set; }

        public string VietnameseDescription { get; set; }

        public string SimplifiedChineseDescription { get; set; }

        public string TraditionalChineseDescription { get; set; }

        public string ReleaseDate { get; set; }

        public string Genre { get; set; }
    }
}
