using System.Collections.Generic;

namespace GlasgowAstro.Obsy.Api.Models.Response
{
    public class ObservationResponse
    {
        public string Number { get; set; }

        public List<Observation> Observations { get; set; }
    }
}
