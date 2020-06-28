using System;
using System.Runtime.Serialization;

namespace Rembrandt.Dataset.Core.Helpers
{
   [DataContract()]
   public class DefaultObservation
    {
        public string Contributor { get; set; }
        public float Site_id { get; set; }
        public float Long_site { get; set; }
        public float Lat_site { get; set; }
        public float Gps_accuracy { get; set; }
        public float Long_actual { get; set; }
        public float Lat_actual { get; set; }
        public string Skip_reason { get; set; }
        public DateTime Time_submitted { get; set; }
        public float Foto_towards_point_compass { get; set; }
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
        public float? Age_cats { get; set; }
        public float? Gender { get; set; }
        public string Dutch { get; set; }
        public float Education { get; set; }
        public float? Visit_freq { get; set; }
        public string Visit_daily { get; set; }
        public string Alone { get; set; }
        public float? Oth_parks { get; set; }
        public string More_inv { get; set; }
        public float? Nature { get; set; }
        public string Walking { get; set; }
        public string Jogging { get; set; }
        public string Biking { get; set; }
        public string Relaxingy { get; set; }
        public string Socialising { get; set; }
        public string Children { get; set; }
        public string Photos { get; set; }
    }
}