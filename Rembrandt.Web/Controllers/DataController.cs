using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Rembrandt.Contracts.Classes.Dataset;
using Rembrandt.Contracts.Classes.Stats;
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

        public IActionResult Location()
        {
            var observation = new ObservationStatDto()
            {
                SkipReasons = new Dictionary<string, int>()
                {
                    {"noskip", 14},
                    {"fluffy", 13},
                    {"nothing", 4}
                },
                SiteId = 14,
                Attributes = new AttributesStatDto()
                {
                    Lively = 6.13f,
                    Relaxing = 4.14f,
                    Tranquil = 8.23f,
                    Noisy = 3.12f,
                    Crowded = 6.21f,
                    Safe = 5.14f,
                    Beauty= 6.14f,
                    Biodiversity= 5.14f,
                    Trees= 3.14f,
                    Shrubs= 9.14f,
                    Lawns= 8.14f,
                    Flowers= 1.74f,
                    Natveg= 8.14f,
                    Benches= 2.14f,
                    Play= 7.14f,
                    Sports= 8.14f,
                    Garbage= 7.14f,
                    Veget= 4.24f,
                    Paths= 5.14f,
                    Facilities= 3.14f
                },
                Activities = new ActivitiesStatDto()
                {
                    Walking = true,
                    Jogging = false,
                    Biking = true,
                    Relaxing = true,
                    Socialising = false
                }
            };

            return View(observation);
        }
    }
}