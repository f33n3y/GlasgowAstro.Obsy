using System;
using System.Collections.Generic;
using System.Text;

namespace GlasgowAstro.Obsy.Services.Models
{
    public class AsteroidObservationResponse
    {
        public string RawTest { get; set; }

        public List<AsteroidObservation> Observations { get; set; }
    }
}
