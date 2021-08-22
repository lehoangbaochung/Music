using Music.Resources.Transtation;
using System;

namespace Music.Enumerables
{
    static class EnumerableExtension
    {
        public static string TranslateName(this Category category, Language language = default)
        {
            var categoryString = category.ToString();

            return language switch
            {
                Language.English => categoryString,
                _ => VietnameseString.ResourceManager
                    .GetString(category.ToString()) ?? categoryString,
            };
        }

        public static string GetNames(this Category category, int startIndex, int length)
        {
            var t = Enum.GetNames(typeof(Category));
            return t[0];
        }    
    }
}
