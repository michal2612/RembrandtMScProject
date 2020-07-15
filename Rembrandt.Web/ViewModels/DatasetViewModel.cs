using System.Collections;
using System.Collections.Generic;
using Rembrandt.Contracts.Classes.Dataset;

namespace Rembrandt.Web.ViewModels
{
    public class DatasetViewModel
    {
        public IEnumerable<ObservationDto> ObservationsDto { get; set; }
    }
}