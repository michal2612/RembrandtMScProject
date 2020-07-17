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
            return View();
        }
        [Route("{siteId}")]
        public async Task<IActionResult> Location(int siteId)
        {
            var result = await _httpClient.GetAsync($"/stats-gateway/{siteId}");

            if(result.IsSuccessStatusCode)
                return View(JsonConvert.DeserializeObject<ObservationStatDto>(await result.Content.ReadAsStringAsync()));

            return RedirectToAction("Data");
        }
    }
}