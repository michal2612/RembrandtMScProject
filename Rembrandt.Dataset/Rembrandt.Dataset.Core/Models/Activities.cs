namespace Rembrandt.Dataset.Core.Models
{
    public class Activities
    {
        public bool? Walking { get; protected set; }
        public bool? Jogging { get; protected set; }
        public bool? Biking { get; protected set; }
        public bool? Relaxing { get; protected set; }
        public bool? Socialising { get; protected set; }

        public Activities(bool? walking, bool? jogging, bool? biking, bool? relaxing, bool? socialising)
        {
            Walking = walking;
            Jogging = jogging;
            Biking = biking;
            Relaxing = relaxing;
            Socialising = socialising;
        }
    }
}