using System.ComponentModel.DataAnnotations;

namespace GlasgowAstro.Obsy.Api.Models.Request
{
    public class OrbitRequest
    {
        [Required]
        [RegularExpression("^[0-9]*$")]  // TODO Expand this regex to cater for other object types
        [MaxLength(10)]
        public string Number { get; set; }
    }
}
