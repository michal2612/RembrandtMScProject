using System;

namespace Rembrandt.Dataset.Core.Models
{
    public class Observation 
    {
        public int Id { get; protected set; }
        public Guid ObservationGuid { get; protected set; }
        public string SkippedReason { get; protected set; }
        public DateTime TimeSubmitted { get; protected set; }
        public int SiteId { get; protected set; }
        public string PhotoAddress { get; protected set; }
        public Attributes Attributes { get; protected set; }
        public Park Park { get; set; }
        public Activities Activities { get; protected set; }
        public Contributor Contributor { get; set; }

        protected Observation()
        {

        }

    }
}