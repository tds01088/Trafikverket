using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http.Headers;
using Trafikverket.Application.Contracts.Infrastructure;
using Trafikverket.Application.Models;
using Trafikverket.Infrastructure.Services;

namespace Trafikverket.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var options = new RelayServiceSettings();
            var section = configuration.GetSection("RelayServiceSettings");
            section.Bind(options);            

            services.AddTransient<ValidateHeaderHandler>();       
            services.AddHttpClient("trafikverket", c => {               
                c.BaseAddress = new Uri(options.ApiUrl);
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
            }).AddHttpMessageHandler<ValidateHeaderHandler>();
            services.AddTransient<IRelayCameraService, RelayCameraService>();
            

            return services;
        }
    }
}
