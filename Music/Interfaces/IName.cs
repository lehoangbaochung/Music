namespace Music.Interfaces
{
    interface IName
    {
        string VietnameseName { get; set; }

        string PinyinName { get; set; }

        string SimplifiedChineseName { get; set; }

        string TraditionalChineseName { get; set; }
    }
}
