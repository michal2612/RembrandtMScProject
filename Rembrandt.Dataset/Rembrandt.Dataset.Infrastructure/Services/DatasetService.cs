using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Rembrandt.Dataset.Core.Models;

namespace Rembrandt.Dataset.Infrastructure.Services
{
    public class DatasetService : IDatasetService
    {
        public Task AddObservation(Observation observeration)
        {
            throw new NotImplementedException();
        }

        public Task AddObservation(string observation)
        {
            var observationToJson = JsonConvert.DeserializeObject(observation);
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Observation>> GetAllObservations()
        {
            throw new NotImplementedException();
        }

        public Task<Observation> GetObservation(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<Observation> GetObservation(int id)
        {
            throw new NotImplementedException();
        }
    }
}