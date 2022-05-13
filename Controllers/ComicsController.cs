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

        public ComicsController(IComicProvider comicProvider) => this.comicProvider = comicProvider;

        [HttpGet("{comicname}")]
        public async Task<IActionResult> GetComic(string comicname)
        {
            try
            {
                Comic comic = await comicProvider.GetComic(comicname);
                if (comic.ImageBytes == null)
                {
                    return NotFound();
                }
                return File(comic.ImageBytes, comic.MimeType);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }
    }
}