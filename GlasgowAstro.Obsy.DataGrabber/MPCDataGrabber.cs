using AutoMapper;
using GlasgowAstro.Obsy.Data;
using GlasgowAstro.Obsy.Data.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace GlasgowAstro.Obsy.DataGrabber
{
    public class MPCDataGrabber
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _config;
        private readonly IRepository<Data.Models.Asteroid> _asteroidRepository;
        private readonly IMapper _mapper;

        public MPCDataGrabber(HttpClient client, IConfiguration config, IRepository<Data.Models.Asteroid> asteroidRepository,
            IMapper mapper)
        {
            _client = client;
            _config = config;
            _asteroidRepository = asteroidRepository;
            _mapper = mapper;
        }

        [FunctionName("MPCDataGrabber")]
        public async Task Run([TimerTrigger("0 0 0 * * *", RunOnStartup = true)]TimerInfo myTimer, ILogger log)
        {
            // Download and decompress file. TODO Move to class.
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

                var res = await _client.GetStreamAsync(dataUrl);
                log.LogInformation("Got Stream");

                using (FileStream decompressedFileStream = File.Create(filePath))
                {
                    using (GZipStream decompressionStream = new GZipStream(res, CompressionMode.Decompress))
                    {
                        await decompressionStream.CopyToAsync(decompressedFileStream);
                        log.LogInformation("File decompressed");
                    }
                }
            }

            // Read file, deserialize, map and store. TODO Move to class.
            IEnumerable<Models.Asteroid> asteroids;
            using (FileStream fs = File.OpenRead($"{tempDir}\\{fileName}"))
            {
                asteroids = await JsonSerializer.DeserializeAsync<List<Models.Asteroid>>(fs); // Do this in batches?                
                log.LogInformation("File deserialized");
                ICollection<Asteroid> documents = _mapper.Map<IEnumerable<Models.Asteroid>, IEnumerable<Data.Models.Asteroid>>(asteroids).ToList();
                //await _asteroidRepository.InsertManyAsync(documents);
            }
        }
    }
}




