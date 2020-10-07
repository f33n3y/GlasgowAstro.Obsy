using GlasgowAstro.Obsy.Api.Models.Response;
using GlasgowAstro.Obsy.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public AsteroidsController(IAsteroidService asteroidService)
        {
            _asteroidService = asteroidService;
        }

        [HttpGet("hello")]        
        public string HelloFriend()
        {
            return "hello friend";
        }

        // GET api/asteroids/{name}
        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AsteroidResponse>> FindAsteroidAsync(string asteroidName) // TODO arg validation
        {
            //var asteroid = await _asteroidService.FindAsteroidByNameAsync(asteroidName)...
            //if (asteroid == null)
            //{
            //    return NotFound();
            //}

            return Ok();
            //return Ok(asteroid);
        }

    }
}
