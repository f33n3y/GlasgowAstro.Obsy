using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlasgowAstro.Obsy.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class AsteroidController : ControllerBase
    {
        public AsteroidController()
        {

        }

        [HttpGet]
        public string Test()
        {
            return "Hello friend";
        }


    }
}
