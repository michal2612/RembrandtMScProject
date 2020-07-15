using System;

namespace Rembrandt.Contracts.Classes.Dataset
{
    [Serializable]
    public class ParkDto
    {
        public LocationDto MeasuredLocation { get; set; }
        public LocationDto ActualLocation { get; set; }
    }

}