using ComicsScraper.Models;
using ComicsScraper.Providers.Readers;
using System.Net.Http;
using System.Threading.Tasks;

namespace ComicsScraper.Providers
{
    public class ComicProvider : IComicProvider
    {
        private readonly IComicParserFactory comicReaderFactory;
        private readonly IHttpClientFactory httpClientFactory;

        public ComicProvider(IComicParserFactory comicReaderFactory,
            IHttpClientFactory httpClientFactory)
        {
            this.comicReaderFactory = comicReaderFactory;
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<Comic> GetComic(string comicname)
        {
            IComicPasrer parser = comicReaderFactory.GetParser(comicname);
            HttpClient client = httpClientFactory.CreateClient(parser.GetComicGroup());

            string page = await client.GetStringAsync(parser.GetComicBaseUri());

            string uri = await parser.GetComicImageUri(page);

            byte[] imageBytes = null;

            if (uri != null)
            {
                imageBytes = await client.GetByteArrayAsync(uri);
            }

            return new Comic
            {
                ImageBytes = imageBytes,
                MimeType = "image/gif"
            };
        }
    }
}
