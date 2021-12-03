using System.Text.Json.Serialization;

namespace GlasgowAstro.Obsy.Services.Models.Response
{
    // TODO Fix this so it isn't all strings
    public class AsteroidObservation
    {
        public string Designation { get; set; }

        [JsonPropertyName("discovery_flag")]
        public string DiscoveryFlag { get; set; }

        [JsonPropertyName("number")]
        public int Number { get; set; }

        [JsonPropertyName("object_type")]
        public string ObjectType { get; set; }

        [JsonPropertyName("observation_date")]
        public string ObservationDate { get; set; }

        [JsonPropertyName("observatory_code")]
        public string ObservatoryCode { get; set; }

        [JsonPropertyName("original_record")]
        public string OriginalRecord { get; set; }
    }
}
