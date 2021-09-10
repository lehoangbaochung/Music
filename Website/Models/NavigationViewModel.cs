namespace Website.ViewModels
{
    public class NavigationViewModel
    {
        public string Header { get; set; }

        public dynamic Items { get; set; }

        public string ViewName { get; set; }

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