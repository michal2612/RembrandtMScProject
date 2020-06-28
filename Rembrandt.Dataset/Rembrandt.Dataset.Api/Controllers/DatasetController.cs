using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rembrandt.Dataset.Infrastructure.Services;
using Rembrandt.Dataset.Infrastructure.DTO;
using Rembrandt.Dataset.Core.Helpers;
using Rembrandt.Dataset.Infrastructure.Mappers;

namespace Rembrandt.Dataset.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DatasetController : ControllerBase
    {
        private readonly IDatasetService _datasetService;
        private readonly IAddDataService _addDataService;


        public DatasetController(IDatasetService datasetService, IAddDataService addDataService)
        {
            _datasetService = datasetService;
            _addDataService = addDataService;
        }

        [HttpGet("{id}")]
        public async Task<ObservationDto> GetSingleObservationDtoAsync(int id)
            => await _datasetService.GetObservationAsync(id);

        [HttpGet]
        public async Task<IEnumerable<ObservationDto>> PostObservationDtoCollectionAsync()
            => await _datasetService.GetAllObservationsAsync();


        [HttpPost("singleObservation")]
        public async Task<IActionResult> PostSingleObservationJsonAsync(ObservationDto observation)
        {
            await _addDataService.AddObservationDtoAsync(observation);
            return Ok(observation);
        }
        
        [HttpPost("MultipleObservattions")]
        public async Task<IActionResult> PostMultipleObservationsAsync(IEnumerable<ObservationDto> observations)
        {
            await _addDataService.AddObservationsDtoAsync(observations);
            return Ok(observations);
        }

        [HttpPost("DefaultObservation")]
        public async Task<IActionResult> PostDefaultObservation(DefaultObservation defaultObservation)
        {
            var observationDto = DefaultToObservationDto.ConvertDefaultToObservationDto(defaultObservation);
            return Ok(observationDto);
        }
    }
}