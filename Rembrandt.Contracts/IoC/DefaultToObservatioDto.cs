using System;
using Rembrandt.Contracts.Classes.Dataset;
using Rembrandt.Contracts.Classes.Dataset.ViennaObservations;

namespace Rembrandt.Contracts.IoC
{
    public static class DefaultToObservationDto
    {
        public static ObservationDto ConvertDefaultToObservationDto(DefaultObservation defaultObservation)
        {
            var observationDto = new ObservationDto() {
                SkipReason = defaultObservation.Skip_reason,
                TimeSubmitted = defaultObservation.Time_submitted,
                SiteId = (int)defaultObservation.Site_id,
                PhotoAddress = defaultObservation.Photos,
                PhotoTowardsPointCompass = (int)defaultObservation.Foto_towards_point_compass,
                Attributes = new AttributesDto()
                {
                    Lively = (int)defaultObservation.Lively,
                    Relaxing = (int)defaultObservation.Relaxing,
                    Tranquil = (int)defaultObservation.Tranquil,
                    Noisy = (int)defaultObservation.Noisy,
                    Crowded = (int)defaultObservation.Crowded,
                    Safe = (int)defaultObservation.Safe,
                    Beauty = (int)defaultObservation.Beauty,
                    Biodiversity = (int)defaultObservation.Biodiversity,
                    Trees = (int)defaultObservation.Trees,
                    Shrubs = (int)defaultObservation.Shrubs,
                    Lawns = (int)defaultObservation.Lawns,
                    Flowers = (int)defaultObservation.Flowers,
                    Natveg = (int)defaultObservation.Natveg,
                    Benches = (int)defaultObservation.Benches,
                    Play = (int)defaultObservation.Play,
                    Sports = (int)defaultObservation.Sports,
                    Garbage = (int)defaultObservation.Garbage,
                    Veget = (int)defaultObservation.Veget,
                    Paths = (int)defaultObservation.Paths,
                    Facilities = (int)defaultObservation.Facilities
                },
                Park = new ParkDto()
                {
                    MeasuredLocation = new LocationDto()
                    {
                        Longitude = defaultObservation.Long_site,
                        Latitude = defaultObservation.Lat_site,
                        GpsAccuracy = (int?)defaultObservation.Gps_accuracy
                    },
                    ActualLocation = new LocationDto()
                    {
                        Longitude = defaultObservation.Long_actual,
                        Latitude = defaultObservation.Lat_actual
                    }
                },
                Activities = new ActivitiesDto()
                {
                    Walking = CheckIfNullForBool(defaultObservation.Walking),
                    Jogging = CheckIfNullForBool(defaultObservation.Jogging),
                    Biking = CheckIfNullForBool(defaultObservation.Biking),
                    Relaxing = CheckIfNullForBool(defaultObservation.Relaxingy),
                    Socialising = CheckIfNullForBool(defaultObservation.Socialising)
                },
                Contributor = new ContributorDto()
                {
                    Id = defaultObservation.Contributor,
                    Age = (int?)defaultObservation.Age_cats,
                    Gender = (int?)defaultObservation.Gender,
                    DutchNationality = CheckIfNullForBool(defaultObservation.Dutch),
                    Education = (int?)defaultObservation.Education,
                    VisitDaily = CheckIfNullForBool(defaultObservation.Visit_daily),
                    VisitFreq = (int?)defaultObservation.Visit_freq,
                    VisitAlone = CheckIfNullForBool(defaultObservation.Alone),
                    VisitOtherParks = (int?)defaultObservation.Oth_parks,
                    MoreInvolved = CheckIfNullForBool(defaultObservation.More_inv),
                    NatureOriented = (int?)defaultObservation.Nature,
                    WithChildren = CheckIfNullForBool(defaultObservation.Children)
                },
                Source = @"https://zenodo.org/record/3688392/#_.XoHitur7S70"
            };
            return observationDto;
        }

        public static ViennaObservationDto ConvertDefaultToObservationDto(DefaultViennaObservation defaultObservation)
        {
            var viennaObservation = new ViennaObservationDto()
            {
                User = defaultObservation.User,
                TimeSubmitted = defaultObservation.TimeSubmitted,
                PhotoPointUrl = defaultObservation.FotoPointUrl,
                PhotoNorthUrl = defaultObservation.FotoNorthUrl,
                PhotoEastUrl = defaultObservation.FotoEastUrl,
                PhotoSouthUrl = defaultObservation.FotoSouthUrl,
                PhotoWestUrl = defaultObservation.FotoWestUrl,
                Location = new LocationDto()
                {
                    Latitude = defaultObservation.Latitude,
                    Longitude = defaultObservation.Longitude
                },
                Attributes = new ViennaAttributesDto()
                {
                    FeelingWell = defaultObservation.FeelingWell,
                    Attractive = defaultObservation.Attractive,
                    Clean = defaultObservation.Clean,
                    Facilities = defaultObservation.Facilities,
                    Quiet = defaultObservation.Quiet,
                    Secure = defaultObservation.Secure,
                    AnimalsNature = defaultObservation.AnimalsNature,
                    Playing = defaultObservation.Playing,
                    Romance = defaultObservation.Romance,
                    ExerciseSport = defaultObservation.ExerciseSport,
                    SittingLayingDown = defaultObservation.SittingLayingDown,
                    Winter = defaultObservation.Winter,
                    Creativity = defaultObservation.Creativity,
                    Summer = defaultObservation.Summer,
                    CoolingGreen = ConvertIntTobool(defaultObservation.CoolingGreen),
                    CoolingWind = ConvertIntTobool(defaultObservation.CoolingWind),
                    DrikingWater = ConvertIntTobool(defaultObservation.DrinkingWater),
                    Shadow = ConvertIntTobool(defaultObservation.Shadow),
                    Water = ConvertIntTobool(defaultObservation.Water)
                },
                SubAttributes = GetViennaSubAttributesDto(defaultObservation)
            };
            return viennaObservation;
        }

        static bool? CheckIfNullForBool(string value)
            => bool.TryParse(value, out bool result) ? result : (bool?)null;

        static int? CheckIfNUllForInt(string value)
            => Int32.TryParse(value, out int result) ? result : (int?)null;

        static bool ConvertIntTobool(int? value)
            => value == null ? false : true;

        static ViennaSubAttributesDto GetViennaSubAttributesDto(DefaultViennaObservation defaultViennaObservation)
        {
            var subAttributes = new ViennaSubAttributesDto();

            foreach(var attribute in subAttributes.GetType().GetProperties())
            {
                var currentAttribute = defaultViennaObservation.GetType().GetProperty(attribute.Name);
                if(currentAttribute != null)
                    subAttributes.GetType().GetProperty(currentAttribute.Name).SetValue(subAttributes, ConvertIntTobool((int?)defaultViennaObservation.GetType().GetProperty(currentAttribute.Name).GetValue(defaultViennaObservation)));
            }

            return subAttributes;
        }
    }
}