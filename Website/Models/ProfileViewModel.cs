using System.Collections.Generic;

namespace Website.Models
{
    public class ProfileViewModel 
    {
        public Profile Profile { get; set; }

        public List<Profile> RelatedProfiles { get; set; } = new();

        public List<Profile> Summaries { get; set; } = new();

        public List<Profile> Informations { get; set; } = new();
    }

    public class Profile
    {
        public string Id { get; set; }

        public string Header { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string Color { get; set; }

        public string ImageUrl { get; set; }
    }
}
