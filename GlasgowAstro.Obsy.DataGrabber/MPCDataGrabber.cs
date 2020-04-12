using GlasgowAstro.Obsy.Data;
using GlasgowAstro.Obsy.Data.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Threading.Tasks;

namespace GlasgowAstro.Obsy.DataGrabber
{
    public class MPCDataGrabber
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _config;        
        private readonly IRepository<Asteroid> _asteroidRepository;        

        public MPCDataGrabber(HttpClient client, IConfiguration config, IRepository<Asteroid> asteroidRepository)
        {
            _client = client;
            _config = config;
            _asteroidRepository = asteroidRepository;
        }

        [FunctionName("MPCDataGrabber")]
        public async Task Run([TimerTrigger("0 0 0 * * *", RunOnStartup = true)]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"MPCDataGrabber Timer trigger function executed at: {DateTime.Now}");

            var dataUrl = _config["ObsDataUrl"];
            var folderName = _config["ObsDataFolderName"];
            var fileName = _config["ObsDataFileName"];

            if (_config["DownloadData"] == "true")
            {
                var tempDir = Path.Combine(Path.GetTempPath(), folderName);
                if (!Directory.Exists(tempDir))
                {
                    Directory.CreateDirectory(tempDir);
                }

                var res = await _client.GetStreamAsync(dataUrl);
                log.LogInformation("Got Stream");

                using (FileStream decompressedFileStream = File.Create($"{tempDir}\\{fileName}"))
                {
                    using (GZipStream decompressionStream = new GZipStream(res, CompressionMode.Decompress))
                    {
                        await decompressionStream.CopyToAsync(decompressedFileStream);
                        log.LogInformation("File decompressed");
                    }
                }

                // TEST
                //using (FileStream fs = File.OpenRead($"{tempDir}\\{fileName}"))
                //{
                //    var asteroids = await JsonSerializer.DeserializeAsync<List<Asteroid>>(fs);
                //}

                // TEST
                //var test1 = await _asteroidRepository.FindByIdAsync("5e926c831c9d44000053be96");
                //var test2 = await _asteroidRepository.InsertManyAsync(documents);
            }
        }
    }
}




