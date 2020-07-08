using AutoMapper;
using Rembrandt.Contracts.Classes.Dataset;
using Rembrandt.Dataset.Core.Models;

namespace Rembrandt.Dataset.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg => {
                
                cfg.CreateMap<Observation, ObservationDto>();
                cfg.CreateMap<ObservationDto, Observation>();

                cfg.CreateMap<Attributes, AttributesDto>();
                cfg.CreateMap<AttributesDto, Attributes>();

                cfg.CreateMap<Activities, ActivitiesDto>();
                cfg.CreateMap<ActivitiesDto, Activities>();

                cfg.CreateMap<Contributor, ContributorDto>();
                cfg.CreateMap<ContributorDto, Contributor>();

                cfg.CreateMap<Location, LocationDto>();
                cfg.CreateMap<LocationDto, Location>();

                cfg.CreateMap<Park, ParkDto>();
                cfg.CreateMap<ParkDto, Park>();
            })
            .CreateMapper();
    }
}