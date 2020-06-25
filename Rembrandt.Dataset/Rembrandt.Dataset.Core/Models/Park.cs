namespace Rembrandt.Dataset.Core.Models
{
    public class Park
    {
        public int Id { get; protected set; }
        public Location MeasuredLocation { get; protected set; }
        public Location ActualLocation { get; protected set; }
        
        public Park()
        {
        }
    }
}