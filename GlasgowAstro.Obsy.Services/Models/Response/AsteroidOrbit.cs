using System.Text.Json.Serialization;

namespace GlasgowAstro.Obsy.Services.Models.Response
{
    public class AsteroidOrbit
    {
        [JsonPropertyName("absolute_magnitude")]
        public string AbsoluteMagnitude { get; set; }

    }
}
