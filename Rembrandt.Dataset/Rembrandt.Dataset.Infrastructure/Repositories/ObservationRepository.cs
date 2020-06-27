using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rembrandt.Dataset.Core.Models;
using Rembrandt.Dataset.Core.Repositories;

namespace Rembrandt.Dataset.Infrastructure.Repositories
{
    public class ObservationRepository : IObservationRepository
    {
        private ISet<Observation> _values = new HashSet<Observation>()
        {
            new Observation(
                skipReason: null,
                timeSubmitted: DateTime.UtcNow,
                siteId: 15,
                photoAddress: null,
                photoTowardsPointCompass: 0,
                attributes: new Attributes(
                    5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5
                ),
                park : new Park(
                    measuredLocation: new Location(
                        longitude: 14f,
                        latitude: 50f
                    ),
                    actualLocation: new Location(
                        longitude: 40f,
                        latitude: 13f
                    )
                ),
                activities : new Activities(
                    walking: true,
                    jogging: null,
                    biking: true,
                    relaxing: true,
                    socialising: true
                ),
                contributor : new Contributor(
                    id: "valie",
                    age: 4,
                    gender: 1,
                    dutchNationality: false,
                    education: 1,
                    visitDaily: false,
                    visitFrequency: 1,
                    visitAlone: true,
                    visitOtherParks: 1,
                    moreInvoled: true,
                    natureOriented: 2,
                    withChildren: true
                )
            )
        };

        public async Task AddObservationAsync(Observation observeration)
            => await Task.FromResult(_values.Add(observeration));

        public async Task<Observation> GetObservationAsync(string id)
            => await Task.FromResult(_values.SingleOrDefault(x => x.Contributor.Id == id));
            
        public async Task<IEnumerable<Observation>> GetAllObservationsAsync()
            => await Task.FromResult(_values.ToList());
            
        

    }
}