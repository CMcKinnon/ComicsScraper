using ComicsScraper.Models;
using ComicsScraper.Providers.Readers;
using System.Threading.Tasks;

namespace ComicsScraper.Providers
{
    public class ComicProvider : IComicProvider
    {
        private readonly IComicReaderFactory comicReaderFactory;

        public ComicProvider(IComicReaderFactory comicReaderFactory)
        {
            this.comicReaderFactory = comicReaderFactory;
        }

        public async Task<Comic> GetComic(string comicname)
        {
            IComicReader reader = comicReaderFactory.GetReader(comicname);
            return await reader.GetComic();
        }
    }
}
