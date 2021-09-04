﻿using Music.Enumerables;
using Music.Models;
using Music.Resources.Transtation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Music.Extensions
{
    public static class Extension
    {

        public static string ToString(this string text, Language language = default)
        {
            return language switch
            {
                Language.Vietnamese => VietnameseString.ResourceManager.GetString(text) ?? text,
                _ => text,
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
                    names[i] = ((Category)values[i]).ToString().ToString(language); 
                }    
            }    

            return names;
        }

        public static T GetRandomItem<T>(this List<T> list)
        {
            return list[new Random().Next(0, list.Count)];
        }    

        public static List<T> Where<T>(this List<T> list, Category category) where T : Base
        {
            T t = null;
            List<T> results = new();
            //var ids = t.Category.Split(JOIN_CHARACTER); 
            if (category >= Category.A && category <= Category.Z)
            {
                switch (category)
                {
                    case Category.A:
                        foreach (var character in Resource.CharactersA.Split(','))
                        {
                            results.AddRange(list
                                .Where(item => item.VietnameseName
                                .StartsWith(character)));
                        }
                        break;
                    case Category.D:
                        foreach (var character in Resource.CharactersD.Split(','))
                        {
                            results.AddRange(list
                                .Where(item => item.VietnameseName
                                .StartsWith(character)));
                        }
                        break;
                    case Category.E:
                        foreach (var character in Resource.CharactersE.Split(','))
                        {
                            results.AddRange(list
                                .Where(item => item.VietnameseName
                                .StartsWith(character)));
                        }
                        break;
                    case Category.O:
                        foreach (var character in Resource.CharactersO.Split(','))
                        {
                            results.AddRange(list
                                .Where(item => item.VietnameseName
                                .StartsWith(character)));
                        }
                        break;
                    case Category.U:
                        foreach (var character in Resource.CharactersU.Split(','))
                        {
                            results.AddRange(list
                                .Where(item => item.VietnameseName
                                .StartsWith(character)));
                        }
                        break;
                    default:
                        results.AddRange(list
                                .Where(item => item.VietnameseName
                                .StartsWith(category.ToString()
                                .ToString(Language.Vietnamese))));
                        break;
                }    
            }
            return results;
        }    
    }
}
