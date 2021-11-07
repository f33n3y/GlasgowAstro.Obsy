using System.Collections.Generic;

namespace GlasgowAstro.Obsy.Services.Models.Response
{
    public class AsteroidOrbitDataResponse
    {
        public string Number { get; set; }

        public List<AsteroidOrbit> OrbitData { get; set; }
    }
}