using System.ComponentModel.DataAnnotations;

namespace Rembrandt.Contracts.Classes.Dataset.ViennaObservations
{
    public class ViennaSubAttributesDto
    {
        [Display(Name ="Alpine Skiing")]
        public bool? AlpineSkiing { get; set; }

        public bool? Alternativ { get; set; }

        [Display(Name ="Animal and bird observation")]
        public bool? AnimalBirdObservation { get; set; }

        [Display(Name ="Feeding and petting animals")]
        public bool? FeedingPettingAnimals { get; set; }

        [Display(Name ="Apparatus Gymnastics")]
        public bool? ApparatusGymnastics { get; set; }

        public bool? Ballgames { get; set; }

        [Display(Name ="Ballgames Throwing balls")]
        public bool? BallgamesThrowingBalls { get; set; }

        [Display(Name ="Bathing and swimming")]
        public bool? BathingSwimming { get; set; }

        public bool? BoardGames { get; set; }

        public bool? Breastfeed { get; set; }

        [Display(Name ="Climbing & Bouldering")]
        public bool? ClimbingBouldering { get; set; }

        public bool? Cycling { get; set; }

        public bool? Dancing { get; set; }

        [Display(Name ="Designated area where dogs can run unleashed")]
        public bool? TakingTheDogOffTheLeash { get; set; }

        [Display(Name ="Dog swimming area")]
        public bool? LettingTheDogSwim { get; set; }

        [Display(Name ="Dog walking")]
        public bool? TakingTheDogForAWalk { get; set; }

        [Display(Name ="Enjoying Nature")]
        public bool? EnjoyingNature { get; set; }

        [Display(Name ="Throwing Frisbee")]
        public bool? ThrowingFrisbee { get; set; }

        [Display(Name ="Going For A Walk")]
        public bool? GoingForAWalk { get; set; }

        public bool? Hiking { get; set; }

        [Display(Name ="Horseback riding")]
        public bool? HorsebackRiding { get; set; }

        public bool? Iceskating { get; set; }

        public bool? Jogging { get; set; }

        [Display(Name ="Juggling Hula Hoop")]
        public bool? JugglingHulaHoop { get; set; }

        [Display(Name ="Sheltered Laying")]
        public bool? LayingDownProtected { get; set; }

        [Display(Name ="Nordic Skiing")]
        public bool? NordicSkiing { get; set; }

        [Display(Name ="Nordic Walking")]
        public bool? NordicWalking { get; set; }

        public bool? Paddleboar { get; set; }

        [Display(Name ="Painting, Drawing")]
        public bool? PaintingDrawing { get; set; }

        public bool? Parcouring { get; set; }

        public bool? Picknick { get; set; }

        public bool? Playing { get; set; }

        [Display(Name ="Making music")]
        public bool? PlayingAnInstrument { get; set; }

        [Display(Name ="Playing in the snow")]
        public bool? PlayingInTheSnow { get; set; }

        [Display(Name ="Playing with water (water playgrounds)")]
        public bool? PlayingWithWater { get; set; }

        public bool? Proposing { get; set; }

        public bool? RidingABoat { get; set; }

        public bool? Romance { get; set; }

        [Display(Name ="Playing in a sandbox")]
        public bool? PlayingWithSand { get; set; }

        [Display(Name ="Riding a Scooter")]
        public bool? RidingAScotter { get; set; }

        public bool? Selfie { get; set; }

        [Display(Name ="Consuming purchased goods")]
        public bool? ConsumptionNecessary { get; set; }

        [Display(Name ="Sitting on the ground")]
        public bool? SittingOnTheGround { get; set; }

        public bool? Skating { get; set; }

        public bool? Slacklinin { get; set; }

        public bool? Tobogganing { get; set; }

        public bool? Snowshoein { get; set; }

        public bool? Spraying { get; set; }

        [Display(Name ="Stargazing")]
        public bool? StarObservation { get; set; }

        [Display(Name ="Sunbathing")]
        public bool? EnjoyingTheSun { get; set; }

        public bool? TableTennis { get; set; }

        [Display(Name ="Photography")]    
        public bool? TakingPictures { get; set; }

        [Display(Name ="Throwing or controlling objects like kites")]
        public bool? ThrowingObjects { get; set; }

        [Display(Name ="Train, plane spotting")]
        public bool? ObservingTrainspotting { get; set; }

        [Display(Name ="Urban gardening")]
        public bool? UrbanGardening { get; set; }

        [Display(Name ="Working, studying")]
        public bool? WorkingStudying { get; set; }

        public bool? Yoga { get; set; }
        
        public bool? Youth { get; set; }
    }
}