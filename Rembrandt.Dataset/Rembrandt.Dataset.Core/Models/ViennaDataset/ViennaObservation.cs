using System;
using System.ComponentModel.DataAnnotations;

namespace Rembrandt.Dataset.Core.Models.ViennaDataset
{
    public class ViennaObservation
    {
        [Key]
        public int Id { get; set; }
        
        public string User { get; protected set; }

        public DateTime TimeSubmitted { get; protected set; }

        public string PhotoPointUrl { get; protected set; }

        public string PhotoNorthUrl { get; protected set; }

        public string PhotoEastUrl { get; protected set; }

        public string PhotoSouthUrl { get; protected set; }

        public string PhotoWestUrl { get; protected set; }

        public Location Location { get; protected set; }

        public ViennaAttributes Attributes { get; protected set; }

        public ViennaSubAttributes SubAttributes { get; protected set; }

        public string Source { get; protected set; }

        protected ViennaObservation()
        {
            
        }

        public ViennaObservation(string user, string photoPointUrl, string photoNorthUrl, string photoEastUrl, string photoSouthUrl, string photoWestUrl, Location location, ViennaAttributes attributes, ViennaSubAttributes subAttributes, string soruce)
        {
            User = user;
            PhotoPointUrl = photoPointUrl;
            PhotoNorthUrl = photoNorthUrl;
            PhotoEastUrl = photoEastUrl;
            PhotoSouthUrl = photoSouthUrl;
            PhotoWestUrl = photoWestUrl;
            Location = location;
            Attributes = attributes;
            SubAttributes = subAttributes;
            Source = Source;
        }
        
    }
}