using System;

namespace Rembrandt.Dataset.Core.Models
{
    public class Observation 
    {
        public int Id { get; set; }
        public Guid ObservationGuid { get; set; }
        public bool Skipped { get; set; }
        public DateTime TimeSubmitted { get; set; }
        public int SiteId { get; set; }
        public string PhotoAddress { get; set; }
        
    }
}