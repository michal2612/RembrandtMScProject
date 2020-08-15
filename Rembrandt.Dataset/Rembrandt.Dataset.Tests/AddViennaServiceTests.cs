using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using Rembrandt.Contracts.Classes.Dataset.ViennaObservations;
using Rembrandt.Dataset.Core.Models.ViennaDataset;
using Rembrandt.Dataset.Core.Repositories;
using Rembrandt.Dataset.Infrastructure.Services;
using Xunit;

namespace Rembrandt.Dataset.Tests
{
    public class AddViennaServiceTests
    {
        private readonly ViennaObservationDto observationDto = new ViennaObservationDto();

        [Fact]
        public async Task add_observation_async()
        {
            var repositoryMock = new Mock<IViennaObservationRepository>();
            var mapperMock = new Mock<IMapper>();

            var serviceMock = new AddViennaService(repositoryMock.Object, mapperMock.Object);
            await serviceMock.AddObservationAsync(observationDto);

            repositoryMock.Verify(x => x.AddObservationAsync(It.IsAny<ViennaObservation>()), Times.Once);
        }

        [Fact]
        public async Task add_observation_null_object_async_shoulnt_inove()
        {
            var repositoryMock = new Mock<IViennaObservationRepository>();
            var mapperMock = new Mock<IMapper>();

            var serviceMock = new AddViennaService(repositoryMock.Object, mapperMock.Object);

            await Assert.ThrowsAsync<ArgumentNullException>( async () =>  await serviceMock.AddObservationAsync(null));
        }

        [Fact]
        public void add_multiple_observations_call_sing_method()
        {
            var repositoryMock = new Mock<IViennaObservationRepository>();
            var mapperMock = new Mock<IMapper>();

            var serviceMock = new AddViennaService(repositoryMock.Object, mapperMock.Object);
            var collection = new List<ViennaObservationDto>() { observationDto};
            serviceMock.AddObservationsAsync(collection);

            repositoryMock.Verify(x => x.AddObservationAsync(It.IsAny<ViennaObservation>()), Times.Exactly(collection.Count));
        }

        [Fact]
        public void add_multiple_no_elements_collection_should_not_call_method()
        {
            var repositoryMock = new Mock<IViennaObservationRepository>();
            var mapperMock = new Mock<IMapper>();

            var serviceMock = new AddViennaService(repositoryMock.Object, mapperMock.Object);
            var collection = new List<ViennaObservationDto>();
            serviceMock.AddObservationsAsync(collection);

            repositoryMock.Verify(x => x.AddObservationAsync(It.IsAny<ViennaObservation>()), Times.Never);
        }

        [Fact]
        public void add_multiple_null_collection_should_not_call_method()
        {
            var repositoryMock = new Mock<IViennaObservationRepository>();
            var mapperMock = new Mock<IMapper>();

            var serviceMock = new AddViennaService(repositoryMock.Object, mapperMock.Object);

            Assert.Throws<ArgumentNullException>(() => serviceMock.AddObservationsAsync(null));
        }
    }
}