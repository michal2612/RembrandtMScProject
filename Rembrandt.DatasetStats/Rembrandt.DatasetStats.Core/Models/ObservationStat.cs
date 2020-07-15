using System;
using System.Collections.Generic;

namespace Rembrandt.DatasetStats.Core.Models
{
    public class ObservationStat
    {
        public Dictionary<string, int> SkipReasons { get; set; }
        public List<DateTime> TimesSubmitted { get; set; }
        public int siteId { get; set; }
        public List<string> PhotosAddresses { get; set; }
        public AttributesStat Attributes { get; set; }
        public ActivitiesStat Activities { get; set; }
    }
}