using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using ComicsScraper.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace ComicsScraper.Providers.Readers
{
    public class DilbertReader : IComicReader
    {
        private ComicDefinition comicDefinition;
        private readonly IHttpClientFactory httpClientFactory;

        public DilbertReader(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public void SetComic(ComicDefinition comicDefinition)
        {
            this.comicDefinition = comicDefinition;
        }

        public async Task<Comic> GetComic()
        {
            HttpClient client = httpClientFactory.CreateClient("Dilbert");
            string page = await client.GetStringAsync("");

            HtmlParser parser = new HtmlParser();
            IHtmlDocument doc = await parser.ParseAsync(page);

            IElement img = doc.QuerySelector("div.img-comic-container img");
            string src = img.GetAttribute("src");

            byte[] imageBytes = null;

            if (src != null)
            {
                if (src.StartsWith("//asset"))
                {
                    src = $"https:{src}";
                }
                imageBytes = await client.GetByteArrayAsync(src);
            }

            return new Comic
            {
                ImageBytes = imageBytes,
                MimeType = "image/gif"
            };
        }
    }
}
