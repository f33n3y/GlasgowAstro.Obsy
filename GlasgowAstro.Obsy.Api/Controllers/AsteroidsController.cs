using AutoMapper;
using GlasgowAstro.Obsy.Api.Models.Request;
using GlasgowAstro.Obsy.Services.Abstractions;
using GlasgowAstro.Obsy.Services.Models.Request;
using GlasgowAstro.Obsy.Services.Models.Response;
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
        private readonly IAsteroidDataService _asteroidService;
        private readonly IAsteroidObservationService _observationService;
        private readonly IMapper _mapper;

        public AsteroidsController(IAsteroidDataService asteroidService, IAsteroidObservationService observationService, IMapper mapper)
        {
            _asteroidService = asteroidService;
            _observationService = observationService;
            _mapper = mapper;
        }

        // GET api/asteroids/hello
        [HttpGet("hello")]
        public string HelloFriend()
        {
            return "Hello friend";
        }

        // GET api/asteroids/{name}
        //[HttpGet("{name}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<AsteroidDataResponse>> FindAsteroidAsync(string name) // TODO validation + request model
        //{
        //    try
        //    {
        //        var asteroid = await _asteroidService.FindAsteroidByNameAsync(name);

        //        if (asteroid == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(asteroid);
        //    }
        //    catch (Exception e)
        //    {
        //        // TODO logging...
        //        return NotFound();
        //    }
        //}

        // GET api/asteroids/observations
        [HttpGet("/observations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> FindObservationsAsync([FromQuery] ObservationRequest obsySearchRequest) 
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var serviceRequestModel = _mapper.Map<ObservationServiceRequest>(obsySearchRequest);

                // TODO Return response model 
                var observation = await _observationService.GetObservationsAsync(serviceRequestModel);

                if (observation == null)
                {
                    return NotFound();
                }

                return Ok(observation.RawTest);

            }
            catch (Exception e)
            {
                // TODO logging ...
                return NotFound();
            }
        }


    }
}
