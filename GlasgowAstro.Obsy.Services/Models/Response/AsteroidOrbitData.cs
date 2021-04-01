﻿using System.Text.Json.Serialization;

namespace GlasgowAstro.Obsy.Services.Models.Response
{
    public class AsteroidOrbitData
    {
        [JsonPropertyName("absolute_magnitude")]
        public string AbsoluteMagnitude { get; set; }

    }
}
