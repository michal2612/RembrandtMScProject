using System.Threading.Tasks;
using AutoMapper;
using Moq;
using Rembrandt.Dataset.Core.Repositories;
using Rembrandt.Dataset.Infrastructure.Services;
using Xunit;

namespace Rembrandt.Dataset.Tests
{
    public class DatasetServiceTests
    {
        [Fact]
        public async Task get_observation_async_should_return_observation_dto()
        {
            var observationRepositoryMock = new Mock<IObservationRepository>();
            var mapperMock = new Mock<IMapper>();

            var addDataService = new DatasetService(observationRepositoryMock.Object, mapperMock.Object);
            await addDataService.GetObservationsAsync("value");

            observationRepositoryMock.Verify(x => x.GetObservationsAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task get_observations_with_id_null()
        {
            var observationRepositoryMock = new Mock<IObservationRepository>();
            var mapperMock = new Mock<IMapper>();

            var addDataService = new DatasetService(observationRepositoryMock.Object, mapperMock.Object);
            await addDataService.GetObservationsAsync(null);

            observationRepositoryMock.Verify(x => x.GetObservationsAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task get_observations_with_id_white_space()
        {
            var observationRepositoryMock = new Mock<IObservationRepository>();
            var mapperMock = new Mock<IMapper>();

            var addDataService = new DatasetService(observationRepositoryMock.Object, mapperMock.Object);
            await addDataService.GetObservationsAsync("");

            observationRepositoryMock.Verify(x => x.GetObservationsAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task get_multiple_observations_async_should_return_observations_dto()
        {
            var observationRepositoryMock = new Mock<IObservationRepository>();
            var mapperMock = new Mock<IMapper>();

            var addDataService = new DatasetService(observationRepositoryMock.Object, mapperMock.Object);
            await addDataService.GetAllObservationsAsync();

            observationRepositoryMock.Verify(x => x.GetAllObservationsAsync(), Times.Once);
        }

        [Fact]
        public async Task get_multiple_observations_with_site_id_int()
        {
            var observationRepositoryMock = new Mock<IObservationRepository>();
            var mapperMock = new Mock<IMapper>();

            var addDataService = new DatasetService(observationRepositoryMock.Object, mapperMock.Object);
            await addDataService.GetMultipleObservationsDtobySiteIdAsync(1);

            observationRepositoryMock.Verify(x => x.GetAllObservationsAsync(), Times.Once);
        }
    }
}