using System;

namespace Website.Models
{
    public class ItemViewModel
    {
        /// <summary>
        /// Hyperlink includes controllerName, actionName and routeParameter
        /// </summary>
        public Tuple<string, string, string> Hyperlink { get; set; }

        public dynamic Items { get; set; }

        public string ImageUrl { get; set; }

        public string Title { get; set; }

        public string Subtitle
        {
            get
            {
                if (Hyperlink == null)
                {
                    return "Tổng: " + Items.Count;
                }    
                else
                {
                    return "Xem tất cả";
                }    
            }
        }

        public int PageCount
        {
            get
            {
                if (Items.Count == 0) return 0;

                return Items.Count % 10 == 0 ? 
                    Items.Count / 10 : 
                    Items.Count / 10 + 1;
            }
        }
    }
}