using System;

namespace Rembrandt.Contracts.Classes.Dataset.ViennaObservations
{
    public class ViennaObservationDto
    {
        public string User { get; set; }

        public DateTime TimeSubmitted { get; set; }

        public string PhotoPointUrl { get; set; }

        public string PhotoNorthUrl { get; set; }

        public string PhotoEastUrl { get; set; }

        public string PhotoSouthUrl { get; set; }

        public string PhotoWestUrl { get; set; }

        public LocationDto Location { get; set; }

        public ViennaAttributesDto Attributes { get; set; }

        public ViennaSubAttributesDto SubAttributes { get; set; }

        public string Source { get; set; }
    }
}