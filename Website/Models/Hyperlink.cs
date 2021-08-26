namespace Website.Models
{
    public class Hyperlink
    {
        public string Controller { get; set; }

        public string Action { get; set; }

        public string Id { get; set; }

        public string Category { get; set; }

        public Hyperlink() { }

        public Hyperlink(string controller, string action,
            string id = null, string category = null)
        {
            Id = id;
            Controller = controller;
            Action = action;
            Category = category;
        }
    }
}
