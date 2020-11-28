using GlasgowAstro.Obsy.Services.Abstractions;
using GlasgowAstro.Obsy.Services.Models;
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

        public AsteroidsController(IAsteroidDataService asteroidService, IAsteroidObservationService observationService)
        {
            _asteroidService = asteroidService;
            _observationService = observationService;
        }

        // GET api/asteroids/hello
        [HttpGet("hello")]
        public string HelloFriend()
        {
            return "Hello friend";
        }

        // GET api/asteroids/{name}
        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AsteroidDataResponse>> FindAsteroidAsync(string name) // TODO validation
        {
            try
            {
                var asteroid = await _asteroidService.FindAsteroidByNameAsync(name);

                if (asteroid == null)
                {
                    return NotFound();
                }

                return Ok(asteroid);                
            }
            catch (Exception e)
            {
                // TODO logging...
                return NotFound();
            }
        }

        // GET api/asteroids/{id}/observations
        [HttpGet("{id}/observations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<string>> FindObservationsAsync(string id) // TODO validation
        {
            try
            {         
                // TODO Return response model 
                var observation = await _observationService.GetObservationsAsync(id);

                if (observation == null)
                {
                    return NotFound();
                }

                return Ok(observation);

            }
            catch (Exception e)
            {
                // TODO logging ...
                return NotFound();
            }
        }


    }
}
