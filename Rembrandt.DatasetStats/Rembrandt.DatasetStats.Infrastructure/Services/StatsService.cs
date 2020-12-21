using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Rembrandt.Contracts.Classes.Stats;
using Rembrandt.DatasetStats.Core.Models;
using Rembrandt.DatasetStats.Core.Repository;

namespace Rembrandt.DatasetStats.Infrastructure.Services
{
    public class StatsService : IStatsService
    {
        private readonly IStatsRepository _statsRepository;
        private readonly IMapper _mapper;

        public StatsService(IStatsRepository statsRepository, IMapper mapper)
        {
            _statsRepository = statsRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ObservationStatDto>> GetObservationsStatAsync()
        {
            var result = new List<ObservationStatDto>();

            foreach(var observation in await _statsRepository.GetAllObservationsStatAsync())
            {
                result.Add(_mapper.Map<ObservationStat, ObservationStatDto>(observation));
            }
            return await Task.FromResult(result);
        }

        public async Task<ObservationStatDto> GetObservationStatAsync(int siteId)
        {
            var databaseStatObservation = await _statsRepository.GetObservationStatByIdAsync(siteId);
            return _mapper.Map<ObservationStat, ObservationStatDto>(databaseStatObservation);
        }
    }
}