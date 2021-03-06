using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rembrandt.DatasetStats.Core.Repository;
using Rembrandt.DatasetStats.Infrastructure;
using Rembrandt.DatasetStats.Infrastructure.Mappers;
using Rembrandt.DatasetStats.Infrastructure.Services;

namespace Rembrandt.DatasetStats.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton<IStatsRepository, StatsRepository>();
            services.AddSingleton(AutoMapperConfig.Initialize());
            
            services.AddScoped<IStatsService, StatsService>();
            services.AddScoped<IUpdateObservations, UpdateObservations>();

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
