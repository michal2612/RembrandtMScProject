using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rembrandt.Dataset.Core.Models;

namespace Rembrandt.Dataset.Core.Repositories
{
    public interface IObservationRepository
    {
        Task AddObservationAsync(Observation observeration);
        Task<Observation> GetObservationAsync(int id);
        Task<IEnumerable<Observation>> GetAllObservationsAsync();
    }
}