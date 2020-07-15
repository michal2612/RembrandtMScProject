using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Rembrandt.Contracts.Classes.Dataset;
using Rembrandt.Web.ViewModels;

namespace Rembrandt.Web.Controllers
{
    [Route("[action]")]
    public class DataController : Controller
    {
        private ILogger<DataController> _logger;
        private HttpClient _httpClient;

        public DataController(ILogger<DataController> logger)
        {
            _logger = logger;
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("http://51.104.49.19:5000")
            };
        }

        public async Task<IActionResult> Data()
        {
            var datasetViewModel = new DatasetViewModel();
            var responseMessage = await _httpClient.GetAsync("/dataset-gateway");
            if(responseMessage.IsSuccessStatusCode)
                datasetViewModel.ObservationsDto = JsonConvert.DeserializeObject<ObservationDto[]>(responseMessage.Content.ReadAsStringAsync().Result);
                
            return View(datasetViewModel);
        }
    }
}