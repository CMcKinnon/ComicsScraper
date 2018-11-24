using ComicsScraper.Providers.Readers;

namespace ComicsScraper.Providers
{
    public interface IComicReaderFactory
    {
        IComicReader GetReader(string comicname);
    }
}
