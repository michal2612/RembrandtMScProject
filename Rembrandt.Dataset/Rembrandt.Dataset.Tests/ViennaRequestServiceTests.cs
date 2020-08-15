using System;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using Rembrandt.Contracts.Classes.Dataset.ViennaRequests;
using Rembrandt.Dataset.Core.Repositories;
using Rembrandt.Dataset.Infrastructure.Services;
using Xunit;

namespace Rembrandt.Dataset.Tests
{
    public class ViennaRequestServiceTests
    {
        [Fact]
        public async Task request_should_call_repository_at_least_once()
        {
            var repositoryMock = new Mock<IViennaObservationRepository>();
            var mapper = new Mock<IMapper>();

            var requestService = new ViennaRequestService(repositoryMock.Object, mapper.Object);
            var viennaRequest = new ViennaRequest();

            await requestService.GetMatchingObservationsDtoAsync(viennaRequest);
            repositoryMock.Verify(x => x.GetAllObservationsAsync(), Times.Once);
        }

        [Fact]
        public async Task request_null_should_throw_an_error()
        {
            var repositoryMock = new Mock<IViennaObservationRepository>();
            var mapper = new Mock<IMapper>();

            var requestService = new ViennaRequestService(repositoryMock.Object, mapper.Object);

            await Assert.ThrowsAsync<ArgumentNullException>(async () => await requestService.GetMatchingObservationsDtoAsync(null));
        }
    }
}