using Music.Enumerables;
using Music.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Music.Utilities
{
    public static class DataHelper
    {
        private const char JOIN_CHARACTER = '-';
        private const string SPLIT_CHARACTER = "/";

        private static readonly char[] aChars = { 'A', 'Á', 'À', 'Ă', 'Â', 'Á' };
        private static readonly char[] dChars = { 'D', 'Đ' };
        private static readonly char[] eChars = { 'E', 'Ê' };
        private static readonly char[] oChars = { 'O', 'Ô', 'Ơ' };
        private static readonly char[] uChars = { 'U', 'Ư' };
        private static readonly char[] numberChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        public static IList<Artist> Where(List<Artist> sourceList, char character)
        {
            List<Artist> outterList = new();

            if (char.IsLower(character))
            {
                character = char.ToUpper(character);
            }

            if (character.Equals('/'))
            {
                outterList = sourceList.OrderBy(artist => artist.VietnameseName).ToList();
            }
            else if (character.Equals('#'))
            {
                foreach (var numberChar in numberChars)
                {
                    outterList.AddRange(sourceList
                        .Where(a => a.VietnameseName.ToUpper().StartsWith(numberChar)));
                }
            }
            else if (aChars.Contains(character))
            {
                foreach (var aChar in aChars)
                {
                    outterList.AddRange(sourceList
                        .Where(a => a.VietnameseName.ToUpper().StartsWith(aChar)));
                }
            }
            else if (dChars.Contains(character))
            {
                foreach (var dChar in dChars)
                {
                    outterList.AddRange(sourceList
                        .Where(a => a.VietnameseName.ToUpper().StartsWith(dChar)));
                }
            }
            else if (eChars.Contains(character))
            {
                foreach (var eChar in eChars)
                {
                    outterList.AddRange(sourceList
                        .Where(a => a.VietnameseName.ToUpper().StartsWith(eChar)));
                }
            }
            else if (oChars.Contains(character))
            {
                foreach (var oChar in oChars)
                {
                    outterList.AddRange(sourceList
                        .Where(a => a.VietnameseName.ToUpper().StartsWith(oChar)));
                }
            }
            else if (uChars.Contains(character))
            {
                foreach (var uChar in uChars)
                {
                    outterList.AddRange(sourceList
                        .Where(a => a.VietnameseName.ToUpper().StartsWith(uChar)));
                }
            }
            else
            {
                outterList.AddRange(sourceList
                        .Where(a => a.VietnameseName.ToUpper().StartsWith(character)));
            }

            return outterList;
        }

        public static IList<Base> Where(List<Base> sourceList, char character)
        {
            List<Base> outterList = new();

            if (char.IsLower(character))
            {
                character = char.ToUpper(character);
            }

            if (character.Equals('/'))
            {
                outterList = sourceList.OrderBy(artist => artist.VietnameseName).ToList();
            }
            else if (character.Equals('#'))
            {
                foreach (var numberChar in numberChars)
                {
                    outterList.AddRange(sourceList
                        .Where(a => a.VietnameseName.ToUpper().StartsWith(numberChar)));
                }
            }
            else if (aChars.Contains(character))
            {
                foreach (var aChar in aChars)
                {
                    outterList.AddRange(sourceList
                        .Where(a => a.VietnameseName.ToUpper().StartsWith(aChar)));
                }
            }
            else if (dChars.Contains(character))
            {
                foreach (var dChar in dChars)
                {
                    outterList.AddRange(sourceList
                        .Where(a => a.VietnameseName.ToUpper().StartsWith(dChar)));
                }
            }
            else if (eChars.Contains(character))
            {
                foreach (var eChar in eChars)
                {
                    outterList.AddRange(sourceList
                        .Where(a => a.VietnameseName.ToUpper().StartsWith(eChar)));
                }
            }
            else if (oChars.Contains(character))
            {
                foreach (var oChar in oChars)
                {
                    outterList.AddRange(sourceList
                        .Where(a => a.VietnameseName.ToUpper().StartsWith(oChar)));
                }
            }
            else if (uChars.Contains(character))
            {
                foreach (var uChar in uChars)
                {
                    outterList.AddRange(sourceList
                        .Where(a => a.VietnameseName.ToUpper().StartsWith(uChar)));
                }
            }
            else
            {
                outterList.AddRange(sourceList
                        .Where(a => a.VietnameseName.ToUpper().StartsWith(character)));
            }

            return outterList;
        }

        public static string GetNames(in string id, string splitCharacter = SPLIT_CHARACTER, Language language = default)
        {
            var artistName = string.Empty;

            foreach (var artistId in id.Split(JOIN_CHARACTER))
            {
                var artist = DataProvider.Artists.Find(a => a.Id.Equals(artistId));
                if (artist == null)
                {
                    throw new NullReferenceException("Name is not found");
                }
                else
                {
                    artistName += language switch
                    {
                        Language.English => artist.PinyinName + splitCharacter,
                        Language.SimplifiedChinese => artist.SimplifiedChineseName + splitCharacter,
                        Language.TraditionalChinese => artist.TraditionalChineseName + splitCharacter,
                        _ => artist.VietnameseName + splitCharacter,
                    };
                }
            }
            return artistName.Remove(artistName.LastIndexOf(splitCharacter)).TrimEnd();
        }


    }
}
