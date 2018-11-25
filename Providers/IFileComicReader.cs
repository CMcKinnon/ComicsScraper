using ComicsScraper.Models;
using ComicsScraper.Providers.Parsers;
using System.Threading.Tasks;

namespace ComicsScraper.Providers
{
    public interface IFileComicReader
    {
        Task<Comic> GetComicFromFile(IComicParser parser);
        Task SaveComicToFile(IComicParser parser, byte[] imageBytes);
    }
}
