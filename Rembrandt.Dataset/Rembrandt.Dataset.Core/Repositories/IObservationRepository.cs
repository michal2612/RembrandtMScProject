using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rembrandt.Dataset.Core.Models;

namespace Rembrandt.Dataset.Core.Repositories
{
    public interface IObservationRepository
    {
        Task<IEnumerable<Observation>> GetAllObservations();
        Task<Observation> GetObservation(Guid guid);
        Task<Observation> GetObservation(int id);
    }
}