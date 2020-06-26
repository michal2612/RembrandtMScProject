using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Rembrandt.Dataset.Core.Models;
using Rembrandt.Dataset.Core.Repositories;

namespace Rembrandt.Dataset.Infrastructure.Services
{
    public class DatasetService : IDatasetService
    {
        private readonly IObservationRepository _observationRepository;

        public DatasetService(IObservationRepository observationRepository)
        {
            _observationRepository = observationRepository;
        }

        public Task AddObservationAsync(Observation observeration)
            => _observationRepository.AddObservationAsync(observeration);

        public Task<IEnumerable<Observation>> GetAllObservationsAsync()
            => _observationRepository.GetAllObservationsAsync();

        public Task<Observation> GetObservationAsync(string id)
            => _observationRepository.GetObservationAsync(id);
    }
}