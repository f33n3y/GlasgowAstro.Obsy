using System.Collections.Generic;

namespace GlasgowAstro.Obsy.Api.Models.Response
{
    public class ObservationResponse
    {
        public string Number { get; set; }

        private readonly List<Observation> _observations = new List<Observation>();

        public List<Observation> Observations { get { return _observations; } }
    }
}
