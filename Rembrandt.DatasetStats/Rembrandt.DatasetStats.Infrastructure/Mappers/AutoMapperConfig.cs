using AutoMapper;
using Rembrandt.Contracts.Classes.Stats;
using Rembrandt.DatasetStats.Core.Models;

namespace Rembrandt.DatasetStats.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ObservationStat, ObservationStatDto>();
                cfg.CreateMap<ObservationStatDto, ObservationStat>();

                cfg.CreateMap<ActivitiesStat, ActivitiesStatDto>();
                cfg.CreateMap<ActivitiesStatDto, ActivitiesStat>();

                cfg.CreateMap<AttributesStat, AttributesStatDto>();
                cfg.CreateMap<AttributesStatDto, AttributesStat>();

                cfg.CreateMap<SkipReasons, SkipReasonsDto>();
                cfg.CreateMap<SkipReasonsDto, SkipReasons>();

                cfg.CreateMap<PhotoAddress, PhotoAddressDto>();
                cfg.CreateMap<PhotoAddressDto, PhotoAddress>();
            })
            .CreateMapper();
    }
}