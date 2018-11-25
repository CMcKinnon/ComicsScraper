using ComicsScraper.Data;
using ComicsScraper.Models;
using ComicsScraper.Providers.Readers;
using System;

namespace ComicsScraper.Providers
{
    public class ComicReaderFactory : IComicReaderFactory
    {
        private readonly IServiceProvider services;
        private readonly IComicDefinitions comicDefinitions;

        public ComicReaderFactory(IServiceProvider services, IComicDefinitions comicDefinitions)
        {
            this.services = services;
            this.comicDefinitions = comicDefinitions;
        }

        public IComicReader GetReader(string comicname)
        {
            IComicReader reader = null;

            ComicDefinition definition = comicDefinitions.GetComicDefinition(comicname);
            if (definition != null)
            {
                if (definition.Group == "GoComics")
                {
                    reader = (IComicReader)services.GetService(typeof(GoComicsReader));
                }
                else if (definition.Group == "Dilbert")
                {
                    reader = (IComicReader)services.GetService(typeof(DilbertReader));
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
