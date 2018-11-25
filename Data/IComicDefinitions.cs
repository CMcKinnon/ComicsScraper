using ComicsScraper.Models;
using System.Collections.Generic;

namespace ComicsScraper.Data
{
    public interface IComicDefinitions
    {
        ComicDefinition GetComicDefinition(string comicnamme);
        IList<ComicDefinition> GetSortedComics();
    }
}
