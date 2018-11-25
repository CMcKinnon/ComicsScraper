using ComicsScraper.Data;
using ComicsScraper.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ComicsScraper.Controllers
{
    public class HomeController : Controller
    {
        private readonly IComicDefinitions comicDefinitions;

        public HomeController(IComicDefinitions comicDefinitions)
        {
            this.comicDefinitions = comicDefinitions;
        }

        public IActionResult Index()
        {
            return View(comicDefinitions.GetSortedComics());
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
