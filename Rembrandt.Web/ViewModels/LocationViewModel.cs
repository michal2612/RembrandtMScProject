using System.Collections;
using System.Collections.Generic;
using Rembrandt.Contracts.Classes.Dataset;
using Rembrandt.Contracts.Classes.Stats;

namespace Rembrandt.Web.ViewModels
{
    public class LocationViewModel 
    {
        public ObservationStatDto ObservationStatDto { get; set; }
        public IEnumerable<ObservationDto> ObservationsDto { get; set; }
    }
}