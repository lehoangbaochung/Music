using Music.Enumerables;
using Music.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Music.Utilities
{
    public static class Filter
    {
        static IEnumerable<Artist> GroupByGender(string index)
        {
            return DataProvider.Artists
                .Where(artist => artist.Gender
                .Equals((Gender)int.Parse(index)));
        }

        /// <summary>
        /// Filters a sequence of values based on the id of category
        /// </summary>
        /// <param name="artists">A list of artists to filter</param>
        /// <param name="categoryId">The id of category</param>
        /// <returns>A list that contains elements from the category's id that satisfy the condition</returns>
        public static List<Artist> Where(this List<Artist> artists, int categoryId)
        {
            List<Artist> results = new();
            switch ((Category)categoryId)
            {
                case Category.A:
                    foreach (var character in Resource.CharactersA.Split(','))
                    {
                        results.AddRange(artists
                            .Where(artist => artist.VietnameseName.ToLower()
                            .StartsWith(character)));
                    }
                    break;
                case Category.D:
                    foreach (var character in Resource.CharactersD.Split(','))
                    {
                        results.AddRange(artists
                            .Where(artist => artist.VietnameseName.ToLower()
                            .StartsWith(character)));
                    }
                    break;
                case Category.E:
                    foreach (var character in Resource.CharactersE.Split(','))
                    {
                        results.AddRange(artists
                            .Where(artist => artist.VietnameseName.ToLower()
                            .StartsWith(character)));
                    }
                    break;
                case Category.O:
                    foreach (var character in Resource.CharactersO.Split(','))
                    {
                        results.AddRange(artists
                            .Where(artist => artist.VietnameseName.ToLower()
                            .StartsWith(character)));
                    }
                    break;
                case Category.U:
                    foreach (var character in Resource.CharactersU.Split(','))
                    {
                        results.AddRange(artists
                            .Where(artist => artist.VietnameseName.ToLower()
                            .StartsWith(character)));
                    }
                    break;
                default:
                    results.AddRange(artists
                            .Where(artist => artist.VietnameseName
                            .StartsWith(((Category)categoryId).ToString(), 
                            StringComparison.CurrentCulture)));
                    break;
                    
            }
            return artists;
        }    
    }
}
