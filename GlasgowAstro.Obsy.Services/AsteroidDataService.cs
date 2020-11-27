using AutoMapper;
using GlasgowAstro.Obsy.Data.Abstractions;
using GlasgowAstro.Obsy.Data.Models;
using GlasgowAstro.Obsy.Services.Abstractions;
using GlasgowAstro.Obsy.Services.Models;
using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;

namespace GlasgowAstro.Obsy.Services
{
    public class AsteroidDataService : IAsteroidDataService
    {
        private readonly IMongoRepository<Asteroid> _asteroidRepository;
        private readonly IMapper _mapper;

        public AsteroidDataService(IMongoRepository<Asteroid> asteroidRepository, IMapper mapper)
        {
            _asteroidRepository = asteroidRepository;
            _mapper = mapper;
        }

        public async Task<AsteroidDataResponse> FindAsteroidByNameAsync(string name)
        {            
            var filter = Builders<Asteroid>.Filter.Eq(x => x.Name, name);
            var asteroidRepoResult = await _asteroidRepository.FindDocumentAsync(filter);

            if (asteroidRepoResult == null || asteroidRepoResult?.Count < 1)
                return null; // ??
            
            var asteroidResponse = _mapper.Map<AsteroidDataResponse>(asteroidRepoResult.First()); //TODO Move .First() elsewhere
            return asteroidResponse;
        }
    }
}
