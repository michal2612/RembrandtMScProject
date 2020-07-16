using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rembrandt.DatasetStats.Core.Models
{
    public class ObservationStat
    {
        [Key]
        public int PrimaryKey { get; set; }
        public List<SkipReasons> SkipReasons { get; set; }
        public int SiteId { get; set; }
        public List<PhotoAddress> PhotosAddresses { get; set; }
        public AttributesStat Attributes { get; set; }
        public ActivitiesStat Activities { get; set; }

        public ObservationStat()
        {
        }
    }
}