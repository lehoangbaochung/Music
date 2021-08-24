using Music.Resources.Transtation;
using System;
using System.Collections.Generic;

namespace Music.Enumerables
{
    public static class Extension
    {
        public static string ToString(this Category category, Language language = default)
        {
            var categoryString = category.ToString();
            return language switch
            {
                Language.Vietnamese => VietnameseString.ResourceManager
                    .GetString(category.ToString()) ?? categoryString,
                _ => categoryString,
            };
        }

        public static string[] GetNames(Category startEnum, Category endEnum)
        {
            List<string> names = new();           
            foreach (int index in Enum.GetValues(typeof(Category)))
            {
                if (index >= (int)startEnum && index <= (int)endEnum)
                {
                    names.Add(Enum.GetName(typeof(Category), index));
                }    
            }
            return names.ToArray();
        }    

        public static string[] GetNames(this Enum @enum, Type enumType, Language language = default)
        {
            var names = Enum.GetNames(enumType);
            var values = (int[])Enum.GetValues(enumType);
   
            if (enumType.Equals(typeof(Category)))
            {
                for (int i = 0; i < names.Length; i++)
                {
                    names[i] = ((Category)values[i]).ToString(language); 
                }    
            }    

            return names;
        }
    }
}
