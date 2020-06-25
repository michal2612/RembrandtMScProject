using System;

namespace Rembrandt.Dataset.Core.Models
{
    public class Location
    {
        public int GpsAccuracy { get; protected set; }
        public float Longitude { get; protected set; }
        public float Latitude { get; protected set; }
        
        protected Location()
        {

        }

        protected Location(int gpsAccuracy, float longitude, float latitude)
        {
            GpsAccuracy = SetGpsAccuracy(gpsAccuracy);
            Longitude = SetLongitude(longitude);
            Latitude = SetLatitude(latitude);
        }

        private int SetGpsAccuracy(int gpsAccuracy)
        {
            if(gpsAccuracy == 0)
                throw new ArgumentException("GPS Accuracy should not be equal to 0!");

            return gpsAccuracy;
        }

        private float SetLongitude(float longitude)
        {
            if(longitude == 0)
                throw new ArgumentNullException("Longitude should not equal to 0!");

            return longitude;
        }

        private float SetLatitude(float latitude)
        {
            if(latitude == 0)
                throw new ArgumentNullException("Latitude should not equal to 0!");

            return latitude;
        }
    }
}