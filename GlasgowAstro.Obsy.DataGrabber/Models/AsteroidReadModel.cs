using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GlasgowAstro.Obsy.DataGrabber.Models
{
    public class AsteroidReadModel
    {
        /// <summary>
        /// Name, if asteroid has received one
        /// </summary>
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Number, if asteroid has received one;
        /// this is the asteroid's permanent designation
        /// </summary>
        [JsonPropertyName("Number")]
        public string Number { get; set; }

        /// <summary>
        /// Principal provisional designation (if it exists)
        /// </summary>
        [JsonPropertyName("Principal_desig")]
        public string PrincipalDesignation { get; set; }

        /// <summary>
        /// Other provisional designations (if they exist)
        /// </summary>
        [JsonPropertyName("Other_desigs")]
        public List<string> OtherDesignation { get; set; }

        /// <summary>
        /// Absolute magnitude
        /// </summary>
        [JsonPropertyName("H")]
        public double AbsoluteMagnitude { get; set; }

        /// <summary>
        /// Slope parameter
        /// </summary>
        [JsonPropertyName("G")]
        public double SlopeParameter { get; set; }

        /// <summary>
        /// Epoch of the orbit (Julian Date)
        /// </summary>
        [JsonPropertyName("Epoch")]
        public double Epoch { get; set; }

        /// <summary>
        /// Semimajor axis, a (AU)
        /// </summary>
        [JsonPropertyName("a")]
        public double SemiMajorAxis { get; set; }

        /// <summary>
        /// Orbital eccentricity, e
        /// </summary>
        [JsonPropertyName("e")]
        public double OrbitalEccentricity { get; set; }

        /// <summary>
        /// Inclination to the ecliptic, J2000.0 (degrees)
        /// </summary>
        [JsonPropertyName("i")]
        public double InclinationEcliptic { get; set; }

        /// <summary>
        /// Longitude of the ascending node, ☊, J2000.0 (degrees)
        /// </summary>
        [JsonPropertyName("Node")]
        public double Node { get; set; }

        /// <summary>
        /// Argument of perihelion, ω, J2000.0 (degrees)
        /// </summary>
        [JsonPropertyName("Peri")]
        public double Peri { get; set; }

        /// <summary>
        /// Mean anomaly, M, at the epoch (degrees)
        /// </summary>
        [JsonPropertyName("M")]
        public double MeanAnomoly { get; set; }

        /// <summary>
        /// Mean daily motion, n (degrees/day)
        /// </summary>
        [JsonPropertyName("n")]
        public double MeanDailyMotion { get; set; }

        /// <summary>
        /// Uncertainty parameter with values 0-9
        /// </summary>
        [JsonPropertyName("U")]
        public string UncertaintyParameter { get; set; }

        /// <summary>
        /// Reference
        /// </summary>
        [JsonPropertyName("Ref")]
        public string Reference { get; set; }

        /// <summary>
        /// Number of observations
        /// </summary>
        [JsonPropertyName("Num_obs")]
        public int NumberObservations { get; set; }

        /// <summary>
        /// Number of oppositions
        /// </summary>
        [JsonPropertyName("Num_opps")]
        public int NumberOppositions { get; set; }

        /// <summary>
        /// Only present for multi-opposition orbits 
        /// (year of first observation – year of last observation)
        /// </summary>
        [JsonPropertyName("Arc_years")]
        public string ArcYears { get; set; }

        /// <summary>
        /// Only present for 1-opposition orbits (days)
        /// </summary>
        [JsonPropertyName("Arc_length")]
        public int ArcLength { get; set; }

        /// <summary>
        /// r.m.s. residual (")
        /// </summary>
        [JsonPropertyName("rms")]
        public double Rms { get; set; }

        /// <summary>
        /// Coarse indicator of perturbers used in 
        /// orbit computation
        /// </summary>
        [JsonPropertyName("Perturbers")]
        public string Perturbers { get; set; }

        /// <summary>
        /// Precise indicator of perturbers used in 
        /// orbit computation
        /// </summary>
        [JsonPropertyName("Perturbers_2")]
        public string Perturbers2 { get; set; }

        /// <summary>
        /// Date of last observation included in orbit 
        /// solution (YYYY-MM-DD format)
        /// </summary>
        [JsonPropertyName("Last_obs")]
        public string LastObservationDate { get; set; }

        /// <summary>
        /// 4-hexdigit flags
        /// </summary>
        [JsonPropertyName("Hex_flags")]
        public string HexFlags { get; set; }

        /// <summary>
        /// Name of orbit computer (be it a person or machine)
        /// </summary>
        [JsonPropertyName("Computer")]
        public string Computer { get; set; }

        /// <summary>
        /// Possible values: Atira, Aten, Apollo, Amor, Object with 
        /// perihelion distance < 1.665 AU, Hungaria, MBA, Phocaea, 
        /// Hilda, Jupiter Trojan, Distant Object or Unclassified
        /// </summary>
        [JsonPropertyName("orbit_type")]
        public string OrbitType { get; set; }

        /// <summary>
        /// Value = 1 if flag raised, otherwise keyword is absent
        /// </summary>
        [JsonPropertyName("NEO_flag")]
        public int NEOFlag { get; set; }

        /// <summary>
        /// Value = 1 if flag raised, otherwise keyword is absent
        /// </summary>
        [JsonPropertyName("One_km_NEO_flag")]
        public int OneKmNEOFlag { get; set; }

        /// <summary>
        /// Value = 1 if flag raised, otherwise keyword is absent
        /// </summary>
        [JsonPropertyName("PHA_flag")]
        public int PHAFlag { get; set; }

        /// <summary>
        /// Value = 1 if flag raised, otherwise keyword is absent
        /// </summary>
        [JsonPropertyName("One_opposition_object_flag")]
        public int OneOppositionObjFlag { get; set; }
            
        /// <summary>
        /// Value = 1 if flag raised, otherwise keyword is absent
        /// </summary>
        [JsonPropertyName("Critical_list_numbered_object_flag")]
        public int CriticalListNumObjFlag { get; set; }

        /// <summary>
        /// Perihelion distance (AU)
        /// </summary>
        [JsonPropertyName("Perihelion_dist")]
        public double PerihelionDistance { get; set; }

        /// <summary>
        /// Aphelion distance (AU)
        /// </summary>
        [JsonPropertyName("Aphelion_dist")]
        public double AphelionDistance { get; set; }

        /// <summary>
        /// Semilatus rectum distance (AU)
        /// </summary>
        [JsonPropertyName("Semilatus_rectum")]
        public double SemilatusRectumDistance { get; set; }

        /// <summary>
        /// Orbital period (years)
        /// </summary>
        [JsonPropertyName("Orbital_period")]
        public double OrbitalPeriod { get; set; }

        /// <summary>
        /// Synodic period (years)
        /// </summary>
        [JsonPropertyName("Synodic_period")]
        public double SynodicPeriod { get; set; }    
    }
}
