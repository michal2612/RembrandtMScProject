using System;
using Newtonsoft.Json;
using Rembrandt.Contracts.IoC;

namespace Rembrandt.Contracts.Classes.Dataset.ViennaObservations
{
    public class DefaultViennaObservation
    {
        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("latitude")]
        public float Latitude { get; set; }

        [JsonProperty("longitude")]
        public float Longitude { get; set; }

        [JsonProperty("time_submitted")]
        public DateTime TimeSubmitted { get; set; }

        [JsonProperty("foto_point_url")]
        public string FotoPointUrl { get; set; }

        [JsonProperty("foto_north_url")]
        public string FotoNorthUrl { get; set; }

        [JsonProperty("foto_east_url")]
        public string FotoEastUrl { get; set; }

        [JsonProperty("foto_south_url")]
        public string FotoSouthUrl { get; set; }

        [JsonProperty("foto_west_url")]
        public string FotoWestUrl { get; set; }

        [JsonProperty("Feeling well")]
        public int? FeelingWell { get; set; }

        [JsonProperty("Attractive")]
        public int? Attractive { get; set; }

        [JsonProperty("Clean")]
        public int? Clean { get; set; }

        [JsonProperty("Facilities")]
        public int? Facilities { get; set; }

        [JsonProperty("Quiet")]
        public int? Quiet { get; set; }

        [JsonProperty("Secure")]
        public int? Secure { get; set; }

        [JsonProperty(@"animals / nature")]
        public int? AnimalsNature { get; set; }

        [JsonProperty("playing")]
        public int? Playing { get; set; }

        [JsonProperty("romance")]
        public int? Romance { get; set; }

        [JsonProperty(@"exercise / sport")]
        public int? ExerciseSport { get; set; }

        [JsonProperty(@"sitting / laying down")]
        public int? SittingLayingDown { get; set; }

        [JsonProperty("winter")]
        public int? Winter { get; set; }

        [JsonProperty("creativity")]
        public int? Creativity { get; set; }

        [JsonProperty("cooling green")]
        public int? CoolingGreen { get; set; }

        [JsonProperty("cooling wind")]
        public int? CoolingWind { get; set; }

        [JsonProperty("drinking water")]
        public int? DrinkingWater { get; set; }

        [JsonProperty("shadow")]
        public int? Shadow { get; set; }

        [JsonProperty("summer")]
        public int? Summer { get; set; }

        [JsonProperty("water")]
        public int? Water { get; set; }

        [JsonProperty("alpine skiing")]
        public int? AlpineSkiing { get; set; }

        [JsonProperty("alternativ")]
        public int? Alternativ { get; set; }

        [JsonProperty(@"animal / bird observation")]
        public int? AnimalBirdObservation { get; set; }

        [JsonProperty(@"feeding / petting animals")]
        public int? FeedingPettingAnimals { get; set; }

        [JsonProperty("apparatus gymnastics")]
        public int? ApparatusGymnastics { get; set; }

        [JsonProperty("ballgames")]
        public int? Ballgames { get; set; }

        [JsonProperty(@"ballgames / throwing balls / boccia")]
        public int? BallgamesThrowingBalls { get; set; }

        [JsonProperty("bathing swimming")]
        public int? BathingSwimming { get; set; }

        [JsonProperty("boardgames")]
        public int? BoardGames { get; set; }

        [JsonProperty("breastfeed")]
        public int? Breastfeed { get; set; }

        [JsonProperty(@"climbing / bouldering")]
        public int? ClimbingBouldering { get; set; }

        [JsonProperty("consumptio")]
        public int? Consumptio { get; set; }

        [JsonProperty("cycling")]
        public int? Cycling { get; set; }

        [JsonProperty("dancing")]
        public int? Dancing { get; set; }

        [JsonProperty("taking the dog off the leash")]
        public int? TakingTheDogOffTheLeash { get; set; }

        [JsonProperty("letting the dog swim")]
        public int? LettingTheDogSwim { get; set; }

