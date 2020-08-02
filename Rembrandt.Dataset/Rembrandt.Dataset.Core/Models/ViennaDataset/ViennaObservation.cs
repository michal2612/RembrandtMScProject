using System;

namespace Rembrandt.Dataset.Core.Models.ViennaDataset
{
    public class ViennaObservation
    {
        public string User { get; protected set; }

        public DateTime TimeSubmitted { get; protected set; }

        public string PhotoPointUrl { get; protected set; }

        public string PhotoNorthUrl { get; protected set; }

        public string PhotoEastUrl { get; protected set; }

        public string PhotoSouthUrl { get; protected set; }

        public string PhotoWestUrl { get; protected set; }

        public Location Location { get; protected set; }

        public ViennaAttributes Attributes { get; protected set; }

        protected ViennaObservation()
        {
            
        }

        public ViennaObservation(string user, string photoPointUrl, string photoNorthUrl, string photoEastUrl, string photoSouthUrl, string photoWestUrl, Location location, ViennaAttributes attributes)
        {
            location ??= new Location(0f,0f);
            attributes ??= new ViennaAttributes();
        }
        
    }
}