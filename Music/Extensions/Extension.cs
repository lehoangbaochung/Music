using Music.Enumerables;
using Music.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Music.Extensions
{
    public static class Extension
    {
        public static T GetRandomItem<T>(this List<T> list)
        {
            return list[new Random().Next(0, list.Count)];
        }    

        public static List<T> Where<T>(this List<T> list, Category.Alphabet category) where T : Base
        {
            //T t = null;
            List<T> results = new();
            //var ids = t.Category.Split(JOIN_CHARACTER); 
            if (category >= Category.Alphabet.A && category <= Category.Alphabet.Z)
            {
                switch (category)
                {
                    case Category.Alphabet.A:
                        foreach (var character in Resource.CharactersA.Split(','))
                        {
                            results.AddRange(list
                                .Where(item => item.VietnameseName
                                .StartsWith(character)));
                        }
                        break;
                    case Category.Alphabet.D:
                        foreach (var character in Resource.CharactersD.Split(','))
                        {
                            results.AddRange(list
                                .Where(item => item.VietnameseName
                                .StartsWith(character)));
                        }
                        break;
                    case Category.Alphabet.E:
                        foreach (var character in Resource.CharactersE.Split(','))
                        {
                            results.AddRange(list
                                .Where(item => item.VietnameseName
                                .StartsWith(character)));
                        }
                        break;
                    case Category.Alphabet.O:
                        foreach (var character in Resource.CharactersO.Split(','))
                        {
                            results.AddRange(list
                                .Where(item => item.VietnameseName
                                .StartsWith(character)));
                        }
                        break;
                    case Category.Alphabet.U:
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
