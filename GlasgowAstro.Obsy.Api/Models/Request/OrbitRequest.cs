using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlasgowAstro.Obsy.Api.Models.Request
{
    public class OrbitRequest
    {
        [Required]
        [RegularExpression("^[0-9]*$")]  // TODO Expand this regex to cater for other object types
        public string Number { get; set; }
    }
}