        [JsonProperty("taking the dog for a walk")]
        public int? TakingTheDogForAWalk { get; set; }

        [JsonProperty("enjoying nature")]
        public int? EnjoyingNature { get; set; }

        [JsonProperty(@"feeding / petting animals_1")]
        public int? FeedingPettingAnimalsSub { get; set; }

        [JsonProperty("throwing frisbee")]
        public int? ThrowingFrisbee { get; set; }

        [JsonProperty("going for a walk")]
        public int? GoingForAWalk { get; set; }

        [JsonProperty("hiking")]
        public int? Hiking { get; set; }

        [JsonProperty("horseback riding")]
        public int? HorsebackRiding { get; set; }

        [JsonProperty("iceskating")]
        public int? Iceskating { get; set; }

        [JsonProperty("jogging")]
        public int? Jogging { get; set; }

        [JsonProperty(@"juggling / hula hoop")]
        public int? JugglingHulaHoop { get; set; }

        [JsonProperty("laying down protected (roof)")]
        public int? LayingDownProtected { get; set; }

        [JsonProperty("nordic skiing")]
        public int? NordicSkiing { get; set; }

        [JsonProperty("nordic walking")]
        public int? NordicWalking { get; set; }

        [JsonProperty("paddleboar")]
        public int? Paddleboar { get; set; }

        [JsonProperty(@"painting / drawing")]
        public int? PaintingDrawing { get; set; }

        [JsonProperty("parcouring")]
        public int? Parcouring { get; set; }

        [JsonProperty("picknick")]
        public int? Picknick { get; set; }

        [JsonProperty("playing_1")]
        public int? Playing1 { get; set; }

        [JsonProperty("playing an instrument")]
        public int? PlayingAnInstrument { get; set; }

        [JsonProperty("playing in the snow")]
        public int? PlayingInTheSnow { get; set; }

        [JsonProperty("playing with water")]
        public int? PlayingWithWater { get; set; }

        [JsonProperty("proposing")]
        public int? Proposing { get; set; }

        [JsonProperty("riding a boat")]
        public int? RidingABoat { get; set; }

        [JsonProperty("romance_1")]
        public int? RomanceSub { get; set; }

        [JsonProperty("playing with sand")]
        public int? PlayingWithSand { get; set; }

        [JsonProperty("riding a scooter")]
        public int? RidingAScotter { get; set; }

        [JsonProperty("selfie")]
        public int? Selfie { get; set; }

        [JsonProperty("consumption necessary")]
        public int? ConsumptionNecessary { get; set; }

        [JsonProperty("sitting on the ground")]
        public int? SittingOnTheGround { get; set; }

        [JsonProperty("skating")]
        public int? Skating { get; set; }

        [JsonProperty("slacklinin")]
        public int? Slacklinin { get; set; }

        [JsonProperty("tobogganing")]
        public int? Tobogganing { get; set; }

        [JsonProperty("snowshoein")]
        public int? Snowshoein { get; set; }

        [JsonProperty("spraying")]
        public int? Spraying { get; set; }

        [JsonProperty("star observation")]
        public int? StarObservation { get; set; }

        [JsonProperty("enjoying the sun")]
        public int? EnjoyingTheSun { get; set; }

        [JsonProperty("tableTenni")]
        public int? TableTennis { get; set; }

        [JsonProperty("taking pictures")]
        public int? TakingPictures { get; set; }

        [JsonProperty("throwing objects")]
        public int? ThrowingObjects { get; set; }

        [JsonProperty(@"observing / trainspotting")]
        public int? ObservingTrainspotting { get; set; }

        [JsonProperty("urban gardening")]
        public int? UrbanGardening { get; set; }

        [JsonProperty(@"working / studying")]
        public int? WorkingStudying { get; set; }

        [JsonProperty("yoga")]
        public int? Yoga { get; set; }

        [JsonProperty("youth")]
        public int? Youth { get; set; }

        public ViennaObservationDto ViennaObservationDto()
            => DefaultToObservationDto.ConvertDefaultToObservationDto(this);
    }
}