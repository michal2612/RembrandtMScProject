using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rembrandt.Dataset.Core.Models;

namespace Rembrandt.Dataset.Infrastructure.Services
{
    public interface IDatasetService
    {
        Task<IEnumerable<Observation>> GetAllObservations();
        Task<Observation> GetObservation(Guid guid);
        Task<Observation> GetObservation(int id);
        Task AddObservation(Observation observeration);

        Task AddObservation(string observeration);
    }
}