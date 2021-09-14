using Microsoft.AspNetCore.Mvc;
using Music.Extensions;
using Website.Models;
/// <summary>
/// ngrok http https://localhost:44397 -host-header="localhost:44397"
/// </summary>
namespace Website.Controllers
{
    public class SongController : Controller
    {
        public IActionResult Detail(string id)
        {
            var song = DataProvider.Songs.Find(s => s.Id.Equals(id));
            return song == null ? NotFound() : View(new SongViewModel.Detail(song));
        }
    }
}