using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Rembrandt.Dataset.Infrastructure.DTO;
using Rembrandt.Dataset.Infrastructure.IoC;
using Rembrandt.Dataset.Infrastructure.Mappers;

namespace Rembrandt.Dataset.Core.Helpers
{
   [DataContract()]
   public class DefaultObservation : IObservationDto, IObservation
    {
        [JsonProperty("contributor")]
        public string Contributor { get; set; }
        [JsonProperty("site_id")]
        public float Site_id { get; set; }
        [JsonProperty("long_site")]
        public float Long_site { get; set; }
        [JsonProperty("lat_site")]
        public float Lat_site { get; set; }
        [JsonProperty("gps_accuracy")]
        public float? Gps_accuracy { get; set; }
        [JsonProperty("long_actual")]
        public float Long_actual { get; set; }
        [JsonProperty("lat_actual")]
        public float Lat_actual { get; set; }
        [JsonProperty("skip_reason")]
        public string Skip_reason { get; set; }
        [JsonProperty("time_submitted")]
        public DateTime Time_submitted { get; set; }
        [JsonProperty("foto_towards_point_compass")]
        public float Foto_towards_point_compass { get; set; }
        [JsonProperty("lively")]
        public float Lively { get; set; }
        [JsonProperty("relaxing")]
        public float Relaxing { get; set; }
        [JsonProperty("tranquil")]
        public float Tranquil { get; set; }
        [JsonProperty("noisy")]
        public float Noisy { get; set; }
        [JsonProperty("crowded")]
        public float Crowded { get; set; }
        [JsonProperty("safe")]
        public float Safe { get; set; }
        [JsonProperty("beauty")]
        public float Beauty { get; set; }
        [JsonProperty("biodiversity")]
        public float Biodiversity { get; set; }
        [JsonProperty("trees")]
        public float Trees { get; set; }
        [JsonProperty("shrubs")]
        public float Shrubs { get; set; }
        [JsonProperty("lawns")]
        public float Lawns { get; set; }
        [JsonProperty("flowers")]
        public float Flowers { get; set; }
        [JsonProperty("natveg")]
        public float Natveg { get; set; }
        [JsonProperty("benches")]
        public float Benches { get; set; }
        [JsonProperty("play")]
        public float Play { get; set; }
        [JsonProperty("sports")]
        public float Sports { get; set; }
        [JsonProperty("garbage")]
        public float Garbage { get; set; }
        [JsonProperty("veget")]
        public float Veget { get; set; }
        [JsonProperty("paths")]
        public float Paths { get; set; }
        [JsonProperty("facilities")]
        public float Facilities { get; set; }
        [JsonProperty("age_cats")]
        public float? Age_cats { get; set; }
        [JsonProperty("gender")]
        public float? Gender { get; set; }
        [JsonProperty("dutch")]
        public string Dutch { get; set; }
        [JsonProperty("education")]
        public float? Education { get; set; }
        [JsonProperty("visit_freq")]
        public float? Visit_freq { get; set; }
        [JsonProperty("visit_daily")]
        public string Visit_daily { get; set; }
        [JsonProperty("alone")]
        public string Alone { get; set; }
        [JsonProperty("oth_parks")]
        public float? Oth_parks { get; set; }
        [JsonProperty("move_inv")]
        public string More_inv { get; set; }
        [JsonProperty("nature")]
        public float? Nature { get; set; }
        [JsonProperty("walking")]
        public string Walking { get; set; }
        [JsonProperty("jogging")]
        public string Jogging { get; set; }
        [JsonProperty("biking")]
        public string Biking { get; set; }
        [JsonProperty("relaxingy")]
        public string Relaxingy { get; set; }
        [JsonProperty("socialising")]
        public string Socialising { get; set; }
        [JsonProperty("children")]
        public string Children { get; set; }
        [JsonProperty("photos")]
        public string Photos { get; set; }

        public ObservationDto ObservationDto()
            => DefaultToObservationDto.ConvertDefaultToObservationDto(this);
    }
}