using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rembrandt.Dataset.Core.Context;
using Rembrandt.Dataset.Core.Models;
using Rembrandt.Dataset.Core.Repositories;

namespace Rembrandt.Dataset.Infrastructure.Repositories
{
    public class ObservationRepository : IObservationRepository
    {
        private readonly ObservationContext _observationContext;

        public ObservationRepository()
            => _observationContext = new ObservationContext();

        public async Task AddObservationAsync(Observation observeration)
        {
            await _observationContext.Observations.AddAsync(observeration);
            await _observationContext.SaveChangesAsync();
        }

        public async Task<Observation> GetObservationAsync(string id)
            => await Task.FromResult(_observationContext.Observations.SingleOrDefault(x => x.Contributor.Id == id));
            
        public async Task<IEnumerable<Observation>> GetAllObservationsAsync()
            => await Task.FromResult(_observationContext.Observations.ToList());
    }
}