using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Music.Extensions;
using Website.Models;

namespace Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;

        public HomeController(ILogger<HomeController> logger)
        {
            this.logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Download(string id)
        {
            var song = DataProvider.Songs
                .Find(s => s.Id.Equals(id));

            return song == null ? NotFound() : View(song);
        }

        public IActionResult Search(string id)
        {
            var artist = DataProvider.Artists
                .Find(a => a.VietnameseName.Equals(id));

            var song = DataProvider.Songs
                .Find(s => s.Id.Equals(id));

            return song == null ? NotFound() : View(song);
        }
    }
}
