using ComicsScraper.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace ComicsScraper.Data
{
    public class ComicDefinitions : IComicDefinitions
    {
        private readonly IList<ComicDefinition> comicDefinitions;

        public ComicDefinitions(IConfiguration configuration) => comicDefinitions = configuration.GetSection("Comics").Get<IList<ComicDefinition>>().OrderBy(c => c.SortOrder).ToList();

        public ComicDefinition GetComicDefinition(string comicnamme) => comicDefinitions.FirstOrDefault(c => c.Name == comicnamme);

        public IList<ComicDefinition> GetSortedComics() => comicDefinitions;
    }
}
