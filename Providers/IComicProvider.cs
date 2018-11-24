using ComicsScraper.Models;
using System.Threading.Tasks;

namespace ComicsScraper.Providers
{
    public interface IComicProvider
    {
        Task<Comic> GetComic(string comicname);
    }
}
