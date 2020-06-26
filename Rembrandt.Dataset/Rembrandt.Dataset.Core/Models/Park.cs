namespace Rembrandt.Dataset.Core.Models
{
    public class Park
    {
        public Location MeasuredLocation { get; protected set; }
        public Location ActualLocation { get; protected set; }
        
        public Park(Location measuredLocation, Location actualLocation)
        {
            MeasuredLocation = measuredLocation;
            ActualLocation = actualLocation;
        }
    }
}