using System;
using System.Collections.Generic;

namespace Rembrandt.Contracts.Classes.Stats
{
    public class ObservationStatDto
    {
        public Dictionary<string, int> SkipReasons { get; set; }
        public List<DateTime> TimesSubmitted { get; set; }
        public int SiteId { get; set; }
        public List<string> PhotosAddresses { get; set; }
        public AttributesStatDto Attributes { get; set; }
        public ActivitiesStatDto Activities { get; set; }
    }
}