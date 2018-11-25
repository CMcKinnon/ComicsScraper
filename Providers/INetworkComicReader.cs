using ComicsScraper.Models;
using ComicsScraper.Providers.Parsers;
using System.Threading.Tasks;

namespace ComicsScraper.Providers
{
    public interface INetworkComicReader
    {
        Task<Comic> GetComicFromNetwork(IComicParser parser);
    }
}
