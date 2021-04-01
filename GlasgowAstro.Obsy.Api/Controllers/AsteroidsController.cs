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
        private readonly IAsteroidService _observationService;
        private readonly IMapper _mapper;

        public AsteroidsController(IAsteroidDataService asteroidService, IAsteroidService observationService, IMapper mapper)
        {
            _observationService = observationService;
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
                var serviceResponse = await _observationService.GetObservationsAsync(serviceRequestModel);                

                if (serviceResponse == null || serviceResponse?.Observations.Count < 1)
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


    }
}
