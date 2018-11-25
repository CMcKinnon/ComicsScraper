using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using ComicsScraper.Models;
using System;
using System.Threading.Tasks;

namespace ComicsScraper.Providers.Readers
{
    public class GoComicsParser : IComicPasrer
    {
        private ComicDefinition comicDefinition;

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
            string today = DateTime.Today.AddDays(-1).ToString("yyyy/MM/dd");
            return $"{comicDefinition.Name}/{today}";
        }

        public async Task<string> GetComicImageUri(string page)
        {
            HtmlParser parser = new HtmlParser();
            IHtmlDocument doc = await parser.ParseAsync(page);

            IElement img = doc.QuerySelector("picture.item-comic-image img.img-fluid");
            return img.GetAttribute("src");
        }
    }
}
