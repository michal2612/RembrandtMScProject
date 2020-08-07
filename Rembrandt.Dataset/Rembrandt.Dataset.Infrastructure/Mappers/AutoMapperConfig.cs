using AutoMapper;
using Rembrandt.Contracts.Classes.Dataset;
using Rembrandt.Contracts.Classes.Dataset.ViennaObservations;
using Rembrandt.Dataset.Core.Models;
using Rembrandt.Dataset.Core.Models.ViennaDataset;

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

                cfg.CreateMap<ViennaObservationDto, ViennaObservation>();
                cfg.CreateMap<ViennaObservation, ViennaObservationDto>();

                cfg.CreateMap<ViennaAttributesDto, ViennaAttributes>();
                cfg.CreateMap<ViennaAttributes, ViennaAttributesDto>();

                cfg.CreateMap<ViennaSubAttributesDto, ViennaSubAttributes>();
                cfg.CreateMap<ViennaSubAttributes, ViennaSubAttributesDto>();
            })
            .CreateMapper();
    }
}