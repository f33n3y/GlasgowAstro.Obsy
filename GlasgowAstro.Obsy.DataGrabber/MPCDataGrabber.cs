using AutoMapper;
using GlasgowAstro.Obsy.Data.Abstractions;
using GlasgowAstro.Obsy.Data.Models;
using GlasgowAstro.Obsy.DataGrabber.Contracts;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace GlasgowAstro.Obsy.DataGrabber
{
    public class MPCDataGrabber
    {
        private readonly IConfiguration _config;
        private readonly IMongoRepository<Data.Models.Asteroid> _asteroidRepository;
        private readonly IMapper _mapper;
        private readonly IFileDownloader _downloader;

        public MPCDataGrabber(IConfiguration config, IMongoRepository<Data.Models.Asteroid> asteroidRepository,
            IMapper mapper, IFileDownloader downloader)
        {
            _config = config;
            _asteroidRepository = asteroidRepository;
            _mapper = mapper;
            _downloader = downloader;
        }

        [FunctionName("MPCDataGrabber")]
        public async Task Run([TimerTrigger("0 0 0 * * *", RunOnStartup = true)]TimerInfo myTimer, ILogger log)
        {
            var filePath = await _downloader.DownloadAsync();
            log.LogInformation("File downloaded");

            if (!string.IsNullOrWhiteSpace(filePath))
            {
                // Read file, deserialize, map and store. TODO Move to class.
                IEnumerable<Models.Asteroid> asteroids;
                using (FileStream fileStream = File.OpenRead(filePath))
                {
                    asteroids = await JsonSerializer.DeserializeAsync<List<Models.Asteroid>>(fileStream);            
                    log.LogInformation("File deserialized");
                }

                // TODO Fix float accuracy issue, TODO exception handling
                ICollection<Asteroid> documents = _mapper.Map<IEnumerable<Models.Asteroid>, IEnumerable<Asteroid>>(asteroids).ToList();

                var documentsToUpsert = new List<WriteModel<Asteroid>>();
                foreach (var doc in documents)
                {
                    var filter = Builders<Asteroid>.Filter.Eq(x => x.CompoId, doc.CompoId);
                    documentsToUpsert.Add(new ReplaceOneModel<Asteroid>(filter, doc)
                    {
                        IsUpsert = true
                    });
                }
                await _asteroidRepository.BulkWriteAsync(documentsToUpsert);
                log.LogInformation("Bulk write completed");

                // NOTE: Clear collection and rebuild it until bulk upsert works properly
                //await _asteroidRepository.DeleteManyAsync(Builders<Asteroid>.Filter.Empty);
                //log.LogInformation("Collection cleared");
                //await _asteroidRepository.InsertManyAsync(documents);
                //log.LogInformation("Collection rebuilt");
            }
        }
    }
}




