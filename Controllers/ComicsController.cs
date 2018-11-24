using ComicsScraper.Models;
using ComicsScraper.Providers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ComicsScraper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComicsController : ControllerBase
    {
        private readonly IComicProvider comicProvider;

        public ComicsController(IComicProvider comicProvider)
        {
            this.comicProvider = comicProvider;
        }

        [HttpGet("{comicname}")]
        public async Task<IActionResult> GetComic(string comicname)
        {
            Comic comic = await comicProvider.GetComic(comicname);
            return File(comic.ImageBytes, comic.MimeType);
        }
    }
}