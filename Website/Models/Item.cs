namespace Website.Models
{
    public class Item
    {
        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string ImageUrl { get; set; }

        public string ColorName { get; set; }

        public Hyperlink Hyperlink { get; set; } = new();
    }
}
