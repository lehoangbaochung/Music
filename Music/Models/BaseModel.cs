using Music.Interfaces;

namespace Music.Models
{
    public class BaseModel : IName, IDescription
    {
        public string Id { get; set; }

        public string VietnameseName { get; set; }

        public string PinyinName { get; set; }

        public string SimplifiedChineseName { get; set; }

        public string TraditionalChineseName { get; set; }

        public string VietnameseDescription { get; set; }

        public string SimplifiedChineseDescription { get; set; }

        public string TraditionalChineseDescription { get; set; }
    }
}
