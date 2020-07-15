using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rembrandt.Contracts.Classes.Stats;
using Rembrandt.DatasetStats.Infrastructure.Services;

namespace Rembrandt.DatasetStats.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatsController : ControllerBase
    {
        private readonly IStatsService _statsService;
        public StatsController(IStatsService statsService)
        {
            _statsService = statsService;
        }

        [HttpGet]
        public async Task<ObservationStatDto> ReturnStatOfLocation(int siteId)
        {
            return await _statsService.GetObservationStat(siteId);
        }
    }
}