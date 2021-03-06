﻿using AutoMapper;
using GlasgowAstro.Obsy.Api.Models.Request;
using GlasgowAstro.Obsy.Api.Models.Response;
using GlasgowAstro.Obsy.Services.Models.Request;
using GlasgowAstro.Obsy.Services.Models.Response;

namespace GlasgowAstro.Obsy.Api.MapperProfiles
{
    public class ObservationProfile : Profile
    {
        public ObservationProfile()
        {
            CreateMap<ObservationRequest, AsteroidObservationServiceRequest>();
            CreateMap<AsteroidObservation, Observation>();
            CreateMap<AsteroidObservationServiceResponse, ObservationResponse>();                
        }
    }
}
