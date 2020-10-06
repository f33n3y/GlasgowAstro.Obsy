using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace GlasgowAstro.Obsy.Api.Controllers
{
        
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    public class AsteroidController : ControllerBase
    {
        public AsteroidController()
        {

        }

        [HttpGet("test")]        
        public string Test()
        {
            return "test";
        }

        [HttpGet("hello")]        
        [AllowAnonymous]
        public string HelloFriend()
        {
            return "hello friend";
        }

    }
}
