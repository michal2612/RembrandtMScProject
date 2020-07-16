using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rembrandt.DatasetStats.Core.Models
{
    public class ActivitiesStat
    {
        [Key]
        public int PrimaryKey { get; set; }
        public bool Walking { get; set; }
        public bool Jogging { get; set; }
        public bool Biking { get; set; }
        public bool Relaxing { get; set; }
        public bool Socialising { get; set; }
    }
}