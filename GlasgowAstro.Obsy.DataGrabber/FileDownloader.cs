using GlasgowAstro.Obsy.DataGrabber.Contracts;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Threading.Tasks;

namespace GlasgowAstro.Obsy.DataGrabber
{
    public class FileDownloader : IFileDownloader
    {
        private readonly IConfiguration _config;
        private readonly IHttpClientFactory _httpClientFactory;

        public FileDownloader(IConfiguration config, IHttpClientFactory httpClientFactory)
        {
            _config = config;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> DownloadAsync()
        {
            var dataUrl = _config["ObsDataUrl"];
            var folderName = _config["ObsDataFolderName"];
            var fileName = _config["ObsDataFileName"];
            var tempDir = Path.Combine(Path.GetTempPath(), folderName);            
            var filePath = Path.Combine(tempDir, fileName);

            if (_config["DownloadData"] == "true")
            {
                if (!Directory.Exists(tempDir))
                {
                    Directory.CreateDirectory(tempDir);
                }

                var client = _httpClientFactory.CreateClient();
                var res = await client.GetStreamAsync(dataUrl);

                using (FileStream decompressedFileStream = File.Create(filePath))
                {
                    using (GZipStream decompressionStream = new GZipStream(res, CompressionMode.Decompress))
                    {
                        await decompressionStream.CopyToAsync(decompressedFileStream);
                    }
                }

                if (File.Exists(filePath))
                {
                    return filePath;
                }
            }

            return string.Empty;
        }

    }
}
