using System.Collections.Generic;

namespace GlasgowAstro.Obsy.Bot.Models
{
    public class AsteroidBotEmbedData
    {
        public string Number { get; set; }

        public string AbsoluteMagnitude { get; set; }

        public List<Observation> Observations { get; set; } = new List<Observation>();
    }
}