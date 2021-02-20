using AutoMapper;
using GlasgowAstro.Obsy.Api.Authentication;
using GlasgowAstro.Obsy.Api.MapperProfiles;
using GlasgowAstro.Obsy.Data;
using GlasgowAstro.Obsy.Data.Abstractions;
using GlasgowAstro.Obsy.Services;
using GlasgowAstro.Obsy.Services.Abstractions;
using GlasgowAstro.Obsy.Services.MapperProfiles;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Net.Http.Headers;
using System.Text;

namespace GlasgowAstro.Obsy.Api
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

            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            services.AddHsts(options =>
            {
                options.Preload = true;
                options.IncludeSubDomains = true;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GlasgowAstro.Obsy API", Version = "v1" });
            });

            // Note: These auth creds for the MPC web service are already publicly available:           
            // https://minorplanetcenter.net/web_service/
            var authToken = Encoding.ASCII.GetBytes(
                $"{Configuration.GetValue<string>("MpcUsername")}:{Configuration.GetValue<string>("MpcPassword")}");
            
            services.AddHttpClient("MpcClient", c =>
            {
                c.BaseAddress = new Uri(Configuration.GetValue<string>("MpcBaseUrl"));
                c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(authToken));
            });
            
            services.AddAutoMapper(typeof(AsteroidProfile), typeof(ObservationProfile));
            services.AddSingleton(typeof(IMongoRepository<>), typeof(MongoRepository<>));
            services.AddSingleton<IAsteroidDataService, AsteroidDataService>();
            services.AddSingleton<IAsteroidObservationService, AsteroidObservationService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //builder.AddUserSecrets<Startup>();
            } 
            else
            {
                app.UseHsts();              
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "GlasgowAstro.Obsy API v1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();
            
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
