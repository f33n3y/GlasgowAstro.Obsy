using GlasgowAstro.Obsy.DataGrabber.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace GlasgowAstro.Obsy.DataGrabber
{
    public class MPCDataGrabber
    {   
        private readonly string DataUrl = Environment.GetEnvironmentVariable("ObsDataUrl");
        private readonly string FolderName = Environment.GetEnvironmentVariable("ObsDataFolderName");
        private readonly string FileName = Environment.GetEnvironmentVariable("ObsDataFileName");
        private readonly HttpClient _client;

        public MPCDataGrabber(HttpClient client)
        {
            _client = client;
        }

        [FunctionName("MPCDataGrabber")]
        public async Task Run([TimerTrigger("0 0 0 * * *", RunOnStartup = true)]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"MPCDataGrabber Timer trigger function executed at: {DateTime.Now}");

            var tempDir = Path.Combine(Path.GetTempPath(), FolderName);

            if (!Directory.Exists(tempDir))
            {
                Directory.CreateDirectory(tempDir);
            }

            var res = await _client.GetStreamAsync(DataUrl);
            log.LogInformation("Got Stream");

            using (FileStream decompressedFileStream = File.Create($"{tempDir}\\{FileName}"))
            {
                using (GZipStream decompressionStream = new GZipStream(res, CompressionMode.Decompress))
                {
                    await decompressionStream.CopyToAsync(decompressedFileStream);
                    log.LogInformation("File decompressed");
                }
            }

            // Read file and deserialize 
            //using (FileStream fs = File.OpenRead($"{tempDir}\\{FileName}"))
            //{
            //    var asteroids = await JsonSerializer.DeserializeAsync<List<Asteroid>>(fs);
            //}

            // Store...
        }
    }
}
