using System.Collections.Generic;

namespace GlasgowAstro.Obsy.Services.Models.Response
{
    public class AsteroidObservationDataResponse
    {
        public string Number { get; set; }

        public List<AsteroidObservation> Observations { get; set; }
    }
}
