using System.Collections.Generic;
using Website.Models;

namespace Website.ViewModels
{
    public class ProfileViewModel 
    {
        public Profile Profile { get; set; }

        public List<Profile> RelatedProfiles { get; set; } = new();

        public List<Profile> Summaries { get; set; } = new();

        public List<Profile> Informations { get; set; } = new();

        public List<ItemViewModel> Items { get; set; } = new();
    }
}
