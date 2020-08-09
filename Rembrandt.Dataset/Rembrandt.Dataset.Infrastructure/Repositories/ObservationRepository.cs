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

        public async Task<IEnumerable<Observation>> GetObservationsAsync(string id)
            => await _observationContext.Observations
                .Include(obs => obs.Activities)
                .Include(obs => obs.Attributes)
                .Include(obs => obs.Contributor)
                .Include(obs => obs.Park)
                    .ThenInclude(loc => loc.MeasuredLocation)
                .Include(obs => obs.Park)
                    .ThenInclude(loc => loc.ActualLocation)
                .Where(c => c.Contributor.Id == id)
                .ToListAsync();
            
        public async Task<IEnumerable<Observation>> GetAllObservationsAsync()
            => await _observationContext.Observations
                .Include(obs => obs.Activities)
                .Include(obs => obs.Attributes)
                .Include(obs => obs.Contributor)
                .Include(obs => obs.Park)
                    .ThenInclude(loc => loc.MeasuredLocation)
                .Include(obs => obs.Park)
                    .ThenInclude(loc => loc.ActualLocation)
                .ToListAsync();
    }
}