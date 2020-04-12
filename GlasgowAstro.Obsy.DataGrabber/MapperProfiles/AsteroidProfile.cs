using AutoMapper;

namespace GlasgowAstro.Obsy.DataGrabber.MapperProfiles
{
    public class AsteroidProfile : Profile
    {
        public AsteroidProfile()
        {
            CreateMap<Models.Asteroid, Data.Models.Asteroid>();
        }
    }
}
