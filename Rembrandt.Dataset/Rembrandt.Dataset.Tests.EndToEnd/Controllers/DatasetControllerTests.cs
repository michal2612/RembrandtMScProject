using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Rembrandt.Contracts.Classes.Dataset;
using Xunit;

namespace Rembrandt.Dataset.Tests.EndToEnd
{
    public class DatasetControllerTests
    {
        readonly WebApplicationFactory<Rembrandt.Dataset.Api.Startup> _factory;

        public DatasetControllerTests()
            => _factory = new WebApplicationFactory<Api.Startup>();

        [Fact]
        public async Task should_return_list_of_records_in_db()
        {
            //arrange
            var response = await _factory.CreateClient().GetAsync("dataset/");
            response.EnsureSuccessStatusCode();

            //act
            var responseString = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<ObservationDto[]>(responseString);
            //assert
            list.Length.Should().BeGreaterThan(1);
        }

        [Fact]
        public async Task should_return_one_record()
        {
            string id = "f899d1239c2f22c7c13f71f135289cce";
            var response = await _factory.CreateClient().GetAsync($"dataset/{id}");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var observationValue = JsonConvert.DeserializeObject<ObservationDto>(responseString);

            observationValue.SiteId.Should().NotBe(null);
        }
    }
}