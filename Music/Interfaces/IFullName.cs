namespace Music.Interfaces
{
    interface IFullName : IName
    {
        string VietnameseFullName { get; set; }

        string PinyinFullName { get; set; }

        string SimplifiedChineseFullName { get; set; }

        string TraditionalChineseFullName { get; set; }
    }
}
