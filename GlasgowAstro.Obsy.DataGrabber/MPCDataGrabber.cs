using Microsoft.Azure.WebJobs;
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
        //Move to appsetting
        private readonly string FileUrl = "https://minorplanetcenter.net/Extended_Files/mpcorb_extended.json.gz";

        public MPCDataGrabber(HttpClient client)
        {
            _client = client;
        }

        [FunctionName("MPCDataGrabber")]
        public async Task Run([TimerTrigger("0 0 0 * * *", RunOnStartup = true)]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"---> MPCDataGrabber Timer trigger function executed at: {DateTime.Now}");

            var tempDir = Path.Combine(Path.GetTempPath(), "MPCData");
            if (!Directory.Exists(tempDir))
            {
                Directory.CreateDirectory(tempDir);
            }

            var res = await _client.GetStreamAsync(FileUrl);

            log.LogInformation("---> Got Stream");

            using (FileStream decompressedFileStream = File.Create(tempDir + "\\test.json"))
            {
                using (GZipStream decompressionStream = new GZipStream(res, CompressionMode.Decompress))
                {
                    await decompressionStream.CopyToAsync(decompressedFileStream);
                    log.LogInformation("---> File decompressed");
                }
            }
        }
    }
}
