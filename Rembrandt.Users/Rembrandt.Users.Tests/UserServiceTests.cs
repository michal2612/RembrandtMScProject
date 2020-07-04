using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Moq;
using Rembrandt.Users.Core.Repositories;
using Xunit;
using Rembrandt.Users.Infrastructure.Services;
using Rembrandt.Users.Core.Models;

namespace Rembrandt.Users.Tests
{
    public class UserServiceTests
    {
        [Fact]
        public async Task Test()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            var encryperMock = new Mock<IEncrypter>();
            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object, encryperMock.Object);

            await userService.RegisterAsync("asd","dsa","asd");

            userRepositoryMock.Verify(x => x.AddUserAsync(It.IsAny<User>()), Times.Once);
        }
    }
}