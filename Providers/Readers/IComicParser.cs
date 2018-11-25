using ComicsScraper.Models;
using System.Threading.Tasks;

namespace ComicsScraper.Providers.Readers
{
    public interface IComicPasrer
    {
        void SetComic(ComicDefinition comicDefinition);
        string GetComicBaseUri();
        Task<string> GetComicImageUri(string page);
        string GetComicGroup();
    }
}
