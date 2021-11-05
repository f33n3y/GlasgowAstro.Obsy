using AutoMapper;
using GlasgowAstro.Obsy.Api.Models.Request;
using GlasgowAstro.Obsy.Api.Models.Response;
using GlasgowAstro.Obsy.Services.Models.Request;
using GlasgowAstro.Obsy.Services.Models.Response;

namespace GlasgowAstro.Obsy.Api.MapperProfiles
{
    public class OrbitProfile : Profile
    {
        public OrbitProfile()
        {
            CreateMap<OrbitRequest, AsteroidOrbitDataRequest>(); // ApiRequestModel > ServiceRequestModel
            //CreateMap<AsteroidObservation, Observation>();
            CreateMap<AsteroidOrbitDataResponse, OrbitResponse>(); // ServiceResponseModel > ApiResponseModel              
        }
    }
}
