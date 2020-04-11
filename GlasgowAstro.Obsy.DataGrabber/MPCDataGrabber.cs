using GlasgowAstro.Obsy.DataGrabber.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using GlasgowAstro.Obsy.Data;
using Microsoft.AspNetCore.Mvc.Formatters.Internal;

namespace GlasgowAstro.Obsy.DataGrabber
{
    public class MPCDataGrabber
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _config;        

        public MPCDataGrabber(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _config = configuration;
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

                //using (FileStream fs = File.OpenRead($"{tempDir}\\{fileName}"))
                //{
                //    var asteroids = await JsonSerializer.DeserializeAsync<List<Asteroid>>(fs);
                //}
            }

        }
    }
}




