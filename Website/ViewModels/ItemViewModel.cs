using Website.Models;

namespace Website.ViewModels
{
    public class ItemViewModel
    {
        public string ViewName { get; set; }

        public Hyperlink Hyperlink { get; set; }

        public dynamic Items { get; set; }

        public string ImageUrl { get; set; }

        public string Header { get; set; }

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