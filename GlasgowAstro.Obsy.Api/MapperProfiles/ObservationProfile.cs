using AutoMapper;
using GlasgowAstro.Obsy.Api.Models.Request;
using GlasgowAstro.Obsy.Services.Models.Request;

namespace GlasgowAstro.Obsy.Api.MapperProfiles
{
    public class ObservationProfile : Profile
    {
        public ObservationProfile()
        {
            CreateMap<ObservationRequest, ObservationServiceRequest>();
        }
    }
}
