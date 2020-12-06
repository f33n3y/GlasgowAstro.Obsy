using AutoMapper;
using GlasgowAstro.Obsy.Data.Models;
using GlasgowAstro.Obsy.Services.Models.Response;

namespace GlasgowAstro.Obsy.Services.MapperProfiles
{
    public class AsteroidProfile : Profile
    {
        public AsteroidProfile()
        {
            CreateMap<Asteroid, AsteroidDataResponse>();
        }
    }
}
