using Music.Models;
using Website.Models;

namespace Website.Utilities
{
    /// <summary>
    /// ngrok http https://localhost:44397 -host-header="localhost:44397"
    /// </summary>
    public static class ViewExtension
    {
        public const string PROFILE_VIEW_PATH = "~/Views/Shared/Profile.cshtml";
        //private const string NAVIGATION_VIEW_PATH = "~/Views/Shared/Partial/Navigation.cshtml";

        public static Hyperlink GetHyperlink(Base @base)
        {
            return new Hyperlink("Home", @base.GetType().Name, @base.Id);
        }
    }
}
