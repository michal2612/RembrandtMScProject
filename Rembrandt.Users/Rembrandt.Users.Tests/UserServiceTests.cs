using System.Threading.Tasks;
using AutoMapper;
using Moq;
using Rembrandt.Users.Core.Repositories;
using Xunit;
using Rembrandt.Users.Infrastructure.Services;
using Rembrandt.Users.Core.Models;
using System;

namespace Rembrandt.Users.Tests
{
    public class UserServiceTests
    {
        //REGISTER TESTS
        [Fact]
        public async Task register_user_should_invoke_once()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            var encrypterMock = new Mock<Encrypter>();
            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object, encrypterMock.Object);

            await userService.RegisterAsync("veruprofession@email.com","sercretPassword!");

            userRepositoryMock.Verify(x => x.AddUserAsync(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public async Task register_user_with_null_value_should_not_invoke()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            var encrypterMock = new Mock<Encrypter>();
            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object, encrypterMock.Object);

            await Assert.ThrowsAsync<ArgumentNullException>(async () => await userService.RegisterAsync(null, null));
        }

        [Fact]
        public async Task register_user_with_null_password_value_should_not_invoke()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            var encrypterMock = new Mock<Encrypter>();
            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object, encrypterMock.Object);

            await Assert.ThrowsAsync<ArgumentNullException>(async () => await userService.RegisterAsync("sample@email.com", null));
        }

        [Fact]
        public async Task register_user_with_null_email_value_should_not_invoke()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            var encrypterMock = new Mock<Encrypter>();
            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object, encrypterMock.Object);

            await Assert.ThrowsAsync<ArgumentNullException>(async () => await userService.RegisterAsync(null, "password"));
        }

        //LOGIN
        [Fact]
        public async Task login_should_invoke_repository_once()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            var encrypterMock = new Mock<Encrypter>();
            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object, encrypterMock.Object);

            await Assert.ThrowsAsync<ArgumentNullException>(async () => await userService.LoginAsync("", "proper-password"));
        }
    }
}