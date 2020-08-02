using System;

namespace Rembrandt.Dataset.Core.Models.ViennaDataset
{
    public class ViennaAttributes
    {
        public int FeelingWell { get; protected set; }

        public int Attractive { get; protected set; }

        public int Clean { get; protected set; }

        public int Facilities { get; protected set; }

        public int Quiet { get; protected set; }

        public int Secure { get; protected set; }

        public int AnimalsNature { get; protected set; }

        public int Playing { get; protected set; }

        public int Romance { get; protected set; }

        public int ExerciseSport { get; protected set; }

        public int SittingLayingDown { get; protected set; }

        public int Winter { get; protected set; }

        public int Creativity { get; protected set; }

        public int Summer { get; protected set; }

        public bool? CoolingGreen { get; protected set; }

        public bool? CoolingWind { get; protected set; }

        public bool? DrikingWater { get; protected set; }

        public bool? Shadow { get; protected set; }

        public bool? Water { get; protected set; }

        public ViennaAttributes()
        {

        }

        public ViennaAttributes(int feelingWell, int attractive, int clean, int facilities, int quiet, int secure, int animalsNature, int playing, int romance, int exerciseSport, int sittingLayingDown, int winter, int creativity, int summer, bool? coolingGreen, bool? coolingWind, bool? drikingWater, bool? shadow, bool? water)
        {
            var minValue = default(int);
            var maxValue = 100;

            foreach(var property in this.GetType().GetProperties())
                if(property.GetType() == typeof(int))
                    if((int)property.GetValue(this) > maxValue || (int)property.GetValue(this) < minValue)
                        throw new ArgumentException($"Value should be between {minValue} and {maxValue}.");
        }
    }
}