using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Rembrandt.Users.Infrastructure.DTO;
using Rembrandt.Users.Infrastructure.Settings;
using Xunit;

namespace Rembrandt.Users.Tests.EndToEnd.Controllers
{
    public class UsersControllerTests
    {
        private readonly WebApplicationFactory<Rembrandt.Users.Api.Startup> _factory;
        public UsersControllerTests()
            => _factory = new WebApplicationFactory<Rembrandt.Users.Api.Startup>();

        [Fact]
        public async Task given_valid_email_should_exist()
        {
            
            var email = "emailaddress1@test.com";
            var response = await _factory.CreateClient().GetAsync($"users/{email}");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserDto>(responseString);

            user.Email.Should().Equals(email);
        }

        [Fact]
        public async Task give_invalid_email_should_exist()
        {
            var email = "incorrect_email";
            var response = await _factory.CreateClient().GetAsync($"users/{email}");

            response.StatusCode.Should().Equals(HttpStatusCode.NotFound);
        }
    }
}