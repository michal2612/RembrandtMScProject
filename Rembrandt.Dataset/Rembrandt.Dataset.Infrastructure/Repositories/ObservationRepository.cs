using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rembrandt.Dataset.Core.Models;
using Rembrandt.Dataset.Core.Repositories;

namespace Rembrandt.Dataset.Infrastructure.Repositories
{
    public class ObservationRepository : IObservationRepository
    {
        public Task AddObservation(Observation observeration)
        {
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