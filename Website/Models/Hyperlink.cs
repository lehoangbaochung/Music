namespace Website.Models
{
    public class Hyperlink
    {
        public string ControllerName { get; set; }

        public string ActionName { get; set; }

        public string Id { get; set; }

        public string CategoryName { get; set; }

        public Hyperlink() { }

        public Hyperlink(string controllerName, string actionName,
            string id = null, string categoryName = null)
        {
            Id = id;
            ControllerName = controllerName;
            ActionName = actionName;
            CategoryName = categoryName;
        }
    }
}
