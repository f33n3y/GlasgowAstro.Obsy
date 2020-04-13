using GlasgowAstro.Obsy.Data.Attributes;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

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
        /// Number, if asteroid has received one;
        /// this is the asteroid's permanent designation
        /// </summary>
        [BsonElement("Number")]
        public string Number { get; set; }

        /// <summary>
        /// Principal provisional designation (if it exists)
        /// </summary>
        [BsonElement("Principal_desig")]
        public string PrincipalDesignation { get; set; }

        [BsonElement("CompoId")]
        public string CompoId => $"{Name}{Number}{PrincipalDesignation}";

        /// <summary>
        /// Other provisional designations (if they exist)
        /// </summary>
        [BsonElement("Other_desigs")]
        public List<string> OtherDesignation { get; set; }

        /// <summary>
        /// Absolute magnitude
        /// </summary>
        [BsonElement("H")]
        public float AbsoluteMagnitude { get; set; }

        /// <summary>
        /// Mean daily motion, n (degrees/day)
        /// </summary>
        [BsonElement("n")]
        public float MeanDailyMotion { get; set; }

        /// <summary>
        /// Orbital period (years)
        /// </summary>
        [BsonElement("Orbital_period")]
        public float OrbitalPeriod { get; set; }
    }
}
