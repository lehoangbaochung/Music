using Music.Enumerables;
using Music.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Music.Utilities
{
    public static class Filter
    {


        /// <summary>
        /// Filters a sequence of values based on the id of category
        /// </summary>
        /// <param name="artists">A list of artists to filter</param>
        /// <param name="categoryName">The category name</param>
        /// <returns>A list that contains elements from the category's id that satisfy the condition</returns>
        public static List<Artist> Where(this List<Artist> artists, string categoryName)
        {
            List<Artist> results = new();
            if (Enum.Parse(typeof(Category), categoryName) == null)
            {
                return null;
            }
            
            return results;
        } 
       

        public static string[] Paging(List<object> items, int itemsInPage = 10)
        {
            if (items.Count <= itemsInPage) 
                return new string[] { "1" };

            var pageCount = items.Count % itemsInPage == 0 ?
                items.Count / itemsInPage :
                items.Count / itemsInPage + 1;

            var pageNames = new string[pageCount];

            for (int i = 1; i <= pageCount; i++)
            {
                pageNames[i - 1] = i.ToString();
            }

            return pageNames;
        }
    }
}
