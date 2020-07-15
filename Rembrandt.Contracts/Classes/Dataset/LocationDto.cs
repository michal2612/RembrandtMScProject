using System;

namespace Rembrandt.Contracts.Classes.Dataset
{
    [Serializable]
    public class LocationDto
    {
        public int? GpsAccuracy { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
    }
}