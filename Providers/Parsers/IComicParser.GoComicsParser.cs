using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using ComicsScraper.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ComicsScraper.Providers.Parsers
{
    public class GoComicsParser : IComicParser
    {
        private ComicDefinition comicDefinition;
        private readonly DateTime today = DateTime.Today;

        public void SetComic(ComicDefinition comicDefinition) => this.comicDefinition = comicDefinition;

        public string GetComicGroup() => comicDefinition.Group;

        public string GetComicFilename() => $"{comicDefinition.Name}-{today:yyyy-MM-dd}{comicDefinition.Extension}";

        public string GetComicBaseUri()
        {
            return $"{comicDefinition.Name}";
        }

        public async Task<string> GetComicImageUri(string page)
        {
            HtmlParser parser = new();
            IHtmlDocument doc = await parser.ParseAsync(page);

            IElement img = doc.QuerySelectorAll("section[data-sentry-component=ShowComicViewer] button > img").FirstOrDefault();
            return img != null ? img.GetAttribute("src") : null;
        }
    }
}
