using ComicsScraper.Constants;
using ComicsScraper.Models;
using ComicsScraper.Providers.Readers;
using System;
using System.Linq;

namespace ComicsScraper.Providers
{
    public class ComicReaderFactory : IComicReaderFactory
    {
        private readonly IServiceProvider services;

        public ComicReaderFactory(IServiceProvider services)
        {
            this.services = services;
        }

        public IComicReader GetReader(string comicname)
        {
            IComicReader reader = null;

            ComicDefinition definition = ComicDefinitions.GoComicsComics.FirstOrDefault(d => d.Name == comicname);
            if (definition != null)
            {
                reader = (IComicReader)services.GetService(typeof(GoComicsReader));
            }
            else
            {
                definition = ComicDefinitions.DilbertComics.FirstOrDefault(d => d.Name == comicname);
                if (definition != null)
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
