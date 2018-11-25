using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using ComicsScraper.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ComicsScraper.Providers.Readers
{
    public class GoComicsReader : IComicReader
    {
        private ComicDefinition comicDefinition;
        private readonly IHttpClientFactory httpClientFactory;

        public GoComicsReader(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public void SetComic(ComicDefinition comicDefinition)
        {
            this.comicDefinition = comicDefinition;
        }

        public async Task<Comic> GetComic()
        {
            HttpClient client = httpClientFactory.CreateClient("GoComics");
            string today =  DateTime.Today.AddDays(-1).ToString("yyyy/MM/dd");
            string page = await client.GetStringAsync($"{this.comicDefinition.Name}/{today}");

            HtmlParser parser = new HtmlParser();
            IHtmlDocument doc = await parser.ParseAsync(page);

            IElement img = doc.QuerySelector("picture.item-comic-image img.img-fluid");
            string src = img.GetAttribute("src");

            byte[] imageBytes = null;

            if (src != null)
            {
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
