using Music.Models;
using System.Collections.Generic;
using System.Linq;

namespace Music.Utilies
{
    public static class ArtistHelper
    {
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
    }
}
