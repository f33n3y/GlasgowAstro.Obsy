using System.ComponentModel.DataAnnotations;

namespace GlasgowAstro.Obsy.Api.Models.Request
{
    public class ObservationRequest
    {       
        [Required]
        [RegularExpression("^[0-9]*$")]  // TODO Expand this regex to cater for other object types
        public string Number { get; set; }

        [Required]
        [Range(byte.MinValue, byte.MaxValue)]        
        public byte NumObservations { get; set; }
    }
}
