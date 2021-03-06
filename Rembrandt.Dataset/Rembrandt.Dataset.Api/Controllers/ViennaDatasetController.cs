using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rembrandt.Contracts.Classes.Dataset.ViennaObservations;
using Rembrandt.Dataset.Infrastructure.Services;

namespace Rembrandt.Dataset.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ViennaDatasetController : ControllerBase
    {
        private readonly IAddViennaService _viennaService;

        private readonly IViennaDatasetService _viennaDataset;

        public ViennaDatasetController(IAddViennaService viennaService, IViennaDatasetService viennaDataset)
        {
            _viennaService = viennaService;
            _viennaDataset = viennaDataset;
        }

        [HttpGet]
        public async Task<IEnumerable<ViennaObservationDto>> ReturnAllObservationsAsync()
            => await _viennaDataset.GetAllObservationsAsync();

        [HttpGet("{userId}")]
        public async Task<IEnumerable<ViennaObservationDto>> ReturnObservationsByUserIdAsync(string userId)
            => await _viennaDataset.GetObservationsByIdAsync(userId);

        [HttpPost]
        public async Task AddSingleObservationAsync(ViennaObservationDto viennaObservationDto)
            => await _viennaService.AddObservationAsync(viennaObservationDto);

        [HttpPost("multiple")]
        public void AddMultipleObservationsAsync(IEnumerable<ViennaObservationDto> viennaObservationsDto)
            => _viennaService.AddObservationsAsync(viennaObservationsDto);

        [HttpPost("multipleDefault")]
        public async Task<IActionResult> AddMultipleObservationsAsync(JsonElement viennaObservations)
        {
            await _viennaService.AddObservationsJsonAsync(viennaObservations);
            return Ok();
        }
    }
}