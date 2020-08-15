using System;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using Rembrandt.Dataset.Core.Repositories;
using Rembrandt.Dataset.Infrastructure.Services;
using Xunit;

namespace Rembrandt.Dataset.Tests
{
    public class ViennaDatasetServiceTests
    {
        [Fact]
        public async Task get_all_observations()
        {
            var repositoryMock = new Mock<IViennaObservationRepository>();
            var mapperMock = new Mock<IMapper>();

            var viennaService = new ViennaDatasetService(mapperMock.Object, repositoryMock.Object);

            await viennaService.GetAllObservationsAsync();

            repositoryMock.Verify(x => x.GetAllObservationsAsync(), Times.Once);
        }

        [Fact]
        public async Task get_observations_by_id()
        {
            var repositoryMock = new Mock<IViennaObservationRepository>();
            var mapperMock = new Mock<IMapper>();

            var viennaService = new ViennaDatasetService(mapperMock.Object, repositoryMock.Object);

            await viennaService.GetObservationsByIdAsync("sample-value");

            repositoryMock.Verify(x => x.GetObservationsAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task get_observations_by_white_space_id_should_throw_an_error()
        {
            var repositoryMock = new Mock<IViennaObservationRepository>();
            var mapperMock = new Mock<IMapper>();

            var viennaService = new ViennaDatasetService(mapperMock.Object, repositoryMock.Object);

            await Assert.ThrowsAsync<ArgumentException>(async () => await viennaService.GetObservationsByIdAsync(""));
        }

        [Fact]
        public async Task get_observations_by_null_value_id_should_throw_an_error()
        {
            var repositoryMock = new Mock<IViennaObservationRepository>();
            var mapperMock = new Mock<IMapper>();

            var viennaService = new ViennaDatasetService(mapperMock.Object, repositoryMock.Object);

            await Assert.ThrowsAsync<ArgumentException>(async () => await viennaService.GetObservationsByIdAsync(null));
        }
    }
}