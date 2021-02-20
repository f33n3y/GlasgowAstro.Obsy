using System.Collections.Generic;

namespace GlasgowAstro.Obsy.Services.Models.Response
{
    public class AsteroidObservationServiceResponse
    {
        public string RawTest { get; set; }

        public List<AsteroidObservation> Observations { get; set; }
    }
}
