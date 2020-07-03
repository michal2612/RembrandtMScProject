using System;
using Rembrandt.Dataset.Core.Helpers;
using Rembrandt.Dataset.Infrastructure.DTO;

namespace Rembrandt.Dataset.Infrastructure.Mappers
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
                }
            };
            return observationDto;
        }

        private static bool? CheckIfNullForBool(string value)
        {
            if(bool.TryParse(value, out bool result))
                return result;
            else
                return null;
        }

        private static int? CheckIfNUllForInt(string value)
        {
            if(Int32.TryParse(value, out int result))
                return result;
            else
                return null;
        }
    }
}