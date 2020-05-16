using AutoMapper;
using GlasgowAstro.Obsy.DataGrabber.Models;

namespace GlasgowAstro.Obsy.DataGrabber.MapperProfiles
{
    public class AsteroidProfile : Profile
    {
        public AsteroidProfile()
        {
            CreateMap<AsteroidReadModel, Data.Models.Asteroid>();
        }
    }
}
