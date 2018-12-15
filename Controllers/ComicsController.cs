using ComicsScraper.Models;
using ComicsScraper.Providers;
using Microsoft.AspNetCore.Mvc;
using System;
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
            try
            {
                Comic comic = await comicProvider.GetComic(comicname);
                return File(comic.ImageBytes, comic.MimeType);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpGet("{date}")]
        public IActionResult AreComicsDownloaded(DateTime date)
        {
            return NotFound();
        }
    }
}