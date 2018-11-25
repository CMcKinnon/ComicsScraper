using ComicsScraper.Providers.Readers;

namespace ComicsScraper.Providers
{
    public interface IComicParserFactory
    {
        IComicPasrer GetParser(string comicname);
    }
}
