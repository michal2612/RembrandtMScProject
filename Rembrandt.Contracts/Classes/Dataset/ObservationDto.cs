using System;
using Newtonsoft.Json;
using Rembrandt.Contracts.IoC;

namespace Rembrandt.Contracts.Classes.Dataset
{
    public class ObservationDto : IObservationDto
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

        ObservationDto IObservationDto.ObservationDto() => this;
    }
}