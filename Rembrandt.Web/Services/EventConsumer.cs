using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using Newtonsoft.Json;
using Rembrandt.Contracts.Classes.Dataset;

namespace Rembrandt.Web.Services
{
    public class EventConsumer : IConsumer<ObservationDto>
    {
        readonly HttpClient _client;
        
        public EventConsumer()
        {
            _client = new HttpClient() {
                BaseAddress = new Uri("http://51.104.49.19:5000")
            };
        }
        public async Task Consume(ConsumeContext<ObservationDto> context)
        {
            var data = new StringContent(JsonConvert.SerializeObject(context.Message), Encoding.UTF8, "application/json");
            await _client.PostAsync("/dataset-gateway/single", data);

            await Console.Out.WriteAsync(JsonConvert.SerializeObject(context.Message));
        }
    }
}