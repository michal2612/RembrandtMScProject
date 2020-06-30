using System;

namespace Rembrandt.Dataset.Core.Models
{
    public class Location
    {
        public int Id { get; set; }
        public int GpsAccuracy { get; protected set; }
        public float Longitude { get; protected set; }
        public float Latitude { get; protected set; }

        protected Location()
        {
            
        }

        public Location(float longitude, float latitude)
        {
            Longitude = SetCoordinates(longitude);
            Latitude = SetCoordinates(latitude);
        }
        
        public Location(int gpsAccuracy, float longitude, float latitude)
        {
            GpsAccuracy = SetGpsAccuracy(gpsAccuracy);
            Longitude = SetCoordinates(longitude);
            Latitude = SetCoordinates(latitude);
        }

        private int SetGpsAccuracy(int gpsAccuracy)
        {
            if(gpsAccuracy < 0)
                throw new ArgumentException("GPS Accuracy should not be below 0!");
            return gpsAccuracy;
        }

        private float SetCoordinates(float coordinate)
        {
            if(coordinate == 0)
                throw new ArgumentNullException("Coordinates should not be below 0!");
            return coordinate;
        }
    }
}