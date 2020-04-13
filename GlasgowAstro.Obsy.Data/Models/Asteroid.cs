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
        /// Slope parameter
        /// </summary>
        [BsonElement("G")]
        public float SlopeParameter { get; set; }

        /// <summary>
        /// Epoch of the orbit (Julian Date)
        /// </summary>
        [BsonElement("Epoch")]
        public float Epoch { get; set; }

        /// <summary>
        /// Semimajor axis, a (AU)
        /// </summary>
        [BsonElement("a")]
        public float SemiMajorAxis { get; set; }

        /// <summary>
        /// Orbital eccentricity, e
        /// </summary>
        [BsonElement("e")]
        public float OrbitalEccentricity { get; set; }

        /// <summary>
        /// Inclination to the ecliptic, J2000.0 (degrees)
        /// </summary>
        [BsonElement("i")]
        public float InclinationEcliptic { get; set; }

        /// <summary>
        /// Longitude of the ascending node, ☊, J2000.0 (degrees)
        /// </summary>
        [BsonElement("Node")]
        public float Node { get; set; }

        /// <summary>
        /// Argument of perihelion, ω, J2000.0 (degrees)
        /// </summary>
        [BsonElement("Peri")]
        public float Peri { get; set; }

        /// <summary>
        /// Mean anomaly, M, at the epoch (degrees)
        /// </summary>
        [BsonElement("M")]
        public float MeanAnomoly { get; set; }

        /// <summary>
        /// Mean daily motion, n (degrees/day)
        /// </summary>
        [BsonElement("n")]
        public float MeanDailyMotion { get; set; }

        /// <summary>
        /// Uncertainty parameter with values 0-9
        /// </summary>
        [BsonElement("U")]
        public string UncertaintyParameter { get; set; }

        /// <summary>
        /// Reference
        /// </summary>
        [BsonElement("Ref")]
        public string Reference { get; set; }

        /// <summary>
        /// Number of observations
        /// </summary>
        [BsonElement("Num_obs")]
        public int NumberObservations { get; set; }

        /// <summary>
        /// Number of oppositions
        /// </summary>
        [BsonElement("Num_opps")]
        public int NumberOppositions { get; set; }

        /// <summary>
        /// Only present for multi-opposition orbits 
        /// (year of first observation – year of last observation)
        /// </summary>
        [BsonElement("Arc_years")]
        public string ArcYears { get; set; }

        /// <summary>
        /// Only present for 1-opposition orbits (days)
        /// </summary>
        [BsonElement("Arc_length")]
        public int ArcLength { get; set; }

        /// <summary>
        /// r.m.s. residual (")
        /// </summary>
        [BsonElement("rms")]
        public float Rms { get; set; }

        /// <summary>
        /// Coarse indicator of perturbers used in 
        /// orbit computation
        /// </summary>
        [BsonElement("Perturbers")]
        public string Perturbers { get; set; }

        /// <summary>
        /// Precise indicator of perturbers used in 
        /// orbit computation
        /// </summary>
        [BsonElement("Perturbers_2")]
        public string Perturbers2 { get; set; }

        /// <summary>
        /// Date of last observation included in orbit 
        /// solution (YYYY-MM-DD format)
        /// </summary>
        [BsonElement("Last_obs")]
        public string LastObservationDate { get; set; }

        /// <summary>
        /// 4-hexdigit flags
        /// </summary>
        [BsonElement("Hex_flags")]
        public string HexFlags { get; set; }

        /// <summary>
        /// Name of orbit computer (be it a person or machine)
        /// </summary>
        [BsonElement("Computer")]
        public string Computer { get; set; }

        /// <summary>
        /// Possible values: Atira, Aten, Apollo, Amor, Object with 
        /// perihelion distance < 1.665 AU, Hungaria, MBA, Phocaea, 
        /// Hilda, Jupiter Trojan, Distant Object or Unclassified
        /// </summary>
        [BsonElement("orbit_type")]
        public string OrbitType { get; set; }

        /// <summary>
        /// Value = 1 if flag raised, otherwise keyword is absent
        /// </summary>
        [BsonElement("NEO_flag")]
        public int NEOFlag { get; set; }

        /// <summary>
        /// Value = 1 if flag raised, otherwise keyword is absent
        /// </summary>
        [BsonElement("One_km_NEO_flag")]
        public int OneKmNEOFlag { get; set; }

        /// <summary>
        /// Value = 1 if flag raised, otherwise keyword is absent
        /// </summary>
        [BsonElement("PHA_flag")]
        public int PHAFlag { get; set; }

        /// <summary>
        /// Value = 1 if flag raised, otherwise keyword is absent
        /// </summary>
        [BsonElement("One_opposition_object_flag")]
        public int OneOppositionObjFlag { get; set; }

        /// <summary>
        /// Value = 1 if flag raised, otherwise keyword is absent
        /// </summary>
        [BsonElement("Critical_list_numbered_object_flag")]
        public int CriticalListNumObjFlag { get; set; }

        /// <summary>
        /// Perihelion distance (AU)
        /// </summary>
        [BsonElement("Perihelion_dist")]
        public float PerihelionDistance { get; set; }

        /// <summary>
        /// Aphelion distance (AU)
        /// </summary>
        [BsonElement("Aphelion_dist")]
        public float AphelionDistance { get; set; }

        /// <summary>
        /// Semilatus rectum distance (AU)
        /// </summary>
        [BsonElement("Semilatus_rectum")]
        public float SemilatusRectumDistance { get; set; }

        /// <summary>
        /// Orbital period (years)
        /// </summary>
        [BsonElement("Orbital_period")]
        public float OrbitalPeriod { get; set; }

        /// <summary>
        /// Synodic period (years)
        /// </summary>
        [BsonElement("Synodic_period")]
        public float SynodicPeriod { get; set; }
    }
}
