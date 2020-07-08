using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using Rembrandt.Contracts.Classes.Dataset;
using Rembrandt.Contracts.IoC;
using Rembrandt.Dataset.Core.Models;
using Rembrandt.Dataset.Core.Repositories;
using Rembrandt.Dataset.Infrastructure.Services;
using Xunit;

namespace Rembrandt.Dataset.Tests
{
    public class AddDataServiceTests
    {
        private ObservationDto ObservationDto = new ObservationDto()
        {
            SkipReason = "noskip",
            TimeSubmitted = DateTime.UtcNow,
            SiteId = 0,
            PhotoAddress = "default",
            PhotoTowardsPointCompass = 15,
            Attributes = new AttributesDto(3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3),
            Park = new ParkDto()
            {
                MeasuredLocation = new LocationDto()
                {
                    Longitude = 5,
                    Latitude = 5,
                    GpsAccuracy = 5
                },
                ActualLocation = new LocationDto()
                {
                    Longitude = 5,
                    Latitude = 5
                }
            },
            Activities = new ActivitiesDto()
            {
                Walking = true,
                Jogging = false,
                Biking = true,
                Relaxing = false,
                Socialising = false
            },
            Contributor = new ContributorDto()
            {
                Id = "Secret",
                Age = 4,
                Gender = 1,
                DutchNationality = true,
                Education = 2,
                VisitDaily = true,
                VisitFreq = 1,
                VisitAlone = true,
                VisitOtherParks = 1,
                MoreInvolved = true,
                NatureOriented = 1,
                WithChildren = false
            }
        };

        // public async Task AddObservationDtoAsync(IObservationDto observation)
        [Fact]
        public async Task add_observation_async_should_invoke_add_async_on_repository()
        {
            var observationRepositoryMock = new Mock<IObservationRepository>();
            var mapperMock = new Mock<IMapper>();

            var addDataService = new AddDataService(observationRepositoryMock.Object, mapperMock.Object);
            await addDataService.AddObservationDtoAsync(ObservationDto);

            observationRepositoryMock.Verify(x => x.AddObservationAsync(It.IsAny<Observation>()), Times.Once);
        }
        
        [Fact]
        public async Task add_null_observation_should_return_exception()
        {
            var observationRepositoryMock = new Mock<IObservationRepository>();
            var mapperMock = new Mock<IMapper>();

            var addDataService = new AddDataService(observationRepositoryMock.Object, mapperMock.Object);
            await Assert.ThrowsAsync<ArgumentNullException>( async () => await addDataService.AddObservationDtoAsync(null));

            observationRepositoryMock.Verify(x => x.AddObservationAsync(It.IsAny<Observation>()), Times.Never);
        }

        // public async Task AddObservationsDtoAsync(IEnumerable<IObservationDto> observations)
        [Fact]
        public async Task add_observation_async_should_invoke_add_async_on_repository_more_than_once()
        {
            var observationRepositoryMock = new Mock<IObservationRepository>();
            var mapperMock = new Mock<IMapper>();

            var addDataService = new AddDataService(observationRepositoryMock.Object, mapperMock.Object);
            await addDataService.AddObservationsDtoAsync(new List<IObservationDto>() {ObservationDto, ObservationDto});

            observationRepositoryMock.Verify(x => x.AddObservationAsync(It.IsAny<Observation>()), Times.Exactly(2));
        }

        [Fact]
        public async Task add_multiple_observations_should_return_exception()
        {
            var observationRepositoryMock = new Mock<IObservationRepository>();
            var mapperMock = new Mock<IMapper>();

            var addDataService = new AddDataService(observationRepositoryMock.Object, mapperMock.Object);
            await Assert.ThrowsAsync<ArgumentNullException>( async () => await addDataService.AddObservationsDtoAsync(null));

            observationRepositoryMock.Verify(x => x.AddObservationAsync(It.IsAny<Observation>()), Times.Never);
        }

        // public async Task AddMultipleDefaultListAsync(JsonElement defaultMultipleList)
        [Fact]
        public async Task add_multiple_observations_should_invoke_add_async_on_repository_more_than_once()
        {
            var observationRepositoryMock = new Mock<IObservationRepository>();
            var mapperMock = new Mock<IMapper>();
            var addDataService = new AddDataService(observationRepositoryMock.Object, mapperMock.Object);

            var observationList = JsonDocument.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"..\..\..\.\observations.json")));
            await addDataService.AddMultipleDefaultListAsync(observationList.RootElement);

            observationRepositoryMock.Verify(x => x.AddObservationAsync(It.IsAny<Observation>()), Times.AtLeast(2));
        }

        [Fact]
        public async Task add_multiple_observations_should_not_invoke_add_async()
        {
            var observationRepositoryMock = new Mock<IObservationRepository>();
            var mapperMock = new Mock<IMapper>();
            var addDataService = new AddDataService(observationRepositoryMock.Object, mapperMock.Object);

            var observationList = JsonDocument.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"..\..\..\.\observationsEmpty.json")));
            await addDataService.AddMultipleDefaultListAsync(observationList.RootElement);

            observationRepositoryMock.Verify(x => x.AddObservationAsync(It.IsAny<Observation>()), Times.Never);
        }
    }
}