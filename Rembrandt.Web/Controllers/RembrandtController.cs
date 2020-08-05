using System;
using System.Net.Http;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rembrandt.Contracts.Classes.Dataset;
using Rembrandt.Contracts.Classes.Stats;
using Rembrandt.Web.ViewModels;

namespace Rembrandt.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class RembrandtController : Controller
    {
        readonly HttpClient _httpClient;
        
        readonly IPublishEndpoint _publishEndpoint;


        public RembrandtController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;

            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("http://51.104.49.19:5000")
            };
        }

        public async Task<IActionResult> Data()
        {
            return await Task.FromResult(View());
        }

        [Route("{siteId}")]
        public async Task<IActionResult> Location(int siteId)
        {
            var result = await _httpClient.GetAsync($"/stats-gateway/{siteId}");
            var resultObservations = await _httpClient.GetAsync($"/sites-gateway/{siteId}");

            if(!result.IsSuccessStatusCode)
                return Content("Something went wrong!");

            var locationViewModel = new LocationViewModel()
            {
                ObservationStatDto = JsonConvert.DeserializeObject<ObservationStatDto>(await result.Content.ReadAsStringAsync()),
                ObservationsDto = JsonConvert.DeserializeObject<ObservationDto[]>(await resultObservations.Content.ReadAsStringAsync())
            };
            return View(locationViewModel);
        }

        public async Task<IActionResult> Add()
        {
            return await Task.FromResult(View(new ObservationDto() {Activities = new ActivitiesDto(), Attributes = new AttributesDto()}));
        }

        [HttpPost]
        public async Task<IActionResult> Submit(ObservationDto observationDto)
        {
            var cookie = Request.Cookies["jwtToken"];

            if(observationDto == null)
                throw new ArgumentNullException("Observation can't be null!");

            observationDto.Source = "http://rembrandt-project.ukwest.cloudapp.azure.com/" + HttpContext.Session.GetString(cookie);

            await _publishEndpoint.Publish<ObservationDto>(observationDto);

            return Ok();
        }
    }
}