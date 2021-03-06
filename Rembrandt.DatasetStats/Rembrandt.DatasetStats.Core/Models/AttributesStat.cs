using System.ComponentModel.DataAnnotations;

namespace Rembrandt.DatasetStats.Core.Models
{
    public class AttributesStat
    {
        [Key]
        public int PrimaryKey { get; set; }

        public float Lively { get; set; }

        public float Relaxing { get; set; }

        public float Tranquil { get; set; }

        public float Noisy { get; set; }

        public float Crowded { get; set; }

        public float Safe { get; set; }

        public float Beauty { get; set; }

        public float Biodiversity { get; set; }

        public float Trees { get; set; }

        public float Shrubs { get; set; }

        public float Lawns { get; set; }

        public float Flowers { get; set; }

        public float Natveg { get; set; }

        public float Benches { get; set; }

        public float Play { get; set; }

        public float Sports { get; set; }

        public float Garbage { get; set; }

        public float Veget { get; set; }

        public float Paths { get; set; }
        
        public float Facilities { get; set; }
    }
}