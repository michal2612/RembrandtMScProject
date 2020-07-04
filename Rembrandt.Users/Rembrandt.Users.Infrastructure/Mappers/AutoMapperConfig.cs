using AutoMapper;
using Rembrandt.Users.Core.Models;
using Rembrandt.Users.Infrastructure.DTO;

namespace Rembrandt.Users.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<UserDto, User>();
            })
            .CreateMapper();
    }
}