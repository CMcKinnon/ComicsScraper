using ComicsScraper.Constants;
using ComicsScraper.Data;
using ComicsScraper.Models;
using ComicsScraper.Providers.Parsers;
using System;

namespace ComicsScraper.Providers
{
    public class ComicParserFactory : IComicParserFactory
    {
        private readonly IServiceProvider services;
        private readonly IComicDefinitions comicDefinitions;

        public ComicParserFactory(IServiceProvider services, IComicDefinitions comicDefinitions)
        {
            this.services = services;
            this.comicDefinitions = comicDefinitions;
        }

        public IComicParser GetParser(string comicname)
        {
            IComicParser reader = null;

            ComicDefinition definition = comicDefinitions.GetComicDefinition(comicname);
            if (definition != null)
            {
                if (definition.Group == ComicGroups.GoComics)
                {
                    reader = (IComicParser)services.GetService(typeof(GoComicsParser));
                }
                else if (definition.Group == ComicGroups.Dilbert)
                {
                    reader = (IComicParser)services.GetService(typeof(DilbertParser));
                }
            }
            if (definition == null || reader == null)
            {
                throw new Exception($"Can't get definition or reader for comic {comicname}");
            }

            reader.SetComic(definition);

            return reader;
        }
    }
}
