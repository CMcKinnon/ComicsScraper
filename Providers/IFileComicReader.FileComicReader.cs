using ComicsScraper.Models;
using ComicsScraper.Providers.Parsers;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace ComicsScraper.Providers
{
    public class FileComicReader : IFileComicReader
    {
        private readonly string comicDirectory;

        public FileComicReader(IConfiguration configuration)
        {
            comicDirectory = configuration.GetSection("ComicImageDirectory").Get<string>();
        }

        public async Task<Comic> GetComicFromFile(IComicParser parser)
        {
            string filename = parser.GetComicFilename();
            string fullPath = Path.Combine(comicDirectory, filename);
            string mimetype = filename.EndsWith(".gif") ? "gif" : "jpeg";

            if (File.Exists(fullPath))
            {
                return new Comic
                {
                    MimeType = $"image/{mimetype}",
                    ImageBytes = await File.ReadAllBytesAsync(fullPath)
                };
            }

            return null;
        }

        public async Task SaveComicToFile(IComicParser parser, byte[] imageBytes)
        {
            string filename = parser.GetComicFilename();
            string fullPath = Path.Combine(comicDirectory, filename);
            await File.WriteAllBytesAsync(fullPath, imageBytes);
        }
    }
}
