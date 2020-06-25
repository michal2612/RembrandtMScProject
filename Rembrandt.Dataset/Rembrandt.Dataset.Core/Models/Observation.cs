using System;

namespace Rembrandt.Dataset.Core.Models
{
    public class Observation 
    {
        public int Id { get; protected set; }
        public Guid ObservationGuid { get; protected set; }
        public bool Skipped { get; protected set; }
        public DateTime TimeSubmitted { get; protected set; }
        public int SiteId { get; protected set; }
        public string PhotoAddress { get; protected set; }
        public Attributes Attributes { get; set; }
        public Park Park { get; set; }
    }
}