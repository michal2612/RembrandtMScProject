using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rembrandt.Dataset.Core.ContextFiles;
using Rembrandt.Dataset.Core.Models;
using Rembrandt.Dataset.Core.Repositories;

namespace Rembrandt.Dataset.Infrastructure.Repositories
{
    public class ObservationRepository : IObservationRepository
    {
        private readonly ObservationContext _observationContext;

        public ObservationRepository()
        {
            _observationContext = new ObservationContext();
        }

        public async Task AddObservationAsync(Observation observeration)
        {
            var observationInside = new Observation("noskup", DateTime.UtcNow, 1, "a", 1, new Attributes(1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1), new Park(new Location(1,1,1),new Location(1,1)), new Activities(true,true,true,true,true), new Contributor("",4,1,true,1,true,1,true,1,true,1,true));

            using(var db = new ObservationContext())
            {
                await db.Observations.AddAsync(observationInside);
                //await db.Observations.AddAsync(observeration);
                await db.SaveChangesAsync();
            };
        }

        public async Task<Observation> GetObservationAsync(string id)
            => await Task.FromResult(_observationContext.Observations.SingleOrDefault(x => x.Contributor.Id == id));
            
        public async Task<IEnumerable<Observation>> GetAllObservationsAsync()
        {
            using(var db = new ObservationContext())
            {
                return await Task.FromResult(db.Observations);
            }
        }
    }
}