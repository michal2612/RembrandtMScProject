using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Rembrandt.Dataset.Core.Models.ViennaDataset
{
    public class ViennaAttributes
    {
        [Key]
        public int Id { get; set; }
        public int? FeelingWell { get; protected set; }

        public int? Attractive { get; protected set; }

        public int? Clean { get; protected set; }

        public int? Facilities { get; protected set; }

        public int? Quiet { get; protected set; }

        public int? Secure { get; protected set; }

        public int? AnimalsNature { get; protected set; }

        public int? Playing { get; protected set; }

        public int? Romance { get; protected set; }

        public int? ExerciseSport { get; protected set; }

        public int? SittingLayingDown { get; protected set; }

        public int? Winter { get; protected set; }

        public int? Creativity { get; protected set; }

        public int? Summer { get; protected set; }

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
            FeelingWell = CheckIfInRange(feelingWell);
            Attractive = CheckIfInRange(attractive);
            Clean = CheckIfInRange(clean);
            Facilities = CheckIfInRange(facilities);
            Quiet = CheckIfInRange(quiet);
            Secure = CheckIfInRange(secure);
            AnimalsNature = CheckIfInRange(animalsNature);
            Playing = CheckIfInRange(playing);
            Romance = CheckIfInRange(romance);
            ExerciseSport = CheckIfInRange(exerciseSport);
            SittingLayingDown = CheckIfInRange(sittingLayingDown);
            Winter = CheckIfInRange(winter);
            Creativity = CheckIfInRange(creativity);
            Summer = CheckIfInRange(summer);
            CoolingGreen = coolingGreen;
            CoolingGreen = coolingWind;
            DrikingWater = drikingWater;
            Shadow = shadow;
            Water = water;
        }

        private static int? CheckIfInRange(int value)
        {
            var minValue = default(int);
            var maxValue = 101;

            if(Enumerable.Range(minValue, maxValue).Contains(value))
                return value;
            
            throw new ArgumentOutOfRangeException($"Value should be between {minValue} and {maxValue}.");
        }
    }
}