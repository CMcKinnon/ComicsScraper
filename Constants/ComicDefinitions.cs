using ComicsScraper.Models;
using System.Collections.Generic;

namespace ComicsScraper.Constants
{
    public class ComicDefinitions
    {
        public static readonly List<ComicDefinition> GoComicsComics = new List<ComicDefinition>
        {
            new ComicDefinition { FullName = "For Better or For Worse", Name = "forbetterorforworse", Extension = ".gif" }
        };

        public static readonly List<ComicDefinition> DilbertComics = new List<ComicDefinition>
        {
            new ComicDefinition{ FullName = "Dilbert", Name = "dilbert", Extension = ".gif" }
        };
    }
}
