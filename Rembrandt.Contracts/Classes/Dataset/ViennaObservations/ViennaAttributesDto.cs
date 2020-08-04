using System.ComponentModel.DataAnnotations;

namespace Rembrandt.Contracts.Classes.Dataset.ViennaObservations
{
    public class ViennaAttributesDto
    {
        [Display(Name ="Feeling well")]
        public int? FeelingWell { get; set; }

        public int? Attractive { get; set; }

        public int? Clean { get; set; }

        public int? Facilities { get; set; }

        public int? Quiet { get; set; }

        public int? Secure { get; set; }

        [Display(Name ="Animals and nature")]
        public int? AnimalsNature { get; set; }

        public int? Playing { get; set; }

        public int? Romance { get; set; }

        [Display(Name ="Exercise and sport")]
        public int? ExerciseSport { get; set; }

        [Display(Name ="Sitting and laying down")]
        public int? SittingLayingDown { get; set; }

        public int? Winter { get; set; }

        public int? Creativity { get; set; }

        public int? Summer { get; set; }

        [Display(Name ="Cooling green")]
        public bool? CoolingGreen { get; set; }

        [Display(Name ="Cooling wind")]
        public bool? CoolingWind { get; set; }

        [Display(Name ="Driking water")]
        public bool? DrikingWater { get; set; }

        public bool? Shadow { get; set; }

        public bool? Water { get; set; }
    }
}