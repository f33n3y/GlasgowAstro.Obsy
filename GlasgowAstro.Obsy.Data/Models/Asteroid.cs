using GlasgowAstro.Obsy.Data.Attributes;
using MongoDB.Bson.Serialization.Attributes;

namespace GlasgowAstro.Obsy.Data.Models
{
    [BsonCollection("data")]
    public class Asteroid : Document
    {
        /// <summary>
        /// Name, if asteroid has received one
        /// </summary>
        [BsonElement("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Name of orbit computer (be it a person or machine)
        /// </summary>
        [BsonElement("Computer")]
        public string Computer { get; set; }

        /// <summary>
        /// Absolute magnitude
        /// </summary>
        [BsonElement("H")]
        public float AbsoluteMagnitude { get; set; }

        // TODO ....
    }
}
