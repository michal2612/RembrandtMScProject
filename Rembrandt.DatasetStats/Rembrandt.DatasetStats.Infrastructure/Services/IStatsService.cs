using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rembrandt.Contracts.Classes.Dataset;
using Rembrandt.Contracts.Classes.Stats;
using Rembrandt.DatasetStats.Core.Models;

namespace Rembrandt.DatasetStats.Infrastructure.Services
{
    public interface IStatsService
    {
        Task<ObservationStatDto> GetObservationStatAsync(int siteId);
        Task<IEnumerable<ObservationStatDto>> GetObservationsStatAsync();
    }
}