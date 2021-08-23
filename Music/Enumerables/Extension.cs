using Music.Resources.Transtation;
using System;
using System.Collections.Generic;

namespace Music.Enumerables
{
    public static class Extension
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

        public static string[] GetNames(Category start, Category end)
        {
            var startIndex = (int)start;
            var endIndex = (int)end;
            List<string> names = new();

            foreach (int index in Enum.GetValues(typeof(Category)))
            {
                if (index >= startIndex && index <= endIndex)
                {
                    names.Add(Enum.GetName(typeof(Category), index));
                }    
            }
            return names.ToArray();
        }    
    }
}
