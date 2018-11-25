using ComicsScraper.Models;
using ComicsScraper.Providers.Parsers;
using System.Net.Http;
using System.Threading.Tasks;

namespace ComicsScraper.Providers
{
    public class NetworkComicReader : INetworkComicReader
    {
        private readonly IHttpClientFactory httpClientFactory;

        public NetworkComicReader(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<Comic> GetComicFromNetwork(IComicParser parser)
        {
            HttpClient client = httpClientFactory.CreateClient(parser.GetComicGroup());

            string page = await client.GetStringAsync(parser.GetComicBaseUri());

            string uri = await parser.GetComicImageUri(page);

            byte[] imageBytes = null;

            if (uri != null)
            {
                imageBytes = await client.GetByteArrayAsync(uri);
            }

            string filename = parser.GetComicFilename();
            string mimetype = filename.EndsWith(".gif") ? "gif" : "jpeg";

            return new Comic
            {
                ImageBytes = imageBytes,
                MimeType = $"image/{mimetype}"
            };
        }
    }
}
