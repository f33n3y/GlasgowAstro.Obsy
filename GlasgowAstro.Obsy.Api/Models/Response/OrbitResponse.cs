using System.Collections.Generic;

namespace GlasgowAstro.Obsy.Api.Models.Response
{
    public class OrbitResponse
    {
        public string Number { get; set; }

        public List<Orbit> OrbitData { get; set; }
    }
}
