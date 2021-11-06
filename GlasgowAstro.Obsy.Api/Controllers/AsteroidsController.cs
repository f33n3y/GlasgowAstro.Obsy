using AutoMapper;
using GlasgowAstro.Obsy.Api.Models.Request;
using GlasgowAstro.Obsy.Api.Models.Response;
using GlasgowAstro.Obsy.Services.Abstractions;
using GlasgowAstro.Obsy.Services.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GlasgowAstro.Obsy.Api.Controllers
{

    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    public class AsteroidsController : ControllerBase
    {
        private readonly IAsteroidService _asteroidService;
        private readonly IMapper _mapper;

        public AsteroidsController(IAsteroidService observationService, IMapper mapper)
        {
            _asteroidService = observationService;
            _mapper = mapper;
        }

        // GET api/asteroids/observations
        [HttpGet("/observations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ObservationResponse>> FindObservationsAsync([FromQuery] ObservationRequest obsySearchRequest) 
        {
            try
            {
                var serviceRequestModel = _mapper.Map<AsteroidObservationDataRequest>(obsySearchRequest);                
                var serviceResponse = await _asteroidService.GetObservationsAsync(serviceRequestModel);                

                if (serviceResponse is null || serviceResponse?.Observations.Count < 1)
                {
                    return NotFound();
                }

                var observationResponse = _mapper.Map<ObservationResponse>(serviceResponse);
                return Ok(observationResponse);

            }
            catch (Exception e)
            {
                // TODO logging ...
                return NotFound();
            }
        }

        [HttpGet("/orbits")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OrbitResponse>> FindOrbitDataAsync([FromQuery] OrbitRequest orbitSearchRequest)
        {
            try
            {
                var serviceRequestModel = _mapper.Map<AsteroidOrbitDataRequest>(orbitSearchRequest);
                var serviceResponse = await _asteroidService.GetOrbitDataAsync(serviceRequestModel);

                if (serviceResponse is null || !string.IsNullOrWhiteSpace(serviceResponse.OrbitData?.AbsoluteMagnitude))
                {
                    return NotFound();
                }

                var orbitResponse = _mapper.Map<OrbitResponse>(serviceResponse);
                return Ok(orbitResponse);
            } 
            catch (Exception e)
            {
                // TODO logging ....
                return NotFound();
            }
        }


    }
}
