using AutoMapper;
using GlasgowAstro.Obsy.Data;
using GlasgowAstro.Obsy.DataGrabber.MapperProfiles;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

[assembly: FunctionsStartup(typeof(GlasgowAstro.Obsy.DataGrabber.Startup))]

namespace GlasgowAstro.Obsy.DataGrabber
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {           
            var config = new ConfigurationBuilder();
            config.SetBasePath(Environment.CurrentDirectory);
            config.AddJsonFile("appsettings.json", false);
            if (Environment.GetEnvironmentVariable("AZURE_FUNCTIONS_ENVIRONMENT") == "Development")
            {
                config.AddUserSecrets<Startup>(false);
            }
            config.AddEnvironmentVariables();            
            builder.Services.AddSingleton<IConfiguration>(config.Build());

            builder.Services.AddSingleton(typeof(IRepository<>), typeof(MongoRepository<>));
            builder.Services.AddHttpClient();
            builder.Services.AddAutoMapper(profileAssemblyMarkerTypes: typeof(AsteroidProfile));
        }
    }
}
