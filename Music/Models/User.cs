using Music.Interfaces;

namespace Music.Models
{
    public class User : Base, IProfile
    {
        public string Birthday { get; set; }

        public string Address { get; set; }

        public string VietnameseFullName { get; set; }

        public string PinyinFullName { get; set; }

        public string SimplifiedChineseFullName { get; set; }

        public string TraditionalChineseFullName { get; set; }
    }
}
