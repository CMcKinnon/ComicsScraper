using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using ComicsScraper.Models;
using System;
using System.Threading.Tasks;

namespace ComicsScraper.Providers.Parsers
{
    public class DilbertParser : IComicParser
    {
        private ComicDefinition comicDefinition;
        private readonly DateTime today = DateTime.Today;

        public void SetComic(ComicDefinition comicDefinition) => this.comicDefinition = comicDefinition;

        public string GetComicGroup() => comicDefinition.Group;

        public string GetComicBaseUri() => "";

        public string GetComicFilename() => $"{comicDefinition.Name}-{today:yyyy-MM-dd}{comicDefinition.Extension}";

        public async Task<string> GetComicImageUri(string page)
        {
            HtmlParser parser = new();
            IHtmlDocument doc = await parser.ParseAsync(page);

            IElement img = doc.QuerySelector("div.img-comic-container img");
            string src = img.GetAttribute("src");
            if (src?.StartsWith("//asset") == true)
            {
                src = $"https:{src}";
            }

            return src;
        }
    }
}
