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

        public void SetComic(ComicDefinition comicDefinition)
        {
            this.comicDefinition = comicDefinition;
        }

        public string GetComicGroup()
        {
            return comicDefinition.Group;
        }

        public string GetComicBaseUri()
        {
            return "";
        }

        public string GetComicFilename()
        {
            return $"{comicDefinition.Name}-{today.ToString("yyyy-MM-dd")}{comicDefinition.Extension}";
        }

        public async Task<string> GetComicImageUri(string page)
        {
            HtmlParser parser = new HtmlParser();
            IHtmlDocument doc = await parser.ParseAsync(page);

            IElement img = doc.QuerySelector("div.img-comic-container img");
            string src = img.GetAttribute("src");
            if (src != null)
            {
                if (src.StartsWith("//asset"))
                {
                    src = $"https:{src}";
                }
            }

            return src;
        }
    }
}
