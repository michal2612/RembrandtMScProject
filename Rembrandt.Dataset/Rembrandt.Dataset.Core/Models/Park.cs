using System;

namespace Rembrandt.Dataset.Core.Models
{
    public class Park
    {
        public Location MeasuredLocation { get; protected set; }
        public Location ActualLocation { get; protected set; }
        
        public Park(Location measuredLocation, Location actualLocation)
        {
            MeasuredLocation = CheckForNullable(measuredLocation);
            ActualLocation = CheckForNullable(actualLocation);
        }

        private static T CheckForNullable<T>(T obj)
            => obj == null ? throw new ArgumentNullException($"Property '{typeof(T).Name}' can not be null!") : obj;
    }
}