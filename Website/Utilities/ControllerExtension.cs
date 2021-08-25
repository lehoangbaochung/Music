using Microsoft.AspNetCore.Mvc;
using Music.Models;
using Music.Utilities;
using System;
using System.Linq;
using Website.Controllers;
using Website.ViewModels;

namespace Website.Utilities
{
    public static class ControllerExtension 
    {
        public static IActionResult ReturnView(this HomeController controller, 
            ProfileViewModel viewModel, string category)
        {
            switch (category)
            {
                case nameof(Song):
                    {
                        return controller.View("Artist/Song", viewModel);
                    }
                case "Album":
                    {
                        return controller.View("Artist/Album", viewModel);
                    }
                case "Video":
                    {
                        return controller.View("Artist/Video", viewModel);
                    }
                default:
                    {
                        return controller.View("Artist/Detail", viewModel);
                    }
            }
        }
    }
}
