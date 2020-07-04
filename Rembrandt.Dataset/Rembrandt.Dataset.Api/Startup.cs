using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rembrandt.Dataset.Core.Repositories;
using Rembrandt.Dataset.Infrastructure.Mappers;
using Rembrandt.Dataset.Infrastructure.Repositories;
using Rembrandt.Dataset.Infrastructure.Services;

namespace Rembrandt.Dataset.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // Here we declare for what interfaces what service should be used <interface, class>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IObservationRepository,ObservationRepository>();
            services.AddScoped<IDatasetService,DatasetService>();
            services.AddScoped<IAddDataService, AddDataService>();

            services.AddSingleton(AutoMapperConfig.Initialize());
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
