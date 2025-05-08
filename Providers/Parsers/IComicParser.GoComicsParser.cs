using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using ComicsScraper.Models;
using System;
using System.Linq;
using System.Text.Json.Nodes;
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

            IElement img = doc.QuerySelectorAll("section[class*=ShowComicViewer] script").FirstOrDefault();
            JsonObject json = JsonNode.Parse(img?.InnerHtml) as JsonObject;
            return json != null ? json["contentUrl"].ToString() : null;
        }
    }
}
