using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using ComicsScraper.Models;
using System;
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
            string todayString = today.ToString("yyyy/MM/dd");
            return $"{comicDefinition.Name}/{todayString}";
        }

        public async Task<string> GetComicImageUri(string page)
        {
            HtmlParser parser = new();
            IHtmlDocument doc = await parser.ParseAsync(page);

            IElement img = doc.QuerySelector("picture.item-comic-image img.img-fluid");
            return img.GetAttribute("src");
        }
    }
}
