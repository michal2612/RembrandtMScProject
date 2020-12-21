using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rembrandt.Dataset.Core.Context;
using Rembrandt.Dataset.Core.Models.ViennaDataset;
using Rembrandt.Dataset.Core.Repositories;

namespace Rembrandt.Dataset.Infrastructure.Repositories
{
    public class ViennaObservationRepository : IViennaObservationRepository
    {
        private readonly ObservationContext _observationContext;

        public ViennaObservationRepository()
            => _observationContext = new ObservationContext();
        
        public async Task AddObservationAsync(ViennaObservation observation)
        {
            await _observationContext.ViennaObservations.AddAsync(observation);
            await _observationContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ViennaObservation>> GetObservationsAsync(string userId)
        {
            var observation = await _observationContext.ViennaObservations
                .Include(obs => obs.Location)
                .Include(obs => obs.Attributes)
                .Include(obs => obs.SubAttributes)
                .Where(c => c.User == userId)
                .ToListAsync();
            
            return observation == null ? null : observation;
        }

        public async Task<IEnumerable<ViennaObservation>> GetAllObservationsAsync()
            => await _observationContext.ViennaObservations
                .Include(obs => obs.Location)
                .Include(obs => obs.Attributes)
                .Include(obs => obs.SubAttributes)
                .ToListAsync();
    }
}