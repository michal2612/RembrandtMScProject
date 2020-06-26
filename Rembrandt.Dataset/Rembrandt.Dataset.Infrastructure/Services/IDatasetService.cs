using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rembrandt.Dataset.Core.Models;

namespace Rembrandt.Dataset.Infrastructure.Services
{
    public interface IDatasetService
    {
        Task AddObservationAsync(Observation observeration);
        Task<Observation> GetObservationAsync(string id);
        Task<IEnumerable<Observation>> GetAllObservationsAsync();
    }
}