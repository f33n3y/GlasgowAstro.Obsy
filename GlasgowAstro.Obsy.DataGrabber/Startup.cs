using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net;
using System.Net.Http;

[assembly: FunctionsStartup(typeof(GlasgowAstro.Obsy.DataGrabber.Startup))]

namespace GlasgowAstro.Obsy.DataGrabber
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddHttpClient<MPCDataGrabber>("DataGrabberClient");
        }
    }
}
