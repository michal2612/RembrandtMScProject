using System;
using System.Threading.Tasks;
using MassTransit;
using Rembrandt.Contracts.Classes.Dataset;

namespace Rembrandt.Web.Services
{
    public class EventConsumer : IConsumer<ObservationDto>
    {
        public async Task Consume(ConsumeContext<ObservationDto> context)
        {
            await Console.Out.WriteAsync(context.Message.SiteId.ToString());
        }
    }
}