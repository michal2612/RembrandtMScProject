using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Rembrandt.Users.Core.Repositories;
using Rembrandt.Users.Infrastructure.Commands;
using Rembrandt.Users.Infrastructure.Mappers;
using Rembrandt.Users.Infrastructure.Repositories;
using Rembrandt.Users.Infrastructure.Services;
using Rembrandt.Users.Infrastructure.Services.Users;
using Rembrandt.Users.Infrastructure.Settings;

namespace Rembrandt.Users.Api
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
            services.AddMemoryCache();

            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddSingleton(AutoMapperConfig.Initialize());
            services.AddSingleton<IEncrypter, Encrypter>();

            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IRegisterService, RegisterService>();
            
            services.AddScoped<IJwtHandler, JwtHandler>();

            var Settings = new Settings();
            Configuration.Bind("Settings", Settings);
            services.AddSingleton(Settings);
            
            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o => {
                o.TokenValidationParameters.ValidIssuer = Settings.Issuer;
                o.TokenValidationParameters.ValidateAudience = Settings.ValidateAudience;
                o.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Settings.IssuerSigningKey));
            });

            services.AddControllers();
            services.AddMvc()
                .AddJsonOptions(options => {
                    options.JsonSerializerOptions.WriteIndented = true;
                });
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
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
