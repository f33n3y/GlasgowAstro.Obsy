using GlasgowAstro.Obsy.Data.Attributes;

namespace GlasgowAstro.Obsy.Data.Models
{
    [BsonCollection("data")]
    public class Asteroid : Document
    {
        public string Name { get; set; }

        public string Computer { get; set; }

        // TODO ....
    }
}
