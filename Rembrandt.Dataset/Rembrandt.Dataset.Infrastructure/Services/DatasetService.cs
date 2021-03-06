using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Rembrandt.Contracts.Classes.Dataset;
using Rembrandt.Dataset.Core.Models;
using Rembrandt.Dataset.Core.Repositories;

namespace Rembrandt.Dataset.Infrastructure.Services
{
    public class DatasetService : IDatasetService
    {
        private readonly IObservationRepository _observationRepository;
        
        private readonly IMapper _mapper;

        public DatasetService(IObservationRepository observationRepository, IMapper mapper)
        {
            _observationRepository = observationRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ObservationDto>> GetAllObservationsAsync()
            => from Observation observation in await _observationRepository.GetAllObservationsAsync()
               select _mapper.Map<Observation, ObservationDto>(observation);

        public async Task<IEnumerable<ObservationDto>> GetMultipleObservationsDtobySiteIdAsync(int siteId)
            => from Observation observation in await _observationRepository.GetAllObservationsAsync()
               where observation.SiteId == siteId
               select _mapper.Map<Observation, ObservationDto>(observation);

        public async Task<IEnumerable<ObservationDto>> GetObservationsAsync(string id)
            => from Observation observation in await _observationRepository.GetObservationsAsync(id)
               select _mapper.Map<Observation, ObservationDto>(observation);
    }
}