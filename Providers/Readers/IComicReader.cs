using ComicsScraper.Models;
using System.Threading.Tasks;

namespace ComicsScraper.Providers.Readers
{
    public interface IComicReader
    {
        void SetComic(ComicDefinition comicDefinition);
        Task<Comic> GetComic();
    }
}
