using System;
using Newtonsoft.Json;

namespace Rembrandt.Contracts.Classes.Dataset
{
    [Serializable]
    public class ActivitiesDto
    {
        public bool? Walking { get; set; }
        public bool? Jogging { get; set; }
        public bool? Biking { get; set; }
        public bool? Relaxing { get; set; }
        public bool? Socialising { get; set; }
    }
}