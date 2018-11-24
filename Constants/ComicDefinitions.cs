using ComicsScraper.Models;
using System.Collections.Generic;
using System.Linq;

namespace ComicsScraper.Constants
{
    public static class ComicDefinitions
    {
        public static readonly List<ComicDefinition> GoComicsComics = new List<ComicDefinition>
        {
            new ComicDefinition { FullName = "For Better or For Worse", Name = "forbetterorforworse", Extension = ".gif", SortOrder = 1 },
            new ComicDefinition { FullName = "F-Minus", Name = "fminus", Extension = ".gif", SortOrder = 2 },
            new ComicDefinition { FullName = "Frazz", Name = "frazz", Extension = ".gif", SortOrder = 4 },
            new ComicDefinition { FullName = "Over the Hedge", Name = "overthehedge", Extension = ".gif", SortOrder = 5 },
            new ComicDefinition { FullName = "Luann", Name = "luann", Extension = ".gif", SortOrder = 6 },
            new ComicDefinition { FullName = "Overboard", Name = "overboard", Extension = ".gif", SortOrder = 7 },
            new ComicDefinition { FullName = "Pearls Before Swine", Name = "pearlsbeforeswine", Extension = ".gif", SortOrder = 8 },
            new ComicDefinition { FullName = "Heart of the City", Name = "heartofthecity", Extension = ".gif", SortOrder = 9 },
            new ComicDefinition { FullName = "Lio", Name = "lio", Extension = ".gif", SortOrder = 10 },
            new ComicDefinition { FullName = "Doonesbury", Name = "doonesbury", Extension = ".gif", SortOrder = 11 },
            new ComicDefinition { FullName = "Brewster Rockit", Name = "brewsterrockit", Extension = ".gif", SortOrder = 12 },
            new ComicDefinition { FullName = "9 Chickweed Lane", Name = "9chickweedlane", Extension = ".gif", SortOrder = 13 },
            new ComicDefinition { FullName = "Nancy", Name = "nancy", Extension = ".gif", SortOrder = 14 },
            new ComicDefinition { FullName = "Foxtrot", Name = "foxtrot", Extension = ".jpg", SortOrder = 15 },
        };

        public static readonly List<ComicDefinition> DilbertComics = new List<ComicDefinition>
        {
            new ComicDefinition{ FullName = "Dilbert", Name = "dilbert", Extension = ".gif", SortOrder = 3 }
        };

        public static readonly List<ComicDefinition> SortedComics;

        static ComicDefinitions()
        {
            SortedComics = new List<ComicDefinition>();
            SortedComics.AddRange(GoComicsComics);
            SortedComics.AddRange(DilbertComics);
            SortedComics = SortedComics.OrderBy(c => c.SortOrder).ToList();
        }
    }
}
