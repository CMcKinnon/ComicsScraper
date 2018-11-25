using ComicsScraper.Models;
using ComicsScraper.Providers.Parsers;
using System.Threading.Tasks;

namespace ComicsScraper.Providers
{
    public class ComicProvider : IComicProvider
    {
        private readonly IComicParserFactory comicReaderFactory;
        private readonly INetworkComicReader networkReader;
        private readonly IFileComicReader fileReader;

        public ComicProvider(IComicParserFactory comicReaderFactory,
            INetworkComicReader networkReader,
            IFileComicReader fileReader)
        {
            this.comicReaderFactory = comicReaderFactory;
            this.networkReader = networkReader;
            this.fileReader = fileReader;
        }

        public async Task<Comic> GetComic(string comicname)
        {
            IComicParser parser = comicReaderFactory.GetParser(comicname);

            Comic comic = await fileReader.GetComicFromFile(parser);
            if (comic == null)
            {
                comic = await networkReader.GetComicFromNetwork(parser);
                if (comic?.ImageBytes != null)
                {
                    await fileReader.SaveComicToFile(parser, comic.ImageBytes);
                }
            }

            return comic;
        }
    }
}
