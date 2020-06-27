using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rembrandt.Dataset.Core.Models;
using Rembrandt.Dataset.Infrastructure.Services;
using System.Linq;

namespace Rembrandt.Dataset.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DatasetController : ControllerBase
    {
        private readonly IDatasetService _datasetService;


        public DatasetController(IDatasetService datasetService)
        {
            _datasetService = datasetService;
        }

        [HttpGet]
        public async Task<IEnumerable<Observation>> GetAsync()
        {
            var dataset = await _datasetService.GetAllObservationsAsync();

            return dataset;
        }

        [HttpPost]
        public async Task PostAsync(Observation observation)
        {
            
        }
    }
}