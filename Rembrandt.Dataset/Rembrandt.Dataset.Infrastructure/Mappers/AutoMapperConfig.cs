using AutoMapper;
using Rembrandt.Dataset.Core.Models;
using Rembrandt.Dataset.Infrastructure.DTO;

namespace Rembrandt.Dataset.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg => {
                cfg.CreateMap<Observation, ObservationDto>();
                cfg.CreateMap<Attributes, AttributesDto>();
                cfg.CreateMap<Activities, ActivitiesDto>();
                cfg.CreateMap<Contributor, ContributorDto>();
                cfg.CreateMap<Location, LocationDto>();
                cfg.CreateMap<Park, ParkDto>();
            })
            .CreateMapper();
    }
}