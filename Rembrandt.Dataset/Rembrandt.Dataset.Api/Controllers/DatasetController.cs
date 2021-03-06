using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rembrandt.Dataset.Infrastructure.Services;
using System.Text.Json;
using Rembrandt.Contracts.Classes.Dataset;

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

        [HttpGet]
        public async Task<IEnumerable<ObservationDto>> PostObservationDtoCollectionAsync()
            => await _datasetService.GetAllObservationsAsync();

        [HttpGet("{id}")]
        public async Task<IEnumerable<ObservationDto>> GetSingleObservationDtoAsync(string id)
            => await _datasetService.GetObservationsAsync(id);

        [HttpGet("/sites/{siteId}")]
        public async Task<IEnumerable<ObservationDto>> GetMultipleObservationsDtobySiteIdAsync(int siteId)
            => await _datasetService.GetMultipleObservationsDtobySiteIdAsync(siteId);

        [HttpPost("single")]
        public async Task<IActionResult> PostSingleObservationJsonAsync(ObservationDto observation)
        {
            await _addDataService.AddObservationDtoAsync(observation);
            return Ok(observation);
        }
        
        [HttpPost("multiple")]
        public async Task<IActionResult> PostMultipleObservationsAsync(IEnumerable<ObservationDto> observations)
        {
            await _addDataService.AddObservationsDtoAsync(observations);
            return Ok(observations);
        }
        
        [HttpPost("defaultSingle")]
        public async Task<IActionResult> PostDefaultObservation(DefaultObservation defaultObservation)
        {
            await _addDataService.AddObservationDtoAsync(defaultObservation);
            return Ok(defaultObservation);
        }

        [HttpPost("defaultMultiple")]
        public async Task<IActionResult> PostMultipleDefaultObservationsAsync(IEnumerable<DefaultObservation> defaultObservations)
        {
            await _addDataService.AddObservationsDtoAsync(defaultObservations);
            return Ok(defaultObservations);
        }

        [HttpPost("defaultMultipleList")]
        public async Task<IActionResult> PostMultipleDefaultListAsync(JsonElement defaultMultipleList)
        {
            await _addDataService.AddMultipleDefaultListAsync(defaultMultipleList);
            return Ok(defaultMultipleList);
        }
    }
}