using AutoMapper;
using Rembrandt.Contracts.Classes.Jwt;
using Rembrandt.Contracts.Classes.User;
using Rembrandt.Users.Core.Models;

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