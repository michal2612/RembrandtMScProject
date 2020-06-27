using System;

namespace Rembrandt.Dataset.Infrastructure.DTO
{
    public class ObservationDto
    {
        public string SkipReason { get;  set; }
        public DateTime TimeSubmitted { get;  set; }
        public int SiteId { get;  set; }
        public string PhotoAddress { get;  set; }
        public int PhotoTowardsPointCompass { get;  set; }
        public AttributesDto Attributes { get;  set; }
        public ParkDto Park { get;  set; }
        public ActivitiesDto Activities { get;  set; }
        public ContributorDto Contributor { get;  set; }
    }
}