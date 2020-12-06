namespace GlasgowAstro.Obsy.Services.Models.Response
{
    // TODO Fix this so it isn't all strings
    public class AsteroidObservation
    {
        public string Designation { get; set; }

        public string DiscoveryFlag { get; set; }

        public string Number { get; set; }

        public string ObjectType { get; set; }

        public string ObservationDate { get; set; }

        public string ObservatoryCode { get; set; }

        public string OriginalRecord { get; set; }
    }
}
