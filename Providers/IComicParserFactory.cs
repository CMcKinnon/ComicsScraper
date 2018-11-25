using ComicsScraper.Providers.Parsers;

namespace ComicsScraper.Providers
{
    public interface IComicParserFactory
    {
        IComicParser GetParser(string comicname);
    }
}
