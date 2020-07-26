using System.Collections.Generic;
using Rembrandt.Contracts.Classes.Dataset;

namespace Rembrandt.Contracts.Classes.Stats
{
    public class UpdateObservationStatDto
    {
        public int SiteId { get; set; }
        
        public IEnumerable<ObservationDto> Observations { get; set; }
    }
}