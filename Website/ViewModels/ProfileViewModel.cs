using System.Collections.Generic;
using Website.Models;

namespace Website.ViewModels
{
    public class ProfileViewModel 
    {
        public Item PrimaryItem { get; set; }

        public Item SecondaryItem { get; set; } = new();

        public List<Profile> Parameters { get; set; } = new();

        public List<Profile> Informations { get; set; } = new();

        public List<NavigationViewModel> Navigations { get; set; } = new();
    }
}
