using System.Collections.Generic;
using Website.Models;

namespace Website.ViewModels
{
    public class ProfileViewModel 
    {
        public Item PrimaryItem { get; set; } = new();

        public Item SecondaryItem { get; set; } = new();

        public List<Item> Parameters { get; set; } = new();

        public List<Item> Informations { get; set; } = new();

        public List<NavigationViewModel> Navigations { get; set; } = new();
    }
}
