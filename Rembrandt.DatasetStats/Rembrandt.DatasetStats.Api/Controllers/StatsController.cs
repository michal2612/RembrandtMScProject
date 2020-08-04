using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rembrandt.Contracts.Classes.Dataset;
using Rembrandt.Contracts.Classes.Stats;
using Rembrandt.DatasetStats.Infrastructure.Services;

namespace Rembrandt.DatasetStats.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatsController : ControllerBase
    {
        readonly IStatsService _statsService;

        readonly IUpdateObservations _updateObservationsService;

        public StatsController(IStatsService statsService, IUpdateObservations updateObservations)
        {
            _statsService = statsService;
            _updateObservationsService = updateObservations;
        }

        [HttpGet("{siteId}")]
        public async Task<ObservationStatDto> ReturnStatOfLocation(int siteId)
        {
            return await _statsService.GetObservationStatAsync(siteId);
        }

        [HttpPost]
        public async Task ReturnStatOfAllLocations(IEnumerable<ObservationDto> observations)
        {
            await _updateObservationsService.UpdateObservationsAsync(observations);
        }

        [HttpGet]
        public async Task<IEnumerable<ObservationStatDto>> ReturnStatOfAllLocations()
            => await _statsService.GetObservationsStatAsync();

        [HttpPut("/update")]
        public async Task UpdateObservationStatAsync(UpdateObservationStatDto updateObservationStatDto)
        {
            await _updateObservationsService.UpdateSingleObservationAsync
                (updateObservationStatDto.SiteId, updateObservationStatDto.Observations);
        }
    }
}