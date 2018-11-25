using ComicsScraper.Models;
using System.Threading.Tasks;

namespace ComicsScraper.Providers.Parsers
{
    public interface IComicParser
    {
        void SetComic(ComicDefinition comicDefinition);
        string GetComicBaseUri();
        Task<string> GetComicImageUri(string page);
        string GetComicGroup();
        string GetComicFilename();
    }
}
